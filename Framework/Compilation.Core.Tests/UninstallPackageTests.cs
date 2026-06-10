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
