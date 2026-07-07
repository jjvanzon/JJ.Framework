namespace JJ.Framework.Business.Legacy.Tests.Helpers;

internal static class DiagnosticsFormatterAccessor
{
    // Legacy Accessor can't resolve well for null-valued parameters.
    // So we use legacy ReflectionCache instead, which also needs explicit aprameter types.
    // (Newer AccessorCore is more convienient, but cannot be used for port-back reasons.)

    [Dyn(AllMethods)]
    private static readonly Type _type = GetReflectedType();

    [return:Dyn(AllMethods)]
    private static Type GetReflectedType()
    {
        const string typeString = "JJ.Framework.Business.Legacy.DiagnosticsFormatter, " +
                                  "JJ.Framework.Business.Legacy";
       
        var type = Type.GetType(typeString);
        if (type == null) throw new Exception("Type not found: " + typeString);
        return type;
    }
    
    private static MethodInfo GetMethod(string name)
        => StaticReflectionCache.GetMethod(_type, name, typeof(IResult));

    private static readonly MethodInfo _exceptionMessageMethod = GetMethod(nameof(ExceptionMessage));

    public static string ExceptionMessage(IResult? result) 
        => (string)_exceptionMessageMethod.Invoke(null, [ result ])!;

    private static readonly MethodInfo _stringifyMethod = GetMethod(nameof(Stringify));

    public static string Stringify(IResult? result) 
        => (string)_stringifyMethod.Invoke(null, [ result ])!;
    
    private static readonly MethodInfo _debuggerDisplayMethod = GetMethod(nameof(DebuggerDisplay)); 

    public static string DebuggerDisplay(IResult? result) 
        => (string)_debuggerDisplayMethod.Invoke(null, [ result ])!;
}
