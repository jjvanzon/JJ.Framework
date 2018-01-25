using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Helpers
{
	public interface ITextMeasurer
	{
		WidthAndHeight GetTextSize(string text, Font font);
	}
}
