﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JJ.Framework.Presentation.VectorGraphics.Enums;
using JJ.Framework.Presentation.VectorGraphics.EventArg;
using JJ.Framework.Presentation.VectorGraphics.Gestures;
using JJ.Framework.Presentation.VectorGraphics.Models.Elements;
using JJ.Framework.Presentation.WinForms.TestForms.Helpers;
using VectorGraphicsElements = JJ.Framework.Presentation.VectorGraphics.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    internal partial class ScaleTestForm : Form
    {
        public ScaleTestForm()
        {
            InitializeComponent();

            Text = GetType().FullName;

            InitializeDiagramAndElements3();
        }

        private void InitializeDiagramAndElements1()
        {
            var diagram = new Diagram();
            diagram.Position.ScaleModeEnum = ScaleModeEnum.ViewPort;
            diagram.Position.ScaledX = 50;
            diagram.Position.ScaledY = 50;
            diagram.Position.ScaledWidth = 400;
            diagram.Position.ScaledHeight = 400;

            var mouseDownGesture = new MouseDownGesture();
            mouseDownGesture.MouseDown += mouseDownGesture_MouseDown;

            var mouseMoveGesture = new MouseMoveGesture();
            mouseMoveGesture.MouseMove += mouseMoveGesture_MouseMove;

            var mouseUpGesture = new MouseUpGesture();
            mouseUpGesture.MouseUp += mouseUpGesture_MouseUp;

            var mouseLeaveGesture = new MouseLeaveGesture();
            mouseLeaveGesture.MouseLeave += mouseLeaveGesture_MouseLeave;

            DoubleClickGesture doubleClickGesture = diagramControl1.CreateDoubleClickGesture();
            doubleClickGesture.DoubleClick += DoubleClickGesture_DoubleClick;

            VectorGraphicsElements.Rectangle rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Hello");
            rectangle.Gestures.Add(mouseDownGesture);
            rectangle.Gestures.Add(mouseMoveGesture);
            rectangle.Gestures.Add(mouseUpGesture);
            rectangle.Gestures.Add(mouseLeaveGesture);
            rectangle.Gestures.Add(doubleClickGesture);
            rectangle.Gestures.Add(new MoveGesture());

            diagramControl1.Diagram = diagram;
            diagramControl1.Width = 200;
            diagramControl1.Height = 200;
        }

        private void InitializeDiagramAndElements2()
        {
            var diagram = new Diagram();
            diagram.Position.ScaleModeEnum = ScaleModeEnum.ViewPort;
            diagram.Position.ScaledX = 50;
            diagram.Position.ScaledY = 50;
            diagram.Position.ScaledWidth = 400;
            diagram.Position.ScaledHeight = 400;

            var mouseDownGesture = new MouseDownGesture();
            mouseDownGesture.MouseDown += mouseDownGesture_MouseDown;

            VectorGraphicsElements.Rectangle rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Hello");
            rectangle.Position.Y = 0;
            rectangle.Position.X = 0;
            rectangle.Position.Width = 200;
            rectangle.Position.Height = 200;
            rectangle.Gestures.Add(mouseDownGesture);

            diagramControl1.Diagram = diagram;
            diagramControl1.Width = 200;
            diagramControl1.Height = 200;
        }

        private void InitializeDiagramAndElements3()
        {
            var diagram = new Diagram();
            diagram.Position.ScaleModeEnum = ScaleModeEnum.ViewPort;
            diagram.Position.ScaledX = -10;
            diagram.Position.ScaledY = -10;
            diagram.Position.ScaledWidth = 30;
            diagram.Position.ScaledHeight = 30;

            var mouseDownGesture = new MouseDownGesture();
            mouseDownGesture.MouseDown += mouseDownGesture_MouseDown;

            var mouseLeaveGesture = new MouseLeaveGesture();
            mouseLeaveGesture.MouseLeave += mouseLeaveGesture_MouseLeave;

            VectorGraphicsElements.Rectangle rectangle = VectorGraphicsFactory.CreateRectangle(diagram, "Hello");
            rectangle.Position.Y = 10;
            rectangle.Position.X = 10;
            rectangle.Position.Width = 10;
            rectangle.Position.Height = 10;
            rectangle.Children.ElementAt(0).Position.Width = 10;
            rectangle.Children.ElementAt(0).Position.Height = 10;
            rectangle.Gestures.Add(mouseDownGesture);
            rectangle.Gestures.Add(mouseLeaveGesture);

            diagramControl1.Diagram = diagram;
        }

        private void ScaleTestForm_SizeChanged(object sender, EventArgs e)
        {
            diagramControl1.Width = ClientSize.Width;
            diagramControl1.Height = ClientSize.Height;
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
