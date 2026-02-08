// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Tests : TestBase
{
    // Text

    [TestMethod]
    public void FilledIn_Text_True_Extensions()
    {
        IsTrue(Text           .FilledIn());
        IsTrue(NullyFilledText.FilledIn());
    }
        
    [TestMethod]
    public void FilledIn_Text_True_Static()
    {
        IsTrue(FilledIn(Text           ));
        IsTrue(FilledIn(NullyFilledText));
    }        

    [TestMethod]
    public void FilledIn_Text_False_Extensions()
    {
        IsFalse(Empty     .FilledIn());
        IsFalse(Space     .FilledIn());
        IsFalse(NullText  .FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False_Static()
    {
        IsFalse(FilledIn(Empty     ));
        IsFalse(FilledIn(Space     ));
        IsFalse(FilledIn(NullText  ));
        IsFalse(FilledIn(NullyEmpty));
        IsFalse(FilledIn(NullySpace));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_Extensions()
    {
        IsFalse(NullText       .FilledIn(                        ));
        IsFalse(NullText       .FilledIn(     spaceMatters: false));
        IsFalse(NullText       .FilledIn(                   false));
        IsFalse(Empty          .FilledIn(                        ));
        IsFalse(Empty          .FilledIn(     spaceMatters: false));
        IsFalse(Empty          .FilledIn(                   false));
        IsFalse(NullyEmpty     .FilledIn(                        ));
        IsFalse(NullyEmpty     .FilledIn(     spaceMatters: false));
        IsFalse(NullyEmpty     .FilledIn(                   false));
        IsFalse(Space          .FilledIn(                        ));
        IsFalse(Space          .FilledIn(     spaceMatters: false));
        IsFalse(Space          .FilledIn(                   false));
        IsFalse(NullySpace     .FilledIn(                        ));
        IsFalse(NullySpace     .FilledIn(     spaceMatters: false));
        IsFalse(NullySpace     .FilledIn(                   false));
        IsTrue (Text           .FilledIn(                        ));
        IsTrue (Text           .FilledIn(     spaceMatters: false));
        IsTrue (Text           .FilledIn(                   false));
        IsTrue (NullyFilledText.FilledIn(                        ));
        IsTrue (NullyFilledText.FilledIn(     spaceMatters: false));
        IsTrue (NullyFilledText.FilledIn(                   false));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullText                                ));
        IsFalse(FilledIn(NullText,            spaceMatters: false));
        IsFalse(FilledIn(NullText,                          false));
        IsFalse(FilledIn(Empty                                   ));
        IsFalse(FilledIn(Empty,               spaceMatters: false));
        IsFalse(FilledIn(Empty,                             false));
        IsFalse(FilledIn(NullyEmpty                              ));
        IsFalse(FilledIn(NullyEmpty,          spaceMatters: false));
        IsFalse(FilledIn(NullyEmpty,                        false));
        IsFalse(FilledIn(Space                                   ));
        IsFalse(FilledIn(Space,               spaceMatters: false));
        IsFalse(FilledIn(Space,                             false));
        IsFalse(FilledIn(NullySpace                              ));
        IsFalse(FilledIn(NullySpace,          spaceMatters: false));
        IsFalse(FilledIn(NullySpace,                        false));
        IsTrue (FilledIn(Text                                    ));
        IsTrue (FilledIn(Text,                spaceMatters: false));
        IsTrue (FilledIn(Text,                              false));
        IsTrue (FilledIn(NullyFilledText                         ));
        IsTrue (FilledIn(NullyFilledText,     spaceMatters: false));
        IsTrue (FilledIn(NullyFilledText,                   false));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_StaticFlagsInFront()
    {
        IsFalse(FilledIn(                     NullText           ));
        IsFalse(FilledIn(spaceMatters: false, NullText           ));
        IsFalse(FilledIn(              false, NullText           ));
        IsFalse(FilledIn(                     Empty              ));
        IsFalse(FilledIn(spaceMatters: false, Empty              ));
        IsFalse(FilledIn(              false, Empty              ));
        IsFalse(FilledIn(                     NullyEmpty         ));
        IsFalse(FilledIn(spaceMatters: false, NullyEmpty         ));
        IsFalse(FilledIn(              false, NullyEmpty         ));
        IsFalse(FilledIn(                     Space              ));
        IsFalse(FilledIn(spaceMatters: false, Space              ));
        IsFalse(FilledIn(              false, Space              ));
        IsFalse(FilledIn(                     NullySpace         ));
        IsFalse(FilledIn(spaceMatters: false, NullySpace         ));
        IsFalse(FilledIn(              false, NullySpace         ));
        IsTrue (FilledIn(                     Text               ));
        IsTrue (FilledIn(spaceMatters: false, Text               ));
        IsTrue (FilledIn(              false, Text               ));
        IsTrue (FilledIn(                     NullyFilledText    ));
        IsTrue (FilledIn(spaceMatters: false, NullyFilledText    ));
        IsTrue (FilledIn(              false, NullyFilledText    ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Extensions()
    {
        IsFalse(NullText       .FilledIn(     spaceMatters       ));
        IsFalse(NullText       .FilledIn(     spaceMatters: true ));
        IsFalse(NullText       .FilledIn(                   true ));
        IsFalse(Empty          .FilledIn(     spaceMatters       ));
        IsFalse(Empty          .FilledIn(     spaceMatters: true ));
        IsFalse(Empty          .FilledIn(                   true ));
        IsFalse(NullyEmpty     .FilledIn(     spaceMatters       ));
        IsFalse(NullyEmpty     .FilledIn(     spaceMatters: true ));
        IsFalse(NullyEmpty     .FilledIn(                   true ));
        IsTrue (Space          .FilledIn(     spaceMatters       ));
        IsTrue (Space          .FilledIn(     spaceMatters: true ));
        IsTrue (Space          .FilledIn(                   true ));
        IsTrue (NullySpace     .FilledIn(     spaceMatters       ));
        IsTrue (NullySpace     .FilledIn(     spaceMatters: true ));
        IsTrue (NullySpace     .FilledIn(                   true ));
        IsTrue (Text           .FilledIn(     spaceMatters       ));
        IsTrue (Text           .FilledIn(     spaceMatters: true ));
        IsTrue (Text           .FilledIn(                   true ));
        IsTrue (NullyFilledText.FilledIn(     spaceMatters       ));
        IsTrue (NullyFilledText.FilledIn(     spaceMatters: true ));
        IsTrue (NullyFilledText.FilledIn(                   true ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Static_FlagsInBack()
    {
        IsFalse(FilledIn(NullText,            spaceMatters       ));
        IsFalse(FilledIn(NullText,            spaceMatters: true ));
        IsFalse(FilledIn(NullText,                          true ));
        IsFalse(FilledIn(Empty,               spaceMatters       ));
        IsFalse(FilledIn(Empty,               spaceMatters: true ));
        IsFalse(FilledIn(Empty,                             true ));
        IsFalse(FilledIn(NullyEmpty,          spaceMatters       ));
        IsFalse(FilledIn(NullyEmpty,          spaceMatters: true ));
        IsFalse(FilledIn(NullyEmpty,                        true ));
        IsTrue (FilledIn(Space,               spaceMatters       ));
        IsTrue (FilledIn(Space,               spaceMatters: true ));
        IsTrue (FilledIn(Space,                             true ));
        IsTrue (FilledIn(NullySpace,          spaceMatters       ));
        IsTrue (FilledIn(NullySpace,          spaceMatters: true ));
        IsTrue (FilledIn(NullySpace,                        true ));
        IsTrue (FilledIn(Text,                spaceMatters       ));
        IsTrue (FilledIn(Text,                spaceMatters: true ));
        IsTrue (FilledIn(Text,                              true ));
        IsTrue (FilledIn(NullyFilledText,     spaceMatters       ));
        IsTrue (FilledIn(NullyFilledText,     spaceMatters: true ));
        IsTrue (FilledIn(NullyFilledText,                   true ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Static_FlagsInFront()
    {
        IsFalse(FilledIn(spaceMatters,        NullText           ));
        IsFalse(FilledIn(spaceMatters: true,  NullText           ));
        IsFalse(FilledIn(              true,  NullText           ));
        IsFalse(FilledIn(spaceMatters,        Empty              ));
        IsFalse(FilledIn(spaceMatters: true,  Empty              ));
        IsFalse(FilledIn(              true,  Empty              ));
        IsFalse(FilledIn(spaceMatters,        NullyEmpty         ));
        IsFalse(FilledIn(spaceMatters: true,  NullyEmpty         ));
        IsFalse(FilledIn(              true,  NullyEmpty         ));
        IsTrue (FilledIn(spaceMatters,        Space              ));
        IsTrue (FilledIn(spaceMatters: true,  Space              ));
        IsTrue (FilledIn(              true,  Space              ));
        IsTrue (FilledIn(spaceMatters,        NullySpace         ));
        IsTrue (FilledIn(spaceMatters: true,  NullySpace         ));
        IsTrue (FilledIn(              true,  NullySpace         ));
        IsTrue (FilledIn(spaceMatters,        Text               ));
        IsTrue (FilledIn(spaceMatters: true,  Text               ));
        IsTrue (FilledIn(              true,  Text               ));
        IsTrue (FilledIn(spaceMatters,        NullyFilledText    ));
        IsTrue (FilledIn(spaceMatters: true,  NullyFilledText    ));
        IsTrue (FilledIn(              true,  NullyFilledText    ));
    }

    // StringBuilder
            
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
    
    // Booleans

    [TestMethod]
    public void FilledIn_Bool_Static()
    {
        IsTrue (FilledIn(true      ));
        IsFalse(FilledIn(false     ));
        IsTrue (FilledIn(True      ));
        IsFalse(FilledIn(False     ));
        IsTrue (FilledIn(NullyTrue ));
        IsFalse(FilledIn(NullyFalse));
        IsFalse(FilledIn(NullBool  ));
    }

    [TestMethod]
    public void FilledIn_Bool_Extensions()
    {
        IsTrue (true      .FilledIn());
        IsFalse(false     .FilledIn());
        IsTrue (True      .FilledIn());
        IsFalse(False     .FilledIn());
        IsTrue (NullyTrue .FilledIn());
        IsFalse(NullyFalse.FilledIn());
        IsFalse(NullBool  .FilledIn());
    }
        
    [TestMethod]
    public void FilledIn_Bool_ZeroMattersNo_Extensions()
    { 
        IsTrue (true      .FilledIn(                   ));
        IsTrue (true      .FilledIn( zeroMatters: false));
        IsTrue (true      .FilledIn(              false));
        IsFalse(false     .FilledIn(                   ));
        IsFalse(false     .FilledIn( zeroMatters: false));
        IsFalse(false     .FilledIn(              false));
        IsTrue (True      .FilledIn(                   ));
        IsTrue (True      .FilledIn( zeroMatters: false));
        IsTrue (True      .FilledIn(              false));
        IsFalse(False     .FilledIn(                   ));
        IsFalse(False     .FilledIn( zeroMatters: false));
        IsFalse(False     .FilledIn(              false));
        IsTrue (NullyTrue .FilledIn(                   ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: false));
        IsTrue (NullyTrue .FilledIn(              false));
        IsFalse(NullyFalse.FilledIn(                   ));
        IsFalse(NullyFalse.FilledIn( zeroMatters: false));
        IsFalse(NullyFalse.FilledIn(              false));
        IsFalse(NullBool  .FilledIn(                   ));
        IsFalse(NullBool  .FilledIn( zeroMatters: false));
        IsFalse(NullBool  .FilledIn(              false));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersNo_StaticFlagsInBack()
    { 
        IsTrue (FilledIn(true                          ));
        IsTrue (FilledIn(true,       zeroMatters: false));
        IsTrue (FilledIn(true,                    false));
        IsFalse(FilledIn(false                         ));
        IsFalse(FilledIn(false,      zeroMatters: false));
        IsFalse(FilledIn(false,                   false));
        IsTrue (FilledIn(True                          ));
        IsTrue (FilledIn(True,       zeroMatters: false));
        IsTrue (FilledIn(True,                    false));
        IsFalse(FilledIn(False                         ));
        IsFalse(FilledIn(False,      zeroMatters: false));
        IsFalse(FilledIn(False,                   false));
        IsTrue (FilledIn(NullyTrue                     ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: false));
        IsTrue (FilledIn(NullyTrue,               false));
        IsFalse(FilledIn(NullyFalse                    ));
        IsFalse(FilledIn(NullyFalse, zeroMatters: false));
        IsFalse(FilledIn(NullyFalse,              false));
        IsFalse(FilledIn(NullBool                      ));
        IsFalse(FilledIn(NullBool,   zeroMatters: false));
        IsFalse(FilledIn(NullBool,                false));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersNo_StaticFlagsInFront()
    {
        IsTrue (FilledIn(                    true      ));
        IsTrue (FilledIn(zeroMatters: false, true      ));
        IsTrue (FilledIn(             false, true      ));
        IsFalse(FilledIn(                    false     ));
        IsFalse(FilledIn(zeroMatters: false, false     ));
        IsFalse(FilledIn(             false, false     ));
        IsTrue (FilledIn(                    True      ));
        IsTrue (FilledIn(zeroMatters: false, True      ));
        IsTrue (FilledIn(             false, True      ));
        IsFalse(FilledIn(                    False     ));
        IsFalse(FilledIn(zeroMatters: false, False     ));
        IsFalse(FilledIn(             false, False     ));
        IsTrue (FilledIn(                    NullyTrue ));
        IsTrue (FilledIn(zeroMatters: false, NullyTrue ));
        IsTrue (FilledIn(             false, NullyTrue ));
        IsFalse(FilledIn(                    NullyFalse));
        IsFalse(FilledIn(zeroMatters: false, NullyFalse));
        IsFalse(FilledIn(             false, NullyFalse));
        IsFalse(FilledIn(                    NullBool  ));
        IsFalse(FilledIn(zeroMatters: false, NullBool  ));
        IsFalse(FilledIn(             false, NullBool  ));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersYes_Extensions()
    { 
        IsTrue (true      .FilledIn( zeroMatters       ));
        IsTrue (true      .FilledIn( zeroMatters: true ));
        IsTrue (true      .FilledIn(              true ));
        IsTrue (false     .FilledIn( zeroMatters       ));
        IsTrue (false     .FilledIn( zeroMatters: true ));
        IsTrue (false     .FilledIn(              true ));
        IsTrue (True      .FilledIn( zeroMatters       ));
        IsTrue (True      .FilledIn( zeroMatters: true ));
        IsTrue (True      .FilledIn(              true ));
        IsTrue (False     .FilledIn( zeroMatters       ));
        IsTrue (False     .FilledIn( zeroMatters: true ));
        IsTrue (False     .FilledIn(              true ));
        IsTrue (NullyTrue .FilledIn( zeroMatters       ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: true ));
        IsTrue (NullyTrue .FilledIn(              true ));
        IsTrue (NullyFalse.FilledIn( zeroMatters       ));
        IsTrue (NullyFalse.FilledIn( zeroMatters: true ));
        IsTrue (NullyFalse.FilledIn(              true ));
        IsFalse(NullBool  .FilledIn( zeroMatters       ));
        IsFalse(NullBool  .FilledIn( zeroMatters: true ));
        IsFalse(NullBool  .FilledIn(              true ));
    }
    
    [TestMethod]
    public void FilledIn_Bool_ZeroMattersYes_StaticFlagsInBack()
    { 
        IsTrue (FilledIn(true,       zeroMatters       ));
        IsTrue (FilledIn(true,       zeroMatters: true ));
        IsTrue (FilledIn(true,                    true ));
        IsTrue (FilledIn(false,      zeroMatters       ));
        IsTrue (FilledIn(false,      zeroMatters: true ));
        IsTrue (FilledIn(false,                   true ));
        IsTrue (FilledIn(True,       zeroMatters       ));
        IsTrue (FilledIn(True,       zeroMatters: true ));
        IsTrue (FilledIn(True,                    true ));
        IsTrue (FilledIn(False,      zeroMatters       ));
        IsTrue (FilledIn(False,      zeroMatters: true ));
        IsTrue (FilledIn(False,                   true ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters       ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: true ));
        IsTrue (FilledIn(NullyTrue,               true ));
        IsTrue (FilledIn(NullyFalse, zeroMatters       ));
        IsTrue (FilledIn(NullyFalse, zeroMatters: true ));
        IsTrue (FilledIn(NullyFalse,              true ));
        IsFalse(FilledIn(NullBool,   zeroMatters       ));
        IsFalse(FilledIn(NullBool,   zeroMatters: true ));
        IsFalse(FilledIn(NullBool,                true ));
    }

    [TestMethod]
    public void FilledIn_Bool_ZeroMattersYes_StaticFlagsInFront()
    {
        IsTrue (FilledIn(zeroMatters,        true      ));
        IsTrue (FilledIn(zeroMatters: true,  true      ));
        IsTrue (FilledIn(             true,  true      ));
        IsTrue (FilledIn(zeroMatters,        false     ));
        IsTrue (FilledIn(zeroMatters: true,  false     ));
        IsTrue (FilledIn(             true,  false     ));
        IsTrue (FilledIn(zeroMatters,        True      ));
        IsTrue (FilledIn(zeroMatters: true,  True      ));
        IsTrue (FilledIn(             true,  True      ));
        IsTrue (FilledIn(zeroMatters,        False     ));
        IsTrue (FilledIn(zeroMatters: true,  False     ));
        IsTrue (FilledIn(             true,  False     ));
        IsTrue (FilledIn(zeroMatters,        NullyTrue ));
        IsTrue (FilledIn(zeroMatters: true,  NullyTrue ));
        IsTrue (FilledIn(             true,  NullyTrue ));
        IsTrue (FilledIn(zeroMatters,        NullyFalse));
        IsTrue (FilledIn(zeroMatters: true,  NullyFalse));
        IsTrue (FilledIn(             true,  NullyFalse));
        IsFalse(FilledIn(zeroMatters,        NullBool  ));
        IsFalse(FilledIn(zeroMatters: true,  NullBool  ));
        IsFalse(FilledIn(             true,  NullBool  ));
    }

    /// <inheritdoc cref="_nullableflag" />
    [TestMethod]
    public void FilledIn_Bool_NullableFlag()
    {
        bool? nullyZeroMattersFalse = false;
        bool? nullyZeroMattersTrue  = true;

        // NOTE: Extension methods do not have the ambiguity problem.

        IsTrue (FilledIn(true,       nullyZeroMattersFalse         ));
        IsFalse(FilledIn(false,      nullyZeroMattersFalse         ));
        IsTrue (FilledIn(True,       nullyZeroMattersFalse         ));
        IsFalse(FilledIn(False,      nullyZeroMattersFalse         ));
        IsTrue (FilledIn(NullyTrue,  nullyZeroMattersFalse ?? false));
        IsFalse(FilledIn(NullyFalse, nullyZeroMattersFalse ?? false));
        IsFalse(FilledIn(NullBool,   nullyZeroMattersFalse ?? false));

        IsTrue (FilledIn(true,       nullyZeroMattersTrue          ));
        IsTrue (FilledIn(false,      nullyZeroMattersTrue          ));
        IsTrue (FilledIn(True,       nullyZeroMattersTrue          ));
        IsTrue (FilledIn(False,      nullyZeroMattersTrue          ));
        IsTrue (FilledIn(NullyTrue,  nullyZeroMattersTrue  ?? true ));
        IsTrue (FilledIn(NullyFalse, nullyZeroMattersTrue  ?? true ));
        IsFalse(FilledIn(NullBool,   nullyZeroMattersTrue  ?? true ));

        IsTrue (FilledIn(nullyZeroMattersFalse,          true       ));
        IsFalse(FilledIn(nullyZeroMattersFalse,          false      ));
        IsTrue (FilledIn(nullyZeroMattersFalse,          True       ));
        IsFalse(FilledIn(nullyZeroMattersFalse,          False      ));
        IsTrue (FilledIn(nullyZeroMattersFalse ?? false, NullyTrue  ));
        IsFalse(FilledIn(nullyZeroMattersFalse ?? false, NullyFalse ));
        IsFalse(FilledIn(nullyZeroMattersFalse ?? false, NullBool   ));

        IsTrue (FilledIn(nullyZeroMattersTrue,           true       ));
        IsTrue (FilledIn(nullyZeroMattersTrue,           false      ));
        IsTrue (FilledIn(nullyZeroMattersTrue,           True       ));
        IsTrue (FilledIn(nullyZeroMattersTrue,           False      ));
        IsTrue (FilledIn(nullyZeroMattersTrue  ?? true , NullyTrue  ));
        IsTrue (FilledIn(nullyZeroMattersTrue  ?? true , NullyFalse ));
        IsFalse(FilledIn(nullyZeroMattersTrue  ?? true , NullBool   ));
    }

    // Values

    // TODO: Rename 
    // TODO: ADd extension method syntax

    [TestMethod]
    public void FilledIn_Values_No()
    {
        IsFalse(FilledIn(NullNum));
        IsFalse(FilledIn(NoNull0));
        IsFalse(FilledIn(Nully0 ));
    }

    [TestMethod]
    public void FilledIn_Values_Yes()
    {
        IsTrue (FilledIn(NoNull1));
        IsTrue (FilledIn(NoNull2));
        IsTrue (FilledIn(NoNull3));
        IsTrue (FilledIn(Nully1 ));
        IsTrue (FilledIn(Nully2 ));
        IsTrue (FilledIn(Nully3 ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersNo_Extensions()
    {
        IsFalse(NullNum.FilledIn(                  ));
        IsFalse(NullNum.FilledIn(zeroMatters: false));
        IsFalse(NullNum.FilledIn(             false));
        IsFalse(NoNull0.FilledIn(                  ));
        IsFalse(NoNull0.FilledIn(zeroMatters: false));
        IsFalse(NoNull0.FilledIn(             false));
        IsFalse(Nully0 .FilledIn(                  ));
        IsFalse(Nully0 .FilledIn(zeroMatters: false));
        IsFalse(Nully0 .FilledIn(             false));
        IsTrue (NoNull1.FilledIn(                  ));
        IsTrue (NoNull1.FilledIn(zeroMatters: false));
        IsTrue (NoNull1.FilledIn(             false));
        IsTrue (Nully1 .FilledIn(                  ));
        IsTrue (Nully1 .FilledIn(zeroMatters: false));
        IsTrue (Nully1 .FilledIn(             false));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersNo_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullNum                    ));
        IsFalse(FilledIn(NullNum, zeroMatters: false));
        IsFalse(FilledIn(NullNum,              false));
        IsFalse(FilledIn(NoNull0                    ));
        IsFalse(FilledIn(NoNull0, zeroMatters: false));
        IsFalse(FilledIn(NoNull0,              false));
        IsFalse(FilledIn(Nully0                     ));
        IsFalse(FilledIn(Nully0,  zeroMatters: false));
        IsFalse(FilledIn(Nully0,               false));
        IsTrue (FilledIn(NoNull1                    ));
        IsTrue (FilledIn(NoNull1, zeroMatters: false));
        IsTrue (FilledIn(NoNull1,              false));
        IsTrue (FilledIn(Nully1                     ));
        IsTrue (FilledIn(Nully1,  zeroMatters: false));
        IsTrue (FilledIn(Nully1,               false));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersNo_StaticFlagsInFront()
    {
        IsFalse(FilledIn(                    NullNum));
        IsFalse(FilledIn(zeroMatters: false, NullNum));
        IsFalse(FilledIn(             false, NullNum));
        IsFalse(FilledIn(                    NoNull0));
        IsFalse(FilledIn(zeroMatters: false, NoNull0));
        IsFalse(FilledIn(             false, NoNull0));
        IsFalse(FilledIn(                    Nully0 ));
        IsFalse(FilledIn(zeroMatters: false, Nully0 ));
        IsFalse(FilledIn(             false, Nully0 ));
        IsTrue (FilledIn(                    NoNull1));
        IsTrue (FilledIn(zeroMatters: false, NoNull1));
        IsTrue (FilledIn(             false, NoNull1));
        IsTrue (FilledIn(                    Nully1 ));
        IsTrue (FilledIn(zeroMatters: false, Nully1 ));
        IsTrue (FilledIn(             false, Nully1 ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersYes_Extensions()
    {
        IsFalse(NullNum.FilledIn(zeroMatters       ));
        IsFalse(NullNum.FilledIn(zeroMatters: true ));
        IsFalse(NullNum.FilledIn(             true ));
        IsTrue (NoNull0.FilledIn(zeroMatters       ));
        IsTrue (NoNull0.FilledIn(zeroMatters: true ));
        IsTrue (NoNull0.FilledIn(             true ));
        IsTrue (Nully0 .FilledIn(zeroMatters       ));
        IsTrue (Nully0 .FilledIn(zeroMatters: true ));
        IsTrue (Nully0 .FilledIn(             true ));
        IsTrue (NoNull1.FilledIn(zeroMatters       ));
        IsTrue (NoNull1.FilledIn(zeroMatters: true ));
        IsTrue (NoNull1.FilledIn(             true ));
        IsTrue (Nully1 .FilledIn(zeroMatters       ));
        IsTrue (Nully1 .FilledIn(zeroMatters: true ));
        IsTrue (Nully1 .FilledIn(             true ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersYes_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullNum, zeroMatters       ));
        IsFalse(FilledIn(NullNum, zeroMatters: true ));
        IsFalse(FilledIn(NullNum,              true ));
        IsTrue (FilledIn(NoNull0, zeroMatters       ));
        IsTrue (FilledIn(NoNull0, zeroMatters: true ));
        IsTrue (FilledIn(NoNull0,              true ));
        IsTrue (FilledIn(Nully0,  zeroMatters       ));
        IsTrue (FilledIn(Nully0,  zeroMatters: true ));
        IsTrue (FilledIn(Nully0,               true ));
        IsTrue (FilledIn(NoNull1, zeroMatters       ));
        IsTrue (FilledIn(NoNull1, zeroMatters: true ));
        IsTrue (FilledIn(NoNull1,              true ));
        IsTrue (FilledIn(Nully1,  zeroMatters       ));
        IsTrue (FilledIn(Nully1,  zeroMatters: true ));
        IsTrue (FilledIn(Nully1,               true ));
    }

    [TestMethod]
    public void FilledIn_Values_ZeroMattersYes_StaticFlagsInFront()
    {
        IsFalse(FilledIn(zeroMatters,       NullNum ));
        IsFalse(FilledIn(zeroMatters: true, NullNum ));
        IsFalse(FilledIn(             true, NullNum ));
        IsTrue (FilledIn(zeroMatters,       NoNull0 ));
        IsTrue (FilledIn(zeroMatters: true, NoNull0 ));
        IsTrue (FilledIn(             true, NoNull0 ));
        IsTrue (FilledIn(zeroMatters,       Nully0  ));
        IsTrue (FilledIn(zeroMatters: true, Nully0  ));
        IsTrue (FilledIn(             true, Nully0  ));
        IsTrue (FilledIn(zeroMatters,       NoNull1 ));
        IsTrue (FilledIn(zeroMatters: true, NoNull1 ));
        IsTrue (FilledIn(             true, NoNull1 ));
        IsTrue (FilledIn(zeroMatters,       Nully1  ));
        IsTrue (FilledIn(zeroMatters: true, Nully1  ));
        IsTrue (FilledIn(             true, Nully1  ));
    }

    // Objects

    [TestMethod]
    public void FilledIn_Object_Extensions()
    {
        IsFalse(NullObj       .FilledIn());
        IsTrue (NoNullObj     .FilledIn());
        IsTrue (NullyFilledObj.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Object_Static()
    {
        IsFalse(FilledIn(NullObj       ));
        IsTrue (FilledIn(NoNullObj     ));
        IsTrue (FilledIn(NullyFilledObj));
    }
}