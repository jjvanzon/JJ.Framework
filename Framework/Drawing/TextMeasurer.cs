using System;
using System.Drawing;
using JJ.Framework.VectorGraphics.Helpers;
using Font = JJ.Framework.VectorGraphics.Models.Styling.Font;

namespace JJ.Framework.Drawing
{
	public class TextMeasurer : ITextMeasurer
	{
		private readonly Graphics _graphics;

		public TextMeasurer(Graphics graphics)
		{
			_graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
		}

		public WidthAndHeight GetTextSize(string text, Font font)
		{
			SizeF sizeF = _graphics.MeasureString(text, font.ToSystemDrawing(DpiHelper.DEFAULT_DPI));
			return new WidthAndHeight(sizeF.Width, sizeF.Height);
		}
	}
}
