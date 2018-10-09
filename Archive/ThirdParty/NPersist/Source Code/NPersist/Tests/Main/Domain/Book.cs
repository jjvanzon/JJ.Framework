using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class Book
    {

        private long m_Id;
        private System.String m_Name;
        private Cover m_Cover;
        private BookInfo m_BookInfo;

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

        public virtual Cover Cover
        {
            get
            {
                return m_Cover;
            }
            set
            {
                m_Cover = value;
            }
        }

        public virtual BookInfo BookInfo
        {
            get
            {
                return m_BookInfo;
            }
        }






    }
}
