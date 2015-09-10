using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal partial class GesturesTestForm : Form
    {
        private const float BLOCK_WIDTH = 200;
        private const float BLOCK_HEIGHT = 60;
        private const float SPACING = 10;

        public GesturesTestForm()
        {
            InitializeComponent();

            Text = GetType().FullName;

            InitializeDiagramAndElements();
        }

        private void InitializeDiagramAndElements()
        {
            var diagram = new Diagram();

            var mouseDownGesture = new MouseDownGesture();
            mouseDownGesture.MouseDown += mouseDownGesture_MouseDown;

            var mouseMoveGesture = new MouseMoveGesture();
            mouseMoveGesture.MouseMove += mouseMoveGesture_MouseMove;

            var mouseUpGesture = new MouseUpGesture();
            mouseUpGesture.MouseUp += mouseUpGesture_MouseUp;

            var mouseLeaveGesture = new MouseLeaveGesture();
            mouseLeaveGesture.MouseLeave += mouseLeaveGesture_MouseLeave;

            var clickGesture = new ClickGesture();
            clickGesture.Click += clickGesture_Click;

            var dragGesture = new DragGesture();
            dragGesture.Dragging += dragGesture_Dragging;

            var dropGesture = new DropGesture(dragGesture);
            dropGesture.Dropped += dropGesture_Dropped;

            DoubleClickGesture doubleClickGesture = diagramControl1.CreateDoubleClickGesture();
            doubleClickGesture.DoubleClick += DoubleClickGesture_DoubleClick;

            VectorGraphicsElements.Rectangle rectangle;

            float currentY = SPACING;

            rectangle = CreateRectangle(diagram, "Double Click Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(doubleClickGesture);
            //rectangle.Gestures.Add(mouseLeaveGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Click Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(mouseDownGesture);
            rectangle.Gestures.Add(mouseMoveGesture);
            rectangle.Gestures.Add(mouseUpGesture);
            rectangle.Gestures.Add(mouseLeaveGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Click Me Too");
            rectangle.Y = currentY;
            //rectangle.Gestures.Add(mouseDownGesture);
            //rectangle.Gestures.Add(mouseMoveGesture);
            rectangle.Gestures.Add(clickGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Move Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(new MoveGesture());

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Drag & Drop Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(dropGesture);
            rectangle.Gestures.Add(dragGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Drop & Drop Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(dropGesture);
            rectangle.Gestures.Add(dragGesture);

            diagramControl1.Diagram = diagram;
        }

        private VectorGraphicsElements.Rectangle CreateRectangle(Diagram diagram, string text)
        {
            var rectangle = new VectorGraphicsElements.Rectangle()
            {
                Diagram = diagram,
                Parent = diagram.Background,
                X = SPACING,
                Y = SPACING,
                Width = BLOCK_WIDTH,
                Height = BLOCK_HEIGHT,
                BackStyle = VectorGraphicsHelper.BlueBackStyle,
                LineStyle = VectorGraphicsHelper.DefaultLineStyle
            };

            var label2 = new VectorGraphicsElements.Label
            {
                Diagram = diagram,
                Parent = rectangle,
                Text = text,
                X = 0,
                Y = 0,
                Width = BLOCK_WIDTH,
                Height = BLOCK_HEIGHT,
                TextStyle = VectorGraphicsHelper.DefaultTextStyle
            };

            return rectangle;
        }

        private void mouseDownGesture_MouseDown(object sender, VectorGraphics.EventArg.MouseEventArgs e)
        {
            TrySetElementText(e.Element, "MouseDown");
        }

        private void mouseMoveGesture_MouseMove(object sender, VectorGraphics.EventArg.MouseEventArgs e)
        {
            TrySetElementText(e.Element, "MouseMove");
        }

        private void mouseUpGesture_MouseUp(object sender, VectorGraphics.EventArg.MouseEventArgs e)
        {
            TrySetElementText(e.Element, "MouseUp");
        }

        private void mouseLeaveGesture_MouseLeave(object sender, VectorGraphics.EventArg.MouseEventArgs e)
        {
            TrySetElementText(e.Element, "MouseLeave");
        }

        private void clickGesture_Click(object sender, ElementEventArgs e)
        {
            TrySetElementText(e.Element, "Clicked");
        }

        private void dragGesture_Dragging(object sender, DraggingEventArgs e)
        {
            TrySetElementText(e.ElementBeingDragged, "Dragging");
        }

        private void dropGesture_Dropped(object sender, DroppedEventArgs e)
        {
            TrySetElementText(e.DraggedElement, "Dragged");
            TrySetElementText(e.DroppedOnElement, "Dropped On");
        }

        private void DoubleClickGesture_DoubleClick(object sender, ElementEventArgs e)
        {
            TrySetElementText(e.Element, "DoubleClicked");
        }

        private void TrySetElementText(Element element, string text)
        {
            var label = element as VectorGraphicsElements.Label;
            if (label == null)
            {
                var rectangle = element as VectorGraphicsElements.Rectangle;
                if (rectangle != null)
                {
                    label = rectangle.Children.OfType<VectorGraphicsElements.Label>().FirstOrDefault();
                }
            }

            if (label != null)
            {
                label.Text = text;
            }
        }
    }
}
