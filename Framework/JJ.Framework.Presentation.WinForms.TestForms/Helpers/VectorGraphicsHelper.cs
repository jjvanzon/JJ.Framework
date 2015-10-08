using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Presentation.VectorGraphics.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms.Helpers
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

        private static Font DefaultFont { get; set; }
        public static LineStyle DefaultLineStyle { get; private set; }
        public static TextStyle DefaultTextStyle { get; private set; }
        public static PointStyle InvisiblePointStyle { get; private set; }
        public static BackStyle BlueBackStyle { get; private set; }
    }
}
