﻿using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.WinForms.TestForms.Helpers
{
	public static class VectorGraphicsHelper
	{
		public const float BLOCK_WIDTH = 200;
		public const float BLOCK_HEIGHT = 60;
		public const float SPACING = 10;

		static VectorGraphicsHelper()
		{
			DefaultFont = new Font
			{
				Bold = true,
				Name = "Verdana",
				Size = 13
			};

			DefaultLineStyle = new LineStyle
			{
				Width = 2
			};

			DefaultTextStyle = new TextStyle
			{
				HorizontalAlignmentEnum = HorizontalAlignmentEnum.Center,
				VerticalAlignmentEnum = VerticalAlignmentEnum.Center,
				Font = DefaultFont
			};

			InvisiblePointStyle = new PointStyle
			{
				Visible = false
			};

			BlueBackStyle = new BackStyle
			{
				Visible = true,
				Color = ColorHelper.GetColor(64, 128, 255)
			};
		}

		private static Font DefaultFont { get; }
		public static LineStyle DefaultLineStyle { get; }
		public static TextStyle DefaultTextStyle { get; }
		public static PointStyle InvisiblePointStyle { get; }
		public static BackStyle BlueBackStyle { get; }
	}
}