using System.Diagnostics;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Rectangle : Element
	{
		public Rectangle()
		{
			Position = new RectanglePosition(this);
			Style = new RectangleStyle();
		}

		public override ElementPosition Position { get; }

		public RectangleStyle Style { get; }

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
