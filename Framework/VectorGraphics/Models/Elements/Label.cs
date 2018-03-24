using System.Diagnostics;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Label : Element
	{
		/// <inheritdoc />
		public Label(Element parent) : base(parent) => Position = new RectanglePosition(this);

		public override ElementPosition Position { get; }

		public string Text { get; set; }

		private TextStyle _textStyle = new TextStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public TextStyle TextStyle
		{
			get => _textStyle;
			set => _textStyle = value ?? throw new NullException(() => value);
		}

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
