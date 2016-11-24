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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations ;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Querying;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class SqlEngineManager : ContextChild, ISqlEngineManager
	{
		private ISqlEngine m_SqlEngineMSSqlServer;
		private ISqlEngine m_SqlEngineMSAccess;
		private ISqlEngine m_SqlEngineOracle;
		private ISqlEngine m_SqlEngineOther;

		private IList transactions = new ArrayList();
 
		public void Begin()
		{
			if (this.Context.AutoTransactions)
			{
				foreach (ISourceMap sourceMap in this.Context.DomainMap.SourceMaps )
				{
					if (sourceMap.PersistenceType == PersistenceType.Default || sourceMap.PersistenceType == PersistenceType.ObjectRelational )
					{
						IDataSource dataSource = this.Context.GetDataSource(sourceMap);
						if (this.Context.HasTransactionPending(dataSource) == false)
						{
							ITransaction transaction = this.Context.BeginTransaction(dataSource);
							transaction.AutoPersistAllOnCommit = false;
							transactions.Add(transaction);
						}
					}
				}				
			}
		}
            
		public void Commit()
		{
			foreach (ITransaction transaction in transactions)
			{

				try
				{
					transaction.Commit() ;		
				}
				catch (Exception ex)
				{
					throw new NPersistException("Transaction against data source " + transaction.DataSource.SourceMap.Name + " failed during commit!", ex);
				}			
			}
			
			transactions.Clear() ;
		}

		public void Abort()
		{
			foreach (ITransaction transaction in transactions)
			{
				try
				{
					transaction.Rollback() ;					
				}
				catch (Exception ex)
				{
					throw new NPersistException("Transaction against data source " + transaction.DataSource.SourceMap.Name + " failed but was not rolled back!", ex);
				}					
			}

			transactions.Clear() ;
		}

		public virtual ISqlEngine GetSqlEngine(SourceType sourceType)
		{
			if (sourceType == SourceType.MSSqlServer)
			{
				return GetSqlEngineMSSqlServer();
			}
			else if (sourceType == SourceType.MSAccess)
			{
				return GetSqlEngineMSAccess();
			}
			else if (sourceType == SourceType.Oracle)
			{
				return GetSqlEngineOracle();
			}
			else if (sourceType == SourceType.Other)
			{
				return GetSqlEngineOther();
			}
			return null;
		}

        public virtual void TouchTable(ITableMap tableMap, int exceptionLimit)
        {
            GetSqlEngine(tableMap.SourceMap.SourceType).TouchTable(tableMap, exceptionLimit);
        }


		public virtual void LoadObject(ref object obj)
		{
			GetSqlEngine(GetSourceType(obj)).LoadObject(ref obj);
		}

		public virtual void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue)
		{
			GetSqlEngine(GetSourceType(obj)).LoadObjectByKey(ref obj, keyPropertyName, keyValue);
		}

		public virtual void InsertObject(object obj, IList stillDirty)
		{
			GetSqlEngine(GetSourceType(obj)).InsertObject(obj, stillDirty);
		}

		public virtual void RemoveObject(object obj)
		{
			GetSqlEngine(GetSourceType(obj)).RemoveObject(obj);
		}

		public IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj)
		{
			return GetSqlEngine(GetSourceType(obj)).GetObjectsOfClassWithUniReferencesToObject(type, obj);
		}

		public virtual void UpdateObject(object obj, IList stillDirty)
		{
			GetSqlEngine(GetSourceType(obj)).UpdateObject(obj, stillDirty);
		}

		public virtual void LoadProperty(object obj, string propertyName)
		{
			GetSqlEngine(GetSourceType(obj, propertyName)).LoadProperty(obj, propertyName);
		}


		#region Query

		//		public IList LoadObjects(IQuery query, Type type, IList parameters, RefreshBehaviorType refreshBehavior)
		//		{
		//			return GetSqlEngine(GetSourceType(type)).LoadObjects(query, type, parameters, refreshBehavior);
		//		}

        public virtual IList LoadObjects(IQuery query, IList listToFill)
		{
			return GetSqlEngine(GetSourceType(query.PrimaryType)).LoadObjects(query, listToFill);
		}

        public virtual IList LoadObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill)
        {
            if (type == null)
                throw new ArgumentNullException("type");

			//Thanks to Kenken for a bug fix here!
            string npath = "Select * From " + type.FullName;
            return LoadObjects(new NPathQuery(npath, type, null, refreshBehavior), listToFill);
        }

        public virtual DataTable LoadDataTable(IQuery query)
		{
			return GetSqlEngine(GetSourceType(query.PrimaryType)).LoadDataTable(query);
		}

        public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill)
		{
			return GetSqlEngine(GetSourceType(type)).GetObjectsBySql(sqlQuery, type, idColumns, typeColumns, propertyColumnMap, parameters, refreshBehavior, listToFill);			
		}

		#endregion

		protected virtual ISqlEngine GetSqlEngineMSSqlServer()
		{
			if (m_SqlEngineMSSqlServer == null)
			{
				m_SqlEngineMSSqlServer = new SqlEngineMSSqlServer();
				m_SqlEngineMSSqlServer.SqlEngineManager = this;
			}
			return m_SqlEngineMSSqlServer;
		}

		protected virtual ISqlEngine GetSqlEngineMSAccess()
		{
			if (m_SqlEngineMSAccess == null)
			{
				m_SqlEngineMSAccess = new SqlEngineMsAccess();
				m_SqlEngineMSAccess.SqlEngineManager = this;
			}
			return m_SqlEngineMSAccess;
		}

		protected virtual ISqlEngine GetSqlEngineOracle()
		{
			if (m_SqlEngineOracle == null)
			{
				m_SqlEngineOracle = new SqlEngineOracle();
				m_SqlEngineOracle.SqlEngineManager = this;
			}
			return m_SqlEngineOracle;
		}

		protected virtual ISqlEngine GetSqlEngineOther()
		{
			if (m_SqlEngineOther == null)
			{
				m_SqlEngineOther = new SqlEngineBase();
				m_SqlEngineOther.SqlEngineManager = this;
			}
			return m_SqlEngineOther;
		}

		protected virtual SourceType GetSourceType(object obj)
		{
			return this.Context.DomainMap.MustGetClassMap(obj.GetType()).GetSourceMap().SourceType;
		}

		protected virtual SourceType GetSourceType(Type type)
		{
			return this.Context.DomainMap.MustGetClassMap(type).GetSourceMap().SourceType;
		}

		protected virtual SourceType GetSourceType(object obj, string propertyName)
		{
			return this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName).GetSourceMap().SourceType;
		}


	}
}