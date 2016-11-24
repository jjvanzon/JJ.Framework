using System;
namespace QuickStart.Domain
{
    public class Review
    {
        private System.Int32 m_Id;
        private System.String m_Reviewer;
        private System.String m_Body;
        private System.Int32 m_Grade;
        private Book m_Book;

        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String Reviewer
        {
            get
            {
                return m_Reviewer;
            }
            set
            {
                m_Reviewer = value;
            }
        }

        public virtual System.String Body
        {
            get
            {
                return m_Body;
            }
            set
            {
                m_Body = value;
            }
        }

        public virtual System.Int32 Grade
        {
            get
            {
                return m_Grade;
            }
            set
            {
                m_Grade = value;
            }
        }

        public virtual Book Book
        {
            get
            {
                return m_Book;
            }
            set
            {
                m_Book = value;
            }
        }
    }
}
