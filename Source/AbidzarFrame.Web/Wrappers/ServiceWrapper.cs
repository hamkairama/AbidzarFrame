using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbidzarFrame.Web.Wrappers
{
    public abstract class ServiceWrapper
    {
        private string _userId = System.Web.HttpContext.Current.Session["UserId"] != null ? (string)System.Web.HttpContext.Current.Session["UserId"] : null;
        private string userId = "Unauthenticated User";
        private string sessionId = "Undefined_Session_Id";

        protected void WriteFunctionLog(string controllerName, string functionName, int level, LogData.LOG_TYPE logType)
        {
            if (HttpContext.Current.Session != null)
            {
                if (!string.IsNullOrWhiteSpace(_userId))
                    userId = _userId;
                
                sessionId = HttpContext.Current.Session.SessionID;
            }
            LogData _log = new LogData(LogData.STAGE.web, controllerName, functionName, "", userId, System.DateTime.Now, sessionId, "", "");
            Logger.GetInstance().WriteLogData(_log, 1, logType);
        }

        protected void WriteFunctionException(string controllerName, string functionName, int level, ref Exception ex, object contract, Type contractType)
        {
            string userData = "";
            if (contractType == typeof(string))
            {
                userData = (string)contract;
            }
            else
            {
                userData = DataContractHelper.ContractToString(ref contract, contractType);
            }
            if (HttpContext.Current.Session != null)
            {
                if (!string.IsNullOrWhiteSpace(_userId))
                    userId = _userId;

                sessionId = HttpContext.Current.Session.SessionID;
            }

            string msg = ex.Message;
            LogData _log = new LogData(LogData.STAGE.error, controllerName, functionName, "", userId, System.DateTime.Now, sessionId, msg, userData);
            Logger.GetInstance().WriteLogData(_log, level, LogData.LOG_TYPE.data);
        }

        protected void WriteFunctionCaptureData(string controllerName, string functionName, int level, ref object contract, Type contractType)
        {
            string userData = "";
            if (contractType == typeof(string))
            {
                userData = (string)contract;
            }
            else
            {
                userData = DataContractHelper.ContractToString(ref contract, contractType);
            }
            if (HttpContext.Current.Session != null)
            {
                if (!string.IsNullOrWhiteSpace(_userId))
                    userId = _userId;

                sessionId = HttpContext.Current.Session.SessionID;
            }

            LogData _log = new LogData(LogData.STAGE.info, controllerName, functionName, "", userId, System.DateTime.Now, sessionId, "[Data Input]", userData);
            Logger.GetInstance().WriteLogData(_log, level, LogData.LOG_TYPE.data);
        }
    }
}