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
    public class SelectableShape2DMixin : ISelectable , IProxyAware
    {
        private Shape2D shape;
        private ISelectable selectable;

        public void SetProxy(IAopProxy target)
        {
            Shape2D shape = target as Shape2D;

            if (shape == null)
                throw new ArgumentException("target is not an IShape2D");

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
            obounds.Inflate(3, 3);
            ibounds.Inflate(-3, -3);

            ControlPaint.DrawSelectionFrame(e.g, true, obounds, ibounds,Color.Transparent);
        }
    }
}
