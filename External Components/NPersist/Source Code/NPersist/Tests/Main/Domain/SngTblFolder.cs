using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class SngTblFolder
    {

        private System.Int32 m_Id;
        private System.String m_Name;
        private SngTblPerson m_Person;

        public virtual System.Int32 Id
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

        public virtual SngTblPerson Person
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
