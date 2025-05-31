namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Text : TestBase
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
    public void IsNully_Text_TrimSpace()
    {
        IsFalse(NullySpace.IsNully(trimSpace: false));
        IsFalse(NullySpace.IsNully(false));
        IsFalse(Space.IsNully(trimSpace: false));
        IsFalse(Space.IsNully(false));
        IsFalse(IsNully(NullySpace, trimSpace: false));
        IsFalse(IsNully(NullySpace, false));
        IsFalse(IsNully(Space, trimSpace: false));
        IsFalse(IsNully(Space, false));
    }
        
    [TestMethod]
    public void FilledIn_Text_TrimSpace()
    {
        IsTrue(Has(NullySpace, trimSpace: false));
        IsTrue(Has(NullySpace, false));
        IsTrue(Has(Space, trimSpace: false));
        IsTrue(Has(Space, false));
        IsTrue(NullySpace.FilledIn(trimSpace: false));
        IsTrue(NullySpace.FilledIn(false));
        IsTrue(Space.FilledIn(trimSpace: false));
        IsTrue(Space.FilledIn(false));
        IsTrue(FilledIn(NullySpace, trimSpace: false));
        IsTrue(FilledIn(NullySpace, false));
        IsTrue(FilledIn(Space, trimSpace: false));
        IsTrue(FilledIn(Space, false));
    }
    
}