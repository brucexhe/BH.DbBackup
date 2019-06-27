using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core
{
    public class ConfigUtil
    {
        static String configFile = AppDomain.CurrentDomain.BaseDirectory + "\\DbBackup.json";
        static ConfigurationRoot config;
        static bool initial = false;
        static ConfigUtil()
        {
            try
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("DbBackup.json");

                config = builder.Build() as ConfigurationRoot;
                initial = true;
            }
            catch
            {
                initial = false;
            }
            if (!System.IO.File.Exists(configFile))
            {

                using (var sw = new System.IO.StreamWriter(configFile))
                {
                    DbBackupConfig c = new DbBackupConfig();

                    var json = JsonUtil.ToJsonString(c);
                    sw.Write(json);
                }

            }
            else
            {
                initial = true;
            }


        }

        public static bool hasInitial()
        {
            return initial;
        }
        public static string Read(string key)
        {
            return config[key];
        }
    }
}
