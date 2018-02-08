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

		public (float width, float height) GetTextSize(string text, Font font)
		{
			SizeF sizeF = _graphics.MeasureString(text, font.ToSystemDrawing(DpiHelper.DEFAULT_DPI));
			return (sizeF.Width, sizeF.Height);
		}

		public (float width, float height) GetTextSize(string text, Font font, float lineWidth)
		{
			SizeF sizeF = _graphics.MeasureString(text, font.ToSystemDrawing(DpiHelper.DEFAULT_DPI), (int)lineWidth);
			return (sizeF.Width, sizeF.Height);
		}
	}
}
