using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AbidzarFrame.Core.Mvc.Models;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;
using System.Collections;
using AbidzarFrame.Core.Mvc.Models.Menu;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public static class HtmlHelperExtender
    {
        private static bool IsAuthorized(IList nodeRoles, string[] userRoles) {
            //string[] roles = userRoles.Split(UserRoleManager.ROLE_SEPARATOR);
            bool matched = false;
            foreach(string e in nodeRoles) {
                matched = matched | userRoles.Contains(e);
            }
            return matched;
        }

        public static string BuildMenu(this HtmlHelper helper, string[] userRoles, string siteMap, IMenuCreator menu)
        {
            menu.WriteMenu(helper.ViewContext.HttpContext, userRoles, siteMap);
            return "";
        }

        public static string BuildMenu(this HtmlHelper helper, string siteMap, string separatorImage, string headerCss, string childCss)
        {
            IMenuCreator menu = new BasicMenuCreator(separatorImage, headerCss, childCss);

            HttpContextBase h = helper.ViewContext.HttpContext;
            HttpResponseBase resp = h.Response;
            FormsAuthenticationTicket ticket = UserRoleManager.GetAuthenticationTicket(h);

            if (ticket != null)
            {
                return BuildMenu(helper, ticket.UserData.Split(UserRoleManager.ROLE_SEPARATOR), siteMap, menu);
            }
            return "";
        }


        public static string BuildMenu(this HtmlHelper helper, string[] userRoles, string siteMap, string separatorImage, string headerCss, string childCss)
        {
            IMenuCreator menu = new BasicMenuCreator(separatorImage, headerCss, childCss);

            HttpContextBase h = helper.ViewContext.HttpContext;
            HttpResponseBase resp = h.Response;
            FormsAuthenticationTicket ticket = UserRoleManager.GetAuthenticationTicket(h);

            if (ticket != null)
            {
                return BuildMenu(helper, userRoles, siteMap, menu);
            }
            return "";
        }

        public static string BuildLevelMenu(this HtmlHelper helper, string[] userRoles, string siteMap, string separatorImage, string headerCss, string childCss, int maxLevel = 3)
        {
            IMenuCreator menu = new LevelMenuCreator(separatorImage, headerCss, childCss, maxLevel);

            HttpContextBase h = helper.ViewContext.HttpContext;
            HttpResponseBase resp = h.Response;
            FormsAuthenticationTicket ticket = UserRoleManager.GetAuthenticationTicket(h);

            if (ticket != null)
            {
                return BuildMenu(helper, userRoles, siteMap, menu);
            }
            return "";
        }
    }
}
