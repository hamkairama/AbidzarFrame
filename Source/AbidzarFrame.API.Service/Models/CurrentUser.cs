using AbidzarFrame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbidzarFrame.API.Service.Models
{
    public class CurrentUser : AuthorizeLogin
    {
        public static string GetCurrentUserId()
        {
            LoginViewModel result = (LoginViewModel)HttpContext.Current.Session["loginSession"];
            if (result != null)
                return result.IdUser;
            else
                return null;
        }

        public static string GetCurrentPassword()
        {
            LoginViewModel result = (LoginViewModel)HttpContext.Current.Session["loginSession"];
            if (result != null)
                return result.Sandi;
            else
                return null;
        }

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public static string GetUrl()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string host = HttpContext.Current.Request.Url.Host;

            // Dim a As String = url.Split("/")(0)

            return url;
        }
        
    }
}

