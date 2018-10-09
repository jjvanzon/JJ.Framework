using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class Cover
    {

        private long m_Id;
        private System.String m_Color;

        public virtual long Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }






    }
}
