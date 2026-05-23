namespace JJ.Framework.Compilation.Core.Tests;

using static DiagnosticsFormatterAccessor;

[TestClass]
public class DotNetOptionsDescriptorTests
{
    private const int _defaultTimeOutSec = 5 * 60;
    private static readonly string[] _textNullies = [ "", " ", default! ];

    [TestMethod]
    public void DotNetOptions_Descriptor_Default()
        => AreEqual("", Descriptor(new DotNetOptions()));

    [TestMethod]
    public void DotNetOptions_Descriptor_BuildConfOnly()
        => AreEqual("Release", Descriptor(new DotNetOptions { BuildConf = "Release" }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_Auto()
        => AreEqual("restore auto", Descriptor(new DotNetOptions { AutoRestore = true }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_Parallel()
        => AreEqual("restore parallel", Descriptor(new DotNetOptions { ParallelRestore = true }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Restore_AutoAndParallel()
        => AreEqual("restore auto parallel", Descriptor(new DotNetOptions { AutoRestore = true, ParallelRestore = true }));

    [TestMethod]
    public void DotNetOptions_Descriptor_TimeOut_Omitted_WhenDefaultOrZero()
    {
        AreEqual("", Descriptor(new DotNetOptions { TimeOutSec = _defaultTimeOutSec }));
        AreEqual("", Descriptor(new DotNetOptions { TimeOutSec = 0 }));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_TimeOut_Shown_WhenCustom()
    {
        AreEqual("(timeout 1s)", Descriptor(new DotNetOptions { TimeOutSec = 1 }));
        AreEqual("(timeout 600s)", Descriptor(new DotNetOptions { TimeOutSec = 600 }));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_Log_Omitted_WhenNullLog()
        => AreEqual("", Descriptor(new DotNetOptions { Log = DotNetOptions.NullLog }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Log_Shown_WhenCustomDelegate()
        => AreEqual("(logs)", Descriptor(new DotNetOptions { Log = x => WriteLine(x) }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Verbosity_AllValues()
    {
        AreEqual("", Descriptor(new DotNetOptions { Verbosity = Normal }));
        AreEqual("Quiet", Descriptor(new DotNetOptions { Verbosity = Quiet }));
        AreEqual("Minimal", Descriptor(new DotNetOptions { Verbosity = Minimal }));
        AreEqual("Detailed", Descriptor(new DotNetOptions { Verbosity = Detailed }));
        AreEqual("Diagnostic", Descriptor(new DotNetOptions { Verbosity = Diagnostic }));
    }

    [TestMethod]
    public void DotNetOptions_Descriptor_FileOptions_OnlyArgs()
        => AreEqual("--no-restore", Descriptor(new DotNetOptions { Args = "--no-restore" }));

    [TestMethod]
    public void DotNetOptions_Descriptor_FileOptions_OnlyFile()
        => AreEqual("MyProject.csproj", Descriptor(new DotNetOptions { File = "MyProject.csproj" }));

    [TestMethod]
    public void DotNetOptions_Descriptor_FileOptions_OnlyDir()
        => AreEqual("(C:/repo)", Descriptor(new DotNetOptions { Dir = "C:/repo" }));

    [TestMethod]
    public void DotNetOptions_Descriptor_FileOptions_All()
        => AreEqual("--no-restore MyProject.csproj (C:/repo)", Descriptor(
            new DotNetOptions
            {
                Args = "--no-restore",
                File = "MyProject.csproj",
                Dir = "C:/repo"
            }));

    [TestMethod]
    public void DotNetOptions_Descriptor_Nullies_IgnoredForFileParts()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("", Descriptor(new DotNetOptions { Args = nully, File = nully, Dir = nully }));
        }
    }

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
            Log = x => WriteLine(x),
            Args = "--no-restore",
            File = "MyProject.csproj",
            Dir = "C:/repo"
        };

        AreEqual(
            "Release restore auto parallel (timeout 123s) Detailed (logs) --no-restore MyProject.csproj (C:/repo)",
            Descriptor(opt));
    }
}
