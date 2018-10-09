using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Classes;
using System.ComponentModel;

namespace AopDraw.Interfaces
{
    public interface ISelectable
    {
        [Browsable(true)]
        bool IsSelected
        {
            get;
            set;
        }

        void RenderSelection(CanvasPaintArgs e);
    }
}
