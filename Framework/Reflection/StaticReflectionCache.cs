using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JJ.Framework.Common;

namespace JJ.Framework.Reflection
{
	public static class StaticReflectionCache
	{
		// TODO: The use of these Tuples as keys might not be fast dictionary keys.
		// Use a different approach to reflection caching (like in ReflectionCacheDemo) and test what happens when you use .NET's own Tuple class.

		// Fields

		private static readonly Dictionary<Tuple<Type, string>, FieldInfo> _fieldIndex = new Dictionary<Tuple<Type, string>, FieldInfo>();
		private static readonly object _fieldIndexLock = new object();

		public static FieldInfo GetField(Type type, string name)
		{
			FieldInfo field = TryGetField(type, name);
			if (field == null)
			{
				throw new Exception($"Field '{name}' not found.");
			}
			return field;
		}

		public static FieldInfo TryGetField(Type type, string name)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			lock (_fieldIndexLock)
			{
				var key = new Tuple<Type, string>(type, name);
				if (_fieldIndex.ContainsKey(key))
				{
					return _fieldIndex[key];
				}
				else
				{
					FieldInfo field = type.GetField(name, ReflectionHelper.BINDING_FLAGS_ALL);
					_fieldIndex[key] = field;
					return field;
				}
			}
		}

		// Properties

		private static readonly Dictionary<Tuple<Type, string>, PropertyInfo> _propertyIndex = new Dictionary<Tuple<Type, string>, PropertyInfo>();
		private static readonly object _propertyIndexLock = new object();

		public static PropertyInfo GetProperty(Type type, string name)
		{
			PropertyInfo property = TryGetProperty(type, name);
			if (property == null)
			{
				throw new Exception($"Property '{name}' not found.");
			}
			return property;
		}

		public static PropertyInfo TryGetProperty(Type type, string name)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			lock (_propertyIndexLock)
			{
				var key = new Tuple<Type, string>(type, name);
				if (_propertyIndex.ContainsKey(key))
				{
					return _propertyIndex[key];
				}
				else
				{
					PropertyInfo property = type.GetProperty(name, ReflectionHelper.BINDING_FLAGS_ALL);
					_propertyIndex[key] = property;
					return property;
				}
			}
		}

		// Indexers

		private static readonly Dictionary<Tuple<Type, string>, PropertyInfo> _indexerIndex = new Dictionary<Tuple<Type, string>, PropertyInfo>();
		private static readonly object _indexerIndexLock = new object();

		public static PropertyInfo GetIndexer(Type type, params Type[] parameterTypes)
		{
			PropertyInfo property = TryGetIndexer(type, parameterTypes);
			if (property == null)
			{
				throw new Exception($"Indexer not found with parameterTypes '{string.Join(", ", parameterTypes.Select(x => x.ToString()))}'.");
			}
			return property;
		}

		public static PropertyInfo TryGetIndexer(Type type, params Type[] parameterTypes)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (parameterTypes == null) throw new ArgumentNullException(nameof(parameterTypes));
			if (parameterTypes.Length == 0) throw new Exception("parameterTypes.Length is 0."); 

			// ReSharper disable once CoVariantArrayConversion
			string parameterTypesKey = KeyHelper.CreateKey(parameterTypes);

			lock (_indexerIndexLock)
			{
				var key = new Tuple<Type, string>(type, parameterTypesKey);
				if (_indexerIndex.ContainsKey(key))
				{
					return _indexerIndex[key];
				}
				else
				{
					var defaultMemberAttribute = (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true).SingleOrDefault();
					if (defaultMemberAttribute == null)
					{
						return null;
					}
					string name = defaultMemberAttribute.MemberName;
					PropertyInfo property = type.GetProperty(name, ReflectionHelper.BINDING_FLAGS_ALL, null, null, parameterTypes, null);
					_indexerIndex[key] = property;
					return property;
				}
			}
		}

		// Methods

		private static readonly Dictionary<Tuple<Type, BindingFlags>, MethodInfo[]> _methodsIndex = new Dictionary<Tuple<Type, BindingFlags>, MethodInfo[]>();
		private static readonly object _methodsIndexLock = new object();

		public static MethodInfo[] GetMethods(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			lock (_methodsIndexLock)
			{
				var key = new Tuple<Type, BindingFlags>(type, bindingFlags);
				if (_methodsIndex.ContainsKey(key))
				{
					return _methodsIndex[key];
				}
				else
				{
					MethodInfo[] methods = type.GetMethods(bindingFlags);
					_methodsIndex[key] = methods;
					return methods;
				}
			}
		}

		private static readonly Dictionary<Tuple<Type, string, string>, MethodInfo> _methodDictionary = new Dictionary<Tuple<Type, string, string>, MethodInfo>();
		private static readonly object _methodDictionaryLock = new object();

		public static MethodInfo GetMethod(Type type, string name, params Type[] parameterTypes)
		{
			MethodInfo method = TryGetMethod(type, name, parameterTypes);
			if (method == null)
			{
				throw new Exception($"Method '{name}' not found.");
			}
			return method;
		}

		public static MethodInfo TryGetMethod(Type type, string name, params Type[] parameterTypes)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (parameterTypes == null) throw new ArgumentNullException(nameof(parameterTypes));
			
			// ReSharper disable once CoVariantArrayConversion
			string parameterTypesKey = KeyHelper.CreateKey(parameterTypes);

			lock (_methodDictionaryLock)
			{
				var key = new Tuple<Type, string, string>(type, name, parameterTypesKey);
				if (_methodDictionary.ContainsKey(key))
				{
					return _methodDictionary[key];
				}
				else
				{
					MethodInfo method = type.GetMethod(name, ReflectionHelper.BINDING_FLAGS_ALL, null, parameterTypes, null);
					_methodDictionary[key] = method;
					return method;
				}
			}
		}

		// Obsolete

		[Obsolete("Use ReflectionCache.GetFields instead.", true)]
		public static FieldInfo[] GetFields(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance) => throw new NotSupportedException("Use ReflectionCache.GetFields instead.");

	    [Obsolete("Use ReflectionCache.GetProperties instead.", true)]
		public static PropertyInfo[] GetProperties(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance) => throw new NotSupportedException("Use ReflectionCache.GetProperties instead.");
	}
}
