using System;
using System.Linq.Expressions;
using JJ.Framework.Common;
using static System.Math;
using static JJ.Framework.Wishes.Testing.AssertHelper_Copied;
using static JJ.Framework.Wishes.Testing.DeltaDirectionEnum;

namespace JJ.Framework.Wishes.Testing
{
    public static class AssertWishes
    {
        public static void AreEqual(int expected, Expression<Func<int>> actualExpression, int delta, DeltaDirectionEnum direction = Both)
        {
            if (direction == Both)
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
          
        public static void AreEqual(double expected, Expression<Func<double>> actualExpression, double delta, DeltaDirectionEnum direction = Both)
        {
            if (direction == Both)
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