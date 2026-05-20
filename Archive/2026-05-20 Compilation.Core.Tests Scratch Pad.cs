    // Exe: string command overloads
    // --version requires no project and always emits stdout with the SDK version number.

    // TODO: Test empty command, but -- parameter in arg.

    private static void TestExeStringOutput(Func<string> call) => AssertOutputText(call(), "Output =");

    [TestMethod]
    public void Test_Exe_String()
    {
        string result = DotNet.Exe("--version");
        TestExeStringOutput(() => result);
        IsTrue(result.Count(x => x == '.') >= 2, $"Expected a version number (major.minor.patch) in: {result}");
    }

    [TestMethod]
    public void Test_Exe_String_Args()
    {
        string result = DotNet.Exe("--list-sdks", "");
        AssertOutputText(result, "Output =");
        IsTrue(result.Contains('['), $"Expected SDK list entries (containing '[') in: {result}");
    }

    [TestMethod]
    public void Test_Exe_String_Opt()
    {
        string msg = "";
        var opt = new DotNetOptions { Log = x => msg = x, Verbosity = Normal };
        string result = DotNet.Exe("--version", opt);
        AssertOutputText(result, "Output =");
        // Normal verbosity logs the invocation line.
        IsTrue(msg.Contains("dotnet --version"), $"Expected log to mention 'dotnet --version', got: {msg}");
    }

    [TestMethod] public void Test_Exe_String_Args_Opt() => TestExeStringOutput(() => DotNet.Exe("--list-sdks", "", new DotNetOptions { Log = _ => { } }));


        IsTrue(outputText.Contains("Output ="), $"Expected 'Output =' in: {outputText}");

    //private static readonly object _tempDirLock = new(); // Fixes synchronization?
