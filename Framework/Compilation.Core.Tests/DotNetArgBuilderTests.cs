namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetArgBuilderTests
{
    [TestMethod]
    public void FormatArgs_WithBuildAndOptions_FormatsDotNetArguments()
    {
        var info = new DotNetInfo(build)
        {
            Command = "build",
            Args = "--nologo"
        };

        var options = new DotNetOptions
        {
            File = "MySolution.sln",
            BuildConf = "Release",
            Verbosity = Diagnostic,
            AutoRestore = false,
            Args = "-p:Foo=Bar"
        };

        string args = FormatArgs(info, options);

        AreEqual("build \"MySolution.sln\" -c Release --verbosity Diagnostic -p:Foo=Bar --nologo --no-restore", args);
    }

    [TestMethod]
    public void FormatArgs_WithMSRebuild_UsesMSBuildSpecificArguments()
    {
        var info = new DotNetInfo(msrebuild)
        {
            Command = "msbuild",
            IsRebuild = true
        };

        var options = new DotNetOptions
        {
            BuildConf = "Debug",
            Verbosity = Minimal,
            AutoRestore = true
        };

        string args = FormatArgs(info, options);

        AreEqual("msbuild /p:Configuration=Debug /t:Rebuild -verbosity:Minimal -restore", args);
    }

    [TestMethod]
    public void FormatArgs_WithInstallPackage_FormatsPackageSegments()
    {
        var info = new DotNetInfo(installpackage)
        {
            Command = "add",
            ID = "Newtonsoft.Json",
            Ver = "13.0.3",
            Args = "--prerelease"
        };

        string args = FormatArgs(info, new DotNetOptions());

        AreEqual("add package Newtonsoft.Json --version 13.0.3 --prerelease", args);
    }

    [TestMethod]
    public void FormatArgs_WithNoFile_DoesNotAddQuotedFile()
    {
        var info = new DotNetInfo(build) { Command = "build" };

        string args = FormatArgs(info, new DotNetOptions());

        AreEqual("build --no-restore", args);
    }

    [TestMethod]
    public void FormatArgs_WithBuildAndAutoRestoreTrue_DoesNotAddNoRestoreFlag()
    {
        var info = new DotNetInfo(build) { Command = "build" };
        var options = new DotNetOptions { AutoRestore = true };

        string args = FormatArgs(info, options);

        AreEqual("build", args);
    }

    [TestMethod]
    public void FormatArgs_WithMSBuildAndAutoRestoreFalse_DoesNotAddRestoreFlag()
    {
        var info = new DotNetInfo(msbuild) { Command = "msbuild" };
        var options = new DotNetOptions { AutoRestore = false };

        string args = FormatArgs(info, options);

        AreEqual("msbuild", args);
    }

    [TestMethod]
    public void FormatArgs_WithBuildAndIsRebuild_AddsDotNetRebuildArgument()
    {
        var info = new DotNetInfo(rebuild)
        {
            Command = "build",
            IsRebuild = true
        };

        string args = FormatArgs(info, new DotNetOptions());

        AreEqual("build --no-incremental --no-restore", args);
    }

    [TestMethod]
    public void FormatArgs_WithRestore_IgnoresBuildConfVerbosityAndRebuild()
    {
        var info = new DotNetInfo(restore)
        {
            Command = "restore",
            IsRebuild = true
        };
        var options = new DotNetOptions
        {
            BuildConf = "Release",
            Verbosity = Detailed,
            AutoRestore = false
        };

        string args = FormatArgs(info, options);

        AreEqual("restore", args);
    }

    [TestMethod]
    public void FormatArgs_WithInstallPackageWithoutVersion_OmitsVersionSegment()
    {
        var info = new DotNetInfo(installpackage)
        {
            Command = "add",
            ID = "Serilog"
        };

        string args = FormatArgs(info, new DotNetOptions());

        AreEqual("add package Serilog", args);
    }

    [TestMethod]
    public void FormatArgs_WithNoPackageID_OmitsPackageSegment()
    {
        var info = new DotNetInfo(installpackage)
        {
            Command = "add",
            Ver = "1.2.3"
        };

        string args = FormatArgs(info, new DotNetOptions());

        AreEqual("add --version 1.2.3", args);
    }
}
