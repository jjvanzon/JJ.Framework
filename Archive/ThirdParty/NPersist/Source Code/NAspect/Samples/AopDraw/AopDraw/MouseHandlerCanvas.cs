using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Classes;
using System.Windows.Forms;
using AopDraw.Interfaces;
using AopDraw.Classes.Shapes;
using AopDraw.Enums;
using System.Drawing;

namespace AopDraw
{
    public class MouseHandlerCanvas : Canvas
    {

        private DrawAction currentAction = DrawAction.None;
        private Point mouseDownPos;
        public void MouseMove(object sender, MouseEventArgs e)
        {
            Shape shape = GetShapeFromMouse(e);
            if (shape is IMouseHandler)
            {
                IMouseHandler mouseShape = (IMouseHandler)shape;
                mouseShape.MouseMove(shape, e);
            }
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPos = new Point(e.X, e.Y);

            Shape shape = GetShapeFromMouse(e);
            if (shape is IMouseHandler)
            {
                IMouseHandler mouseShape = (IMouseHandler)shape;
                mouseShape.MouseDown(shape, e);
            }            
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            Shape shape = GetShapeFromMouse(e);
            if (shape is IMouseHandler)
            {
                IMouseHandler mouseShape = (IMouseHandler)shape;
                mouseShape.MouseUp(shape, e);
            }            
        }

        private Shape GetShapeFromMouse(MouseEventArgs e)
        {
            double x = e.X;
            double y = e.Y;
            Shape shape = GetShapeAt(x, y);
            return shape;
        }
    }
}
