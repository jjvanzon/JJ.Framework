using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics
{
    public static class GeometryCalculator
    {
        public static bool IsInRectangle(float x, float y, float x1, float y1, float x2, float y2)
        {
            return x >= x1 && x <= x2 &&
                   y >= y1 && y <= y2;
        }

        public static bool IsInRectangle(double x, double y, double x1, double y1, double x2, double y2)
        {
            return x >= x1 && x <= x2 &&
                   y >= y1 && y <= y2;
        }
    }
}
