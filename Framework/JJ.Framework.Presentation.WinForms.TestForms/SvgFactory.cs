using JJ.Framework.Presentation.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal static class SvgFactory
    {
        public static SvgManager CreateTestSvgModel()
        {
            var svgManager = new SvgManager();

            SvgElements.Rectangle rootRectangle = svgManager.RootRectangle;

            SvgElements.Rectangle rectangle1 = CreateRectangle(svgManager, 200, 10, "Block 1");

            SvgElements.Rectangle rectangle2 = CreateRectangle(svgManager, 10, 200, "Block 2");

            SvgElements.Point point1 = svgManager.CreatePoint(rectangle1);
            point1.X = 150;
            point1.Y = 30;
            point1.PointStyle = SvgHelper.InvisiblePointStyle;

            SvgElements.Point point2 = svgManager.CreatePoint(rectangle2);
            point2.X = 150;
            point2.Y = 30;
            point2.PointStyle = SvgHelper.InvisiblePointStyle;

            SvgElements.Line line = svgManager.CreateLine(rootRectangle);
            line.PointA = point1;
            line.PointB = point2;
            line.LineStyle = SvgHelper.DefaultLineStyle;

            rootRectangle.ZIndex = -2;
            line.ZIndex = -1;

            return svgManager;
        }

        private static SvgElements.Rectangle CreateRectangle(SvgManager svgManager, float x, float y, string text)
        {
            SvgElements.Rectangle rectangle = svgManager.CreateRectangle(svgManager.RootRectangle);
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = 300;
            rectangle.Height = 60;
            rectangle.SetLineStyle(SvgHelper.DefaultLineStyle);

            SvgElements.Label label = svgManager.CreateLabel(rectangle);
            label.Rectangle.Width = 300;
            label.Rectangle.Height = 60;
            label.Text = text;
            label.TextStyle = SvgHelper.DefaultTextStyle;

            return rectangle;
        }
    }
}
