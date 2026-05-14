namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetArgBuilderAccessor;

[TestClass]
[DoNotParallelize]
public class DotNetArgBuilderTests
{
    // TODO: Info where both command string and command enum are specified are never used internally.
    //  So these tests are not representative.

    // dotnet build style

    [TestMethod]
    public void FormatArgs_Build_FullOptions()
    {
        var info = new DotNetInfoAccessor(build)  { Command = "build", Args = "--nologo" };
        var opt  = new DotNetOptions { File = "MySolution.sln", BuildConf = "Release", Verbosity = Diagnostic, AutoRestore = false, Args = "-p:Foo=Bar" };

        AreEqual("build \"MySolution.sln\" -c Release --verbosity Diagnostic -p:Foo=Bar --nologo --no-restore", FormatArgs(info, opt));
    }

    [TestMethod]
    public void FormatArgs_Build_NoFile()
    {
        var info = new DotNetInfoAccessor(build) { Command = "build" };

        AreEqual("build --no-restore", FormatArgs(info, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_Rebuild()
    {
        var info = new DotNetInfoAccessor(rebuild) { Command = "build", IsRebuild = true };

        AreEqual("build --no-incremental --no-restore", FormatArgs(info, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_AutoRestore()
    {
        var info = new DotNetInfoAccessor(build) { Command = "build" };
        var opt  = new DotNetOptions { AutoRestore = true };

        AreEqual("build", FormatArgs(info, opt));
    }

    // msbuild style

    [TestMethod]
    public void FormatArgs_MSRebuild_FullOptions()
    {
        var info = new DotNetInfoAccessor(msrebuild) { Command = "msbuild", IsRebuild = true };
        var opt  = new DotNetOptions { BuildConf = "Debug", Verbosity = Minimal, AutoRestore = true };

        AreEqual("msbuild /p:Configuration=Debug /t:Rebuild -verbosity:Minimal -restore", FormatArgs(info, opt));
    }

    [TestMethod]
    public void FormatArgs_MSBuild_NoAutoRestore()
    {
        var info = new DotNetInfoAccessor(msbuild) { Command = "msbuild" };
        var opt  = new DotNetOptions { AutoRestore = false };

        AreEqual("msbuild", FormatArgs(info, opt));
    }

    // restore

    // TODO: Package doesn't contain new functionality yet, due to CI blockage.

    [TestMethod]
    public void FormatArgs_Restore_IgnoresOptions()
    {
        var info = new DotNetInfoAccessor(restore) { Command = "restore", IsRebuild = true };
        var opt  = new DotNetOptions { BuildConf = "Release", Verbosity = Detailed, AutoRestore = false };

        AreEqual("restore --disable-parallel", FormatArgs(info, opt));
    }

    [TestMethod]
    public void FormatArgs_Restore_Parallel()
    {
        var info = new DotNetInfoAccessor(restore) { Command = "restore", IsRebuild = true };
        var opt  = new DotNetOptions { ParallelRestore = true };

        AreEqual("restore", FormatArgs(info, opt));
    }

    // package (add/remove)

    [TestMethod] public void FormatArgs_InstallPackage()
    {
        var info = new DotNetInfoAccessor(installpackage) { Command = "add", ID = "Newtonsoft.Json", Ver = "13.0.3", Args = "--prerelease" };

        AreEqual("add package Newtonsoft.Json --version 13.0.3 --prerelease", FormatArgs(info, DefaultOptions));
    }

    [TestMethod] public void FormatArgs_InstallPackage_NoVersion()
    {
        var info = new DotNetInfoAccessor(installpackage) { Command = "add", ID = "Serilog", Ver = "", Args = "" };

        AreEqual("add package Serilog", FormatArgs(info, DefaultOptions));
    }

    [TestMethod] public void FormatArgs_InstallPackage_NoID()
    {
        var info = new DotNetInfoAccessor(installpackage) { Command = "add", ID = "", Ver = "1.2.3", Args = "" };

        AreEqual("add --version 1.2.3", FormatArgs(info, DefaultOptions));
    }

    // TODO: `remove package` tests

    // TODO: Commands not in the DotNetCommandEnum.
}
