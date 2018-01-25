using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Helpers;

namespace JJ.Framework.VectorGraphics.Models.Styling
{
	public class LineStyle
	{
		public bool Visible { get; set; } = true;
		public float Width { get; set; } = 1;
		public int Color { get; set; } = ColorHelper.Black;
		public DashStyleEnum DashStyleEnum { get; set; } = DashStyleEnum.Solid;
	}
}