using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.PlatformCompatibility;
using System.Data;
using System.IO;
using JJ.Framework.IO;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence.SqlClient
{
    public static class SqlCommandHelper
    {
        private static readonly ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

        public static SqlCommand CreateSqlCommand(SqlConnection connection, object sqlEnum, object parameters)
        {
            string sql = GetSql(sqlEnum);
            SqlCommand sqlCommand = CreateSqlCommand(connection, sql, parameters);
            return sqlCommand;
        }

        private static SqlCommand CreateSqlCommand(SqlConnection connection, string sql, object parameters)
        {
            if (connection == null) throw new NullException(() => connection);

            var sqlCommand = new SqlCommand(sql, connection);

            if (parameters != null)
            {
                IList<PropertyInfo> properties = _reflectionCache.GetProperties(parameters.GetType());
                for (int i = 0; i < properties.Count; i++)
                {
                    PropertyInfo property = properties[i];

                    var sqlParameter = new SqlParameter(property.Name, property.GetValue_PlatformSafe(parameters));
                    sqlCommand.Parameters.Add(sqlParameter);
                }
            }

            return sqlCommand;
        }

        public static IEnumerable<T> ExecuteReader<T>(SqlCommand sqlCommand)
            where T : new()
        {
            if (sqlCommand == null) throw new NullException(() => sqlCommand);

            IDataReader reader = sqlCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    T obj = SqlCommandHelper.ConvertRecordToObject<T>(reader);
                    yield return obj;
                }
            }
        }

        private static T ConvertRecordToObject<T>(IDataReader reader)
            where T : new()
        {
            if (IsValueLikeType(typeof(T)))
            {
                T value = (T)ConvertValue(reader[0], typeof(T));
                return value;
            }

            var obj = new T();

            IList<PropertyInfo> properties = _reflectionCache.GetProperties(typeof(T));
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyInfo property = properties[i];
                object value = reader[property.Name];
                object convertedValue = ConvertValue(value, property.PropertyType);
                property.SetValue_PlatformSupport(obj, convertedValue);
            }

            return obj;
        }

        private static bool IsValueLikeType(Type type)
        {
            return type.IsPrimitive ||
                   type.IsEnum ||
                   type == typeof(string) ||
                   type == typeof(DateTime) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid);
        }

        private static IDictionary<object, string> _sqlDictionary = new Dictionary<object, string>();
        private static object _sqlDictionaryLock = new object();

        private static string GetSql(object sqlEnum)
        {
            if (sqlEnum == null) throw new NullException(() => sqlEnum);

            lock (_sqlDictionaryLock)
            {
                string sql;
                if (!_sqlDictionary.TryGetValue(sqlEnum, out sql))
                {
                    Type sqlEnumType = sqlEnum.GetType();
                    string embeddedResourceName = String.Format("{0}.{1}.sql", sqlEnumType.Namespace, sqlEnum);
                    Stream stream = sqlEnumType.Assembly.GetManifestResourceStream(embeddedResourceName);
                    if (stream == null)
                    {
                        throw new Exception(String.Format("Embedded resource with name '{0}' not found. The sql file should be an embedded resource that resides in the same namespace\\subfolder as the sqlEnum type.", embeddedResourceName));
                    }
                    stream.Position = 0;
                    sql = StreamHelper.StreamToString(stream, Encoding.UTF8);

                    _sqlDictionary.Add(sqlEnum, sql);
                }

                return sql;
            }
        }

        private static object ConvertValue(object value, Type type)
        {
            // TODO: Add more conversion types as needed.
            return Convert.ChangeType(value, type);
        }
    }
}