// ReSharper disable ConvertToConstant.Local
// ReSharper disable InlineTemporaryVariable
namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetOptionsFormatterAccessor;
using static DotNetOptionsFormatterExtensionsAccessor;

[TestClass]
public class DotNetOptionsFormatterTests
{
    private static readonly string[] _textNullies = [ "", " ", default! ];
    private static readonly DotNetOptions[] _optNullies = [ DefaultOptions, default ];
    private const string DEFAULT_DESCRIPTOR = "default";

    // Entry Points

    // TODO: Test all variants with same parameterization in one test method.

    [TestMethod]
    public void DotNetOptions_Stringify_Default()
    {
        var expected = "DotNetOptions default";
        foreach (var nully in _optNullies)
        {
            AreEqual(expected, Stringify(nully));
            AreEqual(expected, nully.Stringify());
        }
    }

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_Default()
    {
        var expected = "{DotNetOptions default}";
        foreach (var nully in _optNullies)
        {
            AreEqual(expected, DebuggerDisplay(nully));
            AreEqual(expected, nully.DebuggerDisplay());
        }
    }

    [TestMethod]
    public void DotNetOptions_Stringify_UsesDescriptor()
    {
        var opt = new DotNetOptions
        {
            BuildConf = "Release",
            File = @"C:\Code\MyProject.csproj",
            Args = "--no-logo",
            Dir = @"C:\repo"
        };

        const string expected = 
            """
            DotNetOptions "Release" | --no-logo | C:\Code\MyProject.csproj | Dir = C:\repo
            """;

        AreEqual(expected, Stringify(opt));
        AreEqual(expected, opt.Stringify());
        AreEqual(expected, opt.ToString());
    }

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_UsesSingleQuotesAndForwardSlashes()
    {
        var opt = new DotNetOptions
        {
            BuildConf = "Release",
            File = @"C:\Code\MyProject.csproj",
            Args = "--no-logo",
            Dir = @"C:\Code"
        };

        var accessor = new DotNetOptionsAccessor(opt);

        const string expected =
            """
            {DotNetOptions 'Release' | --no-logo | C:/Code/MyProject.csproj | Dir = C:/Code}
            """;

        AreEqual(expected, DebuggerDisplay(opt));
        AreEqual(expected, opt.DebuggerDisplay());
        AreEqual(expected, accessor.DebuggerDisplay);
    }

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

