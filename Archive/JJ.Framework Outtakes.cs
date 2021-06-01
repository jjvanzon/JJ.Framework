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
