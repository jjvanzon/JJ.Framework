using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.Framework.WinForms.TestForms.Helpers
{
	internal static class VectorGraphicsFactory
	{
		public static Diagram CreateTestVectorGraphicsModel()
		{
			var diagram = new Diagram();

			Rectangle rectangle1 = CreateRectangle(diagram, 200, 10, "Block 1");

			Rectangle rectangle2 = CreateRectangle(diagram, 10, 200, "Block 2");

			var point1 = new Point(rectangle1)
			{
				PointStyle = VectorGraphicsHelper.InvisiblePointStyle
			};
			point1.Position.X = 150;
			point1.Position.Y = 30;

			var point2 = new Point(rectangle2)
			{
				PointStyle = VectorGraphicsHelper.InvisiblePointStyle
			};
			point2.Position.X = 150;
			point2.Position.Y = 30;

			var line = new Line(diagram.Background)
			{
				PointA = point1,
				PointB = point2,
				LineStyle = VectorGraphicsHelper.DefaultLineStyle
			};

			line.ZIndex = -1;

			return diagram;
		}

		private static Rectangle CreateRectangle(Diagram diagram, float x, float y, string text)
		{
			var rectangle = new Rectangle(diagram.Background)
			{
				Style = { LineStyle = VectorGraphicsHelper.DefaultLineStyle }
			};
			rectangle.Position.X = x;
			rectangle.Position.Y = y;
			rectangle.Position.Width = 300;
			rectangle.Position.Height = 60;

			rectangle.Gestures.Add(new MoveGesture());

			var label = new Label(rectangle)
			{
				Text = text,
				TextStyle = VectorGraphicsHelper.DefaultTextStyle
			};
			label.Position.Width = 300;
			label.Position.Height = 60;

			return rectangle;
		}

		public static Rectangle CreateRectangle(Diagram diagram, string text)
		{
			var rectangle = new Rectangle(diagram.Background);

			rectangle.Position.X = VectorGraphicsHelper.SPACING;
			rectangle.Position.Y = VectorGraphicsHelper.SPACING;
			rectangle.Position.Width = VectorGraphicsHelper.BLOCK_WIDTH;
			rectangle.Position.Height = VectorGraphicsHelper.BLOCK_HEIGHT;
			rectangle.Style.BackStyle = VectorGraphicsHelper.BlueBackStyle;
			rectangle.Style.LineStyle = VectorGraphicsHelper.DefaultLineStyle;

			var label = new Label(rectangle)
			{
				Text = text,
				TextStyle = VectorGraphicsHelper.DefaultTextStyle
			};

			label.Position.X = 0;
			label.Position.Y = 0;
			label.Position.Width = VectorGraphicsHelper.BLOCK_WIDTH;
			label.Position.Height = VectorGraphicsHelper.BLOCK_HEIGHT;

			return rectangle;
		}
	}
}