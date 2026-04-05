// ReSharper disable RedundantUsingDirective
// ReSharper disable ConvertIfStatementToSwitchStatement

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics.Legacy
{
    public static class Maths
    {
        /// <summary>
        /// Integer variation of the Math.Pow function.
        /// </summary>
        public static int Pow(int n, int e)
        {
            if (e < 0) return NegExp(n, e);

            // I doubt this is actually faster than just using the standard Math.Pow that takes double.
            int x = 1;
            for (int i = 0; i < e; i++)
            {
                x *= n;
            }
            return x;
        }

        private static int NegExp(int n, int exp)
        {
            if (n == 0)
                throw new DivideByZeroException();

            if (n == 1)
                return 1;

            if (n > 0) 
            { 
                // Postive integer with negative exponent
                // becomes a fraction => floored to 0.
                return 0;
            }

            // Negative number flips powers between pos and neg.
            //if (n < 0)
            {
                if (exp % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Integer variation of the Math.Log function.
        /// It will only return integers,
        /// but will prevent rounding erros such as
        /// 1000 log 10 = 2.99999999996
        /// </summary>
        public static int Log(int value, int n)
        {
            AssertUndefined(value, n);

            int temp = value;
            int i = 0;
            while (temp >= n)
            {
                temp /= n;
                i++;
            }
            return i;
        }

        private static void AssertUndefined(int value, int @base)
        {
            if (value <= 0)
                throw new Exception("Log value cannot be 0, because 0 isn't a power of anything. " +
                                    "Log value cannot be negative for integers - nothing raise to a power is a negative number."); // Not true: The  log -2 of -2 is 1. But most results are complex.
            if (@base < 2)
                throw new Exception("Base (n) cannot be 0, because any power of 0 is 0 and does not evaluate for other integers. " +
                                    "Base (n) cannot be 1, because any power of 1 is 1 and does not evaluate for other integers. " +
                                    "Base (n) cannot be negative - because then the sign flips back and forth and is not very well behaved.");
        }
    }
}
