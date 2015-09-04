using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Helpers;
using JJ.Framework.Presentation.Svg.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public static class SvgHelper
    {
        static SvgHelper()
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
