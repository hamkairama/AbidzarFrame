using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Controllers
{
    public class AllowRedirectedGetOnlyAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String method = filterContext.HttpContext.Request.HttpMethod;
            String requestUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
            String redirectUrl = (String)filterContext.HttpContext.Session[WebConstants.KEY_LAST_REQUEST_REDIRECTED];

            bool canPass = true;
            if (String.IsNullOrEmpty(redirectUrl))
            {
                canPass = false;
            }
            else if ("GET".Equals(method))
            {
                if (!redirectUrl.Equals(requestUrl))
                {
                    canPass = false;
                }
            }

            if (!canPass)
            {
                throw new UnauthorizedAccessException();
            }
        }

    }

}
