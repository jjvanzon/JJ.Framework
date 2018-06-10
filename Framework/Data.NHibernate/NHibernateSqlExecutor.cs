using System.Collections.Generic;
using System.Data.SqlClient;
using JJ.Framework.Data.SqlClient;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.TypeChecking;
using NHibernate;

namespace JJ.Framework.Data.NHibernate
{
    public class NHibernateSqlExecutor : ISqlExecutor
    {
        private readonly ISession _session;
        private readonly SqlConnection _sqlConnection;

        public NHibernateSqlExecutor(ISession session)
        {
            _session = session ?? throw new NullException(() => session);
            _sqlConnection = session.Connection as SqlConnection;
            if (_sqlConnection == null) throw new IsNotTypeException<SqlConnection>(() => session.Connection);
        }

        public int ExecuteNonQuery(object sqlEnum, object parameters = null) => CreateSqlCommand(sqlEnum, parameters).ExecuteNonQuery();

        public object ExecuteScalar(object sqlEnum, object parameters = null) => CreateSqlCommand(sqlEnum, parameters).ExecuteScalar();

        public IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null) where T : new()
            => SqlCommandHelper.ExecuteReader<T>(CreateSqlCommand(sqlEnum, parameters));

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