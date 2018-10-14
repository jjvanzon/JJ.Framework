using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AopDraw.Attributes;

namespace AopDraw.Classes.Shapes
{
    [Movable]
    [Selectable]
    [Designable]
    [Resizable]
    public class Ellipse : Shape2D
    {
        public override void Render(CanvasPaintArgs e)
        {
            e.g.FillEllipse(e.FillBrush, GetBoundsF());
            e.g.DrawEllipse(e.BorderPen, GetBoundsF());
        }
    }
}
