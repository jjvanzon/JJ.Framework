﻿using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.PlatformCompatibility;

namespace JJ.Framework.Persistence.Legacy
{
    public static class RepositoryFactory
    {
        /// <summary>
        /// Creates a context using the values out of the config file.
        /// A configuration example can be found in your bin directory.
        /// The repository implementation should be present in one of the repository assemblies mentioned in the config file.
        /// The repository implementation must have a constructor that takes a single parameter of type IContext.
        /// </summary>
        /// <typeparam name="TRepositoryInterface">The repository interface type.</typeparam>
        public static TRepositoryInterface CreateRepositoryFromConfiguration<TRepositoryInterface>(IContext context, PersistenceConfiguration configuration)
        {
            if (configuration == null) throw new NullException(() => configuration);
            return CreateRepository<TRepositoryInterface>(context, configuration.RepositoryAssemblies);
        }
        
        /// <summary>
        /// Creates a context using the values out of the config file.
        /// A configuration example can be found in your bin directory.
        /// The repository implementation should be present in one of the repository assemblies mentioned in the config file.
        /// The repository implementation must have a constructor that takes a single paramter of type IContext.
        /// </summary>
        /// <typeparam name="TRepositoryInterface">The repository interface type.</typeparam>
        public static TRepositoryInterface CreateRepositoryFromConfiguration<TRepositoryInterface>(IContext context)
        {
            PersistenceConfiguration configuration = PersistenceConfigurationHelper.GetPersistenceConfiguration();

            return RepositoryFactory.CreateRepository<TRepositoryInterface>(context, configuration.RepositoryAssemblies);
        }

        /// <summary>
        /// Create a repository from one of the supplied repository assemblies, that implements the given interface.
        /// Each assembly should at most contain one implementation of the repository interface.
        /// The repository type must have a constructor that takes a single paramter of type IContext.
        /// </summary>
        /// <typeparam name="TRepositoryInterface">The repository interface type.</typeparam>
        public static TRepositoryInterface CreateRepository<TRepositoryInterface>(IContext context, params string[] repositoryAssemblyNames)
        {
            if (repositoryAssemblyNames == null) throw new NullException(() => repositoryAssemblyNames);

            Assembly[] repositoryAssemblies = repositoryAssemblyNames.Select(x => Assembly.Load(x)).ToArray();

            return RepositoryFactory.CreateRepository<TRepositoryInterface>(context, repositoryAssemblies);
        }

        /// <summary>
        /// Create a repository from one of the supplied repository assemblies, that implements the given interface.
        /// Each assembly should at most contain one implementation of the repository interface.
        /// The repository type must have a constructor that takes a single paramter of type IContext.
        /// </summary>
        /// <typeparam name="TRepositoryInterface">The repository interface type.</typeparam>
        public static TRepositoryInterface CreateRepository<TRepositoryInterface>(IContext context, params Assembly[] repositoryAssemblies)
        {
            if (repositoryAssemblies == null) throw new NullException(() => repositoryAssemblies);

            foreach (Assembly repositoryAssembly in repositoryAssemblies)
            {
                Type repositoryType = ReflectionHelper.TryGetImplementation<TRepositoryInterface>(repositoryAssembly);
                if (repositoryType != null)
                {
                    return (TRepositoryInterface)Activator.CreateInstance(repositoryType, context);
                }
            }

            string repositoryAssembliesDescription = String_PlatformSupport.Join(", ", repositoryAssemblies.Select(x => x.GetName().Name));
            throw new Exception(String.Format("No implementation of type {0} found in any of the following assemblies: {1}", typeof(TRepositoryInterface), repositoryAssembliesDescription));
        }
    }
}
