
namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class StreamHelperTests
{
    [TestMethod]
    public void StreamToBytes_ReturnsSameBytes()
    {
        byte[] bytesBefore = [1, 2, 3, 4, 5];
        using var stream = new MemoryStream(bytesBefore);
        byte[] bytesAfter = StreamHelper.StreamToBytes(stream);
        CollectionAssert.AreEqual(bytesBefore, bytesAfter);
    }

    [TestMethod]
    public void BytesToStream_StreamToBytes_Roundtrip()
    {
        Encoding encoding = Encoding.UTF8;
        byte[] bytesBefore = encoding.GetBytes("Hello IO");
        using Stream stream = StreamHelper.BytesToStream(bytesBefore);
        byte[] bytesAfter = StreamHelper.StreamToBytes(stream);
        CollectionAssert.AreEqual(bytesBefore, bytesAfter);
    }

    [TestMethod]
    public void StringToBytes_BytesToString_Roundtrip()
    {
        const string textBefore = "Hello Åäö — тест";
        Encoding encoding = Encoding.UTF8;
        byte[] bytes = StreamHelper.StringToBytes(textBefore, encoding);
        string textAfter = StreamHelper.BytesToString(bytes, encoding);
        AreEqual(textBefore, textAfter);
    }

    [TestMethod]
    public void StringToStream_StreamToString_Roundtrip()
    {
        const string textBefore = "Line1\nLine2\n";
        Encoding encoding = Encoding.UTF8;
        using Stream stream = StreamHelper.StringToStream(textBefore, encoding);
        string textAfter = StreamHelper.StreamToString(stream, encoding);
        AreEqual(textBefore, textAfter);
    }

    [TestMethod]
    public void BytesToString_HandlesEmpty()
    {
        byte[] bytes = [];
        string result = StreamHelper.BytesToString(bytes, Encoding.UTF8);
        AreEqual(string.Empty, result);
    }
}
