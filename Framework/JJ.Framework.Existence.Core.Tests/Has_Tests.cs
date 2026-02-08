// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Tests : TestBase
{
    // Text

    [TestMethod]
    public void Has_Text_True()
    {
        IsTrue(Has(Text           ));
        IsTrue(Has(NullyFilledText));
    }

    [TestMethod]
    public void Has_Text_False()
    {
        IsFalse(Has(Empty     ));
        IsFalse(Has(Space     ));
        IsFalse(Has(NullText  ));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersNo_FlagsInBack()
    {
        IsFalse(Has(NullText                                ));
        IsFalse(Has(NullText,            spaceMatters: false));
        IsFalse(Has(NullText,                          false));
        IsFalse(Has(Empty                                   ));
        IsFalse(Has(Empty,               spaceMatters: false));
        IsFalse(Has(Empty,                             false));
        IsFalse(Has(NullyEmpty                              ));
        IsFalse(Has(NullyEmpty,          spaceMatters: false));
        IsFalse(Has(NullyEmpty,                        false));
        IsFalse(Has(Space                                   ));
        IsFalse(Has(Space,               spaceMatters: false));
        IsFalse(Has(Space,                             false));
        IsFalse(Has(NullySpace                              ));
        IsFalse(Has(NullySpace,          spaceMatters: false));
        IsFalse(Has(NullySpace,                        false));
        IsTrue (Has(Text                                    ));
        IsTrue (Has(Text,                spaceMatters: false));
        IsTrue (Has(Text,                              false));
        IsTrue (Has(NullyFilledText                         ));
        IsTrue (Has(NullyFilledText,     spaceMatters: false));
        IsTrue (Has(NullyFilledText,                   false));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersNo_FlagsInFront()
    {
        IsFalse(Has(                     NullText           ));
        IsFalse(Has(spaceMatters: false, NullText           ));
        IsFalse(Has(              false, NullText           ));
        IsFalse(Has(                     Empty              ));
        IsFalse(Has(spaceMatters: false, Empty              ));
        IsFalse(Has(              false, Empty              ));
        IsFalse(Has(                     NullyEmpty         ));
        IsFalse(Has(spaceMatters: false, NullyEmpty         ));
        IsFalse(Has(              false, NullyEmpty         ));
        IsFalse(Has(                     Space              ));
        IsFalse(Has(spaceMatters: false, Space              ));
        IsFalse(Has(              false, Space              ));
        IsFalse(Has(                     NullySpace         ));
        IsFalse(Has(spaceMatters: false, NullySpace         ));
        IsFalse(Has(              false, NullySpace         ));
        IsTrue (Has(                     Text               ));
        IsTrue (Has(spaceMatters: false, Text               ));
        IsTrue (Has(              false, Text               ));
        IsTrue (Has(                     NullyFilledText    ));
        IsTrue (Has(spaceMatters: false, NullyFilledText    ));
        IsTrue (Has(              false, NullyFilledText    ));

    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersYes_FlagsInBack()
    {
        IsFalse(Has(NullText,            spaceMatters       ));
        IsFalse(Has(NullText,            spaceMatters: true ));
        IsFalse(Has(NullText,                          true ));
        IsFalse(Has(Empty,               spaceMatters       ));
        IsFalse(Has(Empty,               spaceMatters: true ));
        IsFalse(Has(Empty,                             true ));
        IsFalse(Has(NullyEmpty,          spaceMatters       ));
        IsFalse(Has(NullyEmpty,          spaceMatters: true ));
        IsFalse(Has(NullyEmpty,                        true ));
        IsTrue (Has(Space,               spaceMatters       ));
        IsTrue (Has(Space,               spaceMatters: true ));
        IsTrue (Has(Space,                             true ));
        IsTrue (Has(NullySpace,          spaceMatters       ));
        IsTrue (Has(NullySpace,          spaceMatters: true ));
        IsTrue (Has(NullySpace,                        true ));
        IsTrue (Has(Text,                spaceMatters       ));
        IsTrue (Has(Text,                spaceMatters: true ));
        IsTrue (Has(Text,                              true ));
        IsTrue (Has(NullyFilledText,     spaceMatters       ));
        IsTrue (Has(NullyFilledText,     spaceMatters: true ));
        IsTrue (Has(NullyFilledText,                   true ));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersYes_FlagsInFront()
    {
        IsFalse(Has(spaceMatters,        NullText           ));
        IsFalse(Has(spaceMatters: true,  NullText           ));
        IsFalse(Has(              true,  NullText           ));
        IsFalse(Has(spaceMatters,        Empty              ));
        IsFalse(Has(spaceMatters: true,  Empty              ));
        IsFalse(Has(              true,  Empty              ));
        IsFalse(Has(spaceMatters,        NullyEmpty         ));
        IsFalse(Has(spaceMatters: true,  NullyEmpty         ));
        IsFalse(Has(              true,  NullyEmpty         ));
        IsTrue (Has(spaceMatters,        Space              ));
        IsTrue (Has(spaceMatters: true,  Space              ));
        IsTrue (Has(              true,  Space              ));
        IsTrue (Has(spaceMatters,        NullySpace         ));
        IsTrue (Has(spaceMatters: true,  NullySpace         ));
        IsTrue (Has(              true,  NullySpace         ));
        IsTrue (Has(spaceMatters,        Text               ));
        IsTrue (Has(spaceMatters: true,  Text               ));
        IsTrue (Has(              true,  Text               ));
        IsTrue (Has(spaceMatters,        NullyFilledText    ));
        IsTrue (Has(spaceMatters: true,  NullyFilledText    ));
        IsTrue (Has(              true,  NullyFilledText    ));
    }

    // StringBuilder

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

    // Booleans

    [TestMethod]
    public void Has_Bool()
    {
        IsTrue (Has(true));
        IsFalse(Has(false));
        IsTrue (Has(True));
        IsFalse(Has(False));
        IsTrue (Has(NullyTrue));
        IsFalse(Has(NullyFalse));
        IsFalse(Has(NullBool));
    }
    
    [TestMethod]
    public void Has_Bool_ZeroMattersNo_FlagsInBack()
    { 
        IsTrue (Has(true                          ));
        IsTrue (Has(true,       zeroMatters: false));
        IsTrue (Has(true,                    false));
        IsFalse(Has(false                         ));
        IsFalse(Has(false,      zeroMatters: false));
        IsFalse(Has(false,                   false));
        IsTrue (Has(True                          ));
        IsTrue (Has(True,       zeroMatters: false));
        IsTrue (Has(True,                    false));
        IsFalse(Has(False                         ));
        IsFalse(Has(False,      zeroMatters: false));
        IsFalse(Has(False,                   false));
        IsTrue (Has(NullyTrue                     ));
        IsTrue (Has(NullyTrue,  zeroMatters: false));
        IsTrue (Has(NullyTrue,               false));
        IsFalse(Has(NullyFalse                    ));
        IsFalse(Has(NullyFalse, zeroMatters: false));
        IsFalse(Has(NullyFalse,              false));
        IsFalse(Has(NullBool                      ));
        IsFalse(Has(NullBool,   zeroMatters: false));
        IsFalse(Has(NullBool,                false));
    }

    [TestMethod]
    public void Has_Bool_ZeroMattersNo_FlagsInFront()
    {
        IsTrue (Has(                    true      ));
        IsTrue (Has(zeroMatters: false, true      ));
        IsTrue (Has(             false, true      ));
        IsFalse(Has(                    false     ));
        IsFalse(Has(zeroMatters: false, false     ));
        IsFalse(Has(             false, false     ));
        IsTrue (Has(                    True      ));
        IsTrue (Has(zeroMatters: false, True      ));
        IsTrue (Has(             false, True      ));
        IsFalse(Has(                    False     ));
        IsFalse(Has(zeroMatters: false, False     ));
        IsFalse(Has(             false, False     ));
        IsTrue (Has(                    NullyTrue ));
        IsTrue (Has(zeroMatters: false, NullyTrue ));
        IsTrue (Has(             false, NullyTrue ));
        IsFalse(Has(                    NullyFalse));
        IsFalse(Has(zeroMatters: false, NullyFalse));
        IsFalse(Has(             false, NullyFalse));
        IsFalse(Has(                    NullBool  ));
        IsFalse(Has(zeroMatters: false, NullBool  ));
        IsFalse(Has(             false, NullBool  ));
    }
    
    [TestMethod]
    public void Has_Bool_ZeroMattersYes_FlagsInBack()
    { 
        IsTrue (Has(true,       zeroMatters       ));
        IsTrue (Has(true,       zeroMatters: true ));
        IsTrue (Has(true,                    true ));
        IsTrue (Has(false,      zeroMatters       ));
        IsTrue (Has(false,      zeroMatters: true ));
        IsTrue (Has(false,                   true ));
        IsTrue (Has(True,       zeroMatters       ));
        IsTrue (Has(True,       zeroMatters: true ));
        IsTrue (Has(True,                    true ));
        IsTrue (Has(False,      zeroMatters       ));
        IsTrue (Has(False,      zeroMatters: true ));
        IsTrue (Has(False,                   true ));
        IsTrue (Has(NullyTrue,  zeroMatters       ));
        IsTrue (Has(NullyTrue,  zeroMatters: true ));
        IsTrue (Has(NullyTrue,               true ));
        IsTrue (Has(NullyFalse, zeroMatters       ));
        IsTrue (Has(NullyFalse, zeroMatters: true ));
        IsTrue (Has(NullyFalse,              true ));
        IsFalse(Has(NullBool,   zeroMatters       ));
        IsFalse(Has(NullBool,   zeroMatters: true ));
        IsFalse(Has(NullBool,                true ));
    }

    [TestMethod]
    public void Has_Bool_ZeroMattersYes_FlagsInFront()
    {
        IsTrue (Has(zeroMatters,        true      ));
        IsTrue (Has(zeroMatters: true,  true      ));
        IsTrue (Has(             true,  true      ));
        IsTrue (Has(zeroMatters,        false     ));
        IsTrue (Has(zeroMatters: true,  false     ));
        IsTrue (Has(             true,  false     ));
        IsTrue (Has(zeroMatters,        True      ));
        IsTrue (Has(zeroMatters: true,  True      ));
        IsTrue (Has(             true,  True      ));
        IsTrue (Has(zeroMatters,        False     ));
        IsTrue (Has(zeroMatters: true,  False     ));
        IsTrue (Has(             true,  False     ));
        IsTrue (Has(zeroMatters,        NullyTrue ));
        IsTrue (Has(zeroMatters: true,  NullyTrue ));
        IsTrue (Has(             true,  NullyTrue ));
        IsTrue (Has(zeroMatters,        NullyFalse));
        IsTrue (Has(zeroMatters: true,  NullyFalse));
        IsTrue (Has(             true,  NullyFalse));
        IsFalse(Has(zeroMatters,        NullBool  ));
        IsFalse(Has(zeroMatters: true,  NullBool  ));
        IsFalse(Has(             true,  NullBool  ));
    }

    /// <inheritdoc cref="_nullableflag" />
    [TestMethod]
    public void Has_Bool_NullableFlag()
    {
        bool? nullyZeroMattersFalse = false;
        bool? nullyZeroMattersTrue  = true;

        IsTrue (Has(true,       nullyZeroMattersFalse         ));
        IsFalse(Has(false,      nullyZeroMattersFalse         ));
        IsTrue (Has(True,       nullyZeroMattersFalse         ));
        IsFalse(Has(False,      nullyZeroMattersFalse         ));
        IsTrue (Has(NullyTrue,  nullyZeroMattersFalse ?? false));
        IsFalse(Has(NullyFalse, nullyZeroMattersFalse ?? false));
        IsFalse(Has(NullBool,   nullyZeroMattersFalse ?? false));

        IsTrue (Has(true,       nullyZeroMattersTrue          ));
        IsTrue (Has(false,      nullyZeroMattersTrue          ));
        IsTrue (Has(True,       nullyZeroMattersTrue          ));
        IsTrue (Has(False,      nullyZeroMattersTrue          ));
        IsTrue (Has(NullyTrue,  nullyZeroMattersTrue  ?? true ));
        IsTrue (Has(NullyFalse, nullyZeroMattersTrue  ?? true ));
        IsFalse(Has(NullBool,   nullyZeroMattersTrue  ?? true ));

        IsTrue (Has(nullyZeroMattersFalse,          true       ));
        IsFalse(Has(nullyZeroMattersFalse,          false      ));
        IsTrue (Has(nullyZeroMattersFalse,          True       ));
        IsFalse(Has(nullyZeroMattersFalse,          False      ));
        IsTrue (Has(nullyZeroMattersFalse ?? false, NullyTrue  ));
        IsFalse(Has(nullyZeroMattersFalse ?? false, NullyFalse ));
        IsFalse(Has(nullyZeroMattersFalse ?? false, NullBool   ));

        IsTrue (Has(nullyZeroMattersTrue,           true       ));
        IsTrue (Has(nullyZeroMattersTrue,           false      ));
        IsTrue (Has(nullyZeroMattersTrue,           True       ));
        IsTrue (Has(nullyZeroMattersTrue,           False      ));
        IsTrue (Has(nullyZeroMattersTrue  ?? true , NullyTrue  ));
        IsTrue (Has(nullyZeroMattersTrue  ?? true , NullyFalse ));
        IsFalse(Has(nullyZeroMattersTrue  ?? true , NullBool   ));
    }

    // Values

    [TestMethod]
    public void Has_Values_No()
    {
        IsFalse(Has(NullNum));
        IsFalse(Has(NoNull0));
        IsFalse(Has(Nully0 ));
    }

    [TestMethod]
    public void Has_Values_Yes()
    {
        IsTrue (Has(NoNull1));
        IsTrue (Has(NoNull2));
        IsTrue (Has(NoNull3));
        IsTrue (Has(Nully1 ));
        IsTrue (Has(Nully2 ));
        IsTrue (Has(Nully3 ));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersNo_FlagsInBack()
    {
        IsFalse(Has(NullNum                    ));
        IsFalse(Has(NullNum, zeroMatters: false));
        IsFalse(Has(NullNum,              false));
        IsFalse(Has(NoNull0                    ));
        IsFalse(Has(NoNull0, zeroMatters: false));
        IsFalse(Has(NoNull0,              false));
        IsFalse(Has(Nully0                     ));
        IsFalse(Has(Nully0,  zeroMatters: false));
        IsFalse(Has(Nully0,               false));
        IsTrue (Has(NoNull1                    ));
        IsTrue (Has(NoNull1, zeroMatters: false));
        IsTrue (Has(NoNull1,              false));
        IsTrue (Has(Nully1                     ));
        IsTrue (Has(Nully1,  zeroMatters: false));
        IsTrue (Has(Nully1,               false));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersNo_FlagsInFront()
    {
        IsFalse(Has(                    NullNum));
        IsFalse(Has(zeroMatters: false, NullNum));
        IsFalse(Has(             false, NullNum));
        IsFalse(Has(                    NoNull0));
        IsFalse(Has(zeroMatters: false, NoNull0));
        IsFalse(Has(             false, NoNull0));
        IsFalse(Has(                    Nully0 ));
        IsFalse(Has(zeroMatters: false, Nully0 ));
        IsFalse(Has(             false, Nully0 ));
        IsTrue (Has(                    NoNull1));
        IsTrue (Has(zeroMatters: false, NoNull1));
        IsTrue (Has(             false, NoNull1));
        IsTrue (Has(                    Nully1 ));
        IsTrue (Has(zeroMatters: false, Nully1 ));
        IsTrue (Has(             false, Nully1 ));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersYes_FlagsInBack()
    {
        IsFalse(Has(NullNum, zeroMatters       ));
        IsFalse(Has(NullNum, zeroMatters: true ));
        IsFalse(Has(NullNum,              true ));
        IsTrue (Has(NoNull0, zeroMatters       ));
        IsTrue (Has(NoNull0, zeroMatters: true ));
        IsTrue (Has(NoNull0,              true ));
        IsTrue (Has(Nully0,  zeroMatters       ));
        IsTrue (Has(Nully0,  zeroMatters: true ));
        IsTrue (Has(Nully0,               true ));
        IsTrue (Has(NoNull1, zeroMatters       ));
        IsTrue (Has(NoNull1, zeroMatters: true ));
        IsTrue (Has(NoNull1,              true ));
        IsTrue (Has(Nully1,  zeroMatters       ));
        IsTrue (Has(Nully1,  zeroMatters: true ));
        IsTrue (Has(Nully1,               true ));
    }

    [TestMethod]
    public void Has_Values_ZeroMattersYes_FlagsInFront()
    {
        IsFalse(Has(zeroMatters,       NullNum ));
        IsFalse(Has(zeroMatters: true, NullNum ));
        IsFalse(Has(             true, NullNum ));
        IsTrue (Has(zeroMatters,       NoNull0 ));
        IsTrue (Has(zeroMatters: true, NoNull0 ));
        IsTrue (Has(             true, NoNull0 ));
        IsTrue (Has(zeroMatters,       Nully0  ));
        IsTrue (Has(zeroMatters: true, Nully0  ));
        IsTrue (Has(             true, Nully0  ));
        IsTrue (Has(zeroMatters,       NoNull1 ));
        IsTrue (Has(zeroMatters: true, NoNull1 ));
        IsTrue (Has(             true, NoNull1 ));
        IsTrue (Has(zeroMatters,       Nully1  ));
        IsTrue (Has(zeroMatters: true, Nully1  ));
        IsTrue (Has(             true, Nully1  ));
    }

    // Objects
    
    [TestMethod]
    public void Has_Object()
    {
        IsFalse(Has(NullObj));
        IsTrue (Has(NoNullObj));
        IsTrue (Has(NullyFilledObj));
    }
}