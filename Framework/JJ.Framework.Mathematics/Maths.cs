using System;

namespace JJ.Framework.Mathematics
{
    public static class Maths
    {
        private static double _sqrt2 = Math.Sqrt(2);
        public static double Sqrt2 { get { return _sqrt2; } }

        private static float _floatsqrt2 = (float)Math.Sqrt(2);
        public static float FloatSqrt2 { get { return _floatsqrt2; } }

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
