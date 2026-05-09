namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetEnricherTests
{
    [TestMethod]
    public void Enrich_WithRebuildEnum_MapsToBuildCommandAndKeepsRebuildFlag()
    {
        var info = new DotNetInfo(rebuild);

        Enrich(info);

        AreEqual("build", info.Command);
        AreEqual(rebuild, info.CommandEnum);
        IsTrue(info.IsRebuild);
    }

    [TestMethod]
    public void Enrich_WithMSBuildRebuildArgument_SetsMSRebuildCommandEnum()
    {
        var info = new DotNetInfo
        {
            Command = "msbuild",
            Args = "/t:Rebuild"
        };

        Enrich(info);

        AreEqual("msbuild", info.Command);
        AreEqual(msrebuild, info.CommandEnum);
        IsTrue(info.IsRebuild);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithUnknownCommand_ReturnsDefault()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("unknown", isRebuild: false);

        AreEqual(default, commandEnum);
    }

    [TestMethod]
    public void Enrich_WithBuildCommandAndRebuildArg_SetsRebuildEnum()
    {
        var info = new DotNetInfo
        {
            Command = "build",
            Args = "--no-incremental"
        };

        Enrich(info);

        AreEqual("build", info.Command);
        AreEqual(rebuild, info.CommandEnum);
        IsTrue(info.IsRebuild);
    }

    [TestMethod]
    public void Enrich_WithBuildEnum_SetsBuildCommandAndEnum()
    {
        var info = new DotNetInfo(build);

        Enrich(info);

        AreEqual("build", info.Command);
        AreEqual(build, info.CommandEnum);
        IsFalse(info.IsRebuild);
    }

    [TestMethod]
    public void Enrich_WithMSBuildEnum_SetsMSBuildCommandAndEnum()
    {
        var info = new DotNetInfo(msbuild);

        Enrich(info);

        AreEqual("msbuild", info.Command);
        AreEqual(msbuild, info.CommandEnum);
        IsFalse(info.IsRebuild);
    }

    [TestMethod]
    public void Enrich_WithRestoreEnum_SetsRestoreCommandAndEnum()
    {
        var info = new DotNetInfo(restore);

        Enrich(info);

        AreEqual("restore", info.Command);
        AreEqual(restore, info.CommandEnum);
    }

    [TestMethod]
    public void Enrich_WithInstallPackageEnum_SetsAddCommand()
    {
        var info = new DotNetInfo(installpackage);

        Enrich(info);

        AreEqual("add", info.Command);
        AreEqual(installpackage, info.CommandEnum);
    }

    [TestMethod]
    public void Enrich_WithUninstallPackageEnum_SetsRemoveCommand()
    {
        var info = new DotNetInfo(uninstallpackage);

        Enrich(info);

        AreEqual("remove", info.Command);
        AreEqual(uninstallpackage, info.CommandEnum);
    }

    [TestMethod]
    public void Enrich_WithUnknownStringCommandAndNoEnum_LeavesEnumDefault()
    {
        var info = new DotNetInfo
        {
            Command = "custom"
        };

        Enrich(info);

        AreEqual("custom", info.Command);
        AreEqual(default, info.CommandEnum);
        IsFalse(info.IsRebuild);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithBuildAndNoRebuild_ReturnsBuild()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("build", isRebuild: false);

        AreEqual(build, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithBuildAndRebuild_ReturnsRebuild()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("build", isRebuild: true);

        AreEqual(rebuild, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithMSBuildAndNoRebuild_ReturnsMSBuild()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("msbuild", isRebuild: false);

        AreEqual(msbuild, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithMSBuildAndRebuild_ReturnsMSRebuild()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("msbuild", isRebuild: true);

        AreEqual(msrebuild, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithRestore_ReturnsRestore()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("restore", isRebuild: false);

        AreEqual(restore, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithAdd_ReturnsInstallPackage()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("add", isRebuild: false);

        AreEqual(installpackage, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithRemove_ReturnsUninstallPackage()
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum("remove", isRebuild: false);

        AreEqual(uninstallpackage, commandEnum);
    }
}
