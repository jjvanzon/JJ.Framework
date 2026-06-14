

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
```