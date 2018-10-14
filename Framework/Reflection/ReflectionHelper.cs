using System;
using System.Linq;
using System.Reflection;

namespace JJ.Framework.Reflection
{
	public static class ReflectionHelper
	{
		public const BindingFlags BINDING_FLAGS_ALL =
			BindingFlags.Public |
			BindingFlags.NonPublic |
			BindingFlags.Instance |
			BindingFlags.Static |
			BindingFlags.FlattenHierarchy;

		// Other

		public static Type[] TypesFromObjects(params object[] objects)
		{
		    if (objects == null) throw new ArgumentNullException(nameof(objects));

		    Type[] types = objects.Select(x => x?.GetType() ?? typeof(object)).ToArray();

		    return types;
		}

		public static bool IsDefault(object value)
		{
			if (value == null)
			{
				// A little dirty, because you cannot really say that null is the default per se.
				return true;
			}

			Type type = value.GetType();
			object defaultValue = Activator.CreateInstance(type);

			return Equals(value, defaultValue);
		}

		/// <summary>
		/// A simple type can be a .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr
		/// the numeric types, their signed and unsigned variations, but also
		/// String, Guid, DateTime, TimeSpan and Enum types.
		/// If value is null, it is also considered a simple type.
		/// </summary>
		public static bool IsSimpleType(object value)
		{
			if (value == null)
			{
				// A little dirty, because null is not necessarily a simple type.
				return true;
			}

			Type type = value.GetType();

			return type.IsSimpleType();
		}

        /// <summary> A variation on the existing Type.CreateInstance, that takes a type name as a string, instead of a Type. </summary>
		public static object CreateInstance(string typeName, params object[] args)
		{
			Type type = Type.GetType(typeName);

			if (type == null)
			{
				throw new Exception($"Type '{typeName}' not found.");
			}

			object obj = Activator.CreateInstance(type, args);

			return obj;
		}
	}
}