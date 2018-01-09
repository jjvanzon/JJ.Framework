using System.Diagnostics;
using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Point : Element
	{
		public Point() => Position = new PointPosition(this);

		public override ElementPosition Position { get; }

		private PointStyle _pointStyle = new PointStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public PointStyle PointStyle
		{
			[DebuggerHidden]
			get => _pointStyle;
			set => _pointStyle = value ?? throw new NullException(() => value);
		}

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}