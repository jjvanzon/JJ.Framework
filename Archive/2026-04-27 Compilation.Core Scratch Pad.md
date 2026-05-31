
```cs
    public static implicit operator DotNetArgs?([NotNullIfNotNull(nameof(accessor))] DotNetArgsAccessor? accessor) => accessor?.Obj;

    //public static implicit operator DotNetResult?([System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute(nameof(accessor))] DotNetResultAccessor? accessor) => accessor?.Obj;
    public static implicit operator DotNetResult?([NotNullIfNotNull(nameof(accessor))] DotNetResultAccessor? accessor) => accessor?.Obj;

    //public static bool Has     (     DotNetArgs?    args) => FilledIn(args);
    //public static bool Has     (     DotNetOptions? opt ) => FilledIn(opt);
    //public static bool IsNully (     DotNetArgs?    args) => !FilledIn(args);
    //public static bool IsNully (     DotNetOptions? opt ) => !FilledIn(opt);

    //private const string DotNetArgsNull = "<null>";

        //string argsPart = $"{Descriptor(result.Args)}{sep}{Descriptor(result.Opt)}";


        // TODO: For a realistic example:
        // [error] would be is somewhere in the middle of the output.
        // A command line would be expected between "ERROR!" and "Output:".


        /*
        AreEqual(expectedLongForm, result.Text);
        AreEqual(expectedLongForm, result.ToString());
        AreEqual(expectedLongForm, result);
        AreEqual(expectedLongForm, Descriptor(result));
        AreEqual(expectedLongForm, Stringify(result));
        AreEqual(expectedWideForm, ExceptionMessage(result));
        AreEqual(expectedWideForm, DebuggerDisplay(result));
        */


        AreEqual(expected, result.Text);
        AreEqual(expected, result.ToString());
        AreEqual(expected, result);
        AreEqual(expected, Descriptor(result));
        AreEqual(expected, Stringify(result));
        AreEqual(expected, ExceptionMessage(result));
        AreEqual(expected, DebuggerDisplay(result));

    [TestMethod] 
    public void DotNetResult_Empty()
    {
        AreEqual("DotNetResult empty", EmptyResult);
        AreEqual("DotNetResult empty", EmptyResult.Text);
        AreEqual("DotNetResult empty", EmptyResult.ToString());
        AreEqual("DotNetResult empty", Descriptor(EmptyResult));
        AreEqual("DotNetResult empty", Stringify(EmptyResult));
        AreEqual("DotNetResult empty", ExceptionMessage(EmptyResult));
        AreEqual("DotNetResult empty", DebuggerDisplay(EmptyResult));
    }

    [TestMethod]
    public void DotNetResult_Null()
    {
        AreEqual("DotNetResult null", NullResult);
        AreEqual("DotNetResult null", Descriptor(NullResult));
        AreEqual("DotNetResult null", Stringify(NullResult));
        AreEqual("DotNetResult null", ExceptionMessage(NullResult));
        AreEqual("DotNetResult null", DebuggerDisplay(NullResult));
    }


    [TestMethod]
    public void DotNetResultFormatter_ExceptionMessage_Success_UsesSingleLineSeparator()
    {
        var args = new DotNetArgsAccessor(build)
        { 
            Args = "--no-logo", 
            FullArgs = "build MyProject.csproj --no-logo" 
        }.Obj;

        var opt = new DotNetOptions
        {
            Dir = @"C:\repo", 
            File = "MyProject.csproj"
        };

        var result = new DotNetResultAccessor(
            opt,
            args,
            outputText: "Build succeeded.").Obj;

        const string expected =
            @"dotnet build MyProject.csproj --no-logo | MyProject.csproj | Dir = C:\repo | Output: Build succeeded.";

        AreEqual(expected, ExceptionMessage(result));
    }


    [TestMethod]
    public void DotNetResult_DebuggerDisplay_EqualsText()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var resultAccessor = new DotNetResultAccessor(
            default,
            args,
            outputText: "Build succeeded.");

        DotNetResult result = resultAccessor.Obj;

        // TODO: No longer the case. Add prefix?
        //AreEqual(result.Text, resultAccessor.DebuggerDisplay);
    }

    private static readonly DotNetArgs DefaultArgs = new DotNetArgsAccessor().Obj;

    
    [TestMethod] public void Test_DotNetResult_Stringify_UsesNewLines() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_ExceptionMessage_UsesSpaceSeparator() => throw new NotImplementedException();


        AreEqual(DEFAULT_DESCRIPTOR, Descriptor(new DotNetOptions { Log = null!,     Verbosity = Normal }));
        AreEqual(DEFAULT_DESCRIPTOR, Descriptor(new DotNetOptions { Log = NullLog,   Verbosity = Normal }));

            AreEqual("Log", Descriptor(new DotNetOptions { Log = WriteLine                      }));
            AreEqual("Log", Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Normal  }));
            AreEqual("Log", Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = default }));
            AreEqual("Log", Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = 0       }));
            AreEqual("Log", Descriptor(new DotNetOptions { Log = _ => { }                       }));
            AreEqual("Log", Descriptor(new DotNetOptions { Log = _ => { },  Verbosity = Normal  }));
            AreEqual("Log", Descriptor(new DotNetOptions { Log = _ => { },  Verbosity = default }));
            AreEqual("Log", Descriptor(new DotNetOptions { Log = _ => { },  Verbosity = 0       }));

        AreEqual("Log",            Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = 0         }            ));
        AreEqual("Log",                       new DotNetOptions { Log = WriteLine, Verbosity = 0         }.Descriptor());
        AreEqual("Log",            Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = default   }            ));
        AreEqual("Log",                       new DotNetOptions { Log = WriteLine, Verbosity = default   }.Descriptor());
        AreEqual("Log",            Descriptor(new DotNetOptions { Log = WriteLine, Verbosity = Normal    }            ));
        AreEqual("Log",                       new DotNetOptions { Log = WriteLine, Verbosity = Normal    }.Descriptor());

        // params string[] expectedElements)
        //string expectedWideForm = Join(" | ", expectedElements);
        //string expectedLongForm = Join(NewLine, expectedElements);
        // TODO: Account for quote and slash styles.

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_UsesSingleQuotesAndForwardSlashes()
    {
        AssertDiagnosticTexts(
            new DotNetOptions
            {
                BuildConf = "Release",
                File = @"C:\Code\MyProject.csproj",
                Args = "--no-logo",
                Dir = @"C:\Code"
            },
            """'Release' | --no-logo | C:/Code/MyProject.csproj | Dir = C:/Code""");
    }

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_PathTruncation()
    {
        AssertDiagnosticTexts(
            new DotNetOptions
            {
                Args = "--no-logo",
                File = @"D:\Repos\JJ.Framework\src\Apps\Billing\Billing.Service.Api.csproj",
                Dir = @"D:\Repos\JJ.Framework\src\Apps\Billing\ServiceHost\bin\Release\net10.0"
            },
            @"--no-logo | ... /Apps/Billing/Billing.Service.Api.csproj | Dir = ... /Billing/ServiceHost/bin/Release/net10.0");
    }

    // TODO: Test all variants with same parameterization in one test method.

    // TODO: Here the distinction between static/extension invocation still needs to be programmed out.
    // TODO: Perhaps it is time for a helper method that checks both syntaxes given a DotNetOptions and expected text.

        // TODO: Accound for path truncation styles.

    [TestMethod]
    public void DotNetOptions_DebuggerDisplay_Default()
    {
        var expected = "{DotNetOptions default}";
        foreach (var nully in _optNullies)
        {
            AreEqual(expected, DebuggerDisplay(nully));
            AreEqual(expected, nully.DebuggerDisplay());
        }
    }
    
    // TODO: Replace AreEqual with AssertDiagnosticText.

    private static readonly DotNetOptions[] _optNullies = [ DefaultOptions, default ];

    [TestMethod]
    public void DotNetOptionsFormatter_Default()
    {
        foreach (var nully in _optNullies)
        {
            AssertDiagnosticTexts(nully, DEFAULT_DESCRIPTOR);
        }
    }


    [TestMethod]
    public void DotNetArgs_DebuggerDisplay_NullArgs()
    {
        AssertDiagnosticTexts(null, "<null>");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_NullArgs()
    {
        AssertDiagnosticTexts(null, "<null>");
    }


    [TestMethod]
    public void DotNetArgs_DebuggerDisplay()
    {
        var args = new DotNetArgsAccessor(build);

        args.Args = 
            """
            --o "C:\Temp\out"
            """;

        AssertDiagnosticTexts(
            args.Obj,
            """
            build | --o "C:\Temp\out"
            """,
            """
            DotNetArgs build | --o "C:\Temp\out"
            """,
            """
            {DotNetArgs build | --o 'C:/Temp/out'}
            """);
    }

        AssertDiagnosticTexts(
            args.Obj,
            """
            build | --o "C:\Temp\out"
            """
            //,
            //"""
            //DotNetArgs build | --o "C:\Temp\out"
            //"""
            );

    // TODO: Use AssertDiagnosticTexts helper to conjointly test Stringify, DebuggerDisplay, Descriptor, ToString.


```

```xml
    <!--<AutoTrimTest Condition="!$(IsNCrunch)">True</AutoTrimTest>-->
```

```cs
        // HACK: Azure Pipelines TestRunner hates specific frameworks here.
        if (IsAzurePipelines)
        {
           targetFramework = "net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net48;net462;net461";
        }
```