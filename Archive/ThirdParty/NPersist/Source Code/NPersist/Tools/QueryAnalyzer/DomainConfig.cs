// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Tools.QueryAnalyzer
{
	/// <summary>
	/// Summary description for DomainConfig.
	/// </summary>
	public class DomainConfig
	{
		public DomainConfig()
		{
		}

		private string name;
		
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		private string assemblyPath = "";
		
		public string AssemblyPath
		{
			get { return this.assemblyPath; }
			set { this.assemblyPath = value; }
		}

		private string mapPath = "";
		
		public string MapPath
		{
			get { return this.mapPath; }
			set { this.mapPath = value; }
		}

		private string connectionString = "";
		
		public string ConnectionString
		{
			get { return this.connectionString; }
			set { this.connectionString = value; }
		}
		
		private string xmlPath = "";
		
		public string XmlPath
		{
			get { return this.xmlPath; }
			set { this.xmlPath = value; }
		}

		public override string ToString()
		{
			return name;
		}

	}
}
