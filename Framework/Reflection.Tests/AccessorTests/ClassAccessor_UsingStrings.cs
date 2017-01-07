using System;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class ClassAccessor_UsingStrings : ClassAccessorBase
    {
        private static Accessor _staticAccessor;

        public ClassAccessor_UsingStrings(Class obj)
            : base(obj)
        { }

        public ClassAccessor_UsingStrings(Class obj, Type type)
            : base(obj, type)
        { }

        static ClassAccessor_UsingStrings()
        {
            _staticAccessor = new Accessor(typeof(Class));
        }

        public override int _field
        {
            get { return (int)_accessor.GetFieldValue("_field"); }
            set { _accessor.SetFieldValue("_field", value); }
        }

        public override int Property
        {
            get { return (int)_accessor.GetPropertyValue("Property"); }
            set { _accessor.SetPropertyValue("Property", value); }
        }

        public override void VoidMethod()
        {
            _accessor.InvokeMethod("VoidMethod");
        }

        public override void VoidMethodInt(int parameter)
        {
            _accessor.InvokeMethod("VoidMethodInt", parameter);
        }

        public override void VoidMethodIntInt(int parameter1, int parameter2)
        {
            _accessor.InvokeMethod("VoidMethodIntInt", parameter1, parameter2);
        }

        public override int IntMethod()
        {
            return (int)_accessor.InvokeMethod("IntMethod");
        }

        public override int IntMethodInt(int parameter)
        {
            return (int)_accessor.InvokeMethod("IntMethodInt", parameter);
        }

        public override int IntMethodIntInt(int parameter1, int parameter2)
        {
            return (int)_accessor.InvokeMethod("IntMethodIntInt", parameter1, parameter2);
        }

        public static int StaticField
        {
            get { return (int)_staticAccessor.GetFieldValue("StaticField"); }
            set { _staticAccessor.SetFieldValue("StaticField", value); }
        }

        public static int StaticProperty
        {
            get { return (int)_staticAccessor.GetPropertyValue("StaticProperty"); }
            set { _staticAccessor.SetPropertyValue("StaticProperty", value); }
        }

        public static int StaticMethod(int parameter)
        {
            return (int)_staticAccessor.InvokeMethod("StaticMethod", parameter);
        }
    }
}
