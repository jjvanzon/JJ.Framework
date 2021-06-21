using System;
using System.Reflection;
using JetBrains.Annotations;
// ReSharper disable CheckNamespace

namespace JJ.Framework.Reflection
{
    [Obsolete("Use ReflectionCache instead.", true)]
    [PublicAPI]
    public static class StaticReflectionCache
    {
        // Field

        [Obsolete("Use ReflectionCache instead.", true)]
        public static FieldInfo GetField(Type type, string name)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        [Obsolete("Use ReflectionCache instead.", true)]
        public static FieldInfo TryGetField(Type type, string name)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        // Fields

        [Obsolete("Use ReflectionCache instead.", true)]
        public static FieldInfo[] GetFields(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        // Property

        [Obsolete("Use ReflectionCache instead.", true)]
        public static PropertyInfo GetProperty(Type type, string name)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        [Obsolete("Use ReflectionCache instead.", true)]
        public static PropertyInfo TryGetProperty(Type type, string name)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        // Properties

        [Obsolete("Use ReflectionCache instead.", true)]
        public static PropertyInfo[] GetProperties(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        // Indexers

        [Obsolete("Use ReflectionCache instead.", true)]
        public static PropertyInfo GetIndexer(Type type, params Type[] parameterTypes)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        [Obsolete("Use ReflectionCache instead.", true)]
        public static PropertyInfo TryGetIndexer(Type type, params Type[] parameterTypes)
            => throw new NotSupportedException("Use ReflectionCache instead.");
 
        // Method

        [Obsolete("Use ReflectionCache instead.", true)]
        public static MethodInfo GetMethod(Type type, string name, params Type[] parameterTypes)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        [Obsolete("Use ReflectionCache instead.", true)]
        public static MethodInfo TryGetMethod(Type type, string name, params Type[] parameterTypes)
            => throw new NotSupportedException("Use ReflectionCache instead.");

        // Methods

        [Obsolete("Use ReflectionCache instead (instantiating it with BindingFlags.Public | BindingFlags.Instance).", true)]
        public static MethodInfo[] GetMethods(Type type, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
            => throw new NotSupportedException("Use ReflectionCache instead (instantiating ReflectionCache with BindingFlags.Public | BindingFlags.Instance).");
    }
}
