// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for SerializedReference.
	/// </summary>
	public class SerializedReference
	{
		public SerializedReference(string identity, string type)
		{
			this.identity = identity;
			this.type = type;
		}

		#region Property  Identity
		
		private string identity = "";
		
		public string Identity
		{
			get => this.identity;
		    set => this.identity = value;
		}
		
		#endregion

		#region Property  Type
		
		private string type = "";
		
		public string Type
		{
			get => this.type;
		    set => this.type = value;
		}
		
		#endregion
	}
}
