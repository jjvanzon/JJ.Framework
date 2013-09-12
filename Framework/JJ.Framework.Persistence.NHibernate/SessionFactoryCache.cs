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
    internal static class SessionFactoryCache
    {
        public static ISessionFactory GetSessionFactory(string connectionString, params Assembly[] modelAssemblies)
        {
            return CreateSessionFactory(connectionString, modelAssemblies);
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
