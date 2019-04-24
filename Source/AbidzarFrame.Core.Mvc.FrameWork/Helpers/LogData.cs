using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class LogData
    {

        public enum STAGE
        {
            action,
            web,
            wcf,
            api,
            controller,
            error,
            info,
            unknown
        }

        public enum LOG_TYPE {
            begin,
            end,
            data
        }

        protected STAGE logStage = STAGE.unknown;
        protected String controllerName = null;
        protected String actionName = null;
        protected String url = null;
        protected String userId = null;
        protected DateTime time = System.DateTime.MinValue;
        protected String sessionId = null;
        protected String error = null;
        protected String userData = null;

        public LogData()
            : this(STAGE.unknown, null, null, null, null, System.DateTime.MinValue, null, null, null)
        { }

        public LogData(STAGE stage, String controllerName, String actionName, String url, 
            String userId, DateTime time, String sessionId, String error, String userData)
        {
            this.logStage = stage;
            this.controllerName = controllerName;
            this.actionName = actionName;
            this.url = url;
            this.userId = userId;
            this.time = time;
            this.sessionId = sessionId;
            this.error = error;
            this.userData = userData;
        }

        public STAGE LogStage
        {
            get
            {
                return this.logStage;
            }
            set
            {
                this.logStage = value;
            }
        }

        public String ActionName
        {
            get
            {
                return this.actionName;
            }
            set
            {
                this.actionName = value;
            }
        }

        public String Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }

        public String UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public String SessionId
        {
            get
            {
                return this.sessionId;
            }
            set
            {
                this.sessionId = value;
            }
        }

        public String Error
        {
            get
            {
                return this.error;
            }
            set
            {
                this.error = value;
            }
        }

        public String ControllerName
        {
            get
            {
                return this.controllerName;
            }
            set
            {
                this.controllerName = value;
            }
        }

        public String UserData
        {
            get
            {
                return this.userData;
            }
            set
            {
                this.userData = value;
            }
        }

        public static String FormatLogData(LogData log, int errorLevel, LOG_TYPE prefix, int indentLevel)
        {
            String levelDesc = GetLevelDescription(errorLevel);

            StringBuilder builder = new StringBuilder();
            builder.Append(levelDesc);
            builder.Append(" ");
            builder.Append(String.Format("[{0}]", log.Time.ToString("dd-MM-yyyy HH:mm:ss:ff")));
            builder.Append(" [ID=");
            builder.Append(log.SessionId);
            builder.Append("]");
            //builder.Append(' ', indentLevel);       // 1 and above
            builder.Append(" ");
            builder.Append(prefix.ToString().PadRight(6, '.'));
            builder.Append(log.LogStage);
            builder.Append("=");
            builder.Append(log.ControllerName + "(" + log.ActionName +")");
            builder.Append("[user_id='");
            builder.Append(log.UserId);
            builder.Append("']");
            if (!String.IsNullOrEmpty(log.Error)) builder.Append(" [Exception: '" + log.Error + "']");
            if (!String.IsNullOrEmpty(log.UserData)) builder.Append(" [UserData: '" + log.UserData + "']");

            return builder.ToString();
        }
        
        protected static String GetLevelDescription(int level)
        {
            switch (level) {
                case 1:
                    return "STAT.";
                default:
                    return "STAT.";
            }
                    
        }
    }
}