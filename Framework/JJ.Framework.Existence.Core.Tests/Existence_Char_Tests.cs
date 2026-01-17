using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    // TODO: Add more variants (FilledIn, extension methods, IsNully).

    [TestMethod]
    public void Char_FilledIn_Tests()
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
    }

    [TestMethod]
    public void Char_Coalesce_Tests()
    {
        NoNullRet('a', Coalesce(NullChar, ZeroValueChar, NullyFilledChar, 'b'));
    }

    [TestMethod]
    public void Char_FilledIn_ZeroMatters_Tests()
    {
        // Sometimes filled when zeroMatters
        IsFalse(Has(NullChar                              ));
        IsFalse(Has(NullChar,           zeroMatters: false));
        IsFalse(Has(NullChar,                        false));
        IsFalse(Has(NullChar,           zeroMatters       ));
        IsFalse(Has(NullChar,           zeroMatters: true ));
        IsFalse(Has(NullChar,                        true ));
        IsFalse(Has(DefaultChar                           ));
        IsFalse(Has(DefaultChar,        zeroMatters: false));
        IsFalse(Has(DefaultChar,                     false));
        IsTrue (Has(DefaultChar,        zeroMatters       ));
        IsTrue (Has(DefaultChar,        zeroMatters: true ));
        IsTrue (Has(DefaultChar,                     true ));
        IsFalse(Has(DefaultNullyChar                      ));
        IsFalse(Has(DefaultNullyChar,   zeroMatters: false));
        IsFalse(Has(DefaultNullyChar,                false));
        IsFalse(Has(DefaultNullyChar,   zeroMatters       ));
        IsFalse(Has(DefaultNullyChar,   zeroMatters: true ));
        IsFalse(Has(DefaultNullyChar,                true ));
        IsFalse(Has(NewChar                               ));
        IsFalse(Has(NewChar,            zeroMatters: false));
        IsFalse(Has(NewChar,                         false));
        IsTrue (Has(NewChar,            zeroMatters       ));
        IsTrue (Has(NewChar,            zeroMatters: true ));
        IsTrue (Has(NewChar,                         true ));
        IsFalse(Has(NewNullyChar                          ));
        IsFalse(Has(NewNullyChar,       zeroMatters: false));
        IsFalse(Has(NewNullyChar,                    false));
        IsTrue (Has(NewNullyChar,       zeroMatters       ));
        IsTrue (Has(NewNullyChar,       zeroMatters: true ));
        IsTrue (Has(NewNullyChar,                    true ));
        IsFalse(Has(ZeroValueChar                         ));
        IsFalse(Has(ZeroValueChar,      zeroMatters: false));
        IsFalse(Has(ZeroValueChar,                   false));
        IsTrue (Has(ZeroValueChar,      zeroMatters       ));
        IsTrue (Has(ZeroValueChar,      zeroMatters: true ));
        IsTrue (Has(ZeroValueChar,                   true ));
        IsFalse(Has(ZeroValueNullyChar                    ));
        IsFalse(Has(ZeroValueNullyChar, zeroMatters: false));
        IsFalse(Has(ZeroValueNullyChar,              false));
        IsTrue (Has(ZeroValueNullyChar, zeroMatters       ));
        IsTrue (Has(ZeroValueNullyChar, zeroMatters: true ));
        IsTrue (Has(ZeroValueNullyChar,              true ));
        
        // Filled
        IsTrue (Has(ZeroDigitChar                         ));
        IsTrue (Has(ZeroDigitChar,      zeroMatters: false));
        IsTrue (Has(ZeroDigitChar,                   false));
        IsTrue (Has(ZeroDigitChar,      zeroMatters       ));
        IsTrue (Has(ZeroDigitChar,      zeroMatters: true ));
        IsTrue (Has(ZeroDigitChar,                   true ));
        IsTrue (Has(ZeroDigitNullyChar                    ));
        IsTrue (Has(ZeroDigitNullyChar, zeroMatters: false));
        IsTrue (Has(ZeroDigitNullyChar,              false));
        IsTrue (Has(ZeroDigitNullyChar, zeroMatters       ));
        IsTrue (Has(ZeroDigitNullyChar, zeroMatters: true ));
        IsTrue (Has(ZeroDigitNullyChar,              true ));
        IsTrue (Has(FilledChar                            ));
        IsTrue (Has(FilledChar,         zeroMatters: false));
        IsTrue (Has(FilledChar,                      false));
        IsTrue (Has(FilledChar,         zeroMatters       ));
        IsTrue (Has(FilledChar,         zeroMatters: true ));
        IsTrue (Has(FilledChar,                      true ));
        IsTrue (Has(NullyFilledChar                       ));
        IsTrue (Has(NullyFilledChar,    zeroMatters: false));
        IsTrue (Has(NullyFilledChar,                 false));
        IsTrue (Has(NullyFilledChar,    zeroMatters       ));
        IsTrue (Has(NullyFilledChar,    zeroMatters: true ));
        IsTrue (Has(NullyFilledChar,                 true ));
    }

    [TestMethod]
    public void Char_Coalesce_ZeroMatters_Tests()
    {
        NoNullRet(FilledChar,    Coalesce(                    NullChar, ZeroValueChar, NullyFilledChar, 'b'));
        NoNullRet(FilledChar,    Coalesce(zeroMatters: false, NullChar, ZeroValueChar, NullyFilledChar, 'b'));
        NoNullRet(FilledChar,    Coalesce(             false, NullChar, ZeroValueChar, NullyFilledChar, 'b'));
        NoNullRet(ZeroValueChar, Coalesce(zeroMatters,        NullChar, ZeroValueChar, NullyFilledChar, 'b'));
        NoNullRet(ZeroValueChar, Coalesce(zeroMatters: true,  NullChar, ZeroValueChar, NullyFilledChar, 'b'));
        NoNullRet(ZeroValueChar, Coalesce(             true,  NullChar, ZeroValueChar, NullyFilledChar, 'b'));
    }

    [TestMethod]
    public void BUG_Char_Existence_DoesNotBehaveAsString()
    {
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