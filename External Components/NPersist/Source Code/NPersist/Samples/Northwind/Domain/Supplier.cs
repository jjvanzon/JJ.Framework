using System;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class Supplier
    {

        private System.Int32 m_Id;
        private System.String m_Address;
        private System.String m_City;
        private System.String m_CompanyName;
        private System.String m_ContactName;
        private System.String m_ContactTitle;
        private System.String m_Country;
        private System.String m_Fax;
        private System.String m_HomePage;
        private System.String m_Phone;
        private System.String m_PostalCode;
        private System.Collections.IList m_Products;
        private System.String m_Region;

		
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

        public virtual System.String HomePage
        {
            get
            {
                return m_HomePage;
            }
            set
            {
                m_HomePage = value;
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

        public virtual System.Collections.IList Products
        {
            get
            {
                return m_Products;
            }
            set
            {
                m_Products = value;
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






    }
}
