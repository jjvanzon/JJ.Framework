using System;
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
            var types = new Type[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                object parameter = objects[i];

                if (parameter != null)
                {
                    types[i] = parameter.GetType();
                }
                else
                {
                    types[i] = typeof(object);
                }
            }
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