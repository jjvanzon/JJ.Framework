using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class CncTblWorkFolder : CncTblFolder
    {

        private System.String m_WorkType;
        private CncTblEmployee m_Employee;

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

        public virtual CncTblEmployee Employee
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






    }
}
