using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using AbidzarFrame.Core.Mvc.Controllers;
using AbidzarFrame.Core.Mvc.Helpers;
using System.Web.Security;
using System.Security.Principal;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class DirectToLastRequestRule : IRequestRoutingRule
    {
        private ResultExecutedContext context = null;
        private ActionRequestToken token = null;
        private EnhancedController controller = null;

        void IRequestRoutingRule.Init(EnhancedController controller, ResultExecutedContext context, ActionRequestToken token)
        {
            this.context = context;
            this.token = token;
            this.controller = controller;
        }

        public String[] ApplicableMethods
        {
            get { return RoutingMethods.Any(); }
        }

        public virtual bool Trigger()
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated) {
                return false;
            }

            String _requestDirected = (String)context.HttpContext.Session[WebConstants.KEY_REQUEST_RIDRECT_INDICATOR];
            //ActionRequestToken _lastRequest = (ActionRequestToken)context.HttpContext.Session[WebConstants.KEY_LAST_REQUEST];
            ActionRequestToken _lastRequest = controller.LastRequestToken;

            return ("Y".Equals(_requestDirected) && (_lastRequest != null)  && 
                context.HttpContext.User.Identity.IsAuthenticated && controller.IsSameToLastUser());
        }

        public virtual void Execute()
        {
            //ActionRequestToken _lastRequest = (ActionRequestToken)context.HttpContext.Session[WebConstants.KEY_LAST_REQUEST];
            ActionRequestToken _lastRequest = controller.LastRequestToken;

            //context.HttpContext.Session[WebConstants.KEY_REQUEST_RIDRECT_INDICATOR] = null;
            //context.HttpContext.Session[WebConstants.KEY_LAST_REQUEST] = null;
            controller.ClearLastRequestToken();
            context.HttpContext.Response.Redirect(_lastRequest.FullUrl, true);
        }
    }
}
