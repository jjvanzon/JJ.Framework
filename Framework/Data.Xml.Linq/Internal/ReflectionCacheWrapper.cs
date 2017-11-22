using JJ.Framework.Reflection;
using System.Reflection;

namespace JJ.Framework.Data.Xml.Linq.Internal
{
	internal static class ReflectionCacheWrapper
	{
		private static ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

		public static ReflectionCache ReflectionCache { get { return _reflectionCache; } }
	}
}
