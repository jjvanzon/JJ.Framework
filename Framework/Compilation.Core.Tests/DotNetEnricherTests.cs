namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetEnricherTests
{
    [TestMethod]
    public void Enrich_WithRebuildEnum_MapsToBuildCommandAndKeepsRebuildFlag()
    {
        var info = new DotNetInfo(DotNetCommandEnum.rebuild);

        DotNetEnricher.Enrich(info);

        AreEqual("build", info.Command);
        AreEqual(DotNetCommandEnum.rebuild, info.CommandEnum);
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

        DotNetEnricher.Enrich(info);

        AreEqual("msbuild", info.Command);
        AreEqual(DotNetCommandEnum.msrebuild, info.CommandEnum);
        IsTrue(info.IsRebuild);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithUnknownCommand_ReturnsDefault()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("unknown", isRebuild: false);

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

        DotNetEnricher.Enrich(info);

        AreEqual("build", info.Command);
        AreEqual(DotNetCommandEnum.rebuild, info.CommandEnum);
        IsTrue(info.IsRebuild);
    }

    [TestMethod]
    public void Enrich_WithBuildEnum_SetsBuildCommandAndEnum()
    {
        var info = new DotNetInfo(DotNetCommandEnum.build);

        DotNetEnricher.Enrich(info);

        AreEqual("build", info.Command);
        AreEqual(DotNetCommandEnum.build, info.CommandEnum);
        IsFalse(info.IsRebuild);
    }

    [TestMethod]
    public void Enrich_WithMSBuildEnum_SetsMSBuildCommandAndEnum()
    {
        var info = new DotNetInfo(DotNetCommandEnum.msbuild);

        DotNetEnricher.Enrich(info);

        AreEqual("msbuild", info.Command);
        AreEqual(DotNetCommandEnum.msbuild, info.CommandEnum);
        IsFalse(info.IsRebuild);
    }

    [TestMethod]
    public void Enrich_WithRestoreEnum_SetsRestoreCommandAndEnum()
    {
        var info = new DotNetInfo(DotNetCommandEnum.restore);

        DotNetEnricher.Enrich(info);

        AreEqual("restore", info.Command);
        AreEqual(DotNetCommandEnum.restore, info.CommandEnum);
    }

    [TestMethod]
    public void Enrich_WithInstallPackageEnum_SetsAddCommand()
    {
        var info = new DotNetInfo(DotNetCommandEnum.installpackage);

        DotNetEnricher.Enrich(info);

        AreEqual("add", info.Command);
        AreEqual(DotNetCommandEnum.installpackage, info.CommandEnum);
    }

    [TestMethod]
    public void Enrich_WithUninstallPackageEnum_SetsRemoveCommand()
    {
        var info = new DotNetInfo(DotNetCommandEnum.uninstallpackage);

        DotNetEnricher.Enrich(info);

        AreEqual("remove", info.Command);
        AreEqual(DotNetCommandEnum.uninstallpackage, info.CommandEnum);
    }

    [TestMethod]
    public void Enrich_WithUnknownStringCommandAndNoEnum_LeavesEnumDefault()
    {
        var info = new DotNetInfo
        {
            Command = "custom"
        };

        DotNetEnricher.Enrich(info);

        AreEqual("custom", info.Command);
        AreEqual(default, info.CommandEnum);
        IsFalse(info.IsRebuild);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithBuildAndNoRebuild_ReturnsBuild()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("build", isRebuild: false);

        AreEqual(DotNetCommandEnum.build, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithBuildAndRebuild_ReturnsRebuild()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("build", isRebuild: true);

        AreEqual(DotNetCommandEnum.rebuild, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithMSBuildAndNoRebuild_ReturnsMSBuild()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("msbuild", isRebuild: false);

        AreEqual(DotNetCommandEnum.msbuild, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithMSBuildAndRebuild_ReturnsMSRebuild()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("msbuild", isRebuild: true);

        AreEqual(DotNetCommandEnum.msrebuild, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithRestore_ReturnsRestore()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("restore", isRebuild: false);

        AreEqual(DotNetCommandEnum.restore, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithAdd_ReturnsInstallPackage()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("add", isRebuild: false);

        AreEqual(DotNetCommandEnum.installpackage, commandEnum);
    }

    [TestMethod]
    public void TryGetCommandEnum_WithRemove_ReturnsUninstallPackage()
    {
        DotNetCommandEnum commandEnum = DotNetEnricher.TryGetCommandEnum("remove", isRebuild: false);

        AreEqual(DotNetCommandEnum.uninstallpackage, commandEnum);
    }
}
