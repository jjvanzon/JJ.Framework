using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms.Helpers
{
    internal static class VectorGraphicsFactory
    {
        public static Diagram CreateTestVectorGraphicsModel()
        {
            var diagram = new Diagram();

            VectorGraphicsElements.Rectangle background = diagram.Background;

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
                Parent = diagram.Background,
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
                Parent = diagram.Background,
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

        public static VectorGraphicsElements.Rectangle CreateRectangle(Diagram diagram, string text)
        {
            var rectangle = new VectorGraphicsElements.Rectangle()
            {
                Diagram = diagram,
                Parent = diagram.Background,
                X = VectorGraphicsHelper.SPACING,
                Y = VectorGraphicsHelper.SPACING,
                Width = VectorGraphicsHelper.BLOCK_WIDTH,
                Height = VectorGraphicsHelper.BLOCK_HEIGHT,
                BackStyle = VectorGraphicsHelper.BlueBackStyle,
                LineStyle = VectorGraphicsHelper.DefaultLineStyle
            };

            var label = new VectorGraphicsElements.Label
            {
                Diagram = diagram,
                Parent = rectangle,
                Text = text,
                X = 0,
                Y = 0,
                Width = VectorGraphicsHelper.BLOCK_WIDTH,
                Height = VectorGraphicsHelper.BLOCK_HEIGHT,
                TextStyle = VectorGraphicsHelper.DefaultTextStyle
            };

            return rectangle;
        }

    }
}
