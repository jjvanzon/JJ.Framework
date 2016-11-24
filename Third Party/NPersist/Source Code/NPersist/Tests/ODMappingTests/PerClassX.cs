using System;

namespace ODMappingTests
{
	public class PerClassX
	{
		public PerClassX()
		{
		}
		
		private System.Guid m_Id;
		private System.String m_Name;

		public virtual System.Guid Id
		{
			get { return m_Id; }
		}

		public virtual System.String Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}
	}
}
