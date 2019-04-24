using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AbidzarFrame.API.Service
{
    public class ApiConfiguration : ConfigurationSection
    {
        protected static ApiConfiguration instance = null;

        public static ApiConfiguration GetInstance()
        {
            if ((instance == null))
                instance = (ApiConfiguration)ConfigurationManager.GetSection("ApiConfiguration");
            return instance;
        }

        [ConfigurationProperty("ConfigFilePath", DefaultValue = "")]
        public string ConfigFilePath
        {
            get { return "" + this["ConfigFilePath"]; }
            set { this["ConfigFilePath"] = value; }
        }

    }


}