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
using System.Xml.Serialization;

namespace Puzzle.NPersist.Framework.Remoting.Marshaling
{
	/// <summary>
	/// Summary description for MarshalObjectList.
	/// </summary>
	[Serializable()] public class MarshalObjectList 
	{
		public MarshalObjectList()
		{
		}

		private ArrayList objects = new ArrayList() ;

		[XmlArrayItem(typeof(MarshalObject))] public ArrayList Objects
		{
			get => this.objects;
		    set => this.objects = value;
		}
	}
}
