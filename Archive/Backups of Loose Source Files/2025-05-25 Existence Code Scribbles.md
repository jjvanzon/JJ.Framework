### Static Qualifiers in Tests

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
````