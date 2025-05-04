namespace JJ.Framework.Reflection.Core;
public partial class AccessorCore
{
    // 1 Parameter

    // TODO: Pilot one with expression trees
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg>(ref TArg arg, [Caller] string name = "")
        => Call(name, ref arg);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg>(string name, ref TArg arg)
    {
        object?[] args = [ arg ];
        var ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg = (TArg)args[0]!;
        return ret;
    }
}
