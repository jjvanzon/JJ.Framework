using System.Collections.Generic;

namespace JJ.Framework.Text
{
	public static class StringHelper
	{
        /// <summary> Alternative for String.Join, that takes a char as a separator. </summary>
		public static string Join(char separator, IEnumerable<object> values)
		{
			string separatorString = new string(new[] { separator });
			return string.Join(separatorString, values);
		}
	}
}
