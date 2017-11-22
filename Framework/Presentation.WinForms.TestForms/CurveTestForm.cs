using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using System.Windows.Forms;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using VectorGraphicsStyling = JJ.Framework.Presentation.VectorGraphics.Models.Styling;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.Helpers;
using JJ.Framework.Presentation.VectorGraphics.Gestures;

namespace JJ.Framework.Presentation.WinForms.TestForms
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
			Text = this.GetType().FullName;

			var diagram = new Diagram();

			var label = new VectorGraphicsElements.Label
			{
				Diagram = diagram,
				Parent = diagram.Background,
				Text = "Note: You can move around the points.",
				TextStyle = new VectorGraphicsStyling.TextStyle
				{
					Font = new VectorGraphicsStyling.Font
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

			_curve = new Curve
			{
				Diagram = diagram,
				Parent = diagram.Background,
				SegmentCount = 100,

				PointA = new Point
				{
					Diagram = diagram,
					Parent = diagram.Background,
					Visible = true
				},

				ControlPointA = new Point
				{
					Diagram = diagram,
					Parent = diagram.Background
				},

				ControlPointB = new Point
				{
					Diagram = diagram,
					Parent = diagram.Background
				},

				PointB = new Point
				{
					Diagram = diagram,
					Parent = diagram.Background
				},

				LineStyle = new VectorGraphicsStyling.LineStyle
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

			var demoLineStyle = new VectorGraphicsStyling.LineStyle
			{
				Width = 2,
				DashStyleEnum = DashStyleEnum.Dashed,
				Color = ColorHelper.GetColor(80, 40, 120, 255)
			};

			var demoLine1 = new Line
			{
				Diagram = diagram,
				Parent = diagram.Background,
				PointA = _curve.PointA,
				PointB = _curve.ControlPointA,
				LineStyle = demoLineStyle
			};

			var demoLine2 = new Line
			{
				Diagram = diagram,
				Parent = diagram.Background,
				PointA = _curve.PointB,
				PointB = _curve.ControlPointB,
				LineStyle = demoLineStyle
			};

			var pointAGestureRegion = CreateGestureRegion(diagram, _curve.PointA);
			var controlPointAGestureRegion = CreateGestureRegion(diagram, _curve.ControlPointA);
			var controlPointBGestureRegion = CreateGestureRegion(diagram, _curve.ControlPointB);
			var pointBGestureRegion = CreateGestureRegion(diagram, _curve.PointB);

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
			var rectangle = new Rectangle
			{
				Diagram = diagram,
				Parent = diagram.Background,
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
