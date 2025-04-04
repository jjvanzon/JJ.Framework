using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Core
{
    public static class ReflectionHelperLegacy
    {
        public static bool IsProperty(this MethodBase method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            
            bool isProperty = method.Name.StartsWith("get_") ||
                              method.Name.StartsWith("set_");
            
            return isProperty;
        }
    }
}