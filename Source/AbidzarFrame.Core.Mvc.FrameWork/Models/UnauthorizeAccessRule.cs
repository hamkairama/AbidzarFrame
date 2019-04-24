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
    public class UnauthorizeAccessRule : IRequestRoutingRule
    {

        private ResultExecutedContext context = null;
        private ActionRequestToken token = null;
        private EnhancedController controller = null;

        protected ResultExecutedContext Context
        {
            get
            {
                return context;
            }
        }

        protected ActionRequestToken Token
        {
            get
            {
                return this.token;
            }
        }

        protected EnhancedController Controller
        {
            get
            {
                return this.controller;
            }
        }
            

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
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            bool authorizationFail = false;
            FormsAuthenticationTicket authTicket = null;
            HttpCookie authCookie = context.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception e)
            {
                authorizationFail = true;
            }
            String[] _roles = UserRoleManager.StringToRoles(authTicket.UserData);
            context.HttpContext.User = new System.Security.Principal.GenericPrincipal(context.HttpContext.User.Identity, _roles);

            return authorizationFail || !IsAuthorized();
        }

        private bool IsAuthorized()
        {
            IPrincipal user = context.HttpContext.User;
            UserRoleManager userManager = GetUserRoleManager();

            List<String> roles = userManager.GetUserRoles(user);
            bool authorized = false;
            foreach (String e in roles)
            {
                authorized = authorized || userManager.CheckAuthorization(e, token.Controller, token.Action);
                if (authorized) break;
            }
            return authorized;
        }

        private UserRoleManager GetUserRoleManager()
        {
            UserRoleManager _manager = (UserRoleManager)context.HttpContext.Application[WebConstants.KEY_USER_ROLES_MANAGER];
            if (_manager == null)
            {
                _manager = new UserRoleManager();
                context.HttpContext.Application[WebConstants.KEY_USER_ROLES_MANAGER] = _manager;
            }
            return _manager;
        }

        public virtual void Execute()
        {
            String url = ApplicationSetting.GetInstance().UnauthorizedAccessErrorPageUrl;
            if (!string.IsNullOrEmpty(url))
            {
                url = controller.Url.Content(url);
                if (!url.Equals(token.FullUrl))
                {
                    context.HttpContext.Response.Redirect(url, true);
                }
            }
            else
            {
                context.HttpContext.Response.StatusCode = 401;
            }
        }
    }
}
