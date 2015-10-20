using System;

namespace JJ.Framework.Mathematics
{
    public static class Maths
    {
        public const double SQRT_2 = 1.4142135623730950;
        public const float FLOAT_SQRT_2 = 1.4142136f;
        public const double TWO_PI = 6.2831853071795865;

        /// <summary>
        /// Integer variation of the Math.Pow function,
        /// that only works for non-negative exponents.
        /// </summary>
        public static int Pow(int n, int e)
        {
            // I doubt this is actually faster than just using the standard Math.Pow that takes double.
            int x = 1;
            for (int i = 0; i < e; i++)
            {
                x *= n;
            }
            return x;
        }

        /// <summary>
        /// Integer variation of the Math.Log function.
        /// It will only return integers,
        /// but will prevent rounding erros such as
        /// 1000 log 10 = 2.99999999996
        /// </summary>
        public static int Log(int value, int n)
        {
            int temp = value;
            int i = 0;
            while (temp >= n)
            {
                temp /= n;
                i++;
            }
            return i;
        }
    }
}
