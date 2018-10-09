using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class Person
    {

        private System.Int32 m_Id;
        private System.String m_Name;
        private System.Collections.IList m_Children;

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
