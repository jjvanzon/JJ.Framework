// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // ThrowsException Checks

    public static void ThrowsExceptionContaining(Func<object?> statement, params string[] expectedTexts)
        => ThrowsExceptionContaining(() => { statement(); }, expectedTexts);

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
    
    public static void ThrowsExceptionContaining(Func<object?> statement, Type exceptionType, params string[] expectedTexts)
        => ThrowsExceptionContaining(() => { statement(); }, exceptionType, expectedTexts);

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
            AreEqual(exceptionType, ex.GetType());
            
            foreach (string expectedText in expectedTexts)
            {
                Contains(expectedText, ex.Message);
            }
            
            return;
        }

        throw new Exception("An exception should have occurred.");
    }

    public static void ThrowsExceptionContaining<TException>(Func<object?> statement, params string[] expectedTexts)
        => ThrowsExceptionContaining(statement, typeof(TException), expectedTexts);

    public static void ThrowsExceptionContaining<TException>(Action statement, params string[] expectedTexts)
        => ThrowsExceptionContaining(statement, typeof(TException), expectedTexts);
    
    // Overloads with Func
    
    // (extends Action variants, avoids shadow by MSTest)

    public static void ThrowsException(Func<object?> statement)
        => AssertHelper.ThrowsException(() => statement());
        
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
