using System.Collections.Generic;

namespace JJ.Framework.Reflection
{
	public class MethodCallInfo
	{
		internal MethodCallInfo(string name) => Name = name;

		public string Name { get; }

		/// <summary> auto-instantiated </summary>
		public IList<MethodCallParameterInfo> Parameters { get; } = new List<MethodCallParameterInfo>();
	}
}
