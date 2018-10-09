using System;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{
    public class Category
    {
        private System.Int32 m_Id;
        private System.String m_CategoryName;
        private System.String m_Description;
        private System.Byte[] m_Picture;
        private System.Collections.IList m_Products;

		public override string ToString()
		{
			return this.CategoryName;
		}

        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String CategoryName
        {
            get
            {
                return m_CategoryName;
            }
            set
            {
                m_CategoryName = value;
            }
        }

        public virtual System.String Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }

        public virtual System.Byte[] Picture
        {
            get
            {
                return m_Picture;
            }
            set
            {
                m_Picture = value;
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






    }
}
