using System.Collections.Generic;

namespace JJ.Framework.Text
{
	public static class StringHelper
	{
		public static string Join(char separator, IEnumerable<object> values)
		{
			// TODO: Shame a low level version of string.Join is not available here,
			// that uses the fact, that separator is char.
			string separatorString = new string(new[] { separator });
			return string.Join(separatorString, values);
		}
	}
}
