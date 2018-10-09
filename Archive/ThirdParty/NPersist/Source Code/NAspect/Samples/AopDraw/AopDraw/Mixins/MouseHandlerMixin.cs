using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;
using System.Windows.Forms;
using AopDraw.Delegates;
using AopDraw.Classes.Shapes;

namespace AopDraw.Mixins
{
    public class MouseHandlerMixin : IMouseHandler
    {

        

        #region Property MouseDownHandlers 
        private IList<CanvasMouseEventHandler> mouseDownHandlers = new List<CanvasMouseEventHandler>();
        public IList<CanvasMouseEventHandler> MouseDownHandlers
        {
            get
            {
                return this.mouseDownHandlers;
            }
        }                        
        #endregion
        

        #region Property MouseUpHandlers 
        private IList<CanvasMouseEventHandler> mouseUpHandlers = new List<CanvasMouseEventHandler>();
        public IList<CanvasMouseEventHandler> MouseUpHandlers
        {
            get
            {
                return this.mouseUpHandlers;
            }
        }                        
        #endregion

        #region Property MouseMoveHandlers 
        private IList<CanvasMouseEventHandler> mouseMoveHandlers = new List<CanvasMouseEventHandler>();
        public IList<CanvasMouseEventHandler> MouseMoveHandlers
        {
            get
            {
                return this.mouseMoveHandlers;
            }
        }                        
        #endregion

        public void MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            MouseButtons buttons = e.Button;
            bool handled;
            Shape shape = (Shape)sender;
            handled = false;
            foreach (CanvasMouseEventHandler handler in mouseDownHandlers)
            {
                handler(shape, x, y, buttons, ref handled);
                if (handled)
                    break;
            }
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            MouseButtons buttons = e.Button;
            bool handled;
            Shape shape = (Shape)sender;
            handled = false;
            foreach (CanvasMouseEventHandler handler in MouseUpHandlers)
            {
                handler(shape, x, y, buttons, ref handled);
                if (handled)
                    break;
            }
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            MouseButtons buttons = e.Button;
            bool handled;
            Shape shape = (Shape)sender;
            handled = false;
            foreach (CanvasMouseEventHandler handler in mouseMoveHandlers)
            {
                handler(shape, x, y, buttons, ref handled);
                if (handled)
                    break;
            }
        }
    }
}
