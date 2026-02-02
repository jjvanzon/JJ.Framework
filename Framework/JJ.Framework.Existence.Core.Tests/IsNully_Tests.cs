namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Tests : TestBase
{
    private static readonly Dummy? NullyFilled = NullyFilledObj;
    
    // Objects

    [TestMethod]
    public void IsNully_Object_False()
    {
        IsFalse(IsNully(NoNullObj));
        IsFalse(IsNully(NullyFilled));
        IsFalse(NoNullObj.IsNully());
        IsFalse(NullyFilled.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Object_True()
    {
        IsTrue(IsNully(NullObj));
        IsTrue(NullObj.IsNully());
    }

    // Values

    // Text
        
    [TestMethod]
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(Text));
        IsFalse(IsNully(NullyFilled));
        IsFalse(Text.IsNully());
        IsFalse(NullyFilled.IsNully());
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
    public void IsNully_Text_SpaceMatters()
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
        IsTrue (Space     .IsNully( spaceMatters: false));
        IsTrue (Space     .IsNully(               false));
        IsTrue (NullySpace.IsNully( spaceMatters: false));
        IsTrue (NullySpace.IsNully(               false));
        IsTrue (IsNully(Space,      spaceMatters: false));
        IsTrue (IsNully(Space,                    false));
        IsTrue (IsNully(NullySpace, spaceMatters: false));
        IsTrue (IsNully(NullySpace,               false));
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
    public void IsNully_StringBuilder_SpaceMatters()
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
        IsTrue (SpaceSB     .IsNully( spaceMatters: false));
        IsTrue (SpaceSB     .IsNully(               false));
        IsTrue (NullySpaceSB.IsNully( spaceMatters: false));
        IsTrue (NullySpaceSB.IsNully(               false));
        IsTrue (IsNully(SpaceSB,      spaceMatters: false));
        IsTrue (IsNully(SpaceSB,                    false));
        IsTrue (IsNully(NullySpaceSB, spaceMatters: false));
        IsTrue (IsNully(NullySpaceSB,               false));
    }
}