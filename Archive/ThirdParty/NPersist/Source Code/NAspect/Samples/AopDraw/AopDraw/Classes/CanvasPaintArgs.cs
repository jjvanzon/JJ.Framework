using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AopDraw.Classes
{
    public class CanvasPaintArgs
    {
        public Graphics g;
        public Rectangle Bounds;
        public Pen BorderPen;
        public Brush FillBrush;
        public Color Shade;
    }
}
