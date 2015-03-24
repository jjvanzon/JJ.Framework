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
        public static SvgElements.Rectangle CreateTestSvgModel()
        {
            var rootRectangle = new SvgElements.Rectangle();

            SvgElements.Rectangle rectangle1 = CreateRectangle(200, 10, "Block 1");

            SvgElements.Rectangle rectangle2 = CreateRectangle(10, 200, "Block 2");

            var point1 = new SvgElements.Point
            {
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };
            rectangle1.Children.Add(point1);

            var point2 = new SvgElements.Point
            {
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };
            rectangle2.Children.Add(point2);

            var line = new SvgElements.Line
            {
                PointA = point1,
                PointB = point2,
                LineStyle = SvgHelper.DefaultLineStyle
            };

            rootRectangle.Children.Add(line);
            rootRectangle.Children.Add(rectangle1);
            rootRectangle.Children.Add(rectangle2);

            rootRectangle.ZIndex = -2;
            line.ZIndex = -1;

            return rootRectangle;
        }

        private static SvgElements.Rectangle CreateRectangle(float x, float y, string text)
        {
            var rectangle = new SvgElements.Rectangle
            {
                X = x,
                Y = y,
                Width = 300,
                Height = 60,
                Children = new List<SvgElements.ElementBase>
                {
                    new SvgElements.Label
                    {
                        Rectangle = new SvgElements.Rectangle { Width = 300, Height = 60 },
                        Text = text,
                        TextStyle = SvgHelper.DefaultTextStyle
                    }
                }
            };

            rectangle.SetLineStyle(SvgHelper.DefaultLineStyle);

            return rectangle;
        }
    }
}
