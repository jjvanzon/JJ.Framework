namespace JJ.Framework.Existence.Core.SBs.Tests;

[TestClass]
public class IsNully_StringBuilder_Tests : TestBase
{
    [TestMethod]
    public void IsNully_StringBuilder_False_Extensions()
    {
        IsFalse(FilledSB     .IsNully());
        IsFalse(NullyFilledSB.IsNully());
    }

    [TestMethod]
    public void IsNully_StringBuilder_False_Static()
    {
        IsFalse(IsNully(FilledSB      ));
        IsFalse(IsNully(NullyFilledSB ));
    }

    [TestMethod]
    public void IsNully_StringBuilder_True_Extensions()
    {
        IsTrue (NullSB      .IsNully());
        IsTrue (NewSB       .IsNully());
        IsTrue (NullyNewSB  .IsNully());
        IsTrue (EmptySB     .IsNully());
        IsTrue (SpaceSB     .IsNully());
        IsTrue (NullyEmptySB.IsNully());
        IsTrue (NullySpaceSB.IsNully());
    }

    [TestMethod]
    public void IsNully_StringBuilder_True_Static()
    {
        IsTrue (IsNully(NullSB       ));
        IsTrue (IsNully(NewSB        ));
        IsTrue (IsNully(NullyNewSB   ));
        IsTrue (IsNully(EmptySB      ));
        IsTrue (IsNully(NullyEmptySB ));
        IsTrue (IsNully(SpaceSB      ));
        IsTrue (IsNully(NullySpaceSB ));
    }
   
    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersNo_Extensions()
    {
        IsTrue (NullSB       .IsNully(                    ));
        IsTrue (NullSB       .IsNully( spaceMatters: false));
        IsTrue (NullSB       .IsNully(               false));
        IsTrue (NewSB        .IsNully(                    ));
        IsTrue (NewSB        .IsNully( spaceMatters: false));
        IsTrue (NewSB        .IsNully(               false));
        IsTrue (NullyNewSB   .IsNully(                    ));
        IsTrue (NullyNewSB   .IsNully( spaceMatters: false));
        IsTrue (NullyNewSB   .IsNully(               false));
        IsTrue (SpaceSB      .IsNully(                    ));
        IsTrue (SpaceSB      .IsNully( spaceMatters: false));
        IsTrue (SpaceSB      .IsNully(               false));
        IsTrue (NullySpaceSB .IsNully(                    ));
        IsTrue (NullySpaceSB .IsNully( spaceMatters: false));
        IsTrue (NullySpaceSB .IsNully(               false));
        IsFalse(FilledSB     .IsNully(                    ));
        IsFalse(FilledSB     .IsNully( spaceMatters: false));
        IsFalse(FilledSB     .IsNully(               false));
        IsFalse(NullyFilledSB.IsNully(                    ));
        IsFalse(NullyFilledSB.IsNully( spaceMatters: false));
        IsFalse(NullyFilledSB.IsNully(               false));
    }
    
    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersNo_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullSB                            ));
        IsTrue (IsNully(NullSB,        spaceMatters: false));
        IsTrue (IsNully(NullSB,                      false));
        IsTrue (IsNully(NewSB                             ));
        IsTrue (IsNully(NewSB,         spaceMatters: false));
        IsTrue (IsNully(NewSB,                       false));
        IsTrue (IsNully(NullyNewSB                        ));
        IsTrue (IsNully(NullyNewSB,    spaceMatters: false));
        IsTrue (IsNully(NullyNewSB,                  false));
        IsTrue (IsNully(SpaceSB                           ));
        IsTrue (IsNully(SpaceSB,       spaceMatters: false));
        IsTrue (IsNully(SpaceSB,                     false));
        IsTrue (IsNully(NullySpaceSB                      ));
        IsTrue (IsNully(NullySpaceSB,  spaceMatters: false));
        IsTrue (IsNully(NullySpaceSB,                false));
        IsFalse(IsNully(FilledSB                          ));
        IsFalse(IsNully(FilledSB,      spaceMatters: false));
        IsFalse(IsNully(FilledSB,                    false));
        IsFalse(IsNully(NullyFilledSB                     ));
        IsFalse(IsNully(NullyFilledSB, spaceMatters: false));
        IsFalse(IsNully(NullyFilledSB,               false));
    }
    
    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersNo_StaticFlagsInFront()
    {
        IsTrue (IsNully(                     NullSB       ));
        IsTrue (IsNully(spaceMatters: false, NullSB       ));
        IsTrue (IsNully(              false, NullSB       ));
        IsTrue (IsNully(                     NewSB        ));
        IsTrue (IsNully(spaceMatters: false, NewSB        ));
        IsTrue (IsNully(              false, NewSB        ));
        IsTrue (IsNully(                     NullyNewSB   ));
        IsTrue (IsNully(spaceMatters: false, NullyNewSB   ));
        IsTrue (IsNully(              false, NullyNewSB   ));
        IsTrue (IsNully(                     SpaceSB      ));
        IsTrue (IsNully(spaceMatters: false, SpaceSB      ));
        IsTrue (IsNully(              false, SpaceSB      ));
        IsTrue (IsNully(                     NullySpaceSB ));
        IsTrue (IsNully(spaceMatters: false, NullySpaceSB ));
        IsTrue (IsNully(              false, NullySpaceSB ));
        IsFalse(IsNully(                     FilledSB     ));
        IsFalse(IsNully(spaceMatters: false, FilledSB     ));
        IsFalse(IsNully(              false, FilledSB     ));
        IsFalse(IsNully(                     NullyFilledSB));
        IsFalse(IsNully(spaceMatters: false, NullyFilledSB));
        IsFalse(IsNully(              false, NullyFilledSB));
    }
     
    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersYes_Extensions()
    {
        IsTrue (NullSB       .IsNully( spaceMatters       ));
        IsTrue (NullSB       .IsNully( spaceMatters: true ));
        IsTrue (NullSB       .IsNully(               true ));
        IsTrue (NewSB        .IsNully( spaceMatters       ));
        IsTrue (NewSB        .IsNully( spaceMatters: true ));
        IsTrue (NewSB        .IsNully(               true ));
        IsTrue (EmptySB      .IsNully( spaceMatters       ));
        IsTrue (EmptySB      .IsNully( spaceMatters: true ));
        IsTrue (EmptySB      .IsNully(               true ));
        IsTrue (NullyEmptySB .IsNully( spaceMatters       ));
        IsTrue (NullyEmptySB .IsNully( spaceMatters: true ));
        IsTrue (NullyEmptySB .IsNully(               true ));
        IsFalse(SpaceSB      .IsNully( spaceMatters       ));
        IsFalse(SpaceSB      .IsNully( spaceMatters: true ));
        IsFalse(SpaceSB      .IsNully(               true ));
        IsFalse(NullySpaceSB .IsNully( spaceMatters       ));
        IsFalse(NullySpaceSB .IsNully( spaceMatters: true ));
        IsFalse(NullySpaceSB .IsNully(               true ));
        IsFalse(FilledSB     .IsNully( spaceMatters       ));
        IsFalse(FilledSB     .IsNully( spaceMatters: true ));
        IsFalse(FilledSB     .IsNully(               true ));
        IsFalse(NullyFilledSB.IsNully( spaceMatters       ));
        IsFalse(NullyFilledSB.IsNully( spaceMatters: true ));
        IsFalse(NullyFilledSB.IsNully(               true ));
    }
    
    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersYes_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullSB,        spaceMatters       ));
        IsTrue (IsNully(NullSB,        spaceMatters: true ));
        IsTrue (IsNully(NullSB,                      true ));
        IsTrue (IsNully(NewSB,         spaceMatters       ));
        IsTrue (IsNully(NewSB,         spaceMatters: true ));
        IsTrue (IsNully(NewSB,                       true ));
        IsTrue (IsNully(EmptySB,       spaceMatters       ));
        IsTrue (IsNully(EmptySB,       spaceMatters: true ));
        IsTrue (IsNully(EmptySB,                     true ));
        IsTrue (IsNully(NullyEmptySB,  spaceMatters       ));
        IsTrue (IsNully(NullyEmptySB,  spaceMatters: true ));
        IsTrue (IsNully(NullyEmptySB,                true ));
        IsFalse(IsNully(SpaceSB,       spaceMatters       ));
        IsFalse(IsNully(SpaceSB,       spaceMatters: true ));
        IsFalse(IsNully(SpaceSB,                     true ));
        IsFalse(IsNully(NullySpaceSB,  spaceMatters       ));
        IsFalse(IsNully(NullySpaceSB,  spaceMatters: true ));
        IsFalse(IsNully(NullySpaceSB,                true ));
        IsFalse(IsNully(FilledSB,      spaceMatters       ));
        IsFalse(IsNully(FilledSB,      spaceMatters: true ));
        IsFalse(IsNully(FilledSB,                    true ));
        IsFalse(IsNully(NullyFilledSB, spaceMatters       ));
        IsFalse(IsNully(NullyFilledSB, spaceMatters: true ));
        IsFalse(IsNully(NullyFilledSB,               true ));
    }
    
    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersYes_StaticFlagsInFront()
    {
        IsTrue (IsNully(spaceMatters,        NullSB       ));
        IsTrue (IsNully(spaceMatters: true,  NullSB       ));
        IsTrue (IsNully(              true,  NullSB       ));
        IsTrue (IsNully(spaceMatters,        NewSB        ));
        IsTrue (IsNully(spaceMatters: true,  NewSB        ));
        IsTrue (IsNully(              true,  NewSB        ));
        IsTrue (IsNully(spaceMatters,        EmptySB      ));
        IsTrue (IsNully(spaceMatters: true,  EmptySB      ));
        IsTrue (IsNully(              true,  EmptySB      ));
        IsTrue (IsNully(spaceMatters,        NullyEmptySB ));
        IsTrue (IsNully(spaceMatters: true,  NullyEmptySB ));
        IsTrue (IsNully(              true,  NullyEmptySB ));
        IsFalse(IsNully(spaceMatters,        SpaceSB      ));
        IsFalse(IsNully(spaceMatters: true,  SpaceSB      ));
        IsFalse(IsNully(              true,  SpaceSB      ));
        IsFalse(IsNully(spaceMatters,        NullySpaceSB ));
        IsFalse(IsNully(spaceMatters: true,  NullySpaceSB ));
        IsFalse(IsNully(              true,  NullySpaceSB ));
        IsFalse(IsNully(spaceMatters,        FilledSB     ));
        IsFalse(IsNully(spaceMatters: true,  FilledSB     ));
        IsFalse(IsNully(              true,  FilledSB     ));
        IsFalse(IsNully(spaceMatters,        NullyFilledSB));
        IsFalse(IsNully(spaceMatters: true,  NullyFilledSB));
        IsFalse(IsNully(              true,  NullyFilledSB));
    }
}