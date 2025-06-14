namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Text_Tests : TestBase
{
    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue(Has(NullyText));
        IsTrue(Has(Text));
        IsTrue(FilledIn(NullyText));
        IsTrue(FilledIn(Text));
        IsTrue(NullyText.FilledIn());
        IsTrue(Text.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(Has(NullText));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
        IsFalse(Has(Empty));
        IsFalse(Has(Space));
        IsFalse(FilledIn(NullText));
        IsFalse(FilledIn(NullyEmpty));
        IsFalse(FilledIn(NullySpace));
        IsFalse(FilledIn(Empty));
        IsFalse(FilledIn(Space));
        IsFalse(NullText.FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
        IsFalse(Empty.FilledIn());
        IsFalse(Space.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(NullyText));
        IsFalse(IsNully(Text));
        IsFalse(NullyText.IsNully());
        IsFalse(Text.IsNully());
    }

    [TestMethod] 
    public void IsNully_Text_True()
    {
        IsTrue(IsNully(NullText));
        IsTrue(IsNully(NullyEmpty));
        IsTrue(IsNully(NullySpace));
        IsTrue(IsNully(Empty));
        IsTrue(IsNully(Space));
        IsTrue(NullText.IsNully());
        IsTrue(NullyEmpty.IsNully());
        IsTrue(NullySpace.IsNully());
        IsTrue(Empty.IsNully());
        IsTrue(Space.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Text_SpaceMatters()
    {
        IsFalse(NullySpace.IsNully(spaceMatters: true));
        IsFalse(NullySpace.IsNully(true));
        IsFalse(Space.IsNully(spaceMatters: true));
        IsFalse(Space.IsNully(true));
        IsFalse(IsNully(NullySpace, spaceMatters: true));
        IsFalse(IsNully(NullySpace, true));
        IsFalse(IsNully(Space, spaceMatters: true));
        IsFalse(IsNully(Space, true));
    }
        
    [TestMethod]
    public void FilledIn_Text_TrimSpace()
    {
        IsTrue(Has(NullySpace, spaceMatters: true));
        IsTrue(Has(NullySpace, true));
        IsTrue(Has(Space, spaceMatters: true));
        IsTrue(Has(Space, true));
        IsTrue(NullySpace.FilledIn(spaceMatters: true));
        IsTrue(NullySpace.FilledIn(true));
        IsTrue(Space.FilledIn(spaceMatters: true));
        IsTrue(Space.FilledIn(true));
        IsTrue(FilledIn(NullySpace, spaceMatters: true));
        IsTrue(FilledIn(NullySpace, true));
        IsTrue(FilledIn(Space, spaceMatters: true));
        IsTrue(FilledIn(Space, true));
    }
    
}