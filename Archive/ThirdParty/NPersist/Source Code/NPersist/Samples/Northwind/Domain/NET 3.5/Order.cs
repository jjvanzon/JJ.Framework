using System;
using System.Collections.Generic;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class Order
    {

        private System.Int32 m_Id;
        private Customer m_Customer;
        private Employee m_Employee;
        private System.Decimal m_Freight;
        private System.DateTime m_OrderDate;
        private IList<OrderDetail> m_OrderDetails;
        private System.DateTime m_RequiredDate;
        private System.String m_ShipAddress;
        private System.String m_ShipCity;
        private System.String m_ShipCountry;
        private System.String m_ShipName;
        private System.DateTime m_ShippedDate;
        private System.String m_ShipPostalCode;
        private System.String m_ShipRegion;
        private Shipper m_ShipVia;

		
		public override string ToString()
		{
			return this.Id.ToString() ;
		}


		public decimal GetTotal()
		{
			decimal total = 0;

			//make sure to use the public property this.OrderDetails
			//rather than accessing the private m_OrderDetails field
			//directly, or the property will not be lazy loaded!
			foreach (OrderDetail orderDetail in this.OrderDetails)
			{
				total += orderDetail.GetTotal() ;
			}

			return total;
		}

        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual Customer Customer
        {
            get
            {
                return m_Customer;
            }
            set
            {
                m_Customer = value;
            }
        }

        public virtual Employee Employee
        {
            get
            {
                return m_Employee;
            }
            set
            {
                m_Employee = value;
            }
        }

        public virtual System.Decimal Freight
        {
            get
            {
                return m_Freight;
            }
            set
            {
                m_Freight = value;
            }
        }

        public virtual System.DateTime OrderDate
        {
            get
            {
                return m_OrderDate;
            }
            set
            {
                m_OrderDate = value;
            }
        }

        public virtual IList<OrderDetail> OrderDetails
        {
            get
            {
                return m_OrderDetails;
            }
            set
            {
                m_OrderDetails = value;
            }
        }

        public virtual System.DateTime RequiredDate
        {
            get
            {
                return m_RequiredDate;
            }
            set
            {
                m_RequiredDate = value;
            }
        }

        public virtual System.String ShipAddress
        {
            get
            {
                return m_ShipAddress;
            }
            set
            {
                m_ShipAddress = value;
            }
        }

        public virtual System.String ShipCity
        {
            get
            {
                return m_ShipCity;
            }
            set
            {
                m_ShipCity = value;
            }
        }

        public virtual System.String ShipCountry
        {
            get
            {
                return m_ShipCountry;
            }
            set
            {
                m_ShipCountry = value;
            }
        }

        public virtual System.String ShipName
        {
            get
            {
                return m_ShipName;
            }
            set
            {
                m_ShipName = value;
            }
        }

        public virtual System.DateTime ShippedDate
        {
            get
            {
                return m_ShippedDate;
            }
            set
            {
                m_ShippedDate = value;
            }
        }

        public virtual System.String ShipPostalCode
        {
            get
            {
                return m_ShipPostalCode;
            }
            set
            {
                m_ShipPostalCode = value;
            }
        }

        public virtual System.String ShipRegion
        {
            get
            {
                return m_ShipRegion;
            }
            set
            {
                m_ShipRegion = value;
            }
        }

        public virtual Shipper ShipVia
        {
            get
            {
                return m_ShipVia;
            }
            set
            {
                m_ShipVia = value;
            }
        }


		public void Validate()
		{
			EnsureMaxTotalNotExceeded();
		}

		public void EnsureMaxTotalNotExceeded()
		{
			decimal total = this.GetTotal();
			if (total > 500)
				throw new OrderMaxTotalExceededException("Maximum order total value exceeded! Maximum total value for an order is 500, this order has a total value of " + total.ToString());
		}
    }
}
