using System;
using System.Collections;
using System.Collections.Generic;

namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class Customer
    {

        private System.String m_Id;
        private System.String m_Address;
        private System.String m_City;
        private System.String m_CompanyName;
        private System.String m_ContactName;
        private System.String m_ContactTitle;
        private System.String m_Country;
        private IList<CustomerDemographic> m_CustomerDemographics;
        private System.String m_Fax;
        private IList<Order> m_Orders;
        private System.String m_Phone;
        private System.String m_PostalCode;
        private System.String m_Region;

		
		public override string ToString()
		{
			return this.CompanyName;
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

        public virtual System.String Address
        {
            get
            {
                return m_Address;
            }
            set
            {
                m_Address = value;
            }
        }

        public virtual System.String City
        {
            get
            {
                return m_City;
            }
            set
            {
                m_City = value;
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

        public virtual System.String ContactName
        {
            get
            {
                return m_ContactName;
            }
            set
            {
                m_ContactName = value;
            }
        }

        public virtual System.String ContactTitle
        {
            get
            {
                return m_ContactTitle;
            }
            set
            {
                m_ContactTitle = value;
            }
        }

        public virtual System.String Country
        {
            get
            {
                return m_Country;
            }
            set
            {
                m_Country = value;
            }
        }

        public virtual IList<CustomerDemographic> CustomerDemographics
        {
            get
            {
                return m_CustomerDemographics;
            }
            set
            {
                m_CustomerDemographics = value;
            }
        }

        public virtual System.String Fax
        {
            get
            {
                return m_Fax;
            }
            set
            {
                m_Fax = value;
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

        public virtual System.String PostalCode
        {
            get
            {
                return m_PostalCode;
            }
            set
            {
                m_PostalCode = value;
            }
        }

        public virtual System.String Region
        {
            get
            {
                return m_Region;
            }
            set
            {
                m_Region = value;
            }
        }

		public void Validate()
		{
			MayNotHaveDifferentShippingAddresses();
		}

		/// <summary>
		/// This is a stupid, non-realistic rule that is only here for the commit regions test
		/// </summary>
		private void MayNotHaveDifferentShippingAddresses()
		{
			string address = "";
			//IList orders = this.Orders;
			foreach (Order order in this.Orders)
			{
				if (order.ShipAddress != null)
				{
					Console.WriteLine(order.ShipAddress);
					if (address != "")
					{
						if (address != order.ShipAddress)
							throw new DifferentShipAddressException("You have orders with two different shipping addresses for the same customer!");
					}
					address = order.ShipAddress;
				}
			}
		}




    }
}
