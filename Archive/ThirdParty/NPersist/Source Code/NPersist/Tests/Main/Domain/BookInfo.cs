using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class BookInfo
    {

        private long m_Id;
        private System.String m_ISBN;
        private Book m_Book;

        public virtual long Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String ISBN
        {
            get
            {
                return m_ISBN;
            }
            set
            {
                m_ISBN = value;
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
