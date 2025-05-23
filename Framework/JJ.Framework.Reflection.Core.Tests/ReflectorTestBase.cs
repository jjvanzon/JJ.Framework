namespace JJ.Framework.Reflection.Core.Tests;

public abstract class ReflectorTestBase
{
    protected Type _myType = typeof(MyType);
    protected Type _myBase = typeof(MyBase);
    protected MyType _obj = new();
    protected MyType _myObject = new();

    private static readonly BindingFlags _staticBindingFlags     = BindingFlagsAll.ClearFlag(Instance    );
    private static readonly BindingFlags _bindingFlagsMatchCase  = BindingFlagsAll.ClearFlag(IgnoreCase  );
    private static readonly BindingFlags _instanceBindingFlags   = BindingFlagsAll.ClearFlag(Static      );
    private static readonly BindingFlags _baselessBindingFlags   = BindingFlagsAll.SetFlag  (DeclaredOnly);

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
        new (BindingFlagsAll,       matchcase: true      ),
        new (_bindingFlagsMatchCase                      )
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
        public           string       MyProp            => "";
        private          string      _myField           =  "";
        protected static int?         MyStaticProp      => default;
        private   static int?        _myStaticField;
        public           string       Method0(     )    => "Method0";
        public           int          Method1(int i)    => i;
    }
    
    protected class MyBase
    {
        private          bool         MyBaseProp        => default;
        public           bool        _myBaseField;
        internal  static CultureInfo  MyStaticBaseProp  => GetCultureInfo("en-US");
        protected static CultureInfo _myStaticBaseField =  GetCultureInfo("nl-NL");
    }
}
