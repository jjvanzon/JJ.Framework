namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Tests : TestBase
{
    // Text
        
    [TestMethod]
    public void FilledIn_Text_True_Static()
    {
        IsTrue(FilledIn(Text));
        IsTrue(FilledIn(NullyFilledText));
    }        

    [TestMethod]
    public void FilledIn_Text_True_Extensions()
    {
        IsTrue(Text.FilledIn());
        IsTrue(NullyFilledText.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False_Static()
    {
        IsFalse(FilledIn( Empty     ));
        IsFalse(FilledIn( Space     ));
        IsFalse(FilledIn( NullText  ));
        IsFalse(FilledIn( NullyEmpty));
        IsFalse(FilledIn( NullySpace));
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
    public void FilledIn_Text_SpaceMattersYes_Extensions()
    {
        IsTrue (Space     .FilledIn( spaceMatters       ));
        IsTrue (Space     .FilledIn( spaceMatters: true ));
        IsTrue (Space     .FilledIn(               true ));
        IsTrue (NullySpace.FilledIn( spaceMatters       ));
        IsTrue (NullySpace.FilledIn( spaceMatters: true ));
        IsTrue (NullySpace.FilledIn(               true ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Static_FlagsInBack()
    {
        IsTrue (FilledIn(Space,      spaceMatters       ));
        IsTrue (FilledIn(Space,      spaceMatters: true ));
        IsTrue (FilledIn(Space,                    true ));
        IsTrue (FilledIn(NullySpace, spaceMatters       ));
        IsTrue (FilledIn(NullySpace, spaceMatters: true ));
        IsTrue (FilledIn(NullySpace,               true ));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes_Static_FlagsInFront()
    {
        IsTrue (FilledIn(spaceMatters,        Space     ));
        IsTrue (FilledIn(spaceMatters: true,  Space     ));
        IsTrue (FilledIn(              true,  Space     ));
        IsTrue (FilledIn(spaceMatters,        NullySpace));
        IsTrue (FilledIn(spaceMatters: true,  NullySpace));
        IsTrue (FilledIn(              true,  NullySpace));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_Extensions()
    {
        IsFalse(Space     .FilledIn( spaceMatters: false));
        IsFalse(Space     .FilledIn(               false));
        IsFalse(NullySpace.FilledIn( spaceMatters: false));
        IsFalse(NullySpace.FilledIn(               false));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_StaticFlagsInBack()
    {
        IsFalse(FilledIn(Space,      spaceMatters: false));
        IsFalse(FilledIn(Space,                    false));
        IsFalse(FilledIn(NullySpace, spaceMatters: false));
        IsFalse(FilledIn(NullySpace,               false));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo_StaticFlagsInFront()
    {
        IsFalse(FilledIn(spaceMatters: false, Space     ));
        IsFalse(FilledIn(              false, Space     ));
        IsFalse(FilledIn(spaceMatters: false, NullySpace));
        IsFalse(FilledIn(              false, NullySpace));
    }

    // StringBuilder
    
    [TestMethod]
    public void FilledIn_StringBuilder_True_Static()
    {
        IsTrue(FilledIn(FilledSB      ));
        IsTrue(FilledIn(NullyFilledSB ));
    }

    [TestMethod]
    public void FilledIn_StringBuilder_True_Extensions()
    {
        IsTrue(FilledSB     .FilledIn());
        IsTrue(NullyFilledSB.FilledIn());
    }

    [TestMethod]
    public void FilledIn_StringBuilder_False_Static()
    {
        IsFalse(FilledIn(EmptySB      ));
        IsFalse(FilledIn(SpaceSB      ));
        IsFalse(FilledIn(NullSB       ));
        IsFalse(FilledIn(NullyEmptySB ));
        IsFalse(FilledIn(NullySpaceSB ));
    }

    [TestMethod]
    public void FilledIn_StringBuilder_False_Extensions()
    {
        IsFalse(EmptySB     .FilledIn());
        IsFalse(SpaceSB     .FilledIn());
        IsFalse(NullSB      .FilledIn());
        IsFalse(NullyEmptySB.FilledIn());
        IsFalse(NullySpaceSB.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersYes_Extensions()
    {
        IsTrue (SpaceSB     .FilledIn( spaceMatters: true ));
        IsTrue (SpaceSB     .FilledIn( spaceMatters       ));
        IsTrue (SpaceSB     .FilledIn(               true ));
        IsTrue (NullySpaceSB.FilledIn( spaceMatters: true ));
        IsTrue (NullySpaceSB.FilledIn( spaceMatters       ));
        IsTrue (NullySpaceSB.FilledIn(               true ));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersYes_StaticFlagsInBack()
    {
        IsTrue (FilledIn(SpaceSB,      spaceMatters: true ));
        IsTrue (FilledIn(SpaceSB,      spaceMatters       ));
        IsTrue (FilledIn(SpaceSB,                    true ));
        IsTrue (FilledIn(NullySpaceSB, spaceMatters: true ));
        IsTrue (FilledIn(NullySpaceSB, spaceMatters       ));
        IsTrue (FilledIn(NullySpaceSB,               true ));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersYes_StaticFlagsInFront()
    {
        IsTrue (FilledIn(spaceMatters: true, SpaceSB      ));
        IsTrue (FilledIn(spaceMatters,       SpaceSB      ));
        IsTrue (FilledIn(              true, SpaceSB      ));
        IsTrue (FilledIn(spaceMatters: true, NullySpaceSB ));
        IsTrue (FilledIn(spaceMatters,       NullySpaceSB ));
        IsTrue (FilledIn(              true, NullySpaceSB ));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersNo_Extensions()
    {
        IsFalse(SpaceSB     .FilledIn( spaceMatters: false));
        IsFalse(SpaceSB     .FilledIn(               false));
        IsFalse(NullySpaceSB.FilledIn( spaceMatters: false));
        IsFalse(NullySpaceSB.FilledIn(               false));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersNo_StaticFlagsInBack()
    {
        IsFalse(FilledIn(SpaceSB,      spaceMatters: false));
        IsFalse(FilledIn(SpaceSB,                    false));
        IsFalse(FilledIn(NullySpaceSB, spaceMatters: false));
        IsFalse(FilledIn(NullySpaceSB,               false));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMattersNo_StaticFlagsInFront()
    {
        IsFalse(FilledIn(spaceMatters: false, SpaceSB     ));
        IsFalse(FilledIn(              false, SpaceSB     ));
        IsFalse(FilledIn(spaceMatters: false, NullySpaceSB));
        IsFalse(FilledIn(              false, NullySpaceSB));
    }
    
    // Values

    [TestMethod]
    public void FilledIn_True_Int1_Extensions()
    {
        IsTrue(NoNull1.FilledIn(                   ));
        IsTrue(NoNull1.FilledIn( zeroMatters       ));
        IsTrue(NoNull1.FilledIn( zeroMatters: true ));
        IsTrue(NoNull1.FilledIn(              true ));
        IsTrue(NoNull1.FilledIn( zeroMatters: false));
        IsTrue(NoNull1.FilledIn(              false));
        IsTrue(Nully1 .FilledIn(                   ));
        IsTrue(Nully1 .FilledIn( zeroMatters       ));
        IsTrue(Nully1 .FilledIn( zeroMatters: true ));
        IsTrue(Nully1 .FilledIn(              true ));
        IsTrue(Nully1 .FilledIn( zeroMatters: false));
        IsTrue(Nully1 .FilledIn(              false));
    }

    [TestMethod]
    public void FilledIn_True_Int1_StaticFlagsInBack()
    {
        IsTrue(FilledIn(NoNull1                    ));
        IsTrue(FilledIn(NoNull1, zeroMatters       ));
        IsTrue(FilledIn(NoNull1, zeroMatters: true ));
        IsTrue(FilledIn(NoNull1,              true ));
        IsTrue(FilledIn(NoNull1, zeroMatters: false));
        IsTrue(FilledIn(NoNull1,              false));
        IsTrue(FilledIn(Nully1                     ));
        IsTrue(FilledIn(Nully1,  zeroMatters       ));
        IsTrue(FilledIn(Nully1,  zeroMatters: true ));
        IsTrue(FilledIn(Nully1,               true ));
        IsTrue(FilledIn(Nully1,  zeroMatters: false));
        IsTrue(FilledIn(Nully1,               false));
    }

    [TestMethod]
    public void FilledIn_True_Int1_StaticFlagsInFront()
    {
        IsTrue(FilledIn(zeroMatters,        NoNull1));
        IsTrue(FilledIn(zeroMatters: true,  NoNull1));
        IsTrue(FilledIn(zeroMatters,        NoNull1));
        IsTrue(FilledIn(zeroMatters: false, NoNull1));
        IsTrue(FilledIn(             false, NoNull1));
        IsTrue(FilledIn(zeroMatters,        Nully1 ));
        IsTrue(FilledIn(zeroMatters: true,  Nully1 ));
        IsTrue(FilledIn(             true,  Nully1 ));
        IsTrue(FilledIn(zeroMatters: false, Nully1 ));
        IsTrue(FilledIn(             false, Nully1 ));
    }
    
    [TestMethod]
    public void FilledIn_False_Int0_Extensions()
    {
        IsFalse(NoNull0.FilledIn(                   ));
        IsFalse(NoNull0.FilledIn( zeroMatters: false));
        IsFalse(NoNull0.FilledIn(              false));
        IsFalse(Nully0 .FilledIn(                   ));
        IsFalse(Nully0 .FilledIn( zeroMatters: false));
        IsFalse(Nully0 .FilledIn(              false));
    }
    
    [TestMethod]
    public void FilledIn_False_Int0_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NoNull0                    ));
        IsFalse(FilledIn(NoNull0, zeroMatters: false));
        IsFalse(FilledIn(NoNull0,              false));
        IsFalse(FilledIn(Nully0                     ));
        IsFalse(FilledIn(Nully0,  zeroMatters: false));
        IsFalse(FilledIn(Nully0,               false));
    }
    
    [TestMethod]
    public void FilledIn_False_Int0_StaticFlagsInFront()
    {
        IsFalse(FilledIn(zeroMatters: false, NoNull0));
        IsFalse(FilledIn(             false, NoNull0));
        IsFalse(FilledIn(zeroMatters: false, Nully0 ));
        IsFalse(FilledIn(             false, Nully0 ));
    }
    
    [TestMethod]
    public void FilledIn_False_IntNull_Extensions()
    {
        IsFalse(NullNum.FilledIn(                   ));
        IsFalse(NullNum.FilledIn( zeroMatters: false));
        IsFalse(NullNum.FilledIn(              false));
    }
    
    [TestMethod]
    public void FilledIn_False_IntNull_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullNum                    ));
        IsFalse(FilledIn(NullNum, zeroMatters: false));
        IsFalse(FilledIn(NullNum,              false));
    }
    
    [TestMethod]
    public void FilledIn_False_IntNull_StaticFlagsInFront()
    {
        IsFalse(FilledIn(zeroMatters: false, NullNum));
        IsFalse(FilledIn(             false, NullNum));
    }

    [TestMethod]
    public void FilledIn_True_Int0_ZeroMatters_Extensions()
    {
        IsTrue(NoNull0.FilledIn( zeroMatters       ));
        IsTrue(NoNull0.FilledIn( zeroMatters: true ));
        IsTrue(NoNull0.FilledIn(              true ));
        IsTrue(Nully0 .FilledIn( zeroMatters       ));
        IsTrue(Nully0 .FilledIn( zeroMatters: true ));
        IsTrue(Nully0 .FilledIn(              true ));
    }

    [TestMethod]
    public void FilledIn_True_Int0_ZeroMatters_StaticFlagsInBack()
    {
        IsTrue(FilledIn(NoNull0, zeroMatters       ));
        IsTrue(FilledIn(NoNull0, zeroMatters: true ));
        IsTrue(FilledIn(NoNull0,              true ));
        IsTrue(FilledIn(Nully0,  zeroMatters       ));
        IsTrue(FilledIn(Nully0,  zeroMatters: true ));
        IsTrue(FilledIn(Nully0,               true ));
    }

    [TestMethod]
    public void FilledIn_True_Int0_ZeroMatters_StaticFlagsInFront()
    {
        IsTrue(FilledIn(zeroMatters,       NoNull0 ));
        IsTrue(FilledIn(zeroMatters: true, NoNull0 ));
        IsTrue(FilledIn(             true, NoNull0 ));
        IsTrue(FilledIn(zeroMatters,       Nully0  ));
        IsTrue(FilledIn(zeroMatters: true, Nully0  ));
        IsTrue(FilledIn(             true, Nully0  ));
    }

    [TestMethod]
    public void FilledIn_False_IntNull_ZeroMatters_Extensions()
    {
        IsFalse(NullNum.FilledIn( zeroMatters       ));
        IsFalse(NullNum.FilledIn( zeroMatters: true ));
        IsFalse(NullNum.FilledIn(              true ));
    }

    [TestMethod]
    public void FilledIn_False_IntNull_ZeroMatters_StaticFlagsInBack()
    {
        IsFalse(FilledIn(NullNum, zeroMatters       ));
        IsFalse(FilledIn(NullNum, zeroMatters: true ));
        IsFalse(FilledIn(NullNum,              true ));
    }

    [TestMethod]
    public void FilledIn_False_IntNull_ZeroMatters_StaticFlagsInFront()
    {
        IsFalse(FilledIn(zeroMatters,       NullNum ));
        IsFalse(FilledIn(zeroMatters: true, NullNum ));
        IsFalse(FilledIn(             true, NullNum ));
    }

    // Objects

    [TestMethod]
    public void FilledIn_Object_True_Static()
    {
        IsTrue(FilledIn(NoNullObj));
        IsTrue(FilledIn(NullyFilledObj));
    }

    [TestMethod]
    public void FilledIn_Object_True_Extensions()
    {
        IsTrue(NoNullObj.FilledIn());
        IsTrue(NullyFilledObj.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Object_False_Static()
    {
        IsFalse(FilledIn(NullObj));
    }

    [TestMethod]
    public void FilledIn_Object_False_Extensions()
    {
        IsFalse(NullObj.FilledIn());
    }
}