﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Data.SqlClient
{
    internal class SqlExecutorWithSqlConnection : ISqlExecutor
    {
        private readonly SqlConnection _sqlConnection;

        public SqlExecutorWithSqlConnection(SqlConnection sqlConnection)
            => _sqlConnection = sqlConnection ?? throw new NullException(() => sqlConnection);

        public int ExecuteNonQuery(object sqlEnum, object parameters = null)
        {
            EnsureConnection();
            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_sqlConnection, sqlEnum, parameters);
            return sqlCommand.ExecuteNonQuery();
        }

        public object ExecuteScalar(object sqlEnum, object parameters = null)
        {
            EnsureConnection();
            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_sqlConnection, sqlEnum, parameters);
            return sqlCommand.ExecuteScalar();
        }

        public IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null)
            where T : new()
        {
            EnsureConnection();
            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_sqlConnection, sqlEnum, parameters);
            return SqlCommandHelper.ExecuteReader<T>(sqlCommand);
        }

        private void EnsureConnection()
        {
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }
    }
}