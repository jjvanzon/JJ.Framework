using System.Diagnostics;
using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Point : Element
	{
		/// <inheritdoc />
		public Point(Element parent) : base(parent) => Position = new PointPosition(this);

		public override ElementPosition Position { get; }

		private PointStyle _pointStyle = new PointStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public PointStyle PointStyle
		{
			get => _pointStyle;
			set => _pointStyle = value ?? throw new NullException(() => value);
		}

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}