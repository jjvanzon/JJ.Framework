﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace JJ.Framework.Data.NHibernate
{
    internal static class NHibernateSessionFactoryCache
    {
        private static readonly object _lock = new object();
        private static readonly Dictionary<string, ISessionFactory> _dictionary = new Dictionary<string, ISessionFactory>();
        private const string SEPARATOR = "$$";

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

        private static string GetKey(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect) => connectionString + SEPARATOR + modelAssembly.FullName + SEPARATOR + mappingAssembly.FullName + SEPARATOR + dialect;

        private static ISessionFactory CreateSessionFactory(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
        {
            if (string.IsNullOrEmpty(dialect)) throw new ArgumentException("dialect cannot be null or empty.");

            var config = new global::NHibernate.Cfg.Configuration();

            FluentConfiguration fluentConfiguration;

            if (dialect == DialectNames.SqlServer2008)
            {
                fluentConfiguration = Fluently.Configure(config).Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).Dialect<MsSql2008Dialect>());
            }
            else
            {
                throw new NotSupportedException($"Dialect '{dialect}' not supported.");
            }

            fluentConfiguration = fluentConfiguration.Mappings(x => x.FluentMappings.AddFromAssembly(modelAssembly));
            fluentConfiguration = fluentConfiguration.Mappings(x => x.FluentMappings.AddFromAssembly(mappingAssembly));

            return fluentConfiguration.BuildSessionFactory();
        }
    }
}
