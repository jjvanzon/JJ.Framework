﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JJ.Framework.Reflection
{
	public class ReflectionCache
	{
		private readonly BindingFlags _bindingFlags;

		public ReflectionCache(BindingFlags bindingFlags) => _bindingFlags = bindingFlags;

		// Properties

		private readonly Dictionary<Type, PropertyInfo[]> _propertiesDictionary = new Dictionary<Type, PropertyInfo[]>();
		private readonly object _propertiesDictionaryLock = new object();

		public PropertyInfo[] GetProperties(Type type)
		{
			lock (_propertiesDictionaryLock)
			{
				// ReSharper disable once InvertIf
				if (!_propertiesDictionary.TryGetValue(type, out PropertyInfo[] properties))
				{
					properties = type.GetProperties(_bindingFlags);
					_propertiesDictionary.Add(type, properties);
				}
				return properties;
			}
		}

		// PropertyDictionaries

		private readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _propertyDictionaryDictionary = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
		private readonly object _propertyDictionaryDictionaryLock = new object();

		public Dictionary<string, PropertyInfo> GetPropertyDictionary(Type type)
		{
			lock (_propertyDictionaryDictionaryLock)
			{
				// ReSharper disable once InvertIf
				if (!_propertyDictionaryDictionary.TryGetValue(type, out Dictionary<string, PropertyInfo> propertyDictionary))
				{
					propertyDictionary = type.GetProperties(_bindingFlags).ToDictionary(x => x.Name);
					_propertyDictionaryDictionary.Add(type, propertyDictionary);
				}
				return propertyDictionary;
			}
		}

		// Fields

		private readonly Dictionary<Type, FieldInfo[]> _fieldsDictionary = new Dictionary<Type, FieldInfo[]>();
		private readonly object _fieldsDictionaryLock = new object();

		public FieldInfo[] GetFields(Type type)
		{
			lock (_fieldsDictionaryLock)
			{
				// ReSharper disable once InvertIf
				if (!_fieldsDictionary.TryGetValue(type, out FieldInfo[] fields))
				{
					fields = type.GetFields(_bindingFlags);
					_fieldsDictionary.Add(type, fields);
				}
				return fields;
			}
		}

		// Types

		private readonly Dictionary<string, Type[]> _typeByShortNameDictionary = new Dictionary<string, Type[]>();
		private readonly object _typeByShortNameDictionaryLock = new object();

		public Type GetTypeByShortName(string shortTypeName)
		{
			Type type = TryGetTypeByShortName(shortTypeName);
			if (type == null)
			{
				throw new Exception($"Type with short name '{shortTypeName}' not found in the AppDomain's assemblies.");
			}
			return type;
		}

		public Type TryGetTypeByShortName(string shortTypeName)
		{
			IList<Type> types = GetTypesByShortName(shortTypeName);

			switch (types.Count)
			{
				case 1:
					return types[0];

				case 0:
					return null;

				default:
					throw new Exception(
						$"Type with short name '{shortTypeName}' found multiple times in the AppDomain's assemblies. " + 
						$"Found types:{Environment.NewLine}{string.Join(Environment.NewLine, types.Select(x => x.FullName))}");
			}
		}

		public IList<Type> GetTypesByShortName(string shortTypeName)
		{
			lock (_typeByShortNameDictionaryLock)
			{
				if (_typeByShortNameDictionary.TryGetValue(shortTypeName, out Type[] types))
				{
					return types;
				}

				var list = new List<Type>();
				foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
				{
					try
					{
						list.AddRange(assembly.GetTypes().Where(x => string.Equals(x.Name, shortTypeName)));
					}
					catch (ReflectionTypeLoadException)
					{
						// Ignore.
						// TODO: Learn why types of some assemblies cannot be retrieved,
						// and why it says the assembly cannot be loaded (file not found),
						// while it clearly is part of the app domain.
					}
				}
				types = list.ToArray();

				_typeByShortNameDictionary.Add(shortTypeName, types);
				return types;
			}
		}

		// Constructors

		private readonly IDictionary<Type, ConstructorInfo> _constructorDictionary = new Dictionary<Type, ConstructorInfo>();
		private readonly object _constructorDictionaryLock = new object();

		public ConstructorInfo GetConstructor(Type type)
		{
			lock (_constructorDictionaryLock)
			{
				if (_constructorDictionary.TryGetValue(type, out ConstructorInfo constructor))
				{
					return constructor;
				}

				IList<ConstructorInfo> constructors = type.GetConstructors(_bindingFlags);
				switch (constructors.Count)
				{
					case 1:
						_constructorDictionary.Add(type, constructors[0]);
						return constructors[0];

					case 0:
						throw new Exception($"No constructor found for type '{type.FullName}' for '{new {_bindingFlags}}'.");

					default:
						throw new Exception(
							$"Multiple constructors found on type '{type.FullName}' for '{new { _bindingFlags }}'. " +
							$"Found constructors: {string.Join(", ", constructors)}");
				}
			}
		}

	}
}
