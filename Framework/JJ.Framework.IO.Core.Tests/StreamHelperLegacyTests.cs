namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class StreamHelperLegacyTests
{
    private static readonly Encoding encoding = Encoding.UTF8;

    [TestMethod]
    public void StringToBytes_Includes_UTF8_BOM_WhenRequested()
    {
        const string text = "Hello";

        byte[] bytes = StreamHelperLegacy.StringToBytes(text, encoding, includeByteOrderMark: true);

        byte[] preamble = encoding.GetPreamble();
        CollectionAssert.AreEqual(preamble, bytes.Take(preamble.Length).ToArray());

        byte[] content = bytes.Skip(preamble.Length).ToArray();
        CollectionAssert.AreEqual(encoding.GetBytes(text), content);
    }

    [TestMethod]
    public void StringToBytes_DoesNotInclude_BOM_WhenNotRequested()
    {
        const string text = "Hello";
        byte[] bytes = StreamHelperLegacy.StringToBytes(text, encoding, includeByteOrderMark: false);

        CollectionAssert.AreEqual(encoding.GetBytes(text), bytes);
    }

    [TestMethod]
    public void StringToBytes_EmptyString_WithBOM_ReturnsOnlyPreamble()
    {
        const string text = "";
        byte[] bytes = StreamHelperLegacy.StringToBytes(text, encoding, includeByteOrderMark: true);

        CollectionAssert.AreEqual(encoding.GetPreamble(), bytes);
    }

    [TestMethod]
    public void StringToStream_And_StreamToString_WithBOM_Roundtrip()
    {
        const string text = "Hello World";
        using Stream stream = StreamHelperLegacy.StringToStream(text, encoding, includeByteOrderMark: true);

        // Use plain .NET StreamReader to read the stream so the test only verifies
        // StreamHelperLegacy.StringToStream behavior and does not depend on other helpers.
        using var reader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);
        string result = reader.ReadToEnd();

        AreEqual(text, result);
    }

    [TestMethod]
    public void StringToBytes_NullEncoding_ThrowsNullException()
    {
        const string text = "x";
        Throws(() => StreamHelperLegacy.StringToBytes(text, null!, includeByteOrderMark: false), "encoding", "null");
    }

    [TestMethod]
    public void StringToStream_NullEncoding_ThrowsNullException()
    {
        const string text = "x";
        Throws(() => StreamHelperLegacy.StringToStream(text, null!, includeByteOrderMark: false), "encoding", "null");
    }
}
