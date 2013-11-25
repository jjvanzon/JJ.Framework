using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.NHibernate
{
    internal static class NHibernateSessionFactoryCache
    {
        private static readonly object _lock = new object();
        private static readonly Dictionary<string, ISessionFactory> _dictionary = new Dictionary<string, ISessionFactory>();
        private static readonly string _separator = "a3ac31a9-708b-41da-b497-b451b9582fd8";

        public static ISessionFactory GetSessionFactory(string connectionString, params Assembly[] modelAssemblies)
        {
            lock (_lock)
            {
                string key = GetKey(connectionString, modelAssemblies);

                if (_dictionary.ContainsKey(key))
                {
                    return _dictionary[key];
                }

                _dictionary[key] = CreateSessionFactory(connectionString, modelAssemblies);

                return _dictionary[key];
            }
        }
        
        private static string GetKey(string connectionString, Assembly[] modelAssemblies)
        {
            return connectionString + _separator + String.Join(_separator, (object[])modelAssemblies);
        }

        private static ISessionFactory CreateSessionFactory(string connectionString, params Assembly[] modelAssemblies)
        {
            // TODO: This dependency on specifically SQL Server 2008 is not appropriate here.

            var config = new global::NHibernate.Cfg.Configuration();

            var fluentConfig = Fluently.Configure(config).Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).Dialect<MsSql2008Dialect>());

            foreach (Assembly modelAssembly in modelAssemblies)
            {
                fluentConfig = fluentConfig.Mappings(x => x.FluentMappings.AddFromAssembly(modelAssembly));
            }

            return fluentConfig.BuildSessionFactory();
        }
    }
}
