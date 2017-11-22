using System;

namespace JJ.Framework.Common
{
	public static class KeyHelper
	{
		private static readonly string _separator = Guid.NewGuid().ToString();

		/// <summary>
		/// Turns several objects into a single string key.
		/// Only works if the objects' ToString() methods return something unique.
		/// </summary>
		public static string CreateKey(object[] values)
		{
			if (values == null) throw new ArgumentNullException(nameof(values));

			string[] strings = new string[values.Length];

			for (int i = 0; i < strings.Length; i++)
			{
				strings[i] = Convert.ToString(values[i]);
			}

			string key = string.Join(_separator, strings);

			return key;
		}
	}
}
