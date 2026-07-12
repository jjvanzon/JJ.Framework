namespace JJ.Framework.Testing;

public static class AssertHelperEx
{
    // Throws (Containing)

    public static void Throws(Func<object?> statement, params string[] expectedTexts)
        => Throws(() => { statement(); }, expectedTexts);

    public static void Throws(Action statement, params string[] expectedTexts)
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
        
    public static void Throws(Func<object?> statement, Type exceptionType, params string[] expectedTexts)
        => Throws(() => { statement(); }, exceptionType, expectedTexts);

    public static void Throws(Action statement, Type exceptionType, params string[] expectedTexts)
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
            AreEqual(exceptionType, () => ex.GetType());
                
            foreach (string expectedText in expectedTexts)
            {
                Contains(expectedText, ex.Message);
            }
                
            return;
        }

        throw new Exception("An exception should have occurred.");
    }

    public static void Throws<TException>(Func<object?> statement, params string[] expectedTexts)
        => Throws(statement, typeof(TException), expectedTexts);

    public static void Throws<TException>(Action statement, params string[] expectedTexts)
        => Throws(statement, typeof(TException), expectedTexts);
                
    // Partial String Comparison

    private static void Contains(string? expectedText, string? actualText)
    {
        actualText ??= "";
        expectedText ??= "";

        if (!(actualText.IndexOf(expectedText, OrdinalIgnoreCase) >= 0))
        {
            throw new Exception($"Message does not contain: '{expectedText}'. Full message: '{actualText}'");
        }
    }
}
