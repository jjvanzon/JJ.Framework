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
        public static SvgModel CreateTestSvgModel()
        {
            var model = new SvgModel();

            SvgElements.Rectangle rootRectangle = model.RootRectangle;

            SvgElements.Rectangle rectangle1 = CreateRectangle(model, 200, 10, "Block 1");

            SvgElements.Rectangle rectangle2 = CreateRectangle(model, 10, 200, "Block 2");

            //SvgElements.Point point1 = model.CreatePoint(rectangle1);
            SvgElements.Point point1 = new SvgElements.Point();
            model.Elements.Add(point1);
            point1.Parent = rectangle1;

            point1.X = 150;
            point1.Y = 30;
            point1.PointStyle = SvgHelper.InvisiblePointStyle;

            SvgElements.Point point2 = model.CreatePoint(rectangle2);
            point2.X = 150;
            point2.Y = 30;
            point2.PointStyle = SvgHelper.InvisiblePointStyle;

            SvgElements.Line line = model.CreateLine(rootRectangle);
            line.PointA = point1;
            line.PointB = point2;
            line.LineStyle = SvgHelper.DefaultLineStyle;

            rootRectangle.ZIndex = -2;
            line.ZIndex = -1;

            return model;
        }

        private static SvgElements.Rectangle CreateRectangle(SvgModel svgManager, float x, float y, string text)
        {
            SvgElements.Rectangle rectangle = svgManager.CreateRectangle(svgManager.RootRectangle);
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = 300;
            rectangle.Height = 60;
            rectangle.SetLineStyle(SvgHelper.DefaultLineStyle);

            SvgElements.Label label = svgManager.CreateLabel(rectangle);
            label.Width = 300;
            label.Height = 60;
            label.Text = text;
            label.TextStyle = SvgHelper.DefaultTextStyle;

            return rectangle;
        }
    }
}
