using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Classes;
using System.Drawing;

namespace AopDraw.Interfaces
{
    public interface IResizable
    {
        void Resize(double width,double height);

        void RenderResize(CanvasPaintArgs e);
        void RememberSize();

        Rectangle GetGripBounds();
    } 
}
