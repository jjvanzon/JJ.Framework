namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Tests
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