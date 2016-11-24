using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class FolderID
    {

        private System.String m_ApCode;
        private System.String m_FuncCode;
        private System.String m_FolderDescript;
        private System.Int32 m_ID;

        public virtual System.String ApCode
        {
            get
            {
                return m_ApCode;
            }
            set
            {
                m_ApCode = value;
            }
        }

        public virtual System.String FuncCode
        {
            get
            {
                return m_FuncCode;
            }
            set
            {
                m_FuncCode = value;
            }
        }

        public virtual System.String FolderDescript
        {
            get
            {
                return m_FolderDescript;
            }
            set
            {
                m_FolderDescript = value;
            }
        }

        public virtual System.Int32 ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }






    }
}
