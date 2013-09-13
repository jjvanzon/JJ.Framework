using System;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for CyclicA.
	/// </summary>
	public class CyclicA
	{
		public CyclicA()
		{
		}


		#region Property  Id
		
		private int id;
		
		private int m_Id;
		
		public virtual int Id
		{
			get { return this.m_Id; }
			set { this.m_Id = value; }
		}
		
		#endregion

		#region Property  CyclicB 
		
		private CyclicB m_CyclicB ;
		
		public virtual CyclicB CyclicB 
		{
			get { return this.m_CyclicB ; }
			set { this.m_CyclicB  = value; }
		}
		
		#endregion

		#region Property  SomeText
		
		private string m_SomeText;
		
		public virtual string SomeText
		{
			get { return this.m_SomeText; }
			set { this.m_SomeText = value; }
		}
		
		#endregion

	}
}
