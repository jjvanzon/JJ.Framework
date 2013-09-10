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
        public static ISessionFactory GetSessionFactory(string connectionString, Assembly modelAssembly, Assembly mappingAssembly = null)
        {
            return CreateSessionFactory(connectionString, modelAssembly, mappingAssembly);
        }

        private static ISessionFactory CreateSessionFactory(string connectionString, Assembly modelAssembly, Assembly mappingAssembly = null)
        {
            // TODO: This dependency on specifically SQL Server 2008 is not appropriate here.

            var config = new global::NHibernate.Cfg.Configuration();

            var fluentConfig = Fluently.Configure(config)
                                       .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).Dialect<MsSql2008Dialect>())
                                       .Mappings(x => x.FluentMappings.AddFromAssembly(modelAssembly));

            if (mappingAssembly != null)
            {
                fluentConfig = fluentConfig.Mappings(x => x.FluentMappings.AddFromAssembly(mappingAssembly));
            }

            return fluentConfig.BuildSessionFactory();
        }
    }
}
