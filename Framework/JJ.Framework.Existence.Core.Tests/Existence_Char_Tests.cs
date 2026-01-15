namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Char_Tests
{
    // Char

    char? NullChar              = null;
    char  DefaultChar           = default;
    char? DefaultNullyChar      = default;
    char  NewChar               = new();
    char? NewNullyChar          = new();
    char  ZeroValueChar         = '\0';
    char? ZeroValueNullyChar    = '\0';
    char  ZeroDigitChar         = '0';
    char? ZeroDigitNullyChar    = '0';
    char  SpaceChar             = ' ';
    char? NullySpaceChar        = '\t';
    char  ControlChar           = '\u0001';
    char? NullyControlChar      = '\u0001';
    char  SpecialSpace          = '\u2003';
    char? NullySpecialSpace     = '\u2003';
    char  ZeroWidthSpace        = '\u200B';
    char? NullyZeroWidthSpace   = '\u200B';
    char  NonBreakingSpace      = '\u00A0';
    char? NullyNonBreakingSpace = '\u00A0';
    char  HighSurrogate         = '\uD83D'; // Special char used in UTF-16 to help encode values outside the UTF-16 range.
    char? NullyHighSurrogate    = '\uD83D'; // Special char used in UTF-16 to help encode values outside the UTF-16 range.
    char  FilledChar             = 'a';
    char? NullyFilledChar        = 'a';

    [TestMethod]
    public void Char_Existence_Tests()
    {
        // Obviously not filled
        IsFalse(Has(NullChar));
        IsFalse(Has(DefaultChar));
        IsFalse(Has(DefaultNullyChar));
        IsFalse(Has(NewChar));
        IsFalse(Has(NewNullyChar));
        IsFalse(Has(ZeroValueChar));
        IsFalse(Has(ZeroValueNullyChar));

        // Filled
        IsTrue (Has(ZeroDigitChar));
        IsTrue (Has(ZeroDigitNullyChar));
        IsTrue (Has(FilledChar));
        IsTrue (Has(NullyFilledChar));
        NoNullRet('a', Coalesce(NullChar, ZeroValueChar, NullyFilledChar, 'b'));

        // TODO: These should be false
        IsTrue (Has(SpaceChar));
        IsTrue (Has(NullySpaceChar));
        IsTrue (Has(ControlChar));
        IsTrue (Has(NullyControlChar));
        IsTrue (Has(SpecialSpace));
        IsTrue (Has(NullySpecialSpace));
        IsTrue (Has(ZeroWidthSpace));
        IsTrue (Has(NullyZeroWidthSpace));
        IsTrue (Has(NonBreakingSpace));
        IsTrue (Has(NullyNonBreakingSpace));
        IsTrue (Has(HighSurrogate));
        IsTrue (Has(NullyHighSurrogate));
    }
}