        var expected = @"""Release"" | Restore: Auto Parallel | Log Detailed | Timeout: 123s | MyProject.csproj --no-logo | Dir = C:\repo";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    // Empty/Default

    [TestMethod]
    public void DotNetOptions_Descriptor_EmptyOrDefault()
    {
        DotNetOptions[] nullyOptions = [ default, new(), DefaultOptions ];
       
        foreach (var nullyOption in nullyOptions)
        {
            AreEqual(DEFAULT_DESCRIPTOR, Descriptor(nullyOption));
            AreEqual(DEFAULT_DESCRIPTOR, nullyOption.Descriptor());
        }
    }

    // BuildConf Option

    [TestMethod]
    public void DotNetOptions_Descriptor_BuildConf()
    {
        {
            var opt = new DotNetOptions { BuildConf = "Release" };
            var expected = @"""Release""";
            AreEqual(expected, Descriptor(opt)); 
            AreEqual(expected, opt.Descriptor());
        }
        {
            var opt = new DotNetOptions { BuildConf = "Debug" };
            var expected = @"""Debug""";
            AreEqual(expected, Descriptor(opt)); 
            AreEqual(expected, opt.Descriptor());
        }
        {
            var opt = new DotNetOptions { BuildConf = "La lala" };
            var expected = @"""La lala""";
            AreEqual(expected, Descriptor(opt)); 
            AreEqual(expected, opt.Descriptor());
        }
        {
            var opt = new DotNetOptions { BuildConf = "" };
            var expected = DEFAULT_DESCRIPTOR;
            AreEqual(expected, Descriptor(opt)); 
            AreEqual(expected, opt.Descriptor());
        }
    }

    // Restore

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_Auto()
    {
        var opt = new DotNetOptions { AutoRestore = true };
        var expected = "Restore: Auto";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_Parallel()
    {
        var opt = new DotNetOptions { ParallelRestore = true };
        var expected = "Restore: Parallel";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_AutoAndParallel()
    {
        var opt = new DotNetOptions { AutoRestore = true, ParallelRestore = true };
        var expected = "Restore: Auto Parallel";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    // Time-Out


    [TestMethod]
    public void DotNetOptions_Descriptor_TimeOut_Omitted_WhenDefaultOrZero()
    {
        DotNetOptions[] nullyOptions =
        [
            new() { TimeOutSec = DEFAULT_TIME_OUT_SEC },
            new() { TimeOutSec = 0 },
            new() { TimeOutSec = default }];

        foreach (DotNetOptions nullyOption in nullyOptions)
        {
            AreEqual(DEFAULT_DESCRIPTOR, Descriptor(nullyOption));
            AreEqual(DEFAULT_DESCRIPTOR, nullyOption.Descriptor());
        }
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_TimeOut_Shown_WhenCustom()
    {
        {
            var opt = new DotNetOptions { TimeOutSec = 1 };
            var expected = "Timeout: 1s";
            AreEqual(expected, Descriptor(opt));
            AreEqual(expected, opt.Descriptor());
        }
        {
            var opt = new DotNetOptions { TimeOutSec = 600 };
            var expected = "Timeout: 600s";
            AreEqual(expected, Descriptor(opt));
            AreEqual(expected, opt.Descriptor());
        }
    }

    // Log

    [TestMethod]
    public void DotNetOptions_Descriptor_Log_Nully()
    {
        Action<string>[] logNullies = [ null!, NullLog ]; //, _ => { }]; // CustomNot empty lamda recognized as nully.
        DotNetVerbosity[] allVerbosities = [ 0, default, Normal, Quiet, Minimal, Detailed, Diagnostic ];

        foreach (Action<string> logNully in logNullies)
        {
            {
                var opt = new DotNetOptions { Log = logNully };
                var expected = DEFAULT_DESCRIPTOR;
                AreEqual(expected, Descriptor(opt));
                AreEqual(expected, opt.Descriptor());
            }

            foreach (DotNetVerbosity anyVerbosity in allVerbosities)
            {
                // TODO: Change main code implementation:
                //  Verbosity variance is still relevant to show for diagnostics, even when Log is nully.
                //  It also affects the dotnet run, not just the Log delegate.
                var opt = new DotNetOptions { Log = logNully, Verbosity = anyVerbosity };
                var expected = DEFAULT_DESCRIPTOR;
                AreEqual(expected, Descriptor(opt));
                AreEqual(expected, opt.Descriptor());
            }
        }
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_LogCallback_VerbosityNormalOrDefault()
    {
        Action<string>[] logNonNullies = [ WriteLine, _ => { } ];
        DotNetVerbosity[] nullyVerbosities = [ 0, default, Normal ];

        foreach (Action<string> logNonNully in logNonNullies)
        {
            {
                var opt = new DotNetOptions { Log = logNonNully };
                var expected = "Log";
                AreEqual(expected, Descriptor(opt));
                AreEqual(expected, opt.Descriptor());
            }

            foreach (DotNetVerbosity nullyVerbosity in nullyVerbosities)
            {
                var opt = new DotNetOptions { Log = logNonNully, Verbosity = nullyVerbosity };
                var expected = "Log";
                AreEqual(expected, Descriptor(opt));
                AreEqual(expected, opt.Descriptor());
            }
        }
    }

    // Verbosity

    [TestMethod]
    public void DotNetOptions_Descriptor_Log_VariousVerbosities()
    {
        {
            var opt = new DotNetOptions { Log = WriteLine, Verbosity = Quiet };
            var expected = "Log Quiet";
            AreEqual(expected, Descriptor(opt));
            AreEqual(expected, opt.Descriptor());
        }
        {
            var opt = new DotNetOptions { Log = WriteLine, Verbosity = Minimal };
            var expected = "Log Minimal";
            AreEqual(expected, Descriptor(opt));
            AreEqual(expected, opt.Descriptor());
        }
        {
            var opt = new DotNetOptions { Log = WriteLine, Verbosity = Detailed };
            var expected = "Log Detailed";
            AreEqual(expected, Descriptor(opt));
            AreEqual(expected, opt.Descriptor());
        }
        {
            var opt = new DotNetOptions { Log = WriteLine, Verbosity = Diagnostic };
            var expected = "Log Diagnostic";
            AreEqual(expected, Descriptor(opt));
            AreEqual(expected, opt.Descriptor());
        }
    }

    // File Options

    [TestMethod]
    public void DotNetOptions_Descriptor_OnlyArgs()
    {
        var opt = new DotNetOptions { Args = "--no-logo" };
        var expected = "--no-logo";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_OnlyFile()
    {
        var opt = new DotNetOptions { File = "MyProject.csproj" };
        var expected = "MyProject.csproj";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_OnlyDir()
    {
        var opt = new DotNetOptions { Dir = @"C:\repo" };
        var expected = @"Dir = C:\repo";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_AllFileOptions()
    {
        var opt = new DotNetOptions
        {
            Args = "--no-logo",
            File = "MyProject.csproj",
            Dir = @"D:\JJ\Dev\Products\Code"
        };

        var expected = @"MyProject.csproj --no-logo | Dir = D:\JJ\Dev\Products\Code";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
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

        var expected = @"--no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj | Dir = D:\JJ\Dev\Products\Code";
        AreEqual(expected, Descriptor(opt));
        AreEqual(expected, opt.Descriptor());
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_EmptyFileOptions()
    {
        foreach (var nully1 in _textNullies)
        foreach (var nully2 in _textNullies)
        foreach (var nully3 in _textNullies)
        {
            var opt = new DotNetOptions { Args = nully1, File = nully2, Dir = nully3 };
            AreEqual(DEFAULT_DESCRIPTOR, Descriptor(opt));
            AreEqual(DEFAULT_DESCRIPTOR, opt.Descriptor());
        }
    }

    [TestMethod]
    public void DotNetOptions_Stringify_ToString_NoPathTruncation()
    {
        var opt = new DotNetOptions
        {
            Args = "--no-logo",
            File = @"D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj",
            Dir = @"D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0"
        };

        const string expected = 
            """
            DotNetOptions --no-logo | D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj | Dir = D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0
            """;

        AreEqual(expected, Stringify(opt));
        AreEqual(expected, opt.Stringify());
        AreEqual(expected, opt.ToString());
    }

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_PathTruncation()
    {
        var opt = new DotNetOptions
        {
            Args = "--no-logo",
            File = @"D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj",
            Dir = @"D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0"
        };

        const string expected = 
            """
            {DotNetOptions --no-logo | ... /Apps/Billing/Billing.Service.Api.csproj | Dir = ... /Billing/ServiceHost/bin/Release/net10.0}
            """;

        var accessor = new DotNetOptionsAccessor(opt);

        AreEqual(expected, DebuggerDisplay(opt));
        AreEqual(expected, opt.DebuggerDisplay());
        AreEqual(expected, accessor.DebuggerDisplay);
    }

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_DirTruncated_FileNot()
    {
        var opt = new DotNetOptions
        {
            Args = "--no-logo",
            File = "MyProject.csproj",
            Dir = @"D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0"
        };

        const string expected =
            "{DotNetOptions MyProject.csproj --no-logo | Dir = ... /Billing/ServiceHost/bin/Release/net10.0}";

        var accessor = new DotNetOptionsAccessor(opt);

        AreEqual(expected, DebuggerDisplay(opt));
        AreEqual(expected, opt.DebuggerDisplay());
        AreEqual(expected, accessor.DebuggerDisplay);
    }

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_FileTruncated_DirNot()
    {
        var opt = new DotNetOptions
        {
            Args = "--no-logo",
            File = @"D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj",
            Dir = @"D:\Repos\JJ.Framework"
        };

        const string expected =
            "{DotNetOptions --no-logo | ... /Apps/Billing/Billing.Service.Api.csproj | Dir = D:/Repos/JJ.Framework}";

        var accessor = new DotNetOptionsAccessor(opt);

        AreEqual(expected, DebuggerDisplay(opt));
        AreEqual(expected, opt.DebuggerDisplay());
        AreEqual(expected, accessor.DebuggerDisplay);
    }

    // Combos

    // TODO: Here the distinction between static/extension invocation still needs to be programmed out.
    // TODO: Perhaps it is time for a helper method that checks both syntaxes given a DotNetOptions and expected text.

    [TestMethod]
    public void DotNetOptions_Descriptor_Combos_WithoutFileOptions()
    {
        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", TimeOutSec = 123 },
            """
            "Release" | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", AutoRestore = true },
            """
            "Release" | Restore: Auto
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", Log = WriteLine, Verbosity = Detailed },
            """
            "Release" | Log Detailed
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { ParallelRestore = true, TimeOutSec = 123 },
            """
            Restore: Parallel | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { AutoRestore = true, Log = WriteLine, Verbosity = Detailed },
            """
            Restore: Auto | Log Detailed
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { Log = WriteLine, Verbosity = Detailed, TimeOutSec = 123 },
            """
            Log Detailed | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", ParallelRestore = true, TimeOutSec = 123 },
            """
            "Release" | Restore: Parallel | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", Log = WriteLine, Verbosity = Quiet, TimeOutSec = 123 },
            """
            "Release" | Log Quiet | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", AutoRestore = true, Log = WriteLine, Verbosity = Normal, TimeOutSec = 123 },
            """
            "Release" | Restore: Auto | Log | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", ParallelRestore = true, Log = WriteLine, Verbosity = Detailed, TimeOutSec = 123 },
            """
            "Release" | Restore: Parallel | Log Detailed | Timeout: 123s
            """);
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_FileOptionCombos()
    {
        const string shortFile = "MyProject.csproj";
        const string longFile = @"D:\JJ\Dev\Products\Code\MyProject.csproj";

        AssertDiagnosticTexts(
            new DotNetOptions { Args = "--no-logo", Dir = @"C:\repo" },
            """
            --no-logo | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { File = shortFile, Dir = @"C:\repo" },
            """
            MyProject.csproj | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { Args = "--no-logo", File = shortFile },
            """
            MyProject.csproj --no-logo
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { Args = "--no-logo", File = longFile },
            """
            --no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { File = longFile, Dir = @"C:\repo" },
            """
            D:\JJ\Dev\Products\Code\MyProject.csproj | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { Args = "--no-logo", File = longFile, Dir = @"C:\repo" },
            """
            --no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", Args = "--no-logo", Dir = @"C:\repo" },
            """
            "Release" | --no-logo | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new DotNetOptions { BuildConf = "Release", File = shortFile, Dir = @"C:\repo" },
            """
            "Release" | MyProject.csproj | Dir = C:\repo
            """);
    }

    private void AssertDiagnosticTexts(DotNetOptions opt, string expectedText)
    {
        // TODO: Accound for path truncation styles.

        // Descriptor
        {
            AreEqual(expectedText, Descriptor(opt));
            AreEqual(expectedText, opt.Descriptor());
        }
        // String
        {
            string expected = nameof(DotNetOptions) + " " + expectedText;
            AreEqual(expected, opt.ToString());
            AreEqual(expected, Stringify(opt));
            AreEqual(expected, opt.Stringify());
        }
        // DebuggerDisplay
        {
            var accessor = new DotNetOptionsAccessor(opt);
            
            string expected = "{" + nameof(DotNetOptions) + " " + expectedText.Replace('"', '\'').Replace('\\', '/') + "}";
            AreEqual(expected, DebuggerDisplay(opt));
            AreEqual(expected, opt.DebuggerDisplay());
            AreEqual(expected, accessor.DebuggerDisplay);
        }
    }
}
