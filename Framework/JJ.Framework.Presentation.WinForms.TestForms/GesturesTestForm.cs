using JJ.Framework.Presentation.Svg;
using JJ.Framework.Presentation.Svg.EventArg;
using JJ.Framework.Presentation.Svg.Gestures;
using JJ.Framework.Presentation.Svg.Models.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using SvgStyling = JJ.Framework.Presentation.Svg.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class GesturesTestForm : Form
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

            MouseDownGesture mouseDownGesture = new MouseDownGesture();
            mouseDownGesture.MouseDown += mouseDownGesture_MouseDown;

            MouseMoveGesture mouseMoveGesture = new MouseMoveGesture();
            mouseMoveGesture.MouseMove += mouseMoveGesture_MouseMove;

            MouseUpGesture mouseUpGesture = new MouseUpGesture();
            mouseUpGesture.MouseUp += mouseUpGesture_MouseUp;

            ClickGesture clickGesture = new ClickGesture();
            clickGesture.Click += clickGesture_Click;

            DragGesture dragGesture = new DragGesture();
            dragGesture.Dragging += dragGesture_Dragging;

            DropGesture dropGesture = new DropGesture(dragGesture);
            dropGesture.Dropped += dropGesture_Dropped;

            SvgElements.Rectangle rectangle;

            float currentY = SPACING;

            rectangle = CreateRectangle(diagram, "Click Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(mouseDownGesture);
            rectangle.Gestures.Add(mouseMoveGesture);
            rectangle.Gestures.Add(mouseUpGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Click Me Too");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(mouseDownGesture);
            rectangle.Gestures.Add(mouseMoveGesture);
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

        private SvgElements.Rectangle CreateRectangle(Diagram diagram, string text)
        {
            var rectangle = new SvgElements.Rectangle()
            {
                Diagram = diagram,
                Parent = diagram.Canvas,
                X = SPACING,
                Y = SPACING,
                Width = BLOCK_WIDTH,
                Height = BLOCK_HEIGHT,
                BackStyle = SvgHelper.BlueBackStyle,
                LineStyle = SvgHelper.DefaultLineStyle
            };

            var label2 = new SvgElements.Label
            {
                Diagram = diagram,
                Parent = rectangle,
                Text = text,
                X = 0,
                Y = 0,
                Width = BLOCK_WIDTH,
                Height = BLOCK_HEIGHT,
                TextStyle = SvgHelper.DefaultTextStyle
            };

            return rectangle;
        }

        private void mouseDownGesture_MouseDown(object sender, Svg.EventArg.MouseEventArgs e)
        {
            TrySetElementText(e.Element, "MouseDown");
        }

        private void mouseMoveGesture_MouseMove(object sender, Svg.EventArg.MouseEventArgs e)
        {
            TrySetElementText(e.Element, "MouseMove");
        }

        private void mouseUpGesture_MouseUp(object sender, Svg.EventArg.MouseEventArgs e)
        {
            TrySetElementText(e.Element, "MouseUp");
        }

        private void clickGesture_Click(object sender, ClickEventArgs e)
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

        private void TrySetElementText(Element element, string text)
        {
            var label = element as SvgElements.Label;
            if (label == null)
            {
                var rectangle = element as SvgElements.Rectangle;
                if (rectangle != null)
                {
                    label = rectangle.Children.OfType<SvgElements.Label>().First();
                }
            }

            if (label != null)
            {
                label.Text = text;
            }
        }
    }
}
