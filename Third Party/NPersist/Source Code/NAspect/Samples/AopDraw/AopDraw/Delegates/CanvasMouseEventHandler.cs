using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AopDraw.Classes.Shapes;

namespace AopDraw.Delegates
{
    public delegate void CanvasMouseEventHandler (Shape shape,int x,int y,MouseButtons buttons,ref bool handled);
    
}
