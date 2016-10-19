using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using JJ.Framework.PlatformCompatibility;
using System.Data;
using System.IO;
using JJ.Framework.IO;
using JJ.Framework.Reflection;

namespace JJ.Framework.Data.SqlClient
{
    public static class SqlCommandHelper
    {
        private static readonly ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);
        private static IDictionary<object, string> _sqlDictionary = new Dictionary<object, string>();
        private static object _sqlDictionaryLock = new object();

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

                    SqlParameter sqlParameter;
                    object value = property.GetValue_PlatformSafe(parameters);
                    if (value == null)
                    {
                        sqlParameter = CreateNullableSqlParameter(property.Name, value, property.PropertyType);
                    }
                    else
                    {
                        sqlParameter = new SqlParameter(property.Name, value);
                    }
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
            if (IsSimpleType(typeof(T)))
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

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive ||
                   type.IsEnum ||
                   type == typeof(string) ||
                   type == typeof(DateTime) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid);
        }

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

        /// <summary>
        /// SqlClient places a lot of special requirements onto nullability of parameters.
        /// As soon as you want to pass null, you have to specify all sorts of additional data.
        /// This method still only handles a select set of types correctly and should be extended in the future.
        /// </summary>
        private static SqlParameter CreateNullableSqlParameter(string name, object value, Type type)
        {
            var sqlParameter = new SqlParameter(name, DBNull.Value);
            sqlParameter.DbType = GetDbType(type);
            if (sqlParameter.DbType == DbType.Binary)
            {
                // To make it varbinary, setting this property like this is required.
                sqlParameter.Size = -1;
            }
            return sqlParameter;
        }

        private static DbType GetDbType(Type type)
        {
            if (type == typeof(String))
            {
                return DbType.String;
            }
            else if (type == typeof(byte[]))
            {
                return DbType.Binary;
            }
            else if (type == typeof(Int32))
            {
                return DbType.Int32;
            }
            else if (type == typeof(Boolean))
            {
                return DbType.Boolean;
            }
            else
            {
                // TODO: Program additional conversion code to support more types.
                throw new Exception(String.Format("Type '{0}' is not supported.", type.FullName));
            }
        }
    }
}