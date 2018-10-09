using System;
namespace Puzzle.NPersist.Tests.Main
{

    public class Employee : Puzzle.NPersist.Tests.Main.Person
    {

        private System.Decimal m_Salary;

        public virtual System.Decimal Salary
        {
            get
            {
                return m_Salary;
            }
            set
            {
                m_Salary = value;
            }
        }







    }
}
