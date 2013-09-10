using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Reflection
{
    public static class ReflectionHelper
    {
        public static Type GetType(string typeString, params object[] arguments)
        {
            if (String.IsNullOrEmpty(typeString)) throw new ArgumentNullException("typeString");
            string[] split = typeString.Split(',');
            if (split.Length != 2) throw new Exception("typeString should only contain one comma.");
            string assemblyName = split[1];
            string typeName = split[0];
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(typeName);
            if (type == null)
            {
                throw new Exception(String.Format("Type '{0}' not found in assembly '{1}'.", typeName, assemblyName));
            }
            return type;
        }
    }
}
