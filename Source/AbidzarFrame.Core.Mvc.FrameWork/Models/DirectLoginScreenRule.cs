using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Core.Mvc.Controllers;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class DirectLoginScreenRule : IRequestRoutingRule
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

        private Boolean isUnprotectedRequest(String actionRequestString)
        {
            String freeFunctions = ApplicationSetting.GetInstance().UnprotectedActions;
            char[] filterChar = { '\r','\n','\t', ' '};
            foreach (string url in freeFunctions.Split(new char[] { ';' }))
            {
                if ( !String.IsNullOrEmpty(url) &&  url.Trim(filterChar).ToUpper().Equals(actionRequestString.ToUpper()))
                {
                    return true;
                }
                
            }
            return false;
        }

        public String[] ApplicableMethods
        {
            get { return RoutingMethods.Any(); }
        }

        public virtual bool Trigger()
        {
            //if (context.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return false;
            //}
            //String requestMethod = context.HttpContext.Request.HttpMethod;
            //String url = controller.Url.Content(ApplicationSetting.GetInstance().LoginUrl);
            //if (url.Equals(token.FullUrl) || isUnprotectedRequest(token.DestinationUrl) || !"GET".Equals(requestMethod))
            //{
            //    return false;
            //}
            //return true;
            return (!context.HttpContext.User.Identity.IsAuthenticated);
        }

        protected virtual String GetLoginUrl()
        {
            return ApplicationSetting.GetInstance().LoginUrl;
        }

        public virtual void Execute()
        {
            String url = controller.Url.Content(GetLoginUrl());
            if (!url.Equals(token.FullUrl) && !isUnprotectedRequest(token.DestinationUrl))
            {
                //context.HttpContext.Session[WebConstants.KEY_LAST_REQUEST] = token;
                //context.HttpContext.Session[WebConstants.KEY_REQUEST_RIDRECT_INDICATOR] = "Y";
                controller.SaveLastRequestToken(token);
                context.HttpContext.Response.Redirect(url, true);
            }            
        }

    }
}
