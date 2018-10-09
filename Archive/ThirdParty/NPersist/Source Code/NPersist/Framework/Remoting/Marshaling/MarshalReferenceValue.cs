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
	/// Summary description for MarshalReferenceValue.
	/// </summary>
	[Serializable()] public class MarshalReferenceValue 
	{
		public MarshalReferenceValue()
		{
		}

		private ArrayList referenceProperties = new ArrayList() ;
		private ArrayList referenceReferences = new ArrayList() ;

		[XmlArrayItem(typeof(MarshalProperty))] public ArrayList ReferenceProperties
		{
			get => this.referenceProperties;
		    set => this.referenceProperties = value;
		}

		[XmlArrayItem(typeof(MarshalReference))] public ArrayList ReferenceReferences
		{
			get => this.referenceReferences;
		    set => this.referenceReferences = value;
		}

		public MarshalProperty GetReferenceProperty(string name)
		{
			foreach (MarshalProperty mp in this.referenceProperties)
			{
				if (mp.Name == name)
					return mp;
			}
			return null;
		}

		public MarshalReference GetReferenceReference(string name)
		{
			foreach (MarshalReference mr in this.referenceReferences)
			{
				if (mr.Name == name)
					return mr;
			}
			return null;
		}

	}
}
