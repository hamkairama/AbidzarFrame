using System.Configuration;

namespace AbidzarFrame.API.Service
{
    public class AuthenticationConfiguration : ConfigurationSection
    {
        public static AuthenticationConfiguration GetInstance()
        {
            AuthenticationConfiguration instance = null;
            if ((instance == null))
            {
                instance = ConfigurationManager.GetSection("AuthenticationConfiguration") as AuthenticationConfiguration;
            }

            return instance;
        }

        [ConfigurationProperty("ConfigFilePath", DefaultValue = "")]
        public string ConfigFilePath
        {
            get
            {
                return (string)this["ConfigFilePath"];
            }
            set
            {
                this["ConfigFilePath"] = value;
            }
        }
        [ConfigurationProperty("WebServiceAuthenticationToken", DefaultValue = "")]
        public string WebServiceAuthenticationToken
        {
            get
            {
                return (string)this["WebServiceAuthenticationToken"];
            }
            set
            {
                this["WebServiceAuthenticationToken"] = value;
            }
        }

        [ConfigurationProperty("WebServiceAuthenticationDB", DefaultValue = "")]
        public string WebServiceAuthenticationDB
        {
            get
            {
                return (string)this["WebServiceAuthenticationDB"];
            }
            set
            {
                this["WebServiceAuthenticationDB"] = value;
            }
        }

    }
}