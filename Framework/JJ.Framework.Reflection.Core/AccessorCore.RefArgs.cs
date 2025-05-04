namespace JJ.Framework.Reflection.Core;
public partial class AccessorCore
{
    // NOTE: Lambda-style expression trees cannot provide a conveniently notation for ref args,
    // and type arguments are needed, because `object?` would not be a specific enough type for refs.
    
    // 1 Parameter
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef>(ref TRef arg, [Caller] string name = "")
        => Call(name, ref arg);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef>(string name, ref TRef arg)
    {
        object?[] args = [ arg ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg = (TRef)args[0]!;
        return ret;
    }
    
    // 2 Parameters
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1>(ref TRef1 arg, object? arg2, [Caller] string name = "")
        => Call(name, ref arg, arg2);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1>(string name, ref TRef1 arg1, object? arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        return ret;
    }
           
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef2>(object? arg, ref TRef2 arg2, [Caller] string name = "")
        => Call(name, arg, ref arg2);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef2>(string name, object? arg1, ref TRef2 arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef2>(ref TRef1 arg, ref TRef2 arg2, [Caller] string name = "")
        => Call(name, arg, ref arg2);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef2>(string name, ref TRef1 arg1, ref TRef2 arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        return ret;
    }
    
    // 3 Parameters
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, object? arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1>(string name, ref TRef1 arg1, object? arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, object? arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef2>(string name, object? arg1, ref TRef2 arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        return ret;
    }
        
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef2>(string name, ref TRef1 arg1, ref TRef2 arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        return ret;
    }
     
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef3>(object? arg1, object? arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef3>(string name, object? arg1, object? arg2, ref TRef3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef3>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef3>(string name, ref TRef1 arg1, object? arg2, ref TRef3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef2, TRef3>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef2, TRef3>(string name, object? arg1, ref TRef2 arg2, ref TRef3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef2, TRef3>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef2, TRef3>(string name, ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }    
    
    // 4 Parameters
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1>(string name, ref TRef1 arg1, object? arg2, object? arg3, object? arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef2>(string name, object? arg1, ref TRef2 arg2, object? arg3, object? arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        return ret;
    }
        
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef2>(string name, ref TRef1 arg1, ref TRef2 arg2, object? arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        return ret;
    }
     
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef3>(object? arg1, object? arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef3>(string name, object? arg1, object? arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef3>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef3>(string name, ref TRef1 arg1, object? arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef2, TRef3>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef2, TRef3>(string name, object? arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef2, TRef3>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef2, TRef3>(string name, ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }    

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef4>(ref object? arg1, object? arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef4>(string name, ref object? arg1, object? arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg4 = (TRef4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1,TRef4>(ref TRef1 arg1, object? arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef4>(string name, ref TRef1 arg1, object? arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef2, TRef4>(object? arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef2, TRef4>(string name, object? arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
        
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef2, TRef4>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef2, TRef4>(string name, ref TRef1 arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
     
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef3, TRef4>(object? arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, arg4);

    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef3, TRef4>(string name, object? arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TRef3)args[2]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef3, TRef4>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef3, TRef4>(string name, ref TRef1 arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg3 = (TRef3)args[2]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }

    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef2, TRef3, TRef4>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef2, TRef3, TRef4>(string name, object? arg1, ref TRef2 arg2, ref TRef3 arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_invokemethod" />
    public object? Call<TRef1, TRef2, TRef3, TRef4>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_invokemethod" />
    [OverloadPriority(1)]
    public object? Call<TRef1, TRef2, TRef3, TRef4>(string name, ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }    
    
    // TODO: Add 5-argument variations
}
