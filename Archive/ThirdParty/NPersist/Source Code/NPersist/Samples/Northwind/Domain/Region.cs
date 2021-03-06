using System;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class Region
    {

        private System.Int32 m_Id;
        private System.String m_RegionDescription;
        private System.Collections.IList m_Territories;

		
		public override string ToString()
		{
			return this.RegionDescription;
		}


        public virtual System.Int32 Id
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

        public virtual System.String RegionDescription
        {
            get
            {
                return m_RegionDescription;
            }
            set
            {
                m_RegionDescription = value;
            }
        }

        public virtual System.Collections.IList Territories
        {
            get
            {
                return m_Territories;
            }
            set
            {
                m_Territories = value;
            }
        }






    }
}
