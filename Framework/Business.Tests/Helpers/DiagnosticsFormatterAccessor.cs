namespace JJ.Framework.Business.Tests.Helpers;

internal static class DiagnosticsFormatterAccessor
{
    // Legacy Accessor can't resolve well for null-valued parameters.
    // So we use legacy ReflectionCache instead, which also needs explicit aprameter types.
    // (Newer AccessorCore is more convienient, but cannot be used for port-back reasons.)

    private static readonly ReflectionCache _reflectionCache = new(BINDING_FLAGS_ALL);

    //[Dyn(AllMethods)]
    private static readonly Type _type = GetReflectedType();

    //[return:Dyn(AllMethods)]
    private static Type GetReflectedType()
    {
        const string typeString = "JJ.Framework.Business.Helpers.DiagnosticsFormatter, " +
                                  "JJ.Framework.Business";
       
        var type = Type.GetType(typeString);
        if (type == null) throw new Exception("Type not found: " + typeString);
        return type;
    }

    public static string ExceptionMessage(IResult? result) 
        => (string)_reflectionCache.GetMethod(_type, nameof(ExceptionMessage), typeof(IResult)).Invoke(null, [ result ])!;

    public static string Stringify(IResult? result) 
        => (string)_reflectionCache.GetMethod(_type, nameof(Stringify), typeof(IResult)).Invoke(null, [ result ])!;

    public static string DebuggerDisplay(IResult? result) 
        => (string)_reflectionCache.GetMethod(_type, nameof(DebuggerDisplay), typeof(IResult)).Invoke(null, [ result ])!;
}
