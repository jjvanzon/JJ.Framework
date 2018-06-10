using System.Reflection;
using JJ.Framework.Reflection;

namespace JJ.Framework.Data.Xml.Internal
{
    internal static class ReflectionCacheWrapper
    {
        public static ReflectionCache ReflectionCache { get; } = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);
    }
}