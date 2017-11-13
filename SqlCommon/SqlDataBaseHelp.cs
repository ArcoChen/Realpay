using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper
{
    public class SqlDataBaseHelp
    {
        SqlDataBase sdatabase = new SqlDataBase(SqlHelper.SqlBaseHelper.GetConnSting());
        public string CreateTableScript()
        {
            sdatabase.databaseName = "YgOrder";
            sdatabase.tableName = "Pro_BaseStock";
            return sdatabase.GetCreateTableScript();
        }
    }
}
