using AbidzarFrame.Security.Interface;
using AbidzarFrame.Utils;
using AbidzarFrame.Security.Dao;
using AbidzarFrame.Security.Interface.Dto;
using System;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using System.Reflection;

namespace AbidzarFrame.Security.Manager
{
    public class SecurityManager : ISecurityManager
    {
        private const string _serviceName = "SecurityServiceManager";
        ResultStatus result = new ResultStatus();

        #region Instance
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }

        protected FunctionLog _functionLog
        {
            get { return new FunctionLog(); }
        }

        protected MenuDao _MenuDao
        {
            get { return new MenuDao(); }
        }

        protected RoleDao _RoleDao
        {
            get { return new RoleDao(); }
        }

        protected ActiveDirectoryDao _ActiveDirectoryDao
        {
            get { return new ActiveDirectoryDao(); }
        }

        protected UserDao _UserDao
        {
            get { return new UserDao(); }
        }

        protected AuthenticationTokenDao _AuthenticationTokenDao
        {
            get { return new AuthenticationTokenDao(); }
        }

        protected EmailDao _EmailDao
        {
            get { return new EmailDao(); }
        }

        protected UserApiDao _UserApiDao
        {
            get { return new UserApiDao(); }
        }

        protected RoleMenuDao _RoleMenuDao
        {
            get { return new RoleMenuDao(); }
        }

        protected HistoricalUserLoginDao _HistoricalUserLoginDao
        {
            get { return new HistoricalUserLoginDao(); }
        }

        #endregion

        #region Login Using ActiveDirectory

        public ActiveDirectoryResponse CheckUser(ActiveDirectoryRequest request, ref UserResult userResult)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ActiveDirectoryResponse()
            {
                Errors = new BusinessErrors(),
                ActiveDirectoryResult = new ActiveDirectoryResult(),
            };
            string retCode = "";

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                ActiveDirectoryResponse data = new ActiveDirectoryResponse();
                var refData = data.ActiveDirectoryResult;
                bussinessError.Add(_ActiveDirectoryDao.CheckUser(request, ref refData, ref userResult, ref retCode));
                response.ActiveDirectoryResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        #endregion

        #region User

