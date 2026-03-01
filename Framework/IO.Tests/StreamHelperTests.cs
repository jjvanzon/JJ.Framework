using static JJ.Framework.IO.StreamHelper;

namespace JJ.Framework.IO.Tests;

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
    public void StreamToBytes_IgnoresCurrentPosition()
    {
        byte[] bytesBefore = [0, 1, 2, 3, 4];
        using var stream = new MemoryStream(bytesBefore);
        stream.Position = 2; // move to third byte

        byte[] bytesAfter = StreamToBytes(stream);

        CollectionAssert.AreEqual(new byte[] { 0, 1, 2, 3, 4 }, bytesAfter);
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

    [TestMethod]
    public void StreamToString_HandlesBOMAndReturnsText()
    {
        byte[] preamble = encoding.GetPreamble();
        byte[] bytesBefore = preamble.Concat(encoding.GetBytes("Hello BOM")).ToArray();

        using var streamBefore = new MemoryStream(bytesBefore);
        string textAfter = StreamToString(streamBefore, encoding);

        AreEqual("Hello BOM", textAfter);
    }
}
