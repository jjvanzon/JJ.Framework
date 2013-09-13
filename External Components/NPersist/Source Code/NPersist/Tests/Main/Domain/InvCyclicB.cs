using System;
using System.Collections;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for InvCyclicB.
	/// </summary>
	public class InvCyclicB
	{
		public InvCyclicB()
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

		#region Property  InvCyclicA 
		
		private InvCyclicA m_InvCyclicA ;
		
		public virtual InvCyclicA InvCyclicA 
		{
			get { return this.m_InvCyclicA ; }
			set { this.m_InvCyclicA  = value; }
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

		#region Property  InvOfInvCyclicB
		
		private InvCyclicA m_InvOfInvCyclicB;
		
		public virtual InvCyclicA InvOfInvCyclicB
		{
			get { return this.m_InvOfInvCyclicB; }
			set { this.m_InvOfInvCyclicB = value; }
		}
		
		#endregion
	}
}
