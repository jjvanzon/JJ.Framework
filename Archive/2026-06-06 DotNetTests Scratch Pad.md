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
```