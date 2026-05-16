// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetEnricherAccessor;

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
        var args = new DotNetArgs(input);
        args = Enrich(args, DefaultOptions);
        AreEqual(input,     args.CommandEnum);
        AreEqual(command,   args.Command);
        AreEqual(isRebuild, args.IsRebuild);
    }

    [TestMethod] public void Enrich_BuildCommand()           => TestEnrich(input: "build",                     expect:     build           );
    [TestMethod] public void Enrich_BuildCommand_Rebuild()   => TestEnrich(input: "build", "--no-incremental", expect: re, rebuild         );
    [TestMethod] public void Enrich_MSBuildCommand()         => TestEnrich(input: "msbuild",                   expect:     msbuild         );
    [TestMethod] public void Enrich_MSBuildCommand_Rebuild() => TestEnrich(input: "msbuild", "/t:Rebuild",     expect: re, msrebuild       );
    [TestMethod] public void Enrich_RestoreCommand()         => TestEnrich(input: "restore",                   expect:     restore         );
    // TODO: These 2 assumptive cases are not clean.
    [TestMethod] public void Enrich_AddCommand()             => TestEnrich(input: "add",                       expect:     installpackage  );
    [TestMethod] public void Enrich_RemoveCommand()          => TestEnrich(input: "remove",                    expect:     uninstallpackage);
    [TestMethod] public void Enrich_UnknownCommand()         => TestEnrich(input: "custom",                    expect:     undefined       );

    private static void TestEnrich(string input, DotNetCommandEnum expect) => TestEnrich(input, "", false, expect);
    //private static void TestEnrich(string input, bool expect, DotNetCommandEnum @enum) => TestEnrich(input, "", expect, @enum);
    private static void TestEnrich(string input, string extraArgs, bool expect, DotNetCommandEnum @enum)
    {
        bool isRebuild = expect;
        var args = new DotNetArgs(input) { Args = extraArgs };
        args = Enrich(args, DefaultOptions);
        AreEqual(input,     args.Command);
        AreEqual(@enum,     args.CommandEnum);
        AreEqual(isRebuild, args.IsRebuild);
    }

    // Already-filled values are retained (not overwritten by enrichment)

    [TestMethod]
    public void Enrich_RetainsExistingCommand_EvenInConflict()
    {
        var conflicting = installpackage;
        var args = new DotNetArgs("build") { CommandEnum = conflicting };

        args = Enrich(args, DefaultOptions);

        AreEqual("build",     args.Command    );
        AreEqual(conflicting, args.CommandEnum);
    }

    [TestMethod]
    public void Enrich_RetainsExistingCommandEnum_EvenInConflict()
    {
        var conflicting = "add";
        var args = new DotNetArgs(restore) { Command = conflicting };

        args = Enrich(args, DefaultOptions);

        AreEqual(restore,     args.CommandEnum);
        AreEqual(conflicting, args.Command    );
    }

    [TestMethod]
    public void Enrich_RetainsIsRebuildTrue_EvenInConflict()
    {
        var conflicting = uninstallpackage;
        var args = new DotNetArgs { IsRebuild = true, CommandEnum = conflicting };

        args = Enrich(args, DefaultOptions);

        IsTrue  (             args.IsRebuild  );
        AreEqual(conflicting, args.CommandEnum);
    }
}
