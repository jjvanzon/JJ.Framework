using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AopDraw.Attributes;

namespace AopDraw.Classes.Shapes
{
    [Movable]
    [Selectable]
    [Resizable(KeepProportions=true)]
    public class CircleShape : Shape2D
    {
        public override void Render(CanvasPaintArgs e)
        {
            e.g.FillEllipse(e.FillBrush, GetBoundsF());
            e.g.DrawEllipse(e.BorderPen, GetBoundsF());
        }
    }
}
