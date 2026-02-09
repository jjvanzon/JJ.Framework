// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_NotNullWhen_Tests : TestBase
{
    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_Has_NotNullWhen()
    {
        string       ? Text() => NullyFilledText;
        StringBuilder? SB  () => NullyFilledSB;
        int          ? Num () => Nully1;
        bool         ? Bool() => NullyTrue;

        { string?        text = Text(); if ( Has     (text              )) text.ToString(); }
        { string?        text = Text(); if ( Has     (text, true        )) text.ToString(); }
        { string?        text = Text(); if ( Has     (text, spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb                )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb,   true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb,   spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( Has     (boo               )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (boo,  true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (boo,  zeroMatters )) boo = boo.Value; }
        { int?           num  = Num (); if ( Has     (num               )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (num,  true        )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (num,  zeroMatters )) num = num.Value; }
        { string?        text = Text(); if ( Has     (              text)) text.ToString(); }
        { string?        text = Text(); if ( Has     (true,         text)) text.ToString(); }
        { string?        text = Text(); if ( Has     (spaceMatters, text)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (              sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (true,         sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (spaceMatters, sb  )) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( Has     (              boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (true,         boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (zeroMatters,  boo )) boo = boo.Value; }
        { int?           num  = Num (); if ( Has     (              num )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (true,         num )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (zeroMatters,  num )) num = num.Value; }
    }
}