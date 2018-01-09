using System.Diagnostics;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Line : Element
	{
		public Line() => Position = new LinePosition(this);

		public override ElementPosition Position { get; }

		/// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
		public Point PointA { get; set; }

		/// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
		public Point PointB { get; set; }

		private LineStyle _lineStyle = new LineStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public LineStyle LineStyle
		{
			[DebuggerHidden]
			get => _lineStyle;
			set => _lineStyle = value ?? throw new NullException(() => value);
		}

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
