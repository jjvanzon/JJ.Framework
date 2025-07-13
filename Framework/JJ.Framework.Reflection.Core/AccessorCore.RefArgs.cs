namespace JJ.Framework.Reflection.Core;
public partial class AccessorCore
{
    // NOTE: Lambda-style expression trees not supported; they cannot provide a conveniently notation for ref args.
    // NOTE: Type arguments are needed, because `object?` would not be a specific enough type for refs.
    // NOTE: Multiple layers of Priorities are used,
    // to disambiguates explicit last string arguments from optional Caller arguments.
    // See, (arg, name?) can conflict with (arg1, arg2) which can conflict with (arg1, arg2, name?) too.
    
    // 1 Parameter
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef>(ref TRef arg, [Caller] string name = "")
        => Call(name, ref arg);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call(ref string arg, [Caller] string name = "")
        => Call(name, ref arg);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef>(string name, ref TRef arg)
    {
        object?[] args = [ arg ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg = (TRef)args[0]!;
        return ret;
    }
    
    // 2 Parameters
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, [Caller] string name = "")
        => Call(name, ref arg1, arg2);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, string arg2, [Caller] string name = "")
        => Call(name, ref arg1, arg2);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(string name, ref TRef1 arg1, object? arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        return ret;
    }
           
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, [Caller] string name = "")
        => Call(name, arg1, ref arg2);
           
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call(object? arg1, ref string arg2, [Caller] string name = "")
        => Call(name, arg1, ref arg2);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(string name, object? arg1, ref TRef2 arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, ref string arg2, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(string name, ref TRef1 arg1, ref TRef2 arg2)
    {
        object?[] args = [ arg1, arg2 ];
        object? ret = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        return ret;
    }
    
    // 3 Parameters
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, object? arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, string arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(string name, ref TRef1 arg1, object? arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, object? arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, string arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(string name, object? arg1, ref TRef2 arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        return ret;
    }
        
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3);
        
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, string arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(string name, ref TRef1 arg1, ref TRef2 arg2, object? arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        return ret;
    }
     
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3>(object? arg1, object? arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3);
     
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call(object? arg1, object? arg2, ref string arg3, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3>(string name, object? arg1, object? arg2, ref TRef3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, ref string arg3, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3>(string name, ref TRef1 arg1, object? arg2, ref TRef3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, ref string arg3, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3>(string name, object? arg1, ref TRef2 arg2, ref TRef3 arg3)
    {
        object?[] args = [ arg1, arg2, arg3 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef3>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, ref string arg3, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
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
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, object? arg3, string arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, arg4);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(string name, ref TRef1 arg1, object? arg2, object? arg3, object? arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, object? arg3, string arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(string name, object? arg1, ref TRef2 arg2, object? arg3, object? arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        return ret;
    }
        
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, arg4);
        
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, string arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, arg4);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(string name, ref TRef1 arg1, ref TRef2 arg2, object? arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        return ret;
    }
     
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3>(object? arg1, object? arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, arg4);

    // ncrunch: no coverage start

    // NOTE: Overload resolution is going over my head. Marking as no coverage. Don't know how to solve.
    // Attempts to call it appear to resolve to:
    // public object? Call(object? arg1, object? arg2, ref string arg3, [Caller] string name = "")
        
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3>(object? arg1, object? arg2, ref TRef3 arg3, string arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, arg4);

    // ncrunch: no coverage end
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3>(string name, object? arg1, object? arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, arg4);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, string? arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3>(string name, ref TRef1 arg1, object? arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }

    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, arg4);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, string arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3>(string name, object? arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef3>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef3>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, string arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef3>(string name, ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, object? arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        return ret;
    }    
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef4>(object? arg1, object? arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call(object? arg1, object? arg2, object? arg3, ref string arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef4>(string name, object? arg1, object? arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg4 = (TRef4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef4>(ref TRef1 arg1, object? arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1>(ref TRef1 arg1, object? arg2, object? arg3, ref string arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef4>(string name, ref TRef1 arg1, object? arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef4>(object? arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2>(object? arg1, ref TRef2 arg2, object? arg3, ref string arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, arg3, ref arg4);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef4>(string name, object? arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [ arg1, arg2, arg3, arg4 ];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
        
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef4>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, ref arg4);
        
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2>(ref TRef1 arg1, ref TRef2 arg2, object? arg3, ref string arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, arg3, ref arg4);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef4>(string name, ref TRef1 arg1, ref TRef2 arg2, object? arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg2 = (TRef2)args[1]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
     
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3, TRef4>(object? arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, ref arg4);
     
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3>(object? arg1, object? arg2, ref TRef3 arg3, ref string arg4, [Caller] string name = "")
        => Call(name, arg1, arg2, ref arg3, ref arg4);

    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef3, TRef4>(string name, object? arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg3 = (TRef3)args[2]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }

    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3, TRef4>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, ref arg4);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3>(ref TRef1 arg1, object? arg2, ref TRef3 arg3, ref string arg4, [Caller] string name = "")
        => Call(name, ref arg1, arg2, ref arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef3, TRef4>(string name, ref TRef1 arg1, object? arg2, ref TRef3 arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg1 = (TRef1)args[0]!;
        arg3 = (TRef3)args[2]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }

    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3, TRef4>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, ref arg4);

    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3>(object? arg1, ref TRef2 arg2, ref TRef3 arg3, ref string arg4, [Caller] string name = "")
        => Call(name, arg1, ref arg2, ref arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef2, TRef3, TRef4>(string name, object? arg1, ref TRef2 arg2, ref TRef3 arg3, ref TRef4 arg4)
    {
        object?[] args = [arg1, arg2, arg3, arg4];
        object? ret  = ResolveMethod(name, args, [ ], [ ]).Invoke(Obj, args);
        arg2 = (TRef2)args[1]!;
        arg3 = (TRef3)args[2]!;
        arg4 = (TRef4)args[3]!;
        return ret;
    }
    
    /// <inheritdoc cref="_call" />
    [Prio(1)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef3, TRef4>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, ref TRef4 arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(2)]
    [NoTrim(TypeCollection)]
    public object? Call<TRef1, TRef2, TRef3>(ref TRef1 arg1, ref TRef2 arg2, ref TRef3 arg3, ref string arg4, [Caller] string name = "")
        => Call(name, ref arg1, ref arg2, ref arg3, ref arg4);
    
    /// <inheritdoc cref="_call" />
    [Prio(3)]
    [NoTrim(TypeCollection)]
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
}
