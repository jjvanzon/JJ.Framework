using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class MyClassAccessor_UsingExpressions : MyClassAccessorBase
    {
        private static Accessor _staticAccessor;

        public MyClassAccessor_UsingExpressions(MyClass obj)
            : base(obj)
        { }

        public MyClassAccessor_UsingExpressions(MyClass obj, Type type)
            : base(obj, type)
        { }

        static MyClassAccessor_UsingExpressions()
        {
            _staticAccessor = new Accessor(typeof(MyClass));
        }

        public override int _field
        {
            get { return _accessor.GetFieldValue(() => _field); }
            set { _accessor.SetFieldValue(() => _field, value); }
        }

        public override int Property
        {
            get { return _accessor.GetPropertyValue(() => Property); }
            set { _accessor.SetPropertyValue(() => Property, value); }
        }

        public override void VoidMethod()
        {
            _accessor.InvokeMethod(() => VoidMethod());
        }

        public override void VoidMethodInt(int parameter)
        {
            _accessor.InvokeMethod(() => VoidMethodInt(0), parameter);
        }

        public override void VoidMethodIntInt(int parameter1, int parameter2)
        {
            _accessor.InvokeMethod(() => VoidMethodIntInt(0, 0), parameter1, parameter2);
        }

        public override int IntMethod()
        {
            return _accessor.InvokeMethod(() => IntMethod());
        }

        public override int IntMethodInt(int parameter)
        {
            return _accessor.InvokeMethod(() => IntMethodInt(0), parameter);
        }

        public override int IntMethodIntInt(int parameter1, int parameter2)
        {
            return _accessor.InvokeMethod(() => IntMethodIntInt(0, 0), parameter1, parameter2);
        }

        public static int StaticField
        {
            get { return (int)_staticAccessor.GetFieldValue(() => StaticField); }
            set { _staticAccessor.SetFieldValue(() => StaticField, value); }
        }

        public static int StaticProperty
        {
            get { return (int)_staticAccessor.GetPropertyValue(() => StaticProperty); }
            set { _staticAccessor.SetPropertyValue(() => StaticProperty, value); }
        }

        public static int StaticMethod(int parameter)
        {
            return (int)_staticAccessor.InvokeMethod(() => StaticMethod(0), parameter);
        }
    }
}
