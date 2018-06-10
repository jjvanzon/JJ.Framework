// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for InverseAction.
	/// </summary>
	public class InverseAction
	{
		public InverseAction()
		{
		}

		private InverseActionType actionType;
		private object obj;
		private string propertyName;
		private object value;
		private object master;
		
		public InverseActionType ActionType
		{
			get => this.actionType;
		    set => this.actionType = value;
		}

		
		public object Obj
		{
			get => this.obj;
		    set => this.obj = value;
		}

		
		public string PropertyName
		{
			get => this.propertyName;
		    set => this.propertyName = value;
		}
		
		public object Value
		{
			get => this.value;
		    set => this.value = value;
		}
		
		public object Master
		{
			get => this.master;
		    set => this.master = value;
		}
	}
}
