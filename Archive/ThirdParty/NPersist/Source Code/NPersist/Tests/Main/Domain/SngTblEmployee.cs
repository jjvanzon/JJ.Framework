using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class SngTblEmployee : SngTblPerson
    {

        private System.Decimal m_Salary;
        private System.DateTime m_EmploymentDate;
        private System.Collections.IList m_WorkFolders;

        public virtual System.Decimal Salary
        {
            get
            {
                return m_Salary;
            }
            set
            {
                m_Salary = value;
            }
        }

        public virtual System.DateTime EmploymentDate
        {
            get
            {
                return m_EmploymentDate;
            }
            set
            {
                m_EmploymentDate = value;
            }
        }

        public virtual System.Collections.IList WorkFolders
        {
            get
            {
                return m_WorkFolders;
            }
            set
            {
                m_WorkFolders = value;
            }
        }






    }
}
