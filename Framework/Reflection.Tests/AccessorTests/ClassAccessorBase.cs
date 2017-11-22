using System;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
	internal abstract class ClassAccessorBase : IClassAccessor
	{
		protected Accessor _accessor;

		public ClassAccessorBase(Class obj)
		{
			_accessor = new Accessor(obj);
		}

		public ClassAccessorBase(Class obj, Type type)
		{
			_accessor = new Accessor(obj, type);
		}

		public int this[int index]
		{
			get { return (int)_accessor.GetIndexerValue(index); }
			set { _accessor.SetIndexerValue(index, value); }
		}

		public string this[string key]
		{
			get { return (string)_accessor.GetIndexerValue(key); }
			set { _accessor.SetIndexerValue(key, value); }
		}

		public abstract int _field { get; set; }
		public abstract int Property { get; set; }
		public abstract void VoidMethod();
		public abstract void VoidMethodInt(int parameter);
		public abstract void VoidMethodIntInt(int parameter1, int parameter2);
		public abstract int IntMethod();
		public abstract int IntMethodInt(int parameter);
		public abstract int IntMethodIntInt(int parameter1, int parameter2);
	}
}
