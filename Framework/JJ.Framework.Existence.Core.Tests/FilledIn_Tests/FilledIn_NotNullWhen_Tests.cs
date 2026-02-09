// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Tests;

/// <inheritdoc cref="_notnullwhentests" />
[TestClass]
public class FilledIn_NotNullWhen_Tests : TestBase
{
    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_FilledIn_NotNullWhen()
    {
        string       ? Text() => NullyFilledText;
        StringBuilder? SB  () => NullyFilledSB;
        int          ? Num () => Nully1;
        bool         ? Bool() => NullyTrue;

        { string?        text = Text(); if ( FilledIn(text              )) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(text, true        )) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(text, spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(sb                )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(sb,   true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(sb,   spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( FilledIn(boo               )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(boo,  true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(boo,  zeroMatters )) boo = boo.Value; }
        { int?           num  = Num (); if ( FilledIn(num               )) num = num.Value; }
        { int?           num  = Num (); if ( FilledIn(num,  true        )) num = num.Value; }
        { int?           num  = Num (); if ( FilledIn(num,  zeroMatters )) num = num.Value; }
        { string?        text = Text(); if ( FilledIn(              text)) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(true,         text)) text.ToString(); }
        { string?        text = Text(); if ( FilledIn(spaceMatters, text)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(              sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(true,         sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( FilledIn(spaceMatters, sb  )) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( FilledIn(              boo )) boo =boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(true,         boo )) boo =boo.Value; }
        { bool?          boo  = Bool(); if ( FilledIn(zeroMatters,  boo )) boo =boo.Value; }
        { int?           num  = Num (); if ( FilledIn(              num )) num =num.Value; }
        { int?           num  = Num (); if ( FilledIn(true,         num )) num =num.Value; }
        { int?           num  = Num (); if ( FilledIn(zeroMatters,  num )) num =num.Value; }
        { string?        text = Text(); if ( text.FilledIn(             )) text.ToString(); }
        { string?        text = Text(); if ( text.FilledIn( true        )) text.ToString(); }
        { string?        text = Text(); if ( text.FilledIn( spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if ( sb  .FilledIn(             )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( sb  .FilledIn( true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if ( sb  .FilledIn( spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if ( boo .FilledIn(             )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( boo .FilledIn( true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if ( boo .FilledIn(             )) boo = boo.Value; }
        { int?           num  = Num (); if ( num .FilledIn(             )) num = num.Value; }
        { int?           num  = Num (); if ( num .FilledIn( true        )) num = num.Value; }
        { int?           num  = Num (); if ( num .FilledIn(             )) num = num.Value; }
    }
}