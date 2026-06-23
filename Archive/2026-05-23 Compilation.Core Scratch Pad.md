Compilation.Core Scratch Pad
============================

```xml
            <!--<OutputType>Exe</OutputType>-->
```

```cs
    //private  const    string PROGRAM_CONTENT = "Console.WriteLine(\"hello\");";

        // HACK: Temporarily prevent .NET 4x failure.
        //if (targetFramework.StartsWith("net4"))
        //{
        //    targetFramework = "net8.0";
        //}

        //WriteAllText(Path.Combine(TempDir, "Program.cs"), PROGRAM_CONTENT);


        // Do not run this logic. It may bring down the whole tool stack.
        return;
        // ReSharper disable HeuristicUnreachableCode
        // ReSharper restore HeuristicUnreachableCode
```

```xml

    <!--
    Visual Studio:
    will run a trimmed build for a whole stretch of framework versions,
    and run the trim tests. This happens upon release build, but not the debug build.
    -->

    <!--
    NCrunch:
    Can't handle the churn. Only trim for a single .NET version.
    NCrunch forces us to specify it explicitly in each project,
    because it ignores this condition centrally in Directory.Build.props,
    -->
    
    <!--
    All these run-time dotnet.exe calls are too much for NCrunch,
    so RUNNING the TrimTests is disabled here. -->
    <!--<AutoTrimTest Condition="$(IsNCrunch)">False</AutoTrimTest>-->
    
    <!-- 
    Azure Pipelines will always run auto-trim test. 
    To compensate NCrunch's not doing so. -->
    <!--<AutoTrimTest Condition="$(IsAzurePipelines)">True</AutoTrimTest>-->
```

```cs
        //public string DebuggerDisplay() => DotNetResultFormatter.DebuggerDisplay(result);

        //public string DebuggerDisplay() 
        //    => (string)_accessor.Call(Name(), result)!;

    //[NoTrim("DebuggerDisplay",    $"{MainAsm}.Formatters.DotNetResultFormatterExtensions", MainAsm)]
        //AreEqual(expectedDebuggerDisplay, result.DebuggerDisplay());

    // (Test disabled for now, for it might impact entire tooling perf.)

        //if (argPropsDescriptor.Has(args.ID))
        //{
        //    idVerDescriptor = idVerDescriptor.Replace(args.ID, "").TrimStart();
        //}
        //if (argPropsDescriptor.Has(args.Ver))
        //{
        //    idVerDescriptor = idVerDescriptor.Replace(args.Ver, "").TrimEnd();
        //}

        //if (argPropsDescriptor.StartsWith(commandDescriptor, OrdinalIgnoreCase))
        //{
        //    commandDescriptor = "";
        //}

        //if (argPropsDescriptor.StartsWith(args.Command, OrdinalIgnoreCase))
        //{
        //    commandDescriptor = commandDescriptor.CutRight(args.Command).CutRight(" / ");
        //}

```

```xml
    <AutoTrimTest Condition="$(IsNCrunch)">False</AutoTrimTest>
    <AutoTrimTest Condition="$(IsAzurePipelines)">True</AutoTrimTest>
    <!--<AutoTrimTest>True</AutoTrimTest>-->
    <!--<AutoTrimTest>False</AutoTrimTest>-->
    <!--<AutoPublish>True</AutoPublish>-->
```