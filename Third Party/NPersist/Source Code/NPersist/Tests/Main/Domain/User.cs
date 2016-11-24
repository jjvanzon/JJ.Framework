using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class User
    {

        private System.String m_Id;
        private System.DateTime m_LastLogon;
        private System.String m_FirstName;
        private System.String m_LastName;
        private Section m_Section;
        private System.String m_DateOfBirth;

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

        public virtual System.DateTime LastLogon
        {
            get
            {
                return m_LastLogon;
            }
            set
            {
                m_LastLogon = value;
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

        public virtual Section Section
        {
            get
            {
                return m_Section;
            }
            set
            {
                m_Section = value;
            }
        }

        public virtual System.String DateOfBirth
        {
            get
            {
                return m_DateOfBirth;
            }
            set
            {
                m_DateOfBirth = value;
            }
        }






    }
}
