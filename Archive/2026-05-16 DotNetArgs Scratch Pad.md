Compilation.Core DotNetArgs Scratch Pad
=======================================

`DotNetArgsAccessor`
--------------------

```cs
    private const string TYPE_NAME_SHORT = "DotNetArgs";

    public DotNetArgsAccessor() 
        : base(typeof(DotNetArgs)) { }

    public DotNetArgsAccessor(string command)
        : base(typeof(DotNetArgs), command) { }

    public DotNetCommandEnum CommandEnum
    {
        get => Get<DotNetCommandEnum>();
        set => Set(value);
    }

    public string Command
    {
        get => Get<string>()!;
        set => Set(value);
    }

    public string ID
    {
        get => Get<string>()!;
        set => Set(value);
    }

    public string Ver
    {
        get => Get<string>()!;
        set => Set(value);
    }

    public bool IsRebuild
    {
        get => Get<bool>();
        set => Set(value);
    }
```

`Untrimmer`
-----------

```cs
    [NoTrim(AllCtors,      $"{MainAsm}.DotNetArgs",       MainAsm)]
    [NoTrim("Command",     $"{MainAsm}.DotNetArgs",       MainAsm)]
    [NoTrim("CommandEnum", $"{MainAsm}.DotNetArgs",       MainAsm)]
    [NoTrim("IsRebuild",   $"{MainAsm}.DotNetArgs",       MainAsm)]
    [NoTrim("ID",          $"{MainAsm}.DotNetArgs",       MainAsm)]
    [NoTrim("Ver",         $"{MainAsm}.DotNetArgs",       MainAsm)]
```