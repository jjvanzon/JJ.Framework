using static JJ.Framework.Existence.Core.Tests.FlexFlag;
using static JJ.Framework.Existence.Core.Tests.FilledInPrototype;

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Flex_Prototype
{
    // Example use
    
    [TestMethod]
    public void Test_Flex()
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
    
    [TestMethod]
    public void Test_Flex_Coverage()
    {
        // ReSharper disable VariableCanBeNotNullable
        object? nullyObj = null;
        object? nullyTextAsObj = "";
        object? nullySBAsObj = new StringBuilder("");
        object? filledObj = new();
        object? filledTextAsObj = "text";
        object? filledSBAsObj = new StringBuilder("text");
        // ReSharper restore VariableCanBeNotNullable
        
        IsFalse(Has(nullyObj,        flex      ));
        IsFalse(Has(nullyTextAsObj,  flex      ));
        IsFalse(Has(nullySBAsObj,    flex      ));
        IsTrue (Has(filledObj,       flex      ));
        IsTrue (Has(filledTextAsObj, flex      ));
        IsTrue (Has(filledSBAsObj,   flex      ));
        
        IsFalse(Has(nullyObj,        flex: true));
        IsFalse(Has(nullyTextAsObj,  flex: true));
        IsFalse(Has(nullySBAsObj,    flex: true));
        IsTrue (Has(filledObj,       flex: true));
        IsTrue (Has(filledTextAsObj, flex: true));
        IsTrue (Has(filledSBAsObj,   flex: true));
        
        IsFalse(Has(nullyObj,        flex: false));
         // Even "" text is filled if flex is false and variable type object.
        IsTrue (Has(nullyTextAsObj,  flex: false));
        IsTrue (Has(nullySBAsObj,    flex: false));
        IsTrue (Has(filledTextAsObj, flex: false));
        IsTrue (Has(filledSBAsObj,   flex: false));
        IsTrue (Has(filledObj,       flex: false));
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