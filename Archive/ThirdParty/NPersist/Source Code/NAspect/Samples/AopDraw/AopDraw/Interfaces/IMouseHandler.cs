using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AopDraw.Delegates;

namespace AopDraw.Interfaces
{


    public interface IMouseHandler
    {
        IList<CanvasMouseEventHandler> MouseDownHandlers { get;}
        IList<CanvasMouseEventHandler> MouseUpHandlers { get;}
        IList<CanvasMouseEventHandler> MouseMoveHandlers { get;}

        void MouseDown(object sender, MouseEventArgs e);
        void MouseUp(object sender, MouseEventArgs e);
        void MouseMove(object sender, MouseEventArgs e);
    }
}
