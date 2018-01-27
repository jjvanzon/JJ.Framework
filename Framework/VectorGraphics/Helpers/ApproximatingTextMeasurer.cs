using System;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Helpers
{
	/// <summary> This implementation only approximates the text width and height. </summary>
	public class ApproximatingTextMeasurer : ITextMeasurer
	{
		/// <inheritdoc />
		public WidthAndHeight GetTextSize(string text, Font font)
		{
			if (font == null) throw new ArgumentNullException(nameof(font));

			float textWidth = GetTextWidth(text, font);
			float textHeight = GetTextHeight(font);

			return new WidthAndHeight(textWidth, textHeight);
		}

		/// <inheritdoc />
		public WidthAndHeight GetTextSize(string text, Font font, float lineWidth)
		{
			WidthAndHeight sizeWithoutWrapping = GetTextSize(text, font);

			int lineCount = (int)Math.Ceiling(sizeWithoutWrapping.Width / lineWidth);
			float lineHeight = GetTextHeight(font);
			float height = lineHeight * lineCount;

			return new WidthAndHeight(lineWidth, height);
		}

		/// <summary> Returns an approximate width of the string according to the specified font. </summary>
		private float GetTextWidth(string text, Font font, float averageAspectRatioOfCharacter = 0.85f)
		{
			if (string.IsNullOrEmpty(text))
			{
				return 0f;
			}

			float charHeight = font.Size;
			float charWidth = charHeight * averageAspectRatioOfCharacter;
			float textWidth = charWidth * text.Length;
			return textWidth;
		}

		private static float GetTextHeight(Font font) => font.Size * 1.8f;
	}
}