using System;
using System.ComponentModel;

namespace KumoUnitTests
{
    public class SomeAttribAttribute : Attribute
    {
        #region Property Name 
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }                        
        #endregion

        #region Property Age 
        private int age;
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }                        
        #endregion
    }

	public class Foo
	{
        [Browsable(false)]
        [SomeAttrib(Name="Test",Age=10)]
		public Foo()
		{

		}

		#region Public Property B
		private string b;
        public virtual string B
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
		public virtual int A
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

		public Foo(int a,string b)
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