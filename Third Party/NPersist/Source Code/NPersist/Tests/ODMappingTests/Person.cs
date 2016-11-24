using System;

namespace ODMappingTests
{
	/// <summary>
	/// Summary description for Person.
	/// </summary>
	public class Person
	{

		public Person()
		{
		}

		private System.Guid m_Id;
		private System.String m_FirstName;
		private System.String m_LastName;

		public virtual System.Guid Id
		{
			get { return m_Id; }
		}

		public virtual System.String FirstName
		{
			get { return m_FirstName; }
			set { m_FirstName = value; }
		}

		public virtual System.String LastName
		{
			get { return m_LastName; }
			set { m_LastName = value; }
		}
	}
}
