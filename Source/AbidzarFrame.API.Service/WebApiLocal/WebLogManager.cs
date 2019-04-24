using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Security.Interface;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Security.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AbidzarFrame.Domain;

namespace AbidzarFrame.API.Service
{
    public class WebLogManager : ApiController
    {
        //private string _user = System.Web.HttpContext.Current.Session["UserId"] != null ?(string)System.Web.HttpContext.Current.Session["UserId"] : null;
        private string _user = "ApiService";
        private string userId = "Unauthenticated User";


        ISecurityManager manager;
        public WebLogManager() : base()
        {
            manager = new SecurityManager();
        }

        protected void WriteFunctionLog(string serviceName, string functionName, int level, LogData.LOG_TYPE logType)
        {
            if (!string.IsNullOrWhiteSpace(_user))
                userId = _user;

            LogData _log = new LogData(LogData.STAGE.web, serviceName, functionName, "", userId, DateTime.Now, "", "", "");
            Logger.GetInstance().WriteLogData(_log, 1, logType);
        }

        protected void WriteFunctionException(string serviceName, string functionName, int level, ref Exception ex, object contract, Type contractType)
        {
            string userData = "";
            if ((contractType == typeof(string)))
            {
                userData = (string)contract;
            }
            else
            {
                userData = DataContractHelper.ContractToString(ref contract, contractType);
            }

            if (!string.IsNullOrWhiteSpace(_user))
                userId = _user;

            string msg = ex.Message;
            LogData _log = new LogData(LogData.STAGE.error, serviceName, functionName, "", userId, DateTime.Now, "", msg, userData);
            Logger.GetInstance().WriteLogData(_log, level, LogData.LOG_TYPE.data);
        }

        protected virtual bool VerifyAuthenticationToken(string AuthenticationToken)
        {
            AuthenticationTokenRequest request = new AuthenticationTokenRequest();
            AuthenticationTokenResponse response = new AuthenticationTokenResponse();

            response = manager.GetAuthenticationToken(request);
            bool isValid = false;
            if (response.Count > 0)
            {
                isValid = VerifyByDb(response.AuthenticationTokenResultList, AuthenticationToken);
            }
            else
            {
                isValid = VerifyByConfig(AuthenticationToken);
            }

            return isValid;
        }

        private bool VerifyByConfig(string AuthenticationToken)
        {
            bool isValid = false;
            string webServiceAuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
            if (Request != null && webServiceAuthenticationToken.Equals(AuthenticationToken))
            {
                isValid = true;
            }
            return isValid;
        }

        private bool VerifyByDb(List<AuthenticationTokenResult> list, string AuthenticationToken)
        {
            bool isValid = false;
            foreach (var item in list)
            {
                if (item.Token == AuthenticationToken)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        protected virtual bool VerifyAuthenticationDB(string ip, string name)
        {
            foreach (string authDb in AuthenticationConfiguration.GetInstance().WebServiceAuthenticationDB.Split(';'))
            {
                if (ip + "-" + name == authDb)
                    return true;
            }
            return false;
        }

        protected string exceptionWcf(BusinessErrors errors)
        {
            var result = "";
            if (errors != null)
            {
                result = errors.ErrorList.FirstOrDefault().ErrorMessage;
            }
            return result;
        }
    }
}