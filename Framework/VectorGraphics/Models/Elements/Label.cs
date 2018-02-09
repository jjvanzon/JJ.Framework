using System.Diagnostics;
using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public class Label : Element
	{
		//private readonly ITextMeasurer _textMeasurer;

		public Label()
		{
			Position = new RectanglePosition(this);
		}

		public override ElementPosition Position { get; }

		public string Text { get; set; }

		private TextStyle _textStyle = new TextStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public TextStyle TextStyle
		{
			[DebuggerHidden]
			get => _textStyle;
			set => _textStyle = value ?? throw new NullException(() => value);
		}

		/// <summary> Avoid calling repeatedly, for performance. </summary>
		//public (float width, float height) TextSize => _textMeasurer.GetTextSize(Text, TextStyle.Font);

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}
