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
        IsFalse(Has(_nullableSpace));
        IsFalse(Has(_nonNullEmpty));
        IsFalse(Has(_nonNullSpace));
        IsFalse(FilledIn(_nullText));
        IsFalse(FilledIn(_nullableEmpty));
        IsFalse(FilledIn(_nullableSpace));
        IsFalse(FilledIn(_nonNullEmpty));
        IsFalse(FilledIn(_nonNullSpace));
        IsFalse(_nullText.FilledIn());
        IsFalse(_nullableEmpty.FilledIn());
        IsFalse(_nullableSpace.FilledIn());
        IsFalse(_nonNullEmpty.FilledIn());
        IsFalse(_nonNullSpace.FilledIn());
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
        IsTrue(Has(_nullableSpace, false));
        IsTrue(Has(_nullableSpace, trimSpace: false));
        IsTrue(Has(_nonNullSpace, false));
        IsTrue(Has(_nonNullSpace, trimSpace: false));
        IsTrue(_nullableSpace.FilledIn(false));
        IsTrue(_nullableSpace.FilledIn(trimSpace: false));
        IsTrue(_nonNullSpace.FilledIn(false));
        IsTrue(_nonNullSpace.FilledIn(trimSpace: false));
        IsTrue(FilledIn(_nullableSpace, false));
        IsTrue(FilledIn(_nullableSpace, trimSpace: false));
        IsTrue(FilledIn(_nonNullSpace, false));
        IsTrue(FilledIn(_nonNullSpace, trimSpace: false));
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
