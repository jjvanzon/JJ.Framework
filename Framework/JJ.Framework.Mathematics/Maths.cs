using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics
{
    public static class Maths
    {
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
    }
}
