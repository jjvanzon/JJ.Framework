namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_StringBuilder_Tests : TestBase
{
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
    public void FilledIn_StringBuilder_True()
    {
        IsTrue(FilledIn(FilledSB      ));
        IsTrue(FilledIn(NullyFilledSB ));
        IsTrue(FilledSB     .FilledIn());
        IsTrue(NullyFilledSB.FilledIn());
    }

    [TestMethod]
    public void FilledIn_StringBuilder_False()
    {
        IsFalse(FilledIn(EmptySB      ));
        IsFalse(FilledIn(SpaceSB      ));
        IsFalse(FilledIn(NullSB       ));
        IsFalse(FilledIn(NullyEmptySB ));
        IsFalse(FilledIn(NullySpaceSB ));
        IsFalse(EmptySB     .FilledIn());
        IsFalse(SpaceSB     .FilledIn());
        IsFalse(NullSB      .FilledIn());
        IsFalse(NullyEmptySB.FilledIn());
        IsFalse(NullySpaceSB.FilledIn());
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
    public void IsNully_StringBuilder_False()
    {
        IsFalse(FilledSB     .IsNully());
        IsFalse(NullyFilledSB.IsNully());
        IsFalse(IsNully(FilledSB      ));
        IsFalse(IsNully(NullyFilledSB ));
    }
            
    [TestMethod]
    public void Has_StringBuilder_SpaceMatters()
    {
        IsTrue (Has(SpaceSB,          spaceMatters: true ));
        IsTrue (Has(SpaceSB,          spaceMatters       ));
        IsTrue (Has(SpaceSB,                        true ));
        IsTrue (Has(NullySpaceSB,     spaceMatters: true ));
        IsTrue (Has(NullySpaceSB,     spaceMatters       ));
        IsTrue (Has(NullySpaceSB,                   true ));
        IsFalse(Has(SpaceSB,          spaceMatters: false));
        IsFalse(Has(SpaceSB,                        false));
        IsFalse(Has(NullySpaceSB,     spaceMatters: false));
        IsFalse(Has(NullySpaceSB,                   false));
    }
    
    [TestMethod]
    public void FilledIn_StringBuilder_SpaceMatters()
    {
        IsTrue (SpaceSB     .FilledIn( spaceMatters: true ));
        IsTrue (SpaceSB     .FilledIn( spaceMatters       ));
        IsTrue (SpaceSB     .FilledIn(               true ));
        IsTrue (NullySpaceSB.FilledIn( spaceMatters: true ));
        IsTrue (NullySpaceSB.FilledIn( spaceMatters       ));
        IsTrue (NullySpaceSB.FilledIn(               true ));
        IsTrue (FilledIn(SpaceSB,      spaceMatters: true ));
        IsTrue (FilledIn(SpaceSB,      spaceMatters       ));
        IsTrue (FilledIn(SpaceSB,                    true ));
        IsTrue (FilledIn(NullySpaceSB, spaceMatters: true ));
        IsTrue (FilledIn(NullySpaceSB, spaceMatters       ));
        IsTrue (FilledIn(NullySpaceSB,               true ));
        IsFalse(SpaceSB     .FilledIn( spaceMatters: false));
        IsFalse(SpaceSB     .FilledIn(               false));
        IsFalse(NullySpaceSB.FilledIn( spaceMatters: false));
        IsFalse(NullySpaceSB.FilledIn(               false));
        IsFalse(FilledIn(SpaceSB,      spaceMatters: false));
        IsFalse(FilledIn(SpaceSB,                    false));
        IsFalse(FilledIn(NullySpaceSB, spaceMatters: false));
        IsFalse(FilledIn(NullySpaceSB,               false));
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