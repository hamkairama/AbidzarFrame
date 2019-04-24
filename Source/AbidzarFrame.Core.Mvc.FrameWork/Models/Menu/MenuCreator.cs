using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;
using AbidzarFrame.Core.Mvc.Helpers;
using System.Collections;
using System.Collections.Concurrent;
using AbidzarFrame.Core.Mvc.Controllers;

namespace AbidzarFrame.Core.Mvc.Models.Menu
{
    public abstract class MenuCreator : IMenuCreator
    {
        protected abstract void BeginRootMenu(HttpContextBase context, HttpResponseBase response, SiteMapNode node);

        protected abstract void ChildMenu(HttpContextBase context, HttpResponseBase response, SiteMapNode node, string[] userRoles);

        protected abstract void EndRootMenu(HttpContextBase context, HttpResponseBase response, SiteMapNode node);
        
        protected XmlSiteMapProvider GetXmlSiteMapProvider(HttpContextBase httpContext, string siteMap)
        {
            string fullPath = Utility.ToFullUrl(siteMap);
            ConcurrentDictionary<string, XmlSiteMapProvider> siteMapProviderDict 
                = (ConcurrentDictionary<string, XmlSiteMapProvider>)httpContext.Application[WebConstants.KEY_SITEMAP];

            if (siteMapProviderDict == null)
            {
                siteMapProviderDict = new ConcurrentDictionary<string, XmlSiteMapProvider>();
                httpContext.Application[WebConstants.KEY_SITEMAP] = siteMapProviderDict;
            }

            if (!siteMapProviderDict.ContainsKey(fullPath))
            {
                NameValueCollection attributes = new NameValueCollection(1);
                attributes.Add("siteMapFile", fullPath);
                XmlSiteMapProvider provider = new XmlSiteMapProvider();
                provider.Initialize("default", attributes);
                siteMapProviderDict.GetOrAdd(fullPath, provider);                     
            }

            XmlSiteMapProvider result = null;
            siteMapProviderDict.TryGetValue(fullPath, out result);
            return result;
        }

        public void WriteMenu(HttpContextBase httpContext, string[] userRoles, string siteMap)
        {
            HttpResponseBase resp = httpContext.Response;
            FormsAuthenticationTicket ticket = UserRoleManager.GetAuthenticationTicket(httpContext);

            if (ticket != null)
            {
                //NameValueCollection attributes = new NameValueCollection(1);
                //attributes.Add("siteMapFile", Utility.ToFullUrl(siteMap));
                //XmlSiteMapProvider provider = new XmlSiteMapProvider();

                ////r.Write("<LoggedInTemplate>");
                //provider.Initialize("default", attributes);

                XmlSiteMapProvider provider = GetXmlSiteMapProvider(httpContext, siteMap);
                for (int i = 0; i < provider.RootNode.ChildNodes.Count; i++)
                {
                    SiteMapNode e = provider.RootNode.ChildNodes[i];
                    if (IsAuthorized(e.Roles, userRoles))
                    {
                        BeginRootMenu(httpContext, resp, e);
                        for (int j = 0; j < e.ChildNodes.Count; j++)
                        {
                            SiteMapNode g = e.ChildNodes[j];
                            if (IsAuthorized(g.Roles, userRoles))
                            {
                                ChildMenu(httpContext, resp, g, userRoles);
                            }
                        }
                        EndRootMenu(httpContext, resp, e);
                    }
                }
            }
        }

        protected bool IsAuthorized(IList nodeRoles, string[] userRoles)
        {
            bool matched = false;
            if (nodeRoles == null || nodeRoles.Count == 0 || nodeRoles.Contains("*"))
            {
                matched = true;
            }
            else
            {
                foreach (string e in nodeRoles)
                {
                    matched = matched | (userRoles.Contains(e));
                    if (matched) break;
                }
            }
            return matched;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
