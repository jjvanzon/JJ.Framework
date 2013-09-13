using System;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for CyclicB.
	/// </summary>
	public class CyclicB
	{
		public CyclicB()
		{
		}

		#region Property  Id
		
		private int m_Id;
		
		public virtual int Id
		{
			get { return this.m_Id; }
			set { this.m_Id = value; }
		}
		
		#endregion

		#region Property  CyclicA 
		
		private CyclicA m_CyclicA ;
		
		public virtual CyclicA CyclicA 
		{
			get { return this.m_CyclicA ; }
			set { this.m_CyclicA  = value; }
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
