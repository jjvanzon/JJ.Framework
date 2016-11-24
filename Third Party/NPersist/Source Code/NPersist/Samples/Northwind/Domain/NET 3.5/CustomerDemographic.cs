using System;
using System.Collections.Generic;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class CustomerDemographic
    {

        private System.String m_Id;
        private System.String m_CustomerDesc;
        private IList<Customer> m_Customers;

		
		public override string ToString()
		{
			return this.CustomerDesc;
		}


        public virtual System.String Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }

        public virtual System.String CustomerDesc
        {
            get
            {
                return m_CustomerDesc;
            }
            set
            {
                m_CustomerDesc = value;
            }
        }

        public virtual IList<Customer> Customers
        {
            get
            {
                return m_Customers;
            }
            set
            {
                m_Customers = value;
            }
        }






    }
}
