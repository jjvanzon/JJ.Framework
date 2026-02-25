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
        using var streamBefore = new MemoryStream(bytesBefore);
        byte[] bytesAfter = StreamToBytes(streamBefore);
        CollectionAssert.AreEqual(bytesBefore, bytesAfter);
    }

    [TestMethod]
    public void BytesToStream_CreatesStreamWithSameBytes()
    {
        byte[] bytesBefore = encoding.GetBytes("Hello IO");
        using Stream streamAfter = BytesToStream(bytesBefore);
        using MemoryStream copiedStreamAfter = new();
        streamAfter.CopyTo(copiedStreamAfter);
        CollectionAssert.AreEqual(bytesBefore, copiedStreamAfter.ToArray());
    }

    [TestMethod]
    public void StringToBytes_ProducesExpectedBytes()
    {
        const string textBefore = "Hello Åäö — тест";
        byte[] bytesAfter = StringToBytes(textBefore, encoding);
        string textAfter = encoding.GetString(bytesAfter);
        AreEqual(textBefore, textAfter);
    }

    [TestMethod]
    public void StringToStream_ProducesReadableStream()
    {
        const string textBefore = "Line1\nLine2\n";
        using Stream streamAfter = StringToStream(textBefore, encoding);
        using var readerAfter = new StreamReader(streamAfter, encoding);
        string textAfter = readerAfter.ReadToEnd();
        AreEqual(textBefore, textAfter);
    }

    [TestMethod]
    public void BytesToString_HandlesEmpty()
    {
        byte[] bytesBefore = [];
        string textAfter = BytesToString(bytesBefore, encoding);
        AreEqual("", textAfter);
    }
}
