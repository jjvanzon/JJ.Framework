// ReSharper disable ConvertToConstant.Local
// ReSharper disable InlineTemporaryVariable

namespace JJ.Framework.Compilation.Core.Tests.FormatterTests;

using static DotNetOptionsFormatterAccessor;
using static DotNetOptionsFormatterExtensionsAccessor;

[TestClass]
public class DotNetOptionsFormatterTests
{
    private const string DEFAULT_DESCRIPTOR = "default";

    // Entry Points

    [TestMethod]
    public void DotNetOptionsFormatter_UsesDescriptor()
    {
        AssertDiagnosticTexts(
            new()
            {
                BuildConf = "Release",
                File = @"C:\Code\MyProject.csproj",
                Args = "--no-logo",
                Dir = @"C:\repo"
            },
            """
            "Release" | --no-logo | C:\Code\MyProject.csproj | Dir = C:\repo
            """);
    }

    // All Options Filled
    
    [TestMethod]
    public void DotNetOptionsFormatter_FullCombination()
    {
        AssertDiagnosticTexts(
            new()
            {
                BuildConf = "Release",
                AutoRestore = true,
                ParallelRestore = true,
                TimeOutSec = 123,
                Verbosity = Detailed,
                LogAction = WriteLine, // ncrunch: no coverage
                Args = "--no-logo",
                File = "MyProject.csproj",
                Dir = @"C:\repo"
            },
            """
            "Release" | Restore: Auto Parallel | Log Detailed | Timeout: 123s | MyProject.csproj --no-logo | Dir = C:\repo
            """);
    }

    // Empty/Default

    [TestMethod]
    public void DotNetOptionsFormatter_EmptyOrDefault()
    {
        DotNetOptions[] nullyOptions = [ default, new(), DefaultOptions ];

        foreach (var nullyOption in nullyOptions)
        {
            AssertDiagnosticTexts(nullyOption, DEFAULT_DESCRIPTOR);
        }
    }

    // BuildConf Option

    [TestMethod]
    public void DotNetOptionsFormatter_BuildConf()
    {
        AssertDiagnosticTexts(new() { BuildConf = "Release" }, '"' + "Release" + '"');
        AssertDiagnosticTexts(new() { BuildConf = "Debug"   }, '"' + "Debug"   + '"');
        AssertDiagnosticTexts(new() { BuildConf = "La lala" }, '"' + "La lala" + '"');
        AssertDiagnosticTexts(new() { BuildConf = ""        }, DEFAULT_DESCRIPTOR);
    }

    // Restore

