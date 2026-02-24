using static JJ.Framework.IO.Core.StreamHelperLegacy;

namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class StreamHelperLegacyTests
{
    private static readonly Encoding encoding = Encoding.UTF8;

    [TestMethod]
    public void StringToBytes_Includes_UTF8_BOM_WhenRequested()
    {
        byte[] bytes = StringToBytes("Hello", encoding, includeByteOrderMark: true);

        byte[] preamble = encoding.GetPreamble();
        CollectionAssert.AreEqual(preamble, bytes.Take(preamble.Length).ToArray());

        byte[] content = bytes.Skip(preamble.Length).ToArray();
        CollectionAssert.AreEqual(encoding.GetBytes("Hello"), content);
    }

    [TestMethod]
    public void StringToBytes_DoesNotInclude_BOM_WhenNotRequested()
    {
        byte[] bytes = StringToBytes("Hello", encoding, includeByteOrderMark: false);
        CollectionAssert.AreEqual(encoding.GetBytes("Hello"), bytes);
    }

    [TestMethod]
    public void StringToBytes_EmptyString_WithBOM_ReturnsOnlyPreamble()
    {
        byte[] bytes = StringToBytes("", encoding, includeByteOrderMark: true);
        CollectionAssert.AreEqual(encoding.GetPreamble(), bytes);
    }

    [TestMethod]
    public void StringToStream_And_StreamToString_WithBOM_Roundtrip()
    {
        using Stream stream = StringToStream("Hello World", encoding, includeByteOrderMark: true);

        using var reader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks: true);
        string result = reader.ReadToEnd();

        AreEqual("Hello World", result);
    }

    [TestMethod]
    public void StringToBytes_NullEncoding_ThrowsNullException()
    {
        Throws(() => StringToBytes("x", null!, includeByteOrderMark: false), "encoding", "null");
    }

    [TestMethod]
    public void StringToStream_NullEncoding_ThrowsNullException()
    {
        Throws(() => StringToStream("x", null!, includeByteOrderMark: false), "encoding", "null");
    }
}
