using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JJ.Framework.IO.Legacy.Tests;

[TestClass]
public class CsvReaderTests
{
    [TestMethod]
    public void CsvReader_ReadsSimpleLine()
    {
        const string csv = "a,b,c\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("a", reader[0]);
        AreEqual("b", reader[1]);
        AreEqual("c", reader[2]);

        IsFalse(reader.Read());
    }

    [TestMethod]
    public void CsvReader_ParsesComplexMultipleRows()
    {
        const string csv =
            """
            Name,Age,Notes
            "Smith, John",30,Likes pizza and coding
            Doe,25,
            ,,
            """;

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));
        using var reader = new CsvReader(stream);

        // Header
        IsTrue(reader.Read());
        AreEqual("Name", reader[0]);
        AreEqual("Age", reader[1]);
        AreEqual("Notes", reader[2]);

        // First data row with quoted name
        IsTrue(reader.Read());
        AreEqual("Smith, John", reader[0]);
        AreEqual("30", reader[1]);
        AreEqual("Likes pizza and coding", reader[2]);

        // Second data row
        IsTrue(reader.Read());
        AreEqual("Doe", reader[0]);
        AreEqual("25", reader[1]);
        AreEqual("", reader[2]);

        // Third data row with empty fields
        IsTrue(reader.Read());
        AreEqual("", reader[0]);
        AreEqual("", reader[1]);
        AreEqual("", reader[2]);

        IsFalse(reader.Read());
    }


    [TestMethod]
    public void CsvReader_ReadsIntoListOfDtos()
    {
        const string csv =
        """
        Name,Age,Notes
        "Smith, John",30,"Likes ""pizza"" and coding"
        Doe,25,""
        Alice,29,"Uses,commas"

        """;

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));
        using var reader = new CsvReader(stream);

        // Skip header
        IsTrue(reader.Read());

        var list = new List<PersonDto>();

        while (reader.Read())
        {
            list.Add(new PersonDto
            {
                Name = reader[0],
                Age = GetAge(reader[1]),
                Notes = reader[2]
            });
        }

        AreEqual(3, list.Count);

        AreEqual("Smith, John", list[0].Name);
        AreEqual(30, list[0].Age);
        AreEqual("Likes \"pizza\" and coding", list[0].Notes);

        AreEqual("Doe", list[1].Name);
        AreEqual(25, list[1].Age);
        AreEqual("", list[1].Notes);

        AreEqual("Alice", list[2].Name);
        AreEqual(29, list[2].Age);
        AreEqual("Uses,commas", list[2].Notes);
    }

    private int GetAge(string text)
    {
        if (!int.TryParse(text, out int age))
        // ncrunch: no coverage start
        { 
            throw new Exception($"age '{text}' is not a number.");
        }
        // ncrunch: no coverage end
        return age;
    }

    [TestMethod]
    public void CsvReader_ParsesQuotedFieldsWithCommas()
    {
        const string csv = "\"a,1\",b,\"c\"\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("a,1", reader[0]);
        AreEqual("b", reader[1]);
        AreEqual("c", reader[2]);
    }

    [TestMethod]
    public void CsvReader_HandlesEscapedQuotesInsideQuotedField()
    {
        // Double quote inside quoted field is represented by two quotes.
        const string csv = 
        """"
        "He said ""hi""",Other

        """";
        
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("He said \"hi\"", reader[0]);
        AreEqual("Other", reader[1]);
    }

    [TestMethod]
    public void CsvReader_EmptyFields_AreEmptyStrings()
    {
        const string csv = ",,\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("", reader[0]);
        AreEqual("", reader[1]);
        AreEqual("", reader[2]);
    }

    [TestMethod]
    public void CsvReader_MultipleLines_ReadSequentially()
    {
        const string csv = "a,b\n1,2\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("a", reader[0]);
        AreEqual("b", reader[1]);

        IsTrue(reader.Read());
        AreEqual("1", reader[0]);
        AreEqual("2", reader[1]);

        IsFalse(reader.Read());
    }

    [TestMethod]
    public void CsvReader_Ctor_NullStream_ThrowsNullException()
    {
        Throws(() => new CsvReader(null!), "stream", "null");
    }

    [TestMethod]
    public void CsvReader_Finalizer_DisposesStream()
    {
        // Arrange
        var stream = new DisposableMemoryStream();

        // Act: create a reader and drop the reference so the finalizer can run.
        void CreateReader()
        {
            var reader = new CsvReader(stream);
            // Intentionally do not dispose reader.
        }

        CreateReader();

        // Force GC and finalizers.
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Assert: finalizer should have disposed the underlying stream.
        IsTrue(stream.WasDisposed);
    }

    private class DisposableMemoryStream : MemoryStream
    {
        public bool WasDisposed { get; private set; }

        protected override void Dispose(bool disposing)
        {
            WasDisposed = true;
            base.Dispose(disposing);
        }
    }

    private class PersonDto
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
