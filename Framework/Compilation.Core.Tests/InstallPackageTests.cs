#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class InstallPackageTests : DotNetTestHelper
{
    public InstallPackageTests() => AssertInitialState();

    private const string ID = "JJ.Framework.Common.Core";
    private const string Ver = "4.6.6251";

    // Syntaxes

    [TestMethod]
    public void Test_InstallPackage_MainCase() 
        => Assert(InstallPackage(ID, Ver, Opt()));

    [TestMethod]
    public void Test_InstallPackage_NoOpt() => InTempDir(() 
        => Assert(InstallPackage(ID, Ver)));

    [TestMethod]
    public void Test_InstallPackage_AsCommandEnum() 
        => Assert(DotNet.Exe(installpackage, $"{ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_InstallPackage_AsCommandEnum_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe(installpackage, $"{ID} -v {Ver}")));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextAndArgs() 
        => Assert(DotNet.Exe("add package", $"{ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextAndArgs_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("add package", $"{ID} -v {Ver}")));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextOnly() 
        => Assert(DotNet.Exe($"add package {ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe($"add package {ID} -v {Ver}")));

    [TestMethod]
    public void Test_InstallPackage_NoCommandAsArgOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"add package {ID} -v {Ver}")));

    // Options

    [TestMethod]
    public void Test_InstallPackage_WithAutoRestore_DoesNothingButWorks()
    {
        Assert(InstallPackage(ID, Ver, Opt() with { AutoRestore = true }));
    }
    
    [TestMethod]
    public void Test_InstallPackage_WithArg()
    {
        AssertNoRestore(InstallPackage(ID, Ver, "--no-restore", Opt()));
    }

    [TestMethod] 
    public void Test_InstallPackage_WithArg_NoOpt() => InTempDir(() =>
    {
        AssertNoRestore(InstallPackage(ID, Ver, "--no-restore"));
    });

    [TestMethod]
    public void Test_InstallPackage_OptsAllOn()
    {
        var opt = OptsAllOn() with { Args = "--no-restore" };
        var result = InstallPackage(ID, Ver, "--framework net10.0", opt);

        AssertOptsAllOnResult(result);
        AssertNotExists(AssetsFilePath);
    }
        
    [TestMethod]
    public void Test_InstallPackage_NoVer_InstallsLatest()
    {
        Assert(InstallPackage(ID, "", Opt()));
    }

    // File Options

    [TestMethod]
    public void Test_InstallPackage_WithFile()
    {
        Assert(InstallPackage(ID, Ver, Opt() with { File = CsProjName }));
    }

    [TestMethod]
    public void Test_InstallPackage_WithoutFile()
    {
        Assert(InstallPackage(ID, Ver, Opt() with { File = "" }));
    }

    [TestMethod]
    public void Test_InstallPackage_WithDir()
    {
        Assert(InstallPackage(ID, Ver, Opt() with { Dir = TempDir }));
    }

    [TestMethod]
    public void Test_InstallPackage_WithoutDir_WithFullFilePath()
    {
        Assert(InstallPackage(ID, Ver, Opt() with { Dir = "", File = CsProjPath }));
    }

    [TestMethod]
    public void Test_InstallPackage_WithoutDir_WithChDir() => InTempDir(() => 
    {
        Assert(InstallPackage(ID, Ver, Opt() with { Dir = "" }));
    });

    // Error Cases
    
    [TestMethod]
    public void Test_InstallPackage_Exception_NoCommand_ArgOnly_WithFile_PlacedBeforeArg() 
        => Throws(
            () => DotNet.Exe("", $"add package {ID} -v {Ver}", Opt()), 
            $"--project \"Temp.csproj\" add package {ID} -v {Ver}");

    [TestMethod]
    public void Test_InstallPackage_Exception_NoID()
    {
        Throws(() => InstallPackage("", Ver, Opt()), "required argument missing");
    }

    [TestMethod]
    public void Test_InstallPackage_Exception_NoID_EvenWhenNoRestore()
    {
        var opt = Opt() with { AutoRestore = false }; // TODO: Auto-Restore not applied.
        Throws(() => InstallPackage(id: "", Ver, "--no-restore", opt), "required argument missing");
    }

    [TestMethod]
    public void Test_InstallPackage_Exception_InvalidPackageIDSyntax()
    {
        Throws(() => InstallPackage("JJ.Framework/Common.Core", Ver, Opt()), "NU1017", "invalid package id");
    }

    [TestMethod]
    public void Test_InstallPackage_Exception_InvalidVerSyntax()
    {
        Throws(() => InstallPackage(ID, "1.0/x", Opt()), "not a valid version string");
    }

    [TestMethod]
    public void Test_InstallPackage_Exception_IDDoesNotExist_WithRestore()
    {
        Throws(() => InstallPackage(id: "JJ.Framework.Oops", Ver, Opt()), "NU1101", "Unable to find package");
    }

    [TestMethod]
    public void Test_InstallPackage_IDDoesNotExist_NoRestore_InstallSucceeds_BuildThrows()
    {
        var opt = Opt() with { AutoRestore = false };
        const string wrongID = "JJ.Framework.Oops";

        var result = InstallPackage(wrongID, Ver, "--no-restore", opt);
        
        // Assert for different ID.
        AssertResultOk(result);
        AssertContains(result, $"Adding PackageReference for package '{wrongID}' into project");
        AssertContains(result, $"PackageReference for package '{wrongID}' version '{Ver}' added");
        
        // Asserts file does not exist, because --no-restore
        AssertNotExists(AssetsFilePath); 

        // Build should throw
        Throws(() => Build(opt), 
            "NETSDK1004", $"Assets file '{AssetsFilePath}' not found", "Run a NuGet package restore");

        Throws(() => Build(opt with { AutoRestore = true }), $"Unable to find package {wrongID}");
    }

    [TestMethod]
    public void Test_InstallPackage_Exception_VerDoesNotExist_WithRestore()
    {
        Throws(
            () => InstallPackage(ID, "1234.1234.1234", Opt()), 
            "NU1102", $"Unable to find package {ID} with version", ">= 1234.1234.1234");
    }

    [TestMethod]
    public void Test_InstallPackage_VerDoesNotExist_NoRestore_InstallSucceeds_BuildThrows()
    {
        var opt = Opt() with { AutoRestore = false };
        const string wrongVer = "1234.1234.1234";

        var result = InstallPackage(ID, "1234.1234.1234", "--no-restore", opt);

        // Install package succeeds
        AssertResultOk(result);
        AssertContains(result, $"Adding PackageReference for package '{ID}' into project");
        AssertContains(result, $"PackageReference for package '{ID}' version '{wrongVer}' added");

        AssertNotExists(AssetsFilePath); 

        // Build throws
        Throws(() => Build(opt), 
            "NETSDK1004", $"Assets file '{AssetsFilePath}' not found", "Run a NuGet package restore");

        Throws(() => Build(opt with { AutoRestore = true }), $"Unable to find package {ID}");
    }

    // Assertion

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    private void Assert(DotNetResult result)
    {
        AssertResult(result);
        AssertContains(result, "Writing assets file to disk");
        AssertContainsAny(result, $"Restored {CsProjPath}", $"Restored {CsProjName}");
        AssertExists(AssetsFilePath);
        AssertPackageReference();
    }
    
    private void AssertNoRestore(DotNetResult result)
    {
        AssertResult(result);
        AssertNotExists(AssetsFilePath); // Asserts file does not exist, because --no-restore
        AssertPackageReference();
    }

    private void AssertResult(DotNetResult result)
    {
        AssertResultOk(result);

        AssertContains(result, result.Args.Ver);

        AssertContainsAny(result, 
            $"Adding PackageReference for package '{ID}' into project '{CsProjName}'",
            $"Adding PackageReference for package '{ID}' into project '{CsProjPath}'");
        
        AssertContains(result, $"Added to file '{CsProjPath}'");
    }

    private void AssertPackageReference()
    {
        string content = ReadAllText(CsProjPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, $"<PackageReference Include=\"{ID}\" Version=");
    }
}
