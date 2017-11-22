using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Styling
{
	public class PointStyle
	{
		public PointStyle()
		{
			Visible = true;
			Width = 1;
			Color = ColorHelper.Black;
		}

		public bool Visible { get; set; }
		public int Color { get; set; }
		public float Width { get; set; }
	}
}
