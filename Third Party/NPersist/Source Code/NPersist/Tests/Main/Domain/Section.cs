using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class Section
    {

        private System.Int32 m_ID;
        private System.String m_Descr;
        private Section m_Parent;
        private System.Collections.IList m_Children;

        public virtual System.Int32 ID
        {
            get
            {
                return m_ID;
            }
        }

        public virtual System.String Descr
        {
            get
            {
                return m_Descr;
            }
            set
            {
                m_Descr = value;
            }
        }

        public virtual Section Parent
        {
            get
            {
                return m_Parent;
            }
            set
            {
                m_Parent = value;
            }
        }

        public virtual System.Collections.IList Children
        {
            get
            {
                return m_Children;
            }
            set
            {
                m_Children = value;
            }
        }






    }
}
