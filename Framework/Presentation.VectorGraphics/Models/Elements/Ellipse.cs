using System.Diagnostics;
using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Ellipse : Element
	{
		public Ellipse()
		{
			Position = new RectanglePosition(this);
			Style = new EllipseStyle();
		}

		public override ElementPosition Position { get; }

		public EllipseStyle Style { get; }

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