        public UserResponse GetUserFindBy(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse()
            {
                Errors = new BusinessErrors(),
                UserResult = new UserResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                UserResponse data = new UserResponse();
                var refData = data.UserResult;
                bussinessError.Add(_UserDao.GetUserFindBy(request, ref refData));
                response.UserResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public UserResponse GetUserList(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse()
            {
                Errors = new BusinessErrors(),
                UserResultList = new List<UserResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                MenuResponse data = new MenuResponse();
                List<UserResult> refData = new List<UserResult>();
                bussinessError.Add(_UserDao.GetUserList(request, ref refData));
                response.UserResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public UserResponse UserRegistrasi(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_UserDao.UserRegistrasi(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public UserResponse UserUpdateSandi(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_UserDao.UserUpdateSandi(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public UserResponse UserVerifikasi(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_UserDao.UserVerifikasi(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }
        
        public UserResponse InsertUser(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_UserDao.InsertUser(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public UserResponse UpdateUser(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_UserDao.UpdateUser(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public UserResponse DeleteUser(UserRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_UserDao.DeleteUser(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        #endregion

        #region Roles

        public RoleResponse GetRoleFindBy(RoleRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleResponse()
            {
                Errors = new BusinessErrors(),
                RoleResult = new RoleResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RoleResponse data = new RoleResponse();
                var refData = data.RoleResult;
                bussinessError.Add(_RoleDao.GetRoleFindBy(request, ref refData));
                response.RoleResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public RoleResponse GetRoleList(RoleRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleResponse()
            {
                Errors = new BusinessErrors(),
                RoleResultList = new List<RoleResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RoleResponse data = new RoleResponse();
                List<RoleResult> refData = new List<RoleResult>();
                bussinessError.Add(_RoleDao.GetRoleList(request, ref refData));
                response.RoleResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public RoleResponse InsertRole(RoleRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RoleDao.InsertRole(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public RoleResponse UpdateRole(RoleRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RoleDao.UpdateRole(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public RoleResponse DeleteRole(RoleRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RoleDao.DeleteRole(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        #endregion

        #region Menus

        public MenuResponse GetMenuAccessRight(MenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new MenuResponse()
            {
                Errors = new BusinessErrors(),
                MenuResultList = new List<MenuResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                MenuResponse data = new MenuResponse();
                List<MenuResult> refData = new List<MenuResult>();
                bussinessError.Add(_MenuDao.GetMenuAccessRight(request, ref refData));
                response.MenuResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public MenuResponse GetMenuFindBy(MenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new MenuResponse()
            {
                Errors = new BusinessErrors(),
                MenuResult = new MenuResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                MenuResponse data = new MenuResponse();
                var refData = data.MenuResult;
                bussinessError.Add(_MenuDao.GetMenuFindBy(request, ref refData));
                response.MenuResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public MenuResponse GetMenuList(MenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new MenuResponse()
            {
                Errors = new BusinessErrors(),
                MenuResultList = new List<MenuResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                MenuResponse data = new MenuResponse();
                List<MenuResult> refData = new List<MenuResult>();
                bussinessError.Add(_MenuDao.GetMenuList(request, ref refData));
                response.MenuResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public MenuResponse InsertMenu(MenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new MenuResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_MenuDao.InsertMenu(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public MenuResponse UpdateMenu(MenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new MenuResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_MenuDao.UpdateMenu(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public MenuResponse DeleteMenu(MenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new MenuResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_MenuDao.DeleteMenu(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }
        #endregion

        #region Authentication Token

        public AuthenticationTokenResponse GetAuthenticationToken(AuthenticationTokenRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AuthenticationTokenResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                MenuResponse data = new MenuResponse();
                List<AuthenticationTokenResult> refData = new List<AuthenticationTokenResult>();
                bussinessError.Add(_AuthenticationTokenDao.GetAuthenticationToken(request, ref refData));
                response.AuthenticationTokenResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        #endregion

        #region Send Email

        public EmailResponse SendEmail(EmailRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            ResultStatus result = new ResultStatus();
            var response = new EmailResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_EmailDao.SendEmail(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;

            return response;
        }

        #endregion

        #region User Api
        public UserApiResponse GetUserApiFindBy(UserApiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new UserApiResponse()
            {
                Errors = new BusinessErrors(),
                UserApiResult = new UserApiResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                UserApiResponse data = new UserApiResponse();
                var refData = data.UserApiResult;
                bussinessError.Add(_UserApiDao.GetUserApiFindBy(request, ref refData));
                response.UserApiResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }
        #endregion

        #region Email template
        public EmailResponse GetEmailTemplateFindBy(EmailRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new EmailResponse()
            {
                Errors = new BusinessErrors(),
                EmailResult = new EmailResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                EmailResponse data = new EmailResponse();
                var refData = data.EmailResult;
                bussinessError.Add(_EmailDao.GetEmailTemplateFindBy(request, ref refData));
                response.EmailResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }
        #endregion

        #region RoleMenus

        public RoleMenuResponse GetRoleMenuListByRoleId(RoleMenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleMenuResponse()
            {
                Errors = new BusinessErrors(),
                RoleMenuResultList = new List<RoleMenuResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RoleMenuResponse data = new RoleMenuResponse();
                List<RoleMenuResult> refData = new List<RoleMenuResult>();
                bussinessError.Add(_RoleMenuDao.GetRoleMenuListByRoleId(request, ref refData));
                response.RoleMenuResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public RoleMenuResponse GetRoleMenuFindBy(RoleMenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleMenuResponse()
            {
                Errors = new BusinessErrors(),
                RoleMenuResult = new RoleMenuResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RoleMenuResponse data = new RoleMenuResponse();
                var refData = data.RoleMenuResult;
                bussinessError.Add(_RoleMenuDao.GetRoleMenuFindBy(request, ref refData));
                response.RoleMenuResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public RoleMenuResponse GetRoleMenuList(RoleMenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleMenuResponse()
            {
                Errors = new BusinessErrors(),
                RoleMenuResultList = new List<RoleMenuResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RoleMenuResponse data = new RoleMenuResponse();
                List<RoleMenuResult> refData = new List<RoleMenuResult>();
                bussinessError.Add(_RoleMenuDao.GetRoleMenuList(request, ref refData));
                response.RoleMenuResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public RoleMenuResponse InsertRoleMenu(RoleMenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleMenuResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RoleMenuDao.InsertRoleMenu(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public RoleMenuResponse UpdateRoleMenu(RoleMenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleMenuResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RoleMenuDao.UpdateRoleMenu(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public RoleMenuResponse DeleteRoleMenu(RoleMenuRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RoleMenuResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RoleMenuDao.DeleteRoleMenu(request, ref result));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }
        #endregion

        #region HistoricalUserLogin
        public HistoricalUserLoginResponse GetHistoricalUserLoginFindBy(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse()
            {
                Errors = new BusinessErrors(),
                HistoricalUserLoginResult = new HistoricalUserLoginResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                HistoricalUserLoginResponse data = new HistoricalUserLoginResponse();
                var refData = data.HistoricalUserLoginResult;
                bussinessError.Add(_HistoricalUserLoginDao.GetHistoricalUserLoginFindBy(request, ref refData));
                response.HistoricalUserLoginResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public HistoricalUserLoginResponse GetHistoricalUserLoginList(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse()
            {
                Errors = new BusinessErrors(),
                HistoricalUserLoginResultList = new List<HistoricalUserLoginResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<HistoricalUserLoginResult> refData = new List<HistoricalUserLoginResult>();
                bussinessError.Add(_HistoricalUserLoginDao.GetHistoricalUserLoginList(ref refData));
                response.HistoricalUserLoginResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public HistoricalUserLoginResponse GetHistoricalUserLoginListByDate(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse()
            {
                Errors = new BusinessErrors(),
                HistoricalUserLoginResultList = new List<HistoricalUserLoginResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<HistoricalUserLoginResult> refData = new List<HistoricalUserLoginResult>();
                bussinessError.Add(_HistoricalUserLoginDao.GetHistoricalUserLoginListByDate(request, ref refData));
                response.HistoricalUserLoginResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public HistoricalUserLoginResponse GetHistoricalUserLoginListByMonth(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse()
            {
                Errors = new BusinessErrors(),
                HistoricalUserLoginResultList = new List<HistoricalUserLoginResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<HistoricalUserLoginResult> refData = new List<HistoricalUserLoginResult>();
                bussinessError.Add(_HistoricalUserLoginDao.GetHistoricalUserLoginListByMonth(request, ref refData));
                response.HistoricalUserLoginResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public HistoricalUserLoginResponse GetHistoricalUserLoginListByYear(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse()
            {
                Errors = new BusinessErrors(),
                HistoricalUserLoginResultList = new List<HistoricalUserLoginResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<HistoricalUserLoginResult> refData = new List<HistoricalUserLoginResult>();
                bussinessError.Add(_HistoricalUserLoginDao.GetHistoricalUserLoginListByYear(request, ref refData));
                response.HistoricalUserLoginResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public HistoricalUserLoginResponse InsertHistoricalUserLogin(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_HistoricalUserLoginDao.InsertHistoricalUserLogin(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public HistoricalUserLoginResponse UpdateHistoricalUserLogin(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_HistoricalUserLoginDao.UpdateHistoricalUserLogin(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public HistoricalUserLoginResponse DeleteHistoricalUserLogin(HistoricalUserLoginRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new HistoricalUserLoginResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_HistoricalUserLoginDao.DeleteHistoricalUserLogin(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        #endregion
    }
}
