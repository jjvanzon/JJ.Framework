using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class Child
    {

        private System.Int32 m_Id;
        private System.String m_NickName;
        private Person m_Person;

        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

        public virtual System.String NickName
        {
            get
            {
                return m_NickName;
            }
            set
            {
                m_NickName = value;
            }
        }

        public virtual Person Person
        {
            get
            {
                return m_Person;
            }
            set
            {
                m_Person = value;
            }
        }







    }
}
