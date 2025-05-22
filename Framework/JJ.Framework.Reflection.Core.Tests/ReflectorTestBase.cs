namespace JJ.Framework.Reflection.Core.Tests;

public abstract class ReflectorTestBase
{
    protected Type _myType = typeof(MyType);
    protected Type _myBase = typeof(MyBase);
    protected MyType _obj = new();
    protected MyType _myObject = new();

    private static readonly BindingFlags _staticBindingFlags   = BindingFlagsAll.ClearFlag(Instance    );
    private static readonly BindingFlags _instanceBindingFlags = BindingFlagsAll.ClearFlag(Static      );
    private static readonly BindingFlags _baselessBindingFlags = BindingFlagsAll.SetFlag  (DeclaredOnly);

    // Constructors

    protected Reflector[] _reflectors =
    [
        new (                                            ),
        new (matchcase: false                            ),
        new (matchcase: false,     BindingFlagsAll       ),
        new (BindingFlagsAll                             ),
        new (BindingFlagsAll,      matchcase: false      )
    ];
        
    protected Reflector[] _reflectorsMatchCase =
    [
        new (matchcase                                   ),
        new (matchcase: true                             ),
        new (matchcase,             BindingFlagsAll      ),
        new (matchcase: true,       BindingFlagsAll      ),
        new (BindingFlagsAll,       matchcase            ),
        new (BindingFlagsAll,       matchcase: true      )
    ];

    protected Reflector[] _reflectorsStatic =
    [
        new (matchcase: false,      _staticBindingFlags  ),
        new (_staticBindingFlags                         ),
        new (_staticBindingFlags,   matchcase: false     )
    ];

    protected Reflector[] _reflectorsInstance =
    [
        new (matchcase: false,      _instanceBindingFlags),
        new (_instanceBindingFlags                       ),
        new (_instanceBindingFlags, matchcase: false     )
    ];

    protected Reflector[] _baselessReflectors =
    [
        new (matchcase: false,      _baselessBindingFlags),
        new (_baselessBindingFlags                       ),
        new (_baselessBindingFlags, matchcase: false     )
    ];
    
    protected void ThrowsNotFound(Func<object?> func)
    {
        ThrowsExceptionContaining(func, "not found");
    }
    
    protected class MyType : MyBase
    {
        public string MyProp => GetType().Prop().Name; // TODO: Assert value.
        public string _myField = Field<MyType>().Name; // TODO: Assert value.
        
        public static int MyStaticProp { get; }
    }
    
    protected class MyBase
    {
        public int MyBaseProp => default;
        public int _myBaseField;
        
        public static int MyStaticBaseProp { get; }
    }
}
