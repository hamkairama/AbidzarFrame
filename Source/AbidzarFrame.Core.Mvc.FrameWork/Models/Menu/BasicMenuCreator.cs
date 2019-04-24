using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AbidzarFrame.Core.Mvc.Helpers;

namespace AbidzarFrame.Core.Mvc.Models.Menu
{
    public class BasicMenuCreator : MenuCreator
    {
        private int maxMenuSize;
        private string separatorImage;
        private string headerCss;
        private string childCss;

        protected const String HIDEMENU = "HideMenu";
        protected const String TRUE_STRING = "true";

        public BasicMenuCreator(string separatorImage, string headerCss, string childCss) : 
            this(separatorImage, headerCss, childCss, 20)
        {}

        public BasicMenuCreator(string separatorImage, string headerCss, string childCss, int maxMenuSize)
        {
            this.separatorImage = separatorImage;
            this.headerCss = headerCss;
            this.childCss = childCss;
            this.maxMenuSize = maxMenuSize;
        }
        
        public int MaxMenuSize
        {
            get
            {
                return this.maxMenuSize;
            }
            set
            {
                this.maxMenuSize = value;
            }
        }

        public string SeparatorImage
        {
            get
            {
                return this.separatorImage;
            }
            set
            {
                this.separatorImage = value;
            }
        }

        public string HeaderCss
        {
            get
            {
                return this.headerCss;
            }
            set
            {
                this.headerCss = value;
            }
        }

        public string ChildCss
        {
            get
            {
                return this.childCss;
            }
            set
            {
                this.childCss = value;
            }
        }

        protected virtual Boolean IsDisplay(SiteMapNode node) {
            string s = node[HIDEMENU];  //node["HideMenu"];
            
            if (s == null) {
                return true;
            } else {
                if (TRUE_STRING.Equals(s.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

        protected override void BeginRootMenu(HttpContextBase context, HttpResponseBase response, SiteMapNode node)
        {
            if (IsDisplay(node)) {
                response.Write("<li class=\"" + headerCss + "\"><img src=\"" + Utility.ToFullUrl(separatorImage) + 
                        "\" align=\"right\" width=\"2px\" height=\"40px\" alt=\"\" />");

                int rootMenuHeight = 40;
                if (node.Title.Contains(" ") && node.Title.Length > maxMenuSize)
                    rootMenuHeight /= 2;

                if (!string.IsNullOrEmpty(node.Url))
                {
                    response.Write("<a href=\"" + Utility.ToFullUrl(node.Url) + "\" style='line-height:" + rootMenuHeight + "px' >" + node.Title + "</a>");
                }
                else
                {
                    response.Write("<a href=\"#\" style='line-height:" + rootMenuHeight + "px'>" + node.Title + "</a>");
                }
                response.Write("<ul class=\"" + childCss + "\">");
            }
        }

        protected override void ChildMenu(HttpContextBase context, HttpResponseBase response, SiteMapNode node, string[] userRoles)
        {
            if (IsDisplay(node))
            {
                response.Write("<li>");
                if (!string.IsNullOrEmpty(node.Url))
                {
                    response.Write("<a href=\"" + Utility.ToFullUrl(node.Url) + "\">" + node.Title + "</a>");
                }
                else
                {
                    response.Write("<a href=\"#\">" + node.Title + "</a>");
                }
                response.Write("</li>");
            }
        }

        protected override void EndRootMenu(HttpContextBase context, HttpResponseBase response, SiteMapNode node)
        {
            if (IsDisplay(node))
            {
                response.Write("</ul>");
                response.Write("</li>");
            }
        }

    }
}
