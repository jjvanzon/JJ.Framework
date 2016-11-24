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
    [Resizable(KeepProportions = true)]
    public class SquareShape : RectangleShape
    {
        public override void Render(CanvasPaintArgs e)
        {
            RectangleF bounds = GetBoundsF();
            e.g.FillRectangle(e.FillBrush, bounds);
            e.g.DrawRectangle(e.BorderPen, bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }
}
