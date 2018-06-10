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
using System.Data;
using System.Xml.Serialization;

namespace Puzzle.NPersist.Framework.Remoting.Marshaling
{
	/// <summary>
	/// Summary description for MarshalParameter.
	/// </summary>
	[Serializable] public class MarshalParameter
	{
		public MarshalParameter()
		{
		}

		private string name;
		
		public string Name
		{
			get => this.name;
		    set => this.name = value;
		}

		private string value;
		
		public string Value
		{
			get => this.value;
		    set => this.value = value;
		}

		#region Property  ReferenceValue
		
		private MarshalReferenceValue referenceValue;
		
		public MarshalReferenceValue ReferenceValue
		{
			get => this.referenceValue;
		    set => this.referenceValue = value;
		}
		
		#endregion

		#region Property  DbType
		
		private DbType dbType;
		
		public DbType DbType
		{
			get => this.dbType;
		    set => this.dbType = value;
		}
		
		#endregion
	}
}
