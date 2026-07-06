namespace JJ.Framework.Business.Legacy.Tests.Helpers;

internal static class DiagnosticsFormatterAccessor
{
    // Legacy Accessor can't resolve well for null-valued parameters.
    // So we use legacy ReflectionCache instead, which also needs explicit aprameter types.
    // (Newer AccessorCore is more convienient, but cannot be used for port-back reasons.)

    [return:Dyn(AllMethods)]
    private static Type GetReflectedType()
    {
        const string typeString = "JJ.Framework.Business.Legacy.DiagnosticsFormatter, " +
                                  "JJ.Framework.Business.Legacy";
       
        var type = Type.GetType(typeString);
        if (type == null)
        {
            throw new Exception("Type not found: " + typeString);
        }
        return type;
    }

    private static readonly MethodInfo _method 
        = StaticReflectionCache.GetMethod(
            GetReflectedType(), 
            nameof(ExceptionMessage), 
            typeof(IResult));

    public static string ExceptionMessage(IResult? result) 
        => (string)_method.Invoke(null, [ result ])!;
}
