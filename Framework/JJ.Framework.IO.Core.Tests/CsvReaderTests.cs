namespace JJ.Framework.IO.Core.Tests;

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
        const string csv = """"
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
}
