using System;
using Puzzle.NPersist.Framework.Attributes;

namespace HelloWorld
{
	[ClassMap(Table="Employees")]
	public class Employee
	{
		public Employee()
		{
		}

		private int m_Id;
		private string m_Name = "";

		[PropertyMap(Columns="EmployeeId", IsIdentity=true, IsAssignedBySource=true)]
		public virtual int Id
		{
			get { return m_Id; }
		}

		[PropertyMap(Columns="Name", MinLength=1, MaxLength=50)]
		public virtual string Name
		{
			get { return m_Name; }
			set { m_Name = value;}
		}
	}
}
