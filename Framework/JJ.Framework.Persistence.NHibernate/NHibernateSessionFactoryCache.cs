using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Persistence.NHibernate
{
    internal static class NHibernateSessionFactoryCache
    {
        private static readonly object _lock = new object();
        private static readonly Dictionary<string, ISessionFactory> _dictionary = new Dictionary<string, ISessionFactory>();
        private static readonly string _separator = "$$";

        public static ISessionFactory GetSessionFactory(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
        {
            lock (_lock)
            {
                string key = GetKey(connectionString, modelAssembly, mappingAssembly, dialect);

                if (_dictionary.ContainsKey(key))
                {
                    return _dictionary[key];
                }

                _dictionary[key] = CreateSessionFactory(connectionString, modelAssembly, mappingAssembly, dialect);

                return _dictionary[key];
            }
        }

        private static string GetKey(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
        {
            return connectionString + _separator + modelAssembly.FullName + _separator + mappingAssembly.FullName + _separator + dialect;
        }

        private static ISessionFactory CreateSessionFactory(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
        {
            if (String.IsNullOrEmpty(dialect)) throw new ArgumentException("dialect cannot be null or empty.");

            var config = new global::NHibernate.Cfg.Configuration();

            FluentConfiguration fluentConfig;

            if (dialect == DialectNames.SqlServer2008)
            {
                fluentConfig = Fluently.Configure(config).Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).Dialect<MsSql2008Dialect>());
            }
            else
            {
                throw new NotSupportedException(String.Format("Dialect '{0}' not supported.", dialect));
            }

            fluentConfig = fluentConfig.Mappings(x => x.FluentMappings.AddFromAssembly(modelAssembly));
            fluentConfig = fluentConfig.Mappings(x => x.FluentMappings.AddFromAssembly(mappingAssembly));

            return fluentConfig.BuildSessionFactory();
        }
    }
}
