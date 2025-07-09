// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // AreEqual
    
    public static void AreEqual(object? expected, object? actual, [ArgExpress(nameof(actual))] string message = "") 
        => Check(expected, actual, message, () => Equals(expected, actual));
    
    public static void AreEqual<T>(T expected, T actual, [ArgExpress(nameof(actual))] string message = "") 
        => Check(expected, actual, message, () => Equals(expected, actual));
    
    public static void NotEqual(object expected, object actual, [ArgExpress(nameof(actual))] string message = "") 
        => Check(expected, actual, message, () => !Equals(expected, actual));
    
    public static void NotEqual<T>(T expected, T actual, [ArgExpress(nameof(actual))] string message = "") 
        => Check(expected, actual, message, () => !Equals(expected, actual));
    
    /// <inheritdoc cref="_deltadirection" />
    public static void AreEqual(int expected, Expression<Func<int>> actualExpression, int delta, DeltaDirectionEnum direction = DeltaDirectionEnum.None)
    {
        // Allow negatives to trigger Downward direction automatically
        if (delta < 0 && direction == default) direction = Down;

        if (direction == DeltaDirectionEnum.None)
        {
            Check(expected, actualExpression, actual => Abs(actual - expected) <= delta);
        }
        else if (direction == Up)
        {
            Check(expected, actualExpression, actual => actual - expected >= 0 && Abs(actual - expected) <= delta);   
        }
        else if (direction == Down)
        {
            Check(expected, actualExpression, actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta));   
        }
        else
        {
            throw new ValueNotSupportedException(direction);
        }
    }
      
    /// <inheritdoc cref="_deltadirection" />
    public static void AreEqual(double expected, Expression<Func<double>> actualExpression, double delta, DeltaDirectionEnum direction = DeltaDirectionEnum.None)
    {
        // Allow negatives to trigger Downward direction automatically
        if (delta < 0 && direction == default) direction = Down;

        if (direction == DeltaDirectionEnum.None)
        {
            Check(expected, actualExpression, actual => Abs(actual - expected) <= delta);
        }
        else if (direction == Up)
        {
            Check(expected, actualExpression, actual => actual - expected >= 0 && Abs(actual - expected) <= delta);   
        }
        else if (direction == Down)
        {
            Check(expected, actualExpression, actual => actual - expected <= 0 && Abs(actual - expected) <= Abs(delta));   
        }
        else
        {
            throw new ValueNotSupportedException(direction);
        }
    }
}
