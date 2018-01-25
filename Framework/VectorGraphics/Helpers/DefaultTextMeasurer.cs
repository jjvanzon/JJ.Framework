using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Helpers
{
	public class DefaultTextMeasurer : ITextMeasurer
	{
		/// <summary> Returns an approximate width of the string according to the specified font. </summary>
		private float ApproximateTextWidth(string text, Font font, float averageAspectRatioOfCharacter = 0.85f)
		{
			if (font == null) throw new NullException(() => font);

			if (string.IsNullOrEmpty(text))
			{
				return 0f;
			}

			float charHeight = font.Size;
			float charWidth = charHeight * averageAspectRatioOfCharacter;
			float textWidth = charWidth * text.Length;
			return textWidth;
		}

		public WidthAndHeight GetTextSize(string text, Font font)
		{
			float approximateTextWidth = ApproximateTextWidth(text, font);
			float approximateTextHeight = font.Size * 1.8f;

			return new WidthAndHeight(approximateTextWidth, approximateTextHeight);
		}
	}
}