#pragma warning disable IDE0002

// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

public class OperatingSystemSupport_TestBase
{
    public void Test_IsWindows()
    {
        if (IsWindows())
        // ncrunch: no coverage start
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
        // ncrunch: no coverage end
    }
}
