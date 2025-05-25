### FilledIn Tests

```cs
        IsFalse(FilledInHelper      .Has     (_nullString         ));
        IsFalse(FilledInHelper      .Has     (_nullableEmptyString));
        IsFalse(FilledInHelper      .FilledIn(_nullString         ));
        IsFalse(FilledInHelper      .FilledIn(_nullableEmptyString));

        IsTrue (FilledInHelper      .Has     (_nullableFilledText));
        IsTrue (FilledInHelper      .Has     (_nonNullFilledText ));
        IsTrue (FilledInHelper      .FilledIn(_nullableFilledText));
        IsTrue (FilledInHelper      .FilledIn(_nonNullFilledText ));

        IsTrue (FilledInHelper      .Has     (_nullableWhiteSpace                 ));
        IsFalse(FilledInHelper      .Has     (_nullableWhiteSpace, true           ));
        IsFalse(FilledInHelper      .Has     (_nullableWhiteSpace, trimSpace: true));
        IsTrue (FilledInHelper      .FilledIn(_nullableWhiteSpace                 ));
        IsFalse(FilledInHelper      .FilledIn(_nullableWhiteSpace, true           ));
        IsFalse(FilledInHelper      .FilledIn(_nullableWhiteSpace, trimSpace: true));

        // TODO: I expected trimSpace to be active by default.
        // TODO: Only use single-flag enum: `Has(x, trimSpace)` ?
        // Oh, that only works if trimSpace isn't the default.
        // spaceMatters? `Has(someText, spaceMatters)`

    [TestMethod]
    public void FilledIn_TrimSpace_DefaultFalse()
    {

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

    [TestMethod]
    public void FilledIn_TrimSpace_DefaultTrue()
    {
        IsFalse(Has(_nullableSpace));
        IsFalse(Has(_nullableSpace, true));
        IsFalse(Has(_nullableSpace, trimSpace: true));
        IsFalse(Has(_nonNullSpace));
        IsFalse(Has(_nonNullSpace, true));
        IsFalse(Has(_nonNullSpace, trimSpace: true));
        IsFalse(_nullableSpace.FilledIn());
        IsFalse(_nullableSpace.FilledIn(true));
        IsFalse(_nullableSpace.FilledIn(trimSpace: true));
        IsFalse(_nonNullSpace.FilledIn());
        IsFalse(_nonNullSpace.FilledIn(true));
        IsFalse(_nonNullSpace.FilledIn(trimSpace: true));
        IsFalse(FilledIn(_nullableSpace));
        IsFalse(FilledIn(_nullableSpace, true));
        IsFalse(FilledIn(_nullableSpace, trimSpace: true));
        IsFalse(FilledIn(_nonNullSpace));
        IsFalse(FilledIn(_nonNullSpace, true));
        IsFalse(FilledIn(_nonNullSpace, trimSpace: true));
    }

````