using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbidzarFrame.Web.Helpers
{
    public class CurrentUser : AuthorizeLogin
    {
        public static string GetCurrentUserId()
        {
            UserResult result = (UserResult)HttpContext.Current.Session["UserResult"];
            if (result != null)
                return result.Nik;
            else
                return null; 
        }
        public static string GetCurrentPhoto()
        {
            UserResult result = (UserResult)HttpContext.Current.Session["UserResult"];
            if (result != null)
                return result.NamaFile;
            else
                return null;
        }
        public static string GetCurrentRole()
        {
            UserResult result = (UserResult)HttpContext.Current.Session["UserResult"];
            if (result != null)
                return result.IdRole;
            else
                return null;
        }

        public static bool IsApiLogin()
        {
            object result = (object)HttpContext.Current.Session["ApiLogin"];
            if (result != null)
                return true;
            else
                return false;
        }

        public static bool IsAdmin()
        {
            UserResult result = (UserResult)HttpContext.Current.Session["UserResult"];
            if (result != null)
            {
                if (GetCurrentRole().ToUpper() == "ADM" || GetCurrentRole().ToUpper() == "SA")
                    return true;
                else
                    return false;
            }                
            else
            {
                return false;
            }            
        }

        public static string GetCurrentKodeRt()
        {
            UserResult result = (UserResult)HttpContext.Current.Session["UserResult"];
            if (result != null)
                return result.KodeRt;
            else
                return null;
        }

        public static string GetCurrentUserName()
        {
            GlobalVariableUser result = (GlobalVariableUser)HttpContext.Current.Session["GlobalUserVariable"];
            if (result != null)
                return result.NamaUser;
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
            return url;
        }

        public static string GetPath()
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            return path;
        }

        public static string GetHost()
        {
            string host = HttpContext.Current.Request.Url.Host;
            return host;
        }

        public static string GetNamaPerusahaan()
        {
            string result = (string)HttpContext.Current.Session["NamaPerusahaan"];
            if (result != null)
                return result;
            else
                return null;
        }

        public static Domain.Models.RwBaseModel GetObjectRw()
        {
            Domain.Models.RwBaseModel result = (Domain.Models.RwBaseModel)HttpContext.Current.Session["AreaRw"];
            return result;
        }

        public static List<Master.Interface.Dto.TestimoniResult> GetListTestimoni()
        {
            List<Master.Interface.Dto.TestimoniResult> result = (List<Master.Interface.Dto.TestimoniResult>)HttpContext.Current.Session["Testimoni"];
            return result;
        }

    }
}

