// ReSharper disable ConvertToConstant.Local
// ReSharper disable InlineTemporaryVariable

namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetEnricherAccessor;

[TestClass]
public class DotNetEnricherTests
{
    private const bool re = true;

    [TestMethod] public void Enrich_BuildEnum()            => TestEnrich(input: build,            expect:     "build"         );
    [TestMethod] public void Enrich_RebuildEnum()          => TestEnrich(input: rebuild,          expect: re, "build"         );
    [TestMethod] public void Enrich_MSBuildEnum()          => TestEnrich(input: msbuild,          expect:     "msbuild"       );
    [TestMethod] public void Enrich_MSRebuildEnum()        => TestEnrich(input: msrebuild,        expect: re, "msbuild"       );
    [TestMethod] public void Enrich_RestoreEnum()          => TestEnrich(input: restore,          expect:     "restore"       );
    [TestMethod] public void Enrich_InstallPackageEnum()   => TestEnrich(input: installpackage,   expect:     "add package"   );
    [TestMethod] public void Enrich_UninstallPackageEnum() => TestEnrich(input: uninstallpackage, expect:     "remove package");

    private static void TestEnrich(DotNetCommandEnum input, string expect) => TestEnrich(input, default, expect);
    private static void TestEnrich(DotNetCommandEnum input, bool expect, string command)
    {
        bool isRebuild = expect;
        var args = new DotNetArgsAccessor(input).Obj;
        Enrich(args);
        AreEqual(input,     args.CommandEnum);
        AreEqual(command,   args.Command);
        AreEqual(isRebuild, args.IsRebuild);
    }

    [TestMethod] public void Enrich_BuildCommand()           => TestEnrich(input: "build",                     expect:     build           );
    [TestMethod] public void Enrich_BuildCommand_Rebuild()   => TestEnrich(input: "build", "--no-incremental", expect: re, rebuild         );
    [TestMethod] public void Enrich_MSBuildCommand()         => TestEnrich(input: "msbuild",                   expect:     msbuild         );
    [TestMethod] public void Enrich_MSBuildCommand_Rebuild() => TestEnrich(input: "msbuild", "/t:Rebuild",     expect: re, msrebuild       );
    [TestMethod] public void Enrich_RestoreCommand()         => TestEnrich(input: "restore",                   expect:     restore         );
    [TestMethod] public void Enrich_AddCommand()             => TestEnrich(input: "add package",               expect:     installpackage  );
    [TestMethod] public void Enrich_RemoveCommand()          => TestEnrich(input: "remove package",            expect:     uninstallpackage);
    [TestMethod] public void Enrich_UnknownCommand()         => TestEnrich(input: "custom",                    expect:     undefined       );

    private static void TestEnrich(string input, DotNetCommandEnum expect) => TestEnrich(input, "", false, expect);
    //private static void TestEnrich(string input, bool expect, DotNetCommandEnum @enum) => TestEnrich(input, "", expect, @enum);
    private static void TestEnrich(string input, string extraArgs, bool expect, DotNetCommandEnum @enum)
    {
        bool isRebuild = expect;
        var args = new DotNetArgsAccessor(input) { Args = extraArgs }.Obj;
        Enrich(args);
        AreEqual(input,     args.Command);
        AreEqual(@enum,     args.CommandEnum);
        AreEqual(isRebuild, args.IsRebuild);
    }

    // Already-filled values are retained (not overwritten by enrichment)

    [TestMethod]
    public void Enrich_RetainsExistingCommand_EvenInConflict()
    {
        var conflicting = installpackage;
        var args = new DotNetArgsAccessor("build") { CommandEnum = conflicting }.Obj;

        Enrich(args);

        AreEqual("build",     args.Command    );
        AreEqual(conflicting, args.CommandEnum);
    }

    [TestMethod]
    public void Enrich_RetainsExistingCommandEnum_EvenInConflict()
    {
        var conflicting = "add";
        var args = new DotNetArgsAccessor(restore) { Command = conflicting }.Obj;

        Enrich(args);

        AreEqual(restore,     args.CommandEnum);
        AreEqual(conflicting, args.Command    );
    }

    [TestMethod]
    public void Enrich_RetainsIsRebuildTrue_EvenInConflict()
    {
        var conflicting = uninstallpackage;
        var args = new DotNetArgsAccessor { IsRebuild = true, CommandEnum = conflicting }.Obj;

        Enrich(args);

        IsTrue  (             args.IsRebuild  );
        AreEqual(conflicting, args.CommandEnum);
    }
}
