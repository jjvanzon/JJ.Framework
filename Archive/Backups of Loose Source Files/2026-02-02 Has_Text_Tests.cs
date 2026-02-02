
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Text_Tests : TestBase
{
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Has_Text_True()
    {
        IsTrue(Has(Text));
        IsTrue(Has(NullyFilled));
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
    public void Has_Text_SpaceMatters()
    {
        IsTrue (Has(Space,          spaceMatters: true ));
        IsTrue (Has(Space,          spaceMatters       ));
        IsTrue (Has(Space,                        true ));
        IsTrue (Has(NullySpace,     spaceMatters: true ));
        IsTrue (Has(NullySpace,     spaceMatters       ));
        IsTrue (Has(NullySpace,                   true ));
        IsFalse(Has(Space,          spaceMatters: false));
        IsFalse(Has(Space,                        false));
        IsFalse(Has(NullySpace,     spaceMatters: false));
        IsFalse(Has(NullySpace,                   false));
    }
}