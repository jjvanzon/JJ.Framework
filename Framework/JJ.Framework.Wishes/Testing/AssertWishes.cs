using System;
using System.Linq.Expressions;

namespace JJ.Framework.Wishes.Testing
{
    public static class AssertWishes
    {
        public static void AreEqual(int expected, Expression<Func<int>> actualExpression, int delta)
        {
            AssertHelper_Copied.ExpectedActualCheck_Copied(actual => Math.Abs(expected - actual) <= delta, nameof(AreEqual), expected, actualExpression);
        }
        
        public static void AreEqual(double expected, Expression<Func<double>> actualExpression, double delta)
        {
            AssertHelper_Copied.ExpectedActualCheck_Copied(actual => Math.Abs(expected - actual) <= delta, nameof(AreEqual), expected, actualExpression);
        }
    }
}