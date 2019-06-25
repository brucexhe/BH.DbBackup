using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core
{
    public class ConfigUtil
    {
        static ConfigurationRoot config;
        static ConfigUtil()
        {
            if (System.IO.File.Exists("DbBackup.json"))
            {

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
