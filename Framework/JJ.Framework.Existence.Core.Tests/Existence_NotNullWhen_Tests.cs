// ReSharper disable ReturnTypeCanBeNotNullable
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_NotNullWhen_Tests
{
    string? Text => "Hi!";
    StringBuilder? SB => new("Hi!");
    int? Num => 1;

    [TestMethod]
    public void Test_Has_NotNullWhen()
    {
        { string?        text = Text; if ( FilledIn(text         )) text.ToString(); }
        { string?        text = Text; if ( FilledIn(text, default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if ( FilledIn(sb           )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if ( FilledIn(sb,   default)) sb  .ToString(); }
        { int?           num  = Num ; if ( FilledIn(num          )) num .ToString(); }
        { string?        text = Text; if ( Has     (text         )) text.ToString(); }
        { string?        text = Text; if ( Has     (text, default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if ( Has     (sb           )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if ( Has     (sb,   default)) sb  .ToString(); }
        { int?           num  = Num ; if ( Has     (num          )) num .ToString(); }
        { string?        text = Text; if (!IsNully (text         )) text.ToString(); }
        { string?        text = Text; if (!IsNully (text, default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if (!IsNully (sb           )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if (!IsNully (sb,   default)) sb  .ToString(); }
        { int?           num  = Num ; if (!IsNully (num          )) num .ToString(); }
        { string?        text = Text; if ( text.FilledIn(        )) text.ToString(); }
        { string?        text = Text; if ( text.FilledIn( default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if ( sb  .FilledIn(        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if ( sb  .FilledIn( default)) sb  .ToString(); }
        { int?           num  = Num ; if ( num .FilledIn(        )) num .ToString(); }
        { string?        text = Text; if (!text.IsNully(         )) text.ToString(); }
        { string?        text = Text; if (!text.IsNully(  default)) text.ToString(); }
        { StringBuilder? sb   = SB  ; if (!sb  .IsNully(         )) sb  .ToString(); }
        { StringBuilder? sb   = SB  ; if (!sb  .IsNully(  default)) sb  .ToString(); }
        { int?           num  = Num ; if (!num .IsNully(         )) num .ToString(); }
    }

    // TODO: For Collections
}