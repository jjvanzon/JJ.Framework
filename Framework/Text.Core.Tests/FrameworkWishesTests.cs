namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class FrameworkWishesTests
{
    [TestMethod]
    public void Test_StringWishes_PrettyByteCount()
    {
        AreEqual("100 bytes",  PrettyByteCount(100));
        AreEqual("1000 bytes", PrettyByteCount(1000));
        AreEqual("5119 bytes", PrettyByteCount(5 * 1024 - 1));
        AreEqual("5 kB",       PrettyByteCount(5 * 1024 + 1));
        AreEqual("10 kB",      PrettyByteCount(10 * 1024));
        AreEqual("100 kB",     PrettyByteCount(100 * 1024));
        AreEqual("1000 kB",    PrettyByteCount(1000 * 1024));
        AreEqual("5120 kB",    PrettyByteCount(5 * 1024 * 1024 - 1));
        AreEqual("5 MB",       PrettyByteCount(5 * 1024 * 1024 + 1));
        AreEqual("100 MB",     PrettyByteCount(100 * 1024 * 1024));
        AreEqual("1000 MB",    PrettyByteCount(1000 * 1024 * 1024));
        AreEqual("5120 MB",    PrettyByteCount((long)5 * 1024 * 1024 * 1024 - 1));
        AreEqual("5 GB",       PrettyByteCount((long)5 * 1024 * 1024 * 1024 + 1));
        AreEqual("10 GB",      PrettyByteCount((long)10 * 1024 * 1024 * 1024));
        AreEqual("100 GB",     PrettyByteCount((long)100 * 1024 * 1024 * 1024));
        AreEqual("1000 GB",    PrettyByteCount((long)1000 * 1024 * 1024 * 1024));
        AreEqual("10000 GB",   PrettyByteCount((long)10000 * 1024 * 1024 * 1024));
    } 
}