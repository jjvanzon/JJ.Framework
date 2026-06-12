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
c
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

        //AssertContains(content, ID);
        //AssertContains(content, Ver);

    // TODO: Test error cases:
    // x Package does not exist (might pass install, just to break upon compilation)
    // x Package version does not exist

    // TODO: --no-restore appears to have an effect. Is the AutoRestore option applied 
    //  to InstallPackage automatically?

        Assert(result, release: true); // TODO: Redundant? Shouldn't the call below cover all of it?


    /*
    [Obsolete]
    private void Assert(Func<DotNetResult> call, string args = "", bool release = false)
    {
        var result = call();

        Assert(result, args, release);
    }
    */

    //private void AssertNoDir(Func<DotNetResult> call) => InTempDir(() => Assert(call));


    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.
    
    private void TestMSBuild_ChDir(Func<DotNetResult> call) => InTempDir(() => TestMSBuild(call));
    private void TestMSBuild(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, DllPath);
        AssertExists(DllPath);
    }

    [TestMethod] public void Test_MSBuild_ByMethod()                => TestMSBuild_ChDir(() =>             MSBuild(               ));
    [TestMethod] public void Test_MSBuild_ByMethod_WithOpt()        => TestMSBuild      (() =>             MSBuild(          Opt()));
    [TestMethod] public void Test_MSBuild_ByMethod_WithArgs()       => TestMSBuild_ChDir(() =>             MSBuild(  "-low"       ));
    [TestMethod] public void Test_MSBuild_ByMethod_WithArgsAndOpt() => TestMSBuild      (() =>             MSBuild(  "-low", Opt()));
    [TestMethod] public void Test_MSBuild_ByEnum()                  => TestMSBuild_ChDir(() => DotNet.Exe( msbuild                ));
    [TestMethod] public void Test_MSBuild_ByEnum_WithOpt()          => TestMSBuild      (() => DotNet.Exe( msbuild,          Opt()));
    [TestMethod] public void Test_MSBuild_ByEnum_WithArgs()         => TestMSBuild_ChDir(() => DotNet.Exe( msbuild,  "-low"       ));
    [TestMethod] public void Test_MSBuild_ByEnum_WithArgsAndOpt()   => TestMSBuild      (() => DotNet.Exe( msbuild,  "-low", Opt()));
    [TestMethod] public void Test_MSBuild_ByName()                  => TestMSBuild_ChDir(() => DotNet.Exe("msbuild"               ));
    [TestMethod] public void Test_MSBuild_ByName_WithOpt()          => TestMSBuild      (() => DotNet.Exe("msbuild",         Opt()));
    [TestMethod] public void Test_MSBuild_ByName_WithArgs()         => TestMSBuild_ChDir(() => DotNet.Exe("msbuild", "-low"       ));
    [TestMethod] public void Test_MSBuild_ByName_WithArgsAndOpt()   => TestMSBuild      (() => DotNet.Exe("msbuild", "-low", Opt()));

        AssertContains(result, "dotnet rebuild | build");

    private void AssertInitialState()
    {
        AssertExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }


    private void AssertInitialState()
    {
        AssertExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    [TestMethod]
    public void Test_Rebuild_AutoRestore()
    {
        Assert(Rebuild(Opt() with { AutoRestore = true }));
    }

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    [TestMethod]
    public void Test_Rebuild_ErrorCase_ForgotRestore()
    {
        LogNormal("Error = expected");

        Exception ex = Throws(() => Rebuild(Opt()));

        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "NETSDK1004");
        AssertContains(ex.Message, "Run a NuGet package restore");

        LogNormal($"{ex}");
    }
    
    internal void AssertInitialStateForBuild()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    private void AssertNoDir(Func<DotNetResult> call) => InTempDir(() => Assert(call));

    private void Assert(Func<DotNetResult> call)
    {
        InitRestore();
        var result = call();
        Assert(result);
        AssertDll();
    }

    private void Assert(Func<DotNetOptions, DotNetResult> call, DotNetOptions opt)
    {
        var result = call(opt);
        Assert(result);
    }


    // MSRebuild

    private void TestMSRebuild_ChDir(Func<DotNetResult> call) => InTempDir(() => TestMSRebuild(call));
    private void TestMSRebuild(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, DllPath);
        AssertExists(DllPath);
    }

    [TestMethod] public void Test_MSRebuild_ByMethod()                => TestMSRebuild_ChDir  (() =>            MSRebuild(              ));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithOpt()        => TestMSRebuild        (() =>            MSRebuild(         Opt()));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithArgs()       => TestMSRebuild_ChDir  (() =>            MSRebuild( "-low"       ));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithArgsAndOpt() => TestMSRebuild        (() =>            MSRebuild( "-low", Opt()));
    [TestMethod] public void Test_MSRebuild_ByEnum()                  => TestMSRebuild_ChDir  (() => DotNet.Exe(msrebuild               ));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithOpt()          => TestMSRebuild        (() => DotNet.Exe(msrebuild,         Opt()));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithArgs()         => TestMSRebuild_ChDir  (() => DotNet.Exe(msrebuild, "-low"       ));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithArgsAndOpt()   => TestMSRebuild        (() => DotNet.Exe(msrebuild, "-low", Opt()));

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    private void AssertNoDir(Func<DotNetResult> call) => InTempDir(() => Assert(call()));

    //private const string ID = "JJ.Framework.Common.Core";
    //private const string Ver = "4.6.6251";


        // If command string filled, its use takes preference.
        //if (Has(command))
        //{
        //    return $"{command} {formattedFile}";
        //}


        //AssertContains(result, result.Opt.BinLog); // Only for Build results. Already covered in other tests.
        //AssertContains(result, "build succeeded"); // MSBuild doesn't say "Build succeeded"

    /// <summary>
    /// Checks most, but notably skips checking if Args are filled in
    /// (result.Args.Args and result.Opts.Args),
    /// Because UnstallPackage can't always do guarantee it filled in.
    /// Add a call to <see cref="AssertOptsAllOnArgs"></see> to check those.
    /// </summary>

    /// <summary>
    /// Args can't be guaranteed filledin for UninstallPackage
    /// </summary>
    internal static void AssertOptsAllOnArgs(DotNetResult result)
    {
        NotNullOrWhiteSpace(result.Args.Args);
        NotNullOrWhiteSpace(result.Opt.Args);
    }

    // HACK: Update to Visual Studio 18.6.0 and 18.6.2 gave dotnet.exe perf hit.
    //static DotNetTestHelper() => SetEnvironmentVariable("MSBuildDisableFeaturesFromVersion", "18.6");

        //NotNullOrWhiteSpace(result.Opt.Args);
        //NullOrWhiteSpace(result.Args.Args);

        //NotNullOrWhiteSpace(result.Args.Args);
        //NullOrWhiteSpace(result.Opt.Args);
```