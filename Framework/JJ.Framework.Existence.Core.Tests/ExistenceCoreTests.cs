namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class ExistenceCoreTests
{
    // Should check:
    // int
    // int?
    // string
    // string?
    // Enum
    // Enum?
    // double
    // bool
    // CultureInfo
    // CultureInfo?
    // Coalescing from collection to collection
    // Collection types
    // Trim tolerance
    // Coalesce arities
    // Static variant
    // Extension variant
    
    private string? _nullText      = null;
    private string? _nullableEmpty = "";
    private string? _nullableSpace = " ";
    private string? _nullableWithText  = "Hi";
    private string  _nonNullEmpty  = "";
    private string  _nonNullSpace  = " ";
    private string  _nonNullText   = "Hello";

    [TestMethod]
    public void FilledIn_Text_False()
    { 
        IsFalse(                  Has     (_nullText        ));
        IsFalse(                  Has     (_nullableEmpty   ));
        IsFalse(                  FilledIn(_nullText        ));
        IsFalse(                  FilledIn(_nullableEmpty   ));
        IsFalse(_nullText        .FilledIn(                 ));
        IsFalse(_nullableEmpty   .FilledIn(                 ));
    }

    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue (                  Has     (_nullableWithText));
        IsTrue (                  Has     (_nonNullText     ));
        IsTrue (_nullableWithText.FilledIn(                 ));
        IsTrue (_nonNullText     .FilledIn(                 ));
        IsTrue (                  FilledIn(_nullableWithText));
        IsTrue (                  FilledIn(_nonNullText     ));
    }
    
    [TestMethod]
    public void FilledIn_TrimSpace()
    {
        IsTrue (                  Has     (_nullableSpace                 ));
        IsFalse(                  Has     (_nullableSpace, true           ));
        IsFalse(                  Has     (_nullableSpace, trimSpace: true));
        IsTrue (_nullableSpace   .FilledIn()                               );
        IsFalse(_nullableSpace   .FilledIn(true)                           );
        IsFalse(_nullableSpace   .FilledIn(trimSpace: true)                );
        IsTrue (                  FilledIn(_nullableSpace                 ));
        IsFalse(                  FilledIn(_nullableSpace, true           ));
        IsFalse(                  FilledIn(_nullableSpace, trimSpace: true));
    }
}
