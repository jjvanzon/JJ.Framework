using JJ.Framework.Common;
using JJ.Framework.IO;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Data.SqlClient
{
    // TODO:
    // MSBUILD : warning CA1001: Microsoft.Design : Implement IDisposable on 'SqlExecutor' because it creates members of the following IDisposable types: 'SqlConnection'. If 'SqlExecutor' has previously shipped, adding new members that implement IDisposable to this type is considered a breaking change to existing consumers.
    public class SqlExecutor : ISqlExecutor
    {
        private SqlConnection _connection;
        private string _connectionString;

        public SqlExecutor(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString)) throw new NullException(() => connectionString);
            _connectionString = connectionString;
        }

        public SqlExecutor(SqlConnection connection)
        {
            if (connection == null) throw new NullException(() => connection);
            _connection = connection;
        }

        public int ExecuteNonQuery(object sqlEnum, object parameters = null)
        {
            EnsureConnection();
            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_connection, sqlEnum, parameters);
            return sqlCommand.ExecuteNonQuery();
        }

        public object ExecuteScalar(object sqlEnum, object parameters = null)
        {
            EnsureConnection();
            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_connection, sqlEnum, parameters);
            return sqlCommand.ExecuteScalar();
        }

        public IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null)
            where T : new()
        {
            EnsureConnection();
            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_connection, sqlEnum, parameters);
            return SqlCommandHelper.ExecuteReader<T>(sqlCommand);
        }

        private void EnsureConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
            }

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
