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
	/// Summary description for MarshalReference.
	/// </summary>
	[Serializable()] public class MarshalReference 
	{
		public MarshalReference()
		{
		}

		private string name = "";
		private bool isNull = false;
		private bool wasNull = false;
		private bool hasOriginal = false;
		private MarshalReferenceValue value = new MarshalReferenceValue();
		private MarshalReferenceValue originalValue = new MarshalReferenceValue();

		#region Property  Type
		
		private string type;
		
		public string Type
		{
			get => this.type;
		    set => this.type = value;
		}
		
		#endregion

		#region Property  OriginalType
		
		private string originalType;
		
		public string OriginalType
		{
			get => this.originalType;
		    set => this.originalType = value;
		}
		
		#endregion

		public string Name
		{
			get => this.name;
		    set => this.name = value;
		}
		
		public bool IsNull
		{
			get => this.isNull;
		    set => this.isNull = value;
		}
		
		public bool WasNull
		{
			get => this.wasNull;
		    set => this.wasNull = value;
		}

		public bool HasOriginal
		{
			get => this.hasOriginal;
		    set => this.hasOriginal = value;
		}

		public MarshalReferenceValue Value
		{
			get => this.value;
		    set => this.value = value;
		}
		
		public MarshalReferenceValue OriginalValue
		{
			get => this.originalValue;
		    set => this.originalValue = value;
		}

	
	}
}
