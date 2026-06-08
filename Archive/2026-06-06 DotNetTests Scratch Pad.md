```cs

    // RebuildTests:
    // Most logic is already hit by BuildTests
    // Just look in BuildTests to see which are worth repeating for Rebuild.
    // Do explicit restores inside the methods themselves instead of constructor,
    // since that will get logging options applied to it.

    private void Assert(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();
        var result = call();
        AssertResult(result);
    }

        //BasicOpt = CreateBasicOpt();
    
    /*
    private void TestBuild(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();
        call();
        AssertExists(DllPath);
    }
    */

    // TODO: How about testing what happens if a build actually fails?

    // InstallPackage

    private void TestInstallPack_ChDir(Func<DotNetResult> call) => InTempDir(() => TestInstallPack(call));
    private void TestInstallPack(Func<DotNetResult> call)
    {
        AssertInitialState();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, PackID);

        string content = ReadAllText(CsprojPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, PackID);
        AssertContains(content, PackVer);
    }

    [TestMethod] public void Test_InstallPackage_ByMethod()                => TestInstallPack_ChDir(() => InstallPackage(PackID, PackVer));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithArgs()       => TestInstallPack_ChDir(() => InstallPackage(PackID, PackVer, "--no-restore"));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithOpt()        => TestInstallPack      (() => InstallPackage(PackID, PackVer, Opt()));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithArgsAndOpt() => TestInstallPack      (() => InstallPackage(PackID, PackVer, "--no-restore", Opt()));
    // ByEnum and ByName variants won't work unless you specify id and ver as args.

    // TODO: Test:
    // x Main case
    // x As command enum
    // x As command text
    // x As args only
    // x No opt
    // x Rework: Recognize command in text and arg in Enricher, which adjusts behavior in CmdFormatter.
    // x File situations
    // x With extra Args
    // x With AutoRestore (should be irrelevant but still work).
    // x All options on
    // x Overload space

        AssertContainsAny(result, 
            $"Adding PackageReference for package '{ID}' into project '{CsProjName}'",
            $"Adding PackageReference for package '{ID}' into project '{CsProjPath}'");
```