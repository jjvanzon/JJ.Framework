using System.Data.SqlClient;

namespace JJ.Framework.Data.SqlClient
{
	public static class SqlExecutorFactory
	{
		public static ISqlExecutor CreateSqlExecutor(string connectionString) => new SqlExecutorWithConnectionString(connectionString);

	    public static ISqlExecutor CreateSqlExecutor(SqlConnection sqlConnection) => new SqlExecutorWithSqlConnection(sqlConnection);
	}
}
