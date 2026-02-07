namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Tests : TestBase
{
    // Text

    [TestMethod]
    public void Has_Text_True()
    {
        IsTrue(Has(Text));
        IsTrue(Has(NullyFilledText));
    }

    [TestMethod]
    public void Has_Text_False()
    {
        IsFalse(Has(Empty));
        IsFalse(Has(Space));
        IsFalse(Has(NullText));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
    }
    
    [TestMethod]
    public void Has_Text_SpaceMattersYes()
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
    
    [TestMethod]
    public void Has_Text_SpaceMattersNo()
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
        IsFalse(Has(EmptySB     ));
        IsFalse(Has(SpaceSB     ));
        IsFalse(Has(NullSB      ));
        IsFalse(Has(NullyEmptySB));
        IsFalse(Has(NullySpaceSB));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMattersYes()
    {
        IsTrue (Has(SpaceSB,      spaceMatters: true ));
        IsTrue (Has(SpaceSB,      spaceMatters       ));
        IsTrue (Has(SpaceSB,                    true ));
        IsTrue (Has(NullySpaceSB, spaceMatters: true ));
        IsTrue (Has(NullySpaceSB, spaceMatters       ));
        IsTrue (Has(NullySpaceSB,               true ));
        IsTrue (Has(spaceMatters: true, SpaceSB      ));
        IsTrue (Has(spaceMatters,       SpaceSB      ));
        IsTrue (Has(              true, SpaceSB      ));
        IsTrue (Has(spaceMatters: true, NullySpaceSB ));
        IsTrue (Has(spaceMatters,       NullySpaceSB ));
        IsTrue (Has(              true, NullySpaceSB ));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMattersNo()
    {
        IsFalse(Has(SpaceSB,      spaceMatters: false));
        IsFalse(Has(SpaceSB,                    false));
        IsFalse(Has(NullySpaceSB, spaceMatters: false));
        IsFalse(Has(NullySpaceSB,               false));
        IsFalse(Has(spaceMatters: false, SpaceSB     ));
        IsFalse(Has(              false, SpaceSB     ));
        IsFalse(Has(spaceMatters: false, NullySpaceSB));
        IsFalse(Has(              false, NullySpaceSB));
    }

    // Values

    [TestMethod]
    public void Has_True_Int1()
    {
        // Invariant under zeroMatters
        IsTrue(Has(NoNull1                    ));
        IsTrue(Has(NoNull1, zeroMatters       ));
        IsTrue(Has(NoNull1, zeroMatters: true ));
        IsTrue(Has(NoNull1, zeroMatters: false));
        IsTrue(Has(Nully1                     ));
        IsTrue(Has(Nully1,  zeroMatters       ));
        IsTrue(Has(Nully1,  zeroMatters: true ));
        IsTrue(Has(Nully1,  zeroMatters: false));
        IsTrue(Has(zeroMatters,        NoNull1));
        IsTrue(Has(zeroMatters: true,  NoNull1));
        IsTrue(Has(zeroMatters: false, NoNull1));
        IsTrue(Has(zeroMatters,        Nully1 ));
        IsTrue(Has(zeroMatters: true,  Nully1 ));
        IsTrue(Has(zeroMatters: false, Nully1 ));
    }
    
    [TestMethod]
    public void Has_False_Int0()
    {
        IsFalse(Has(NoNull0                    ));
        IsFalse(Has(NoNull0, zeroMatters: false));
        IsFalse(Has(NoNull0,              false));
        IsFalse(Has(Nully0                     ));
        IsFalse(Has(Nully0,  zeroMatters: false));
        IsFalse(Has(Nully0,               false));
        IsFalse(Has(zeroMatters: false, NoNull0));
        IsFalse(Has(             false, NoNull0));
        IsFalse(Has(zeroMatters: false, Nully0 ));
        IsFalse(Has(             false, Nully0 ));
    }
    
    [TestMethod]
    public void Has_False_IntNull()
    {
        IsFalse(Has(NullNum                    ));
        IsFalse(Has(NullNum, zeroMatters: false));
        IsFalse(Has(NullNum,              false));
        IsFalse(Has(zeroMatters: false, NullNum));
        IsFalse(Has(             false, NullNum));
    }

    [TestMethod]
    public void Has_True_Int0_ZeroMatters()
    {
        IsTrue(Has(NoNull0, zeroMatters       ));
        IsTrue(Has(NoNull0, zeroMatters: true ));
        IsTrue(Has(NoNull0,              true ));
        IsTrue(Has(Nully0,  zeroMatters       ));
        IsTrue(Has(Nully0,  zeroMatters: true ));
        IsTrue(Has(Nully0,               true ));
        IsTrue(Has(zeroMatters,       NoNull0 ));
        IsTrue(Has(zeroMatters: true, NoNull0 ));
        IsTrue(Has(             true, NoNull0 ));
        IsTrue(Has(zeroMatters,       Nully0  ));
        IsTrue(Has(zeroMatters: true, Nully0  ));
        IsTrue(Has(             true, Nully0  ));
    }

    [TestMethod]
    public void Has_False_IntNull_ZeroMatters()
    {
        IsFalse(Has(NullNum, zeroMatters       ));
        IsFalse(Has(NullNum, zeroMatters: true ));
        IsFalse(Has(NullNum,              true ));
        IsFalse(Has(zeroMatters,       NullNum ));
        IsFalse(Has(zeroMatters: true, NullNum ));
        IsFalse(Has(             true, NullNum ));
    }

    // Objects

    [TestMethod]
    public void Has_Object_True()
    {
        IsTrue(Has(NoNullObj));
        IsTrue(Has(NullyFilledObj));
    }
    
    [TestMethod]
    public void Has_Object_False()
    {
        IsFalse(Has(NullObj));
    }
}