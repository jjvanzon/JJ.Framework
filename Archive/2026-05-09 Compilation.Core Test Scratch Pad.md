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

```cs
    // Exe: enum command overloads

    // TODO: enum and string variants should be tested the for each known command exactly the same way as the explicit methods.
    // Perhaps using a synonyms pattern (see e.g. the test ItemTypes_WithCollectionType in JJ.Framework.Reflection.Legacy.Tests)

    // Restore output says "up-to-date" when already restored; look for "restore" (case-insensitive substring).
    [TestMethod] public void Test_Exe_Enum()          
        => InTempDir(() => AssertOutputText(DotNet.Exe(restore                          ), expectedInOutput: "restore"));
    [TestMethod] public void Test_Exe_Enum_Args()    
        => InTempDir(() => AssertOutputText(DotNet.Exe(restore, "--no-cache"            ), expectedInOutput: "restore"));
    [TestMethod] public void Test_Exe_Enum_Opt()      
        =>                 AssertOutputText(DotNet.Exe(restore,               _optNoFile), expectedInOutput: "restore");
    [TestMethod] public void Test_Exe_Enum_Args_Opt() 
        =>                 AssertOutputText(DotNet.Exe(restore, "--no-cache", _optNoFile), expectedInOutput: "restore");
```


```cs
    //[NoTrim("Command",         typeof(DotNetInfoAccessor))]
    //[NoTrim("FormatArgs",  typeof(DotNetArgBuilderAccessor))]
    //[NoTrim("Enrich",      typeof(DotNetEnricherAccessor))]
    //[NoTrim("Log",         typeof(DotNetLoggerAccessor))]
```