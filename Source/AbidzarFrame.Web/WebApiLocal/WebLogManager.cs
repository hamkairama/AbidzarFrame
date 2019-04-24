using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Mvc.Infrastructures.ActionResult;
using AbidzarFrame.Web.App_Start;
using AbidzarFrame.Web.Helpers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AbidzarFrame.Web.WebApiLocal
{
    [AccessAuthorization]
    public class WebLogManager : BaseController
    {
        private string _user = CurrentUser.GetCurrentUserId() != null ? CurrentUser.GetCurrentUserId() : null;
        private string userId = "Unauthenticated User";

        public WebLogManager() : base()
        {
            ModelConfigurationSetting.ConfigurationLocation = AuthenticationConfiguration.GetInstance().ConfigFilePath;
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
                userData = DataContractHelper.ContractToString( ref contract, contractType);
            }

            if (!string.IsNullOrWhiteSpace(_user))
                userId = _user;

            string msg = ex.Message;
            LogData _log = new LogData(LogData.STAGE.error, serviceName, functionName, "", userId, DateTime.Now, "", msg, userData);
            Logger.GetInstance().WriteLogData(_log, level, LogData.LOG_TYPE.data);
        }

        protected virtual bool VerifyAuthenticationToken(string AuthenticationToken)
        {
            bool isValid = false;
            string webServiceAuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
            if(Request != null && webServiceAuthenticationToken.Equals(AuthenticationToken))
            {
                isValid = true;
            }
            return isValid;
        }

        protected virtual bool VerifyAuthenticationDB(string ip, string name)
        {
            foreach (string authDb in AuthenticationConfiguration.GetInstance().WebServiceAuthenticationDB.Split(';'))
            {
                if(ip + "-" + name == authDb)
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