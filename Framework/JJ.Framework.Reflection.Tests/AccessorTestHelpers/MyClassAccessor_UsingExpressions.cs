using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Tests.AccessorTestHelpers
{
    public class MyClassAccessor_UsingExpressions
    {
        private Accessor Accessor;
        private static Accessor StaticAccessor;

        public MyClassAccessor_UsingExpressions(MyClass obj)
        {
            Accessor = new Accessor(obj);
        }

        static MyClassAccessor_UsingExpressions()
        {
            StaticAccessor = new Accessor(typeof(MyClass));
        }

        public int Field
        {
            get { return Accessor.GetFieldValue(() => Field); }
            set { Accessor.SetFieldValue(() => Field, value); }
        }

        public int Property
        {
            get { return Accessor.GetPropertyValue(() => Property); }
            set { Accessor.SetPropertyValue(() => Property, value); }
        }

        public void VoidMethod()
        {
            Accessor.InvokeMethod(() => VoidMethod());
        }

        public void VoidMethodInt(int parameter)
        {
            Accessor.InvokeMethod(() => VoidMethodInt(0), parameter);
        }

        public void VoidMethodIntInt(int parameter1, int parameter2)
        {
            Accessor.InvokeMethod(() => VoidMethodIntInt(0, 0), parameter1, parameter2);
        }

        public int IntMethod(int parameter)
        {
            return Accessor.InvokeMethod(() => IntMethod(0), parameter);
        }

        public int IntMethodInt(int parameter)
        {
            return Accessor.InvokeMethod(() => IntMethodInt(0), parameter);
        }

        public int IntMethodIntInt(int parameter)
        {
            return Accessor.InvokeMethod(() => IntMethodIntInt(0), parameter);
        }

        public static int StaticField
        {
            get { return (int)StaticAccessor.GetFieldValue(() => StaticField); }
            set { StaticAccessor.SetFieldValue(() => StaticField, value); }
        }

        public static int StaticProperty
        {
            get { return (int)StaticAccessor.GetPropertyValue(() => StaticProperty); }
            set { StaticAccessor.SetPropertyValue(() => StaticProperty, value); }
        }

        private static int StaticMethod(int parameter)
        {
            return (int)StaticAccessor.InvokeMethod(() => StaticMethod(0), parameter);
        }

        // TODO: Finish other methods to use in AccessorTests_UsingExpressions.
    }
}
