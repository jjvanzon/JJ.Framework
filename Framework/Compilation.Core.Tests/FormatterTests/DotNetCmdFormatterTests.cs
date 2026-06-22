namespace JJ.Framework.Compilation.Core.Tests.FormatterTests;

using static DotNetCmdFormatterAccessor;

[TestClass]
public class DotNetCmdFormatterTests
{
    // TODO: Info where both command string and command enum are specified are never used internally.
    //  So these tests are not representative.

    // dotnet build style

    [TestMethod]
    public void FormatArgs_Build_FullOptions()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build", Args = "--nologo" };
        var opt  = new DotNetOptions { File = "MySolution.sln", BuildConf = "Release", Verbosity = Diagnostic, AutoRestore = false, Args = "-p:Foo=Bar" };

        AreEqual("build \"MySolution.sln\" -c Release --verbosity Diagnostic --nodereuse:false -p:Foo=Bar --nologo --no-restore", FormatArgs(args, opt));
    }

    [TestMethod]
    public void FormatArgs_Build_NoFile()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build" };

        AreEqual("build --nodereuse:false --no-restore", FormatArgs(args, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_Rebuild()
    {
        var args = new DotNetArgsAccessor(rebuild) { Command = "build", IsRebuild = true };

        AreEqual("build --no-incremental --nodereuse:false --no-restore", FormatArgs(args, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_Build_AutoRestore()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build" };
        var opt  = new DotNetOptions { AutoRestore = true };

        AreEqual("build --nodereuse:false", FormatArgs(args, opt));
    }

    [TestMethod]
    public void FormatArgs_Build_BinLog()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build" };
        var opt  = new DotNetOptions { BinLog = "build.binlog" };

        AreEqual("build --nodereuse:false -bl:\"build.binlog\" --no-restore", FormatArgs(args, opt));
    }

    // msbuild style

    [TestMethod]
    public void FormatArgs_MSRebuild_FullOptions()
    {
        var args = new DotNetArgsAccessor(msrebuild) { Command = "msbuild", IsRebuild = true };
        var opt  = new DotNetOptions { BuildConf = "Debug", Verbosity = Minimal, AutoRestore = true };

        AreEqual("msbuild /p:Configuration=Debug /t:Rebuild -verbosity:Minimal --nodereuse:false -restore", FormatArgs(args, opt));
    }

    [TestMethod]
    public void FormatArgs_MSBuild_NoAutoRestore()
    {
        var args = new DotNetArgsAccessor(msbuild) { Command = "msbuild" };
        var opt  = new DotNetOptions { AutoRestore = false };

        AreEqual("msbuild --nodereuse:false", FormatArgs(args, opt));
    }

    // restore

    [TestMethod]
    public void FormatArgs_Restore_IgnoresOptions()
    {
        var args = new DotNetArgsAccessor(restore) { Command = "restore", IsRebuild = true };
        var opt  = new DotNetOptions { BuildConf = "Release", Verbosity = Detailed };

        AreEqual("restore --disable-parallel", FormatArgs(args, opt));
    }

    [TestMethod]
    public void FormatArgs_Restore_Parallel()
    {
        var args = new DotNetArgsAccessor(restore) { Command = "restore", IsRebuild = true };
        var opt  = new DotNetOptions { ParallelRestore = true };

        AreEqual("restore", FormatArgs(args, opt));
    }

    // package (add/remove)

    [TestMethod] 
    public void FormatArgs_InstallPackage()
    {
        var args = new DotNetArgsAccessor(installpackage) { Command = "add package", ID = "JJ.Framework.Common.Core", Ver = "4.6.6251", Args = "--prerelease" };

        AreEqual("add package JJ.Framework.Common.Core --version 4.6.6251 --prerelease", FormatArgs(args, DefaultOptions));
    }

    [TestMethod]
    public void FormatArgs_InstallPackage_NoVersion()
    {
        var args = new DotNetArgsAccessor(installpackage) { Command = "add package", ID = "JJ.Framework.Common.Core" };

        AreEqual("add package JJ.Framework.Common.Core", FormatArgs(args, DefaultOptions));
    }

    [TestMethod] 
    public void FormatArgs_InstallPackage_NoID()
    {
        var args = new DotNetArgsAccessor(installpackage) { Command = "add package", Ver = "1.2.3" };

        AreEqual("add package --version 1.2.3", FormatArgs(args, DefaultOptions));
    }

    // TODO: `remove package` tests

    // TODO: Commands not in the DotNetCommandEnum.
}
