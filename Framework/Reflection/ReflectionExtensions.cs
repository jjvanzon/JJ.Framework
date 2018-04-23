using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Text;

namespace JJ.Framework.Reflection
{
	public static class ReflectionExtensions
	{
		// ItemType

		private static readonly object _itemTypeDictionaryLock = new object();
		private static readonly Dictionary<Type, Type> _itemTypeDictionary = new Dictionary<Type, Type>();

		public static Type GetItemType(this PropertyInfo collectionProperty)
		{
			if (collectionProperty == null) throw new ArgumentNullException(nameof(collectionProperty));
			return GetItemType(collectionProperty.PropertyType);
		}

		public static Type GetItemType(this object collection)
		{
			if (collection == null) throw new ArgumentNullException(nameof(collection));

			return GetItemType(collection.GetType());
		}

		public static Type GetItemType(this Type collectionType)
		{
			Type itemType = TryGetItemType(collectionType);
			if (itemType == null)
			{
				throw new Exception($"Type '{collectionType}' has no item type.");
			}
			return itemType;
		}

		public static Type TryGetItemType(this Type collectionType)
		{
			if (collectionType == null) throw new ArgumentNullException(nameof(collectionType));

			lock (_itemTypeDictionaryLock)
			{
				if (_itemTypeDictionary.TryGetValue(collectionType, out Type itemType))
				{
					return itemType;
				}

				// This works for IEnumerable<T> itself.
				if (collectionType.IsGenericType)
				{
					Type openGenericCollectionType = collectionType.GetGenericTypeDefinition();
					if (openGenericCollectionType == typeof(IEnumerable<>))
					{
						itemType = collectionType.GetGenericArguments()[0];
					}
				}

				// This works for types that implement IEnumerable<T> / have IEnumerable<T> as a base.
				Type enumerableInterface = collectionType.GetInterface_PlatformSafe(typeof(IEnumerable<>).FullName);
				if (enumerableInterface != null)
				{
					itemType = enumerableInterface.GetGenericArguments()[0];
				}

				_itemTypeDictionary.Add(collectionType, itemType);

				return itemType;
			}
		}

		// GetImplementation

		private static readonly object _implementationsDictionaryLock = new object();
		private static readonly Dictionary<string, Type[]> _implementationsDictionary = new Dictionary<string, Type[]>();

		public static Type GetImplementation(this Assembly assembly, Type baseType)
		{
			Type type = TryGetImplementation(assembly, baseType);

			if (type == null)
			{
				throw new Exception($"No implementation of type '{baseType}' found in assembly '{assembly.GetName().Name}'.");
			}

			return type;
		}

		public static Type TryGetImplementation(this Assembly assembly, Type baseType)
		{
			Type[] types = GetImplementations(assembly, baseType);

			if (types.Length == 0)
			{
				return null;
			}

			if (types.Length > 1)
			{
				throw new Exception($"Multiple implementations of type '{baseType}' found in assembly '{assembly.GetName().Name}'.");
			}

			return types[0];
		}

		public static Type[] GetImplementations(this IEnumerable<Assembly> assemblies, Type baseType)
		{
			return assemblies.SelectMany(x => GetImplementations(x, baseType)).ToArray();
		}

		public static Type[] GetImplementations(this Assembly assembly, Type baseType)
		{
			if (assembly == null) throw new ArgumentNullException(nameof(assembly));
			if (baseType == null) throw new ArgumentNullException(nameof(baseType));

			lock (_implementationsDictionaryLock)
			{
				string key = GetImplementationsDictionaryKey(assembly, baseType);
				// ReSharper disable once InvertIf
				if (!_implementationsDictionary.TryGetValue(key, out Type[] types))
				{
					types = assembly.GetTypes();
					types = Enumerable.Union(
						types.Where(x => x.GetBaseClasses().Contains(baseType)),
						types.Where(x => x.GetInterface_PlatformSafe(baseType.Name) != null)).ToArray();

					_implementationsDictionary.Add(key, types);
				}

				return types;
			}
		}

		private static string GetImplementationsDictionaryKey(this Assembly assembly, Type baseType)
		{
			// TODO: Is it not a bad plan to hash a large string?
			return assembly.FullName + "$" + baseType.FullName + "$" + baseType.Assembly.FullName;
		}

