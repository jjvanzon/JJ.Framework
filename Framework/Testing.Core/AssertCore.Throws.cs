// ReSharper disable RedundantBoolCompare

using JJ.Framework.Collections.Core;

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Throws (Containing)

    public static Exception Throws(Func<object?> statement, params string[] expectedTexts)
        => Throws(() => { statement(); }, expectedTexts);

    public static Exception Throws(Action statement, params string[] expectedTexts)
    {
        if (statement == null) throw new NullException(() => statement);
        if (expectedTexts == null) throw new NullException(() => expectedTexts);
        
        Exception? actualException = null;
        try
        {
            statement();
        }
        catch (Exception ex)
        {
            if (ExceptionIsMatch(ex, expectedTexts))
            {
                return ex;
            }

            actualException = ex;
        }

        throw new Exception(FormatShouldHaveThrownMessage(expectedTexts, actualException));
        
    }
    
    public static Exception Throws(Func<object?> statement, Type exceptionType, params string[] expectedTexts)
        => Throws(() => { statement(); }, exceptionType, expectedTexts);

    public static Exception Throws(Action statement, Type exceptionType, params string[] expectedTexts)
    {
        if (statement == null) throw new NullException(() => statement);
        if (exceptionType == null) throw new NullException(() => exceptionType);
        if (expectedTexts == null) throw new NullException(() => expectedTexts);
        
        Exception? actualException = null;
        try
        {
            statement();
        }
        catch (Exception ex)
        {
            if (ExceptionIsMatch(ex, exceptionType, expectedTexts))
            {
                return ex;
            }

            actualException = ex;
        }

        throw new Exception(FormatShouldHaveThrownMessage(exceptionType, expectedTexts, actualException));
    }

    private static bool ExceptionIsMatch(Exception ex, string?[] expectedTexts) => ExceptionIsMatch(ex, default, expectedTexts);
    private static bool ExceptionIsMatch(Exception ex, Type? expectedType, string?[]? expectedTexts)
    {
        bool anyExpectedTexts = AnyExpectedTexts(expectedTexts);

        if (expectedType == null && !anyExpectedTexts) 
        {
            // No expectations filled in? 
            // Exception always match.
            return true;
        }

        Exception[] exceptions = ex.SelfAndAncestors(x => x.InnerException).ToArray();

        foreach (Exception exception in exceptions)
        {
            if (expectedType != null)
            {
                // TODO: Base types?
                bool typeIsMatch = exception.GetType() == expectedType;
                if (!typeIsMatch)
                {
                    // No match: continue searching.
                    continue;
                }
            }

            if (anyExpectedTexts)
            {
                bool messageIsMatch = expectedTexts!.All(x => exception.Message.Contains(x, caseMatters: false));
                if (!messageIsMatch)
                {
                    // No match: continue searching.
                    continue;
                }
            }

            // Both type and text match: found! Return true!
            return true;
        }

        // Nothing matched: return false.
        return false;
    }

    private static bool AnyExpectedTexts([NotNullWhen(true)] string?[]? expectedTexts) 
        => expectedTexts != null && expectedTexts.Any(x => !string.IsNullOrWhiteSpace(x));

    private static string FormatShouldHaveThrownMessage(string[]? expectedTexts, Exception? actualException)
    {
        return FormatShouldHaveThrownMessage(default, expectedTexts, actualException);
    }

    private static string FormatShouldHaveThrownMessage(Type? exceptionType, string[]? expectedTexts, Exception? actualException)
    {
        string exceptionTypePart = "Exception";
        if (exceptionType != null)
        {
            exceptionTypePart = exceptionType.Name.CutRight("Exception");
        }
        
        string expectedTextsPart = "";
        if (AnyExpectedTexts(expectedTexts))
        {
            expectedTextsPart = " with message containing: " + Join(", ", expectedTexts.Select(x => '"' + x + '"'));
        }

        string actualExceptionPart = "";
        if (actualException != null)
        {
           actualExceptionPart = " Actual: " + actualException;
        }

        return exceptionTypePart + " should have been thrown" + expectedTextsPart + "." + actualExceptionPart;
    }

    public static Exception Throws<TException>(Func<object?> statement, params string[] expectedTexts)
        => Throws(statement, typeof(TException), expectedTexts);

    public static Exception Throws<TException>(Action statement, params string[] expectedTexts)
        => Throws(statement, typeof(TException), expectedTexts);

    public static void ThrowsExceptionOnOtherThread(Func<object?> statement)
        => AssertHelper.ThrowsExceptionOnOtherThread(() => statement());
    
    public static void ThrowsOnOtherThread(Func<object?> statement)
        => AssertCore.ThrowsExceptionOnOtherThread(statement);
    
    public static void ThrowsOnOtherThread(Action statement)
        => AssertHelper.ThrowsExceptionOnOtherThread(statement);

    // Overloads with Func
    
    // (extends Action variants, avoids shadow by MSTest)

    public static void ThrowsException(Func<object?> statement)
        => Throws(() => statement());
        
    public static void ThrowsException(Func<object?> statement, string expectedMessage) 
        => Throws(() => statement(), expectedMessage);
    
    public static void ThrowsException(Func<object?> statement, Type exceptionType)
        => Throws(() => statement(), exceptionType);

    public static void ThrowsException(Func<object?> statement, Type exceptionType, string expectedMessage)
        => Throws(() => statement(), exceptionType, expectedMessage);
    
    public static void ThrowsException<ExceptionType>(Func<object?> statement)
        => Throws<ExceptionType>(() => statement());

    public static void ThrowsException<ExceptionType>(Func<object?> statement, string expectedMessage)
        => Throws<ExceptionType>(() => statement(), expectedMessage);
}
