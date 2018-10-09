using System;
namespace QuickStart.Domain
{
    public class Book
    {
        private System.Int32 m_Id;
        private System.String m_Title;
        private System.String m_Isbn;
        private System.Collections.IList m_Authors;
        private System.Collections.IList m_Reviews;

        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        public virtual System.String Isbn
        {
            get
            {
                return m_Isbn;
            }
            set
            {
                m_Isbn = value;
            }
        }

        public virtual System.Collections.IList Authors
        {
            get
            {
                return m_Authors;
            }
            set
            {
                m_Authors = value;
            }
        }

        public virtual System.Collections.IList Reviews
        {
            get
            {
                return m_Reviews;
            }
            set
            {
                m_Reviews = value;
            }
        }
    }
}
