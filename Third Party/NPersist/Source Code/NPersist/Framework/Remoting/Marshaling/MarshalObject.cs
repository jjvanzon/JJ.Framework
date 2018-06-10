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
	/// Summary description for MarshalObject.
	/// </summary>
	[Serializable()] public class MarshalObject 
	{
		public MarshalObject()
		{
		}

		private string type = null;
		private string tempId = "";
		private IList properties = new ArrayList() ;
		private IList lists = new ArrayList() ;
		private IList references = new ArrayList() ;
		private IList referenceLists = new ArrayList() ;

		public string Type
		{
			get => this.type;
		    set => this.type = value;
		}

		public string TempId
		{
			get => this.tempId;
		    set => this.tempId = value;
		}

		[XmlArrayItem(typeof(MarshalProperty))] public IList Properties 
		{
			get => this.properties;
		    set => this.properties = value;
		}

				[XmlArrayItem(typeof(MarshalList))] public IList Lists {
					get => this.lists;
				    set => this.lists = value;
				}

		[XmlArrayItem(typeof(MarshalReference))] public IList References 
		{
			get => this.references;
		    set => this.references = value;
		}

		[XmlArrayItem(typeof(MarshalReferenceList))] public IList ReferenceLists 
		{
			get => this.referenceLists;
		    set => this.referenceLists = value;
		}


		public MarshalProperty GetProperty(string name)
		{
			foreach (MarshalProperty mp in this.properties)
			{
				if (mp.Name == name)
					return mp;
			}
			return null;
		}

		public MarshalReference GetReference(string name)
		{
			foreach (MarshalReference mr in this.references)
			{
				if (mr.Name == name)
					return mr;
			}
			return null;
		}


	}
}
