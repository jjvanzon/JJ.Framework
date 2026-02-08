namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Tests : TestBase
{
    // Text
        
    [TestMethod]
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(Text));
        IsFalse(IsNully(NullyFilledText));
        IsFalse(Text.IsNully());
        IsFalse(NullyFilledText.IsNully());
    }

    [TestMethod] 
    public void IsNully_Text_True()
    {
        IsTrue(Empty     .IsNully());
        IsTrue(Space     .IsNully());
        IsTrue(NullText.  IsNully());
        IsTrue(NullyEmpty.IsNully());
        IsTrue(NullySpace.IsNully());
        IsTrue(IsNully(Empty      ));
        IsTrue(IsNully(Space      ));
        IsTrue(IsNully(NullText   ));
        IsTrue(IsNully(NullyEmpty ));
        IsTrue(IsNully(NullySpace ));
    }

    [TestMethod]
    public void IsNully_Text_SpaceMattersYes()
    {
        IsFalse(Space     .IsNully( spaceMatters: true ));
        IsFalse(Space     .IsNully( spaceMatters       ));
        IsFalse(Space     .IsNully(               true ));
        IsFalse(NullySpace.IsNully( spaceMatters: true ));
        IsFalse(NullySpace.IsNully( spaceMatters       ));
        IsFalse(NullySpace.IsNully(               true ));
        IsFalse(IsNully(Space,      spaceMatters: true ));
        IsFalse(IsNully(Space,      spaceMatters       ));
        IsFalse(IsNully(Space,                    true ));
        IsFalse(IsNully(NullySpace, spaceMatters: true ));
        IsFalse(IsNully(NullySpace, spaceMatters       ));
        IsFalse(IsNully(NullySpace,               true ));
        IsFalse(IsNully(spaceMatters: true, Space      ));
        IsFalse(IsNully(spaceMatters      , Space      ));
        IsFalse(IsNully(              true, Space      ));
        IsFalse(IsNully(spaceMatters: true, NullySpace ));
        IsFalse(IsNully(spaceMatters      , NullySpace ));
        IsFalse(IsNully(              true, NullySpace ));
    }

    [TestMethod]
    public void IsNully_Text_SpaceMattersNo()
    {
        IsTrue (Space     .IsNully( spaceMatters: false));
        IsTrue (Space     .IsNully(               false));
        IsTrue (NullySpace.IsNully( spaceMatters: false));
        IsTrue (NullySpace.IsNully(               false));
        IsTrue (IsNully(Space,      spaceMatters: false));
        IsTrue (IsNully(Space,                    false));
        IsTrue (IsNully(NullySpace, spaceMatters: false));
        IsTrue (IsNully(NullySpace,               false));
        IsTrue (IsNully(spaceMatters: false, Space     ));
        IsTrue (IsNully(              false, Space     ));
        IsTrue (IsNully(spaceMatters: false, NullySpace));
        IsTrue (IsNully(              false, NullySpace));
    }

    // StringBuilder
        
    [TestMethod]
    public void IsNully_StringBuilder_False()
    {
        IsFalse(FilledSB     .IsNully());
        IsFalse(NullyFilledSB.IsNully());
        IsFalse(IsNully(FilledSB      ));
        IsFalse(IsNully(NullyFilledSB ));
    }

    [TestMethod] 
    public void IsNully_StringBuilder_True()
    {
        IsTrue(EmptySB     .IsNully());
        IsTrue(SpaceSB     .IsNully());
        IsTrue(NullSB.      IsNully());
        IsTrue(NullyEmptySB.IsNully());
        IsTrue(NullySpaceSB.IsNully());
        IsTrue(IsNully(EmptySB      ));
        IsTrue(IsNully(SpaceSB      ));
        IsTrue(IsNully(NullSB       ));
        IsTrue(IsNully(NullyEmptySB ));
        IsTrue(IsNully(NullySpaceSB ));
    }

    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersYes()
    {
        IsFalse(SpaceSB     .IsNully( spaceMatters: true ));
        IsFalse(SpaceSB     .IsNully( spaceMatters       ));
        IsFalse(SpaceSB     .IsNully(               true ));
        IsFalse(NullySpaceSB.IsNully( spaceMatters: true ));
        IsFalse(NullySpaceSB.IsNully( spaceMatters       ));
        IsFalse(NullySpaceSB.IsNully(               true ));
        IsFalse(IsNully(SpaceSB,      spaceMatters: true ));
        IsFalse(IsNully(SpaceSB,      spaceMatters       ));
        IsFalse(IsNully(SpaceSB,                    true ));
        IsFalse(IsNully(NullySpaceSB, spaceMatters: true ));
        IsFalse(IsNully(NullySpaceSB, spaceMatters       ));
        IsFalse(IsNully(NullySpaceSB,               true ));
        IsFalse(IsNully(spaceMatters: true, SpaceSB      ));
        IsFalse(IsNully(spaceMatters      , SpaceSB      ));
        IsFalse(IsNully(              true, SpaceSB      ));
        IsFalse(IsNully(spaceMatters: true, NullySpaceSB ));
        IsFalse(IsNully(spaceMatters      , NullySpaceSB ));
        IsFalse(IsNully(              true, NullySpaceSB ));
    }

    [TestMethod]
    public void IsNully_StringBuilder_SpaceMattersNo()
    {
        IsTrue (SpaceSB     .IsNully( spaceMatters: false));
        IsTrue (SpaceSB     .IsNully(               false));
        IsTrue (NullySpaceSB.IsNully( spaceMatters: false));
        IsTrue (NullySpaceSB.IsNully(               false));
        IsTrue (IsNully(SpaceSB,      spaceMatters: false));
        IsTrue (IsNully(SpaceSB,                    false));
        IsTrue (IsNully(NullySpaceSB, spaceMatters: false));
        IsTrue (IsNully(NullySpaceSB,               false));
        IsTrue (IsNully(spaceMatters: false, SpaceSB     ));
        IsTrue (IsNully(              false, SpaceSB     ));
        IsTrue (IsNully(spaceMatters: false, NullySpaceSB));
        IsTrue (IsNully(              false, NullySpaceSB));
    }

    // Values
    
    [TestMethod]
    public void IsNully_False_Int1()
    {
        // Invariant under zeroMatters
        IsFalse(NoNull1.IsNully(                   ));
        IsFalse(NoNull1.IsNully( zeroMatters       ));
        IsFalse(NoNull1.IsNully( zeroMatters: true ));
        IsFalse(NoNull1.IsNully(              true ));
        IsFalse(NoNull1.IsNully( zeroMatters: false));
        IsFalse(NoNull1.IsNully(              false));
        IsFalse(Nully1 .IsNully(                   ));
        IsFalse(Nully1 .IsNully( zeroMatters       ));
        IsFalse(Nully1 .IsNully( zeroMatters: true ));
        IsFalse(Nully1 .IsNully(              true ));
        IsFalse(Nully1 .IsNully( zeroMatters: false));
        IsFalse(Nully1 .IsNully(              false));
        IsFalse(IsNully(NoNull1                    ));
        IsFalse(IsNully(NoNull1, zeroMatters       ));
        IsFalse(IsNully(NoNull1, zeroMatters: true ));
        IsFalse(IsNully(NoNull1,              true ));
        IsFalse(IsNully(NoNull1, zeroMatters: false));
        IsFalse(IsNully(NoNull1,              false));
        IsFalse(IsNully(Nully1                     ));
        IsFalse(IsNully(Nully1,  zeroMatters       ));
        IsFalse(IsNully(Nully1,  zeroMatters: true ));
        IsFalse(IsNully(Nully1,               true ));
        IsFalse(IsNully(Nully1,  zeroMatters: false));
        IsFalse(IsNully(Nully1,               false));
        IsFalse(IsNully(zeroMatters       , NoNull1));
        IsFalse(IsNully(zeroMatters: true , NoNull1));
        IsFalse(IsNully(             true , NoNull1));
        IsFalse(IsNully(zeroMatters: false, NoNull1));
        IsFalse(IsNully(             false, NoNull1));
        IsFalse(IsNully(zeroMatters       , Nully1 ));
        IsFalse(IsNully(zeroMatters: true , Nully1 ));
        IsFalse(IsNully(             true , Nully1 ));
        IsFalse(IsNully(zeroMatters: false, Nully1 ));
        IsFalse(IsNully(             false, Nully1 ));
    }

    [TestMethod]
    public void IsNully_True_Int0()
    {
        IsTrue(NoNull0.IsNully(                   ));
        IsTrue(NoNull0.IsNully( zeroMatters: false));
        IsTrue(NoNull0.IsNully(              false));
        IsTrue(Nully0 .IsNully(                   ));
        IsTrue(Nully0 .IsNully( zeroMatters: false));
        IsTrue(Nully0 .IsNully(              false));
        IsTrue(IsNully(NoNull0                    ));
        IsTrue(IsNully(NoNull0, zeroMatters: false));
        IsTrue(IsNully(NoNull0,              false));
        IsTrue(IsNully(Nully0                     ));
        IsTrue(IsNully(Nully0,  zeroMatters: false));
        IsTrue(IsNully(Nully0,               false));
        IsTrue(IsNully(zeroMatters: false, NoNull0));
        IsTrue(IsNully(             false, NoNull0));
        IsTrue(IsNully(zeroMatters: false, Nully0 ));
        IsTrue(IsNully(             false, Nully0 ));
    }
    
    [TestMethod]
    public void IsNully_True_IntNull()
    {
        IsTrue(NullNum.IsNully(                   ));
        IsTrue(NullNum.IsNully( zeroMatters: false));
        IsTrue(NullNum.IsNully(              false));
        IsTrue(IsNully(NullNum                    ));
        IsTrue(IsNully(NullNum, zeroMatters: false));
        IsTrue(IsNully(NullNum,              false));
        IsTrue(IsNully(zeroMatters: false, NullNum));
        IsTrue(IsNully(             false, NullNum));
    }

    [TestMethod]
    public void IsNully_False_Int0_ZeroMatters()
    {
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(NoNull0,              true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
        IsFalse(IsNully(Nully0,               true ));
        IsFalse(NoNull0.IsNully( zeroMatters       ));
        IsFalse(NoNull0.IsNully( zeroMatters: true ));
        IsFalse(NoNull0.IsNully(              true ));
        IsFalse(Nully0 .IsNully( zeroMatters       ));
        IsFalse(Nully0 .IsNully( zeroMatters: true ));
        IsFalse(Nully0 .IsNully(              true ));
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(NoNull0,              true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
        IsFalse(IsNully(Nully0,               true ));
    }

    [TestMethod]
    public void IsNully_True_IntNull_ZeroMatters()
    {
        IsTrue(IsNully(NullNum, zeroMatters       ));
        IsTrue(IsNully(NullNum, zeroMatters: true ));
        IsTrue(IsNully(NullNum,              true ));
        IsTrue(NullNum.IsNully( zeroMatters       ));
        IsTrue(NullNum.IsNully( zeroMatters: true ));
        IsTrue(NullNum.IsNully(              true ));
        IsTrue(IsNully(NullNum, zeroMatters       ));
        IsTrue(IsNully(NullNum, zeroMatters: true ));
        IsTrue(IsNully(NullNum,              true ));
    }

    // Objects

    [TestMethod]
    public void IsNully_Object_False()
    {
        IsFalse(IsNully(NoNullObj));
        IsFalse(IsNully(NullyFilledObj));
        IsFalse(NoNullObj.IsNully());
        IsFalse(NullyFilledObj.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Object_True()
    {
        IsTrue(IsNully(NullObj));
        IsTrue(NullObj.IsNully());
    }
}