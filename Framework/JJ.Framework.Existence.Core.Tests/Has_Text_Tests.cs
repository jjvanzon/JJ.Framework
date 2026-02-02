
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
    public void FilledIn_Text_True()
    {
        IsTrue(FilledIn(Text));
        IsTrue(FilledIn(NullyFilled));
        IsTrue(Text.FilledIn());
        IsTrue(NullyFilled.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(FilledIn( Empty     ));
        IsFalse(FilledIn( Space     ));
        IsFalse(FilledIn( NullText  ));
        IsFalse(FilledIn( NullyEmpty));
        IsFalse(FilledIn( NullySpace));
        IsFalse(Empty     .FilledIn());
        IsFalse(Space     .FilledIn());
        IsFalse(NullText  .FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
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
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(Text));
        IsFalse(IsNully(NullyFilled));
        IsFalse(Text.IsNully());
        IsFalse(NullyFilled.IsNully());
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
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersYes()
    {
        IsTrue (Space     .FilledIn( spaceMatters: true ));
        IsTrue (Space     .FilledIn( spaceMatters       ));
        IsTrue (Space     .FilledIn(               true ));
        IsTrue (NullySpace.FilledIn( spaceMatters: true ));
        IsTrue (NullySpace.FilledIn( spaceMatters       ));
        IsTrue (NullySpace.FilledIn(               true ));
        IsTrue (FilledIn(Space,      spaceMatters: true ));
        IsTrue (FilledIn(Space,      spaceMatters       ));
        IsTrue (FilledIn(Space,                    true ));
        IsTrue (FilledIn(NullySpace, spaceMatters: true ));
        IsTrue (FilledIn(NullySpace, spaceMatters       ));
        IsTrue (FilledIn(NullySpace,               true ));
        IsTrue (FilledIn(spaceMatters: true,  Space     ));
        IsTrue (FilledIn(spaceMatters,        Space     ));
        IsTrue (FilledIn(              true,  Space     ));
        IsTrue (FilledIn(spaceMatters: true,  NullySpace));
        IsTrue (FilledIn(spaceMatters,        NullySpace));
        IsTrue (FilledIn(              true,  NullySpace));
    }
    
    [TestMethod]
    public void FilledIn_Text_SpaceMattersNo()
    {
        IsFalse(Space     .FilledIn( spaceMatters: false));
        IsFalse(Space     .FilledIn(               false));
        IsFalse(NullySpace.FilledIn( spaceMatters: false));
        IsFalse(NullySpace.FilledIn(               false));
        IsFalse(FilledIn(Space,      spaceMatters: false));
        IsFalse(FilledIn(Space,                    false));
        IsFalse(FilledIn(NullySpace, spaceMatters: false));
        IsFalse(FilledIn(NullySpace,               false));
        IsFalse(FilledIn(spaceMatters: false, Space     ));
        IsFalse(FilledIn(              false, Space     ));
        IsFalse(FilledIn(spaceMatters: false, NullySpace));
        IsFalse(FilledIn(              false, NullySpace));
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
}