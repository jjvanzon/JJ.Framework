using System.Diagnostics;

namespace JJ.Demos.ReturnActions.Framework.Presentation
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public sealed class ActionParameterInfo
	{
		public string Name { get; set; }
		public string Value { get; set; }

		private string DebuggerDisplay => $"{Name}={Value}";
	}
}
