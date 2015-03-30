using JJ.Framework.Presentation.Svg;
using JJ.Framework.Presentation.Svg.Elements;
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
        public static Diagram CreateTestSvgModel()
        {
            var diagram = new Diagram();

            SvgElements.Rectangle rootRectangle = diagram.RootRectangle;

            SvgElements.Rectangle rectangle1 = CreateRectangle(diagram, 200, 10, "Block 1");

            SvgElements.Rectangle rectangle2 = CreateRectangle(diagram, 10, 200, "Block 2");

            var point1 = new SvgElements.Point
            {
                Parent = rectangle1,
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };

            var point2 = new SvgElements.Point  
            {
                Parent = rectangle2,
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };

            var line = new SvgElements.Line
            {
                Diagram = diagram,
                PointA = point1,
                PointB = point2,
                LineStyle = SvgHelper.DefaultLineStyle
            };

            rootRectangle.ZIndex = -2;
            line.ZIndex = -1;

            return diagram;
        }

        private static SvgElements.Rectangle CreateRectangle(Diagram diagram, float x, float y, string text)
        {
            var rectangle = new SvgElements.Rectangle 
            {
                Diagram = diagram,
                X = x,
                Y = y,
                Width = 300,
                Height = 60
            };
            rectangle.SetLineStyle(SvgHelper.DefaultLineStyle);

            var label = new SvgElements.Label 
            {
                Parent = rectangle,
                Width = 300,
                Height = 60,
                Text = text,
                TextStyle = SvgHelper.DefaultTextStyle
            };

            return rectangle;
        }
    }
}
