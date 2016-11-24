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
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Remoting.Marshaling
{
	/// <summary>
	/// Summary description for MarshalQuery.
	/// </summary>
	[Serializable()]
	public class MarshalQuery
	{
		public MarshalQuery()
		{
		}

		private ArrayList parameters = new ArrayList() ;

		[XmlArrayItem(typeof(MarshalParameter))] public ArrayList Parameters
		{
			get { return this.parameters; }
			set { this.parameters = value; }
		}	

		#region Property  PrimitiveType
		
		private string primitiveType;
		
		public string PrimitiveType
		{
			get { return this.primitiveType; }
			set { this.primitiveType = value; }
		}
		
		#endregion

		#region Property  QueryType
		
		private string queryType = "NPathQuery";
		
		public string QueryType
		{
			get { return this.queryType; }
			set { this.queryType = value; }
		}
		
		#endregion

		#region Property  QueryString
		
		private string queryString = "";
		
		public string QueryString
		{
			get { return this.queryString; }
			set { this.queryString = value; }
		}
		
		#endregion

	}
}
