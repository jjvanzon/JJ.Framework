// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_NotNullWhen_Tests : TestBase
{
    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Has_NotNullWhen_Text()
    {
        string? Text() => NullyFilledText;

        { string?        text = Text(); if ( Has     (text              )) text.ToString(); }
        { string?        text = Text(); if ( Has     (text, true        )) text.ToString(); }
        { string?        text = Text(); if ( Has     (text, spaceMatters)) text.ToString(); }
        { string?        text = Text(); if ( Has     (              text)) text.ToString(); }
        { string?        text = Text(); if ( Has     (true,         text)) text.ToString(); }
        { string?        text = Text(); if ( Has     (spaceMatters, text)) text.ToString(); }
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Has_NotNullWhen_StringBuilder()
    {
        StringBuilder? SB() => NullyFilledSB;

        { StringBuilder? sb   = SB  (); if ( Has     (sb                )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb,   true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (sb,   spaceMatters)) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (              sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (true,         sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( Has     (spaceMatters, sb  )) sb  .ToString(); }
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Has_NotNullWhen_Bool()
    {
        bool? Bool() => NullyTrue;

        { bool?          boo  = Bool(); if ( Has     (boo               )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (boo,  true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (boo,  zeroMatters )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (              boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (true,         boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( Has     (zeroMatters,  boo )) boo = boo.Value; }
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Has_NotNullWhen_Value()
    {
        int? Num() => Nully1;

        { int?           num  = Num (); if ( Has     (num               )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (num,  true        )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (num,  zeroMatters )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (              num )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (true,         num )) num = num.Value; }
        { int?           num  = Num (); if ( Has     (zeroMatters,  num )) num = num.Value; }
    }
}