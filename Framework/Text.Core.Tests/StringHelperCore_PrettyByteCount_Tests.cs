namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_PrettyByteCount_Tests
{
    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount()
    {
        AreEqual("100 bytes",  PrettyByteCount(   100                         ));
        AreEqual("1000 bytes", PrettyByteCount(  1000                         ));
        AreEqual("5119 bytes", PrettyByteCount(     5 *               1024 - 1));
        AreEqual("5 kB",       PrettyByteCount(     5 *               1024 + 1));
        AreEqual("10 kB",      PrettyByteCount(    10 *               1024    ));
        AreEqual("100 kB",     PrettyByteCount(   100 *               1024    ));
        AreEqual("1000 kB",    PrettyByteCount(  1000 *               1024    ));
        AreEqual("5120 kB",    PrettyByteCount(     5 *        1024 * 1024 - 1));
        AreEqual("5 MB",       PrettyByteCount(     5 *        1024 * 1024 + 1));
        AreEqual("100 MB",     PrettyByteCount(   100 *        1024 * 1024    ));
        AreEqual("1000 MB",    PrettyByteCount(  1000 *        1024 * 1024    ));
        AreEqual("5120 MB",    PrettyByteCount(    5L * 1024 * 1024 * 1024 - 1));
        AreEqual("5 GB",       PrettyByteCount(    5L * 1024 * 1024 * 1024 + 1));
        AreEqual("10 GB",      PrettyByteCount(   10L * 1024 * 1024 * 1024    ));
        AreEqual("100 GB",     PrettyByteCount(  100L * 1024 * 1024 * 1024    ));
        AreEqual("1000 GB",    PrettyByteCount( 1000L * 1024 * 1024 * 1024    ));
        AreEqual("10000 GB",   PrettyByteCount(10000L * 1024 * 1024 * 1024    ));
    }
    
    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount_Nullable()
    {
        AreEqual("0 bytes", PrettyByteCount(null)); // Arbitrary. Might have expected "", but ok.
        AreEqual("1000 bytes", PrettyByteCount(  1000                         ));
        AreEqual("10 kB",      PrettyByteCount(    10 *               1024    ));
        AreEqual("100 MB",     PrettyByteCount(   100 *        1024 * 1024    ));
        AreEqual("12345 GB",   PrettyByteCount(12345L * 1024 * 1024 * 1024    ));
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount_EdgeCases()
    {
        AreEqual("0 bytes",  PrettyByteCount(0));
        AreEqual("1 bytes",  PrettyByteCount(1));
        AreEqual("-1 bytes", PrettyByteCount(-1));
        AreEqual("-10 GB",   PrettyByteCount(-10L * 1024 * 1024 * 1024));
    }
}