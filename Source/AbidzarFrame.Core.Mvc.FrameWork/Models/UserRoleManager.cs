using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using AbidzarFrame.Core.Mvc.Helpers;
using System.Web.Mvc;
using System.Security.Principal;
using System.Web.Security;
using System.Web;
using System.Collections.Specialized;
using System.Collections;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class UserRoleManager : IDisposable
    {

        public const char ROLE_SEPARATOR = ',';
        public const String _userRolesLock = "";

        protected ViewPage _dummy = null;
        protected UserRoles _userRoles = null;

        public UserRoleManager()
        {
            _dummy = new ViewPage();
            init();
        }

        public bool IsInRole(IPrincipal user, string role)
        {
            if (user.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)user.Identity).Ticket;
                return IsInRole(ticket, role);
            }

            return user.IsInRole(role);
        }

        public bool IsInRole(FormsAuthenticationTicket ticket, string role)
        {
            string[] roleList = StringToRoles(ticket.UserData);
            foreach (string r in roleList)
            {
                if (!string.IsNullOrEmpty(r) && r.Equals(role))
                {
                    return true;
                }
            }
            return false;
        }

        public List<String> GetUserRoles(IPrincipal user)
        {
            List<String> _roles = new List<String>();
            foreach (String r in _userRoles.RoleList)
            {
                if (IsInRole(user, r))
                {
                    _roles.Add(r);
                }
            }
            _roles.Add("*");
            return _roles;
        }

        public bool CheckAuthorization(String userRole, String controller, String action)
        {
            bool isAuthorized = false;
            foreach (UserRole r in _userRoles.RightList)
            {
                if (r.isMatched(userRole, controller, action))
                {
                    isAuthorized = true;
                }
            }
            return isAuthorized;
        }

        protected void init()
        {
            ReadUserRoles();
        }

        public static String RolesToString(String[] roles)
        {
            String rolesString = "";
            foreach (String e in roles)
            {
                if (!String.IsNullOrEmpty(e))
                {
                    rolesString += e + ROLE_SEPARATOR;
                }
            }
            return rolesString.Substring(0, rolesString.Length - 1);
        }

        public static String[] StringToRoles(String rolesString)
        {
            return rolesString.Split(ROLE_SEPARATOR);
        }

        private HttpCookie GetAuthorizedCookie(String userId, String[] roles)
        {
            String rolesString = RolesToString(roles);
            int timeOut = ApplicationSetting.GetInstance().TimeOut;

            FormsAuthentication.SetAuthCookie(userId, false);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddMinutes(timeOut), false, rolesString);
            String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            return authCookie;
        }

        public void SetUserSecurityInformation(System.Web.HttpContext context, String userId, String[] roles)
        {
            //String rolesString = RolesToString(roles);
            //int timeOut = ApplicationSetting.GetInstance().TimeOut;

            //FormsAuthentication.SetAuthCookie(userId, false);
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddMinutes(timeOut), false, rolesString);
            //String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            //System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //context.Response.Cookies.Add(authCookie);
            context.Response.Cookies.Add(GetAuthorizedCookie(userId, roles));
        }

        public void SetUserSecurityInformation(System.Web.HttpContextBase context, String userId, String[] roles)
        {
            //String rolesString = RolesToString(roles);
            //int timeOut = ApplicationSetting.GetInstance().TimeOut;

            //FormsAuthentication.SetAuthCookie(userId, false);
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddMinutes(timeOut), false, rolesString);
            //String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            //System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //context.Response.Cookies.Add(authCookie);
            context.Response.Cookies.Add(GetAuthorizedCookie(userId, roles));
        }

        protected void ReadUserRoles()
        {
            if (_userRoles == null)
            {
                lock (_userRolesLock)
                {
                    String file = GetAuthorizationFilePath();
                    if (!File.Exists(file))
                    {
                        CreateDefaultUserProfile(file);
                    }
                    FileStream _in = File.OpenRead(file);
                    XmlSerializer xmlReader = new XmlSerializer(new UserRoles().GetType());
                    _userRoles = (UserRoles)xmlReader.Deserialize(_in);
                    _in.Close();

                    foreach (String map in _userRoles.Sitemap)
                    {
                        ReadSitemaps(map, ref _userRoles);
                    }
                }
            }
        }

        protected void ReadSitemaps(String siteMap, ref UserRoles roles)
        {
            NameValueCollection attributes = null;
            XmlSiteMapProvider provider = null;

            try
            {
                attributes = new NameValueCollection(1);
                attributes.Add("siteMapFile", Utility.ToFullUrl(siteMap));
                provider = new XmlSiteMapProvider();

                //r.Write("<LoggedInTemplate>");
                provider.Initialize("default", attributes);
                ReadSiteNodeSetting(provider.RootNode);
            }
            catch (Exception e) {
                String a = e.Message;
            }
            finally {
                attributes.Clear();
                attributes = null;

                provider.Dispose();
            }
        }

        protected void ReadSiteNodeSetting(SiteMapNode node)
        {
            String url = node.Url;
            if (!string.IsNullOrEmpty(url))
            {
                ActionRequestToken token = Utility.UrlToAction(url);
                if (token != null)
                {
                    IList roles = node.Roles;
                    foreach (String r in roles)
                    {
                        if (string.IsNullOrEmpty(r)) continue;

                        UserRole right = new UserRole() { Role = r.Trim(), Action = "*", Controller = token.Controller };

                        if (!_userRoles.RoleList.Contains(r)) _userRoles.RoleList.Add(r);
                        if (!_userRoles.RightList.Contains(right)) _userRoles.RightList.Add(right);
                    }
                    roles = null;
                }
            }
            foreach (SiteMapNode n in node.ChildNodes)
            {
                ReadSiteNodeSetting(n);
            }
        }

        protected void CreateDefaultUserProfile(String filePath)
        {
            System.IO.Directory.CreateDirectory(filePath);
            System.IO.Directory.Delete(filePath);

            UserRoles roles = new UserRoles();
            roles.RoleList.Add("*");
            roles.RightList.Add(new UserRole() { Role = "*", Action = "*", Controller = "*" });

            FileStream _out = new FileStream(filePath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(roles.GetType());
            xmlSerializer.Serialize(_out, roles);
            _out.Close();
        }

        protected String GetAuthorizationFilePath()
        {
            String userFile = ApplicationSetting.GetInstance().AuthorizationFilePath;
            if (userFile.Contains("~"))
            {
                userFile = _dummy.Server.MapPath(userFile);
            }
            return userFile;
        }

        public static FormsAuthenticationTicket GetAuthenticationTicket(HttpContextBase context)
        {
            return ReadAuthenticationTicket(context.Request.Cookies[FormsAuthentication.FormsCookieName]);
        }

        public static FormsAuthenticationTicket GetAuthenticationTicket(HttpContext context)
        {
            return ReadAuthenticationTicket(context.Request.Cookies[FormsAuthentication.FormsCookieName]);
        }

        private static FormsAuthenticationTicket ReadAuthenticationTicket(HttpCookie cookie)
        {
            FormsAuthenticationTicket ticket = null;
            try
            {
                ticket = FormsAuthentication.Decrypt(cookie.Value);
            }
            catch (Exception e)
            {
                // do nothing
            }
            return ticket;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._userRoles = null;
                    this._dummy = null;
                }
                
            }
        }

        ~UserRoleManager()
        {
            Dispose(false);

            this._userRoles = null;
            this._dummy = null;
        }

    }
}
