using System;
using System.Diagnostics;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Rectangle : Element
	{
		/// <inheritdoc />
		public Rectangle(Element parent) : base(parent) => Position = new RectanglePosition(this);

		/// <inheritdoc />
		internal Rectangle(Diagram diagram) : base(diagram) => Position = new RectanglePosition(this);

		public override ElementPosition Position { get; }

		private RectangleStyle _style = new RectangleStyle();

		/// <summary> not nullable, auto-instantiated </summary>
		public RectangleStyle Style
		{
			get => _style;
			set => _style = value ?? throw new ArgumentNullException(nameof(Style));
		}

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}