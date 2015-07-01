using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics
{
    public static class Interpolator
    {
        ///// <summary>
        ///// Derived from the following source:
        ///// http://www.virtualdj.com/forums/171269/VirtualDJ_Plugins/_Release__CDJ_Vinyl_Brake_Effect.html
        ///// </summary>
        //public static short Interpolate_CubicEquidistant_Original(float x, short y1, short y2, short y3, short y4)
        //{
        //    float result = ((y2 / 2 - y1 / 6 - y3 / 2 + y4 / 6) * x * x * x) +
        //                   ((y1 / 2 - y2 + y3 / 2) * x * x) +
        //                   ((y3 - y2 / 2 - y1 / 3 - y4 / 6) * x) +
        //                    y2; //y2 is d
        //    return (short)result;
        //}

        /// <summary>
        /// Derived from the following source:
        /// http://www.virtualdj.com/forums/171269/VirtualDJ_Plugins/_Release__CDJ_Vinyl_Brake_Effect.html
        /// </summary>
        public static double Interpolate_Cubic_Equidistant_SlightlyBetterThanLinear(double t, double yMinus1, double y0, double y1, double y2)
        {
            double y = (y0 / 2 - yMinus1 / 6 - y1 / 2 + y2 / 6) * t * t * t +
                       (yMinus1 / 2 - y0 + y1 / 2) * t * t +
                       (y1 - y0 / 2 - yMinus1 / 3 - y2 / 6) * t +
                       y0; // y0 is d
            return y;
        }

        /// <summary>
        /// t values between 0 and 1 trace a curve
        /// going from (x0, y0) to (x3, y3).
        /// It does not go through (x1, y1) and (x2, y2).
        /// Those are merely control points that indicate the direction in which the curve goes.
        /// </summary>
        public static void Interpolate_Cubic_FromT(
            double x0, double x1, double x2, double x3,
            double y0, double y1, double y2, double y3,
            double t, out double x, out double y)
        {
            double oneMinusT = (1.0 - t);
            double oneMinusTSquared = oneMinusT * oneMinusT;
            double oneMinusTCubed = oneMinusTSquared * oneMinusT;
            double tSquared = t * t;
            double tCubed = tSquared * t;

            double a = oneMinusTCubed;
            double b = 3 * oneMinusTSquared * t;
            double c = 3 * oneMinusT * tSquared;
            double d = tCubed;

            x = a * x0 + 
                b * x1 + 
                c * x2 + 
                d * x3;

            y = a * y0 + 
                b * y1 + 
                c * y2 + 
                d * y3;
        }

        /// <summary>
        /// t values between 0 and 1 trace a curve
        /// going from (x0, y0) to (x3, y3).
        /// It does not go through (x1, y1) and (x2, y2).
        /// Those are merely control points that indicate the direction in which the curve goes.
        /// </summary>
        public static void Interpolate_Cubic_FromT(
            float x0, float x1, float x2, float x3,
            float y0, float y1, float y2, float y3,
            float t, out float x, out float y)
        {
            float oneMinusT = (1f - t);
            float oneMinusTSquared = oneMinusT * oneMinusT;
            float oneMinusTCubed = oneMinusTSquared * oneMinusT;
            float tSquared = t * t;
            float tCubed = tSquared * t;

            float a = oneMinusTCubed;
            float b = 3 * oneMinusTSquared * t;
            float c = 3 * oneMinusT * tSquared;
            float d = tCubed;

            x = a * x0 +
                b * x1 +
                c * x2 +
                d * x3;

            y = a * y0 +
                b * y1 +
                c * y2 +
                d * y3;
        }

        /// <summary>
        /// Not implemented yet.
        /// </summary>
        public static double Interpolate_Cubic_FromX(
            double x0, double x1, double x2, double x3, 
            double y0, double y1, double y2, double y3,
            double x)
        {
            throw new NotImplementedException();
        }
    }
}
