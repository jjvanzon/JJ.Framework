namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class StreamHelperLegacyTests
{
    [TestMethod]
    public void StringToBytes_Includes_UTF8_BOM_WhenRequested()
    {
        const string text = "Hello";
        Encoding encoding = Encoding.UTF8;

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
        Encoding encoding = Encoding.UTF8;

        byte[] bytes = StreamHelperLegacy.StringToBytes(text, encoding, includeByteOrderMark: false);

        CollectionAssert.AreEqual(encoding.GetBytes(text), bytes);
    }

    [TestMethod]
    public void StringToBytes_EmptyString_WithBOM_ReturnsOnlyPreamble()
    {
        const string text = "";
        Encoding encoding = Encoding.UTF8;

        byte[] bytes = JJ.Framework.IO.Core.StreamHelperLegacy.StringToBytes(text, encoding, includeByteOrderMark: true);

        CollectionAssert.AreEqual(encoding.GetPreamble(), bytes);
    }

    [TestMethod]
    public void StringToStream_And_StreamToString_WithBOM_Roundtrip()
    {
        const string text = "Hello World";
        Encoding encoding = Encoding.UTF8;

        using Stream s = StreamHelperLegacy.StringToStream(text, encoding, includeByteOrderMark: true);

        // StreamHelper.StreamToString handles the BOM correctly when provided the same encoding.
        string result = StreamHelper.StreamToString(s, encoding);

        AreEqual(text, result);
    }

    [TestMethod]
    public void StringToBytes_NullEncoding_ThrowsNullException()
    {
        const string text = "x";

        Throws(() => StreamHelperLegacy.StringToBytes(text, null!, includeByteOrderMark: false));
    }

    [TestMethod]
    public void StringToStream_NullEncoding_ThrowsNullException()
    {
        const string text = "x";

        Throws(() => StreamHelperLegacy.StringToStream(text, null!, includeByteOrderMark: false));
    }
}
