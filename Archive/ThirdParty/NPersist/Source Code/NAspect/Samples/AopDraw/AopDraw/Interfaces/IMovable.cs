using System;
using System.Collections.Generic;
using System.Text;

namespace AopDraw.Interfaces
{
    public interface IMovable
    {
        void MoveTo(double x, double y);
        void RememberLocation();
    }
}
