using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AbidzarFrame.Core.Mvc.Controllers;
using AbidzarFrame.Core.Mvc.Helpers;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class ActionRequestToken
    {

        protected String controller = null;
        protected String action = null;
        protected String queryString = null;
        protected const String routingFormat = "~/{0}/{1}";

        public ActionRequestToken(String controller, String action) :
            this(controller, action, "")
        { }

        public ActionRequestToken(String controller, String action, String queryString)
        {
            this.controller = controller;
            this.action = action;
            this.queryString = queryString;
        }

        public ActionRequestToken(ActionExecutingContext context) :
            this(context.ActionDescriptor.ControllerDescriptor.ControllerName, context.ActionDescriptor.ActionName, context.HttpContext.Request.QueryString.ToString())
        {
            //this.controller = context.ActionDescriptor.ControllerDescriptor.ControllerName;
            //this.action = context.ActionDescriptor.ActionName;
            //this.queryString = context.HttpContext.Request.QueryString.ToString();
        }

        public ActionRequestToken(ResultExecutedContext context) :
            this((String) context.RouteData.Values["controller"],(String) context.RouteData.Values["action"], context.HttpContext.Request.QueryString.ToString())
        {
            //this.controller = (String) context.RouteData.Values["controller"];
            //this.action = (String) context.RouteData.Values["action"];
            //this.queryString = context.HttpContext.Request.QueryString.ToString();
        }

        public String Controller
        {
            get
            {
                return controller;
            }
            set
            {
                controller = value;
            }
        }

        public String Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }

        public String QueryString
        {
            get
            {
                return queryString;
            }
            set
            {
                queryString = value;
            }
        }

        public String DestinationUrl
        {
            get
            {
                String url = String.Format(routingFormat, controller, action);
                return url;
            }
        }

        public String RawUrl
        {
            get
            {
                String url = this.DestinationUrl;
                if (!String.IsNullOrEmpty(queryString))
                {
                    url += "?" + queryString;
                }
                return url;
            }
        }

        public String FullUrl
        {
            get
            {
                return Utility.ToFullUrl(RawUrl);
            }
        }

        public override int GetHashCode()
        {
            return new { @A = this.controller, @b = this.action, @c = this.queryString }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (obj.GetType().Equals(typeof(ActionRequestToken)))
                {
                    ActionRequestToken a = (ActionRequestToken) obj;
                    return (a.controller.Equals(this.controller) && a.action.Equals(this.action) && a.queryString.Equals(this.queryString));
                }
                else 
                {
                    return false;
                }
            }
        }

    }
}
