using System;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
	internal class ClassAccessor_UsingExpressions : ClassAccessorBase
	{
		private static readonly Accessor _staticAccessor;

		public ClassAccessor_UsingExpressions(Class obj)
			: base(obj) { }

		public ClassAccessor_UsingExpressions(Class obj, Type type)
			: base(obj, type) { }

		static ClassAccessor_UsingExpressions() => _staticAccessor = new Accessor(typeof(Class));

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

		public override void VoidMethodInt(int parameter) => _accessor.InvokeMethod(() => VoidMethodInt(0), parameter);

		public override void VoidMethodIntInt(int parameter1, int parameter2) => _accessor.InvokeMethod(() => VoidMethodIntInt(0, 0), parameter1, parameter2);

		public override int IntMethod() => _accessor.InvokeMethod(() => IntMethod());

		public override int IntMethodInt(int parameter) => _accessor.InvokeMethod(() => IntMethodInt(0), parameter);

		public override int IntMethodIntInt(int parameter1, int parameter2) => _accessor.InvokeMethod(() => IntMethodIntInt(0, 0), parameter1, parameter2);

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

		public static int StaticMethod(int parameter) => _staticAccessor.InvokeMethod(() => StaticMethod(0), parameter);
	}
}