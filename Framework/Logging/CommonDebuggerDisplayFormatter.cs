using System;

namespace JJ.Framework.Logging
{
	public static class CommonDebuggerDisplayFormatter
	{
		public static string GetDebuggerDisplayWithIDAndName<T>(int id, string name)
		{
			string debuggerDisplay = GetDebuggerDisplayWithIDAndName(typeof(T), id, name);
			return debuggerDisplay;
		}

		public static string GetDebuggerDisplayWithIDAndName(Type type, int id, string name)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			string debuggerDisplay = $"{{{type.Name}}} {name} (ID = {id})";
			return debuggerDisplay;
		}

		/// <summary> Just returns "{TypeName}" without the type name having the namespace, like Visual Studio does by default. </summary>
		public static string GetDebuggerDisplay(object obj)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			string debuggerDisplay = $"{{{obj.GetType().Name}}}";
			return debuggerDisplay;
		}
	}
}
