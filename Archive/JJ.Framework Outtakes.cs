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


ReflectionCache (2021-06-21):

    private MethodInfo TryResolveGenericMethod(Type type, string name, Type[] parameterTypes, Type[] typeArguments)
    {
        IList<MethodInfo> methods = GetMethods(type);
        
        if (methods.Count == 0)
        {
            throw new Exception($"Type {type} appears to have no methods");
        }

        methods = methods.Where(x => string.Equals(x.Name, name)).ToArray();
        
        if (methods.Count == 0)
        {
            throw new Exception($"Type {type} appears to have no method with name {name}");
        }

        methods = methods.Where(x => x.GetParameters()
                                        .Select(y => y.ParameterType)
                                        .SequenceEqual(parameterTypes))
                            .ToArray();

        switch (methods.Count)
        {
            case 0:
                throw new Exception($"Type {type} appears to have no method with name {name} and " +
                                    $"parameter types {string.Join(", ", parameterTypes.Select(x => $"{x.Name}"))}.");
            case 1:
                break;

            default:
                throw new Exception($"Type {type} appears to have multiple methods with name {name} and " +
                                    $"parameter types {string.Join(", ", parameterTypes.Select(x => $"{x.Name}"))}.");
        }


        MethodInfo openGenericMethod = methods[0];
        MethodInfo closedGenericMethod = openGenericMethod.MakeGenericMethod(typeArguments);
        return closedGenericMethod;
    }


Encoding_PlatformSafe_Tests (2021-06-24):

    [TestMethod]
    public void Test_Encoding_GetString_PlatformSafe()
    {
        // Arrange
        string expectedText = "Test text";
        byte[] bytes = StreamHelper.StringToBytes(expectedText, Encoding.UTF8, includeByteOrderMark: false);

        // Act
        string actualText = Encoding.UTF8.GetString_PlatformSafe(bytes);
        string textFromDotNet = Encoding.UTF8.GetString(bytes);

        // Assert
        AssertHelper.AreEqual(expectedText, () => actualText);
        AssertHelper.AreEqual(expectedText, () => textFromDotNet);
    }

StringExtensions_Split (2021-07-17):

    public static IList<string> SplitWithQuotation(this string input, string separator, StringSplitOptions options, char? quote)
    {
        IList<string> values = SplitWithQuotation_WithoutUnescape(input, separator, options, quote);

        if (quote.HasValue)
        {
            values = values.Select(x => x.Trim(quote.Value).Replace($"{quote}{quote}", $"{quote}")).ToArray();
        }

        return values;
    }

    private static IList<string> SplitWithQuotation_WithoutUnescape(
        this string input,
        string separator,
        StringSplitOptions options,
        char? quote)
    {
        if (!quote.HasValue)
        {
            return input.Split(separator, options);
        }

        if (string.IsNullOrEmpty(separator))
        {
            throw new ArgumentNullException(nameof(separator));
        }

        if (string.IsNullOrEmpty(input))
        {
            return new string[0];
        }

        IList<string> values = new List<string>();

        var inQuote = false;
        var startPos = 0;

        int forEnd = input.Length - separator.Length;

        for (var pos = 0; pos <= forEnd; pos++)
        {
            char chr = input[pos];

            // Handle quotation
            if (chr == quote.Value)
            {
                inQuote = !inQuote;
            }

            if (inQuote)
            {
                continue;
            }

            // Detect separator
            if (input.Substring(pos, separator.Length) == separator)
            {
                // An end-of-element was found.
                string value = input.FromTill(startPos, pos - 1);

                if (!string.IsNullOrEmpty(value) || options != StringSplitOptions.RemoveEmptyEntries)
                {
                    values.Add(value);
                }

                // Next element is starting.
                startPos = pos + separator.Length;
            }
        }

        // Add last element
        // (For the previous elements, the separator functions as an end-of-value, while the last value does hot have that.)
        string str2 = input.FromTill(startPos, input.Length - 1);
        if (!string.IsNullOrEmpty(str2) || options != StringSplitOptions.RemoveEmptyEntries)
        {
            values.Add(str2);
        }

        return values;
    }
