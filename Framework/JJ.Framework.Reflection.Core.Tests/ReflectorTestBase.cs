namespace JJ.Framework.Reflection.Core.Tests;

public abstract class ReflectorTestBase
{
    protected Type _myType = typeof(MyType);
    protected Type _myBase = typeof(MyBase);

    // Constructors

    protected Reflector[] _reflectors =
    [
        new (                                  ),
        new (matchcase: false                  ),
        new (matchcase: false, BindingFlagsAll ),
        new (BindingFlagsAll                   ),
        new (BindingFlagsAll,  matchcase: false)
    ];
    
    protected Reflector[] _reflectorsMatchCase =
    [
        new (matchcase                       ),
        new (matchcase: true                 ),
        new (matchcase,       BindingFlagsAll),
        new (matchcase: true, BindingFlagsAll),
        new (BindingFlagsAll, matchcase      ),
        new (BindingFlagsAll, matchcase: true)
    ];
    
    protected void ThrowsNotFound(Func<object?> func)
    {
        ThrowsExceptionContaining(func, "not found");
    }
    
    protected class MyType : MyBase
    {
        public string MyProp => GetType().Prop().Name; // TODO: Assert value.
    }
    
    protected class MyBase
    {
        public int MyBaseProp => default;
    }
}
