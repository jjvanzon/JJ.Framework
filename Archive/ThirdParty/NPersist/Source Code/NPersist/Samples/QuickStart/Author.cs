using System;
namespace QuickStart.Domain
{
    public class Author
    {

        private System.Int32 m_Id;
        private System.String m_FirstName;
        private System.String m_LastName;
        private System.Collections.IList m_Books;

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

        public virtual System.Collections.IList Books
        {
            get
            {
                return m_Books;
            }
            set
            {
                m_Books = value;
            }
        }
    }
}
