using System;
using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Utils;
using AbidzarFrame.Security.Interface.Dto;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AbidzarFrame.Security.Dao
{
    public class ActiveDirectoryDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "SecurityService";
        internal ActiveDirectoryDao()
        {
            conFactory = new SqlDb();
            _errHand = new ErrorHandler();
            _logger = new FunctionLog();
        }

        private IDbConnFactory _dbSql { get { return conFactory; } }

        public BusinessErrors CheckUser(ActiveDirectoryRequest request, ref ActiveDirectoryResult loginResult, ref UserResult userResult, ref string returnCode)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            try
            {
                loginResult = GetUserAD(request);
                if (!string.IsNullOrWhiteSpace(loginResult.UserId))
                {
                    //var userResultList = GetUserRegistration(request.UserId);
                    UserRequest modelUser = new UserRequest();
                    UserDao requestUser = new UserDao();
                    var userFound = requestUser.GetUserFindBy(modelUser, ref userResult);
                    if (userFound != null)
                    {
                        //var test = EnumList.Status.Active;
                        if (!string.IsNullOrWhiteSpace(userResult.Nik) && userResult.Status == true)
                        {
                            returnCode = ErrorHandler._MSG_SUCCESS;
                        }
                        else
                        {
                            messageResult = _errHand.InterpretErrors(ErrorHandler._ERRKEY_ABIDZARFRAME, Utils.ErrorMessages.ABIDZARFRAME_USER_IN_ACTIVE_CD);
                        }
                    }
                    else
                    {
                        messageResult = _errHand.InterpretErrors(ErrorHandler._ERRKEY_ABIDZARFRAME, Utils.ErrorMessages.ABIDZARFRAME_DATA_NOT_FOUND_CD);
                    }
                }
                else
                {
                    messageResult = _errHand.InterpretErrors(ErrorHandler._ERRKEY_ABIDZARFRAME, Utils.ErrorMessages.ABIDZARFRAME_DATA_NOT_FOUND_CD);
                }
            }
            catch (Exception ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }

            return messageResult;
        }

        private ActiveDirectoryResult GetUserAD(ActiveDirectoryRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            ActiveDirectoryResult result = null;
            try
            {
                result = ActiveDirectory.IsAuthenticated(request.UserId);
            }
            catch (Exception ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
            }
            return result;
        }

        public BusinessErrors GetActiveDirBy(ActiveDirectoryRequest request, ref List<ActiveDirectoryResult> activeDirectoryResult, ref string returnCode)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            try
            {
                List<ActiveDirectoryResult> userActive = ActiveDirectory.GetActiveDirBy(request.FilterBy, request.FilterValue);
                if (userActive != null)
                {
                    activeDirectoryResult = userActive;
                }
                else
                {
                    messageResult = _errHand.InterpretErrors(ErrorHandler._ERRKEY_ABIDZARFRAME, Utils.ErrorMessages.ABIDZARFRAME_AD_NOT_FOUND_CD);
                }
            }
            catch (Exception ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }

            return messageResult;
        }        
    }
}

