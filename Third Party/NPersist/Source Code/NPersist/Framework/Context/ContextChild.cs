using System.Diagnostics;
using Puzzle.NPersist.Framework.Interfaces;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.BaseClasses
{
	/// <summary>
	/// Summary description for ContextChild.
	/// </summary>
	public class ContextChild : IContextChild 
	{
		public ContextChild()
		{
		}

		public ContextChild(IContext ctx) => this.context = ctx;

	    private IContext context;

		
		public virtual IContext Context
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => this.context;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => this.context = value;
		}

	}
}
