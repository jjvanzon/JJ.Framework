namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class NotNullWhen_Shim_Tests_Base
{
    public void Test_NotNullWhen_PlatformStub()
    {
        var attr = new NotNullWhenAttribute(true);
        IsTrue(attr.ReturnValue);
        
        // ReSharper disable once VariableCanBeNotNullable
        const string? nullyFilled = "";
        const string? @null = null;
        
        if (!CheckNotNull(nullyFilled))
            // ncrunch: no coverage start
        {
            const string num = nullyFilled; // Compiles: Successfully promoted to non-null.
            NoNullRet(nullyFilled);
        }
        // ncrunch: no coverage end
        
        if (CheckIsNull(@null))
        {
            // Does not compile = correct = not promoted to non-null
            //string noNull = nullText;
        }
    }
    
    private bool CheckNotNull([NotNullWhen(true)] string? text) => text != null;
    private bool CheckIsNull([NotNullWhen(false)] string? text) => text == null;
}