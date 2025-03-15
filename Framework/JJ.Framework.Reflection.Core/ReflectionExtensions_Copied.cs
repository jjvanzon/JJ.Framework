using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Core
{
    public static class ReflectionExtensions_Copied
    {
        /// <summary> Returns a type's base type and its base type etc. </summary>
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
        /// Type.GetProperty returns null if the property does not exist.
        /// This method is a little safer than that and throws a clear exception if the property does not exist.
        /// </summary>
        public static PropertyInfo GetPropertyOrException(this Type type, string name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            PropertyInfo property = type.GetProperty(name);
            if (property == null) throw new Exception($"Property '{name}' not found on type '{type}'.");
            return property;
        }
    }
}
