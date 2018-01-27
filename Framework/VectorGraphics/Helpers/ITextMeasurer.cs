using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Helpers
{
	public interface ITextMeasurer
	{
		/// <summary> Returns the text width, without wrapping and the text height only depends on the font. </summary>
		WidthAndHeight GetTextSize(string text, Font font);

		/// <summary>
		/// The returned text width can actually differ from the width passwed along,
		/// since wrapping can actually make some of the right side space unused.
		/// The returned text height can be more than one line height,
		/// due to text wrapping.
		/// </summary>
		/// <param name="lineWidth">When wrapping text, the provided width influences the height of the measured text.</param>
		WidthAndHeight GetTextSize(string text, Font font, float lineWidth);
	}
}