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
	/// Summary description for MarshalUnitOfWork.
	/// </summary>
	[Serializable] public class MarshalUnitOfWork
	{
		public MarshalUnitOfWork()
		{
		}

		private ArrayList updateObjects = new ArrayList() ;
		private ArrayList insertObjects = new ArrayList() ;
		private ArrayList removeObjects = new ArrayList() ;
		
		[XmlArrayItem(typeof(MarshalObject))] public ArrayList UpdateObjects
		{
			get { return this.updateObjects; }
			set { this.updateObjects = value; }
		}
		
		[XmlArrayItem(typeof(MarshalObject))] public ArrayList InsertObjects
		{
			get { return this.insertObjects; }
			set { this.insertObjects = value; }
		}

		[XmlArrayItem(typeof(MarshalObject))] public ArrayList RemoveObjects
		{
			get { return this.removeObjects; }
			set { this.removeObjects = value; }
		}
	}
}
