using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BH.DbBackup.Core
{
    public class MySqlDb : IDb
    {
        private DbBackupConfig config;
        public MySqlDb(DbBackupConfig _config)
        {
            config = _config;
        }

        public DbConnection GetConnection()
        {
            var connString = string.Format("server={0};port=3306;database={1};user={2};password={3};CharSet=utf8;", config.server, config.dbname, config.username, config.password);
            var conn = new MySqlConnection(connString);

            return conn;
        }



        public bool ConnectTest()
        {
            if (config.dbtype == DbType.MySql.ToString())
            {
                try
                {
                    using (MySqlConnection conn = (MySqlConnection)GetConnection())
                    {
                        conn.Open();
                    }

                    return true;
                }
                catch
                {
                }

            }

            return false;
        }

        public List<DbInfo> GetDbList()
        {
            var list = new List<DbInfo>();
            using (MySqlConnection conn = (MySqlConnection)GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("show databases;", conn))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new DbInfo() { Name = rdr[0].ToString() });
                        }
                    }


                }

            }
            return list;
        }
    }
}
