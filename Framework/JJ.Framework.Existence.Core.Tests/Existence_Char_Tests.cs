namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Char_Tests
{
    // Char

    readonly char? NullChar              = null;
    const    char  DefaultChar           = default;
    readonly char? DefaultNullyChar      = default;
    const    char  NewChar               = new();
    readonly char? NewNullyChar          = new();
    const    char  ZeroValueChar         = '\0';
    readonly char? ZeroValueNullyChar    = '\0';
    const    char  ZeroDigitChar         = '0';
    readonly char? ZeroDigitNullyChar    = '0';
    const    char  SpaceChar             = ' ';
    readonly char? NullySpaceChar        = '\t';
    const    char  ControlChar           = '\u0001';
    readonly char? NullyControlChar      = '\u0001';
    const    char  SpecialSpace          = '\u2003';
    readonly char? NullySpecialSpace     = '\u2003';
    const    char  ZeroWidthSpace        = '\u200B';
    readonly char? NullyZeroWidthSpace   = '\u200B';
    const    char  NonBreakingSpace      = '\u00A0';
    readonly char? NullyNonBreakingSpace = '\u00A0';
    const    char  HighSurrogate         = '\uD83D'; // Special char used in UTF-16 to help encode values outside the UTF-16 range.
    readonly char? NullyHighSurrogate    = '\uD83D'; // Special char used in UTF-16 to help encode values outside the UTF-16 range.
    const    char  FilledChar             = 'a';
    readonly char? NullyFilledChar        = 'a';

    [TestMethod]
    public void Test_Char_Has()
    {
        // Obviously not filled
        IsFalse(Has(NullChar                ));
        IsFalse(Has(DefaultChar             ));
        IsFalse(Has(DefaultNullyChar        ));
        IsFalse(Has(NewChar                 ));
        IsFalse(Has(NewNullyChar            ));
        IsFalse(Has(ZeroValueChar           ));
        IsFalse(Has(ZeroValueNullyChar      ));
        // Filled
        IsTrue (Has(ZeroDigitChar           ));
        IsTrue (Has(ZeroDigitNullyChar      ));
        IsTrue (Has(FilledChar              ));
        IsTrue (Has(NullyFilledChar         ));
    }
    
    [TestMethod]
    public void Test_Char_FilledIn()
    {
        // Obviously not filled
        IsFalse(FilledIn(NullChar           ));
        IsFalse(FilledIn(DefaultChar        ));
        IsFalse(FilledIn(DefaultNullyChar   ));
        IsFalse(FilledIn(NewChar            ));
        IsFalse(FilledIn(NewNullyChar       ));
        IsFalse(FilledIn(ZeroValueChar      ));
        IsFalse(FilledIn(ZeroValueNullyChar ));
        IsFalse(NullChar          .FilledIn());
        IsFalse(DefaultChar       .FilledIn());
        IsFalse(DefaultNullyChar  .FilledIn());
        IsFalse(NewChar           .FilledIn());
        IsFalse(NewNullyChar      .FilledIn());
        IsFalse(ZeroValueChar     .FilledIn());
        IsFalse(ZeroValueNullyChar.FilledIn());
        // Filled
        IsTrue (FilledIn(ZeroDigitChar      ));
        IsTrue (FilledIn(ZeroDigitNullyChar ));
        IsTrue (FilledIn(FilledChar         ));
        IsTrue (FilledIn(NullyFilledChar    ));
        IsTrue (ZeroDigitChar     .FilledIn());
        IsTrue (ZeroDigitNullyChar.FilledIn());
        IsTrue (FilledChar        .FilledIn());
        IsTrue (NullyFilledChar   .FilledIn());
    }

    [TestMethod]
    public void Test_Char_IsNully()
    {
        // Obviously not filled
        IsTrue (IsNully (NullChar           ));
        IsTrue (IsNully (DefaultChar        ));
        IsTrue (IsNully (DefaultNullyChar   ));
        IsTrue (IsNully (NewChar            ));
        IsTrue (IsNully (NewNullyChar       ));
        IsTrue (IsNully (ZeroValueChar      ));
        IsTrue (IsNully (ZeroValueNullyChar ));
        IsTrue (NullChar          .IsNully( ));
        IsTrue (DefaultChar       .IsNully( ));
        IsTrue (DefaultNullyChar  .IsNully( ));
        IsTrue (NewChar           .IsNully( ));
        IsTrue (NewNullyChar      .IsNully( ));
        IsTrue (ZeroValueChar     .IsNully( ));
        IsTrue (ZeroValueNullyChar.IsNully( ));
        // Filled
        IsFalse(IsNully (ZeroDigitChar      ));
        IsFalse(IsNully (ZeroDigitNullyChar ));
        IsFalse(IsNully (FilledChar         ));
        IsFalse(IsNully (NullyFilledChar    ));
        IsFalse(ZeroDigitChar     .IsNully( ));
        IsFalse(ZeroDigitNullyChar.IsNully( ));
        IsFalse(FilledChar        .IsNully( ));
        IsFalse(NullyFilledChar   .IsNully( ));
    }

    [TestMethod]
    public void Test_Char_Coalesce()
    {
        NoNullRet('a', Coalesce(NullChar, ZeroValueChar, NullyFilledChar, 'b'));
    }
        
    [TestMethod]
    public void Test_Char_Has_ZeroMatters()
    {
        // Sometimes filled when zeroMatters
        IsFalse(Has     (NullChar                              ));
        IsFalse(Has     (NullChar,           zeroMatters: false));
        IsFalse(Has     (NullChar,                        false));
        IsFalse(Has     (NullChar,           zeroMatters       ));
        IsFalse(Has     (NullChar,           zeroMatters: true ));
        IsFalse(Has     (NullChar,                        true ));
        IsFalse(Has     (DefaultChar                           ));
        IsFalse(Has     (DefaultChar,        zeroMatters: false));
        IsFalse(Has     (DefaultChar,                     false));
        IsTrue (Has     (DefaultChar,        zeroMatters       ));
        IsTrue (Has     (DefaultChar,        zeroMatters: true ));
        IsTrue (Has     (DefaultChar,                     true ));
        IsFalse(Has     (DefaultNullyChar                      ));
        IsFalse(Has     (DefaultNullyChar,   zeroMatters: false));
        IsFalse(Has     (DefaultNullyChar,                false));
        IsFalse(Has     (DefaultNullyChar,   zeroMatters       ));
        IsFalse(Has     (DefaultNullyChar,   zeroMatters: true ));
        IsFalse(Has     (DefaultNullyChar,                true ));
        IsFalse(Has     (NewChar                               ));
        IsFalse(Has     (NewChar,            zeroMatters: false));
        IsFalse(Has     (NewChar,                         false));
        IsTrue (Has     (NewChar,            zeroMatters       ));
        IsTrue (Has     (NewChar,            zeroMatters: true ));
        IsTrue (Has     (NewChar,                         true ));
        IsFalse(Has     (NewNullyChar                          ));
        IsFalse(Has     (NewNullyChar,       zeroMatters: false));
        IsFalse(Has     (NewNullyChar,                    false));
        IsTrue (Has     (NewNullyChar,       zeroMatters       ));
        IsTrue (Has     (NewNullyChar,       zeroMatters: true ));
        IsTrue (Has     (NewNullyChar,                    true ));
        IsFalse(Has     (ZeroValueChar                         ));
        IsFalse(Has     (ZeroValueChar,      zeroMatters: false));
        IsFalse(Has     (ZeroValueChar,                   false));
        IsTrue (Has     (ZeroValueChar,      zeroMatters       ));
        IsTrue (Has     (ZeroValueChar,      zeroMatters: true ));
        IsTrue (Has     (ZeroValueChar,                   true ));
        IsFalse(Has     (ZeroValueNullyChar                    ));
        IsFalse(Has     (ZeroValueNullyChar, zeroMatters: false));
        IsFalse(Has     (ZeroValueNullyChar,              false));
        IsTrue (Has     (ZeroValueNullyChar, zeroMatters       ));
        IsTrue (Has     (ZeroValueNullyChar, zeroMatters: true ));
        IsTrue (Has     (ZeroValueNullyChar,              true ));

        // Filled
        IsTrue (Has     (ZeroDigitChar                         ));
        IsTrue (Has     (ZeroDigitChar,      zeroMatters: false));
        IsTrue (Has     (ZeroDigitChar,                   false));
        IsTrue (Has     (ZeroDigitChar,      zeroMatters       ));
        IsTrue (Has     (ZeroDigitChar,      zeroMatters: true ));
        IsTrue (Has     (ZeroDigitChar,                   true ));
        IsTrue (Has     (ZeroDigitNullyChar                    ));
        IsTrue (Has     (ZeroDigitNullyChar, zeroMatters: false));
        IsTrue (Has     (ZeroDigitNullyChar,              false));
        IsTrue (Has     (ZeroDigitNullyChar, zeroMatters       ));
        IsTrue (Has     (ZeroDigitNullyChar, zeroMatters: true ));
        IsTrue (Has     (ZeroDigitNullyChar,              true ));
        IsTrue (Has     (FilledChar                            ));
        IsTrue (Has     (FilledChar,         zeroMatters: false));
        IsTrue (Has     (FilledChar,                      false));
        IsTrue (Has     (FilledChar,         zeroMatters       ));
        IsTrue (Has     (FilledChar,         zeroMatters: true ));
        IsTrue (Has     (FilledChar,                      true ));
        IsTrue (Has     (NullyFilledChar                       ));
        IsTrue (Has     (NullyFilledChar,    zeroMatters: false));
        IsTrue (Has     (NullyFilledChar,                 false));
        IsTrue (Has     (NullyFilledChar,    zeroMatters       ));
        IsTrue (Has     (NullyFilledChar,    zeroMatters: true ));
        IsTrue (Has     (NullyFilledChar,                 true ));
    }
        
    [TestMethod]
    public void Test_Char_FilledIn_ZeroMatters()
    {
        // Sometimes filled when zeroMatters
        IsFalse(FilledIn(NullChar                              ));
        IsFalse(FilledIn(NullChar,           zeroMatters: false));
        IsFalse(FilledIn(NullChar,                        false));
        IsFalse(FilledIn(NullChar,           zeroMatters       ));
        IsFalse(FilledIn(NullChar,           zeroMatters: true ));
        IsFalse(FilledIn(NullChar,                        true ));
        IsFalse(FilledIn(DefaultChar                           ));
        IsFalse(FilledIn(DefaultChar,        zeroMatters: false));
        IsFalse(FilledIn(DefaultChar,                     false));
        IsTrue (FilledIn(DefaultChar,        zeroMatters       ));
        IsTrue (FilledIn(DefaultChar,        zeroMatters: true ));
        IsTrue (FilledIn(DefaultChar,                     true ));
        IsFalse(FilledIn(DefaultNullyChar                      ));
        IsFalse(FilledIn(DefaultNullyChar,   zeroMatters: false));
        IsFalse(FilledIn(DefaultNullyChar,                false));
        IsFalse(FilledIn(DefaultNullyChar,   zeroMatters       ));
        IsFalse(FilledIn(DefaultNullyChar,   zeroMatters: true ));
        IsFalse(FilledIn(DefaultNullyChar,                true ));
        IsFalse(FilledIn(NewChar                               ));
        IsFalse(FilledIn(NewChar,            zeroMatters: false));
        IsFalse(FilledIn(NewChar,                         false));
        IsTrue (FilledIn(NewChar,            zeroMatters       ));
        IsTrue (FilledIn(NewChar,            zeroMatters: true ));
        IsTrue (FilledIn(NewChar,                         true ));
        IsFalse(FilledIn(NewNullyChar                          ));
        IsFalse(FilledIn(NewNullyChar,       zeroMatters: false));
        IsFalse(FilledIn(NewNullyChar,                    false));
        IsTrue (FilledIn(NewNullyChar,       zeroMatters       ));
        IsTrue (FilledIn(NewNullyChar,       zeroMatters: true ));
        IsTrue (FilledIn(NewNullyChar,                    true ));
        IsFalse(FilledIn(ZeroValueChar                         ));
        IsFalse(FilledIn(ZeroValueChar,      zeroMatters: false));
        IsFalse(FilledIn(ZeroValueChar,                   false));
        IsTrue (FilledIn(ZeroValueChar,      zeroMatters       ));
        IsTrue (FilledIn(ZeroValueChar,      zeroMatters: true ));
        IsTrue (FilledIn(ZeroValueChar,                   true ));
        IsFalse(FilledIn(ZeroValueNullyChar                    ));
        IsFalse(FilledIn(ZeroValueNullyChar, zeroMatters: false));
        IsFalse(FilledIn(ZeroValueNullyChar,              false));
        IsTrue (FilledIn(ZeroValueNullyChar, zeroMatters       ));
        IsTrue (FilledIn(ZeroValueNullyChar, zeroMatters: true ));
        IsTrue (FilledIn(ZeroValueNullyChar,              true ));
        IsFalse(NullChar          .FilledIn(                   ));
        IsFalse(NullChar          .FilledIn( zeroMatters: false));
        IsFalse(NullChar          .FilledIn(              false));
        IsFalse(NullChar          .FilledIn( zeroMatters       ));
        IsFalse(NullChar          .FilledIn( zeroMatters: true ));
        IsFalse(NullChar          .FilledIn(              true ));
        IsFalse(DefaultChar       .FilledIn(                   ));
        IsFalse(DefaultChar       .FilledIn( zeroMatters: false));
        IsFalse(DefaultChar       .FilledIn(              false));
        IsTrue (DefaultChar       .FilledIn( zeroMatters       ));
        IsTrue (DefaultChar       .FilledIn( zeroMatters: true ));
        IsTrue (DefaultChar       .FilledIn(              true ));
        IsFalse(DefaultNullyChar  .FilledIn(                   ));
        IsFalse(DefaultNullyChar  .FilledIn( zeroMatters: false));
        IsFalse(DefaultNullyChar  .FilledIn(              false));
        IsFalse(DefaultNullyChar  .FilledIn( zeroMatters       ));
        IsFalse(DefaultNullyChar  .FilledIn( zeroMatters: true ));
        IsFalse(DefaultNullyChar  .FilledIn(              true ));
        IsFalse(NewChar           .FilledIn(                   ));
        IsFalse(NewChar           .FilledIn( zeroMatters: false));
        IsFalse(NewChar           .FilledIn(              false));
        IsTrue (NewChar           .FilledIn( zeroMatters       ));
        IsTrue (NewChar           .FilledIn( zeroMatters: true ));
        IsTrue (NewChar           .FilledIn(              true ));
        IsFalse(NewNullyChar      .FilledIn(                   ));
        IsFalse(NewNullyChar      .FilledIn( zeroMatters: false));
        IsFalse(NewNullyChar      .FilledIn(              false));
        IsTrue (NewNullyChar      .FilledIn( zeroMatters       ));
        IsTrue (NewNullyChar      .FilledIn( zeroMatters: true ));
        IsTrue (NewNullyChar      .FilledIn(              true ));
        IsFalse(ZeroValueChar     .FilledIn(                   ));
        IsFalse(ZeroValueChar     .FilledIn( zeroMatters: false));
        IsFalse(ZeroValueChar     .FilledIn(              false));
        IsTrue (ZeroValueChar     .FilledIn( zeroMatters       ));
        IsTrue (ZeroValueChar     .FilledIn( zeroMatters: true ));
        IsTrue (ZeroValueChar     .FilledIn(              true ));
        IsFalse(ZeroValueNullyChar.FilledIn(                   ));
        IsFalse(ZeroValueNullyChar.FilledIn( zeroMatters: false));
        IsFalse(ZeroValueNullyChar.FilledIn(              false));
        IsTrue (ZeroValueNullyChar.FilledIn( zeroMatters       ));
        IsTrue (ZeroValueNullyChar.FilledIn( zeroMatters: true ));
        IsTrue (ZeroValueNullyChar.FilledIn(              true ));

        // Filled
        IsTrue (FilledIn(ZeroDigitChar                         ));
        IsTrue (FilledIn(ZeroDigitChar,      zeroMatters: false));
        IsTrue (FilledIn(ZeroDigitChar,                   false));
        IsTrue (FilledIn(ZeroDigitChar,      zeroMatters       ));
        IsTrue (FilledIn(ZeroDigitChar,      zeroMatters: true ));
        IsTrue (FilledIn(ZeroDigitChar,                   true ));
        IsTrue (FilledIn(ZeroDigitNullyChar                    ));
        IsTrue (FilledIn(ZeroDigitNullyChar, zeroMatters: false));
        IsTrue (FilledIn(ZeroDigitNullyChar,              false));
        IsTrue (FilledIn(ZeroDigitNullyChar, zeroMatters       ));
        IsTrue (FilledIn(ZeroDigitNullyChar, zeroMatters: true ));
        IsTrue (FilledIn(ZeroDigitNullyChar,              true ));
        IsTrue (FilledIn(FilledChar                            ));
        IsTrue (FilledIn(FilledChar,         zeroMatters: false));
        IsTrue (FilledIn(FilledChar,                      false));
        IsTrue (FilledIn(FilledChar,         zeroMatters       ));
        IsTrue (FilledIn(FilledChar,         zeroMatters: true ));
        IsTrue (FilledIn(FilledChar,                      true ));
        IsTrue (FilledIn(NullyFilledChar                       ));
        IsTrue (FilledIn(NullyFilledChar,    zeroMatters: false));
        IsTrue (FilledIn(NullyFilledChar,                 false));
        IsTrue (FilledIn(NullyFilledChar,    zeroMatters       ));
        IsTrue (FilledIn(NullyFilledChar,    zeroMatters: true ));
        IsTrue (FilledIn(NullyFilledChar,                 true ));
        IsTrue (ZeroDigitChar     .FilledIn(                   ));
        IsTrue (ZeroDigitChar     .FilledIn( zeroMatters: false));
        IsTrue (ZeroDigitChar     .FilledIn(              false));
        IsTrue (ZeroDigitChar     .FilledIn( zeroMatters       ));
        IsTrue (ZeroDigitChar     .FilledIn( zeroMatters: true ));
        IsTrue (ZeroDigitChar     .FilledIn(              true ));
        IsTrue (ZeroDigitNullyChar.FilledIn(                   ));
        IsTrue (ZeroDigitNullyChar.FilledIn( zeroMatters: false));
        IsTrue (ZeroDigitNullyChar.FilledIn(              false));
        IsTrue (ZeroDigitNullyChar.FilledIn( zeroMatters       ));
        IsTrue (ZeroDigitNullyChar.FilledIn( zeroMatters: true ));
        IsTrue (ZeroDigitNullyChar.FilledIn(              true ));
        IsTrue (FilledChar        .FilledIn(                   ));
        IsTrue (FilledChar        .FilledIn( zeroMatters: false));
        IsTrue (FilledChar        .FilledIn(              false));
        IsTrue (FilledChar        .FilledIn( zeroMatters       ));
        IsTrue (FilledChar        .FilledIn( zeroMatters: true ));
        IsTrue (FilledChar        .FilledIn(              true ));
        IsTrue (NullyFilledChar   .FilledIn(                   ));
        IsTrue (NullyFilledChar   .FilledIn( zeroMatters: false));
        IsTrue (NullyFilledChar   .FilledIn(              false));
        IsTrue (NullyFilledChar   .FilledIn( zeroMatters       ));
        IsTrue (NullyFilledChar   .FilledIn( zeroMatters: true ));
        IsTrue (NullyFilledChar   .FilledIn(              true ));
    }
        
    [TestMethod]
    public void Test_Char_IsNully_ZeroMatters()
    {
        // Sometimes filled when zeroMatters
        IsTrue (IsNully (NullChar                              ));
        IsTrue (IsNully (NullChar,           zeroMatters: false));
        IsTrue (IsNully (NullChar,                        false));
        IsTrue (IsNully (NullChar,           zeroMatters       ));
        IsTrue (IsNully (NullChar,           zeroMatters: true ));
        IsTrue (IsNully (NullChar,                        true ));
        IsTrue (IsNully (DefaultChar                           ));
        IsTrue (IsNully (DefaultChar,        zeroMatters: false));
        IsTrue (IsNully (DefaultChar,                     false));
        IsFalse(IsNully (DefaultChar,        zeroMatters       ));
        IsFalse(IsNully (DefaultChar,        zeroMatters: true ));
        IsFalse(IsNully (DefaultChar,                     true ));
        IsTrue (IsNully (DefaultNullyChar                      ));
        IsTrue (IsNully (DefaultNullyChar,   zeroMatters: false));
        IsTrue (IsNully (DefaultNullyChar,                false));
        IsTrue (IsNully (DefaultNullyChar,   zeroMatters       ));
        IsTrue (IsNully (DefaultNullyChar,   zeroMatters: true ));
        IsTrue (IsNully (DefaultNullyChar,                true ));
        IsTrue (IsNully (NewChar                               ));
        IsTrue (IsNully (NewChar,            zeroMatters: false));
        IsTrue (IsNully (NewChar,                         false));
        IsFalse(IsNully (NewChar,            zeroMatters       ));
        IsFalse(IsNully (NewChar,            zeroMatters: true ));
        IsFalse(IsNully (NewChar,                         true ));
        IsTrue (IsNully (NewNullyChar                          ));
        IsTrue (IsNully (NewNullyChar,       zeroMatters: false));
        IsTrue (IsNully (NewNullyChar,                    false));
        IsFalse(IsNully (NewNullyChar,       zeroMatters       ));
        IsFalse(IsNully (NewNullyChar,       zeroMatters: true ));
        IsFalse(IsNully (NewNullyChar,                    true ));
        IsTrue (IsNully (ZeroValueChar                         ));
        IsTrue (IsNully (ZeroValueChar,      zeroMatters: false));
        IsTrue (IsNully (ZeroValueChar,                   false));
        IsFalse(IsNully (ZeroValueChar,      zeroMatters       ));
        IsFalse(IsNully (ZeroValueChar,      zeroMatters: true ));
        IsFalse(IsNully (ZeroValueChar,                   true ));
        IsTrue (IsNully (ZeroValueNullyChar                    ));
        IsTrue (IsNully (ZeroValueNullyChar, zeroMatters: false));
        IsTrue (IsNully (ZeroValueNullyChar,              false));
        IsFalse(IsNully (ZeroValueNullyChar, zeroMatters       ));
        IsFalse(IsNully (ZeroValueNullyChar, zeroMatters: true ));
        IsFalse(IsNully (ZeroValueNullyChar,              true ));
        IsTrue (NullChar          .IsNully (                   ));
        IsTrue (NullChar          .IsNully ( zeroMatters: false));
        IsTrue (NullChar          .IsNully (              false));
        IsTrue (NullChar          .IsNully ( zeroMatters       ));
        IsTrue (NullChar          .IsNully ( zeroMatters: true ));
        IsTrue (NullChar          .IsNully (              true ));
        IsTrue (DefaultChar       .IsNully (                   ));
        IsTrue (DefaultChar       .IsNully ( zeroMatters: false));
        IsTrue (DefaultChar       .IsNully (              false));
        IsFalse(DefaultChar       .IsNully ( zeroMatters       ));
        IsFalse(DefaultChar       .IsNully ( zeroMatters: true ));
        IsFalse(DefaultChar       .IsNully (              true ));
        IsTrue (DefaultNullyChar  .IsNully (                   ));
        IsTrue (DefaultNullyChar  .IsNully ( zeroMatters: false));
        IsTrue (DefaultNullyChar  .IsNully (              false));
        IsTrue (DefaultNullyChar  .IsNully ( zeroMatters       ));
        IsTrue (DefaultNullyChar  .IsNully ( zeroMatters: true ));
        IsTrue (DefaultNullyChar  .IsNully (              true ));
        IsTrue (NewChar           .IsNully (                   ));
        IsTrue (NewChar           .IsNully ( zeroMatters: false));
        IsTrue (NewChar           .IsNully (              false));
        IsFalse(NewChar           .IsNully ( zeroMatters       ));
        IsFalse(NewChar           .IsNully ( zeroMatters: true ));
        IsFalse(NewChar           .IsNully (              true ));
        IsTrue (NewNullyChar      .IsNully (                   ));
        IsTrue (NewNullyChar      .IsNully ( zeroMatters: false));
        IsTrue (NewNullyChar      .IsNully (              false));
        IsFalse(NewNullyChar      .IsNully ( zeroMatters       ));
        IsFalse(NewNullyChar      .IsNully ( zeroMatters: true ));
        IsFalse(NewNullyChar      .IsNully (              true ));
        IsTrue (ZeroValueChar     .IsNully (                   ));
        IsTrue (ZeroValueChar     .IsNully ( zeroMatters: false));
        IsTrue (ZeroValueChar     .IsNully (              false));
        IsFalse(ZeroValueChar     .IsNully ( zeroMatters       ));
        IsFalse(ZeroValueChar     .IsNully ( zeroMatters: true ));
        IsFalse(ZeroValueChar     .IsNully (              true ));
        IsTrue (ZeroValueNullyChar.IsNully (                   ));
        IsTrue (ZeroValueNullyChar.IsNully ( zeroMatters: false));
        IsTrue (ZeroValueNullyChar.IsNully (              false));
        IsFalse(ZeroValueNullyChar.IsNully ( zeroMatters       ));
        IsFalse(ZeroValueNullyChar.IsNully ( zeroMatters: true ));
        IsFalse(ZeroValueNullyChar.IsNully (              true ));

        // Filled
        IsFalse(IsNully (ZeroDigitChar                         ));
        IsFalse(IsNully (ZeroDigitChar,      zeroMatters: false));
        IsFalse(IsNully (ZeroDigitChar,                   false));
        IsFalse(IsNully (ZeroDigitChar,      zeroMatters       ));
        IsFalse(IsNully (ZeroDigitChar,      zeroMatters: true ));
        IsFalse(IsNully (ZeroDigitChar,                   true ));
        IsFalse(IsNully (ZeroDigitNullyChar                    ));
        IsFalse(IsNully (ZeroDigitNullyChar, zeroMatters: false));
        IsFalse(IsNully (ZeroDigitNullyChar,              false));
        IsFalse(IsNully (ZeroDigitNullyChar, zeroMatters       ));
        IsFalse(IsNully (ZeroDigitNullyChar, zeroMatters: true ));
        IsFalse(IsNully (ZeroDigitNullyChar,              true ));
        IsFalse(IsNully (FilledChar                            ));
        IsFalse(IsNully (FilledChar,         zeroMatters: false));
        IsFalse(IsNully (FilledChar,                      false));
        IsFalse(IsNully (FilledChar,         zeroMatters       ));
        IsFalse(IsNully (FilledChar,         zeroMatters: true ));
        IsFalse(IsNully (FilledChar,                      true ));
        IsFalse(IsNully (NullyFilledChar                       ));
        IsFalse(IsNully (NullyFilledChar,    zeroMatters: false));
        IsFalse(IsNully (NullyFilledChar,                 false));
        IsFalse(IsNully (NullyFilledChar,    zeroMatters       ));
        IsFalse(IsNully (NullyFilledChar,    zeroMatters: true ));
        IsFalse(IsNully (NullyFilledChar,                 true ));
        IsFalse(ZeroDigitChar     .IsNully (                   ));
        IsFalse(ZeroDigitChar     .IsNully ( zeroMatters: false));
        IsFalse(ZeroDigitChar     .IsNully (              false));
        IsFalse(ZeroDigitChar     .IsNully ( zeroMatters       ));
        IsFalse(ZeroDigitChar     .IsNully ( zeroMatters: true ));
        IsFalse(ZeroDigitChar     .IsNully (              true ));
        IsFalse(ZeroDigitNullyChar.IsNully (                   ));
        IsFalse(ZeroDigitNullyChar.IsNully ( zeroMatters: false));
        IsFalse(ZeroDigitNullyChar.IsNully (              false));
        IsFalse(ZeroDigitNullyChar.IsNully ( zeroMatters       ));
        IsFalse(ZeroDigitNullyChar.IsNully ( zeroMatters: true ));
        IsFalse(ZeroDigitNullyChar.IsNully (              true ));
        IsFalse(FilledChar        .IsNully (                   ));
        IsFalse(FilledChar        .IsNully ( zeroMatters: false));
        IsFalse(FilledChar        .IsNully (              false));
        IsFalse(FilledChar        .IsNully ( zeroMatters       ));
        IsFalse(FilledChar        .IsNully ( zeroMatters: true ));
        IsFalse(FilledChar        .IsNully (              true ));
        IsFalse(NullyFilledChar   .IsNully (                   ));
        IsFalse(NullyFilledChar   .IsNully ( zeroMatters: false));
        IsFalse(NullyFilledChar   .IsNully (              false));
        IsFalse(NullyFilledChar   .IsNully ( zeroMatters       ));
        IsFalse(NullyFilledChar   .IsNully ( zeroMatters: true ));
        IsFalse(NullyFilledChar   .IsNully (              true ));
    }
    
    // TODO: Add more variants (FilledIn, extension methods, IsNully).

    [TestMethod]
    public void Test_Char_Coalesce_ZeroMatters()
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