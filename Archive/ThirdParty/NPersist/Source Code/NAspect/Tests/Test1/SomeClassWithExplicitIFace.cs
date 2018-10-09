using System;

namespace KumoUnitTests
{
	public class SomeClassWithExplicitIFace : ICloneable
	{
		#region Public Property SomeLongProp
		private long someLongProp;
		public long SomeLongProp
		{
			get
			{
				return this.someLongProp;
			}
			set
			{
				this.someLongProp = value;
			}
		}
		#endregion

		public SomeClassWithExplicitIFace()
		{
		}


		object ICloneable.Clone()
		{
			SomeClassWithExplicitIFace clone = new SomeClassWithExplicitIFace() ;
			clone.SomeLongProp = this.SomeLongProp;
			return clone;
		}
	}
}
