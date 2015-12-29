using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace JJ.Framework.Data.SqlClient
{
    public static class SqlExecutorFactory
    {
        public static ISqlExecutor CreateSqlExecutor(string connectionString)
        {
            return new SqlExecutorWithConnectionString(connectionString);
        }

        public static ISqlExecutor CreateSqlExecutor(SqlConnection sqlConnection)
        {
            return new SqlExecutorWithSqlConnection(sqlConnection);
        }
    }
}
