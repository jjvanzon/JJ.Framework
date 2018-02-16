using System;
using System.Diagnostics;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Line : Element
	{
		/// <inheritdoc />
		public Line(Element parent) : base(parent) => Position = new LinePosition(this);

		public override ElementPosition Position { get; }

		/// <summary>
		/// Coordinates of the point are related to the Point's parent. 
		/// Nullable while building up the model.
		/// Not nullable once its being drawn.
		/// </summary>
		public Point PointA { get; set; }

		/// <summary>
		/// Coordinates of the point are related to the Point's parent. 
		/// Nullable while building up the model.
		/// Not nullable once its being drawn.
		/// </summary>
		public Point PointB { get; set; }

		private LineStyle _lineStyle = new LineStyle();

		/// <summary> not nullable, auto-instantiated </summary>
		public LineStyle LineStyle
		{
			get => _lineStyle;
			set => _lineStyle = value ?? throw new ArgumentNullException(nameof(LineStyle));
		}

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}