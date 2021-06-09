DoubleHelper_Accessor (2021-06-01):

    // Old

    private static readonly PrivateType _privateType = new PrivateType(typeof(DoubleHelper));

    private static bool TryParseOld(string s, IFormatProvider provider, out double result)
    {
        object[] args = { s, provider, null };
        bool success = (bool)_privateType.InvokeStatic(nameof(TryParse), args);
        result = (double)args[2];
        return success;
    }


Accessor (2021-06-01):

    /// <summary> (1st arg is out) </summary>
    public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, TArg2 arg2, TArg3 arg3)
    {
        arg1 = default;

        MethodInfo method = StaticReflectionCache.GetMethod<TArg1, TArg2, TArg3>(_objectType, name);
        object[] parameters = { arg1, arg2, arg3 };
        var returnValue = (TRet)method.Invoke(_object, parameters);

        arg1 = (TArg1)parameters[0];

        return returnValue;
    }

    // Inferring types for non-out parameters.
    // Pro: Cleaner call syntax?
    // Con: More code..
    // Con: When null, argument might not be inferrable either way.
    // Con: C# might once have syntax for partial type inference. (https://github.com/dotnet/csharplang/issues/1349)

    public TRet InvokeMethod<TRet, TOut>(string name, object arg1, object arg2, out TOut arg3)
    {
        Type[] parameterTypes = ReflectionHelper.TypesFromObjects(arg1, arg2, null);

        parameterTypes[2] = typeof(TOut);

        MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
        object[] parameters = { arg1, arg2, null };
        var returnValue = (TRet)method.Invoke(_object, parameters);

        arg3 = (TOut)parameters[2];

        return returnValue;
    }


StaticReflectionCacheTests (2021-06-01):

    [TestMethod]
    public void Bug_StaticReflectionCache_MethodNotFound_Fails_ThreeParameters_OfWhichOnOutParameter()
    {
        Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
        const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_ThreeParameters_OfWhichOnOutParameter);
        string expectedMessage = $"Method '{methodName}' not found.";

        AssertHelper.ThrowsException(
            () => StaticReflectionCache.GetMethod<string, IFormatProvider, double>(type, methodName),
            expectedMessage);
    }


    [TestMethod]
    public void Bug_StaticReflectionCache_MethodNotFound_Succeeds_ThreeParameters_NoOutParameter()
    {
        Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
        const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_ThreeParameters_NoOutParameter);

        StaticReflectionCache.GetMethod<string, IFormatProvider, int>(type, methodName);
    }


StaticReflectionCacheTests_BugMethodNotFound (2021-06-01):

    public static bool Method_ThreeParameters_OfWhichOnOutParameter(string s, IFormatProvider provider, out double result)
        => throw new NotSupportedException();

    public static bool Method_ThreeParameters_NoOutParameter(string s, IFormatProvider provider, int result)
        => throw new NotSupportedException();


AccessorTests_OutParameters (2021-06-03):

    private static string FormatDateTime(DateTime dateTime) => $"{dateTime:yyyy-MM-dd}";

ExceptionHelper (2021-06-08):

    public static bool HasExceptionOrInnerExceptionsOfType<T>(Exception ex, string message)
    {
        var exceptions = ex.SelfAndAncestors(x => x.InnerException).ToArray();

        foreach (Exception ex2 in exceptions)
        {

            if (ex2.GetType() == typeof(T) &&
                string.Equals(ex2.Message, message))
            {
                return true;
            }

        }
        return false;
    }


EnumHelper_Obsolete_Tests (2021-06-08):

    /*
    AssertHelper.ThrowsExceptionOrInnerException<NotSupportedException>();
    try
    {
        EnumHelper_Obsolete_Accessor.Parse<object>("");
    }
    catch (Exception ex)
    {
        bool exceptionOrInnerExceptionIsMatch = ExceptionHelper.HasExceptionOrInnerExceptionsOfType<NotSupportedException>(ex, "Use JJ.Framework.Conversion.EnumParser.Parse instead.");

        if (!exceptionOrInnerExceptionIsMatch)
        {
            throw new Exception();
        }
    }*/