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
}