using System.Windows.Forms;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.VectorGraphics.Models.Styling;
using Label = JJ.Framework.VectorGraphics.Models.Elements.Label;

namespace JJ.Framework.WinForms.TestForms
{
	internal partial class CurveTestForm : Form
	{
		private Curve _curve;

		public CurveTestForm()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			Text = GetType().FullName;

			var diagram = new Diagram();

			var label = new Label(diagram.Background)
			{
				Text = "Note: You can move around the points.",
				TextStyle = new TextStyle
				{
					Font = new Font
					{
						Size = 12,
						Bold = true
					}
				}
			};

			label.Position.X = 10;
			label.Position.Y = 10;
			label.Position.Width = 500;
			label.Position.Height = 100;

			_curve = new Curve(diagram.Background)
			{
				SegmentCount = 100,

				PointA = new Point(diagram.Background)
				{
					Visible = true
				},

				ControlPointA = new Point(diagram.Background),

				ControlPointB = new Point(diagram.Background),

				PointB = new Point(diagram.Background),

				LineStyle = new LineStyle
				{
					Width = 3
				}
			};

			_curve.Position.X = 100;
			_curve.Position.Y = 200;

			_curve.PointA.Position.X = 100;
			_curve.PointA.Position.Y = 100;

			_curve.ControlPointA.Position.X = 500;
			_curve.ControlPointA.Position.Y = 500;

			_curve.ControlPointB.Position.X = 100;
			_curve.ControlPointB.Position.Y = 600;

			_curve.PointB.Position.X = 1000;
			_curve.PointB.Position.Y = 600;

			var demoLineStyle = new LineStyle
			{
				Width = 2,
				DashStyleEnum = DashStyleEnum.Dashed,
				Color = ColorHelper.GetColor(80, 40, 120, 255)
			};

			// ReSharper disable once UnusedVariable
			var demoLine1 = new Line(diagram.Background)
			{
				PointA = _curve.PointA,
				PointB = _curve.ControlPointA,
				LineStyle = demoLineStyle
			};

			// ReSharper disable once UnusedVariable
			var demoLine2 = new Line(diagram.Background)
			{
				PointA = _curve.PointB,
				PointB = _curve.ControlPointB,
				LineStyle = demoLineStyle
			};

			Rectangle pointAGestureRegion = CreateGestureRegion(diagram, _curve.PointA);
			Rectangle controlPointAGestureRegion = CreateGestureRegion(diagram, _curve.ControlPointA);
			Rectangle controlPointBGestureRegion = CreateGestureRegion(diagram, _curve.ControlPointB);
			Rectangle pointBGestureRegion = CreateGestureRegion(diagram, _curve.PointB);

			var pointAMoveGesture = new MoveGesture();
			pointAGestureRegion.Gestures.Add(pointAMoveGesture);
			pointAMoveGesture.Moving += pointAGestureRegion_Moving;

			var controlPointAMoveGesture = new MoveGesture();
			controlPointAGestureRegion.Gestures.Add(controlPointAMoveGesture);
			controlPointAMoveGesture.Moving += controlPointAGestureRegion_Moving;

			var controlPointBMoveGesture = new MoveGesture();
			controlPointBGestureRegion.Gestures.Add(controlPointBMoveGesture);
			controlPointBMoveGesture.Moving += controlPointBGestureRegion_Moving;

			var pointBMoveGesture = new MoveGesture();
			pointBGestureRegion.Gestures.Add(pointBMoveGesture);
			pointBMoveGesture.Moving += pointBGestureRegion_Moving;

			diagramControl1.Diagram = diagram;
		}

		private Rectangle CreateGestureRegion(Diagram diagram, Point point)
		{
			var rectangle = new Rectangle(diagram.Background)
			{
				Visible = false
			};

			rectangle.Position.X = point.Position.X - 20;
			rectangle.Position.Y = point.Position.Y - 20;
			rectangle.Position.Width = 40;
			rectangle.Position.Height = 40;

			return rectangle;
		}

		private void pointAGestureRegion_Moving(object sender, VectorGraphics.EventArg.ElementEventArgs e)
		{
			_curve.PointA.Position.X = e.Element.Position.X + e.Element.Position.Width / 2f;
			_curve.PointA.Position.Y = e.Element.Position.Y + e.Element.Position.Height / 2f;

			//CorrectPointBounds(_curve.PointA);
		}

		private void controlPointAGestureRegion_Moving(object sender, VectorGraphics.EventArg.ElementEventArgs e)
		{
			_curve.ControlPointA.Position.X = e.Element.Position.X + e.Element.Position.Width / 2f;
			_curve.ControlPointA.Position.Y = e.Element.Position.Y + e.Element.Position.Height / 2f;

			//CorrectPointBounds(_curve.ControlPointA);
		}

		private void controlPointBGestureRegion_Moving(object sender, VectorGraphics.EventArg.ElementEventArgs e)
		{
			_curve.ControlPointB.Position.X = e.Element.Position.X + e.Element.Position.Width / 2f;
			_curve.ControlPointB.Position.Y = e.Element.Position.Y + e.Element.Position.Height / 2f;

			//CorrectPointBounds(_curve.ControlPointB);
		}

		private void pointBGestureRegion_Moving(object sender, VectorGraphics.EventArg.ElementEventArgs e)
		{
			_curve.PointB.Position.X = e.Element.Position.X + e.Element.Position.Width / 2f;
			_curve.PointB.Position.Y = e.Element.Position.Y + e.Element.Position.Height / 2f;

			//CorrectPointBounds(_curve.PointB);
		}

		//private void CorrectPointBounds(Point point)
		//{
		//	if (point.X < 0) point.X = 0;
		//	if (point.Y < 0) point.Y = 0;

		//	if (point.X > diagramControl1.Diagram.Background.Width) point.X = diagramControl1.Diagram.Background.Width;
		//	if (point.Y > diagramControl1.Diagram.Background.Height) point.Y = diagramControl1.Diagram.Background.Height;
		//}

		//private void CorrectRectangleBounds(Rectangle rectangle)
		//{
		//	if (rectangle.X < 0) rectangle.X = 0;
		//	if (rectangle.Y < 0) rectangle.Y = 0;

		//	if (rectangle.X + rectangle.Width > diagramControl1.Diagram.Background.Width) rectangle.X = diagramControl1.Diagram.Background.Width;
		//	if (rectangle.Y > diagramControl1.Diagram.Background.Height) rectangle.Y = diagramControl1.Diagram.Background.Height;
		//}
	}
}
