using JJ.Framework.Data.SqlClient;
using JJ.Framework.Exceptions;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace JJ.Framework.Data.NHibernate
{
    public class NHibernateSqlExecutor : ISqlExecutor
    {
        private ISession _session;
        private SqlConnection _sqlConnection;

        public NHibernateSqlExecutor(ISession session)
        {
            if (session == null) throw new NullException(() => session);
            _session = session;
            _sqlConnection = session.Connection as SqlConnection;
            if (_sqlConnection == null) throw new Exception("session.Connection must be an SqlConnection.");
        }

        public int ExecuteNonQuery(object sqlEnum, object parameters = null)
        {
            SqlCommand command = CreateSqlCommand(sqlEnum, parameters);
            return command.ExecuteNonQuery();
        }

        public object ExecuteScalar(object sqlEnum, object parameters = null)
        {
            SqlCommand command = CreateSqlCommand(sqlEnum, parameters);
            return command.ExecuteScalar();
        }

        public IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null) 
            where T : new()
        {
            SqlCommand command = CreateSqlCommand(sqlEnum, parameters);
            return SqlCommandHelper.ExecuteReader<T>(command);
        }

        private SqlCommand CreateSqlCommand(object sqlEnum, object parameters)
        {
            SqlCommand command = SqlCommandHelper.CreateSqlCommand(_sqlConnection, sqlEnum, parameters);

            if (!_session.Transaction.IsActive)
            {
                _session.Transaction.Begin();
            }

            _session.Transaction.Enlist(command);
            
            return command;
        }
    }
}
