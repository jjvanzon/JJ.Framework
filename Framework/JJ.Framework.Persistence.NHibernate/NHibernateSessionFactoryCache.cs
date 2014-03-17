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
        private static readonly string _separator = "a3ac31a9-708b-41da-b497-b451b9582fd8";

        public static ISessionFactory GetSessionFactory(string connectionString, Assembly modelAssembly, Assembly mappingAssembly)
        {
            lock (_lock)
            {
                string key = GetKey(connectionString, modelAssembly, mappingAssembly);

                if (_dictionary.ContainsKey(key))
                {
                    return _dictionary[key];
                }

                _dictionary[key] = CreateSessionFactory(connectionString, modelAssembly, mappingAssembly);

                return _dictionary[key];
            }
        }

        private static string GetKey(string connectionString, Assembly modelAssembly, Assembly mappingAssembly)
        {
            return connectionString + _separator + modelAssembly.FullName + _separator + mappingAssembly.FullName;
        }

        private static ISessionFactory CreateSessionFactory(string connectionString, Assembly modelAssembly, Assembly mappingAssembly)
        {
            // TODO: This dependency on specifically SQL Server 2008 is not appropriate here.

            var config = new global::NHibernate.Cfg.Configuration();

            var fluentConfig = Fluently.Configure(config).Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).Dialect<MsSql2008Dialect>());

            fluentConfig = fluentConfig.Mappings(x => x.FluentMappings.AddFromAssembly(modelAssembly));
            fluentConfig = fluentConfig.Mappings(x => x.FluentMappings.AddFromAssembly(mappingAssembly));

            return fluentConfig.BuildSessionFactory();
        }
    }
}
