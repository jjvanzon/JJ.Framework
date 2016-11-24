using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AopDraw.Interfaces
{
    [Browsable(true)]
    public interface ICanvasAware
    {
        ICanvas Canvas { get;set;}
    }
}
