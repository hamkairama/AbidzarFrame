﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Core.Mvc.Models;
using System.Web.Security;
using System.Text;
using System.Web.SessionState;
using AbidzarFrame.Core.Mvc.Controllers;

namespace AbidzarFrame.Core.Mvc.WebServices
{
    public abstract class WebServiceBase
    {
        Logger logger = null;

        public WebServiceBase()
        {
            InitService();
        }

        protected HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        protected HttpApplicationState Application
        {
            get
            {
                return HttpContext.Current.Application;
            }
        }

        protected HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;

            }
        }

        private Logger GetLogger()
        {
            if (logger == null)
            {
                logger = Logger.GetInstance();
                Session[WebConstants.KEY_LOGGER] = logger;
            }
            return logger;
        }

        public virtual void InitService() { }

        public virtual bool IsPasswordExpired(System.Security.Principal.IPrincipal user)
        {
            return false;
        }

        public virtual bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public String CurrentUserId
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        public virtual bool IsSameToLastUser()
        {
            String lastUser = (String)Session[WebConstants.KEY_LAST_USER];
            String currUser = (String)Session[WebConstants.KEY_CURRENT_USER];

            if (string.IsNullOrEmpty(lastUser))
            {
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(currUser))
                    return false;
                else
                    return (lastUser.Equals(currUser));
            }
        }

        protected AppServiceLocator ServiceLocator
        {
            get
            {
                AppServiceLocator service = (AppServiceLocator)Session[AppServiceLocator.SESSION_APPLICATION_SERVICE];
                if (service == null)
                {
                    service = CreateServiceLocator();
                    Session[AppServiceLocator.SESSION_APPLICATION_SERVICE] = service;
                }
                return service;
            }
            set
            {
                Session[AppServiceLocator.SESSION_APPLICATION_SERVICE] = value;
            }
        }

        protected AppServiceLocator SharedServiceLocator
        {
            get
            {
                AppServiceLocator service = (AppServiceLocator)Application[AppServiceLocator.SESSION_APPLICATION_SERVICE];
                if (service == null)
                {
                    service = CreateSharedServiceLocator();
                    Application[AppServiceLocator.SESSION_APPLICATION_SERVICE] = service;
                }
                return service;
            }
            set
            {
                Application[AppServiceLocator.SESSION_APPLICATION_SERVICE] = value;
            }
        }

        protected virtual AppServiceLocator CreateServiceLocator()
        {
            return new AppServiceLocator();
        }

        protected virtual AppServiceLocator CreateSharedServiceLocator()
        {
            return new AppServiceLocator();
        }

        protected virtual LogData CreateLogData(LogData.STAGE stage, ControllerContext context)
        {
            return LogInformationReader.Read(stage, context);
        }

        //protected Errors UpdateWorkingViewModel(IWorkingViewModel model)
        //{
        //    return UpdateWorkingViewModel(model, null);
        //}

        //protected Errors UpdateWorkingViewModel(IWorkingViewModel model, Errors errors)
        //{
        //    if (errors == null)
        //    {
        //        errors = new Errors();
        //    }

        //    try
        //    {
        //        model.Read(Request);
        //    }
        //    catch (Exception e)
        //    {
        //        errors.Add(new ErrorVo("", "", e.Message));
        //    }

        //    if (!errors.HasError)
        //    {
        //        Errors errs = model.CheckIntegrity(Request);
        //        if (errs.HasError)
        //        {
        //            errors.Add(errs);
        //        }
        //    }
        //    return errors;
        //}

        private UserRoleManager GetUserRoleManager()
        {
            UserRoleManager _manager = (UserRoleManager)Application[WebConstants.KEY_USER_ROLES_MANAGER];
            if (_manager == null)
            {
                _manager = new UserRoleManager();
                Application[WebConstants.KEY_USER_ROLES_MANAGER] = _manager;
            }
            return _manager;
        }

        private Dictionary<String, SystemAccessRecord> UserTable
        {
            get
            {
                Dictionary<String, SystemAccessRecord> table = (Dictionary<String, SystemAccessRecord>)
                        Application[WebConstants.KEY_USER_TABLE];
                if (table == null)
                {
                    table = new Dictionary<String, SystemAccessRecord>();
                    Application[WebConstants.KEY_USER_TABLE] = table;
                }
                return table;
            }
        }

        private String CreateUserAccessTimeKey(String userId, String sessionId)
        {
            if (AcceptConcurrentLogin())
            {
                return userId + "{" + sessionId + "}";
            }
            else
            {
                return userId;
            }
        }

        private void CreateUserAccessTime(String userId)
        {
            Dictionary<String, SystemAccessRecord> table = UserTable;
            if (!table.ContainsKey(CreateUserAccessTimeKey(userId, Session.SessionID)))
            {
                table.Add(CreateUserAccessTimeKey(userId, Session.SessionID), new SystemAccessRecord(Session.SessionID, DateTime.UtcNow));
            }
        }

        protected void SetUserAccessTime(String userId, DateTime t)
        {
            SetUserAccessTime(userId, t, Session.SessionID);
        }

        protected void SetUserAccessTime(String userId, DateTime t, String sessionId)
        {
            Dictionary<String, SystemAccessRecord> table = UserTable;
            if (table.ContainsKey(CreateUserAccessTimeKey(userId, sessionId)))
            {
                table[CreateUserAccessTimeKey(userId, sessionId)].AccessTime = t;
            }
        }

        private void RemoveUserAccessTime(String userId)
        {
            Dictionary<String, SystemAccessRecord> table = UserTable;
            if (table.ContainsKey(CreateUserAccessTimeKey(userId, Session.SessionID)))
            {
                table.Remove(CreateUserAccessTimeKey(userId, Session.SessionID));
            }
        }

        protected Boolean IsTimeOut(String userId)
        {
            long lastTime = GetUserLastAccessTime(userId).Ticks;
            long minisecDiff = (DateTime.UtcNow.Ticks - lastTime) / 10000; //10000 ticks = 1 minisec
            return (minisecDiff > ApplicationSetting.GetInstance().TimeOut * 60 * 1000);
        }

        protected DateTime GetUserLastAccessTime()
        {
            return GetUserLastAccessTime((String)Session[WebConstants.KEY_CURRENT_USER]);
        }

        private DateTime GetUserLastAccessTime(String userId)
        {
            Dictionary<String, SystemAccessRecord> table = UserTable;
            if (table.ContainsKey(CreateUserAccessTimeKey(userId, Session.SessionID)))
            {
                //Whatever session is still collected.
                return table[CreateUserAccessTimeKey(userId, Session.SessionID)].AccessTime;
            }
            return DateTime.MinValue;
        }

        protected void SetUserInformation(String userId, String[] userRoles)
        {
            SetUserInformation(userId, userRoles, null);
        }

        protected void SetUserInformation(String userId, String[] userRoles, Type channelType)
        {
            UserRoleManager userManager = GetUserRoleManager();
            userManager.SetUserSecurityInformation(HttpContext.Current, userId, userRoles);

            Session[WebConstants.KEY_LAST_USER] = Session[WebConstants.KEY_CURRENT_USER];
            Session[WebConstants.KEY_CURRENT_USER] = userId;

            Session[WebConstants.KEY_LAST_CHANNEL] = Session[WebConstants.KEY_CURRENT_CHANNEL];
            if (channelType == null)
            {
                Session[WebConstants.KEY_CURRENT_CHANNEL] = "";
            }
            else
            {
                Session[WebConstants.KEY_CURRENT_CHANNEL] = channelType.Name;
            }

            CreateUserAccessTime(userId);
        }

        protected virtual void SignOut()
        {
            string userId = (String)Session[WebConstants.KEY_CURRENT_USER];
            if (!String.IsNullOrEmpty(userId))
            {
                Session[WebConstants.KEY_CURRENT_USER] = null;
                RemoveUserAccessTime(userId);
            }
            Session.Abandon();
            ClearSessionObjects();

            FormsAuthentication.SignOut();
        }

        public String GarbageCollection(String password)
        {
            long totalHeapMemory = 0;
            if (!String.IsNullOrEmpty(ApplicationSetting.GetInstance().AdministratorPassword))
            {
                if (String.Equals(password, ApplicationSetting.GetInstance().AdministratorPassword))
                {
                    GC.Collect();
                    totalHeapMemory = GC.GetTotalMemory(true);
                }
            }
            return "<html><body>Total Process Heap Memory = " + totalHeapMemory + "</body></html>";
        }

        [NonAction]
        private void ClearSessionObjects()
        {
            List<String> _list = PermanentSessionObjects();
            int _firstIndex = 0;
            while (_firstIndex < Session.Keys.Count)
            {
                String _key = Session.Keys[_firstIndex];
                if (!_list.Contains(_key))
                {
                    Object _object = Session[_key];
                    if (_object != null)
                    {
                        Utility.ClearObject(ref _object);

                        _object = null;

                        Session[_key] = null;
                        Session.RemoveAt(_firstIndex);
                    }
                    else
                    {
                        _firstIndex++;
                    }
                }
                else
                {
                    _firstIndex++;
                }
            }
        }

        [NonAction]
        protected virtual List<String> PermanentSessionObjects()
        {
            return new List<String>();
        }

        protected void UpdateCurrentUserLastActionTime()
        {
            string userId = (String)Session[WebConstants.KEY_CURRENT_USER];
            if (!String.IsNullOrEmpty(userId))
            {
                SetUserAccessTime(userId, DateTime.UtcNow);
            }
        }

        protected Boolean HaveConcurrentLogin(String userId)
        {
            if (!AcceptConcurrentLogin())
            {
                if (!String.IsNullOrEmpty(userId))
                {
                    return !IsTimeOut(userId);
                    //long lastTime = GetUserLastAccessTime(userId).Ticks;
                    //long minisecDiff = (DateTime.UtcNow.Ticks - lastTime) / 10000; //10000 ticks = 1 minisec
                    //return (minisecDiff < ApplicationSetting.GetInstance().TimeOut * 60 * 1000);
                }
            }
            return false;
        }

        private Boolean AcceptConcurrentLogin()
        {
            return ApplicationSetting.GetInstance().AcceptConcurrentLogin;
        }
    }
}