		// Generic overloads

		public static Type GetImplementation<TBaseType>(this Assembly assembly)
		{
			return GetImplementation(assembly, typeof(TBaseType));
		}

		public static Type TryGetImplementation<TBaseType>(this Assembly assembly)
		{
			return TryGetImplementation(assembly, typeof(TBaseType));
		}

		public static IList<Type> GetImplementations<TBaseType>(this Assembly assembly)
		{
			return GetImplementations(assembly, typeof(TBaseType));
		}

		public static IList<Type> GetImplementations<TBaseType>(this IEnumerable<Assembly> assemblies)
		{
			return GetImplementations(assemblies, typeof(TBaseType));
		}

		// Misc

		public static bool IsAssignableTo(this Type type, Type otherType)
		{
			if (otherType == null) throw new ArgumentNullException(nameof(otherType));

			return otherType.IsAssignableFrom(type);
		}

		public static bool IsNullableType(this Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		public static bool IsReferenceType(this Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			return !type.IsValueType;
		}

		public static bool IsProperty(this MethodBase method)
		{
			if (method == null) throw new ArgumentNullException(nameof(method));

			bool isProperty = method.Name.StartsWith("get_") ||
							  method.Name.StartsWith("set_");
			return isProperty;
		}

		public static bool IsIndexer(this MethodBase method)
		{
			if (!method.IsSpecialName)
			{
				return false;
			}

			if (!method.Name.StartsWith("get_") &&
				!method.Name.StartsWith("set_"))
			{
				return false;
			}

			string propertyName = method.Name.TrimStart("get_").TrimStart("set_");

			Type type = method.DeclaringType;
			// ReSharper disable once PossibleNullReferenceException
			var defaultMemberAttribute = (DefaultMemberAttribute)type.GetCustomAttributes(typeof(DefaultMemberAttribute), inherit: true).SingleOrDefault();
			if (defaultMemberAttribute == null)
			{
				return false;
			}

			if (defaultMemberAttribute.MemberName == propertyName)
			{
				return true;
			}

			return false;
		}

		public static bool IsStatic(this MemberInfo member)
		{
			if (member == null) throw new ArgumentNullException(nameof(member));

			MemberTypes_PlatformSafe memberType = member.MemberType_PlatformSafe();

			switch (memberType)
			{
				case MemberTypes_PlatformSafe.Field:
					var field = (FieldInfo)member;
					return field.IsStatic;

				case MemberTypes_PlatformSafe.Method:
					var method = (MethodInfo)member;
					return method.IsStatic;

				case MemberTypes_PlatformSafe.Property:
					var property = (PropertyInfo)member;
					// TODO: Check if this will work for public members.
					MethodInfo getterOrSetter = property.GetGetMethod(nonPublic: true) ?? property.GetSetMethod(nonPublic: true);
					return getterOrSetter.IsStatic;

				default:
					throw new Exception($"IsStatic cannot be obtained from member of type '{member.GetType()}'.");
			}
		}

		/// <summary>
		/// A simple type can be a .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr
		/// the numeric types, their signed and unsigned variations, but also
		/// String, Guid, DateTime, TimeSpan and Enum types.
		/// </summary>
		public static bool IsSimpleType(this Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			if (type.IsPrimitive ||
			    type.IsEnum ||
			    type == typeof(string) ||
			    type == typeof(Guid) ||
			    type == typeof(DateTime) ||
			    type == typeof(TimeSpan))
			{
				return true;
			}

			if (type.IsNullableType())
			{
				Type underlyingType = type.GetUnderlyingNullableTypeFast();
				return IsSimpleType(underlyingType);
			}

			return false;
		}

		public static IList<Type> GetBaseClasses(this Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			var types = new List<Type>();

			while (type.BaseType != null)
			{
				types.Add(type.BaseType);

				type = type.BaseType;
			}

			return types;
		}

		/// <summary>
		/// Slightly faster than Nullable.GetUnderlyingType, but gives false positives if the type is not nullable to begin with.
		/// </summary>
		public static Type GetUnderlyingNullableTypeFast(this Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			// For performance, do not check if it is a nullable type.
			return type.GetGenericArguments()[0];
		}
	}
}
