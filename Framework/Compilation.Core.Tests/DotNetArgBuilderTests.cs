namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetArgBuilderTests
{
    [TestMethod]
    public void FormatArgs_WithBuildAndOptions_FormatsDotNetArguments()
    {
        var info = new DotNetInfo(DotNetCommandEnum.build)
        {
            Command = "build",
            Args = "--nologo"
        };

        var options = new DotNetOptions
        {
            File = "MySolution.sln",
            BuildConf = "Release",
            Verbosity = DotNetVerbosity.Diagnostic,
            AutoRestore = false,
            Args = "-p:Foo=Bar"
        };

        string args = DotNetArgBuilder.FormatArgs(info, options);

        AreEqual("build \"MySolution.sln\" -c Release --verbosity Diagnostic -p:Foo=Bar --nologo --no-restore", args);
    }

    [TestMethod]
    public void FormatArgs_WithMSRebuild_UsesMSBuildSpecificArguments()
    {
        var info = new DotNetInfo(DotNetCommandEnum.msrebuild)
        {
            Command = "msbuild",
            IsRebuild = true
        };

        var options = new DotNetOptions
        {
            BuildConf = "Debug",
            Verbosity = DotNetVerbosity.Minimal,
            AutoRestore = true
        };

        string args = DotNetArgBuilder.FormatArgs(info, options);

        AreEqual("msbuild /p:Configuration=Debug /t:Rebuild -verbosity:Minimal -restore", args);
    }

    [TestMethod]
    public void FormatArgs_WithInstallPackage_FormatsPackageSegments()
    {
        var info = new DotNetInfo(DotNetCommandEnum.installpackage)
        {
            Command = "add",
            ID = "Newtonsoft.Json",
            Ver = "13.0.3",
            Args = "--prerelease"
        };

        string args = DotNetArgBuilder.FormatArgs(info, new DotNetOptions());

        AreEqual("add package Newtonsoft.Json --version 13.0.3 --prerelease", args);
    }
}
