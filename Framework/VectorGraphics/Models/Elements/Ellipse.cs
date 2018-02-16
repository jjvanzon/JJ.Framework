using System.Diagnostics;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Ellipse : Element
	{
		/// <inheritdoc />
		public Ellipse(Element parent) : base(parent) => Position = new RectanglePosition(this);

		public override ElementPosition Position { get; }

		public EllipseStyle Style { get; } = new EllipseStyle();

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
