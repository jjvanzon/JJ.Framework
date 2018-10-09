using Puzzle.NPersist.Framework.Enumerations;
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

		#region Property  UseObjectToString
		
		private bool useObjectToString = false;
		
		public bool UseObjectToString
		{
			get { return this.useObjectToString; }
			set { this.useObjectToString = value; }
		}
		
		#endregion

		private string mapPath = "";
		
		public string MapPath
		{
			get { return this.mapPath; }
			set { this.mapPath = value; }
		}

		#region Property  PersistenceType
		
		private PersistenceType persistenceType = PersistenceType.ObjectRelational;
		
		public PersistenceType PersistenceType
		{
			get { return this.persistenceType; }
			set { this.persistenceType = value; }
		}
		
		#endregion

		#region Property  UseCustomDataSource
		
		private bool useCustomDataSource = false;
		
		public bool UseCustomDataSource
		{
			get { return this.useCustomDataSource; }
			set { this.useCustomDataSource = value; }
		}
		
		#endregion

		private SourceType sourceType = SourceType.MSSqlServer;
		
		public SourceType SourceType
		{
			get { return this.sourceType; }
			set { this.sourceType = value; }
		}

		private ProviderType providerType = ProviderType.SqlClient;
		
		public ProviderType ProviderType
		{
			get { return this.providerType; }
			set { this.providerType = value; }
		}


		private string connectionString = "";
		
		public string ConnectionString
		{
			get { return this.connectionString; }
			set { this.connectionString = value; }
		}

		#region Property  Url
		
		private string url = "";
		
		public string Url
		{
			get { return this.url; }
			set { this.url = value; }
		}
		
		#endregion

		#region Property  DomainKey
		
		private string domainKey = "";
		
		public string DomainKey
		{
			get { return this.domainKey; }
			set { this.domainKey = value; }
		}
		
		#endregion
		
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
