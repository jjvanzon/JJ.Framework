

```cs
    private static DotNetArgs NewDotNetArgs() => new DotNetArgsAccessor().Obj;

    [TestMethod]
    public void Test_DotNetArgs_Nully_CommandEnum0() 
        => AssertNully(new DotNetArgsAccessor { CommandEnum = 0 }.Obj);

    private static readonly DotNetCommandEnum[] _enumNullies = [ 0, default, undefined ];


```