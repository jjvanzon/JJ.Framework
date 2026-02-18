// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace JJ.Framework.Existence.Core.SBs.Tests;

[TestClass]
public class FilledIn_StringBuilder_Tests : TestBase
{
    [TestMethod]
    public void FilledIn_StringBuilder_True_Extensions()
    {
        IsTrue(FilledSB     .FilledIn());
        IsTrue(NullyFilledSB.FilledIn());
    }

    [TestMethod]
    public void FilledIn_StringBuilder_True_Static()
    {
        IsTrue(FilledIn(FilledSB      ));
        IsTrue(FilledIn(NullyFilledSB ));
    }

    [TestMethod]
    public void FilledIn_StringBuilder_False_Extensions()
    {
        IsFalse(NullSB      .FilledIn());
        IsFalse(NewSB       .FilledIn());
        IsFalse(NullyNewSB  .FilledIn());
        IsFalse(EmptySB     .FilledIn());
        IsFalse(SpaceSB     .FilledIn());
        IsFalse(NullyEmptySB.FilledIn());
        IsFalse(NullySpaceSB.FilledIn());
    }

    [TestMethod]
    public void FilledIn_StringBuilder_False_Static()
    {
        IsFalse(FilledIn(NullSB       ));
        IsFalse(FilledIn(NewSB        ));
        IsFalse(FilledIn(NullyNewSB   ));
        IsFalse(FilledIn(EmptySB      ));
        IsFalse(FilledIn(NullyEmptySB ));
        IsFalse(FilledIn(SpaceSB      ));
        IsFalse(FilledIn(NullySpaceSB ));
    }
   
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersNo_Extensions()
    {
        IsFalse(NullSB       .FilledIn(                    ));
        IsFalse(NullSB       .FilledIn( spaceMatters: false));
        IsFalse(NullSB       .FilledIn(               false));
        IsFalse(NewSB        .FilledIn(                    ));
        IsFalse(NewSB        .FilledIn( spaceMatters: false));
        IsFalse(NewSB        .FilledIn(               false));
        IsFalse(NullyNewSB   .FilledIn(                    ));
        IsFalse(NullyNewSB   .FilledIn( spaceMatters: false));
        IsFalse(NullyNewSB   .FilledIn(               false));
        IsFalse(SpaceSB      .FilledIn(                    ));
        IsFalse(SpaceSB      .FilledIn( spaceMatters: false));
        IsFalse(SpaceSB      .FilledIn(               false));
        IsFalse(NullySpaceSB .FilledIn(                    ));
        IsFalse(NullySpaceSB .FilledIn( spaceMatters: false));
        IsFalse(NullySpaceSB .FilledIn(               false));
        IsTrue (FilledSB     .FilledIn(                    ));
        IsTrue (FilledSB     .FilledIn( spaceMatters: false));
        IsTrue (FilledSB     .FilledIn(               false));
        IsTrue (NullyFilledSB.FilledIn(                    ));
        IsTrue (NullyFilledSB.FilledIn( spaceMatters: false));
        IsTrue (NullyFilledSB.FilledIn(               false));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersNo_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullSB                            ));
        IsFalse(FilledIn(NullSB,        spaceMatters: false));
        IsFalse(FilledIn(NullSB,                      false));
        IsFalse(FilledIn(NewSB                             ));
        IsFalse(FilledIn(NewSB,         spaceMatters: false));
        IsFalse(FilledIn(NewSB,                       false));
        IsFalse(FilledIn(NullyNewSB                        ));
        IsFalse(FilledIn(NullyNewSB,    spaceMatters: false));
        IsFalse(FilledIn(NullyNewSB,                  false));
        IsFalse(FilledIn(SpaceSB                           ));
        IsFalse(FilledIn(SpaceSB,       spaceMatters: false));
        IsFalse(FilledIn(SpaceSB,                     false));
        IsFalse(FilledIn(NullySpaceSB                      ));
        IsFalse(FilledIn(NullySpaceSB,  spaceMatters: false));
        IsFalse(FilledIn(NullySpaceSB,                false));
        IsTrue (FilledIn(FilledSB                          ));
        IsTrue (FilledIn(FilledSB,      spaceMatters: false));
        IsTrue (FilledIn(FilledSB,                    false));
        IsTrue (FilledIn(NullyFilledSB                     ));
        IsTrue (FilledIn(NullyFilledSB, spaceMatters: false));
        IsTrue (FilledIn(NullyFilledSB,               false));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersNo_StaticFlagsInFront()
    {
        IsFalse(FilledIn(                     NullSB       ));
        IsFalse(FilledIn(spaceMatters: false, NullSB       ));
        IsFalse(FilledIn(              false, NullSB       ));
        IsFalse(FilledIn(                     NewSB        ));
        IsFalse(FilledIn(spaceMatters: false, NewSB        ));
        IsFalse(FilledIn(              false, NewSB        ));
        IsFalse(FilledIn(                     NullyNewSB   ));
        IsFalse(FilledIn(spaceMatters: false, NullyNewSB   ));
        IsFalse(FilledIn(              false, NullyNewSB   ));
        IsFalse(FilledIn(                     SpaceSB      ));
        IsFalse(FilledIn(spaceMatters: false, SpaceSB      ));
        IsFalse(FilledIn(              false, SpaceSB      ));
        IsFalse(FilledIn(                     NullySpaceSB ));
        IsFalse(FilledIn(spaceMatters: false, NullySpaceSB ));
        IsFalse(FilledIn(              false, NullySpaceSB ));
        IsTrue (FilledIn(                     FilledSB     ));
        IsTrue (FilledIn(spaceMatters: false, FilledSB     ));
        IsTrue (FilledIn(              false, FilledSB     ));
        IsTrue (FilledIn(                     NullyFilledSB));
        IsTrue (FilledIn(spaceMatters: false, NullyFilledSB));
        IsTrue (FilledIn(              false, NullyFilledSB));
    }
     
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersYes_Extensions()
    {
        IsFalse(NullSB       .FilledIn( spaceMatters       ));
        IsFalse(NullSB       .FilledIn( spaceMatters: true ));
        IsFalse(NullSB       .FilledIn(               true ));
        IsFalse(NewSB        .FilledIn( spaceMatters       ));
        IsFalse(NewSB        .FilledIn( spaceMatters: true ));
        IsFalse(NewSB        .FilledIn(               true ));
        IsFalse(EmptySB      .FilledIn( spaceMatters       ));
        IsFalse(EmptySB      .FilledIn( spaceMatters: true ));
        IsFalse(EmptySB      .FilledIn(               true ));
        IsFalse(NullyEmptySB .FilledIn( spaceMatters       ));
        IsFalse(NullyEmptySB .FilledIn( spaceMatters: true ));
        IsFalse(NullyEmptySB .FilledIn(               true ));
        IsTrue (SpaceSB      .FilledIn( spaceMatters       ));
        IsTrue (SpaceSB      .FilledIn( spaceMatters: true ));
        IsTrue (SpaceSB      .FilledIn(               true ));
        IsTrue (NullySpaceSB .FilledIn( spaceMatters       ));
        IsTrue (NullySpaceSB .FilledIn( spaceMatters: true ));
        IsTrue (NullySpaceSB .FilledIn(               true ));
        IsTrue (FilledSB     .FilledIn( spaceMatters       ));
        IsTrue (FilledSB     .FilledIn( spaceMatters: true ));
        IsTrue (FilledSB     .FilledIn(               true ));
        IsTrue (NullyFilledSB.FilledIn( spaceMatters       ));
        IsTrue (NullyFilledSB.FilledIn( spaceMatters: true ));
        IsTrue (NullyFilledSB.FilledIn(               true ));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersYes_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullSB,        spaceMatters       ));
        IsFalse(FilledIn(NullSB,        spaceMatters: true ));
        IsFalse(FilledIn(NullSB,                      true ));
        IsFalse(FilledIn(NewSB,         spaceMatters       ));
        IsFalse(FilledIn(NewSB,         spaceMatters: true ));
        IsFalse(FilledIn(NewSB,                       true ));
        IsFalse(FilledIn(EmptySB,       spaceMatters       ));
        IsFalse(FilledIn(EmptySB,       spaceMatters: true ));
        IsFalse(FilledIn(EmptySB,                     true ));
        IsFalse(FilledIn(NullyEmptySB,  spaceMatters       ));
        IsFalse(FilledIn(NullyEmptySB,  spaceMatters: true ));
        IsFalse(FilledIn(NullyEmptySB,                true ));
        IsTrue (FilledIn(SpaceSB,       spaceMatters       ));
        IsTrue (FilledIn(SpaceSB,       spaceMatters: true ));
        IsTrue (FilledIn(SpaceSB,                     true ));
        IsTrue (FilledIn(NullySpaceSB,  spaceMatters       ));
        IsTrue (FilledIn(NullySpaceSB,  spaceMatters: true ));
        IsTrue (FilledIn(NullySpaceSB,                true ));
        IsTrue (FilledIn(FilledSB,      spaceMatters       ));
        IsTrue (FilledIn(FilledSB,      spaceMatters: true ));
        IsTrue (FilledIn(FilledSB,                    true ));
        IsTrue (FilledIn(NullyFilledSB, spaceMatters       ));
        IsTrue (FilledIn(NullyFilledSB, spaceMatters: true ));
        IsTrue (FilledIn(NullyFilledSB,               true ));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersYes_StaticFlagsInFront()
    {
        IsFalse(FilledIn(spaceMatters,        NullSB       ));
        IsFalse(FilledIn(spaceMatters: true,  NullSB       ));
        IsFalse(FilledIn(              true,  NullSB       ));
        IsFalse(FilledIn(spaceMatters,        NewSB        ));
        IsFalse(FilledIn(spaceMatters: true,  NewSB        ));
        IsFalse(FilledIn(              true,  NewSB        ));
        IsFalse(FilledIn(spaceMatters,        EmptySB      ));
        IsFalse(FilledIn(spaceMatters: true,  EmptySB      ));
        IsFalse(FilledIn(              true,  EmptySB      ));
        IsFalse(FilledIn(spaceMatters,        NullyEmptySB ));
        IsFalse(FilledIn(spaceMatters: true,  NullyEmptySB ));
        IsFalse(FilledIn(              true,  NullyEmptySB ));
        IsTrue (FilledIn(spaceMatters,        SpaceSB      ));
        IsTrue (FilledIn(spaceMatters: true,  SpaceSB      ));
        IsTrue (FilledIn(              true,  SpaceSB      ));
        IsTrue (FilledIn(spaceMatters,        NullySpaceSB ));
        IsTrue (FilledIn(spaceMatters: true,  NullySpaceSB ));
        IsTrue (FilledIn(              true,  NullySpaceSB ));
        IsTrue (FilledIn(spaceMatters,        FilledSB     ));
        IsTrue (FilledIn(spaceMatters: true,  FilledSB     ));
        IsTrue (FilledIn(              true,  FilledSB     ));
        IsTrue (FilledIn(spaceMatters,        NullyFilledSB));
        IsTrue (FilledIn(spaceMatters: true,  NullyFilledSB));
        IsTrue (FilledIn(              true,  NullyFilledSB));
    }

    /// <inheritdoc cref="_notnullwhentests" />
    [TestMethod]
    public void FilledIn_NotNullWhen_StringBuilder()
    {
        SB? SB() => NullyFilledSB;

        { SB? sb = SB (); if ( FilledIn(sb              )) sb.ToString(); }
        { SB? sb = SB (); if ( FilledIn(sb, true        )) sb.ToString(); }
        { SB? sb = SB (); if ( FilledIn(sb, spaceMatters)) sb.ToString(); }
        { SB? sb = SB (); if ( FilledIn(              sb)) sb.ToString(); }
        { SB? sb = SB (); if ( FilledIn(true,         sb)) sb.ToString(); }
        { SB? sb = SB (); if ( FilledIn(spaceMatters, sb)) sb.ToString(); }
        { SB? sb = SB (); if ( sb.FilledIn(             )) sb.ToString(); }
        { SB? sb = SB (); if ( sb.FilledIn(true         )) sb.ToString(); }
        { SB? sb = SB (); if ( sb.FilledIn(spaceMatters )) sb.ToString(); }
    }
}