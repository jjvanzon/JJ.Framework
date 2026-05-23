using static JJ.Framework.Compilation.Core.Tests.Accessors.DotNetOptionsAccessor;

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetOptionsDescriptorTests
{
    private static readonly string[] _textNullies = [ "", " ", default! ];
    private static readonly Action<string>[] _logNullies = [ null!, NullLog ]; //, _ => { }]; // CustomNot empty lamda recognized as nully.

    // All Options Filled
    
    [TestMethod]
    public void DotNetOptions_Descriptor_FullCombination()
    {
        var opt = new DotNetOptions
        {
            BuildConf = "Release",
            AutoRestore = true,
            ParallelRestore = true,
            TimeOutSec = 123,
            Verbosity = Detailed,
            Log = WriteLine, // ncrunch: no coverage
            Args = "--no-logo",
            File = "MyProject.csproj",
            Dir = @"C:\repo"
        };

        AreEqual(
            @"""Release"" | Restore: Auto Parallel | Log Detailed | Timeout: 123s | MyProject.csproj --no-logo | Dir: ""C:\repo""",
            Descriptor(opt));
    }

    // Empty/Default

    [TestMethod]
    public void DotNetOptions_Descriptor_EmptyOrDefault()
    {
        AreEqual("", Descriptor(default(DotNetOptions)));
        AreEqual("", Descriptor(new DotNetOptions()));
        AreEqual("", Descriptor(DefaultOptions));
    }

    // BuildConf Option

    [TestMethod]
    public void DotNetOptions_Descriptor_BuildConf()
    {
        AreEqual(@"""Release""", Descriptor(new DotNetOptions { BuildConf = "Release" }));
        AreEqual(@"""Debug""",   Descriptor(new DotNetOptions { BuildConf = "Debug"   }));
        AreEqual(@"""La lala""", Descriptor(new DotNetOptions { BuildConf = "La lala" }));
        AreEqual("",             Descriptor(new DotNetOptions { BuildConf = ""        }));
    }

    // Restore

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_Auto()
        => AreEqual("Restore: Auto", Descriptor(new DotNetOptions { AutoRestore = true }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_Parallel()
        => AreEqual("Restore: Parallel", Descriptor(new DotNetOptions { ParallelRestore = true }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_AutoAndParallel()
        => AreEqual("Restore: Auto Parallel", Descriptor(new DotNetOptions { AutoRestore = true, ParallelRestore = true }));

    // Time-Out

    [TestMethod]
    public void DotNetOptions_Descriptor_TimeOut_Omitted_WhenDefaultOrZero()
    {
        AreEqual("", Descriptor(new DotNetOptions { TimeOutSec = DEFAULT_TIME_OUT_SEC }));
        AreEqual("", Descriptor(new DotNetOptions { TimeOutSec = 0 }));
        AreEqual("", Descriptor(new DotNetOptions { TimeOutSec = default }));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_TimeOut_Shown_WhenCustom()
    {
        AreEqual("Timeout: 1s",   Descriptor(new DotNetOptions { TimeOutSec = 1   }));
        AreEqual("Timeout: 600s", Descriptor(new DotNetOptions { TimeOutSec = 600 }));
    }

    // Log

    [TestMethod]
    public void DotNetOptions_Descriptor_Log_Nully()
    {
        foreach (Action<string> logNully in _logNullies)
        {
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully                        }));
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully, Verbosity = 0         }));
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully, Verbosity = default   }));
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully, Verbosity = Normal    }));
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully, Verbosity = Quiet     }));
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully, Verbosity = Minimal   }));
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully, Verbosity = Detailed  }));
            AreEqual("", Descriptor(new DotNetOptions { Log = logNully, Verbosity = Diagnostic}));
        }

        // Verbosity quiet means no logging at all.
        AreEqual("", Descriptor(new DotNetOptions { Log = null!,     Verbosity = Quiet }));
        AreEqual("", Descriptor(new DotNetOptions { Log = NullLog,   Verbosity = Quiet }));
        AreEqual("", Descriptor(new DotNetOptions { Log = _ => { },  Verbosity = Quiet }));
        AreEqual("", Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Quiet }));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_Log_Included()
        => AreEqual("Log Normal", Descriptor(new DotNetOptions { Log = WriteLine }));

    // Verbosity

    [TestMethod]
    public void DotNetOptions_Descriptor_Verbosity_AllValues()
    {

        AreEqual("Log Normal",     Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = 0         }));
        AreEqual("Log Normal",     Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = default   }));
        AreEqual("Log Normal",     Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Normal    }));
        AreEqual("",               Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Quiet     }));
        AreEqual("Log Minimal",    Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Minimal   }));
        AreEqual("Log Detailed",   Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Detailed  }));
        AreEqual("Log Diagnostic", Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Diagnostic}));
    }

    // File Options

    [TestMethod]
    public void DotNetOptions_Descriptor_OnlyArgs()
        => AreEqual("--no-logo", Descriptor(new DotNetOptions { Args = "--no-logo" }));

    [TestMethod]
    public void DotNetOptions_Descriptor_OnlyFile()
        => AreEqual("MyProject.csproj", Descriptor(new DotNetOptions { File = "MyProject.csproj" }));

    [TestMethod]
    public void DotNetOptions_Descriptor_OnlyDir()
        => AreEqual(@"Dir: ""C:\repo""", Descriptor(new DotNetOptions { Dir = @"C:\repo" }));

    [TestMethod]
    public void DotNetOptions_Descriptor_AllFileOptions()
    {
        var opt = new DotNetOptions
        {
            Args = "--no-logo",
            File = "MyProject.csproj",
            Dir = @"D:\JJ\Dev\Products\Code"
        };

        AreEqual(@"MyProject.csproj --no-logo | Dir: ""D:\JJ\Dev\Products\Code""", Descriptor(opt));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_AllFileOptions_LongFilePath()
    {
        var opt = new DotNetOptions
        {
            Args = "--no-logo",
            File = @"D:\JJ\Dev\Products\Code\MyProject.csproj",
            Dir = @"D:\JJ\Dev\Products\Code"
        };

        IsTrue(opt.File.Length > 20);

        AreEqual(@"--no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj | Dir: ""D:\JJ\Dev\Products\Code""", Descriptor(opt));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_EmptyFileOptions()
    {
        foreach (var nully1 in _textNullies)
        foreach (var nully2 in _textNullies)
        foreach (var nully3 in _textNullies)
        {
            AreEqual("", Descriptor(new DotNetOptions { Args = nully1, File = nully2, Dir = nully3 }));
        }
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_Combos()
    {
        AreEqual(
            """
            "Release" | Timeout: 123s
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", TimeOutSec = 123 }));

        AreEqual(
            """
            "Release" | Restore: Auto
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", AutoRestore = true }));

        AreEqual(
            """
            "Release" | Log Detailed
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", Log = WriteLine, Verbosity = Detailed }));

        AreEqual(
            """
            Restore: Parallel | Timeout: 123s
            """,
            Descriptor(new DotNetOptions { ParallelRestore = true, TimeOutSec = 123 }));

        AreEqual(
            """
            Restore: Auto | Log Detailed
            """,
            Descriptor(new DotNetOptions { AutoRestore = true, Log = WriteLine, Verbosity = Detailed }));

        AreEqual(
            """
            Log Detailed | Timeout: 123s
            """,
            Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Detailed, TimeOutSec = 123 }));

        AreEqual("""
            "Release" | Restore: Parallel | Timeout: 123s
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", ParallelRestore = true, TimeOutSec = 123 }));

        AreEqual("""
            "Release" | Timeout: 123s
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", Log = WriteLine, Verbosity = Quiet, TimeOutSec = 123 }));

        AreEqual("""
            "Release" | Restore: Auto | Timeout: 123s
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", AutoRestore = true, Log = WriteLine, Verbosity = Quiet, TimeOutSec = 123 }));

        AreEqual(
            """
            "Release" | Restore: Parallel | Log Detailed | Timeout: 123s
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", ParallelRestore = true, Log = WriteLine, Verbosity = Detailed, TimeOutSec = 123 }));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_FileOptionCombos()
    {
        const string shortFile = "MyProject.csproj";
        const string longFile = @"D:\JJ\Dev\Products\Code\MyProject.csproj";

        AreEqual(
            """
            --no-logo | Dir: "C:\repo"
            """,
            Descriptor(new DotNetOptions { Args = "--no-logo", Dir = @"C:\repo" }));

        AreEqual(
            """
            MyProject.csproj | Dir: "C:\repo"
            """,
            Descriptor(new DotNetOptions { File = shortFile, Dir = @"C:\repo" }));

        AreEqual(
            """
            MyProject.csproj --no-logo
            """,
            Descriptor(new DotNetOptions { Args = "--no-logo", File = shortFile }));

        AreEqual(
            """
            --no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj
            """,
            Descriptor(new DotNetOptions { Args = "--no-logo", File = longFile }));

        AreEqual(
            """
            D:\JJ\Dev\Products\Code\MyProject.csproj | Dir: "C:\repo"
            """,
            Descriptor(new DotNetOptions { File = longFile, Dir = @"C:\repo" }));

        AreEqual(
            """
            --no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj | Dir: "C:\repo"
            """,
            Descriptor(new DotNetOptions { Args = "--no-logo", File = longFile, Dir = @"C:\repo" }));

        AreEqual(
            """
            "Release" | --no-logo | Dir: "C:\repo"
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", Args = "--no-logo", Dir = @"C:\repo" }));

        AreEqual(
            """
            "Release" | MyProject.csproj | Dir: "C:\repo"
            """,
            Descriptor(new DotNetOptions { BuildConf = "Release", File = shortFile, Dir = @"C:\repo" }));
    }
}