    [TestMethod]
    public void DotNetOptionsFormatter_Restore_Auto()
    {
        AssertDiagnosticTexts(new() { AutoRestore = true }, "Restore: Auto");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_Restore_Parallel()
    {
        AssertDiagnosticTexts(new() { ParallelRestore = true }, "Restore: Parallel");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_Restore_AutoAndParallel()
    {
        AssertDiagnosticTexts(new() { AutoRestore = true, ParallelRestore = true }, "Restore: Auto Parallel");
    }

    // Time-Out

    [TestMethod]
    public void DotNetOptionsFormatter_TimeOut_Omitted_WhenDefaultOrZero()
    {
        DotNetOptions[] nullyOptions =
        [
            new() { TimeOutSec = DefaultOptions.TimeOutSec },
            new() { TimeOutSec = 0 },
            new() { TimeOutSec = default }];

        foreach (DotNetOptions nullyOption in nullyOptions)
        {
            AssertDiagnosticTexts(nullyOption, DEFAULT_DESCRIPTOR);
        }
    }

    [TestMethod]
    public void DotNetOptionsFormatter_TimeOut_Shown_WhenCustom()
    {
        AssertDiagnosticTexts(new() { TimeOutSec = 1 }, "Timeout: 1s");
        AssertDiagnosticTexts(new() { TimeOutSec = 600 }, "Timeout: 600s");
    }

    // Log

    [TestMethod]
    public void DotNetOptionsFormatter_Log_Nully()
    {
        Action<string>[] filledLogActions = [ null!, NullAction ];
        DotNetVerbosity[] allVerbosities = [ 0, default, Normal, Quiet, Minimal, Detailed, Diagnostic ];

        foreach (Action<string> filledLogAction in filledLogActions)
        {
            AssertDiagnosticTexts(new() { LogAction = filledLogAction }, DEFAULT_DESCRIPTOR);

            foreach (DotNetVerbosity anyVerbosity in allVerbosities)
            {
                // TODO: Change main code implementation:
                //  Verbosity variance is still relevant to show for diagnostics, even when Log is nully.
                //  It also affects the dotnet run, not just the Log delegate.
                AssertDiagnosticTexts(new() { LogAction = filledLogAction, Verbosity = anyVerbosity }, DEFAULT_DESCRIPTOR);
            }
        }
    }

    [TestMethod]
    public void DotNetOptionsFormatter_LogCallback_VerbosityNormal()
    {
        Action<string>[] filledLogActions = [ WriteLine, _ => { } ];
        DotNetVerbosity[] normalVerbosities = [ Normal, DefaultOptions.Verbosity ];

        foreach (Action<string> filledLogAction in filledLogActions)
        {
            AssertDiagnosticTexts(new() { LogAction = filledLogAction }, "Log");

            foreach (DotNetVerbosity normalVerbosity in normalVerbosities)
            {
                AssertDiagnosticTexts(new() { LogAction = filledLogAction, Verbosity = normalVerbosity }, "Log");
            }
        }
    }

    [TestMethod]
    public void DotNetOptionsFormatter_LogCallback_VerbosityZeroOrUndefined()
    {
        Action<string>[] filledLogActions = [ WriteLine, _ => { } ];
        DotNetVerbosity[] nullyVerbosities = [ 0, default, Undefined ];

        foreach (Action<string> filledLogAction in filledLogActions)
        {
            foreach (DotNetVerbosity nullyVerbosity in nullyVerbosities)
            {
                AssertDiagnosticTexts(new() { LogAction = filledLogAction, Verbosity = nullyVerbosity }, "Log Undefined");
            }
        }
    }

    // Verbosity

    [TestMethod]
    public void DotNetOptionsFormatter_Log_VariousVerbosities()
    {
        AssertDiagnosticTexts(new() { LogAction = WriteLine, Verbosity = Quiet      }, "Log Quiet"     );
        AssertDiagnosticTexts(new() { LogAction = WriteLine, Verbosity = Minimal    }, "Log Minimal"   );
        AssertDiagnosticTexts(new() { LogAction = WriteLine, Verbosity = Detailed   }, "Log Detailed"  );
        AssertDiagnosticTexts(new() { LogAction = WriteLine, Verbosity = Diagnostic }, "Log Diagnostic");
    }

    // File Options

    [TestMethod]
    public void DotNetOptionsFormatter_OnlyArgs()
    {
        AssertDiagnosticTexts(new() { Args = "--no-logo" }, "--no-logo");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_OnlyFile()
    {
        AssertDiagnosticTexts(new() { File = "MyProject.csproj" }, "MyProject.csproj");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_OnlyDir()
    {
        AssertDiagnosticTexts(new() { Dir = @"C:\repo" }, @"Dir = C:\repo");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_AllFileOptions()
    {
        AssertDiagnosticTexts(
            new()
            {
                Args = "--no-logo",
                File = "MyProject.csproj",
                Dir = @"D:\JJ\Dev\Products\Code"
            },
            @"MyProject.csproj --no-logo | Dir = D:\JJ\Dev\Products\Code");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_AllFileOptions_LongFilePath()
    {
        DotNetOptions opt = new()
        {
            Args = "--no-logo",
            File = @"D:\JJ\Dev\Products\Code\MyProject.csproj",
            Dir = @"D:\JJ\Dev\Products\Code"
        };

        IsTrue(opt.File.Length > 20);

        AssertDiagnosticTexts(opt, @"--no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj | Dir = D:\JJ\Dev\Products\Code");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_EmptyFileOptions()
    {
        string[] textNullies = [ "", " ", default! ];

        foreach (var nully1 in textNullies)
        foreach (var nully2 in textNullies)
        foreach (var nully3 in textNullies)
        {
            AssertDiagnosticTexts(new() { Args = nully1, File = nully2, Dir = nully3 }, DEFAULT_DESCRIPTOR);
        }
    }

    [TestMethod]
    public void DotNetOptionsFormatter_PathsTruncated()
    {
        AssertDiagnosticTexts(
            new()
            {
                Args = "--no-logo",
                File = @"D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj",
                Dir = @"D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0"
            },
            """
            --no-logo | D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj | Dir = D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0
            """,
            "--no-logo | ... /Apps/Billing/Billing.Service.Api.csproj | Dir = ... /Billing/ServiceHost/bin/Release/net10.0");

    }

    [TestMethod]
    public void DotNetOptionsFormatter_DirTruncated_FileNot()
    {
        AssertDiagnosticTexts(
            new()
            {
                Args = "--no-logo",
                File = "MyProject.csproj",
                Dir = @"D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0"
            },
            """
            MyProject.csproj --no-logo | Dir = D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0
            """,
            "MyProject.csproj --no-logo | Dir = ... /Billing/ServiceHost/bin/Release/net10.0");
    }

    [TestMethod]
    public void DotNetOptionsFormatter_FileTruncated_DirNot()
    {
        AssertDiagnosticTexts(
            new()
            {
                Args = "--no-logo",
                File = @"D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj",
                Dir = @"D:\Repos\JJ.Framework"
            },
            """
            --no-logo | D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj | Dir = D:\Repos\JJ.Framework
            """,
            "--no-logo | ... /Apps/Billing/Billing.Service.Api.csproj | Dir = D:/Repos/JJ.Framework");
    }

    // Combos

    [TestMethod]
    public void DotNetOptionsFormatter_Combos_WithoutFileOptions()
    {
        AssertDiagnosticTexts(
            new() { BuildConf = "Release", TimeOutSec = 123 },
            """
            "Release" | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", AutoRestore = true },
            """
            "Release" | Restore: Auto
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", LogAction = WriteLine, Verbosity = Detailed },
            """
            "Release" | Log Detailed
            """);

        AssertDiagnosticTexts(
            new() { ParallelRestore = true, TimeOutSec = 123 },
            """
            Restore: Parallel | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new() { AutoRestore = true, LogAction = WriteLine, Verbosity = Detailed },
            """
            Restore: Auto | Log Detailed
            """);

        AssertDiagnosticTexts(
            new() { LogAction = WriteLine, Verbosity = Detailed, TimeOutSec = 123 },
            """
            Log Detailed | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", ParallelRestore = true, TimeOutSec = 123 },
            """
            "Release" | Restore: Parallel | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", LogAction = WriteLine, Verbosity = Quiet, TimeOutSec = 123 },
            """
            "Release" | Log Quiet | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", AutoRestore = true, LogAction = WriteLine, Verbosity = Normal, TimeOutSec = 123 },
            """
            "Release" | Restore: Auto | Log | Timeout: 123s
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", ParallelRestore = true, LogAction = WriteLine, Verbosity = Detailed, TimeOutSec = 123 },
            """
            "Release" | Restore: Parallel | Log Detailed | Timeout: 123s
            """);
    }

    [TestMethod]
    public void DotNetOptionsFormatter_FileOptionCombos()
    {
        const string shortFile = "MyProject.csproj";
        const string longFile = @"D:\JJ\Dev\Products\Code\MyProject.csproj";

        AssertDiagnosticTexts(
            new() { Args = "--no-logo", Dir = @"C:\repo" },
            """
            --no-logo | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new() { File = shortFile, Dir = @"C:\repo" },
            """
            MyProject.csproj | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new() { Args = "--no-logo", File = shortFile },
            """
            MyProject.csproj --no-logo
            """);

        AssertDiagnosticTexts(
            new() { Args = "--no-logo", File = longFile },
            """
            --no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj
            """);

        AssertDiagnosticTexts(
            new() { File = longFile, Dir = @"C:\repo" },
            """
            D:\JJ\Dev\Products\Code\MyProject.csproj | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new() { Args = "--no-logo", File = longFile, Dir = @"C:\repo" },
            """
            --no-logo | D:\JJ\Dev\Products\Code\MyProject.csproj | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", Args = "--no-logo", Dir = @"C:\repo" },
            """
            "Release" | --no-logo | Dir = C:\repo
            """);

        AssertDiagnosticTexts(
            new() { BuildConf = "Release", File = shortFile, Dir = @"C:\repo" },
            """
            "Release" | MyProject.csproj | Dir = C:\repo
            """);
    }

    private void AssertDiagnosticTexts(DotNetOptions opt, string expectedText, string? withTruncatedPaths = null)
    {
        withTruncatedPaths ??= expectedText;

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
            
            string expected = "{" + nameof(DotNetOptions) + " " + withTruncatedPaths.Replace('"', '\'').Replace('\\', '/') + "}";
            AreEqual(expected, DebuggerDisplay(opt));
            AreEqual(expected, opt.DebuggerDisplay());
            AreEqual(expected, accessor.DebuggerDisplay);
        }
    }
}
