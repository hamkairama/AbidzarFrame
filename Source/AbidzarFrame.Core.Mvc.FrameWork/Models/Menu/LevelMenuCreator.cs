using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AbidzarFrame.Core.Mvc.Helpers;
using System.Web.Security;
using System.Collections.Specialized;

namespace AbidzarFrame.Core.Mvc.Models.Menu
{
    public class LevelMenuCreator : BasicMenuCreator
    {
        private int _maxLevel;
        private int _currentLevel;

        public LevelMenuCreator(string separatorImage, string headerCss, string childCss)
            : this(separatorImage, headerCss, childCss, 3) { }

        public LevelMenuCreator(string separatorImage, string headerCss, string childCss, int maxLevel)
            : base(separatorImage, headerCss, childCss)
        {
            _maxLevel = maxLevel;
            _currentLevel = 2;
        }
        
        protected override void ChildMenu(HttpContextBase context, HttpResponseBase response, SiteMapNode node, string[] userRoles)
        {
            if (IsDisplay(node))
            {
                response.Write("<li>");
                if (!string.IsNullOrEmpty(node.Url) && !node.Url.Substring(0, 10).Equals("javascript"))
                {
                    response.Write("<a href=\"" + Utility.ToFullUrl(node.Url) + "\">" + node.Title + "</a>");
                }
                else if (!string.IsNullOrEmpty(node.Url) && node.Url.Substring(0, 10).Equals("javascript"))
                {                   
                    response.Write("<a href=" + node.Url + ">" + node.Title +"</a>");
                }
                else
                {
                    response.Write("<a href=\"#\">" + node.Title + "</a>");
                }
                if (node.ChildNodes.Count > 0 && _currentLevel < _maxLevel )
                {
                    _currentLevel++;
                    response.Write("<ul>");
                    for (int k = 0; k < node.ChildNodes.Count; k++)
                    {
                        SiteMapNode h = node.ChildNodes[k];
                        if (IsAuthorized(h.Roles, userRoles))
                        {
                            ChildMenu(context, response, h, userRoles);
                        }
                    }
                    response.Write("</ul>");
                    _currentLevel--;
                }
                response.Write("</li>");
            }
        }
    }
}
