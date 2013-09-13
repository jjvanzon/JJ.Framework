using System;
using System.Collections.Generic;
namespace Puzzle.NPersist.Samples.Northwind.Domain
{

    public class Territory
    {

        private System.String m_Id;
        private IList<Employee> m_Employees;
        private Region m_Region;
        private System.String m_TerritoryDescription;

		
		public override string ToString()
		{
			return this.TerritoryDescription;
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

        public virtual IList<Employee> Employees
        {
            get
            {
                return m_Employees;
            }
            set
            {
                m_Employees = value;
            }
        }

        public virtual Region Region
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

        public virtual System.String TerritoryDescription
        {
            get
            {
                return m_TerritoryDescription;
            }
            set
            {
                m_TerritoryDescription = value;
            }
        }






    }
}
