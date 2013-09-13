using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Common;

namespace JJ.Framework.Reflection
{
    public static class ReflectionHelper
    {
        public static string GetAssemblyName(Assembly assembly)
        {
            return assembly.ManifestModule.Name.CutRight(".exe").CutRight(".dll");
        }
    }
}
