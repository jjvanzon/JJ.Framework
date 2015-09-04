using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Models.Elements;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal static class SvgFactory
    {
        public static Diagram CreateTestSvgModel()
        {
            var diagram = new Diagram();

            SvgElements.Rectangle canvas = diagram.Canvas;

            SvgElements.Rectangle rectangle1 = CreateRectangle(diagram, 200, 10, "Block 1");

            SvgElements.Rectangle rectangle2 = CreateRectangle(diagram, 10, 200, "Block 2");

            var point1 = new SvgElements.Point
            {
                Diagram = diagram,
                Parent = rectangle1,
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };

            var point2 = new SvgElements.Point  
            {
                Diagram = diagram,
                Parent = rectangle2,
                X = 150,
                Y = 30,
                PointStyle = SvgHelper.InvisiblePointStyle
            };

            var line = new SvgElements.Line
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
                PointA = point1,
                PointB = point2,
                LineStyle = SvgHelper.DefaultLineStyle
            };

            line.ZIndex = -1;

            return diagram;
        }

        private static SvgElements.Rectangle CreateRectangle(Diagram diagram, float x, float y, string text)
        {
            var rectangle = new SvgElements.Rectangle(new MoveGesture())
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
                X = x,
                Y = y,
                Width = 300,
                Height = 60,
                LineStyle = SvgHelper.DefaultLineStyle
            };

            var label = new SvgElements.Label 
            {
                Diagram = diagram,
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
