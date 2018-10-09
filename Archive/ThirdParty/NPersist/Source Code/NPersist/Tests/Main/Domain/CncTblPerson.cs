using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class CncTblPerson
    {

        private System.Int32 m_Id;
        private System.String m_FirstName;
        private System.String m_LastName;
        private System.Collections.IList m_Folders;

        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String FirstName
        {
            get
            {
                return m_FirstName;
            }
            set
            {
                m_FirstName = value;
            }
        }

        public virtual System.String LastName
        {
            get
            {
                return m_LastName;
            }
            set
            {
                m_LastName = value;
            }
        }

        public virtual System.Collections.IList Folders
        {
            get
            {
                return m_Folders;
            }
            set
            {
                m_Folders = value;
            }
        }






    }
}
