using System;
using System.Collections;

namespace ODMappingTests
{
	public class Profile
	{
		public Profile()
		{
		}

		
		private System.Guid m_Id;
		private System.String m_Email;
		private DogOwner m_DogOwner;
		private IList m_PhoneNumbers;

		public virtual System.Guid Id
		{
			get { return m_Id; }
		}

		public virtual System.String Email
		{
			get { return m_Email; }
			set { m_Email = value; }
		}

		public virtual DogOwner DogOwner
		{
			get { return m_DogOwner; }
			set { m_DogOwner = value; }
		}

		public virtual IList PhoneNumbers
		{
			get { return m_PhoneNumbers; }
			set { m_PhoneNumbers = value; }
		}
	}
}
