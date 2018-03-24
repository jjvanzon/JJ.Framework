using System.Diagnostics;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Styling
{
	public class TextStyle
	{
		public int Color { get; set; } = ColorHelper.Black;
		public bool Wrap { get; set; }

		/// <summary>
		/// If false, will draw remaining text outside if the rectangle, without cutting it off.
		/// If true, will cut off pieces of text that do not fit inside the rectangle.
		/// </summary>
		public bool Clip { get; set; }

		/// <summary> If true, will show '...' at the end if the text does not fit. </summary>
		public bool Abbreviate { get; set; }

		public HorizontalAlignmentEnum HorizontalAlignmentEnum { get; set; } = HorizontalAlignmentEnum.Left;
		public VerticalAlignmentEnum VerticalAlignmentEnum { get; set; } = VerticalAlignmentEnum.Top;

		private Font _font = new Font();

		/// <summary> not nullable, auto-instantiated </summary>
		public Font Font
		{
			[DebuggerHidden] get => _font;
			set => _font = value ?? throw new NullException(() => value);
		}
	}
}