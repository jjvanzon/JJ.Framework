namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class TextTests
{
    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue(Has(NullyWithText));
        IsTrue(Has(NonNullText));
        IsTrue(FilledIn(NullyWithText));
        IsTrue(FilledIn(NonNullText));
        IsTrue(NullyWithText.FilledIn());
        IsTrue(NonNullText.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(Has(NullText));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
        IsFalse(Has(NonNullEmpty));
        IsFalse(Has(NonNullSpace));
        IsFalse(FilledIn(NullText));
        IsFalse(FilledIn(NullyEmpty));
        IsFalse(FilledIn(NullySpace));
        IsFalse(FilledIn(NonNullEmpty));
        IsFalse(FilledIn(NonNullSpace));
        IsFalse(NullText.FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
        IsFalse(NonNullEmpty.FilledIn());
        IsFalse(NonNullSpace.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(NullyWithText));
        IsFalse(IsNully(NonNullText));
        IsFalse(NullyWithText.IsNully());
        IsFalse(NonNullText.IsNully());
    }

    [TestMethod] 
    public void IsNully_Text_True()
    {
        IsTrue(IsNully(NullText));
        IsTrue(IsNully(NullyEmpty));
        IsTrue(IsNully(NullySpace));
        IsTrue(IsNully(NonNullEmpty));
        IsTrue(IsNully(NonNullSpace));
        IsTrue(NullText.IsNully());
        IsTrue(NullyEmpty.IsNully());
        IsTrue(NullySpace.IsNully());
        IsTrue(NonNullEmpty.IsNully());
        IsTrue(NonNullSpace.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Text_TrimSpace()
    {
        IsFalse(NullySpace.IsNully(trimSpace: false));
        IsFalse(NullySpace.IsNully(false));
        IsFalse(NonNullSpace.IsNully(trimSpace: false));
        IsFalse(NonNullSpace.IsNully(false));
        IsFalse(IsNully(NullySpace, trimSpace: false));
        IsFalse(IsNully(NullySpace, false));
        IsFalse(IsNully(NonNullSpace, trimSpace: false));
        IsFalse(IsNully(NonNullSpace, false));
    }
        
    [TestMethod]
    public void FilledIn_Text_TrimSpace()
    {
        IsTrue(Has(NullySpace, trimSpace: false));
        IsTrue(Has(NullySpace, false));
        IsTrue(Has(NonNullSpace, trimSpace: false));
        IsTrue(Has(NonNullSpace, false));
        IsTrue(NullySpace.FilledIn(trimSpace: false));
        IsTrue(NullySpace.FilledIn(false));
        IsTrue(NonNullSpace.FilledIn(trimSpace: false));
        IsTrue(NonNullSpace.FilledIn(false));
        IsTrue(FilledIn(NullySpace, trimSpace: false));
        IsTrue(FilledIn(NullySpace, false));
        IsTrue(FilledIn(NonNullSpace, trimSpace: false));
        IsTrue(FilledIn(NonNullSpace, false));
    }
    
}