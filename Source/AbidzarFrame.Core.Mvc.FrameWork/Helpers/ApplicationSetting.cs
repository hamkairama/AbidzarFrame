using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using AbidzarFrame.Core.Mvc.Helpers;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class ApplicationSetting : ConfigurationSection
    {
        private static ApplicationSetting me = null;

        public ApplicationSetting()
        {
        }

        public static ApplicationSetting GetInstance() {    
            if (me == null)
            {
                me = (ApplicationSetting)ConfigurationManager.GetSection("ApplicationSetting");
            }
            return me;
        }

        [ConfigurationProperty("ApplicationName", DefaultValue = "")]
        public String ApplicationName
        {
            get { return "" + this["ApplicationName"]; }
            set { this["ApplicationName"] = value; }
        }

        [ConfigurationProperty("ApplicationVersion", DefaultValue = "1.0")]
        public String ApplicationVersion
        {
            get { return "" + this["ApplicationVersion"]; }
            set { this["ApplicationVersion"] = value; }
        }

        [ConfigurationProperty("LogFile", DefaultValue = "")]
        public String LogFile
        {
            get { return "" + this["LogFile"]; }
            set { this["LogFile"] = value; }
        }

        [ConfigurationProperty("LogLevel", DefaultValue = 5)]
        public int LogLevel
        {
            get { return Convert.ToInt16(this["LogLevel"]); }
            set { this["LogLevel"] = value; }
        }

        [ConfigurationProperty("AuthorizationFilePath", DefaultValue = "~/Resource/Users.xml")]
        public String AuthorizationFilePath
        {
            get { return "" + this["AuthorizationFilePath"]; }
            set { this["AuthorizationFilePath"] = value; }
        }

        [ConfigurationProperty("LoginUrl", DefaultValue = "")]
        public String LoginUrl
        {
            get { return "" + this["LoginUrl"]; }
            set { this["LoginUrl"] = value; }
        }

        [ConfigurationProperty("ChangePasswordUrl", DefaultValue = "")]
        public String ChangePasswordUrl
        {
            get { return "" + this["ChangePasswordUrl"]; }
            set { this["ChangePasswordUrl"] = value; }
        }

        [ConfigurationProperty("TimeOut", DefaultValue = 15)]
        public int TimeOut
        {
            get { return Convert.ToInt16(this["TimeOut"]); }
            set { this["TimeOut"] = value; }
        }

        [ConfigurationProperty("UnauthorizedAccessErrorPageUrl", DefaultValue = "")]
        public String UnauthorizedAccessErrorPageUrl
        {
            get { return "" + this["UnauthorizedAccessErrorPageUrl"]; }
            set { this["UnauthorizedAccessErrorPageUrl"] = value; }
        }

        [ConfigurationProperty("WcfHeaderNamespace", DefaultValue = "")]
        public String WcfHeaderNamespace
        {
            get { return "" + this["WcfHeaderNamespace"]; }
            set { this["WcfHeaderNamespace"] = value; }
        }

        [ConfigurationProperty("UnprotectedActions", DefaultValue = "")]
        public String UnprotectedActions
        {
            get { return "" + this["UnprotectedActions"]; }
            set { this["UnprotectedActions"] = value; }
        }

        [ConfigurationProperty("AcceptConcurrentLogin", DefaultValue = false)]
        public bool AcceptConcurrentLogin
        {
            get { return Convert.ToBoolean(this["AcceptConcurrentLogin"]); }
            set { this["AcceptConcurrentLogin"] = value; }
        }

        [ConfigurationProperty("RecordRegressionResult", DefaultValue = false)]
        public bool RecordRegressionResult
        {
            get { return Convert.ToBoolean(this["RecordRegressionResult"]); }
            set { this["RecordRegressionResult"] = value; }
        }

        [ConfigurationProperty("BusinessTermFile", DefaultValue = "")]
        public String BusinessTermFile
        {
            get { return "" + this["BusinessTermFile"]; }
            set { this["BusinessTermFile"] = value; }
        }

        [ConfigurationProperty("CacheOption", DefaultValue = Cache.CacheFile)]
        public Cache CacheOption
        {
            get { return (Cache)Enum.Parse(typeof(Cache), this["CacheOption"].ToString()); }
            set { this["CacheOption"] = value; }
        }

        [ConfigurationProperty("UnMemorizedActions", DefaultValue = "")]
        public String UnMemorizedActions
        {
            get { return "" + this["UnMemorizedActions"]; }
            set { this["UnMemorizedActions"] = value; }
        }

        [ConfigurationProperty("AdministratorPassword", DefaultValue = "")]
        public String AdministratorPassword
        {
            get { return "" + this["AdministratorPassword"]; }
            set { this["AdministratorPassword"] = value; }
        }

        [ConfigurationProperty("ClearAllEntryInAppServiceLocator", DefaultValue = "false")]
        public String ClearAllEntryInAppServiceLocator
        {
            get { return "" + this["ClearAllEntryInAppServiceLocator"]; }
            set { this["ClearAllEntryInAppServiceLocator"] = value; }
        }


        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(this.GetType().ToString() + "{");
            //s.Append("PasswordExpiryInDays=" + this.PasswordExpiryInDays + ",");
            //s.Append("PasswordExpiryWarningInDays=" + this.PasswordExpiryWarningInDays + ",");
            s.Append("ApplicationName=" + this.ApplicationName + ",");
            //s.Append("LocalMembershipProvider=" + this.LocalMembershipProvider + ",");
            //s.Append("LocalRoleProvider=" + this.LocalRoleProvider + ",");
            s.Append("ApplicationVersion=" + this.ApplicationVersion + ",");
            //s.Append("PasswordLockedPeriod=" + this.PasswordLockedPeriod + ",");
            //s.Append("PasswordUniqueness=" + this.PasswordUniqueness + ",");
            //s.Append("ReprintPasswordUrl=" + this.ReprintPasswordUrl + ",");
            s.Append("LogFile=" + this.LogFile + ",");
            s.Append("LogLevel=" + this.LogLevel + ",");
            s.Append("LoginUrl=" + this.LoginUrl + ",");
            s.Append("ChangePasswordUrl=" + this.ChangePasswordUrl + ",");
            //s.Append("LogoutUrl=" + this.LogoutUrl + ",");
            //s.Append("ErrorPage=" + this.ErrorPage + ",");
            s.Append("WcfHeaderNamespace="+ this.WcfHeaderNamespace + ",");
            s.Append("UnprotectedActions=" + this.UnprotectedActions);
            s.Append("}");
            return s.ToString();
        }
    }
}