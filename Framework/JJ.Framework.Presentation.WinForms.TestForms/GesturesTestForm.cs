using JJ.Framework.Presentation.Svg;
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

            DragDropGesture dragDropGesture = new DragDropGesture();
            dragDropGesture.OnDragDrop += dragDropGesture_OnDragDrop;

            MouseMoveGesture mouseMoveGesture = new MouseMoveGesture();
            mouseMoveGesture.MouseMove += mouseMoveGesture_MouseMove;

            ClickGesture clickGesture = new ClickGesture();
            clickGesture.Click += clickGesture_Click;

            SvgElements.Rectangle rectangle;

            float currentY = SPACING;

            rectangle = CreateRectangle(diagram, "Click Me");
            rectangle.Y = currentY;
            rectangle.OnMouseDown += rectangle_OnMouseDown;
            rectangle.OnMouseUp += rectangle_OnMouseUp;
            rectangle.Gestures.Add(mouseMoveGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Click Me Too");
            rectangle.Y = currentY;
            rectangle.OnMouseDown += rectangle_OnMouseDown;
            rectangle.Gestures.Add(mouseMoveGesture);
            rectangle.Gestures.Add(clickGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Move Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(new MoveGesture());

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Drag & Drop Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(dragDropGesture);

            currentY += BLOCK_HEIGHT + SPACING;

            rectangle = CreateRectangle(diagram, "Drop & Drop Me");
            rectangle.Y = currentY;
            rectangle.Gestures.Add(dragDropGesture);

            diagramControl1.Diagram = diagram;
        }

        private SvgElements.Rectangle CreateRectangle(Diagram diagram, string text)
        {
            var rectangle = new SvgElements.Rectangle()
            {
                X = SPACING,
                Y = SPACING,
                Width = BLOCK_WIDTH,
                Height = BLOCK_HEIGHT,
                BackStyle = SvgHelper.BlueBackStyle,
                LineStyle = SvgHelper.DefaultLineStyle,
                Diagram = diagram
            };

            var label2 = new SvgElements.Label
            {
                Text = text,
                X = 0,
                Y = 0,
                Width = BLOCK_WIDTH,
                Height = BLOCK_HEIGHT,
                TextStyle = SvgHelper.DefaultTextStyle,
                Parent = rectangle
            };

            return rectangle;
        }

        private void dragDropGesture_OnDragDrop(object sender, Svg.EventArg.DragDropEventArgs e)
        {
            TrySetElementText(e.DraggedElement, "Dragged");
            TrySetElementText(e.DroppedOnElement, "Dropped On");
        }

        private void mouseMoveGesture_MouseMove(object sender, Svg.EventArg.MouseEventArgs e)
        {
            TrySetElementText(sender, "MouseMove");
        }

        private void rectangle_OnMouseDown(object sender, Svg.EventArg.MouseEventArgs e)
        {
            TrySetElementText(sender, "MouseDown");
        }

        private void rectangle_OnMouseUp(object sender, Svg.EventArg.MouseEventArgs e)
        {
            TrySetElementText(sender, "MouseUp");
        }

        private void clickGesture_Click(object sender, EventArgs e)
        {
            TrySetElementText(sender, "Clicked");
        }

        private void TrySetElementText(object element, string text)
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
