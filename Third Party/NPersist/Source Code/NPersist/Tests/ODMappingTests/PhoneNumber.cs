using System;

namespace ODMappingTests
{
	public class PhoneNumber
	{
		public PhoneNumber()
		{
		}


		private System.Guid m_Id;
		private System.String m_Number;
		private Profile m_Profile;

		public virtual System.Guid Id
		{
			get { return m_Id; }
		}

		public virtual System.String Number
		{
			get { return m_Number; }
			set { m_Number = value; }
		}

		public virtual Profile Profile
		{
			get { return m_Profile; }
			set { m_Profile = value; }
		}
	}
}
