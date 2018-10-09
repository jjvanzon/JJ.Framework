using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class SngTblWorkFolder : SngTblFolder
    {

        private SngTblEmployee m_Employee;
        private System.String m_WorkType;

        public virtual SngTblEmployee Employee
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

        public virtual System.String WorkType
        {
            get
            {
                return m_WorkType;
            }
            set
            {
                m_WorkType = value;
            }
        }






    }
}
