using System;
using System.Collections.Generic;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
	internal static class FuncCache<T>
	{
		private static Dictionary<object, Func<T>> Items = new Dictionary<object, Func<T>>();

		public static bool ContainsKey(object key) => Items.ContainsKey(key);

	    public static Func<T> GetItem(object key) => Items[key];

	    public static void SetItem(object key, Func<T> value) => Items[key] = value;
	}
}
