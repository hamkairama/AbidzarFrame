using System.Configuration;

namespace AbidzarFrame.Web
{
    public class FileConfiguration : ConfigurationSection
    {
        public static FileConfiguration GetInstance()
        {
            FileConfiguration instance = null;
            if ((instance == null))
            {
                instance = ConfigurationManager.GetSection("FileConfiguration") as FileConfiguration;
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

    }
}