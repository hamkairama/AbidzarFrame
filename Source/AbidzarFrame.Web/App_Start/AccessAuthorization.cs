using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap.Attributes;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Models;
using System.Web.Routing;

namespace AbidzarFrame.Web.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AccessAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isValid = false;
            GlobalVariableUser userVariable = (GlobalVariableUser)HttpContext.Current.Session["GlobalUserVariable"];
            if (userVariable != null )
            {
                isValid = true;
            }
            return isValid;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Account", action = "LogOff", area = "" }));
        }


    }

}