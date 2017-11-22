using System;
using System.Collections.Generic;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
	internal static class FuncCache<T>
	{
		private static Dictionary<object, Func<T>> Items = new Dictionary<object, Func<T>>();

		public static bool ContainsKey(object key)
		{
			return Items.ContainsKey(key);
		}

		public static Func<T> GetItem(object key)
		{
			return Items[key];
		}

		public static void SetItem(object key, Func<T> value)
		{
			Items[key] = value;
		}
	}
}
