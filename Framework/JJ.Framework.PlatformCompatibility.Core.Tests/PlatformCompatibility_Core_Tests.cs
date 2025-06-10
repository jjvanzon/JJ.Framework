using System.Runtime.CompilerServices;

namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_Core_Tests
{
    [TestMethod]
    public void Test_PlatformCompatibility_Core()
    {
        int i = 5;
        CallerArgumentExpressionDummy(i);
    }
    
    private void CallerArgumentExpressionDummy(int arg, [CallerArgumentExpression(nameof(arg))] string expr = "")
    {
        AreEqual("i", expr);
    }
}