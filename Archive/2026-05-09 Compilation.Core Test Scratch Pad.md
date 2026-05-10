Compilation.Core Test Scratch Pad
=================================

```cs
    [TestMethod]
    public void Log_WithNullLog_DoesNotThrow()
    {
        var info = new DotNetInfo(build);
        var opt = new DotNetOptions { Verbosity = Normal, Log = null };

        Log(info, "build", opt);
    }
```


```cs
private static void TestEnrichEnum(DotNetCommandEnum input, (string command, bool re) expected)

(string expectedCommand, bool expectedIsRebuild) = expected;
```