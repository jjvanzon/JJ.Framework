using System.Collections.Generic;

namespace JJ.Framework.Data.SqlClient
{
    public interface ISqlExecutor
    {
        int ExecuteNonQuery(object sqlEnum, object parameters = null);
        object ExecuteScalar(object sqlEnum, object parameters = null);
        IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null) where T : new();
    }
}
