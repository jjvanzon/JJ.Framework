using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class ClsTblWorkFolder : ClsTblFolder
    {

        private ClsTblEmployee m_Employee;
        private System.String m_WorkType;

        public virtual ClsTblEmployee Employee
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
