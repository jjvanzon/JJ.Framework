using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class ClsTblFolder
    {

        private long m_Id;
        private System.String m_Name;
        private ClsTblPerson m_Person;

        public virtual long Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public virtual ClsTblPerson Person
        {
            get
            {
                return m_Person;
            }
            set
            {
                m_Person = value;
            }
        }






    }
}
