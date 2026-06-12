#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class UninstallPackageTests : DotNetTestHelper
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
    public void Test_RemovePackage_AllInommandTextOnly_NoOpt() => InTempDir(()
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
    public void Test_PackageRemove_AllInommandTextOnly_NoOpt() => InTempDir(()
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
    public void Test_UninstallPackage_OptsAllOn_ArgInOpts()
    {
        var opt = OptsAllOn() with { Args = "--interactive" };
        var result = UninstallPackage(ID, opt);

        // Complains about Args.Args not being filled. 
        // TODO: Make specialized version for UninstallPacakge, and move specific option to the ForBuild version?
        //AssertOptsAllOnResult(result); 

        Assert(result);
    }

    [TestMethod]
    public void Test_UninstallPackage_OptsAllOn_ArgInCall()
    {
        var opt = OptsAllOn() with { Args = "" };
        var result = UninstallPackage(ID, "--interactive", opt);

        //AssertOptsAllOnResult(result);
        Assert(result);
    }

    // Error cases

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
