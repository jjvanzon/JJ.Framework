#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class UninstallPackageTests : TestHelper
{
    public UninstallPackageTests() => Initialize();

    // Syntaxes

    [TestMethod]
    public void Test_UninstallPackage()
        => Assert(UninstallPackage(ID, Opt()));

    [TestMethod]
    public void Test_UninstallPackage_NoOpt() => InTempDir(() 
        => Assert(UninstallPackage(ID)));

    [TestMethod]
    public void Test_UninstallPackage_AsCommandEnum() 
        => Assert(DotNet.Exe(uninstallpackage, ID, Opt()));

    [TestMethod]
    public void Test_UninstallPackage_AsCommandEnum_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe(uninstallpackage, ID)));

    [TestMethod]
    public void Test_RemovePackage_AsCommandTextAndArgs() 
        => Assert(DotNet.Exe("remove package", ID, Opt()));

    [TestMethod]
    public void Test_RemovePackage_AsCommandTextAndArgs_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("remove package", ID)));

    [TestMethod]
    public void Test_RemovePackage_AllInCommandTextOnly() 
        => Assert(DotNet.Exe($"remove package {ID}", Opt()));

    [TestMethod]
    public void Test_RemovePackage_AllInCommandTextOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe($"remove package {ID}")));

    [TestMethod]
    public void Test_RemovePackage_AllInArgsOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"remove package {ID}")));

    [TestMethod]
    public void Test_RemovePackage_AllInArgOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"remove package {ID}")));

    [TestMethod]
    public void Test_PackageRemove_AsCommandTextAndArgs() 
        => Assert(DotNet.Exe("package remove", ID, Opt()));

    [TestMethod]
    public void Test_PackageRemove_AsCommandTextAndArgs_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("package remove", ID)));

    [TestMethod]
    public void Test_PackageRemove_AllInCommandTextOnly() 
        => Assert(DotNet.Exe($"package remove {ID}", Opt()));

    [TestMethod]
    public void Test_PackageRemove_AllInCommandTextOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe($"package remove {ID}")));

    [TestMethod]
    public void Test_PackageRemove_AllInArgsOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"package remove {ID}")));

    [TestMethod]
    public void Test_PackageRemove_AllInArgOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"package remove {ID}")));

    // File Options

    [TestMethod]
    public void Test_UninstallPackage_WithFile() 
        => Assert(UninstallPackage(ID, Opt() with { File = CsProjName }));

    [TestMethod]
    public void Test_UninstallPackage_WithoutFile() 
        => Assert(UninstallPackage(ID, Opt() with { File = "" }));

    [TestMethod]
    public void Test_UninstallPackage_WithDir() 
        => Assert(UninstallPackage(ID, Opt() with { Dir = TempDir }));

    [TestMethod]
    public void Test_UninstallPackage_WithoutDir_WithFullFilePath() 
        => Assert(UninstallPackage(ID, Opt() with { Dir = "", File = CsProjPath }));

    [TestMethod]
    public void Test_UninstallPackage_WithoutDir_WithChDir() => InTempDir(() => 
    {
        Assert(UninstallPackage(ID, Opt() with { Dir = "" }));
    });

    // Options

    [TestMethod] 
    public void Test_InstallPackage_WithArg_NoOpt() => InTempDir(() =>
    {
        var result = UninstallPackage(ID, "--interactive");
        AssertContains(result, $"remove package {ID} --interactive");
        Assert(result);
    });

    [TestMethod] 
    public void Test_InstallPackage_WithArg_WithOpt()
    {
        var opt = Opt();
        var result = UninstallPackage(ID, "--interactive", opt);
        AssertContains(result, $"remove \"{opt.File}\" package {ID} --interactive");
        Assert(result);
    }

    [TestMethod]
    public void Test_UninstallPackage_OptsAllOn_ArgInOpts()
    {
        var opt = OptsAllOn() with { Args = "--interactive" };
        var result = UninstallPackage(ID, opt);

        AssertOptsAllOn(result, checkArgsArgs: false); 
        Assert(result);
    }

    [TestMethod]
    public void Test_UninstallPackage_OptsAllOn_ArgInCall()
    {
        var opt = OptsAllOn() with { Args = "" };
        var result = UninstallPackage(ID, "--interactive", opt);

        AssertOptsAllOn(result, checkOptArgs: false);
        Assert(result);
    }

    [TestMethod]
    public void Test_UninstallPackage_WithAutoRestore_DoesNothingButWorks() 
        => Assert(UninstallPackage(ID, Opt() with { AutoRestore = true }));

    // Error Cases

    [TestMethod]
    public void Test_UninstallPackage_Exception_MissingID() 
        => Throws(() => UninstallPackage(id: "", Opt()), "required argument missing");

    [TestMethod]
    public void Test_RemovePackage_Exception_CommandMissingArgOnly_CsProjNamePlacedBeforeArg()
        => Throws(() => DotNet.Exe("", $"remove package {ID}", Opt()), $"\"Temp.csproj\" remove package {ID}");
    
    [TestMethod]
    public void Test_PackageRemove_Exception_CommandMissingArgOnly_CsProjNamePlacedBeforeArg()
        => Throws(() => DotNet.Exe("", $"package remove {ID}", Opt()), $"\"Temp.csproj\" package remove {ID}");

    [TestMethod]
    public void Test_UninstallPackage_Exception_AccidentalVerInclusionAsArgs()
        => Throws(
            () => UninstallPackage(ID, Ver, Opt()),
            "remove \"Temp.csproj\" package JJ.Framework.Common.Core 4.6.6251",
            "Error: Specify only one package reference to remove.");

    // Helpers
    
    private void Initialize()
    {
        InstallPackage(ID, Ver, Opt());
        AssertContains(ReadAllText(CsProjPath), $"<PackageReference Include=\"{ID}\" Version=");
    }

    private void Assert(DotNetResult result)
    {
        AssertResultOk(result);
        AssertContainsAny(result, "dotnet uninstallpackage / remove package",
                                  "dotnet uninstallpackage | remove package",
                                  "dotnet uninstallpackage / package remove",
                                  "dotnet uninstallpackage | package remove");

        AssertContainsAny(result, $"Removing PackageReference for package '{ID}' from project '{CsProjName}'.",
                                  $"Removing PackageReference for package '{ID}' from project '{CsProjPath}'.");

        AssertNotContains(ReadAllText(CsProjPath), $"<PackageReference Include=\"{ID}\" Version=");
    }
}
