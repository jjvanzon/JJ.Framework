// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Tests : TestBase
{
    // Text

    [TestMethod]
    public void IsNully_Text_False_Extensions()
    {
        IsFalse(Text           .IsNully());
        IsFalse(NullyFilledText.IsNully());
    }
        
    [TestMethod]
    public void IsNully_Text_False_Static()
    {
        IsFalse(IsNully(Text           ));
        IsFalse(IsNully(NullyFilledText));
    }        

    [TestMethod]
    public void IsNully_Text_True_Extensions()
    {
        IsTrue (Empty     .IsNully());
        IsTrue (Space     .IsNully());
        IsTrue (NullText  .IsNully());
        IsTrue (NullyEmpty.IsNully());
        IsTrue (NullySpace.IsNully());
    }

    [TestMethod]
    public void IsNully_Text_True_Static()
    {
        IsTrue (IsNully(Empty     ));
        IsTrue (IsNully(Space     ));
        IsTrue (IsNully(NullText  ));
        IsTrue (IsNully(NullyEmpty));
        IsTrue (IsNully(NullySpace));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersNo_Extensions()
    {
        IsTrue (NullText       .IsNully(                        ));
        IsTrue (NullText       .IsNully(     spaceMatters: false));
        IsTrue (NullText       .IsNully(                   false));
        IsTrue (Empty          .IsNully(                        ));
        IsTrue (Empty          .IsNully(     spaceMatters: false));
        IsTrue (Empty          .IsNully(                   false));
        IsTrue (NullyEmpty     .IsNully(                        ));
        IsTrue (NullyEmpty     .IsNully(     spaceMatters: false));
        IsTrue (NullyEmpty     .IsNully(                   false));
        IsTrue (Space          .IsNully(                        ));
        IsTrue (Space          .IsNully(     spaceMatters: false));
        IsTrue (Space          .IsNully(                   false));
        IsTrue (NullySpace     .IsNully(                        ));
        IsTrue (NullySpace     .IsNully(     spaceMatters: false));
        IsTrue (NullySpace     .IsNully(                   false));
        IsFalse(Text           .IsNully(                        ));
        IsFalse(Text           .IsNully(     spaceMatters: false));
        IsFalse(Text           .IsNully(                   false));
        IsFalse(NullyFilledText.IsNully(                        ));
        IsFalse(NullyFilledText.IsNully(     spaceMatters: false));
        IsFalse(NullyFilledText.IsNully(                   false));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersNo_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullText                                ));
        IsTrue (IsNully(NullText,            spaceMatters: false));
        IsTrue (IsNully(NullText,                          false));
        IsTrue (IsNully(Empty                                   ));
        IsTrue (IsNully(Empty,               spaceMatters: false));
        IsTrue (IsNully(Empty,                             false));
        IsTrue (IsNully(NullyEmpty                              ));
        IsTrue (IsNully(NullyEmpty,          spaceMatters: false));
        IsTrue (IsNully(NullyEmpty,                        false));
        IsTrue (IsNully(Space                                   ));
        IsTrue (IsNully(Space,               spaceMatters: false));
        IsTrue (IsNully(Space,                             false));
        IsTrue (IsNully(NullySpace                              ));
        IsTrue (IsNully(NullySpace,          spaceMatters: false));
        IsTrue (IsNully(NullySpace,                        false));
        IsFalse(IsNully(Text                                    ));
        IsFalse(IsNully(Text,                spaceMatters: false));
        IsFalse(IsNully(Text,                              false));
        IsFalse(IsNully(NullyFilledText                         ));
        IsFalse(IsNully(NullyFilledText,     spaceMatters: false));
        IsFalse(IsNully(NullyFilledText,                   false));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersNo_StaticFlagsInFront()
    {
        IsTrue (IsNully(                     NullText           ));
        IsTrue (IsNully(spaceMatters: false, NullText           ));
        IsTrue (IsNully(              false, NullText           ));
        IsTrue (IsNully(                     Empty              ));
        IsTrue (IsNully(spaceMatters: false, Empty              ));
        IsTrue (IsNully(              false, Empty              ));
        IsTrue (IsNully(                     NullyEmpty         ));
        IsTrue (IsNully(spaceMatters: false, NullyEmpty         ));
        IsTrue (IsNully(              false, NullyEmpty         ));
        IsTrue (IsNully(                     Space              ));
        IsTrue (IsNully(spaceMatters: false, Space              ));
        IsTrue (IsNully(              false, Space              ));
        IsTrue (IsNully(                     NullySpace         ));
        IsTrue (IsNully(spaceMatters: false, NullySpace         ));
        IsTrue (IsNully(              false, NullySpace         ));
        IsFalse(IsNully(                     Text               ));
        IsFalse(IsNully(spaceMatters: false, Text               ));
        IsFalse(IsNully(              false, Text               ));
        IsFalse(IsNully(                     NullyFilledText    ));
        IsFalse(IsNully(spaceMatters: false, NullyFilledText    ));
        IsFalse(IsNully(              false, NullyFilledText    ));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersYes_Extensions()
    {
        IsTrue (NullText       .IsNully(     spaceMatters       ));
        IsTrue (NullText       .IsNully(     spaceMatters: true ));
        IsTrue (NullText       .IsNully(                   true ));
        IsTrue (Empty          .IsNully(     spaceMatters       ));
        IsTrue (Empty          .IsNully(     spaceMatters: true ));
        IsTrue (Empty          .IsNully(                   true ));
        IsTrue (NullyEmpty     .IsNully(     spaceMatters       ));
        IsTrue (NullyEmpty     .IsNully(     spaceMatters: true ));
        IsTrue (NullyEmpty     .IsNully(                   true ));
        IsFalse(Space          .IsNully(     spaceMatters       ));
        IsFalse(Space          .IsNully(     spaceMatters: true ));
        IsFalse(Space          .IsNully(                   true ));
        IsFalse(NullySpace     .IsNully(     spaceMatters       ));
        IsFalse(NullySpace     .IsNully(     spaceMatters: true ));
        IsFalse(NullySpace     .IsNully(                   true ));
        IsFalse(Text           .IsNully(     spaceMatters       ));
        IsFalse(Text           .IsNully(     spaceMatters: true ));
        IsFalse(Text           .IsNully(                   true ));
        IsFalse(NullyFilledText.IsNully(     spaceMatters       ));
        IsFalse(NullyFilledText.IsNully(     spaceMatters: true ));
        IsFalse(NullyFilledText.IsNully(                   true ));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersYes_Static_FlagsInBack()
    {
        IsTrue (IsNully(NullText,            spaceMatters       ));
        IsTrue (IsNully(NullText,            spaceMatters: true ));
        IsTrue (IsNully(NullText,                          true ));
        IsTrue (IsNully(Empty,               spaceMatters       ));
        IsTrue (IsNully(Empty,               spaceMatters: true ));
        IsTrue (IsNully(Empty,                             true ));
        IsTrue (IsNully(NullyEmpty,          spaceMatters       ));
        IsTrue (IsNully(NullyEmpty,          spaceMatters: true ));
        IsTrue (IsNully(NullyEmpty,                        true ));
        IsFalse(IsNully(Space,               spaceMatters       ));
        IsFalse(IsNully(Space,               spaceMatters: true ));
        IsFalse(IsNully(Space,                             true ));
        IsFalse(IsNully(NullySpace,          spaceMatters       ));
        IsFalse(IsNully(NullySpace,          spaceMatters: true ));
        IsFalse(IsNully(NullySpace,                        true ));
        IsFalse(IsNully(Text,                spaceMatters       ));
        IsFalse(IsNully(Text,                spaceMatters: true ));
        IsFalse(IsNully(Text,                              true ));
        IsFalse(IsNully(NullyFilledText,     spaceMatters       ));
        IsFalse(IsNully(NullyFilledText,     spaceMatters: true ));
        IsFalse(IsNully(NullyFilledText,                   true ));
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMattersYes_Static_FlagsInFront()
    {
        IsTrue (IsNully(spaceMatters,        NullText           ));
        IsTrue (IsNully(spaceMatters: true,  NullText           ));
        IsTrue (IsNully(              true,  NullText           ));
        IsTrue (IsNully(spaceMatters,        Empty              ));
        IsTrue (IsNully(spaceMatters: true,  Empty              ));
        IsTrue (IsNully(              true,  Empty              ));
        IsTrue (IsNully(spaceMatters,        NullyEmpty         ));
        IsTrue (IsNully(spaceMatters: true,  NullyEmpty         ));
        IsTrue (IsNully(              true,  NullyEmpty         ));
        IsFalse(IsNully(spaceMatters,        Space              ));
        IsFalse(IsNully(spaceMatters: true,  Space              ));
        IsFalse(IsNully(              true,  Space              ));
        IsFalse(IsNully(spaceMatters,        NullySpace         ));
        IsFalse(IsNully(spaceMatters: true,  NullySpace         ));
        IsFalse(IsNully(              true,  NullySpace         ));
        IsFalse(IsNully(spaceMatters,        Text               ));
        IsFalse(IsNully(spaceMatters: true,  Text               ));
        IsFalse(IsNully(              true,  Text               ));
        IsFalse(IsNully(spaceMatters,        NullyFilledText    ));
        IsFalse(IsNully(spaceMatters: true,  NullyFilledText    ));
        IsFalse(IsNully(              true,  NullyFilledText    ));
    }

    // StringBuilder
            
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
    
    // Booleans

    [TestMethod]
    public void IsNully_Bool_Static()
    {
        IsFalse(IsNully(true      ));
        IsTrue (IsNully(false     ));
        IsFalse(IsNully(True      ));
        IsTrue (IsNully(False     ));
        IsFalse(IsNully(NullyTrue ));
        IsTrue (IsNully(NullyFalse));
        IsTrue (IsNully(NullBool  ));
    }

    [TestMethod]
    public void IsNully_Bool_Extensions()
    {
        IsFalse(true      .IsNully());
        IsTrue (false     .IsNully());
        IsFalse(True      .IsNully());
        IsTrue (False     .IsNully());
        IsFalse(NullyTrue .IsNully());
        IsTrue (NullyFalse.IsNully());
        IsTrue (NullBool  .IsNully());
    }
        
    [TestMethod]
    public void IsNully_Bool_ZeroMattersNo_Extensions()
    { 
        IsFalse(true      .IsNully(                   ));
        IsFalse(true      .IsNully( zeroMatters: false));
        IsFalse(true      .IsNully(              false));
        IsTrue (false     .IsNully(                   ));
        IsTrue (false     .IsNully( zeroMatters: false));
        IsTrue (false     .IsNully(              false));
        IsFalse(True      .IsNully(                   ));
        IsFalse(True      .IsNully( zeroMatters: false));
        IsFalse(True      .IsNully(              false));
        IsTrue (False     .IsNully(                   ));
        IsTrue (False     .IsNully( zeroMatters: false));
        IsTrue (False     .IsNully(              false));
        IsFalse(NullyTrue .IsNully(                   ));
        IsFalse(NullyTrue .IsNully( zeroMatters: false));
        IsFalse(NullyTrue .IsNully(              false));
        IsTrue (NullyFalse.IsNully(                   ));
        IsTrue (NullyFalse.IsNully( zeroMatters: false));
        IsTrue (NullyFalse.IsNully(              false));
        IsTrue (NullBool  .IsNully(                   ));
        IsTrue (NullBool  .IsNully( zeroMatters: false));
        IsTrue (NullBool  .IsNully(              false));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersNo_StaticFlagsInBack()
    { 
        IsFalse(IsNully(true                          ));
        IsFalse(IsNully(true,       zeroMatters: false));
        IsFalse(IsNully(true,                    false));
        IsTrue (IsNully(false                         ));
        IsTrue (IsNully(false,      zeroMatters: false));
        IsTrue (IsNully(false,                   false));
        IsFalse(IsNully(True                          ));
        IsFalse(IsNully(True,       zeroMatters: false));
        IsFalse(IsNully(True,                    false));
        IsTrue (IsNully(False                         ));
        IsTrue (IsNully(False,      zeroMatters: false));
        IsTrue (IsNully(False,                   false));
        IsFalse(IsNully(NullyTrue                     ));
        IsFalse(IsNully(NullyTrue,  zeroMatters: false));
        IsFalse(IsNully(NullyTrue,               false));
        IsTrue (IsNully(NullyFalse                    ));
        IsTrue (IsNully(NullyFalse, zeroMatters: false));
        IsTrue (IsNully(NullyFalse,              false));
        IsTrue (IsNully(NullBool                      ));
        IsTrue (IsNully(NullBool,   zeroMatters: false));
        IsTrue (IsNully(NullBool,                false));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersNo_StaticFlagsInFront()
    {
        IsFalse(IsNully(                    true      ));
        IsFalse(IsNully(zeroMatters: false, true      ));
        IsFalse(IsNully(             false, true      ));
        IsTrue (IsNully(                    false     ));
        IsTrue (IsNully(zeroMatters: false, false     ));
        IsTrue (IsNully(             false, false     ));
        IsFalse(IsNully(                    True      ));
        IsFalse(IsNully(zeroMatters: false, True      ));
        IsFalse(IsNully(             false, True      ));
        IsTrue (IsNully(                    False     ));
        IsTrue (IsNully(zeroMatters: false, False     ));
        IsTrue (IsNully(             false, False     ));
        IsFalse(IsNully(                    NullyTrue ));
        IsFalse(IsNully(zeroMatters: false, NullyTrue ));
        IsFalse(IsNully(             false, NullyTrue ));
        IsTrue (IsNully(                    NullyFalse));
        IsTrue (IsNully(zeroMatters: false, NullyFalse));
        IsTrue (IsNully(             false, NullyFalse));
        IsTrue (IsNully(                    NullBool  ));
        IsTrue (IsNully(zeroMatters: false, NullBool  ));
        IsTrue (IsNully(             false, NullBool  ));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersYes_Extensions()
    { 
        IsFalse(true      .IsNully( zeroMatters       ));
        IsFalse(true      .IsNully( zeroMatters: true ));
        IsFalse(true      .IsNully(              true ));
        IsFalse(false     .IsNully( zeroMatters       ));
        IsFalse(false     .IsNully( zeroMatters: true ));
        IsFalse(false     .IsNully(              true ));
        IsFalse(True      .IsNully( zeroMatters       ));
        IsFalse(True      .IsNully( zeroMatters: true ));
        IsFalse(True      .IsNully(              true ));
        IsFalse(False     .IsNully( zeroMatters       ));
        IsFalse(False     .IsNully( zeroMatters: true ));
        IsFalse(False     .IsNully(              true ));
        IsFalse(NullyTrue .IsNully( zeroMatters       ));
        IsFalse(NullyTrue .IsNully( zeroMatters: true ));
        IsFalse(NullyTrue .IsNully(              true ));
        IsFalse(NullyFalse.IsNully( zeroMatters       ));
        IsFalse(NullyFalse.IsNully( zeroMatters: true ));
        IsFalse(NullyFalse.IsNully(              true ));
        IsTrue (NullBool  .IsNully( zeroMatters       ));
        IsTrue (NullBool  .IsNully( zeroMatters: true ));
        IsTrue (NullBool  .IsNully(              true ));
    }
    
    [TestMethod]
    public void IsNully_Bool_ZeroMattersYes_StaticFlagsInBack()
    { 
        IsFalse(IsNully(true,       zeroMatters       ));
        IsFalse(IsNully(true,       zeroMatters: true ));
        IsFalse(IsNully(true,                    true ));
        IsFalse(IsNully(false,      zeroMatters       ));
        IsFalse(IsNully(false,      zeroMatters: true ));
        IsFalse(IsNully(false,                   true ));
        IsFalse(IsNully(True,       zeroMatters       ));
        IsFalse(IsNully(True,       zeroMatters: true ));
        IsFalse(IsNully(True,                    true ));
        IsFalse(IsNully(False,      zeroMatters       ));
        IsFalse(IsNully(False,      zeroMatters: true ));
        IsFalse(IsNully(False,                   true ));
        IsFalse(IsNully(NullyTrue,  zeroMatters       ));
        IsFalse(IsNully(NullyTrue,  zeroMatters: true ));
        IsFalse(IsNully(NullyTrue,               true ));
        IsFalse(IsNully(NullyFalse, zeroMatters       ));
        IsFalse(IsNully(NullyFalse, zeroMatters: true ));
        IsFalse(IsNully(NullyFalse,              true ));
        IsTrue (IsNully(NullBool,   zeroMatters       ));
        IsTrue (IsNully(NullBool,   zeroMatters: true ));
        IsTrue (IsNully(NullBool,                true ));
    }

    [TestMethod]
    public void IsNully_Bool_ZeroMattersYes_StaticFlagsInFront()
    {
        IsFalse(IsNully(zeroMatters,        true      ));
        IsFalse(IsNully(zeroMatters: true,  true      ));
        IsFalse(IsNully(             true,  true      ));
        IsFalse(IsNully(zeroMatters,        false     ));
        IsFalse(IsNully(zeroMatters: true,  false     ));
        IsFalse(IsNully(             true,  false     ));
        IsFalse(IsNully(zeroMatters,        True      ));
        IsFalse(IsNully(zeroMatters: true,  True      ));
        IsFalse(IsNully(             true,  True      ));
        IsFalse(IsNully(zeroMatters,        False     ));
        IsFalse(IsNully(zeroMatters: true,  False     ));
        IsFalse(IsNully(             true,  False     ));
        IsFalse(IsNully(zeroMatters,        NullyTrue ));
        IsFalse(IsNully(zeroMatters: true,  NullyTrue ));
        IsFalse(IsNully(             true,  NullyTrue ));
        IsFalse(IsNully(zeroMatters,        NullyFalse));
        IsFalse(IsNully(zeroMatters: true,  NullyFalse));
        IsFalse(IsNully(             true,  NullyFalse));
        IsTrue (IsNully(zeroMatters,        NullBool  ));
        IsTrue (IsNully(zeroMatters: true,  NullBool  ));
        IsTrue (IsNully(             true,  NullBool  ));
    }

    /// <inheritdoc cref="_nullableflag" />
    [TestMethod]
    public void IsNully_Bool_NullableFlag()
    {
        bool? nullyZeroMattersFalse = false;
        bool? nullyZeroMattersTrue  = true;

        // NOTE: Extension methods do not have the ambiguity problem.

        IsFalse(IsNully(true,       nullyZeroMattersFalse         ));
        IsTrue (IsNully(false,      nullyZeroMattersFalse         ));
        IsFalse(IsNully(True,       nullyZeroMattersFalse         ));
        IsTrue (IsNully(False,      nullyZeroMattersFalse         ));
        IsFalse(IsNully(NullyTrue,  nullyZeroMattersFalse ?? false));
        IsTrue (IsNully(NullyFalse, nullyZeroMattersFalse ?? false));
        IsTrue (IsNully(NullBool,   nullyZeroMattersFalse ?? false));

        IsFalse(IsNully(true,       nullyZeroMattersTrue          ));
        IsFalse(IsNully(false,      nullyZeroMattersTrue          ));
        IsFalse(IsNully(True,       nullyZeroMattersTrue          ));
        IsFalse(IsNully(False,      nullyZeroMattersTrue          ));
        IsFalse(IsNully(NullyTrue,  nullyZeroMattersTrue  ?? true ));
        IsFalse(IsNully(NullyFalse, nullyZeroMattersTrue  ?? true ));
        IsTrue (IsNully(NullBool,   nullyZeroMattersTrue  ?? true ));

        IsFalse(IsNully(nullyZeroMattersFalse,          true       ));
        IsTrue (IsNully(nullyZeroMattersFalse,          false      ));
        IsFalse(IsNully(nullyZeroMattersFalse,          True       ));
        IsTrue (IsNully(nullyZeroMattersFalse,          False      ));
        IsFalse(IsNully(nullyZeroMattersFalse ?? false, NullyTrue  ));
        IsTrue (IsNully(nullyZeroMattersFalse ?? false, NullyFalse ));
        IsTrue (IsNully(nullyZeroMattersFalse ?? false, NullBool   ));

        IsFalse(IsNully(nullyZeroMattersTrue,           true       ));
        IsFalse(IsNully(nullyZeroMattersTrue,           false      ));
        IsFalse(IsNully(nullyZeroMattersTrue,           True       ));
        IsFalse(IsNully(nullyZeroMattersTrue,           False      ));
        IsFalse(IsNully(nullyZeroMattersTrue  ?? true , NullyTrue  ));
        IsFalse(IsNully(nullyZeroMattersTrue  ?? true , NullyFalse ));
        IsTrue (IsNully(nullyZeroMattersTrue  ?? true , NullBool   ));
    }

    // Values

    [TestMethod]
    public void IsNully_Values_No()
    {
        IsTrue (IsNully(NullNum));
        IsTrue (IsNully(NoNull0));
        IsTrue (IsNully(Nully0 ));
    }

    [TestMethod]
    public void IsNully_Values_Yes()
    {
        IsFalse(IsNully(NoNull1));
        IsFalse(IsNully(NoNull2));
        IsFalse(IsNully(NoNull3));
        IsFalse(IsNully(Nully1 ));
        IsFalse(IsNully(Nully2 ));
        IsFalse(IsNully(Nully3 ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersNo_Extensions()
    {
        IsTrue (NullNum.IsNully(                  ));
        IsTrue (NullNum.IsNully(zeroMatters: false));
        IsTrue (NullNum.IsNully(             false));
        IsTrue (NoNull0.IsNully(                  ));
        IsTrue (NoNull0.IsNully(zeroMatters: false));
        IsTrue (NoNull0.IsNully(             false));
        IsTrue (Nully0 .IsNully(                  ));
        IsTrue (Nully0 .IsNully(zeroMatters: false));
        IsTrue (Nully0 .IsNully(             false));
        IsFalse(NoNull1.IsNully(                  ));
        IsFalse(NoNull1.IsNully(zeroMatters: false));
        IsFalse(NoNull1.IsNully(             false));
        IsFalse(Nully1 .IsNully(                  ));
        IsFalse(Nully1 .IsNully(zeroMatters: false));
        IsFalse(Nully1 .IsNully(             false));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersNo_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullNum                    ));
        IsTrue (IsNully(NullNum, zeroMatters: false));
        IsTrue (IsNully(NullNum,              false));
        IsTrue (IsNully(NoNull0                    ));
        IsTrue (IsNully(NoNull0, zeroMatters: false));
        IsTrue (IsNully(NoNull0,              false));
        IsTrue (IsNully(Nully0                     ));
        IsTrue (IsNully(Nully0,  zeroMatters: false));
        IsTrue (IsNully(Nully0,               false));
        IsFalse(IsNully(NoNull1                    ));
        IsFalse(IsNully(NoNull1, zeroMatters: false));
        IsFalse(IsNully(NoNull1,              false));
        IsFalse(IsNully(Nully1                     ));
        IsFalse(IsNully(Nully1,  zeroMatters: false));
        IsFalse(IsNully(Nully1,               false));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersNo_StaticFlagsInFront()
    {
        IsTrue (IsNully(                    NullNum));
        IsTrue (IsNully(zeroMatters: false, NullNum));
        IsTrue (IsNully(             false, NullNum));
        IsTrue (IsNully(                    NoNull0));
        IsTrue (IsNully(zeroMatters: false, NoNull0));
        IsTrue (IsNully(             false, NoNull0));
        IsTrue (IsNully(                    Nully0 ));
        IsTrue (IsNully(zeroMatters: false, Nully0 ));
        IsTrue (IsNully(             false, Nully0 ));
        IsFalse(IsNully(                    NoNull1));
        IsFalse(IsNully(zeroMatters: false, NoNull1));
        IsFalse(IsNully(             false, NoNull1));
        IsFalse(IsNully(                    Nully1 ));
        IsFalse(IsNully(zeroMatters: false, Nully1 ));
        IsFalse(IsNully(             false, Nully1 ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersYes_Extensions()
    {
        IsTrue (NullNum.IsNully(zeroMatters       ));
        IsTrue (NullNum.IsNully(zeroMatters: true ));
        IsTrue (NullNum.IsNully(             true ));
        IsFalse(NoNull0.IsNully(zeroMatters       ));
        IsFalse(NoNull0.IsNully(zeroMatters: true ));
        IsFalse(NoNull0.IsNully(             true ));
        IsFalse(Nully0 .IsNully(zeroMatters       ));
        IsFalse(Nully0 .IsNully(zeroMatters: true ));
        IsFalse(Nully0 .IsNully(             true ));
        IsFalse(NoNull1.IsNully(zeroMatters       ));
        IsFalse(NoNull1.IsNully(zeroMatters: true ));
        IsFalse(NoNull1.IsNully(             true ));
        IsFalse(Nully1 .IsNully(zeroMatters       ));
        IsFalse(Nully1 .IsNully(zeroMatters: true ));
        IsFalse(Nully1 .IsNully(             true ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersYes_StaticFlagsInBack()
    {
        IsTrue (IsNully(NullNum, zeroMatters       ));
        IsTrue (IsNully(NullNum, zeroMatters: true ));
        IsTrue (IsNully(NullNum,              true ));
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(NoNull0,              true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
        IsFalse(IsNully(Nully0,               true ));
        IsFalse(IsNully(NoNull1, zeroMatters       ));
        IsFalse(IsNully(NoNull1, zeroMatters: true ));
        IsFalse(IsNully(NoNull1,              true ));
        IsFalse(IsNully(Nully1,  zeroMatters       ));
        IsFalse(IsNully(Nully1,  zeroMatters: true ));
        IsFalse(IsNully(Nully1,               true ));
    }

    [TestMethod]
    public void IsNully_Values_ZeroMattersYes_StaticFlagsInFront()
    {
        IsTrue (IsNully(zeroMatters,       NullNum ));
        IsTrue (IsNully(zeroMatters: true, NullNum ));
        IsTrue (IsNully(             true, NullNum ));
        IsFalse(IsNully(zeroMatters,       NoNull0 ));
        IsFalse(IsNully(zeroMatters: true, NoNull0 ));
        IsFalse(IsNully(             true, NoNull0 ));
        IsFalse(IsNully(zeroMatters,       Nully0  ));
        IsFalse(IsNully(zeroMatters: true, Nully0  ));
        IsFalse(IsNully(             true, Nully0  ));
        IsFalse(IsNully(zeroMatters,       NoNull1 ));
        IsFalse(IsNully(zeroMatters: true, NoNull1 ));
        IsFalse(IsNully(             true, NoNull1 ));
        IsFalse(IsNully(zeroMatters,       Nully1  ));
        IsFalse(IsNully(zeroMatters: true, Nully1  ));
        IsFalse(IsNully(             true, Nully1  ));
    }

    // Objects

    [TestMethod]
    public void IsNully_Object_Extensions()
    {
        IsTrue (NullObj       .IsNully());
        IsFalse(NoNullObj     .IsNully());
        IsFalse(NullyFilledObj.IsNully());
    }

    [TestMethod]
    public void IsNully_Object_Static()
    {
        IsTrue (IsNully(NullObj       ));
        IsFalse(IsNully(NoNullObj     ));
        IsFalse(IsNully(NullyFilledObj));
    }

    // NotNullWhen

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