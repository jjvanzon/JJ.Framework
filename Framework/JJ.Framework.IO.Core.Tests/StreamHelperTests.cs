using static JJ.Framework.IO.Legacy.StreamHelper;

namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class StreamHelperTests
{
    static readonly Encoding encoding = Encoding.UTF8;

    [TestMethod]
    public void StreamToBytes_ReturnsSameBytes()
    {
        byte[] bytesBefore = [1, 2, 3, 4, 5];
        using var stream = new MemoryStream(bytesBefore);
        byte[] bytesAfter = StreamToBytes(stream);
        CollectionAssert.AreEqual(bytesBefore, bytesAfter);
    }

    [TestMethod]
    public void BytesToStream_StreamToBytes_Roundtrip()
    {
        byte[] bytesBefore = encoding.GetBytes("Hello IO");
        using Stream stream = BytesToStream(bytesBefore);
        byte[] bytesAfter = StreamToBytes(stream);
        CollectionAssert.AreEqual(bytesBefore, bytesAfter);
    }

    [TestMethod]
    public void StringToBytes_BytesToString_Roundtrip()
    {
        const string textBefore = "Hello Åäö — тест";
        byte[] bytes = StringToBytes(textBefore, encoding);
        string textAfter = BytesToString(bytes, encoding);
        AreEqual(textBefore, textAfter);
    }

    [TestMethod]
    public void StringToStream_StreamToString_Roundtrip()
    {
        const string textBefore = "Line1\nLine2\n";
        using Stream stream = StringToStream(textBefore, encoding);
        string textAfter = StreamToString(stream, encoding);
        AreEqual(textBefore, textAfter);
    }

    [TestMethod]
    public void BytesToString_HandlesEmpty()
    {
        byte[] bytes = [];
        string result = BytesToString(bytes, encoding);
        AreEqual(string.Empty, result);
    }
}
