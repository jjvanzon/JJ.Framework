using System;

namespace ODMappingTests
{
	/// <summary>
	/// Summary description for Dog.
	/// </summary>
	public class Dog
	{
		public Dog()
		{
		}

		private System.Guid m_Id;
		private System.String m_Name;
		private DogOwner m_DogOwner;

		public virtual System.Guid Id
		{
			get { return m_Id; }
		}

		public virtual System.String Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public virtual DogOwner DogOwner
		{
			get { return m_DogOwner; }
			set { m_DogOwner = value; }
		}
	}
}
