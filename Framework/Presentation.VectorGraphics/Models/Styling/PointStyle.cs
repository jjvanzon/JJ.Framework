using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Styling
{
	public class PointStyle
	{
		public bool Visible { get; set; } = true;
		public int Color { get; set; } = ColorHelper.Black;
		public float Width { get; set; } = 1;
	}
}
