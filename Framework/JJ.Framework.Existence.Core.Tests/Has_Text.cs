namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Text
{
    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue(Has(NullyWithText));
        IsTrue(Has(NoNullText));
        IsTrue(FilledIn(NullyWithText));
        IsTrue(FilledIn(NoNullText));
        IsTrue(NullyWithText.FilledIn());
        IsTrue(NoNullText.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(Has(NullText));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
        IsFalse(Has(NoNullEmpty));
        IsFalse(Has(NoNullSpace));
        IsFalse(FilledIn(NullText));
        IsFalse(FilledIn(NullyEmpty));
        IsFalse(FilledIn(NullySpace));
        IsFalse(FilledIn(NoNullEmpty));
        IsFalse(FilledIn(NoNullSpace));
        IsFalse(NullText.FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
        IsFalse(NoNullEmpty.FilledIn());
        IsFalse(NoNullSpace.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(NullyWithText));
        IsFalse(IsNully(NoNullText));
        IsFalse(NullyWithText.IsNully());
        IsFalse(NoNullText.IsNully());
    }

    [TestMethod] 
    public void IsNully_Text_True()
    {
        IsTrue(IsNully(NullText));
        IsTrue(IsNully(NullyEmpty));
        IsTrue(IsNully(NullySpace));
        IsTrue(IsNully(NoNullEmpty));
        IsTrue(IsNully(NoNullSpace));
        IsTrue(NullText.IsNully());
        IsTrue(NullyEmpty.IsNully());
        IsTrue(NullySpace.IsNully());
        IsTrue(NoNullEmpty.IsNully());
        IsTrue(NoNullSpace.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Text_TrimSpace()
    {
        IsFalse(NullySpace.IsNully(trimSpace: false));
        IsFalse(NullySpace.IsNully(false));
        IsFalse(NoNullSpace.IsNully(trimSpace: false));
        IsFalse(NoNullSpace.IsNully(false));
        IsFalse(IsNully(NullySpace, trimSpace: false));
        IsFalse(IsNully(NullySpace, false));
        IsFalse(IsNully(NoNullSpace, trimSpace: false));
        IsFalse(IsNully(NoNullSpace, false));
    }
        
    [TestMethod]
    public void FilledIn_Text_TrimSpace()
    {
        IsTrue(Has(NullySpace, trimSpace: false));
        IsTrue(Has(NullySpace, false));
        IsTrue(Has(NoNullSpace, trimSpace: false));
        IsTrue(Has(NoNullSpace, false));
        IsTrue(NullySpace.FilledIn(trimSpace: false));
        IsTrue(NullySpace.FilledIn(false));
        IsTrue(NoNullSpace.FilledIn(trimSpace: false));
        IsTrue(NoNullSpace.FilledIn(false));
        IsTrue(FilledIn(NullySpace, trimSpace: false));
        IsTrue(FilledIn(NullySpace, false));
        IsTrue(FilledIn(NoNullSpace, trimSpace: false));
        IsTrue(FilledIn(NoNullSpace, false));
    }
    
}