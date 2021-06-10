using JJ.Framework.Reflection;
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ArrangeConstructorOrDestructorBody
// ReSharper disable ArrangeMethodOrOperatorBody
// ReSharper disable UnusedMember.Global
// ReSharper disable ArrangeTypeModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable UnusedVariable
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local
// ReSharper disable MemberCanBeMadeStatic.Global
#pragma warning disable IDE0022 // Use expression body for methods
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0060 // Remove unused parameter

namespace JJ.Demos.Accessors
{
    class MyClass
    {
        private int MyPrivateMethod(int myParameter)
        {
            return 3;
        }
    }

    class AccessorCaller
    {
        public void Demo()
        {
            var myObject = new MyClass();
            var accessor = new Accessor(myObject);
            int myInt = (int)accessor.InvokeMethod("MyPrivateMethod", 1);
        }
    }

    class MyAccessor
    {
        Accessor _accessor;

        public MyAccessor(MyClass myObject) => _accessor = new Accessor(myObject);

        public int MyPrivateMethod(int myParameter) => _accessor.InvokeMethod(() => MyPrivateMethod(myParameter));
    }

    class MyAccessorCaller
    {
        public void Demo()
        {
            var myObject = new MyClass();
            var accessor = new MyAccessor(myObject);
            int myInt = accessor.MyPrivateMethod(1);
        }
    }

}