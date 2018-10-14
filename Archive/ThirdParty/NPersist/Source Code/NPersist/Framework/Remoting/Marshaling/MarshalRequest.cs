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
	/// Summary description for MarshalRequest.
	/// </summary>
	[Serializable()] public class MarshalRequest
	{
		public MarshalRequest()
		{
		}

		private string method;
		
		public string Method
		{
			get => this.method;
		    set => this.method = value;
		}

		private ArrayList parameters;
		
		public ArrayList Parameters
		{
			get => this.parameters;
		    set => this.parameters = value;
		}

		public MarshalParameter GetParameter(string name)
		{
			name = name.ToLower();
			foreach (MarshalParameter mp in parameters)
			{
				if (mp.Name.ToLower() == name)
				{
					return mp;	
				}
			}
			return null;
		}
	}
}
