// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    // Basics
    
    public static void IsNotNull(object? value) 
        => Check(() => value != null, GetCurrentMethod().Name);
    
    public static void IsTrue(bool value) 
        => Check(() => value == true, GetCurrentMethod().Name);
    
    public static void IsTrue(bool value, string messageOrName) 
        => Check(() => value == true, GetCurrentMethod().Name, messageOrName);
    
    public static void IsFalse(bool value) 
        => Check(() => value == false, GetCurrentMethod().Name);
    
    public static void Fail(string message) 
        => throw new Exception(GetFailureMessageLegacy("", message));

    // Generalized Methods
    
    internal static void ExpectedActualCheckCore<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression, string? name = null)
    {
        T actual = ExpressionHelper.GetValue(actualExpression);
        
        if (IsNullOrWhiteSpace(name))
        {
            name = ExpressionHelper.GetText(actualExpression);
        }
        
        ExpectedActualCheckCore(() => condition(actual), methodName, expected, actual, name);
    }
    
    private static void ExpectedActualCheckCore<T>(Func<bool> condition, string methodName, T expected, T actual, string? name = null)
    {
        if (!condition())
        {
            string message = FormatTestedPropertyMessageLegacy(name);
            string fullMessage = GetExpectedActualMessageLegacy(methodName, expected, actual, message);
            throw new Exception(fullMessage);
        }
    }
    
    public static void Check(Func<bool> condition, string methodName, string? name = null)
        => Check(condition(), methodName, name);
    
    public static void Check(bool condition, string methodName, string? name = null)
    {
        if (!condition)
        {
            string message = FormatTestedPropertyMessageLegacy(name);
            string fullMessage = GetFailureMessageLegacy(methodName, message);
            throw new Exception(fullMessage);
        }
    }

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
    
            
    // Partial String Comparison
            
    public static void Contains(string expectedText, string actualText)
    {
        actualText ??= "";
        expectedText ??= "";
        
        if (!actualText.Contains(expectedText, ignoreCase: true))
        {
            throw new Exception($"Message does not contain: '{expectedText}'. Full message: '{actualText}'");
        }
    }

    // ThrowsException Checks
    
    public static void ThrowsExceptionContaining(Action statement, params string[] expectedTexts)
    {
        if (statement == null) throw new NullException(() => statement);
        if (expectedTexts == null) throw new NullException(() => expectedTexts);
        
        try
        {
            statement();
        }
        catch (Exception ex)
        {
            foreach (string expectedText in expectedTexts)
            {
                Contains(expectedText, ex.Message);
            }
            
            return;
        }

        throw new Exception("An exception should have occurred.");
    }
    
    public static void ThrowsExceptionContaining(Action statement, Type exceptionType, params string[] expectedTexts)
    {
        if (statement == null) throw new NullException(() => statement);
        if (exceptionType == null) throw new NullException(() => exceptionType);
        if (expectedTexts == null) throw new NullException(() => expectedTexts);
        
        try
        {
            statement();
        }
        catch (Exception ex)
        {
            AssertHelper.AreEqual(exceptionType, () => ex.GetType());
            
            foreach (string expectedText in expectedTexts)
            {
                Contains(expectedText, ex.Message);
            }
            
            return;
        }

        throw new Exception("An exception should have occurred.");
    }

    public static void ThrowsExceptionContaining<TException>(Action statement, params string[] expectedTexts)
        => ThrowsExceptionContaining(statement, typeof(TException), expectedTexts);
    // Overloads with Func (extends Action variants, avoids shadow by MSTest)

    public static void ThrowsException(Func<object?> statement, string expectedMessage) 
        => AssertHelper.ThrowsException(() => statement(), expectedMessage);
    
    public static void ThrowsException(Func<object?> statement, Type exceptionType)
        => AssertHelper.ThrowsException(() => statement(), exceptionType);

    public static void ThrowsException(Func<object?> statement, Type exceptionType, string expectedMessage)
        => AssertHelper.ThrowsException(() => statement(), exceptionType, expectedMessage);
    
    public static void ThrowsException<ExceptionType>(Func<object?> statement)
        => AssertHelper.ThrowsException<ExceptionType>(() => statement());

    public static void ThrowsException<ExceptionType>(Func<object?> statement, string expectedMessage)
        => AssertHelper.ThrowsException<ExceptionType>(() => statement(), expectedMessage);
    
    public static void ThrowsExceptionOnOtherThread(Func<object?> statement)
        => AssertHelper.ThrowsExceptionOnOtherThread(() => statement());
}
