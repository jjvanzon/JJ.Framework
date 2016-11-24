using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
using AopDraw.Classes;
using System.Windows.Forms;
using System.Drawing;
using AopDraw.Classes.Shapes;
using AopDraw.Attributes;

namespace AopDraw.Mixins
{
    public class ResizableShape2DMixin : IResizable, IProxyAware
    {
        private Shape2D shape;

        public virtual void Resize(double width, double height)
        {
            if (!keepProportions)
            {
                shape.Width = Math.Max(OldWidth + width, 5);
                shape.Height = Math.Max(OldHeight + height, 5);
            }
            else
            {
                double max = Math.Max(OldWidth + width, OldHeight + height);
                shape.Width = Math.Max (max,5);
                shape.Height = Math.Max(max, 5);
            }
        }

        #region Property OldWidth 
        private double oldWidth;
        public double OldWidth
        {
            get
            {
                return this.oldWidth;
            }
            set
            {
                this.oldWidth = value;
            }
        }                        
        #endregion

        #region Property OldHeight 
        private double oldHeight;
        public double OldHeight
        {
            get
            {
                return this.oldHeight;
            }
            set
            {
                this.oldHeight = value;
            }
        }                        
        #endregion

        #region Property KeepProportions 
        private bool keepProportions;
        public bool KeepProportions
        {
            get
            {
                return this.keepProportions;
            }
            set
            {
                this.keepProportions = value;
            }
        }                        
        #endregion

        public void RememberSize()
        {
            this.OldWidth = shape.Width;
            this.OldHeight = shape.Height;
        }

        public void SetProxy(IAopProxy target)
        {
            Shape2D shape = target as Shape2D;

            if (shape == null)
                throw new ArgumentException("target is not an IShape2D");

            this.shape = shape;

            ResizableAttribute attrib = (ResizableAttribute)shape.GetType().GetCustomAttributes(typeof(ResizableAttribute), true)[0];

            KeepProportions = attrib.KeepProportions;

            IMouseHandler mouseShape = (IMouseHandler)shape;
            mouseShape.MouseDownHandlers.Add(MouseDown);
            mouseShape.MouseUpHandlers.Add(MouseUp);
            mouseShape.MouseMoveHandlers.Add(MouseMove);
        }

        private void MouseDown(Shape shape, int x, int y, MouseButtons buttons, ref bool handled)
        {
        }

        private void MouseUp(Shape shape, int x, int y, MouseButtons buttons, ref bool handled)
        {
        }

        private void MouseMove(Shape shape, int x, int y, MouseButtons buttons, ref bool handled)
        {
        }

        public virtual Rectangle GetGripBounds()
        {
            Rectangle bounds = shape.GetBounds();
            Rectangle sizeBounds = new Rectangle(bounds.Right - 16, bounds.Bottom - 16, 16, 16);
            return sizeBounds;
        }


        public void RenderResize(CanvasPaintArgs e)
        {

            ControlPaint.DrawSizeGrip(e.g, SystemColors.Control, GetGripBounds());
        }
    }
}
