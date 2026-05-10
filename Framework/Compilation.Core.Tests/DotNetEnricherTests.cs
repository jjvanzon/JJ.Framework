namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetEnricherTests
{
    // Enum-based input: command and rebuild flag are derived from the enum

    [TestMethod] public void Enrich_BuildEnum()            => EnrichEnum(build,            "build",   false);
    [TestMethod] public void Enrich_RebuildEnum()          => EnrichEnum(rebuild,           "build",   true );
    [TestMethod] public void Enrich_MSBuildEnum()          => EnrichEnum(msbuild,           "msbuild", false);
    [TestMethod] public void Enrich_MSRebuildEnum()        => EnrichEnum(msrebuild,         "msbuild", true );
    [TestMethod] public void Enrich_RestoreEnum()          => EnrichEnum(restore,           "restore", false);
    [TestMethod] public void Enrich_InstallPackageEnum()   => EnrichEnum(installpackage,    "add",     false);
    [TestMethod] public void Enrich_UninstallPackageEnum() => EnrichEnum(uninstallpackage,  "remove",  false);

    static void EnrichEnum(DotNetCommandEnum inputEnum, string expectedCommand, bool expectedIsRebuild)
    {
        var info = new DotNetInfo(inputEnum);
        Enrich(info);
        AreEqual(expectedCommand,   info.Command);
        AreEqual(inputEnum,         info.CommandEnum);
        AreEqual(expectedIsRebuild, info.IsRebuild);
    }

    // String-based input: enum is resolved from the command string (and rebuild args)

    [TestMethod] public void Enrich_BuildCommand()              => EnrichCommand("build",   "",                 build,           false);
    [TestMethod] public void Enrich_BuildCommand_Rebuild()      => EnrichCommand("build",   "--no-incremental", rebuild,         true );
    [TestMethod] public void Enrich_MSBuildCommand()            => EnrichCommand("msbuild", "",                 msbuild,         false);
    [TestMethod] public void Enrich_MSBuildCommand_Rebuild()    => EnrichCommand("msbuild", "/t:Rebuild",       msrebuild,       true );
    [TestMethod] public void Enrich_RestoreCommand()            => EnrichCommand("restore", "",                 restore,         false);
    [TestMethod] public void Enrich_AddCommand()                => EnrichCommand("add",     "",                 installpackage,  false);
    [TestMethod] public void Enrich_RemoveCommand()             => EnrichCommand("remove",  "",                 uninstallpackage,false);
    [TestMethod] public void Enrich_UnknownCommand()            => EnrichCommand("custom",  "",                 default,         false);

    static void EnrichCommand(string command, string args, DotNetCommandEnum expectedEnum, bool expectedIsRebuild)
    {
        var info = new DotNetInfo { Command = command, Args = args };
        Enrich(info);
        AreEqual(command,           info.Command);
        AreEqual(expectedEnum,      info.CommandEnum);
        AreEqual(expectedIsRebuild, info.IsRebuild);
    }
}
