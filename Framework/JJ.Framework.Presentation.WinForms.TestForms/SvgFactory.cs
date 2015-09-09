using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal static class VectorGraphicsFactory
    {
        public static Diagram CreateTestVectorGraphicsModel()
        {
            var diagram = new Diagram();

            VectorGraphicsElements.Rectangle canvas = diagram.Canvas;

            VectorGraphicsElements.Rectangle rectangle1 = CreateRectangle(diagram, 200, 10, "Block 1");

            VectorGraphicsElements.Rectangle rectangle2 = CreateRectangle(diagram, 10, 200, "Block 2");

            var point1 = new VectorGraphicsElements.Point
            {
                Diagram = diagram,
                Parent = rectangle1,
                X = 150,
                Y = 30,
                PointStyle = VectorGraphicsHelper.InvisiblePointStyle
            };

            var point2 = new VectorGraphicsElements.Point  
            {
                Diagram = diagram,
                Parent = rectangle2,
                X = 150,
                Y = 30,
                PointStyle = VectorGraphicsHelper.InvisiblePointStyle
            };

            var line = new VectorGraphicsElements.Line
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
                PointA = point1,
                PointB = point2,
                LineStyle = VectorGraphicsHelper.DefaultLineStyle
            };

            line.ZIndex = -1;

            return diagram;
        }

        private static VectorGraphicsElements.Rectangle CreateRectangle(Diagram diagram, float x, float y, string text)
        {
            var rectangle = new VectorGraphicsElements.Rectangle(new MoveGesture())
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
                X = x,
                Y = y,
                Width = 300,
                Height = 60,
                LineStyle = VectorGraphicsHelper.DefaultLineStyle
            };

            var label = new VectorGraphicsElements.Label 
            {
                Diagram = diagram,
                Parent = rectangle,
                Width = 300,
                Height = 60,
                Text = text,
                TextStyle = VectorGraphicsHelper.DefaultTextStyle
            };

            return rectangle;
        }
    }
}
