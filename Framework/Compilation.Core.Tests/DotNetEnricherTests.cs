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
}
