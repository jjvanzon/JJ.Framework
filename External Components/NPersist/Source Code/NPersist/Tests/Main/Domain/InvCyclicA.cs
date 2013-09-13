using System;
using System.Collections;

namespace Puzzle.NPersist.Tests.Main
{
	/// <summary>
	/// Summary description for InvCyclicA.
	/// </summary>
	public class InvCyclicA
	{
		public InvCyclicA()
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

		#region Property  InvCyclicB
		
		private InvCyclicB m_InvCyclicB ;
		
		public virtual InvCyclicB InvCyclicB 
		{
			get { return this.m_InvCyclicB ; }
			set { this.m_InvCyclicB  = value; }
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

		#region Property  InvOfInvCyclicA
		
		private InvCyclicB m_InvOfInvCyclicA;
		
		public virtual InvCyclicB InvOfInvCyclicA
		{
			get { return this.m_InvOfInvCyclicA; }
			set { this.m_InvOfInvCyclicA = value; }
		}
		
		#endregion
	}
}
