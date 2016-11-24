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
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Framework.Attributes
{
	/// <summary>
	/// Summary description for SourceMapAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	public class SourceMapAttribute : Attribute
	{
		public SourceMapAttribute()
		{
		}


		#region Private Member Variables

		private PersistenceType m_PersistenceType = PersistenceType.Default;
		private bool m_Compute = false;

		//O/R Mapping
		private string m_name = "";
		private SourceType m_SourceType = SourceType. MSSqlServer;
		private ProviderType m_ProviderType = ProviderType. SqlClient;
		private string m_ConnectionString = "";
		private string m_Schema = "dbo";
		private string m_Catalog = "";
		private string m_ProviderAssemblyPath = "";
		private string m_ProviderConnectionTypeName = "";
		private string m_LockTable = "";

		//O/D Mapping
		private string m_DocPath = "";
		private string m_DocRoot = "";
		private string m_DocEncoding = "";

		//O/S Mapping
		private string m_Url = "";
		private string m_DomainKey = "";

		#endregion


		#region General

		#region Property  PersistenceType
				
		public PersistenceType PersistenceType
		{
			get { return this.m_PersistenceType; }
			set { this.m_PersistenceType = value; }
		}
		
		#endregion

		#region Property  Compute
				
		public bool Compute
		{
			get { return this.m_Compute; }
			set { this.m_Compute = value; }
		}
		
		#endregion

		#endregion

		#region Object/Relational Mapping

		public virtual string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public virtual SourceType SourceType
		{
			get { return m_SourceType; }
			set { m_SourceType = value; }
		}

		public virtual ProviderType ProviderType
		{
			get { return m_ProviderType; }
			set { m_ProviderType = value; }
		}

		public virtual string ConnectionString
		{
			get { return m_ConnectionString; }
			set { m_ConnectionString = value; }
		}

		public virtual string Schema
		{
			get { return m_Schema; }
			set { m_Schema = value; }
		}

		public virtual string Catalog
		{
			get { return m_Catalog; }
			set { m_Catalog = value; }
		}

		public virtual string ProviderAssemblyPath
		{
			get { return m_ProviderAssemblyPath; }
			set { m_ProviderAssemblyPath = value; }
		}

		public virtual string ProviderConnectionTypeName
		{
			get { return m_ProviderConnectionTypeName; }
			set { m_ProviderConnectionTypeName = value; }
		}

		public virtual string LockTable
		{
			get { return m_LockTable; }
			set { m_LockTable = value; }
		}

		#endregion

		#region Object/Object Mapping

		#endregion

		#region Object/Document Mapping
		
		public virtual string DocPath
		{
			get { return m_DocPath; }
			set { m_DocPath = value; }
		}
		
		public virtual string DocRoot
		{
			get { return m_DocRoot; }
			set { m_DocRoot = value; }
		}

		public virtual string DocEncoding
		{
			get { return m_DocEncoding; }
			set { m_DocEncoding = value; }
		}

		#endregion

		#region Object/Service Mapping

		public string Url
		{
			get { return this.m_Url; }
			set { this.m_Url = value; }
		}

		public string DomainKey
		{
			get { return this.m_DomainKey; }
			set { this.m_DomainKey = value; }
		}

		#endregion


	}
}
