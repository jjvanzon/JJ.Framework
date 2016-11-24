using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace AopDraw.Interfaces
{
    public interface IDesignable
    {
        [Browsable(true)]
        Color BorderColor { get;set;}
        [Browsable(true)]
        float BorderSize { get;set;}
        [Browsable(true)]
        Color FillColor { get;set;}
    }
}
