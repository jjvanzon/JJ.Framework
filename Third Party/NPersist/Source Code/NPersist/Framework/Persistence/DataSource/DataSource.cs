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
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Reflection;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class DataSource : IDataSource
	{
		private IDataSourceManager m_DataSourceManager;
		private string m_Name = "";
		private ISourceMap m_SourceMap;
		private IDbConnection m_Connection;
		private bool m_KeepConnectionOpen = false;

		public virtual IDataSourceManager DataSourceManager
		{
			get { return m_DataSourceManager; }
			set { m_DataSourceManager = value; }
		}

		public virtual string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public virtual ISourceMap SourceMap
		{
			get { return m_SourceMap; }
			set { m_SourceMap = value; }
		}

        public virtual bool HasConnection()
        {
            return m_Connection != null;
        }

        public virtual bool HasOpenConnection()
        {
            if (m_Connection == null)
                return false;

            return m_Connection.State.Equals(ConnectionState.Open);
        }

		public virtual IDbConnection GetConnection()
		{
			InitConnection();
			OpenConnection();
			return m_Connection;
		}

		public virtual void ReturnConnection()
		{
			if (!(m_KeepConnectionOpen))
			{
				CloseConnection();
			}
		}

		public virtual void SetConnection(IDbConnection connection)
		{
			CloseConnection();
			m_Connection = connection;
		}

		public virtual bool KeepConnectionOpen
		{
			get { return m_KeepConnectionOpen; }
			set
			{
				m_KeepConnectionOpen = value;
				if (!(m_KeepConnectionOpen))
				{
					CloseConnection();
				}
			}
		}

		protected virtual void InitConnection()
		{
			if (m_Connection != null)
			{
				return;
			}
			ProviderType providerType = m_SourceMap.ProviderType;
			string connectionString = m_SourceMap.ConnectionString;
			if (providerType == ProviderType.SqlClient)
			{
				m_Connection = new SqlConnection(connectionString);
			}
			else if (providerType == ProviderType.OleDb)
			{
				m_Connection = new OleDbConnection(connectionString);
			}
			else if (providerType == ProviderType.Odbc)
			{
				m_Connection = new OdbcConnection(connectionString);
			}
			else if (providerType == ProviderType.Bdp)
			{
				m_Connection = LoadBorlandDataProvider(connectionString);
			}
			else if (providerType == ProviderType.Other)
			{
				if (m_Connection == null)
				{
					throw new NPersistException("'Other' provider type specified, but no Connection object from this type has been set!"); // do not localize
				}
			}
			else
			{
				throw new NPersistException("Unknown provider type specified!"); // do not localize
			}
		}

		protected virtual void OpenConnection()
		{
			if (m_Connection != null)
			{
				if (m_Connection.State == ConnectionState.Closed)
				{
					m_Connection.Open();
				}
			}
		}

		protected virtual void CloseConnection()
		{
			if (m_Connection != null)
			{
				if (!(m_Connection.State == ConnectionState.Closed))
				{
					m_Connection.Close();
				}
			}
		}

		protected virtual void DisposeConnection()
		{
			if (m_Connection != null)
			{
				CloseConnection();
				m_Connection.Dispose();
			}
		}

		public virtual void Dispose()
		{
			DisposeConnection();
			GC.SuppressFinalize(this);
		}

		protected IDbConnection LoadBorlandDataProvider(string connectionString)
		{
			string assemblyPath = m_SourceMap.ProviderAssemblyPath;
			string cnName = m_SourceMap.ProviderConnectionTypeName;
			if (assemblyPath.Length < 1)
			{
				assemblyPath = "Borland.Data.Provider";
			}
			if (cnName.Length < 1)
			{
				cnName = "Borland.Data.Provider.BdpConnection";
			}
			Assembly asm = m_DataSourceManager.Context.AssemblyManager.GetAssembly(assemblyPath);
			IDbConnection cn = (IDbConnection) asm.CreateInstance(cnName);
			cn.ConnectionString = connectionString;
			return cn;
		}

		protected IDbConnection LoadOtherDataProvider(string connectionString)
		{
			string assemblyPath = m_SourceMap.ProviderAssemblyPath;
			string cnName = m_SourceMap.ProviderConnectionTypeName;
			if (assemblyPath.Length < 1)
			{
				throw new NPersistException("Path to assembly containing 'other' data provider must be specified in ISourceMap.ProviderAssemblyPath"); // do not localize
			}
			if (cnName.Length < 1)
			{
				throw new NPersistException("Name of connection class in 'other' data provider must be specified in ISourceMap.ProviderConnectionTypeName"); // do not localize
			}
			Assembly asm = m_DataSourceManager.Context.AssemblyManager.GetAssembly(assemblyPath);
			IDbConnection cn = (IDbConnection) asm.CreateInstance(cnName);
			cn.ConnectionString = connectionString;
			return cn;
		}
	}
}