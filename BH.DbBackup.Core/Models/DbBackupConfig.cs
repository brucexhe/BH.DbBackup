using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core
{
    public class DbBackupConfig
    {
        public string dbtype { get; set; }
        public string server { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string timetype { get; set; }
        public string time { get; set; }
        public string positiontype { get; set; }
        public string position { get; set; }
        
    }
}
