```cs

    private void Assert(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();
        var result = call();
        AssertResult(result);
    }

        //BasicOpt = CreateBasicOpt();

    // TODO: Make helper for checking with all opt, because there's lots of repetition compared to BuildTests.
    
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