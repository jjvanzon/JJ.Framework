using System;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class OrderDetail
    {

        private Order m_Order;
        private Product m_Product;
        private System.Single m_Discount;
        private System.Int16 m_Quantity;
        private System.Decimal m_UnitPrice;
		
		public override string ToString()
		{
			return this.Order.Id + ":" + this.Product.Id ;
		}

		public decimal GetTotal()
		{
			return this.Quantity * this.UnitPrice;
		}

        public virtual Order Order
        {
            get
            {
                return m_Order;
            }
            set
            {
                m_Order = value;
            }
        }

        public virtual Product Product
        {
            get
            {
                return m_Product;
            }
            set
            {
                m_Product = value;
            }
        }

        public virtual System.Single Discount
        {
            get
            {
                return m_Discount;
            }
            set
            {
                m_Discount = value;
            }
        }

        public virtual System.Int16 Quantity
        {
            get
            {
                return m_Quantity;
            }
            set
            {
                m_Quantity = value;
            }
        }

        public virtual System.Decimal UnitPrice
        {
            get
            {
                return m_UnitPrice;
            }
            set
            {
                m_UnitPrice = value;
            }
        }






    }
}
