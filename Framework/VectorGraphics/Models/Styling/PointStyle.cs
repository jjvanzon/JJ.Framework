using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Styling
{
	public class PointStyle : StyleWithVisibleBase
	{
		public int Color { get; set; } = ColorHelper.Black;
		public float Width { get; set; } = 1;
	}
}
