namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetArgFormatterAccessor;

[TestClass]
public class DotNetArgFormatterTests
{
    // TODO: Info where both command string and command enum are specified are never used internally.
    //  So these tests are not representative.

    // dotnet build style

    [TestMethod]
    public void FormatArgs_Build_FullOptions()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build", Args = "--nologo" }.Obj;
        var opt  = new DotNetOptions { File = "MySolution.sln", BuildConf = "Release", Verbosity = Diagnostic, AutoRestore = false, Args = "-p:Foo=Bar" };

        AreEqual("build \"MySolution.sln\" -c Release --verbosity Diagnostic -p:Foo=Bar --nologo --no-restore", FormatArgs(args, opt));
    }

    [TestMethod]
    public void FormatArgs_Build_NoFile()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build" }.Obj;

        AreEqual("build --no-restore", FormatArgs(args, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_Rebuild()
    {
        var args = new DotNetArgsAccessor(rebuild) { Command = "build", IsRebuild = true }.Obj;

        AreEqual("build --no-incremental --no-restore", FormatArgs(args, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_AutoRestore()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build" }.Obj;
        var opt  = new DotNetOptions { AutoRestore = true };

        AreEqual("build", FormatArgs(args, opt));
    }

    // msbuild style

    [TestMethod]
    public void FormatArgs_MSRebuild_FullOptions()
    {
        var args = new DotNetArgsAccessor(msrebuild) { Command = "msbuild", IsRebuild = true }.Obj;
        var opt  = new DotNetOptions { BuildConf = "Debug", Verbosity = Minimal, AutoRestore = true };

        AreEqual("msbuild /p:Configuration=Debug /t:Rebuild -verbosity:Minimal -restore", FormatArgs(args, opt));
    }

    [TestMethod]
    public void FormatArgs_MSBuild_NoAutoRestore()
    {
        var args = new DotNetArgsAccessor(msbuild) { Command = "msbuild" }.Obj;
        var opt  = new DotNetOptions { AutoRestore = false };

        AreEqual("msbuild", FormatArgs(args, opt));
    }

    // restore

    // TODO: Package doesn't contain new functionality yet, due to CI blockage.

    [TestMethod]
    public void FormatArgs_Restore_IgnoresOptions()
    {
        var args = new DotNetArgsAccessor(restore) { Command = "restore", IsRebuild = true }.Obj;
        var opt  = new DotNetOptions { BuildConf = "Release", Verbosity = Detailed };

        AreEqual("restore --disable-parallel", FormatArgs(args, opt));
    }

    [TestMethod]
    public void FormatArgs_Restore_Parallel()
    {
        var args = new DotNetArgsAccessor(restore) { Command = "restore", IsRebuild = true }.Obj;
        var opt  = new DotNetOptions { ParallelRestore = true };

        AreEqual("restore", FormatArgs(args, opt));
    }

    // package (add/remove)

    [TestMethod] 
    public void FormatArgs_InstallPackage()
    {
        var args = new DotNetArgsAccessor(installpackage) { Command = "add", ID = "Newtonsoft.Json", Ver = "13.0.3", Args = "--prerelease" }.Obj;

        AreEqual("add package Newtonsoft.Json --version 13.0.3 --prerelease", FormatArgs(args, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_InstallPackage_NoVersion()
    {
        var args = new DotNetArgsAccessor(installpackage) { Command = "add", ID = "Serilog" }.Obj;

        AreEqual("add package Serilog", FormatArgs(args, DefaultOptions));
    }

    [TestMethod] 
    public void FormatArgs_InstallPackage_NoID()
    {
        var args = new DotNetArgsAccessor(installpackage) { Command = "add", Ver = "1.2.3" }.Obj;

        AreEqual("add --version 1.2.3", FormatArgs(args, DefaultOptions));
    }

    // TODO: `remove package` tests

    // TODO: Commands not in the DotNetCommandEnum.
}
