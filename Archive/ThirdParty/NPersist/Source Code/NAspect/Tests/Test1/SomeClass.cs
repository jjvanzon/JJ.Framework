using System;

namespace KumoUnitTests
{
	public class SomeClass
	{
		public SomeClass()
		{
		}

		#region Public Property B
		private string b;
		public string B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}
		#endregion

		#region Public Property A
		private int a;
		public int A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}
		#endregion

		public SomeClass(int a,string b)
		{
			A = a;
			B = b;
		}

		public virtual int MyIntMethod()
		{
			return 0;
		}

		public virtual int MyOtherIntMethod()
		{
			return 0;
		}

		public virtual void MyRefParamMethod(ref string refString)
		{
		}

		public virtual int MyExceptionMethod()
		{
			throw new Exception("Yeeehaa");
		}

		public virtual string PassAndReturnRefParam(ref string refString)
		{
			return refString;
		}
	}
}