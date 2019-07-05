using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BH.DbBackup.Core
{
    public interface IDb
    {
        DbConnection GetConnection();

        bool ConnectTest();

        List<DbInfo> GetDbList();
    }
}
