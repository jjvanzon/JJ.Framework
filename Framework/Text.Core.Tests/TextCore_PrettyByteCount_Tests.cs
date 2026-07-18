#pragma warning disable IDE0002 // Remove static member qualifier

namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class TextCore_PrettyByteCount_Tests
{
    [TestMethod]
    public void Test_TextCore_PrettyByteCount_Static()
    {
        AreEqual("100 bytes",  StringHelperCore.PrettyByteCount(   100                         ));
        AreEqual("100 bytes",  StringHelperCore.PrettyByteCount(   100                         ));
        AreEqual("1000 bytes", StringHelperCore.PrettyByteCount(  1000                         ));
        AreEqual("5119 bytes", StringHelperCore.PrettyByteCount(     5 *               1024 - 1));
        AreEqual("5 kB",       StringHelperCore.PrettyByteCount(     5 *               1024 + 1));
        AreEqual("10 kB",      StringHelperCore.PrettyByteCount(    10 *               1024    ));
        AreEqual("100 kB",     StringHelperCore.PrettyByteCount(   100 *               1024    ));
        AreEqual("1000 kB",    StringHelperCore.PrettyByteCount(  1000 *               1024    ));
        AreEqual("5120 kB",    StringHelperCore.PrettyByteCount(     5 *        1024 * 1024 - 1));
        AreEqual("5 MB",       StringHelperCore.PrettyByteCount(     5 *        1024 * 1024 + 1));
        AreEqual("100 MB",     StringHelperCore.PrettyByteCount(   100 *        1024 * 1024    ));
        AreEqual("1000 MB",    StringHelperCore.PrettyByteCount(  1000 *        1024 * 1024    ));
        AreEqual("5120 MB",    StringHelperCore.PrettyByteCount(    5L * 1024 * 1024 * 1024 - 1));
        AreEqual("5 GB",       StringHelperCore.PrettyByteCount(    5L * 1024 * 1024 * 1024 + 1));
        AreEqual("10 GB",      StringHelperCore.PrettyByteCount(   10L * 1024 * 1024 * 1024    ));
        AreEqual("100 GB",     StringHelperCore.PrettyByteCount(  100L * 1024 * 1024 * 1024    ));
        AreEqual("1000 GB",    StringHelperCore.PrettyByteCount( 1000L * 1024 * 1024 * 1024    ));
        AreEqual("10000 GB",   StringHelperCore.PrettyByteCount(10000L * 1024 * 1024 * 1024    ));
    }
    
    [TestMethod]
    public void Test_TextCore_PrettyByteCount_ShortStatic()
    {
        AreEqual("100 bytes",                   PrettyByteCount(   100                         ));
        AreEqual("100 bytes",                   PrettyByteCount(   100                         ));
        AreEqual("1000 bytes",                  PrettyByteCount(  1000                         ));
        AreEqual("5119 bytes",                  PrettyByteCount(     5 *               1024 - 1));
        AreEqual("5 kB",                        PrettyByteCount(     5 *               1024 + 1));
        AreEqual("10 kB",                       PrettyByteCount(    10 *               1024    ));
        AreEqual("100 kB",                      PrettyByteCount(   100 *               1024    ));
        AreEqual("1000 kB",                     PrettyByteCount(  1000 *               1024    ));
        AreEqual("5120 kB",                     PrettyByteCount(     5 *        1024 * 1024 - 1));
        AreEqual("5 MB",                        PrettyByteCount(     5 *        1024 * 1024 + 1));
        AreEqual("100 MB",                      PrettyByteCount(   100 *        1024 * 1024    ));
        AreEqual("1000 MB",                     PrettyByteCount(  1000 *        1024 * 1024    ));
        AreEqual("5120 MB",                     PrettyByteCount(    5L * 1024 * 1024 * 1024 - 1));
        AreEqual("5 GB",                        PrettyByteCount(    5L * 1024 * 1024 * 1024 + 1));
        AreEqual("10 GB",                       PrettyByteCount(   10L * 1024 * 1024 * 1024    ));
        AreEqual("100 GB",                      PrettyByteCount(  100L * 1024 * 1024 * 1024    ));
        AreEqual("1000 GB",                     PrettyByteCount( 1000L * 1024 * 1024 * 1024    ));
        AreEqual("10000 GB",                    PrettyByteCount(10000L * 1024 * 1024 * 1024    ));
    }
    
    [TestMethod]
    public void Test_TextCore_PrettyByteCount_Extension()
    {
        AreEqual("100 bytes",                                      100                          .PrettyByteCount());
        AreEqual("100 bytes",                                      100                          .PrettyByteCount());
        AreEqual("1000 bytes",                                    1000                          .PrettyByteCount());
        AreEqual("5119 bytes",                                 (     5 *               1024 - 1).PrettyByteCount());
        AreEqual("5 kB",                                       (     5 *               1024 + 1).PrettyByteCount());
        AreEqual("10 kB",                                      (    10 *               1024    ).PrettyByteCount());
        AreEqual("100 kB",                                     (   100 *               1024    ).PrettyByteCount());
        AreEqual("1000 kB",                                    (  1000 *               1024    ).PrettyByteCount());
        AreEqual("5120 kB",                                    (     5 *        1024 * 1024 - 1).PrettyByteCount());
        AreEqual("5 MB",                                       (     5 *        1024 * 1024 + 1).PrettyByteCount());
        AreEqual("100 MB",                                     (   100 *        1024 * 1024    ).PrettyByteCount());
        AreEqual("1000 MB",                                    (  1000 *        1024 * 1024    ).PrettyByteCount());
        AreEqual("5120 MB",                                    (    5L * 1024 * 1024 * 1024 - 1).PrettyByteCount());
        AreEqual("5 GB",                                       (    5L * 1024 * 1024 * 1024 + 1).PrettyByteCount());
        AreEqual("10 GB",                                      (   10L * 1024 * 1024 * 1024    ).PrettyByteCount());
        AreEqual("100 GB",                                     (  100L * 1024 * 1024 * 1024    ).PrettyByteCount());
        AreEqual("1000 GB",                                    ( 1000L * 1024 * 1024 * 1024    ).PrettyByteCount());
        AreEqual("10000 GB",                                   (10000L * 1024 * 1024 * 1024    ).PrettyByteCount());
    }

    [TestMethod]
    public void Test_TextCore_PrettyByteCount_FromByteArray()
    {
        var bytes = new byte[51 * 1024];
        AreEqual("51 kB", StringHelperCore.PrettyByteCount(bytes));
        AreEqual("51 kB", PrettyByteCount(bytes));
        AreEqual("51 kB", bytes.PrettyByteCount());
    }
    
    [TestMethod]
    public void Test_TextCore_PrettyByteCount_NullByteArray()
    {
        // Arbitrary. Might have expected "", but ok.
        byte[]? @null = null;
        AreEqual("0 bytes",  StringHelperCore.PrettyByteCount(null)); 
        AreEqual("0 bytes",  PrettyByteCount(null)); 
        AreEqual("0 bytes",  @null.PrettyByteCount()); 
    }

    [TestMethod]
    public void Test_TextCore_PrettyByteCount_EdgeCases()
    {
        AreEqual("0 bytes",  PrettyByteCount(0));
        AreEqual("1 bytes",  PrettyByteCount(1));
        AreEqual("-1 bytes", PrettyByteCount(-1));
        AreEqual("-10 GB",   PrettyByteCount(-10L * 1024 * 1024 * 1024));
    }
}