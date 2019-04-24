using System.Configuration;

namespace AbidzarFrame.Web
{
    public class ApiConfiguration : ConfigurationSection
    {
        public static ApiConfiguration GetInstance()
        {
            ApiConfiguration instance = null;
            if ((instance == null))
            {
                instance = ConfigurationManager.GetSection("ApiConfiguration") as ApiConfiguration;
            }

            return instance;
        }

        [ConfigurationProperty("ApiBaseAddress", DefaultValue = "")]
        public string ApiBaseAddress
        {
            get
            {
                return (string)this["ApiBaseAddress"];
            }
            set
            {
                this["ApiBaseAddress"] = value;
            }
        }

    }
}