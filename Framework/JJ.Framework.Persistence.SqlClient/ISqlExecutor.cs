using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.SqlClient
{
    public interface ISqlExecutor
    {
        int ExecuteNonQuery(object sqlEnum, object parameters = null);
        object ExecuteScalar(object sqlEnum, object parameters = null);
        IEnumerable<T> ExecuteReader<T>(object sqlEnum, object parameters = null) where T : new();
    }
}
