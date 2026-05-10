namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetEnricherTests
{
    private const bool re = true;

    [TestMethod] public void Enrich_BuildEnum()            => TestEnrich(input: build,            expect:     "build"  );
    [TestMethod] public void Enrich_RebuildEnum()          => TestEnrich(input: rebuild,          expect: re, "build"  );
    [TestMethod] public void Enrich_MSBuildEnum()          => TestEnrich(input: msbuild,          expect:     "msbuild");
    [TestMethod] public void Enrich_MSRebuildEnum()        => TestEnrich(input: msrebuild,        expect: re, "msbuild");
    [TestMethod] public void Enrich_RestoreEnum()          => TestEnrich(input: restore,          expect:     "restore");
    [TestMethod] public void Enrich_InstallPackageEnum()   => TestEnrich(input: installpackage,   expect:     "add"    );
    [TestMethod] public void Enrich_UninstallPackageEnum() => TestEnrich(input: uninstallpackage, expect:     "remove" );

    private static void TestEnrich(DotNetCommandEnum input, string expect) => TestEnrich(input, default, expect);
    private static void TestEnrich(DotNetCommandEnum input, bool expect, string command)
    {
        bool isRebuild = expect;
        var info = new DotNetInfo(input);
        Enrich(info);
        AreEqual(input,     info.CommandEnum);
        AreEqual(command,   info.Command);
        AreEqual(isRebuild, info.IsRebuild);
    }

    [TestMethod] public void Enrich_BuildCommand()           => TestEnrich(input: "build",                     expect:     build           );
    [TestMethod] public void Enrich_BuildCommand_Rebuild()   => TestEnrich(input: "build", "--no-incremental", expect: re, rebuild         );
    [TestMethod] public void Enrich_MSBuildCommand()         => TestEnrich(input: "msbuild",                   expect:     msbuild         );
    [TestMethod] public void Enrich_MSBuildCommand_Rebuild() => TestEnrich(input: "msbuild", "/t:Rebuild",     expect: re, msrebuild       );
    [TestMethod] public void Enrich_RestoreCommand()         => TestEnrich(input: "restore",                   expect:     restore         );
    [TestMethod] public void Enrich_AddCommand()             => TestEnrich(input: "add",                       expect:     installpackage  );
    [TestMethod] public void Enrich_RemoveCommand()          => TestEnrich(input: "remove",                    expect:     uninstallpackage);
    [TestMethod] public void Enrich_UnknownCommand()         => TestEnrich(input: "custom",                    expect:     undefined       );

    private static void TestEnrich(string input, DotNetCommandEnum expect) => TestEnrich(input, "", false, expect);
    private static void TestEnrich(string input, bool expect, DotNetCommandEnum @enum) => TestEnrich(input, "", expect, @enum);
    private static void TestEnrich(string input, string args, bool expect, DotNetCommandEnum @enum)
    {
        bool isRebuild = expect;
        var info = new DotNetInfo { Command = input, Args = args };
        Enrich(info);
        AreEqual(input,     info.Command);
        AreEqual(@enum,     info.CommandEnum);
        AreEqual(isRebuild, info.IsRebuild);
    }
}
