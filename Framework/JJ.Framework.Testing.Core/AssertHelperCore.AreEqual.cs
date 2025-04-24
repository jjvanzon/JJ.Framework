// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    // AreEqual
    
    public static void AreEqual(object? expected, object? actual) 
        => ExpectedActualCheckCore(() => Equals(expected, actual), GetCurrentMethod().Name, expected, actual);
    
    // TODO: New syntax?
    //public static void AreEqual(object? expected, object? actual) 
    //    => Check(expected, actual, Equals);
    
    /// <inheritdoc cref="_deltadirection" />
    public static void AreEqual(int expected, Expression<Func<int>> actualExpression, int delta, DeltaDirectionEnum direction = None)
    {
        // Allow negatives to trigger Downward direction automatically
        if (delta < 0 && direction == default) direction = Down;

        if (direction == None)
        {
            ExpectedActualCheckLegacy(actual => Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);
        }
        else if (direction == Up)
        {
            ExpectedActualCheckLegacy(actual => actual - expected >= 0 && Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);   
        }
        else if (direction == Down)
        {
            ExpectedActualCheckLegacy(actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta), nameof(AreEqual), expected, actualExpression);   
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
            ExpectedActualCheckLegacy(actual => Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);
        }
        else if (direction == Up)
        {
            ExpectedActualCheckLegacy(actual => actual - expected >= 0 && Abs(actual - expected) <= delta, nameof(AreEqual), expected, actualExpression);   
        }
        else if (direction == Down)
        {
            ExpectedActualCheckLegacy(actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta), nameof(AreEqual), expected, actualExpression);   
        }
        else
        {
            throw new ValueNotSupportedException(direction);
        }
    }
}
