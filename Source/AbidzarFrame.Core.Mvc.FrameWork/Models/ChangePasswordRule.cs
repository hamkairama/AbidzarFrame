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
    public class ChangePasswordRule : IRequestRoutingRule
    {
        private ResultExecutedContext _context = null;
        private ActionRequestToken _token = null;
        private EnhancedController _controller = null;

        protected  ResultExecutedContext context
        {
            get { return _context; }
        }

        void IRequestRoutingRule.Init(EnhancedController controller, ResultExecutedContext context, ActionRequestToken token)
        {
            this._context = context;
            this._token = token;
            this._controller = controller;
        }

        public String[] ApplicableMethods
        {
            get { return RoutingMethods.GetOnly(); }
        }

        public virtual bool Trigger()
        {
            if (!_context.HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            //if (controller.IsPasswordExpired(context.HttpContext.User))
            //{
            //    String url = controller.Url.Content(ApplicationSetting.GetInstance().ChangePasswordUrl);
            //    return !url.Equals(token.FullUrl);
            //}
            //else
            //{
            //    return false;
            //}
            return (_controller.IsPasswordExpired(_context.HttpContext.User));
        }

        protected virtual String GetChangePasswordUrl()
        {
            return ApplicationSetting.GetInstance().ChangePasswordUrl;
        }

        public virtual void Execute()
        {
            //String url = controller.Url.Content(ApplicationSetting.GetInstance().ChangePasswordUrl);
            String url = GetChangePasswordUrl();
            string[] chgPwdUrl = url.Split(';'); 
            bool isRedirected = false;
            foreach (string a in chgPwdUrl) {
                String b = _controller.Url.Content(a);
                if (b.Equals(_token.FullUrl)) {
                    isRedirected = true;
                    break;
                }
            }
            if (!isRedirected && chgPwdUrl.Length > 0)
            {
                _context.HttpContext.Response.Redirect(chgPwdUrl[0], true);
            }
        }
    }
}
