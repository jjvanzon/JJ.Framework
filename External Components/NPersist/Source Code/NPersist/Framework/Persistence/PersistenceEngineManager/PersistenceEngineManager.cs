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
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Remoting.WebService.Client;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for PersistenceEngineManager.
	/// </summary>
	public class PersistenceEngineManager : ContextChild, IPersistenceEngineManager
	{
		public PersistenceEngineManager()
		{
		}

		private Hashtable dataSourcePersistenceEngines = new Hashtable() ;

		#region Persistence Engines

		#region Property  DefaultPersistenceEngine
		
		private IPersistenceEngine defaultPersistenceEngine;
		
		public IPersistenceEngine DefaultPersistenceEngine
		{
			get
			{
				if (this.defaultPersistenceEngine == null)
				{
					return this.ObjectRelationalPersistenceEngine;
				}
				return this.defaultPersistenceEngine;
			}
			set
			{
				this.defaultPersistenceEngine = value;
				if (value != null)
				{
					value.Context = this.Context;
				}
			}
		}
		
		#endregion

		#region Property  ObjectRelationalPersistenceEngine
		
		private IPersistenceEngine objectRelationalPersistenceEngine;
		
		public IPersistenceEngine ObjectRelationalPersistenceEngine
		{
			get
			{
				if (this.objectRelationalPersistenceEngine == null)
				{
					this.objectRelationalPersistenceEngine = new SqlEngineManager();
					this.objectRelationalPersistenceEngine.Context = this.Context;

				}
				return this.objectRelationalPersistenceEngine;
			}
			set
			{
				this.objectRelationalPersistenceEngine = value;
				if (value != null)
				{
					value.Context = this.Context;
				}
			}
		}
		
		#endregion

		#region Property  ObjectDocumentPersistenceEngine
		
		private IPersistenceEngine objectDocumentPersistenceEngine;
		
		public IPersistenceEngine ObjectDocumentPersistenceEngine
		{
			get
			{
				if (this.objectDocumentPersistenceEngine == null)
				{
					this.objectDocumentPersistenceEngine = new DocumentPersistenceEngine();
					this.objectDocumentPersistenceEngine.Context = this.Context;

				}
				return this.objectDocumentPersistenceEngine;
			}
			set
			{
				this.objectDocumentPersistenceEngine = value;
				if (value != null)
				{
					value.Context = this.Context;
				}
			}
		}
		
		#endregion

		#region Property  ObjectServicePersistenceEngine
		
		private IPersistenceEngine objectServicePersistenceEngine;
		
		public IPersistenceEngine ObjectServicePersistenceEngine
		{
			get
			{
				if (this.objectServicePersistenceEngine == null)
				{
					this.objectServicePersistenceEngine = new WebServiceRemotingEngine();
					this.objectServicePersistenceEngine.Context = this.Context;

				}
				return this.objectServicePersistenceEngine;
			}
			set
			{
				this.objectServicePersistenceEngine = value;
				if (value != null)
				{
					value.Context = this.Context;
				}
			}
		}
		
		#endregion

		#region Property  ObjectObjectPersistenceEngine
		
		private IPersistenceEngine objectObjectPersistenceEngine;
		
		public IPersistenceEngine ObjectObjectPersistenceEngine
		{
			get
			{
				if (this.objectObjectPersistenceEngine == null)
				{
					//TODO: null is no good ofc :-)
                    this.objectObjectPersistenceEngine = new ObjectPersistenceEngine(null);
                    this.objectObjectPersistenceEngine.Context = this.Context;
				}
				return this.objectObjectPersistenceEngine;
			}
			set
			{
				this.objectObjectPersistenceEngine = value;
				if (value != null)
				{
					value.Context = this.Context;
				}
			}
		}
		
		#endregion


		#endregion

		public virtual IPersistenceEngine GetPersistenceEngine(ISourceMap sourceMap)
		{
			if (sourceMap == null)
				throw new ArgumentException("sourceMap");

			IPersistenceEngine persistenceEngine = (IPersistenceEngine) dataSourcePersistenceEngines[sourceMap];
			if (persistenceEngine == null)
			{
				persistenceEngine = GetPersistenceEngine(sourceMap.PersistenceType);
                dataSourcePersistenceEngines[sourceMap] = persistenceEngine;
            }
			return persistenceEngine;
		}

		public virtual void SetPersistenceEngine(ISourceMap sourceMap, IPersistenceEngine persistenceEngine)
		{
			dataSourcePersistenceEngines[sourceMap] = persistenceEngine	;
			persistenceEngine.Context = this.Context;
		}

		
		public void Begin()
		{
			foreach (ISourceMap sourceMap in this.Context.DomainMap.SourceMaps )
			{
				GetPersistenceEngine(sourceMap).Begin();				
			}
		}

		public void Commit()
		{
			foreach (ISourceMap sourceMap in this.Context.DomainMap.SourceMaps )
			{
				GetPersistenceEngine(sourceMap).Commit();				
			}
		}

		public void Abort()
		{
			foreach (ISourceMap sourceMap in this.Context.DomainMap.SourceMaps )
			{
				GetPersistenceEngine(sourceMap).Abort();				
			}
		}

		public virtual IPersistenceEngine GetPersistenceEngine(PersistenceType persistenceType)
		{
			if (persistenceType == PersistenceType.Default)
			{
				return DefaultPersistenceEngine;
			}
			else if (persistenceType == PersistenceType.ObjectDocument )
			{
				return ObjectDocumentPersistenceEngine;
			}
			else if (persistenceType == PersistenceType.ObjectObject  )
			{
				return ObjectObjectPersistenceEngine;
			}
			else if (persistenceType == PersistenceType.ObjectRelational  )
			{
				return ObjectRelationalPersistenceEngine;
			}
			else if (persistenceType == PersistenceType.ObjectService  )
			{
				return ObjectServicePersistenceEngine;
			}
			return null;
		}

        public virtual void TouchTable(ITableMap tableMap, int exceptionLimit)
        {
            GetPersistenceEngine(tableMap.SourceMap).TouchTable(tableMap, exceptionLimit);
        }

		public virtual void LoadObject(ref object obj)
		{
			GetPersistenceEngine(GetSourceMap(obj)).LoadObject(ref obj);
		}

		public virtual void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue)
		{
			GetPersistenceEngine(GetSourceMap(obj)).LoadObjectByKey(ref obj, keyPropertyName, keyValue);
		}

		public virtual void InsertObject(object obj, IList stillDirty)
		{
			GetPersistenceEngine(GetSourceMap(obj)).InsertObject(obj, stillDirty);
		}

		public virtual void RemoveObject(object obj)
		{
			GetPersistenceEngine(GetSourceMap(obj)).RemoveObject(obj);
		}

		public virtual void UpdateObject(object obj, IList stillDirty)
		{
			GetPersistenceEngine(GetSourceMap(obj)).UpdateObject(obj, stillDirty);
		}

		public virtual void LoadProperty(object obj, string propertyName)
		{
			GetPersistenceEngine(GetSourceMap(obj, propertyName)).LoadProperty(obj, propertyName);
		}


		public virtual IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj)
		{
			return GetPersistenceEngine(GetSourceMap(obj)).GetObjectsOfClassWithUniReferencesToObject(type, obj);
		}


		#region Query

		public IList LoadObjects(IQuery query, IList listToFill)
		{
			return GetPersistenceEngine(GetSourceMap(query.PrimaryType)).LoadObjects(query, listToFill);
		}

        public IList LoadObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill)
        {
            return GetPersistenceEngine(GetSourceMap(type)).LoadObjects(type, refreshBehavior, listToFill);
        }
		
		public DataTable LoadDataTable(IQuery query)
		{
			return GetPersistenceEngine(GetSourceMap(query.PrimaryType)).LoadDataTable(query);
		}

		public IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill)
		{
			return GetPersistenceEngine(GetSourceMap(type)).GetObjectsBySql(sqlQuery, type, idColumns, typeColumns, propertyColumnMap, parameters, refreshBehavior, listToFill);			
		}

		#endregion

		protected virtual ISourceMap GetSourceMap(object obj)
		{
			return this.Context.DomainMap.MustGetClassMap(obj.GetType()).GetSourceMap();
		}

		protected virtual ISourceMap GetSourceMap(Type type)
		{
			return this.Context.DomainMap.MustGetClassMap(type).GetSourceMap();
		}

		protected virtual ISourceMap GetSourceMap(object obj, string propertyName)
		{
			return this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName).GetSourceMap();
		}

	}
}
