using System;
using System.Collections;

namespace ODMappingTests
{
	/// <summary>
	/// Summary description for DogOwner.
	/// </summary>
	public class DogOwner
	{
		public DogOwner()
		{
		}

		private System.Guid m_Id;
		private System.String m_Name;
		private IList m_Dogs;
		private Profile m_Profile;

		public virtual System.Guid Id
		{
			get { return m_Id; }
		}

		public virtual System.String Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public virtual IList Dogs
		{
			get { return m_Dogs; }
			set { m_Dogs = value; }
		}

		public virtual Profile Profile
		{
			get { return m_Profile; }
			set { m_Profile = value; }
		}

	}
}
