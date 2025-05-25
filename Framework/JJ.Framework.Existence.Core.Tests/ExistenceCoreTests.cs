namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class ExistenceCoreTests
{
    // Should check:
    // - [x] int
    // - [x] int?
    // - [x] string
    // - [x] string?
    // - [ ] Enum
    // - [ ] Enum?
    // - [ ] double
    // - [ ] bool
    // - [ ] CultureInfo
    // - [ ] CultureInfo?
    // - [ ] Coalescing from collection to collection
    // - [ ] Collection types
    // - [ ] Trim tolerance
    // - [ ] Coalesce arities
    // - [x] Static variant
    // - [x] Extension variant
    
    private string? _nullText         = null;
    private string? _nullableEmpty    = "";
    private string? _nullableSpace    = " ";
    private string? _nullableWithText = "Hi";
    private string  _nonNullEmpty     = "";
    private string  _nonNullSpace     = " ";
    private string  _nonNullText      = "Hello";

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(Has(_nullText));
        IsFalse(Has(_nullableEmpty));
        IsFalse(FilledIn(_nullText));
        IsFalse(FilledIn(_nullableEmpty));
        IsFalse(_nullText.FilledIn());
        IsFalse(_nullableEmpty.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue(Has(_nullableWithText));
        IsTrue(Has(_nonNullText));
        IsTrue(FilledIn(_nullableWithText));
        IsTrue(FilledIn(_nonNullText));
        IsTrue(_nullableWithText.FilledIn());
        IsTrue(_nonNullText.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_TrimSpace()
    {
        // TODO: I expected trimSpace to be active by default.
        
        IsTrue(Has(_nullableSpace));
        IsFalse(Has(_nullableSpace, true));
        IsFalse(Has(_nullableSpace, trimSpace: true));
        IsTrue(Has(_nonNullSpace));
        IsFalse(Has(_nonNullSpace, true));
        IsFalse(Has(_nonNullSpace, trimSpace: true));
        IsTrue(_nullableSpace.FilledIn());
        IsFalse(_nullableSpace.FilledIn(true));
        IsFalse(_nullableSpace.FilledIn(trimSpace: true));
        IsTrue(_nonNullSpace.FilledIn());
        IsFalse(_nonNullSpace.FilledIn(true));
        IsFalse(_nonNullSpace.FilledIn(trimSpace: true));
        IsTrue(FilledIn(_nullableSpace));
        IsFalse(FilledIn(_nullableSpace, true));
        IsFalse(FilledIn(_nullableSpace, trimSpace: true));
        IsTrue(FilledIn(_nonNullSpace));
        IsFalse(FilledIn(_nonNullSpace, true));
        IsFalse(FilledIn(_nonNullSpace, trimSpace: true));
    }
    
    int? nullInt    = null;
    int? nullable0  = 0;
    int? nullable1  = 1;
    int  nonNull0   = 0;
    int  nonNull1   = 1;
    
    [TestMethod]
    public void FilledIn_Int_False()
    {
        IsFalse(Has(nullInt));
        IsFalse(Has(nullable0));
        IsFalse(Has(nonNull0));
        IsFalse(nullInt.FilledIn());
        IsFalse(nullable0.FilledIn());
        IsFalse(nonNull0.FilledIn());
        IsFalse(FilledIn(nullInt));
        IsFalse(FilledIn(nonNull0));
    }
    
    [TestMethod]
    public void FilledIn_Int_True()
    {
        IsTrue(Has(nullable1));
        IsTrue(Has(nonNull1));
        IsTrue(nullable1.FilledIn());
        IsTrue(nonNull1.FilledIn());
        IsTrue(FilledIn(nullable1));
        IsTrue(FilledIn(nonNull1));
    }
    
}
