using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class ConfigurationReader
    {
        public static Int16 Read(String propertyName, Int16 defaultValue) 
        {
            return Convert.ToInt16(Read(propertyName, Convert.ToInt64(defaultValue)));
        }

        public static Int32 Read(String propertyName, Int32 defaultValue)
        {
            return Convert.ToInt32(Read(propertyName, Convert.ToInt64(defaultValue)));
        }

        public static Int64 Read(String propertyName, Int64 defaultValue)
        {
            Int64 propertyValue = defaultValue;

            String property = ConfigurationManager.AppSettings[propertyName];
            if (property != null)
            {
                propertyValue = Convert.ToInt16(property);
            }

            return propertyValue;
        }

        public static String Read(String propertyName, String defaultValue)
        {
            String propertyValue = defaultValue;

            String property = ConfigurationManager.AppSettings[propertyName];
            if (property != null)
            {
                propertyValue = property;
            }

            return propertyValue;
        }

    }
}