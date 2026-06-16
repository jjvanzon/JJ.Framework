

```cs
    private static DotNetArgs NewDotNetArgs() => new DotNetArgsAccessor().Obj;

    [TestMethod]
    public void Test_DotNetArgs_Nully_CommandEnum0() 
        => AssertNully(new DotNetArgsAccessor { CommandEnum = 0 }.Obj);

    private static readonly DotNetCommandEnum[] _enumNullies = [ 0, default, undefined ];



    [TestMethod]
    public void Test_DotNetArgs_Nully_IsRebuildFalse() 
        => AssertNully(new DotNetArgsAccessor { IsRebuild = false }.Obj);

    [TestMethod]
    public void Test_DotNetArgs_Nully_CommandEnum()
    {
        foreach (var nully in NullyCommandEnums)
        {
            AssertNully(new DotNetArgsAccessor { CommandEnum = nully }.Obj);
        }
    }


        //return opt.HasValue && 
        //       opt.Value != default && 
        //       opt.Value != DefaultOptions;


    //private static bool HasDefaults(DotNetOptions opt)
    //    =>!Has(opt.Dir) &&



    // Every constructor argument made optional, for better overview in the tests.
    
    // TODO: Optional arg handling sort of belongs in a MockFactory or something, instead of in the Accessor.

    //private static DotNetResult NewResult(DotNetArgsAccessor args) => Mocks.NewResult(args);
    //private static DotNetResult NewResult(DotNetOptions opt) => Mocks.NewResult(opt);
    //private static DotNetResult NewResult(DotNetOptions opt, DotNetArgsAccessor args) => Mocks.NewResult(opt, args);

        // TODO: Test with the 4 other result constructor arguments.
        //AssertFilled(FilledResult(exitCode: NullyExitCode));
        //AssertFilled(FilledResult(errorText: NullyErrorText));
        //AssertFilled(FilledResult(outputText: NullyOutputText));
        //AssertFilled(FilledResult(hasTimeOut: NullyTimeOut));
     
        // TODO: Was expecting failure, since result's own fields aren't used, just arg and opt..

    // TODO: AllFilled test so that case isn't dependent on the grand "all combos" loop.
```