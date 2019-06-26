using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core
{
    public class ConfigUtil
    {
        static String configFile = "DbBackup.json";
        static ConfigurationRoot config;
        public static bool isInitial = true;
        static ConfigUtil()
        {
            if (!System.IO.File.Exists(configFile))
            {
                isInitial = false;

                using (var sw = new System.IO.StreamWriter(configFile))
                {
                    DbBackupConfig c = new DbBackupConfig();
                }
            }
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("DbBackup.json");

            config = builder.Build() as ConfigurationRoot;

        }
        public static string Read(string key)
        {
            return config[key];
        }
    }
}
