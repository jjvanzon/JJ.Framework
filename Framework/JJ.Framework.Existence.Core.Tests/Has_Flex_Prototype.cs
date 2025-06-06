using static JJ.Framework.Existence.Core.Tests.FlexFlag;
using static JJ.Framework.Existence.Core.Tests.FilledInPrototype;

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Dynamic_Tests
{
    // Example use
    
    [TestMethod]
    public void Test_Has_Dynamic()
    {
        // Problem: Object parameter isn't treated as text,
        // so white space isn't treated as empty.

        // Normal case
        {
            string text = " "; // type `string`
            bool filled = Has(text);
            // " " is considered not filled in, because Has uses parameter type string here.
            IsFalse(filled);
        }

        // Problem case
        {
            object text = " "; // type `object`
            bool filled = Has(text);
            // " " is considered filled, because of parameter type object.
            IsTrue(filled);
        }
        
        // Solution
        {
            object text = " ";
            bool filled = Has(text, flex); // `flex` flag
            // " " = not filled in here.
            // Even though parameter typer is object,
            // it's still recognized as text,
            // by (slower) run-time inspection.
            IsFalse(filled);
        }

        // Former alternatives:
        //IsFalse(Has(text, dynamic));
        //IsFalse(Has(text, deep));
        //IsFalse(Has(text, thorough));
        //IsFalse(Has(text, concrete));
        //IsFalse(Has(text, force));
        //IsFalse(Has(text, dyn));
        //IsFalse(Has(text, reflect));
    }

}

// Proposed Implementation

internal enum FlexFlag
{
    flex = 1,
    
    // Former alternatives:
    //dynamic,
    //deep,
    //thorough,
    //concrete,
    //force,
    //dyn,
    //reflect,
}

internal static class FilledInPrototype
{
    // Overload for switching flex on and off with true/false.
    public static bool Has([NotNullWhen(true)] object? obj, bool flex)
    {
        if (flex) return Has(obj, FlexFlag.flex);
        return HasValOrObj(obj);
    }

    // Overload with FlexFlag: the FlexFlax enum only has 1 possible value: `flex`.
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
    
    // Stubs for demo, already part of the main code.
    private static bool HasText([NotNullWhen(true)] string? text) => FilledInHelper.Has(text);
    private static bool HasSB([NotNullWhen(true)] StringBuilder? sb) => FilledInHelper.Has(sb);
    private static bool HasValOrObj([NotNullWhen(true)] object? valOrObj) => FilledInHelper.Has(valOrObj);
}