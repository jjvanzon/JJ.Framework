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

namespace JJ.Framework.Persistence.SqlClient
{
    public class SqlExecutor : ISqlExecutor
    {
        private SqlConnection _connection;

        public SqlExecutor(SqlConnection connection)
        {
            if (connection == null) throw new NullException(() => connection);
            _connection = connection;
        }

        public int ExecuteNonQuery(object sqlEnum, object parameters = null)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_connection, sqlEnum, parameters);
            return sqlCommand.ExecuteNonQuery();
        }

        public object ExecuteScalar(object sqlEnum, object parameters = null)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_connection, sqlEnum, parameters);
            return sqlCommand.ExecuteScalar();
        }

        public IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null)
            where T : new()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            SqlCommand sqlCommand = SqlCommandHelper.CreateSqlCommand(_connection, sqlEnum, parameters);
            return SqlCommandHelper.ExecuteReader<T>(sqlCommand);
        }
    }
}
