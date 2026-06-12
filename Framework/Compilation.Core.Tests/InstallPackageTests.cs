#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class InstallPackageTests : TestHelper
{
    private const string WrongID = "JJ.Framework.Oops";
    private const string WrongVer = "1234.1234.1234";

    // Syntaxes

    [TestMethod]
    public void Test_InstallPackage_MainCase() 
        => Assert(InstallPackage(ID, Ver, Opt()));

    [TestMethod]
    public void Test_InstallPackage_NoOpt() => InTempDir(() 
        => Assert(InstallPackage(ID, Ver)));

    [TestMethod]
    public void Test_InstallPackage_AsEnum() 
        => Assert(DotNet.Exe(installpackage, $"{ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_InstallPackage_AsEnum_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe(installpackage, $"{ID} -v {Ver}")));

    [TestMethod]
    public void Test_AddPackage_CommandTextAndArgs() 
        => Assert(DotNet.Exe("add package", $"{ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_AddPackage_CommandTextAndArgs_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("add package", $"{ID} -v {Ver}")));

    [TestMethod]
    public void Test_AddPackage_AllInCommandText() 
        => Assert(DotNet.Exe($"add package {ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_AddPackage_AllInCommandText_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe($"add package {ID} -v {Ver}")));

    [TestMethod]
    public void Test_AddPackage_AllInArgsOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"add package {ID} -v {Ver}")));

    [TestMethod]
    public void Test_AddPackage_AllInArgOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"add package {ID} -v {Ver}")));

    [TestMethod]
    public void Test_PackageAdd_CommandTextAndArgs() 
        => Assert(DotNet.Exe("package add", $"{ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_PackageAdd_CommandTextAndArgs_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("package add", $"{ID} -v {Ver}")));

    [TestMethod]
    public void Test_PackageAdd_AllInCommandText() 
        => Assert(DotNet.Exe($"package add {ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_PackageAdd_AllInCommandText_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe($"package add {ID} -v {Ver}")));

    [TestMethod]
    public void Test_PackageAdd_AllInArgsOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"package add {ID} -v {Ver}")));

    [TestMethod]
    public void Test_PackageAdd_AllInArgOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"package add {ID} -v {Ver}")));

    // File Options

    [TestMethod]
    public void Test_InstallPackage_WithFile() 
        => Assert(InstallPackage(ID, Ver, Opt() with { File = CsProjName }));

    [TestMethod]
    public void Test_InstallPackage_WithoutFile() 
        => Assert(InstallPackage(ID, Ver, Opt() with { File = "" }));

    [TestMethod]
    public void Test_InstallPackage_WithDir() 
        => Assert(InstallPackage(ID, Ver, Opt() with { Dir = TempDir }));

    [TestMethod]
    public void Test_InstallPackage_WithoutDir_WithFullFilePath() 
        => Assert(InstallPackage(ID, Ver, Opt() with { Dir = "", File = CsProjPath }));

    [TestMethod]
    public void Test_InstallPackage_WithoutDir_WithChDir() => InTempDir(() => 
    {
        Assert(InstallPackage(ID, Ver, Opt() with { Dir = "" }));
    });

    // Options

    [TestMethod]
    public void Test_InstallPackage_WithArg() 
        => Assert(InstallPackage(ID, Ver, "--no-restore", Opt()), restore: false);

    [TestMethod] 
    public void Test_InstallPackage_WithArg_NoOpt() => InTempDir(() =>
    {
        Assert(InstallPackage(ID, Ver, "--no-restore"), restore: false);
    });

    [TestMethod]
    public void Test_InstallPackage_OptsAllOn()
    {
        var opt = OptsAllOn() with { Args = "--no-restore" };
        var result = InstallPackage(ID, Ver, "--framework net10.0", opt);

        AssertOptsAllOn(result);
        AssertNotExists(AssetsFilePath);
    }
        
    [TestMethod]
    public void Test_InstallPackage_NoVer_InstallsLatest() 
        => Assert(InstallPackage(ID, "", Opt()));

    [TestMethod]
    public void Test_InstallPackage_WithAutoRestore_DoesNothingButWorks() 
        => Assert(InstallPackage(ID, Ver, Opt() with { AutoRestore = true }));

    // Error Cases

    [TestMethod]
    public void Test_InstallPackage_Exception_NoID() 
        => Throws(() => InstallPackage(id: "", Ver, Opt()), "required argument missing");

    [TestMethod]
    public void Test_InstallPackage_Exception_NoID_EvenWhenNoRestore() 
        => Throws(() => InstallPackage(id: "", Ver, "--no-restore", Opt()), "required argument missing");

    [TestMethod]
    public void Test_InstallPackage_Exception_InvalidPackageIDSyntax() 
        => Throws(() => InstallPackage("JJ.Framework/Common.Core", Ver, Opt()), "NU1017", "invalid package id");

    [TestMethod]
    public void Test_InstallPackage_Exception_InvalidVerSyntax() 
        => Throws(() => InstallPackage(ID, "1.0/x", Opt()), "not a valid version string");
    
    [TestMethod]
    public void Test_InstallPackage_Exception_CommandMissingArgOnly_FilePlacedBeforeArg()
        => Throws(() => DotNet.Exe("", $"add package {ID} -v {Ver}", Opt()), $"--project \"Temp.csproj\" add package {ID} -v {Ver}");

    [TestMethod]
    public void Test_InstallPackage_IDDoesNotExist_WithRestore_Exception() 
        => Throws(() => InstallPackage(id: "JJ.Framework.Oops", Ver, Opt()), "NU1101", "Unable to find package");

    [TestMethod]
    public void Test_InstallPackage_VerDoesNotExist_WithRestore_Exception() 
        => Throws(() => InstallPackage(ID, WrongVer, Opt()), "NU1102", $"Unable to find package {ID} with version", ">= " + WrongVer);

    [TestMethod]
    public void Test_InstallPackage_IDDoesNotExist_NoRestore_InstallSucceeds_BuildThrows()
    {
        // Assert for wrong ID passes
        Assert(InstallPackage(WrongID, Ver, "--no-restore", Opt()), restore: false);

        // Build should throw
        Throws(() => Build(Opt() with { AutoRestore = false }), "NETSDK1004", $"Assets file '{AssetsFilePath}' not found", "Run a NuGet package restore");
        Throws(() => Build(Opt() with { AutoRestore = true  }), $"Unable to find package {WrongID}");
    }

    [TestMethod]
    public void Test_InstallPackage_VerDoesNotExist_NoRestore_InstallSucceeds_BuildThrows()
    {
        // Install with wrong ver succeeds
        Assert(InstallPackage(ID, WrongVer, "--no-restore", Opt()), restore: false);
        
        // Build throws
        Throws(() => Build(Opt() with { AutoRestore = false }), "NETSDK1004", $"Assets file '{AssetsFilePath}' not found", "Run a NuGet package restore");
        Throws(() => Build(Opt() with { AutoRestore = true  }), $"Unable to find package {ID}");
    }

    // Assert

    private void Assert(DotNetResult result, bool restore = true)
    {
        string id = Coalesce(result.Args.ID, ID);
        bool hasVer = Has(result.Args.Ver);

        // Check success messages
        AssertResultOk(result);
        AssertContainsAny(result, 
            $"Adding PackageReference for package '{id}' into project '{CsProjName}'",
            $"Adding PackageReference for package '{id}' into project '{CsProjPath}'");

        // Check with or without ver
        if (hasVer)
        {
            AssertContains(result, $"PackageReference for package '{id}' version '{result.Args.Ver}' added to file '{CsProjPath}'");
        }
        else
        {
            AssertContains(result, $"PackageReference for package '{id}' "); AssertContains(result, $"added to file '{CsProjPath}'");
        }

        // Check Package Reference
        string content = ReadAllText(CsProjPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, $"<PackageReference Include=\"{id}\" Version=");

        // Check Restore
        if (!restore)
        {
            AssertNotExists(AssetsFilePath); // Asserts file does not exist, because --no-restore
            return;
        }

        AssertContains(result, "Writing assets file to disk");
        AssertContainsAny(result, $"Restored {CsProjPath}", $"Restored {CsProjName}");
        AssertExists(AssetsFilePath);
    }
}
