using static JJ.Framework.Compilation.Core.DotNetOptions;

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetArgBuilderTests
{
    // dotnet build style

    [TestMethod]
    public void FormatArgs_Build_FullOptions()
    {
        var info    = new DotNetInfo(build)  { Command = "build", Args = "--nologo" };
        var options = new DotNetOptions { File = "MySolution.sln", BuildConf = "Release", Verbosity = Diagnostic, AutoRestore = false, Args = "-p:Foo=Bar" };

        AreEqual("build \"MySolution.sln\" -c Release --verbosity Diagnostic -p:Foo=Bar --nologo --no-restore", FormatArgs(info, options));
    }

    [TestMethod]
    public void FormatArgs_Build_NoFile()
    {
        var info = new DotNetInfo(build) { Command = "build" };

        AreEqual("build --no-restore", FormatArgs(info, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_Rebuild()
    {
        var info = new DotNetInfo(rebuild) { Command = "build", IsRebuild = true };

        AreEqual("build --no-incremental --no-restore", FormatArgs(info, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_AutoRestore()
    {
        var info    = new DotNetInfo(build) { Command = "build" };
        var options = new DotNetOptions { AutoRestore = true };

        AreEqual("build", FormatArgs(info, options));
    }

    // msbuild style

    [TestMethod]
    public void FormatArgs_MSRebuild_FullOptions()
    {
        var info    = new DotNetInfo(msrebuild) { Command = "msbuild", IsRebuild = true };
        var options = new DotNetOptions { BuildConf = "Debug", Verbosity = Minimal, AutoRestore = true };

        AreEqual("msbuild /p:Configuration=Debug /t:Rebuild -verbosity:Minimal -restore", FormatArgs(info, options));
    }

    [TestMethod]
    public void FormatArgs_MSBuild_NoAutoRestore()
    {
        var info    = new DotNetInfo(msbuild) { Command = "msbuild" };
        var options = new DotNetOptions { AutoRestore = false };

        AreEqual("msbuild", FormatArgs(info, options));
    }

    // restore ignores build options

    [TestMethod]
    public void FormatArgs_Restore_IgnoresOptions()
    {
        var info    = new DotNetInfo(restore) { Command = "restore", IsRebuild = true };
        var options = new DotNetOptions { BuildConf = "Release", Verbosity = Detailed, AutoRestore = false };

        AreEqual("restore", FormatArgs(info, options));
    }

    // package (add/remove)

    [TestMethod] public void FormatArgs_InstallPackage()
    {
        var info = new DotNetInfo(installpackage) { Command = "add", ID = "Newtonsoft.Json", Ver = "13.0.3", Args = "--prerelease" };
        AreEqual("add package Newtonsoft.Json --version 13.0.3 --prerelease", FormatArgs(info, DefaultOptions));
    }

    [TestMethod] public void FormatArgs_InstallPackage_NoVersion()
    {
        var info = new DotNetInfo(installpackage) { Command = "add", ID = "Serilog", Ver = "", Args = "" };
        AreEqual("add package Serilog", FormatArgs(info, DefaultOptions));
    }

    [TestMethod] public void FormatArgs_InstallPackage_NoID()
    {
        var info = new DotNetInfo(installpackage) { Command = "add", ID = "", Ver = "1.2.3", Args = "" };
        AreEqual("add --version 1.2.3", FormatArgs(info, DefaultOptions));
    }
}
