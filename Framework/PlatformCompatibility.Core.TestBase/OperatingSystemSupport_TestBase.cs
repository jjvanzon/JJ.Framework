#pragma warning disable IDE0002

// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

public class OperatingSystemSupport_TestBase
{
    public void Test_IsWindows()
    {
        if (IsWindows())
        {
            Console.WriteLine("IsWindows == true");
        }
        else
        {
            Console.WriteLine("IsWindows == false");
        }

        #if NETSTANDARD || NETFRAMEWORK
            IsFalse(IsWindows());
        #else
            IsTrue(IsWindows());
        #endif
    }
}
