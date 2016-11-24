using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using System.Windows.Forms;
using AopDraw.Classes;
using Puzzle.NAspect.Framework.Aop;
using System.Drawing;
using Puzzle.NAspect.Framework;
using AopDraw.Classes.Shapes;

namespace AopDraw.Mixins
{
    public class SelectableShape1DMixin : ISelectable, IProxyAware
    {
        private Shape1D shape;
        private ISelectable selectable;

        public void SetProxy(IAopProxy target)
        {
            Shape1D shape = target as Shape1D;

            if (shape == null)
                throw new ArgumentException("target is not an IShape1D");

            this.shape = shape;
            this.selectable = (ISelectable)shape;


            IMouseHandler mouseShape = (IMouseHandler)shape;
            mouseShape.MouseDownHandlers.Add(MouseDown);
            mouseShape.MouseUpHandlers.Add(MouseUp);
            mouseShape.MouseMoveHandlers.Add(MouseMove);
        }

        private ICanvas Canvas
        {
            get
            {
                return ((ICanvasAware)shape).Canvas;
            }
        }

        

        private void MouseDown(Shape shape, int x, int y, MouseButtons buttons, ref bool handled)
        {
            Canvas.ClearSelection();
            selectable.IsSelected = true;
            handled = true;
        }

        private void MouseUp(Shape shape, int x, int y, MouseButtons buttons, ref bool handled)
        {
        }

        private void MouseMove(Shape shape, int x, int y, MouseButtons buttons, ref bool handled)
        {
        }

        #region Property IsSelected
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
            }
        }
        #endregion

        public void RenderSelection(CanvasPaintArgs e)
        {
            Rectangle obounds = shape.GetBounds();
            Rectangle ibounds = shape.GetBounds();
            obounds.Inflate(1, 1);
            ibounds.Inflate(-1, -1);

            ControlPaint.DrawGrabHandle (e.g,new Rectangle ((int)shape.X-3,(int)shape.Y-3,6,6),true,true);
            ControlPaint.DrawGrabHandle(e.g, new Rectangle((int)shape.X2 - 3, (int)shape.Y2 - 3, 6, 6), true, true);
            ControlPaint.DrawSelectionFrame(e.g, true, obounds, ibounds, Color.Transparent);
        }
    }
}

