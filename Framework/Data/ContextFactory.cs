using System;
using System.Collections.Generic;
using System.Reflection;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Reflection;

namespace JJ.Framework.Data
{
	public static class ContextFactory
	{
		/// <summary>
		/// Creates a context using the values out of the config file.
		/// A configuration example can be found in your bin directory.
		/// </summary>
		public static IContext CreateContextFromConfiguration()
		{
			PersistenceConfiguration persistenceConfiguration = PersistenceConfigurationHelper.GetPersistenceConfiguration();

			return CreateContextFromConfiguration(persistenceConfiguration);
		}

		public static IContext CreateContextFromConfiguration(PersistenceConfiguration persistenceConfiguration)
		{
			if (persistenceConfiguration == null) throw new NullException(() => persistenceConfiguration);

			return CreateContext(
				persistenceConfiguration.ContextType,
				persistenceConfiguration.Location,
				persistenceConfiguration.ModelAssembly,
				persistenceConfiguration.MappingAssembly,
				persistenceConfiguration.Dialect);
		}

		/// <param name="contextTypeName">
		/// Can be a fully qualified type name, or the name of the assembly that holds the type, 
		/// or if the assembly name starts with 'JJ.Framework.Data' you can omit the 'JJ.Framework.Data.' from the name.
		/// </param>
		public static IContext CreateContext(string contextTypeName, string location, string modelAssemblyName, string mappingAssemblyName, string dialect)
		{
			Type persistenceContextType = ResolveContextType(contextTypeName);

			Assembly modelAssembly = null;
			if (!string.IsNullOrEmpty(modelAssemblyName))
			{
				modelAssembly = Assembly.Load(modelAssemblyName);
			}

			Assembly mappingAssembly = null;
			if (!string.IsNullOrEmpty(mappingAssemblyName))
			{
				mappingAssembly = Assembly.Load(mappingAssemblyName);
			}

			return CreateContext(persistenceContextType, location, modelAssembly, mappingAssembly, dialect);
		}

		public static IContext CreateContext(Type persistenceContextType, string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
		{
			return (IContext)Activator.CreateInstance(persistenceContextType, persistenceLocation, modelAssembly, mappingAssembly, dialect);
		}

		private static readonly object _contextTypeDictionaryLock = new object();
		private static readonly Dictionary<string, Type> _contextTypeDictionary = new Dictionary<string, Type>();

		private static Type ResolveContextType(string contextTypeName)
		{
			if (contextTypeName == null) throw new NullException(() => contextTypeName);

			lock (_contextTypeDictionaryLock)
			{
				if (_contextTypeDictionary.ContainsKey(contextTypeName))
				{
					return _contextTypeDictionary[contextTypeName];
				}

				// Try to get type by name
				Type type = Type.GetType(contextTypeName);
				if (type == null)
				{
					// Otherwise assume the assembly name is :JJ.Framework.Data." + persistenceContextTypeName.
					string assumedAssemblyName = typeof(ContextFactory).Assembly.GetName().Name + "." + contextTypeName;
					Assembly assembly;
					try
					{
						assembly = Assembly.Load(assumedAssemblyName);
					}
					// TODO:
					// Warning CA1031  Modify 'ContextFactory.ResolveContextType(string)' to catch a more specific exception than 'object' or rethrow the exception.
					catch
					{
						// Otherwise assume it is a full assembly name.
						assembly = Assembly.Load(contextTypeName);
					}
					IList<Type> types = assembly.GetImplementations<IContext>();
					switch (types.Count)
					{
						case 1:
							type = types[0];
							break;

						case 0:
							throw new Exception($"Context type '{contextTypeName}' not found.");

						default:
							throw new Exception($"Multiple context types found in assembly '{assembly.GetName().Name}'. Please specify a fully qualified type name or implement only one context in the assembly.");
					}
				}

				_contextTypeDictionary[contextTypeName] = type;
				return type;
			}
		}
	}
}
