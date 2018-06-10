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

namespace Puzzle.NPersist.Framework.Remoting.Marshaling 
{
	/// <summary>
	/// Summary description for MarshalUol.
	/// </summary>
	[Serializable()]
	public class MarshalUol
	{
		public MarshalUol()
		{
		}

		#region Property  Url
		
		private string url = "";
		
		public string Url
		{
			get => this.url;
		    set => this.url = value;
		}
		
		#endregion

		#region Property  Key
		
		private string key = "";
		
		public string Key
		{
			get => this.key;
		    set => this.key = value;
		}
		
		#endregion
	
		#region Property  Id
		
		private string id = "";
		
		public string Id
		{
			get => this.id;
		    set => this.id = value;
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
