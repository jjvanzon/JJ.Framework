using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Logging.Core.docs;
using static System.Math;
using static JJ.Framework.Testing.Core.AssertHelperLegacy;
using static JJ.Framework.Testing.Core.DeltaDirectionEnum;

namespace JJ.Framework.Testing.Core
{
    public static class AssertHelperCore
    {
        /// <inheritdoc cref="_deltadirection" />
        public static void AreEqual(int expected, Expression<Func<int>> actualExpression, int delta, DeltaDirectionEnum direction = None)
        {
            // Allow negatives to trigger Downward direction automatically
            if (delta < 0 && direction == default) direction = Down;

            if (direction == None)
            {
                ExpectedActualCheck_Copied(actual => Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);
            }
            else if (direction == Up)
            {
                ExpectedActualCheck_Copied(actual => actual - expected >= 0 && Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);   
            }
            else if (direction == Down)
            {
                ExpectedActualCheck_Copied(actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta), nameof(AreEqual), expected, actualExpression);   
            }
            else
            {
                throw new ValueNotSupportedException(direction);
            }
        }
          
        /// <inheritdoc cref="_deltadirection" />
        public static void AreEqual(double expected, Expression<Func<double>> actualExpression, double delta, DeltaDirectionEnum direction = None)
        {
            // Allow negatives to trigger Downward direction automatically
            if (delta < 0 && direction == default) direction = Down;

            if (direction == None)
            {
                ExpectedActualCheck_Copied(actual => Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);
            }
            else if (direction == Up)
            {
                ExpectedActualCheck_Copied(actual => actual - expected >= 0 && Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);   
            }
            else if (direction == Down)
            {
                ExpectedActualCheck_Copied(actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta), nameof(AreEqual), expected, actualExpression);   
            }
            else
            {
                throw new ValueNotSupportedException(direction);
            }
        }
    }
}