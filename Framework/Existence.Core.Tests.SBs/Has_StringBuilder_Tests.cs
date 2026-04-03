// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace JJ.Framework.Existence.Core.SBs.Tests;

[TestClass]
public class Has_StringBuilder_Tests : TestBase
{
    [TestMethod]
    public void Has_StringBuilder_True()
    {
        IsTrue(Has(FilledSB     ));
        IsTrue(Has(NullyFilledSB));
    }

    [TestMethod]
    public void Has_StringBuilder_False()
    {
        IsFalse(Has(NullSB      ));
        IsFalse(Has(NewSB       ));
        IsFalse(Has(NullyNewSB  ));
        IsFalse(Has(EmptySB     ));
        IsFalse(Has(NullyEmptySB));
        IsFalse(Has(SpaceSB     ));
        IsFalse(Has(NullySpaceSB));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMattersNo_FlagsInBack()
    {
        IsFalse(Has(NullSB                                  ));
        IsFalse(Has(NullSB,              spaceMatters: false));
        IsFalse(Has(NullSB,                            false));
        IsFalse(Has(NewSB                                   ));
        IsFalse(Has(NewSB,               spaceMatters: false));
        IsFalse(Has(NewSB,                             false));
        IsFalse(Has(NullyNewSB                              ));
        IsFalse(Has(NullyNewSB,          spaceMatters: false));
        IsFalse(Has(NullyNewSB,                        false));
        IsFalse(Has(SpaceSB                                 ));
        IsFalse(Has(SpaceSB,             spaceMatters: false));
        IsFalse(Has(SpaceSB,                           false));
        IsFalse(Has(NullySpaceSB                            ));
        IsFalse(Has(NullySpaceSB,        spaceMatters: false));
        IsFalse(Has(NullySpaceSB,                      false));
        IsTrue (Has(FilledSB                                ));
        IsTrue (Has(FilledSB,            spaceMatters: false));
        IsTrue (Has(FilledSB,                          false));
        IsTrue (Has(NullyFilledSB                           ));
        IsTrue (Has(NullyFilledSB,       spaceMatters: false));
        IsTrue (Has(NullyFilledSB,                     false));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMattersNo_FlagsInFront()
    {
        IsFalse(Has(                     NullSB             ));
        IsFalse(Has(spaceMatters: false, NullSB             ));
        IsFalse(Has(              false, NullSB             ));
        IsFalse(Has(                     NewSB              ));
        IsFalse(Has(spaceMatters: false, NewSB              ));
        IsFalse(Has(              false, NewSB              ));
        IsFalse(Has(                     NullyNewSB         ));
        IsFalse(Has(spaceMatters: false, NullyNewSB         ));
        IsFalse(Has(              false, NullyNewSB         ));
        IsFalse(Has(                     SpaceSB            ));
        IsFalse(Has(spaceMatters: false, SpaceSB            ));
        IsFalse(Has(              false, SpaceSB            ));
        IsFalse(Has(                     NullySpaceSB       ));
        IsFalse(Has(spaceMatters: false, NullySpaceSB       ));
        IsFalse(Has(              false, NullySpaceSB       ));
        IsTrue (Has(                     FilledSB           ));
        IsTrue (Has(spaceMatters: false, FilledSB           ));
        IsTrue (Has(              false, FilledSB           ));
        IsTrue (Has(                     NullyFilledSB      ));
        IsTrue (Has(spaceMatters: false, NullyFilledSB      ));
        IsTrue (Has(              false, NullyFilledSB      ));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMattersYes_FlagsInBack()
    {
        IsFalse(Has(NullSB,              spaceMatters       ));
        IsFalse(Has(NullSB,              spaceMatters: true ));
        IsFalse(Has(NullSB,                            true ));
        IsFalse(Has(NewSB,               spaceMatters       ));
        IsFalse(Has(NewSB,               spaceMatters: true ));
        IsFalse(Has(NewSB,                             true ));
        IsFalse(Has(EmptySB,             spaceMatters       ));
        IsFalse(Has(EmptySB,             spaceMatters: true ));
        IsFalse(Has(EmptySB,                           true ));
        IsFalse(Has(NullyEmptySB,        spaceMatters       ));
        IsFalse(Has(NullyEmptySB,        spaceMatters: true ));
        IsFalse(Has(NullyEmptySB,                      true ));
        IsTrue (Has(SpaceSB,             spaceMatters       ));
        IsTrue (Has(SpaceSB,             spaceMatters: true ));
        IsTrue (Has(SpaceSB,                           true ));
        IsTrue (Has(NullySpaceSB,        spaceMatters       ));
        IsTrue (Has(NullySpaceSB,        spaceMatters: true ));
        IsTrue (Has(NullySpaceSB,                      true ));
        IsTrue (Has(FilledSB,            spaceMatters       ));
        IsTrue (Has(FilledSB,            spaceMatters: true ));
        IsTrue (Has(FilledSB,                          true ));
        IsTrue (Has(NullyFilledSB,       spaceMatters       ));
        IsTrue (Has(NullyFilledSB,       spaceMatters: true ));
        IsTrue (Has(NullyFilledSB,                     true ));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMattersYes_FlagsInFront()
    {
        IsFalse(Has(spaceMatters,        NullSB             ));
        IsFalse(Has(spaceMatters: true,  NullSB             ));
        IsFalse(Has(              true,  NullSB             ));
        IsFalse(Has(spaceMatters,        NewSB              ));
        IsFalse(Has(spaceMatters: true,  NewSB              ));
        IsFalse(Has(              true,  NewSB              ));
        IsFalse(Has(spaceMatters,        EmptySB            ));
        IsFalse(Has(spaceMatters: true,  EmptySB            ));
        IsFalse(Has(              true,  EmptySB            ));
        IsFalse(Has(spaceMatters,        NullyEmptySB       ));
        IsFalse(Has(spaceMatters: true,  NullyEmptySB       ));
        IsFalse(Has(              true,  NullyEmptySB       ));
        IsTrue (Has(spaceMatters,        SpaceSB            ));
        IsTrue (Has(spaceMatters: true,  SpaceSB            ));
        IsTrue (Has(              true,  SpaceSB            ));
        IsTrue (Has(spaceMatters,        NullySpaceSB       ));
        IsTrue (Has(spaceMatters: true,  NullySpaceSB       ));
        IsTrue (Has(              true,  NullySpaceSB       ));
        IsTrue (Has(spaceMatters,        FilledSB           ));
        IsTrue (Has(spaceMatters: true,  FilledSB           ));
        IsTrue (Has(              true,  FilledSB           ));
        IsTrue (Has(spaceMatters,        NullyFilledSB      ));
        IsTrue (Has(spaceMatters: true,  NullyFilledSB      ));
        IsTrue (Has(              true,  NullyFilledSB      ));
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void Has_StringBuilder_NotNullWhen()
    {
        SB? SB() => NullyFilledSB;

        { SB? sb = SB(); if (Has(sb              )) sb.ToString(); }
        { SB? sb = SB(); if (Has(sb, true        )) sb.ToString(); }
        { SB? sb = SB(); if (Has(sb, spaceMatters)) sb.ToString(); }
        { SB? sb = SB(); if (Has(              sb)) sb.ToString(); }
        { SB? sb = SB(); if (Has(true,         sb)) sb.ToString(); }
        { SB? sb = SB(); if (Has(spaceMatters, sb)) sb.ToString(); }
    }
}