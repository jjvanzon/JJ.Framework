
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
```
