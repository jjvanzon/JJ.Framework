using System;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class Product
    {

        private System.Int32 m_Id;
        private Category m_Category;
        private System.Boolean m_Discontinued;
        private System.Collections.IList m_OrderDetails;
        private System.String m_ProductName;
        private System.String m_QuantityPerUnit;
        private System.Int16 m_ReorderLevel;
        private Supplier m_Supplier;
        private System.Decimal m_UnitPrice;
        private System.Int16 m_UnitsInStock;
        private System.Int16 m_UnitsOnOrder;

		
		public override string ToString()
		{
			return this.ProductName;
		}


        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual Category Category
        {
            get
            {
                return m_Category;
            }
            set
            {
                m_Category = value;
            }
        }

        public virtual System.Boolean Discontinued
        {
            get
            {
                return m_Discontinued;
            }
            set
            {
                m_Discontinued = value;
            }
        }

        public virtual System.Collections.IList OrderDetails
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

        public virtual System.String ProductName
        {
            get
            {
                return m_ProductName;
            }
            set
            {
                m_ProductName = value;
            }
        }

        public virtual System.String QuantityPerUnit
        {
            get
            {
                return m_QuantityPerUnit;
            }
            set
            {
                m_QuantityPerUnit = value;
            }
        }

        public virtual System.Int16 ReorderLevel
        {
            get
            {
                return m_ReorderLevel;
            }
            set
            {
                m_ReorderLevel = value;
            }
        }

        public virtual Supplier Supplier
        {
            get
            {
                return m_Supplier;
            }
            set
            {
                m_Supplier = value;
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

        public virtual System.Int16 UnitsInStock
        {
            get
            {
                return m_UnitsInStock;
            }
            set
            {
                m_UnitsInStock = value;
            }
        }

        public virtual System.Int16 UnitsOnOrder
        {
            get
            {
                return m_UnitsOnOrder;
            }
            set
            {
                m_UnitsOnOrder = value;
            }
        }






    }
}
