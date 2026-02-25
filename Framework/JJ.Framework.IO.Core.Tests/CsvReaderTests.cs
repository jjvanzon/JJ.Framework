using System.IO;
using System.Text;
using static JJ.Framework.Testing.Core.AssertCore;

namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class CsvReaderTests
{
    [TestMethod]
    public void CsvReader_ReadsSimpleLine()
    {
        string csv = "a,b,c\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new JJ.Framework.IO.Legacy.CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("a", reader[0]);
        AreEqual("b", reader[1]);
        AreEqual("c", reader[2]);

        IsFalse(reader.Read());
    }

    [TestMethod]
    public void CsvReader_ParsesQuotedFieldsWithCommas()
    {
        string csv = "\"a,1\",b,\"c\"\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new JJ.Framework.IO.Legacy.CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("a,1", reader[0]);
        AreEqual("b", reader[1]);
        AreEqual("c", reader[2]);
    }

    [TestMethod]
    public void CsvReader_HandlesEscapedQuotesInsideQuotedField()
    {
        // Double quote inside quoted field is represented by two quotes.
        string csv = "\"He said \"\"hi\"\"\",Other\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new JJ.Framework.IO.Legacy.CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual("He said \"hi\"", reader[0]);
        AreEqual("Other", reader[1]);
    }

    [TestMethod]
    public void CsvReader_EmptyFields_AreEmptyStrings()
    {
        string csv = ",,\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new JJ.Framework.IO.Legacy.CsvReader(ms);

        IsTrue(reader.Read());
        AreEqual(string.Empty, reader[0]);
        AreEqual(string.Empty, reader[1]);
        AreEqual(string.Empty, reader[2]);
    }

    [TestMethod]
    public void CsvReader_MultipleLines_ReadSequentially()
    {
        string csv = "a,b\n1,2\n";
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        using var reader = new JJ.Framework.IO.Legacy.CsvReader(ms);

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
        Throws(() => new JJ.Framework.IO.Legacy.CsvReader(null!), "stream", "null");
    }
}
