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
	/// Summary description for MarshalProperty.
	/// </summary>
	[Serializable()] public class MarshalProperty 
	{
		public MarshalProperty()
		{

		}

		private string name = "";
		private bool isNull = false;
		private bool wasNull = false;
		private string value = "";
		private string originalValue = "";
		private bool hasOriginal = false;

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

		public string Value
		{
			get => this.value;
		    set => this.value = value;
		}
		
		public string OriginalValue
		{
			get => this.originalValue;
		    set => this.originalValue = value;
		}

		public bool HasOriginal
		{
			get => this.hasOriginal;
		    set => this.hasOriginal = value;
		}

	}
}
