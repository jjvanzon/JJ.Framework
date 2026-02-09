// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_NotNullWhen_Tests : TestBase
{
    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Test_IsNully_NotNullWhen()
    {
        string       ? Text() => NullyFilledText;
        StringBuilder? SB  () => NullyFilledSB;
        int          ? Num () => Nully1;
        bool         ? Bool() => NullyTrue;

        { string?        text = Text(); if (!IsNully (text              )) text.ToString(); }
        { string?        text = Text(); if (!IsNully (text, true        )) text.ToString(); }
        { string?        text = Text(); if (!IsNully (text, spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (sb                )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (sb,   true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (sb,   spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if (!IsNully (boo               )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (boo,  true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (boo,  zeroMatters )) boo = boo.Value; }
        { int?           num  = Num (); if (!IsNully (num               )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (num,  true        )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (num,  zeroMatters )) num = num.Value; }
        { string?        text = Text(); if (!IsNully (              text)) text.ToString(); }
        { string?        text = Text(); if (!IsNully (true,         text)) text.ToString(); }
        { string?        text = Text(); if (!IsNully (spaceMatters, text)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (              sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (true,         sb  )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!IsNully (spaceMatters, sb  )) sb  .ToString(); }
        { bool?          boo  = Bool(); if (!IsNully (              boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (true,         boo )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!IsNully (zeroMatters,  boo )) boo = boo.Value; }
        { int?           num  = Num (); if (!IsNully (              num )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (true,         num )) num = num.Value; }
        { int?           num  = Num (); if (!IsNully (zeroMatters,  num )) num = num.Value; }
        { string?        text = Text(); if (!text .IsNully(             )) text.ToString(); }
        { string?        text = Text(); if (!text .IsNully( true        )) text.ToString(); }
        { string?        text = Text(); if (!text .IsNully( spaceMatters)) text.ToString(); }
        { StringBuilder? sb   = SB  (); if (!sb   .IsNully(             )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!sb   .IsNully( true        )) sb  .ToString(); }
        { StringBuilder? sb   = SB  (); if (!sb   .IsNully( spaceMatters)) sb  .ToString(); }
        { bool?          boo  = Bool(); if (!boo  .IsNully(             )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!boo  .IsNully( true        )) boo = boo.Value; }
        { bool?          boo  = Bool(); if (!boo  .IsNully(             )) boo = boo.Value; }
        { int?           num  = Num (); if (!num  .IsNully(             )) num = num.Value; }
        { int?           num  = Num (); if (!num  .IsNully( true        )) num = num.Value; }
        { int?           num  = Num (); if (!num  .IsNully(             )) num = num.Value; }
    }
}