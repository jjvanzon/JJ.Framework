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