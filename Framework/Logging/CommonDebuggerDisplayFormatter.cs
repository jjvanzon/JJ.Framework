using System;

namespace JJ.Framework.Logging
{
	public static class CommonDebuggerDisplayFormatter
	{
		public static string GetDebuggDisplayWithIDAndName<T>(int id, string name)
		{
			string debuggerDisplay = GetDebuggDisplayWithIDAndName(typeof(T), id, name);
			return debuggerDisplay;
		}

		public static string GetDebuggDisplayWithIDAndName(Type type, int id, string name)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			string debuggerDisplay = $"{{{type.Name}}} {name} (ID = {id})";
			return debuggerDisplay;
		}
	}
}
