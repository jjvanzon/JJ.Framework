using static JJ.Framework.Existence.Core.Tests.Has_Dynamic_Tests.FlexFlag;

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Dynamic_Tests
{
    // Demonstration
    
    [TestMethod]
    public void Test_Has_Dynamic()
    {
        object text = " ";
        IsFalse(Has(text, flex));
        
        // Former alternatives:
        //IsFalse(Has(text, dynamic));
        //IsFalse(Has(text, deep));
        //IsFalse(Has(text, thorough));
        //IsFalse(Has(text, concrete));
        //IsFalse(Has(text, force));
        //IsFalse(Has(text, dyn));
        //IsFalse(Has(text, reflect));
    }

    // Proposed Implementation

    public enum FlexFlag
    {
        flex = 1, synonym
        
        // Former alternatives:
        //dynamic,
        //deep,
        //thorough,
        //concrete,
        //force,
        //dyn,
        //reflect,
    }
    
    public static bool Has([NotNullWhen(true)] object? obj, bool flex)
    {
        if (flex) return Has(obj, FlexFlag.flex);
        return HasValOrObj(obj);
    }

    // ReSharper disable once UnusedParameter.Global
    public static bool Has([NotNullWhen(true)] object? obj, FlexFlag flex)
    {
        switch (obj)
        {
            case string text: return HasText(text);
            case StringBuilder sb: return HasSB(sb);
            default: return HasValOrObj(obj);
            // TODO: Extend cases
        }
    }
    
    // Stubs for demo, not part of new implementation.
    private static bool HasText([NotNullWhen(true)] string? text) => FilledInHelper.Has(text);
    private static bool HasSB([NotNullWhen(true)] StringBuilder? sb) => FilledInHelper.Has(sb);
    private static bool HasValOrObj([NotNullWhen(true)] object? valOrObj) => FilledInHelper.Has(valOrObj);
}