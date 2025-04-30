using System;
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    internal class ClassAccessorLegacy_UsingExpressions : ClassAccessorLegacyBase
    {
        private static readonly AccessorLegacy _staticAccessor;

        public ClassAccessorLegacy_UsingExpressions(ClassLegacy obj)
            : base(obj) { }

        public ClassAccessorLegacy_UsingExpressions(ClassLegacy obj, Type type)
            : base(obj, type) { }

        static ClassAccessorLegacy_UsingExpressions() => _staticAccessor = new AccessorLegacy(typeof(ClassLegacy));

        public override int _field
        {
            get => _accessor.GetFieldValue(() => _field);
            set => _accessor.SetFieldValue(() => _field, value);
        }

        public override int Property
        {
            get => _accessor.GetPropertyValue(() => Property);
            set => _accessor.SetPropertyValue(() => Property, value);
        }

        public override void VoidMethod() => _accessor.InvokeMethod(() => VoidMethod());

        public override void VoidMethodInt(int parameter) 
            => _accessor.InvokeMethod(() => VoidMethodInt(parameter));

        public override void VoidMethodIntInt(int parameter1, int parameter2) 
            => _accessor.InvokeMethod(() => VoidMethodIntInt(parameter1, parameter2));

        public override int IntMethod() 
            => _accessor.InvokeMethod(() => IntMethod());

        public override int IntMethodInt(int parameter) 
            => _accessor.InvokeMethod(() => IntMethodInt(parameter));

        public override int IntMethodIntInt(int parameter1, int parameter2) 
            => _accessor.InvokeMethod(() => IntMethodIntInt(parameter1, parameter2));

        // ReSharper disable once InconsistentNaming
        public static int _staticField
        {
            get => _staticAccessor.GetFieldValue(() => _staticField);
            set => _staticAccessor.SetFieldValue(() => _staticField, value);
        }

        public static int StaticProperty
        {
            get => _staticAccessor.GetPropertyValue(() => StaticProperty);
            set => _staticAccessor.SetPropertyValue(() => StaticProperty, value);
        }

        public static int StaticMethod(int parameter) 
            => _staticAccessor.InvokeMethod(() => StaticMethod(parameter));
    }
}