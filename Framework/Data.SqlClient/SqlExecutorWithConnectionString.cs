using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace JJ.Framework.Data.SqlClient
{
    internal class SqlExecutorWithConnectionString : ISqlExecutor
    {
        private string _connectionString;

        public SqlExecutorWithConnectionString(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString)) throw new NullOrEmptyException(() => connectionString);
            _connectionString = connectionString;
        }

        public int ExecuteNonQuery(object sqlEnum, object parameters = null)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(sqlConnection, sqlEnum, parameters);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(object sqlEnum, object parameters = null)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(sqlConnection, sqlEnum, parameters);
                return sqlCommand.ExecuteScalar();
            }
        }

        public IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null)
            where T : new()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(sqlConnection, sqlEnum, parameters);
                return SqlCommandHelper.ExecuteReader<T>(sqlCommand).ToArray();
            }
        }
    }
}
