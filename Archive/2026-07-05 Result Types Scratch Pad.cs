Result Types Scratch Pad
========================

```cs
        // As IList
        {
            IList<string> messages = new string[] { "Hi", "Hello" };
            new Result ( messages );
            new Result { Messages = messages };
            var result = new Result();
            result.Messages = messages;
        }

        // Data is not a constructor argument in this Result type implementation.

    //public override string ToString() => DebuggerDisplay(this);

    //public static string DebuggerDisplay<T>(Result<T> result) => DebuggerDisplay((IResult) result);
        //var typeName = GetPrettyTypeName(type);

    //private static string GetPrettyTypeName(Type? type)
    //{
    //    string str = type?.FullName ?? "";
    //    return str.Substring(0, str.IndexOf(",", Ordinal));
    //}


    // TODO: Reuse more?

    //private static void AssertDefault(IResult result)
    //{
    //    IsTrue(result.Success);
    //    NotNull(result.Messages);
    //    AreEqual(0, result.Messages.Count);
    //}
```

Accssors / Untrimming:

```cs
//[Suppress("Trimmer", "IL2026", Justification = GetTypes)] // Assembly.GetType used (GetTypes = closest NoTrimReason).

    //private static Accessor _accessor = new(_type);

    //public static string ExceptionMessage(IResult? result) 
    //    => 

    //public static string ExceptionMessage(IResult? result) 
    //    => 

    //, [ typeof(IResult) ]
    // These all didn't work either:
    // private static Accessor _accessor = new(_type);
    // => (string)_accessor.InvokeMethod(nameof(ExceptionMessage), result);
    // => (string)_accessor.InvokeMethod(() => ExceptionMessage(result));
    // var reflectionCache = new ReflectionCache(ReflectionHelper.BINDING_FLAGS_ALL); // Doesn't have GetMethod.

        //=> typeof(Result).Assembly.GetType("JJ.Framework.Business.Legacy.DiagnosticsFormatter") ??

    //[NoTrim(AllMethods, $"{MainAsm}.DiagnosticsFormatter", MainAsm)]

```