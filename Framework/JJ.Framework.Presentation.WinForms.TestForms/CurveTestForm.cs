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
                Parent = diagram.Canvas,
                Text = "Note: You can move around the points.",
                X = 10,
                Y = 10,
                Width = 500,
                Height = 100,
                TextStyle = new VectorGraphicsStyling.TextStyle
                {
                    Font = new VectorGraphicsStyling.Font
                    {
                        Size = 12,
                        Bold = true
                    }
                }
            };

            _curve = new VectorGraphicsElements.Curve
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
                X = 100,
                Y = 200,
                LineCount = 100,

                PointA = new VectorGraphicsElements.Point
                {
                    Diagram = diagram,
                    Parent = diagram.Canvas,
                    X = 100,
                    Y = 100,
                    Visible = true
                },

                ControlPointA = new VectorGraphicsElements.Point
                {
                    Diagram = diagram,
                    Parent = diagram.Canvas,
                    X = 500,
                    Y = 500,
                    Visible = true
                },

                ControlPointB = new VectorGraphicsElements.Point
                {
                    Diagram = diagram,
                    Parent = diagram.Canvas,
                    X = 100,
                    Y = 600,
                    Visible = true
                },

                PointB = new VectorGraphicsElements.Point
                {
                    Diagram = diagram,
                    Parent = diagram.Canvas,
                    X = 1000,
                    Y = 600,
                    Visible = true
                },

                LineStyle = new VectorGraphicsStyling.LineStyle
                {
                    Width = 3
                }
            };

            var demoLineStyle = new VectorGraphicsStyling.LineStyle
            {
                Width = 2,
                DashStyleEnum = DashStyleEnum.Dashed,
                Color = ColorHelper.GetColor(80, 40, 120, 255)
            };

            var demoLine1 = new VectorGraphicsElements.Line
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
                PointA = _curve.PointA,
                PointB = _curve.ControlPointA,
                LineStyle = demoLineStyle
            };

            var demoLine2 = new VectorGraphicsElements.Line
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
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
                Parent = diagram.Canvas,
                Visible = false,
                X = point.X - 20,
                Y = point.Y - 20,
                Width = 40,
                Height = 40
            };

            return rectangle;
        }

        private void pointAGestureRegion_Moving(object sender, VectorGraphics.EventArg.MoveEventArgs e)
        {
            _curve.PointA.X = e.Element.X + e.Element.Width / 2f;
            _curve.PointA.Y = e.Element.Y + e.Element.Height / 2f;

            //CorrectPointBounds(_curve.PointA);
        }

        private void controlPointAGestureRegion_Moving(object sender, VectorGraphics.EventArg.MoveEventArgs e)
        {
            _curve.ControlPointA.X = e.Element.X + e.Element.Width / 2f;
            _curve.ControlPointA.Y = e.Element.Y + e.Element.Height / 2f;

            //CorrectPointBounds(_curve.ControlPointA);
        }

        private void controlPointBGestureRegion_Moving(object sender, VectorGraphics.EventArg.MoveEventArgs e)
        {
            _curve.ControlPointB.X = e.Element.X + e.Element.Width / 2f;
            _curve.ControlPointB.Y = e.Element.Y + e.Element.Height / 2f;

            //CorrectPointBounds(_curve.ControlPointB);
        }

        private void pointBGestureRegion_Moving(object sender, VectorGraphics.EventArg.MoveEventArgs e)
        {
            _curve.PointB.X = e.Element.X + e.Element.Width / 2f;
            _curve.PointB.Y = e.Element.Y + e.Element.Height / 2f;

            //CorrectPointBounds(_curve.PointB);
        }

        //private void CorrectPointBounds(Point point)
        //{
        //    if (point.X < 0) point.X = 0;
        //    if (point.Y < 0) point.Y = 0;

        //    if (point.X > diagramControl1.Diagram.Canvas.Width) point.X = diagramControl1.Diagram.Canvas.Width;
        //    if (point.Y > diagramControl1.Diagram.Canvas.Height) point.Y = diagramControl1.Diagram.Canvas.Height;
        //}

        //private void CorrectRectangleBounds(Rectangle rectangle)
        //{
        //    if (rectangle.X < 0) rectangle.X = 0;
        //    if (rectangle.Y < 0) rectangle.Y = 0;

        //    if (rectangle.X + rectangle.Width > diagramControl1.Diagram.Canvas.Width) rectangle.X = diagramControl1.Diagram.Canvas.Width;
        //    if (rectangle.Y > diagramControl1.Diagram.Canvas.Height) rectangle.Y = diagramControl1.Diagram.Canvas.Height;
        //}
    }
}
