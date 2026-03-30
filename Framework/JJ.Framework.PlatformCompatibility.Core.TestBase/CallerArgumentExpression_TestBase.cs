#pragma warning disable IDE0051 // Unused member
#pragma warning disable IDE0062 // Unused parameter
#pragma warning disable CS0219 // Unused variable

// ReSharper disable UseSymbolAlias
// ReSharper disable EntityNameCapturedOnly.Local
// ReSharper disable UnusedVariable
// ReSharper disable UnusedMember.Local

namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class CallerArgumentExpression_TestBase
{
    public void Test_CallerArgumentExpression_PlatformStub()
    {
        var attribute = new CallerArgumentExpressionAttribute("name");
        AreEqual("name", attribute.ParameterName);

        const int i = 5;
        CallerArgumentExpressionDummy(i);
    }
    
    private void CallerArgumentExpressionDummy(int arg, [CallerArgumentExpression(nameof(arg))] string expr = "")
    {
        AreEqual("i", expr);
    }
}