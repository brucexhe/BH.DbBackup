using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DbBackup.Core
{
    public class DbFactory
    {

        public static IDb GetDbInstance()
        {
            DbBackupConfig config = ConfigUtil.GetConfig();
            IDb db = null;
            if (config.dbtype == DbType.MySql.ToString())
            {
                db = new MySqlDb(config);
            } 

            return db;
        }
    }
}
