namespace JJ.Framework.Reflection.Core;
public partial class AccessorCore
{
    // NOTE: Lambda-style expression trees cannot provide a conveniently notation for ref args,
    // and type arguments are needed, because `object?` would not be a specific enough type for refs.
    
    // 1 Parameter
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg>(ref TArg arg, [Caller] string name = "")
        => Call(name, ref arg);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg>(string name, ref TArg arg)
    {
        object?[] args = [ arg ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg = (TArg)args[0]!;
        return ret;
    }
    
    // 2 Parameters
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1>(ref TArg1 arg, object? arg2, [Caller] string name = "")
        => Call(name, ref arg, arg2);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1>(string name, ref TArg1 arg1, object? arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        return ret;
    }
           
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg2>(object? arg, ref TArg2 arg2, [Caller] string name = "")
        => Call(name, arg, ref arg2);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg2>(string name, object? arg1, ref TArg2 arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TArg2)args[1]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2>(ref TArg1 arg, ref TArg2 arg2, [Caller] string name = "")
        => Call(name, arg, ref arg2);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg2>(string name, ref TArg1 arg1, ref TArg2 arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg2 = (TArg2)args[1]!;
        return ret;
    }
    
    // 3 Parameters
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1>(ref TArg1 arg1, object? arg2, object? arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1>(string name, ref TArg1 arg1, object? arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg2>(object? arg1, ref TArg2 arg2, object? arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg2>(string name, object? arg1, ref TArg2 arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TArg2)args[1]!;
        return ret;
    }
        
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2>(ref TArg1 arg1, ref TArg2 arg2, object? arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg2>(string name, ref TArg1 arg1, ref TArg2 arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg2 = (TArg2)args[1]!;
        return ret;
    }
     
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg3>(object? arg1, object? arg2, ref TArg3 arg3, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg3>(string name, object? arg1, object? arg2, ref TArg3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TArg3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg3>(ref TArg1 arg1, object? arg2, ref TArg3 arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg3>(string name, ref TArg1 arg1, object? arg2, ref TArg3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg3 = (TArg3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg2, TArg3>(object? arg1, ref TArg2 arg2, ref TArg3 arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg2, TArg3>(string name, object? arg1, ref TArg2 arg2, ref TArg3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TArg2)args[1]!;
        arg3 = (TArg3)args[2]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3>(ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg2, TArg3>(string name, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg2 = (TArg2)args[1]!;
        arg3 = (TArg3)args[2]!;
        return ret;
    }    
    
    // 4 Parameters
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1>(ref TArg1 arg1, object? arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1>(string name, ref TArg1 arg1, object? arg2, object? arg3, object? arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg2>(object? arg1, ref TArg2 arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg2>(string name, object? arg1, ref TArg2 arg2, object? arg3, object? arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TArg2)args[1]!;
        return ret;
    }
        
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2>(ref TArg1 arg1, ref TArg2 arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg2>(string name, ref TArg1 arg1, ref TArg2 arg2, object? arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg2 = (TArg2)args[1]!;
        return ret;
    }
     
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg3>(object? arg1, object? arg2, ref TArg3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg3>(string name, object? arg1, object? arg2, ref TArg3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TArg3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg3>(ref TArg1 arg1, object? arg2, ref TArg3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg3>(string name, ref TArg1 arg1, object? arg2, ref TArg3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg3 = (TArg3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg2, TArg3>(object? arg1, ref TArg2 arg2, ref TArg3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg2, TArg3>(string name, object? arg1, ref TArg2 arg2, ref TArg3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TArg2)args[1]!;
        arg3 = (TArg3)args[2]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3>(ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg2, TArg3>(string name, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg2 = (TArg2)args[1]!;
        arg3 = (TArg3)args[2]!;
        return ret;
    }    

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg4>(ref object? arg1, object? arg2, object? arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg4>(string name, ref object? arg1, object? arg2, object? arg3, ref TArg4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg4 = (TArg4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1,TArg4>(ref TArg1 arg1, object? arg2, object? arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg4>(string name, ref TArg1 arg1, object? arg2, object? arg3, ref TArg4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg4 = (TArg4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg2, TArg4>(object? arg1, ref TArg2 arg2, object? arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg2, TArg4>(string name, object? arg1, ref TArg2 arg2, object? arg3, ref TArg4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TArg2)args[1]!;
        arg4 = (TArg4)args[3]!;
        return ret;
    }
        
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg4>(ref TArg1 arg1, ref TArg2 arg2, object? arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg2, TArg4>(string name, ref TArg1 arg1, ref TArg2 arg2, object? arg3, ref TArg4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg2 = (TArg2)args[1]!;
        arg4 = (TArg4)args[3]!;
        return ret;
    }
     
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg3, TArg4>(object? arg1, object? arg2, ref TArg3 arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg3, TArg4>(string name, object? arg1, object? arg2, ref TArg3 arg3, ref TArg4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TArg3)args[2]!;
        arg4 = (TArg4)args[3]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg3, TArg4>(ref TArg1 arg1, object? arg2, ref TArg3 arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg3, TArg4>(string name, ref TArg1 arg1, object? arg2, ref TArg3 arg3, ref TArg4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg3 = (TArg3)args[2]!;
        arg4 = (TArg4)args[3]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg2, TArg3, TArg4>(object? arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg2, TArg3, TArg4>(string name, object? arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TArg2)args[1]!;
        arg3 = (TArg3)args[2]!;
        arg4 = (TArg4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TArg1, TArg2, TArg3, TArg4>(ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TArg1, TArg2, TArg3, TArg4>(string name, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TArg1)args[0]!;
        arg2 = (TArg2)args[1]!;
        arg3 = (TArg3)args[2]!;
        arg4 = (TArg4)args[3]!;
        return ret;
    }    
    
    // TODO: Add 5-argument variations
}
