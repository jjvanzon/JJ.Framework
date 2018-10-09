using System;
using System.Collections.Generic;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class Shipper
    {

        private System.Int32 m_Id;
        private System.String m_CompanyName;
        private IList<Order> m_Orders;
        private System.String m_Phone;

		
		public override string ToString()
		{
			return this.CompanyName;
		}

        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String CompanyName
        {
            get
            {
                return m_CompanyName;
            }
            set
            {
                m_CompanyName = value;
            }
        }

        public virtual IList<Order> Orders
        {
            get
            {
                return m_Orders;
            }
            set
            {
                m_Orders = value;
            }
        }

        public virtual System.String Phone
        {
            get
            {
                return m_Phone;
            }
            set
            {
                m_Phone = value;
            }
        }






    }
}
