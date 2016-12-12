using JJ.Framework.Reflection;
using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Data.Xml.Internal
{
    internal static class ReflectionCacheWrapper
    {
        private static ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

        public static ReflectionCache ReflectionCache { get { return _reflectionCache; } }
    }
}
