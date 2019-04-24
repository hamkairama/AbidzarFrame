using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Core.Mvc.Models;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Web.Security;
using System.Xml.Linq;
using System.Collections;
using System.Security.Principal;
using AbidzarFrame.Core.Mvc.Views;
using System.Security;
using System.Text;
using System.Runtime.InteropServices;

namespace AbidzarFrame.Core.Mvc.Controllers
{
    public class EnhancedController : Controller
    {

        Logger logger = null;

        private String currentAction = null;
        private String currentController = null;
        private List<IRequestRoutingRule> routingRules = new List<IRequestRoutingRule>()
                { new DirectLoginScreenRule(), new UnauthorizeAccessRule(), 
                  new ChangePasswordRule(), new DirectToLastRequestRule() };

        public EnhancedController()
            : base()
        {
            InitController();
        }

        protected List<IRequestRoutingRule> RoutingRules
        {
            get
            {
                return routingRules;
            }
            set
            {
                routingRules = value;
            }
        }

        protected ActionRequestToken LastSuccessfulAction
        {
            get
            {
                return RetrieveLastSuccessfulActionToken();
            }
        }

        protected ViewToken LastSuccessfulView
        {
            get
            {
                return RetrieveLastSuccessfulViewLocation();
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

        public virtual void InitController() { }

        public string CurrentAction
        {
            get
            {
                return this.currentAction;
            }
        }

        public string CurrentController
        {
            get
            {
                return this.currentController;
            }
        }

        protected virtual void InitActionRequest(String actionName, String controllerName)
        {
            // to be implemented by realized class
        }

        public virtual bool IsPasswordExpired(System.Security.Principal.IPrincipal user)
        {
            return false;
        }

        public virtual bool IsSameToLastUser()
        {
            String lastUser = (String)Session[WebConstants.KEY_LAST_USER];
            String currUser = (String)Session[WebConstants.KEY_CURRENT_USER];

            if (string.IsNullOrEmpty(lastUser))
            {
                return true;
            } else 
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
                AppServiceLocator service = (AppServiceLocator)HttpContext.Application[AppServiceLocator.SESSION_APPLICATION_SERVICE];
                if (service == null)
                {
                    service = CreateSharedServiceLocator();
                    HttpContext.Application[AppServiceLocator.SESSION_APPLICATION_SERVICE] = service;
                } 
                return service;
            }
            set
            {
                HttpContext.Application[AppServiceLocator.SESSION_APPLICATION_SERVICE] = value;
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

        protected override void OnException(ExceptionContext filterContext)
        {
            GetLogger().WriteLogData(CreateLogData(this, LogData.STAGE.error, filterContext), 1, LogData.LOG_TYPE.begin);
            base.OnException(filterContext);
            GetLogger().WriteLogData(CreateLogData(this, LogData.STAGE.error, filterContext), 1, LogData.LOG_TYPE.end);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            currentAction = filterContext.ActionDescriptor.ActionName;
            currentController = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            SaveCurrentRequestToken(new ActionRequestToken(currentController, currentAction));

            GetLogger().WriteLogData(CreateLogData(this, LogData.STAGE.action, filterContext), 1, LogData.LOG_TYPE.begin);
            GetLogger().WriteLogData(CreateLogData(this, LogData.STAGE.web, filterContext), 1, LogData.LOG_TYPE.begin);
            InitActionRequest(currentAction, currentController);
            base.OnActionExecuting(filterContext);
        }

        protected virtual LogData CreateLogData(EnhancedController controller, LogData.STAGE stage, ControllerContext context)
        {
            return LogInformationReader.Read(stage, context);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Session[WebConstants.KEY_LAST_REQUEST_REDIRECTED] = null;
            base.OnResultExecuting(filterContext);
        }

        protected virtual void DisableCache(ResultExecutedContext filterContext)
        {
            if (ApplicationSetting.GetInstance().CacheOption == Cache.CacheAll)
            {
                return;
            }
            else if (ApplicationSetting.GetInstance().CacheOption == Cache.CacheNothing)
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();
            }
            else if (ApplicationSetting.GetInstance().CacheOption == Cache.CacheFile)
            {
                if (!(filterContext.Result is FileResult))
                {
                    filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                    filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                    filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                    filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    filterContext.HttpContext.Response.Cache.SetNoStore();
                }
            }
        }

        private void SaveLastSuccessfulActionToken(ActionRequestToken token)
        {
            HttpContext.Session[WebConstants.KEY_LAST_SUCCESSFUL_ACTION_TOKEN] = token;
        }

        private ActionRequestToken RetrieveLastSuccessfulActionToken()
        {
            return (ActionRequestToken)HttpContext.Session[WebConstants.KEY_LAST_SUCCESSFUL_ACTION_TOKEN];
        }

        private void SaveLastSuccessfulViewLocation(ViewToken token)
        {
            Session[WebConstants.KEY_LAST_SUCCESSFUL_VIEW] = token;
        }

        private ViewToken RetrieveLastSuccessfulViewLocation()
        {
            return (ViewToken)Session[WebConstants.KEY_LAST_SUCCESSFUL_VIEW];
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            bool isAjaxOutput = (filterContext.Result.GetType().Equals(typeof(JsonResult)) ||
                                 filterContext.Result.GetType().Equals(typeof(FileContentResult)));
            bool isHttpAjax = HttpContext.Request.IsAjaxRequest();
            bool isPost = "POST".Equals(HttpContext.Request.HttpMethod);
            bool shouldCheck = !(isPost && (isHttpAjax && isAjaxOutput));
            ViewResult viewBase = null;
            ViewToken viewToken = null;
            if (filterContext.Result != null)
            {
                if (filterContext.Result.GetType().Equals(typeof(ViewResult)))
                {
                    viewBase = (ViewResult)filterContext.Result;
                    BuildManagerCompiledView webFormView = (BuildManagerCompiledView)viewBase.View;
                    viewToken = new ViewToken(viewBase.ViewName, webFormView.ViewPath);
                }
            }

            ActionRequestToken token = new ActionRequestToken(filterContext);
            if (shouldCheck)
            {
                //ActionRequestToken token = new ActionRequestToken(this, filterContext);
                bool routed = false;
                foreach (IRequestRoutingRule rule in routingRules)
                {
                    if (rule.ApplicableMethods.Contains(HttpContext.Request.HttpMethod))
                    {
                        rule.Init(this, filterContext, token);
                        if (rule.Trigger())
                        {
                            string targetLocation = HttpContext.Response.RedirectLocation;
                            rule.Execute();
                            string newLocation = HttpContext.Response.RedirectLocation;
                            if (newLocation != null && !newLocation.Equals(targetLocation))
                            {
                                if (RoutingMethods.METHOD_GET.Equals(HttpContext.Request.HttpMethod))
                                {
                                    routed = true;
                                    Session[WebConstants.KEY_LAST_REQUEST_REDIRECTED] = newLocation;
                                }
                            }
                            break;
                        }
                    }
                }
                if (!routed)
                {
                    DisableCache(filterContext);
                    base.OnResultExecuted(filterContext);
                    SaveLastSuccessfulActionToken(token);
                    if (viewToken != null)
                    {
                        SaveLastSuccessfulViewLocation(viewToken);
                    }
                }
            }
            else
            {
                if (!HttpContext.User.Identity.IsAuthenticated)
                {
                    if (!filterContext.Result.GetType().Equals(typeof(JsonResult)))
                    {
                        Response.Clear();
                    }
                }
                DisableCache(filterContext);
                base.OnResultExecuted(filterContext);
                SaveLastSuccessfulActionToken(token);
                if (viewToken != null)
                {
                    SaveLastSuccessfulViewLocation(viewToken);
                }
            }
            SaveLastActionTime(token);
            GetLogger().WriteLogData(CreateLogData(this, LogData.STAGE.web, filterContext), 1, LogData.LOG_TYPE.end);
            GetLogger().WriteLogData(CreateLogData(this, LogData.STAGE.action, filterContext), 1, LogData.LOG_TYPE.end);
        }

        protected virtual void SaveLastActionTime(ActionRequestToken token)  
        {
            UpdateCurrentUserLastActionTime();
        }

        protected Errors UpdateWorkingViewModel(IWorkingViewModel model)
        {
            return UpdateWorkingViewModel(model, null);
        }

        protected Errors UpdateWorkingViewModel(IWorkingViewModel model, Errors errors)
        {
            if (errors == null)
            {
                errors = new Errors();
            }

            try
            {
                model.Read(Request);
            }
            catch (Exception e)
            {
                errors.Add(new ErrorVo("", "", e.Message));
            }

            if (!errors.HasError)
            {
                Errors errs = model.CheckIntegrity(Request);
                if (errs.HasError)
                {
                    errors.Add(errs);
                }
            }
            return errors;
        }

        protected virtual ErrorResult ErrorResult(int statusCode, Errors errors)
        {
            return new ErrorResult(statusCode, errors);
        }

        protected virtual void DirectErrorsToView(List<List<string>> errors)
        {
            errors = filterDuplicateErrors(errors);
            foreach (List<string> err in errors)
            {
                String m = err[2];
                if (!string.IsNullOrEmpty(err[0]))
                {
                    m = "[" + err[0] + "] " + m;
                }
                ModelState.AddModelError(err[1], m);
            }
        }

        protected virtual void DirectErrorsToView(Dictionary<String, List<List<string>>> errors)
        {
            if (errors.Count > 0)
            {
                String lang = (String)Session[EnhancedViewEngine.SYSTEM_LANGUAGE];
                if (!errors.ContainsKey(lang))
                {
                    lang = ErrorVo.DEFAULT_LANGUAGE;
                }
                DirectErrorsToView(errors[lang]);
            }
        }

        protected virtual List<List<string>> filterDuplicateErrors(List<List<string>> errors)
        {
            List<List<string>> filtedErrors = new List<List<string>>();
            List<String> tempMessages = new List<string>();
            foreach (List<string> e in errors)
            {
                String message = e.ElementAt(2);
                HtmlString a = new HtmlString(message);
                Boolean alreadyAddedInModelState = false;
                if (message != null) { message = a.ToString().Trim(); }//change to html before trim. i.e. advoid "/n" in the string
                foreach (ModelState item in ModelState.Values)
                {
                    foreach (ModelError errorItem in item.Errors)
                    {
                        if (errorItem.ErrorMessage.Contains(message))
                        {
                            alreadyAddedInModelState = true; //found message is already added into ModelState
                            break;
                        }
                    }
                }
                if (!tempMessages.Contains(message) && !alreadyAddedInModelState)
                {
                    tempMessages.Add(message);
                    filtedErrors.Add(e);
                }
            }
            return filtedErrors;
        }

        private UserRoleManager GetUserRoleManager()
        {
            UserRoleManager _manager = (UserRoleManager)HttpContext.Application[WebConstants.KEY_USER_ROLES_MANAGER];
            if (_manager == null)
            {
                _manager = new UserRoleManager();
                HttpContext.Application[WebConstants.KEY_USER_ROLES_MANAGER] = _manager;
            }
            return _manager;
        }

        private Dictionary<String, SystemAccessRecord> UserTable
        {
            get
            {
                Dictionary<String, SystemAccessRecord> table = (Dictionary<String, SystemAccessRecord>)
                        HttpContext.Application[WebConstants.KEY_USER_TABLE];
                if (table == null)
                {
                    table = new Dictionary<String, SystemAccessRecord>();
                    HttpContext.Application[WebConstants.KEY_USER_TABLE] = table;
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

        protected void SetUserInformation(HttpContextBase context, String userId, String[] userRoles)
        {
            SetUserInformation(context, userId, userRoles, null);
        }

        protected void SetUserInformation(HttpContextBase context, String userId, String[] userRoles, Type channelType)
        {
            UserRoleManager userManager = GetUserRoleManager();
            userManager.SetUserSecurityInformation(context, userId, userRoles);

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

        public void SaveCurrentRequestToken(ActionRequestToken action)
        {
            String _unmemorizedActions = ApplicationSetting.GetInstance().UnMemorizedActions;
            if (!_unmemorizedActions.Contains(action.DestinationUrl))
            {
                Session[WebConstants.KEY_CURRENT_REQUEST] = action;
            }
        }

        public void SaveLastRequestToken(ActionRequestToken action)
        {
            String _unmemorizedActions = ApplicationSetting.GetInstance().UnMemorizedActions;
            if (!_unmemorizedActions.Contains(action.DestinationUrl))
            {
                Session[WebConstants.KEY_REQUEST_RIDRECT_INDICATOR] = "Y";
                Session[WebConstants.KEY_LAST_REQUEST] = action;
            }
        }

        public void ClearLastRequestToken()
        {
            Session[WebConstants.KEY_REQUEST_RIDRECT_INDICATOR] = null;
            Session[WebConstants.KEY_LAST_REQUEST] = null;
        }

        public ActionRequestToken LastRequestToken {
            get
            {
                return (ActionRequestToken)Session[WebConstants.KEY_LAST_REQUEST];
            }
        }

        public String RedirectedLocation
        {
            get
            {
                return (String)Session[WebConstants.KEY_LAST_REQUEST_REDIRECTED];
            }
        }

        protected virtual void SignOut()
        {
            string userId = (String)Session[WebConstants.KEY_CURRENT_USER];
            if (!String.IsNullOrEmpty(userId))
            {
                Session[WebConstants.KEY_CURRENT_USER] = null;
                RemoveUserAccessTime(userId);
            }
            ClearLastRequestToken();
            
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

        protected ActionResult RedirectToLastActionRequest()
        {
            ActionRequestToken a = (ActionRequestToken)Session[WebConstants.KEY_LAST_REQUEST];
            if (a == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction(a.Action, a.Controller);
            }
        }

        [ActionName("DumpSession")]
        public String DumpSession(String password) {
            if (!String.IsNullOrEmpty(ApplicationSetting.GetInstance().AdministratorPassword))
            {
                if (String.Equals(password, ApplicationSetting.GetInstance().AdministratorPassword))
                {
                    StringBuilder _result = new StringBuilder();
                    try
                    {
                        _result.Append("<html>");
                        _result.Append("<body>");
                        _result.Append("<table>");
                        _result.Append("<tr>");
                        _result.Append("<th>Object Name</th>");
                        _result.Append("<th>Data Type</th>");
                        _result.Append("<th>Value</th>");
                        _result.Append("</tr>");
                        foreach (String _key in Session.Keys)
                        {
                            Object _data = Session[_key];

                            if (_data != null)
                            {
                                _result.Append("<tr>");
                                _result.Append("<td>" + _key.ToString() + "</td>");
                                _result.Append("<td>" + _data.GetType().ToString() + "</td>");
                                _result.Append("<td>" + _data + "</td>");
                                _result.Append("</tr>");
                            }
                        }
                        _result.Append("</table>");
                        _result.Append("</body>");
                        _result.Append("</html>");

                        return _result.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        _result = null;
                    }
                }
            }
            return "";
        }

        [ActionName("CurrentSessions")]
        public String CurrentSessions(string password)
        {
            int totalSessions = 0;
            int activeSessions = 0;

            if (!String.IsNullOrEmpty(ApplicationSetting.GetInstance().AdministratorPassword))
            {
                if (String.Equals(password, ApplicationSetting.GetInstance().AdministratorPassword))
                {
                    StringBuilder _result = new StringBuilder();
                    try
                    {
                        _result.Append("<html>");
                        _result.Append("<body>");
                        _result.Append("<table>");
                        _result.Append("<tr>");
                        _result.Append("<th>Session Id</th>");
                        _result.Append("<th>Last Access Time</th>");
                        _result.Append("</tr>");

                        Dictionary<String, SystemAccessRecord> _records = UserTable;
                        foreach (String _key in _records.Keys)
                        {
                            SystemAccessRecord _record = _records[_key];
                            TimeSpan _span = new DateTime().Subtract(_record.AccessTime);

                            bool _active = (_span.Minutes <= 15);

                            totalSessions++;
                            if (_active)
                            {
                                activeSessions++;
                            }
                        
                            _result.Append("<tr>");
                            _result.Append("<td>" + _record.SessionId + "</td>");
                            _result.Append("<td>" + _record.AccessTime + "</td>");
                            _result.Append("</tr>");
                        }
                        _result.Append("</table>");
                        _result.Append("<br/>");
                        _result.Append("Total Sessions since last restarted: " + totalSessions);
                        _result.Append("<br/>");
                        _result.Append("Total Active Sessions: " + activeSessions);
                        _result.Append("</body>");
                        _result.Append("</html>");
                        
                        return _result.ToString();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        _result = null;
                    }
                }
            }
            return "";
        }

    }
}