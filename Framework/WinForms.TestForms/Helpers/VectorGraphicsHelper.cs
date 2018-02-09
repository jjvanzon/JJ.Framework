using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.WinForms.TestForms.Helpers
{
	public static class VectorGraphicsHelper
	{
		public const float BLOCK_WIDTH = 200;
		public const float BLOCK_HEIGHT = 60;
		public const float SPACING = 10;

		private static Font DefaultFont { get; } = new Font
		{
			Bold = true,
			Name = "Verdana",
			Size = 13
		};

		public static LineStyle DefaultLineStyle { get; } = new LineStyle
		{
			Width = 2
		};

		public static TextStyle DefaultTextStyle { get; } = new TextStyle
		{
			HorizontalAlignmentEnum = HorizontalAlignmentEnum.Center,
			VerticalAlignmentEnum = VerticalAlignmentEnum.Center,
			Font = DefaultFont,
			Clip = true
		};

		public static PointStyle InvisiblePointStyle { get; } = new PointStyle
		{
			Visible = false
		};

		public static BackStyle BlueBackStyle { get; } = new BackStyle
		{
			Visible = true,
			Color = ColorHelper.GetColor(64, 128, 255)
		};
	}
}
