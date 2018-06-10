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
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Aop;
using Puzzle.NCore.Framework.Compression;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.IdentityGeneration;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NCore.Framework.Logging;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPath.Framework;
using Puzzle.NPersist.Framework.NPath;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Mapping.Serialization;
using Puzzle.NPersist.Framework.Remoting.Formatting;
using Puzzle.NPersist.Framework.Remoting.WebService.Client;
using Puzzle.NPersist.Framework.Validation;
#if NET2
using System.Collections.Generic;
#endif

namespace Puzzle.NPersist.Framework
{
	/// <summary>
	/// Summary description for Context.
	/// </summary>
	public class Context : IContext, IObserver
	{
		#region Private Member Variables

		//ObjectEventArgs
		private ILogManager m_LogManager;
		private IInterceptor m_Interceptor;
		private IProxyFactory m_ProxyFactory;
		private IPersistenceManager m_PersistenceManager;
		private IObjectManager m_ObjectManager;
		private IListManager m_ListManager;
		private IDomainMap m_DomainMap;
		private IIdentityMap m_IdentityMap;
		private IObjectCacheManager m_ObjectCacheManager;
		private IReadOnlyObjectCacheManager m_ReadOnlyObjectCacheManager;
		private IUnitOfWork m_UnitOfWork;
		private IInverseManager m_InverseManager;
		private IEventManager m_EventManager;
		private IDataSourceManager m_DataSourceManager;
		private IPersistenceEngine m_PersistenceEngine;
		private IPersistenceEngineManager m_PersistenceEngineManager;
		private ISqlExecutor m_SqlExecutor;
		private INPathEngine m_NPathEngine;
		private IObjectQueryEngine m_ObjectQueryEngine;
		private IAssemblyManager m_AssemblyManager;
		private IObjectFactory m_ObjectFactory;
		private IObjectCloner m_ObjectCloner;
		private IObjectValidator m_ObjectValidator;
		private Hashtable m_Transactions = new Hashtable();
		private bool m_AutoTransactions = true;
        private DeadlockStrategy m_DeadlockStrategy = DeadlockStrategy.Default;

		private IList conflicts = new ArrayList();
		private Hashtable loadedInLatestQuery = new Hashtable();

		#endregion

		#region Events

		public event BeginningTransactionEventHandler BeginningTransaction;
		public event BegunTransactionEventHandler BegunTransaction;
		public event CommittingTransactionEventHandler CommittingTransaction;
		public event CommittedTransactionEventHandler CommittedTransaction;
		public event RollingbackTransactionEventHandler RollingbackTransaction;
		public event RolledbackTransactionEventHandler RolledbackTransaction;
		public event ExecutedSqlEventHandler ExecutedSql;
		public event ExecutingSqlEventHandler ExecutingSql;
		public event CallingWebServiceEventHandler CallingWebService;
		public event CalledWebServiceEventHandler CalledWebService;
		public event CommittedEventHandler Committed;
		public event CommittingEventHandler Committing;
		public event CreatedObjectEventHandler CreatedObject;
		public event CreatingObjectEventHandler CreatingObject;
		public event InsertedObjectEventHandler InsertedObject;
		public event InsertingObjectEventHandler InsertingObject;
		public event DeletingObjectEventHandler DeletingObject;
		public event DeletedObjectEventHandler DeletedObject;
		public event RemovingObjectEventHandler RemovingObject;
		public event RemovedObjectEventHandler RemovedObject;
		public event CommittingObjectEventHandler CommittingObject;
		public event CommittedObjectEventHandler CommittedObject;
		public event UpdatingObjectEventHandler UpdatingObject;
		public event UpdatedObjectEventHandler UpdatedObject;
		public event GettingObjectEventHandler GettingObject;
		public event GotObjectEventHandler GotObject;
		public event LoadingObjectEventHandler LoadingObject;
		public event LoadedObjectEventHandler LoadedObject;
		public event ReadingPropertyEventHandler ReadingProperty;
		public event ReadPropertyEventHandler ReadProperty;
		public event WritingPropertyEventHandler WritingProperty;
		public event WrotePropertyEventHandler WroteProperty;
		public event LoadingPropertyEventHandler LoadingProperty;
		public event LoadedPropertyEventHandler LoadedProperty;
		public event InstantiatingObjectEventHandler InstantiatingObject;
		public event InstantiatedObjectEventHandler InstantiatedObject;

		#endregion

		#region Constructors

		public Context(IDomainMap domainMap) : base()
		{
			m_DomainMap = domainMap;
			InitManagers();
		}

		public Context(string mapFilePath) : base() => InitManagers(mapFilePath);

	    public Context(Assembly asm) : base() => InitManagers(asm);

	    public Context(Assembly asm, string mapFileResourceName) : base() => InitManagers(asm, mapFileResourceName);

	    public Context(IContext rootContext) : base()
		{
			m_DomainMap = rootContext.DomainMap;
			m_PersistenceEngine = new ObjectPersistenceEngine(rootContext);
			m_PersistenceEngine.Context = this;
			InitManagers(true);
		}

		public Context(string url, string domainKey) : this(url, domainKey, true)
		{			
		}
		
		public Context(string url, string domainKey, bool useCompression) : base()
		{
			WebServiceRemotingEngine webServiceRemotingEngine = new WebServiceRemotingEngine(new XmlFormatter(), url, domainKey, new DefaultWebServiceCompressor(), useCompression);
			m_PersistenceEngine = webServiceRemotingEngine;
			m_DomainMap = webServiceRemotingEngine.GetMap();
			m_PersistenceEngine.Context = this;
			InitManagers(true);
		}

		#region InitManagers Method

		protected virtual void InitManagers(Assembly asm)
		{
			m_DomainMap = Mapping.DomainMap.Load(asm);
			m_DomainMap.Fixate();

			InitManagers();
		}

		protected virtual void InitManagers(Assembly asm, string name)
		{
			if (!(name == ""))
			{
				m_DomainMap = Mapping.DomainMap.Load(asm, name, null);
				m_DomainMap.Fixate();
			}
			InitManagers();
		}

		protected virtual void InitManagers(string mapPath)
		{
			if (!(mapPath == ""))
			{
				m_DomainMap = Mapping.DomainMap.Load(mapPath, null);
				m_DomainMap.Fixate();
			}
			InitManagers();
		}

		protected virtual void InitManagers() => InitManagers(false);

	    protected virtual void InitManagers(bool persistenceEngineIsSet)
		{
			m_Interceptor = new Interceptor();
			m_Interceptor.Context = this;
			m_PersistenceManager = new PersistenceManager();
			m_PersistenceManager.Context = this;
			m_ObjectManager = new DefaultObjectManager();
			m_ObjectManager.Context = this;
			m_ListManager = new ListManager();
			m_ListManager.Context = this;
			m_IdentityMap = new IdentityMap();
			m_IdentityMap.Context = this;
			m_ObjectCacheManager = new DefaultObjectCacheManager();
			m_ObjectCacheManager.Context = this;
			m_ReadOnlyObjectCacheManager = new ReadOnlyObjectCacheManager();
			m_ReadOnlyObjectCacheManager.Context = this;
			m_UnitOfWork = new UnitOfWork();
			m_UnitOfWork.Context = this;
			m_InverseManager = new InverseManager();
			m_InverseManager.Context = this;
			m_EventManager = new EventManager();
			m_EventManager.Context = this;
			m_EventManager.Observer = this;
			IValidationManager validationManager = new ValidationManager();
			m_EventManager.ValidationManager = validationManager;
			validationManager.EventManager = m_EventManager;
			m_DataSourceManager = new DataSourceManager();
			m_DataSourceManager.Context = this;
			m_DataSourceManager.Setup();
			m_SqlExecutor = new SqlExecutor();
			m_SqlExecutor.Context = this;
			m_NPathEngine = new NPathOmegaEngine();
			m_NPathEngine.Context = this;
			m_ObjectQueryEngine = new ObjectQueryEngine();
			m_ObjectQueryEngine.ObjectQueryEngineHelper = new NPersistObjectQueryEngineHelper(this);

	//		m_ObjectQueryEngine.Context = this;
			m_AssemblyManager = new AssemblyManager();
			m_AssemblyManager.Context = this;
			m_ObjectFactory = new AopObjectFactory();
			m_ObjectFactory.Context = this;
			m_ObjectCloner = new ObjectCloner();
			m_ObjectCloner.Context = this;
			m_ObjectValidator = new ObjectValidator();
			m_ObjectValidator.Context = this;
			m_PersistenceEngineManager = new PersistenceEngineManager() ;
			m_PersistenceEngineManager.Context = this;
			
			m_LogManager = new LogManager();

			m_ProxyFactory = new AopProxyFactory() ;
			m_ProxyFactory.Context = this; 
			
			//m_ProxyFactory.Context = this;

			if (persistenceEngineIsSet == false)
				m_PersistenceEngine = m_PersistenceEngineManager;
		}

		#endregion

		#endregion

		#region Public Properties

		public virtual IInterceptor Interceptor
		{
			get => m_Interceptor;
		    set 
			{ 
				m_Interceptor = value; 
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IPersistenceManager PersistenceManager
		{
			get => m_PersistenceManager;
		    set
			{
				m_PersistenceManager = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IProxyFactory ProxyFactory
		{
			get => m_ProxyFactory;
		    set
			{
				m_ProxyFactory = value;	
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IObjectManager ObjectManager
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_ObjectManager;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set
			{
				m_ObjectManager = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IListManager ListManager
		{
			get => m_ListManager;
		    set 
			{ 
				m_ListManager = value; 
				if (value != null)
					value.Context = this;
			}
		}


		public virtual IDomainMap DomainMap
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_DomainMap;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_DomainMap = value;
		}

		public virtual IIdentityMap IdentityMap
		{
			get => m_IdentityMap;
		    set
			{
				m_IdentityMap = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IObjectCacheManager ObjectCacheManager
		{
			get => m_ObjectCacheManager;
		    set
			{
				m_ObjectCacheManager = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IReadOnlyObjectCacheManager ReadOnlyObjectCacheManager
		{
			get => m_ReadOnlyObjectCacheManager;
		    set
			{
				m_ReadOnlyObjectCacheManager = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IUnitOfWork UnitOfWork
		{
			get => m_UnitOfWork;
		    set
			{
				m_UnitOfWork = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IInverseManager InverseManager
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_InverseManager;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set
			{
				m_InverseManager = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IEventManager EventManager
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_EventManager;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set
			{
				m_EventManager = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IDataSourceManager DataSourceManager
		{
			get => m_DataSourceManager;
		    set 
			{ 
				m_DataSourceManager = value; 
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IPersistenceEngine PersistenceEngine
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => this.m_PersistenceEngine;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set
			{
				this.m_PersistenceEngine = value;
				if (value != null)
				{
					value.Context = this;
				} 
			}
		}

		public virtual IPersistenceEngineManager PersistenceEngineManager
		{
			get => m_PersistenceEngineManager;
		    set 
			{ 
				m_PersistenceEngineManager = value; 
				if (value != null)
					value.Context = this;
			}
		}

		public virtual ISqlExecutor SqlExecutor
		{
			get => m_SqlExecutor;
		    set
			{
				m_SqlExecutor = value;
				if (value != null)
					value.Context = this;
			}
		}

		public virtual INPathEngine NPathEngine
		{
			get => m_NPathEngine;
		    set 
			{ 
				m_NPathEngine = value; 
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IObjectQueryEngine ObjectQueryEngine
		{
			get => m_ObjectQueryEngine;
		    set => m_ObjectQueryEngine = value;
		}

		public virtual IAssemblyManager AssemblyManager
		{
			get => m_AssemblyManager;
		    set 
			{ 
				m_AssemblyManager = value; 
				if (value != null)
					value.Context = this;
			}
		}

		public virtual IObjectFactory ObjectFactory
		{
			get => m_ObjectFactory;
		    set 
			{ 				
				m_ObjectFactory = value; 

				if (value != null)
					value.Context = this;
			}
		}

		public virtual IObjectCloner ObjectCloner
		{
			get => m_ObjectCloner;
		    set 
			{ 				
				m_ObjectCloner = value; 

				if (value != null)
					value.Context = this;
			}
		}

		public virtual IObjectValidator ObjectValidator
		{
			get => m_ObjectValidator;
		    set 
			{ 				
				m_ObjectValidator = value; 

				if (value != null)
					value.Context = this;
			}
		}

		public virtual ILogManager LogManager
		{
			get => m_LogManager;
		    set => m_LogManager = value;
		}

		public Notification Notification
		{
			get => this.Interceptor.Notification;
		    set => this.Interceptor.Notification = value;
		}

		public bool AutoTransactions
		{
			get => m_AutoTransactions;
		    set => m_AutoTransactions = value;
		}

        public DeadlockStrategy DeadlockStrategy
        {
            get => m_DeadlockStrategy;
            set => m_DeadlockStrategy = value;
        }

        public DeadlockStrategy GetDeadlockStrategy()
        {
            if (this.DomainMap != null)
                if (this.DomainMap.DeadlockStrategy != DeadlockStrategy.Default)
                    return this.DomainMap.DeadlockStrategy;
            return this.DeadlockStrategy;
        }

        public virtual void TouchTables(IList tables, DeadlockStrategy deadlockStrategy)
        {
            ArrayList tableMaps = new ArrayList();
            ISourceMap sourceMap = this.DomainMap.GetSourceMap();
            foreach (object table in tables)
            {
                if (table is string)
                {
                    if (sourceMap == null)
                        throw new MappingException("No source map found in mapping!");

                    ITableMap tableMap = sourceMap.MustGetTableMap((string)table);
                    tableMaps.Add(tableMap);
                }
                else if (table is ITableMap)
                    tableMaps.Add(table);
                else
                    throw new NPersistException("Only table names (strings) and instances implementing ITableMap may be used in the list passed to the tables parameter!");
            }
            this.UnitOfWork.TouchLockTables(null, 1, deadlockStrategy, tableMaps);
        }


		#region Property  DomainKey
		
		private string domainKey = "";
		
		public string DomainKey
		{
			get => this.domainKey;
		    set => this.domainKey = value;
		}
		
		#endregion
		
		#region Property  OptimisticConcurrencyMode
		
		private OptimisticConcurrencyMode optimisticConcurrencyMode = OptimisticConcurrencyMode.Default ;
		
		public OptimisticConcurrencyMode OptimisticConcurrencyMode
		{
			get => this.optimisticConcurrencyMode;
		    set => this.optimisticConcurrencyMode = value;
		}
		
		#endregion

		#region Property  IdentityGenerators
		
		private Hashtable identityGenerators = new Hashtable() ;
		
		public virtual Hashtable IdentityGenerators => this.identityGenerators;

	    #endregion

		#region Property  IsDisposed
		
		private bool isDisposed = false;
		
		public bool IsDisposed => this.isDisposed;

	    #endregion

		#region Property  IsDirty
		
		public bool IsDirty
		{
			get
			{
				IUnitOfWork uow = this.UnitOfWork ;
				if (uow.GetCreatedObjects().Count > 0)
					return true;
				if (uow.GetDirtyObjects().Count > 0)
					return true;
				if (uow.GetDeletedObjects().Count > 0)
					return true;
				return false;
			}
		}
		
		#endregion
		
		#region Property  Timeout
		
		private int timeout = 0;
		
		public int Timeout
		{
			get => this.timeout;
		    set => this.timeout = value;
		}
		
		#endregion

        #region Property  ParamCounter

        private long paramCounter = 0;

        public long ParamCounter
        {
            get => this.paramCounter;
            set => this.paramCounter = value;
        }

        #endregion

        #region Method  GetNextParamNr

        public virtual long GetNextParamNr()
        {
            paramCounter++;
            if (paramCounter == Int64.MaxValue)  // yeah, right....
                paramCounter = 0;
            return paramCounter;
        }

        #endregion

        #endregion

        #region Public Methods

        public virtual ObjectStatus GetObjectStatus(object obj) => m_ObjectManager.GetObjectStatus(obj);

	    public virtual PropertyStatus GetPropertyStatus(object obj, string propertyName) => m_ObjectManager.GetPropertyStatus(obj, propertyName);

	    public virtual object TryGetObject(object identity, Type type) => TryGetObjectById(identity, type);

	    public virtual object TryGetObject(IQuery query) => TryGetObjectByQuery(query);

	    public virtual object TryGetObject(IQuery query, Type type)
		{
			query.PrimaryType = type;
			return TryGetObjectByQuery(query);
		}

		public virtual object TryGetObject(IQuery query, Type type, IList parameters)
		{
			query.PrimaryType = type;
			query.Parameters = parameters;
			return TryGetObjectByQuery(query);
		}

		public virtual object TryGetObjectById(object identity, Type type)
		{
			object id = EnsureIdentity(identity, type);
			return m_PersistenceManager.GetObject(id, type, false, true);	
		}

		public object TryGetObjectByQuery(IQuery query)
		{
			IList listResults;
			listResults = (IList) GetObjectsByQuery(query);
			if (listResults.Count > 1)
			{
				return null;
			}
			else if (listResults.Count < 1)
			{
				return null;
			}
			else
			{
				return listResults[0];
			}
		}

		public object TryGetObjectByNPath(NPathQuery npathQuery) => TryGetObjectByQuery(npathQuery);

	    public object TryGetObjectByNPath(string npathQuery, Type type) => TryGetObjectByNPath(npathQuery, type, null, RefreshBehaviorType.DefaultBehavior);

	    public object TryGetObjectByNPath(string npathQuery, Type type, IList parameters) => TryGetObjectByNPath(npathQuery, type, parameters, RefreshBehaviorType.DefaultBehavior);

	    public object TryGetObjectByNPath(string npathQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior) => TryGetObjectByQuery(new NPathQuery(npathQuery, type, parameters, refreshBehavior, this));

	    public object TryGetObjectBySql(SqlQuery sqlQuery) => TryGetObjectByQuery(sqlQuery);

	    public object TryGetObjectBySql(string sqlQuery, Type type) => TryGetObjectBySql(sqlQuery, type, null, RefreshBehaviorType.DefaultBehavior);

	    public object TryGetObjectBySql(string sqlQuery, Type type, IList parameters) => TryGetObjectBySql(sqlQuery, type, parameters, RefreshBehaviorType.DefaultBehavior);

	    public object TryGetObjectBySql(string sqlQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior) => TryGetObjectByQuery(new SqlQuery(sqlQuery, type, parameters, refreshBehavior, this));

	    public virtual object TryGetObjectByKey(string keyPropertyName, object keyValue, Type type) => m_PersistenceManager.GetObjectByKey(keyPropertyName, keyValue, type, true);

	    public virtual object GetObject(object identity, Type type) => GetObjectById(identity, type, false);

	    public virtual object GetObject(IQuery query) => GetObjectByQuery(query);

	    public virtual object GetObject(IQuery query, Type type)
		{
			query.PrimaryType = type;
			return GetObjectByQuery(query);
		}

		public virtual object GetObject(IQuery query, Type type, IList parameters)
		{
			query.PrimaryType = type;
			query.Parameters = parameters;
			return GetObjectByQuery(query);
		}

		public virtual object GetObjectById(object identity, Type type)
		{
			bool lazy = false;

			LoadBehavior loadBehavior = this.ObjectManager.GetLoadBehavior(type);
			if (loadBehavior == LoadBehavior.Lazy)
				lazy = true;

			return GetObjectById(identity, type, lazy);
		}

		public virtual object GetObjectById(object identity, Type type, bool lazy)
		{
			object id = EnsureIdentity(identity, type);
			return m_PersistenceManager.GetObject(id, type, lazy);
		}

		protected virtual object EnsureIdentity(object identity, Type type)
		{
			if (identity.GetType().IsAssignableFrom(type))
			{
				return m_ObjectManager.GetObjectIdentity(identity);
			}
			else if (identity is Hashtable)
			{
				return  GetHashtableIdentity((Hashtable) identity, type);
			}

			return identity;
		}

		protected virtual string TransformIdentity(object identity, Type type)
		{
			string id;
			if (identity.GetType().IsAssignableFrom(type))
			{
				id = m_ObjectManager.GetObjectIdentity(identity);
			}
			else if (identity is Hashtable)
			{
				id = GetHashtableIdentity((Hashtable) identity, type);
			}
			else
			{
				try
				{
					id = Convert.ToString(identity);
				}
				catch (Exception ex)
				{
					throw new IdentityNotConvertibleToStringException("Identity must be convertible to string, a hashtable with the names of the identity properties as keys and their values as the values, or be a 'dummy' object of the same type as the object you want to get where the identity property or properties have been set to their correct values!", ex);
				}
			}

			return id;
		}

		protected virtual string GetHashtableIdentity(Hashtable identity, Type type)
		{
			IClassMap classMap = this.DomainMap.MustGetClassMap(type);
			string separator = classMap.GetIdentitySeparator();
			if (separator.Length < 1)
				separator = "|";

			StringBuilder id = new StringBuilder() ;

			foreach (IPropertyMap idPropertyMap in classMap.GetIdentityPropertyMaps() )
			{
				string str = "";
				object value = identity[idPropertyMap.Name];
				if (value == null)
					throw new IdentityNotConvertibleToStringException("Could not find value for property " + idPropertyMap.ToString() + " in supplid composite identity Hashtable!" );

				if (idPropertyMap.ReferenceType == ReferenceType.None)
					str = Convert.ToString(value);
				else
					str = this.ObjectManager.GetObjectIdentity(value) ;			

				id.Append(str + separator);
			}
			if (id.Length > separator.Length)
				id.Length -= separator.Length ;
			return id.ToString(); 
		}

		public virtual object GetObjectById(object identity, Type type, RefreshBehaviorType refreshBehavior) => throw new IAmOpenSourcePleaseImplementMeException("Feature not implemented yet!");

	    public object GetObjectByQuery(IQuery query)
		{
			IList listResults;
			listResults = (IList) GetObjectsByQuery(query);
			if (listResults.Count > 1)
			{
				throw new MultipleObjectsFoundException("Multiple objects matched the supplied query!");
			}
			else if (listResults.Count < 1)
			{
				throw new ObjectNotFoundException("No object matched the supplied query!");
			}
			else
			{
				return listResults[0];
			}
		}

		public object GetObjectByNPath(NPathQuery npathQuery) => GetObjectByQuery(npathQuery);

	    public object GetObjectByNPath(string npathQuery, Type type) => GetObjectByNPath(npathQuery, type, null, RefreshBehaviorType.DefaultBehavior);

	    public object GetObjectByNPath(string npathQuery, Type type, IList parameters) => GetObjectByNPath(npathQuery, type, parameters, RefreshBehaviorType.DefaultBehavior);

	    public object GetObjectByNPath(string npathQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior) => GetObjectByQuery(new NPathQuery(npathQuery, type, parameters, refreshBehavior, this));

	    public object GetObjectBySql(SqlQuery sqlQuery) => GetObjectByQuery(sqlQuery);

	    public object GetObjectBySql(string sqlQuery, Type type) => GetObjectBySql(sqlQuery, type, null, RefreshBehaviorType.DefaultBehavior);

	    public object GetObjectBySql(string sqlQuery, Type type, IList parameters) => GetObjectBySql(sqlQuery, type, parameters, RefreshBehaviorType.DefaultBehavior);

	    public object GetObjectBySql(string sqlQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior) => GetObjectByQuery(new SqlQuery(sqlQuery, type, parameters, refreshBehavior, this));

	    public virtual object GetObjectByKey(string keyPropertyName, object keyValue, Type type) => m_PersistenceManager.GetObjectByKey(keyPropertyName, keyValue, type);

	    public void LoadProperty(object obj, string propertyName) => m_PersistenceManager.LoadProperty(obj, propertyName);

	    public IList GetObjectsByQuery(IQuery query, IList listToFill) => this.PersistenceEngine.LoadObjects(query, listToFill);

	    public IList GetObjectsByQuery(IQuery query) => this.PersistenceEngine.LoadObjects(query, new ArrayList());

	    public virtual IList GetObjectsByNPath(NPathQuery npathQuery) => GetObjectsByQuery(npathQuery);

	    public virtual IList GetObjectsByNPath(NPathQuery npathQuery, IList listToFill) => GetObjectsByQuery(npathQuery, listToFill);

	    public virtual IList GetObjectsByNPath(string npathQuery, Type type) => GetObjectsByNPath(npathQuery, type, null, RefreshBehaviorType.DefaultBehavior);

	    public virtual IList GetObjectsByNPath(string npathQuery, Type type, IList parameters) => GetObjectsByNPath(npathQuery, type, parameters, RefreshBehaviorType.DefaultBehavior);

	    public virtual IList GetObjectsByNPath(string npathQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior) => GetObjectsByQuery(new NPathQuery(npathQuery, type, parameters, refreshBehavior, this));

	    public virtual IList GetObjectsBySql(SqlQuery sqlQuery) => GetObjectsByQuery(sqlQuery);

	    public virtual IList GetObjectsBySql(SqlQuery sqlQuery, IList listToFill) => GetObjectsByQuery(sqlQuery, listToFill);

	    public virtual IList GetObjectsBySql(string sqlQuery, Type type) => GetObjectsBySql(sqlQuery, type, null, RefreshBehaviorType.DefaultBehavior);

	    public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList parameters) => GetObjectsBySql(sqlQuery, type, parameters, RefreshBehaviorType.DefaultBehavior);

	    public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior) => GetObjectsByQuery(new SqlQuery(sqlQuery, type, parameters, refreshBehavior, this));

	    public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap) => GetObjectsBySql(sqlQuery, type, idColumns, typeColumns, propertyColumnMap, new ArrayList(), RefreshBehaviorType.DefaultBehavior);

	    public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters) => GetObjectsBySql(sqlQuery, type, idColumns, typeColumns, propertyColumnMap, parameters, RefreshBehaviorType.DefaultBehavior);

	    public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior) => GetPersistenceEngine().GetObjectsBySql(sqlQuery, type, idColumns, typeColumns, propertyColumnMap, parameters, refreshBehavior, new ArrayList() );

	    public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill) => GetPersistenceEngine().GetObjectsBySql(sqlQuery, type, idColumns, typeColumns, propertyColumnMap, parameters, refreshBehavior, listToFill);

	    public IList GetObjects(Type type) => GetObjects(type, RefreshBehaviorType.DefaultBehavior);

	    public IList GetObjects(Type type, IList listToFill) => GetObjects(type, RefreshBehaviorType.DefaultBehavior, listToFill);

	    public IList GetObjects(Type type, RefreshBehaviorType refreshBehavior) => GetObjects(type, refreshBehavior, new ArrayList() );

	    public IList GetObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill)
		{
            if (type == null)
                throw new ArgumentNullException("type");

            return m_PersistenceEngine.LoadObjects(type, refreshBehavior, listToFill);
		}


		public IList GetObjects(IQuery query, Type type)
		{
			query.PrimaryType = type;
			return GetObjectsByQuery(query);
		}

		public IList GetObjects(IQuery query, Type type, IList parameters, RefreshBehaviorType refreshBehavior)
		{
			query.PrimaryType = type;
			query.Parameters = parameters;
			query.RefreshBehavior = refreshBehavior;
			return GetObjectsByQuery(query);
		}

		public IList GetObjects(IQuery query, Type type, IList parameters)
		{
			query.PrimaryType = type;
			query.Parameters = parameters;
			return GetObjectsByQuery(query);
		}

		public virtual IList FilterObjects(IList objects, NPathQuery query) => ObjectQueryEngine.GetObjectsByNPath((string) query.Query, objects, query.Parameters);

	    public virtual IList FilterObjects(IList objects, string npath, Type type) => FilterObjects(objects, new NPathQuery(npath, type, this));

	    public virtual IList FilterObjects(IList objects, string npath, Type type, IList parameters) => FilterObjects(objects, new NPathQuery(npath, type, parameters, this));

	    public IList FilterObjects(NPathQuery query)
		{
			if (query == null)
				throw new ArgumentNullException("query");
			IList objects = m_IdentityMap.GetObjects();
            
            IList filterObjects = new ArrayList ();
            foreach (object item in objects)
            {
                if (query.PrimaryType.IsAssignableFrom(item.GetType()))
                    filterObjects.Add(item);
            }

            return FilterObjects(filterObjects, query);
		}

		public IList FilterObjects(string npath, Type type)
		{
			if (npath == null)
				throw new ArgumentNullException("npath");
			if (type == null)
				throw new ArgumentNullException("type");

			return FilterObjects(new NPathQuery(npath, type));
		}

		public IList FilterObjects(string npath, Type type, IList parameters) => FilterObjects(new NPathQuery(npath, type, parameters));

	    public DataTable FilterIntoDataTable(IList objects, NPathQuery query)
		{
			if (query == null)
				throw new ArgumentNullException("query");

			return this.ObjectQueryEngine.GetDataTableByNPath((string)query.Query,objects, query.Parameters);
		}

		public DataTable FilterIntoDataTable(IList objects, string npath, Type type)
		{
			if (objects == null)
				throw new ArgumentNullException("objects");
			if (type == null)
				throw new ArgumentNullException("type");

			return FilterIntoDataTable(objects, new NPathQuery(npath, type, this));
		}

		public DataTable FilterIntoDataTable(IList objects, string npath, Type type, IList parameters)
		{
			if (objects == null)
				throw new ArgumentNullException("objects");
			if (type == null)
				throw new ArgumentNullException("type");
			if (parameters == null)
				throw new ArgumentNullException("parameters");

			return FilterIntoDataTable(objects, new NPathQuery(npath, type, parameters, this));
		}


		public DataTable FilterIntoDataTable(NPathQuery query)
		{
			IList objects = this.IdentityMap.GetObjects();
			return FilterIntoDataTable(objects, query);
		}


		public DataTable FilterIntoDataTable(string npath, Type type) => FilterIntoDataTable(new NPathQuery(npath, type));

	    public DataTable FilterIntoDataTable(string npath, Type type, IList parameters) => FilterIntoDataTable(new NPathQuery(npath, type, parameters));

	    public DataTable GetDataTable(NPathQuery query) => this.PersistenceEngine.LoadDataTable(query);

	    public DataTable GetDataTable(string npath, Type type) => GetDataTable(new NPathQuery(npath, type));

	    public DataTable GetDataTable(string npath, Type type, IList parameters) => GetDataTable(new NPathQuery(npath, type, parameters));

//		private DataTable FetchDataTable(NPathQuery query, Type type, IList parameters)
//		{
//			IDataSource ds = this.DataSourceManager.GetDataSource(type);
//			Hashtable propertyColumnMap = new Hashtable() ;
//			IList outParameters = new ArrayList() ;
//			string sql = this.NPathEngine.ToSql((string) query.Query , type, ref propertyColumnMap, ref outParameters, parameters);
//			return this.SqlExecutor.ExecuteDataTable(sql, ds, outParameters);
//		}

		public virtual object CreateObject(object identity, Type type, params object[] ctorParams)
		{
			object obj;
			obj = m_AssemblyManager.CreateInstance(type, ctorParams);
			string id = TransformIdentity(identity, type);
			m_ObjectManager.SetObjectIdentity(obj, id);
			RegisterObject(obj, ObjectStatus.UpForCreation);
			return obj;
		}

		public virtual object CreateObject(Type type, params object[] ctorParams)
		{
			object obj;            

			obj = m_AssemblyManager.CreateInstance(type, ctorParams);
            
			IClassMap classMap = this.DomainMap.MustGetClassMap(type);

			if (classMap.HasIdentityGenerators())
			{
				Hashtable identities = new Hashtable() ;
				foreach (IPropertyMap idPropertyMap in classMap.GetIdentityPropertyMaps() )
				{
					if (idPropertyMap.IdentityGenerator.Length > 0 )
					{
						IIdentityGenerator identityGenerator = GetIdentityGenerator(idPropertyMap.IdentityGenerator);
						if (identityGenerator != null)
						{
							identities[idPropertyMap.Name] = identityGenerator.GenerateIdentity();
						}
					}
				}
				string id = TransformIdentity(identities, type);
				m_ObjectManager.SetObjectIdentity(obj, id);				
			}

			IColumnMap typeColMap = classMap.GetTypeColumnMap();
			if (typeColMap != null)
			{
				IPropertyMap typeMap = classMap.GetPropertyMapForColumnMap(typeColMap);
				if (typeMap != null)
				{
					m_ObjectManager.SetPropertyValue(obj, typeMap.Name, classMap.TypeValue);
					m_ObjectManager.SetOriginalPropertyValue(obj, typeMap.Name, classMap.TypeValue);
				}
			}

			RegisterObject(obj, ObjectStatus.UpForCreation);
			return obj;
		}

		protected virtual void RegisterObject(object obj, ObjectStatus objectStatus)
		{
			if (objectStatus == ObjectStatus.UpForCreation)
			{
				RegisterNewObject(obj);
			}
			else
			{
				throw new IAmOpenSourcePleaseImplementMeException("Not implemented yet!");
			}
		}

		protected virtual void RegisterObject(object obj) => RegisterObject(obj, ObjectStatus.UpForCreation);

	    protected virtual void RegisterNewObject(object obj)
		{
			ObjectCancelEventArgs e = new ObjectCancelEventArgs(obj);
			m_EventManager.OnCreatingObject(this, e);
			if (e.Cancel)
			{
				return;
			}
			IClassMap classMap = DomainMap.MustGetClassMap(obj.GetType());
			if (classMap.IsReadOnly)
			{
				throw new ReadOnlyException("Objects from class '" + classMap.Name + "' can not be created because the class is marked as read-only!");
			}
			m_PersistenceManager.CreateObject(obj);
			ObjectEventArgs e2 = new ObjectEventArgs(obj);
			m_EventManager.OnCreatedObject(this, e2);
		}

		public virtual void CommitObject(object obj) => CommitObject(obj, 1);

	    public virtual void CommitObject(object obj, int exceptionLimit)
		{
			ObjectCancelEventArgs e = new ObjectCancelEventArgs(obj);
			m_EventManager.OnCommittingObject(this, e);
			if (e.Cancel)
			{
				return;
			}
			IClassMap classMap = DomainMap.MustGetClassMap(obj.GetType());
			if (classMap.IsReadOnly)
			{
				throw new ReadOnlyException("Objects from class '" + classMap.Name + "' can not be updated because the class is marked as read-only!");
			}
			m_PersistenceManager.CommitObject(obj, exceptionLimit);
			ObjectEventArgs e2 = new ObjectEventArgs(obj);
			m_EventManager.OnCommittedObject(this, e2);
		}

		public virtual void DeleteObjects(IList objects)
		{
			ArrayList tmp = new ArrayList(objects) ;
			foreach (object obj in tmp)
			{
				DeleteObject(obj);
			} 			
		}

		public virtual void DeleteObject(object identity, Type type)
        {
            object obj = this.GetObjectById(identity, type);
            DeleteObject(obj);
        }

		public virtual void DeleteObject(object obj)
		{
			ObjectCancelEventArgs e = new ObjectCancelEventArgs(obj);
			m_EventManager.OnDeletingObject(this, e);
			if (e.Cancel)
			{
				return;
			}
			IClassMap classMap = DomainMap.MustGetClassMap(obj.GetType());
			if (classMap.IsReadOnly)
			{
				throw new ReadOnlyException("Objects from class '" + classMap.Name + "' can not be created because the class is marked as read-only!");
			}
			m_PersistenceManager.DeleteObject(obj);
			ObjectEventArgs e2 = new ObjectEventArgs(obj);
			m_EventManager.OnDeletedObject(this, e2);
		}

		public virtual void PersistAll() => Commit(1);

	    //Default is to use exceptionLimit = 1. exceptionLimit = 0 means no limit.
		public virtual void Commit() => Commit(1);

	    public virtual void Commit(int exceptionLimit)
		{
			ContextCancelEventArgs e = new ContextCancelEventArgs(this);
			m_EventManager.OnCommitting(this, e);
 
			if (e.Cancel)
				return;
			if (!DomainMap.IsReadOnly)
			{
				m_PersistenceManager.Commit(exceptionLimit);				
			}

			ContextEventArgs e2 = new ContextEventArgs(this);
			m_EventManager.OnCommitted(this, e2);
		}

        public virtual void CommitRecursive() => CommitRecursive(1);

	    public virtual void CommitRecursive(int exceptionLimit)
        {
            Commit(exceptionLimit);

            if (m_PersistenceEngine != null)
            {
                PersistenceEngineManager persistenceEngineManager = m_PersistenceEngine as PersistenceEngineManager;
                ObjectPersistenceEngine objectPersistenceEngine = null;
                if (persistenceEngineManager != null)
                {
                    objectPersistenceEngine = persistenceEngineManager.ObjectObjectPersistenceEngine as ObjectPersistenceEngine;
                }
                else
                {
                    objectPersistenceEngine = m_PersistenceEngine as ObjectPersistenceEngine;
                }               
                if (objectPersistenceEngine != null)
                {
                    if (objectPersistenceEngine.SourceContext != null)
                        objectPersistenceEngine.SourceContext.CommitRecursive(exceptionLimit);
                }
            }
        }
        
        public virtual void Dispose()
		{
			if (this.isDisposed)
				return;

			this.isDisposed = true;

			if (m_Interceptor != null)
				m_Interceptor.Dispose();

			if (m_DataSourceManager != null)
				m_DataSourceManager.Dispose();

			GC.SuppressFinalize(this);
		}

		public virtual bool GetNullValueStatus(object obj, string propertyName) => m_ObjectManager.GetNullValueStatus(obj, propertyName);

	    public virtual void SetNullValueStatus(object obj, string propertyName, bool value)
		{
			m_ObjectManager.SetNullValueStatus(obj, propertyName, value);
			m_UnitOfWork.RegisterDirty(obj);
			m_ObjectManager.SetUpdatedStatus(obj, propertyName, true);
		}

//		public virtual void Debug(object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Debug(message, verbose);
//			}
//		}
//
//		public virtual void Info(object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Info(message, verbose);
//			}			
//		}
//
//		public virtual void Warn(object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Warn(message, verbose);
//			}
//		}
//
//		public virtual void Error(object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Error(message, verbose);
//			}
//		}
//
//		public virtual void Fatal(object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Fatal(message, verbose);
//			}
//		}
//		
//		public virtual void Debug(object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Debug(message, verbose, t);
//			}
//		}
//
//		public virtual void Info(object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Info(message, verbose, t);
//			}
//		}
//
//		public virtual void Warn(object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Warn(message, verbose, t);
//			}
//		}
//
//		public virtual void Error(object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Error(message, verbose, t);
//			}
//		}
//
//		public virtual void Fatal(object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Fatal(message, verbose, t);
//			}
//		}
//		
//		public virtual void Debug(object sender, object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Debug(sender, message, verbose);
//			}
//		}
//
//		public virtual void Info(object sender, object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Info(sender, message, verbose);
//			}			
//		}
//
//		public virtual void Warn(object sender, object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Warn(sender, message, verbose);
//			}
//		}
//
//		public virtual void Error(object sender, object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Error(sender, message, verbose);
//			}
//		}
//
//		public virtual void Fatal(object sender, object message, object verbose)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Fatal(sender, message, verbose);
//			}
//		}
//		
//		public virtual void Debug(object sender, object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Debug(sender, message, verbose, t);
//			}
//		}
//
//		public virtual void Info(object sender, object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Info(sender, message, verbose, t);
//			}
//		}
//
//		public virtual void Warn(object sender, object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Warn(sender, message, verbose, t);
//			}
//		}
//
//		public virtual void Error(object sender, object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Error(sender, message, verbose, t);
//			}
//		}
//
//		public virtual void Fatal(object sender, object message, object verbose, Exception t)
//		{
//			foreach (ILogger logger in m_Loggers)
//			{
//				logger.Fatal(sender, message, verbose, t);
//			}
//		}

		public virtual void AddObserver(IObserver observer)
		{
			if (m_EventManager != null)
			{
				m_EventManager.AddObserver(observer);
			}
		}


		public virtual void AddObserver(IObserver observer, ObserverTarget observerTarget)
		{
			if (m_EventManager != null)
			{
				m_EventManager.AddObserver(observer, observerTarget);
			}
		}

		public virtual void AddObserver(IObserver observer, Type type)
		{
			if (m_EventManager != null)
			{
				m_EventManager.AddObserver(observer, type);
			}
		}

		public virtual void AddObserver(IObserver observer, object obj)
		{
			if (m_EventManager != null)
			{
				m_EventManager.AddObserver(observer, obj);
			}
		}

		public virtual void AddObserver(IObserver observer, params object[] targets)
		{
			if (m_EventManager != null)
			{
				m_EventManager.AddObserver(observer, targets);
			}
		}

		public virtual IList GetAllObservers()
		{
			if (m_EventManager != null)
			{
				return m_EventManager.GetAllObservers();
			}
			return null;
		}
		
		public virtual IList GetObservers()
		{
			if (m_EventManager != null)
			{
				return m_EventManager.GetObservers();
			}
			return null;
		}
		
		public virtual IList GetObservers(ObserverTarget observerTarget)
		{
			if (m_EventManager != null)
			{
				return m_EventManager.GetObservers(observerTarget);
			}
			return null;
		}
		
		public virtual IList GetObservers(Type type)
		{
			if (m_EventManager != null)
			{
				return m_EventManager.GetObservers(type);
			}
			return null;
		}

		public virtual IList GetObservers(object obj)
		{
			if (m_EventManager != null)
			{
				return m_EventManager.GetObservers(obj);
			}
			return null;
		}

		public virtual IDbConnection GetConnection()
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap();
			if (sourceMap == null)
			{
				throw new MappingException("Default source not found!");
			}
			return GetConnection(sourceMap);
		}

		public virtual IDbConnection GetConnection(string sourceName)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap(sourceName);
			if (sourceMap == null)
			{
				throw new MappingException("Source not found!");
			}
			return GetConnection(sourceMap);
		}

		public virtual IDbConnection GetConnection(ISourceMap sourceMap)
		{
			IDataSource ds = m_DataSourceManager.GetDataSource(sourceMap);
			return ds.GetConnection();
		}

		public virtual void SetConnection(IDbConnection value)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap();
			if (sourceMap == null)
			{
				throw new MappingException("Default source not found!");
			}
			SetConnection(value, sourceMap);
		}

		public virtual void SetConnection(IDbConnection value, string sourceName)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap(sourceName);
			if (sourceMap == null)
			{
				throw new MappingException("Source not found!");
			}
			SetConnection(value, sourceMap);
		}

		public virtual void SetConnection(IDbConnection value, ISourceMap sourceMap)
		{
			IDataSource ds = m_DataSourceManager.GetDataSource(sourceMap);
			ds.SetConnection(value);
		}


		public virtual string GetConnectionString()
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap();
			if (sourceMap == null)
			{
				throw new MappingException("Default source not found!");
			}
			return GetConnectionString(sourceMap);
		}

		public virtual string GetConnectionString(string sourceName)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap(sourceName);
			if (sourceMap == null)
			{
				throw new MappingException("Source not found!");
			}
			return GetConnectionString(sourceMap);
		}

		public virtual string GetConnectionString(ISourceMap sourceMap) => sourceMap.ConnectionString;

	    public virtual void SetConnectionString(string value)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap();
			if (sourceMap == null)
			{
				throw new MappingException("Default source not found!");
			}
			SetConnectionString(value, sourceMap);
		}

		public virtual void SetConnectionString(string value, string sourceName)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap(sourceName);
			if (sourceMap == null)
			{
				throw new MappingException("Source not found!");
			}
			SetConnectionString(value, sourceMap);
		}

		public virtual void SetConnectionString(string value, ISourceMap sourceMap) => sourceMap.ConnectionString = value;

	    public virtual IDataSource GetDataSource()
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap();
			if (sourceMap == null)
			{
				throw new MappingException("Default source not found!");
			}
			return GetDataSource(sourceMap);
		}

		public virtual IDataSource GetDataSource(string sourceName)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap(sourceName);
			if (sourceMap == null)
			{
				throw new MappingException("Source not found!");
			}
			return GetDataSource(sourceMap);
		}

		public virtual IDataSource GetDataSource(ISourceMap sourceMap)
		{
			IDataSource ds = m_DataSourceManager.GetDataSource(sourceMap);
			return ds;
		}

		public virtual ISourceMap GetSourceMap()
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap();
			if (sourceMap == null)
			{
				throw new MappingException("Default source not found!");
			}
			return sourceMap;
		}

		public virtual ISourceMap GetSourceMap(string sourceName)
		{
			if (m_DomainMap == null)
			{
				throw new MappingException("DomainMap not set!");
			}
			ISourceMap sourceMap = m_DomainMap.GetSourceMap(sourceName);
			if (sourceMap == null)
			{
				throw new MappingException("Source not found!");
			}
			return sourceMap;
		}

		public virtual ITransaction BeginTransaction() => BeginTransaction(IsolationLevel.ReadCommitted, true);

	    public virtual ITransaction BeginTransaction(IsolationLevel iso) => BeginTransaction(iso, true);

	    public virtual ITransaction BeginTransaction(bool commitTransactionOnCommittingContext) => BeginTransaction(IsolationLevel.ReadCommitted, commitTransactionOnCommittingContext);

	    public virtual ITransaction BeginTransaction(IsolationLevel iso, bool commitTransactionOnCommittingContext) => new CompositeTransaction(this, iso, commitTransactionOnCommittingContext);

	    public virtual ITransaction BeginTransaction(IDataSource dataSource)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");
			return BeginTransaction(dataSource, IsolationLevel.ReadCommitted, true);
		}

		public virtual ITransaction BeginTransaction(IDataSource dataSource, IsolationLevel iso)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");
			return BeginTransaction(dataSource, iso, true);
		}

		public virtual ITransaction BeginTransaction(IDataSource dataSource, bool commitTransactionOnCommittingContext)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");
			return BeginTransaction(dataSource, IsolationLevel.ReadCommitted, commitTransactionOnCommittingContext);
		}

		public virtual ITransaction BeginTransaction(IDataSource dataSource, IsolationLevel iso, bool commitTransactionOnCommittingContext)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");

            LogMessage message = new LogMessage("Beginning local transaction");
            LogMessage verbose = new LogMessage("Data source: {0}, Isolation level: {1} Auto persist: {2} " , dataSource.Name , iso, commitTransactionOnCommittingContext);
            this.LogManager.Info(this, message, verbose); // do not localize	

			TransactionCancelEventArgs e = new TransactionCancelEventArgs(dataSource, iso, commitTransactionOnCommittingContext);
			m_EventManager.OnBeginningTransaction(this, e);
			if (e.Cancel)
			{
				return null;
			}
			iso = e.IsolationLevel;
			dataSource = e.DataSource;
			commitTransactionOnCommittingContext = e.AutoPersistAllOnCommit;

			IDbConnection connection = dataSource.GetConnection();

			if (m_Transactions.ContainsKey(connection))
			{
				throw new TransactionException("Can't begin new transaction for a connection that already has a pending transaction!");
			}
			IDbTransaction dbTransaction = connection.BeginTransaction(iso);
			ITransaction transaction = new Transaction(dbTransaction, dataSource, this);
			transaction.AutoPersistAllOnCommit = commitTransactionOnCommittingContext;
			m_Transactions[connection] = transaction;

			TransactionEventArgs e2 = new TransactionEventArgs(transaction, dataSource, iso, commitTransactionOnCommittingContext);
			m_EventManager.OnBegunTransaction(this, e2);

			return transaction;
		}

		public virtual bool HasTransactionPending()
		{
			bool result = false;
			if (m_Transactions.Count > 0)
			{
				result = true;
			}
			return result;
		}

		public virtual bool HasTransactionPending(IDataSource dataSource)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");

			IDbConnection connection = dataSource.GetConnection();
			bool result = false;
			if (m_Transactions.ContainsKey(connection))
			{
				result = true;
			}
			dataSource.ReturnConnection() ;
			return result;
		}

		public virtual void OnTransactionComplete(ITransaction transaction)
		{
			IDbConnection connection = transaction.DataSource.GetConnection();
			if (connection == null)
			{
				throw new TransactionException("Connection has been lost!");
			}
			else
			{
				if (!(m_Transactions.ContainsKey(connection)))
				{
					throw new TransactionException("Transaction has been lost!");
				}
			}
			m_Transactions.Remove(connection);
			//m_Transactions[connection] = null;
		}

		public virtual ITransaction GetTransaction(IDbConnection connection)
		{
			if (m_Transactions.ContainsKey(connection))
			{
				return (ITransaction) m_Transactions[connection];
			}
			else
			{
				return null;
			}
		}

		public virtual void SetTransaction(IDbConnection connection, ITransaction transaction) => m_Transactions[connection] = transaction;

	    public virtual object ExecuteScalar(IQuery query)
		{
			IDataSource dataSource = GetDataSource();
			return ExecuteScalar(query, dataSource);
		}

		public virtual object ExecuteScalar(IQuery query, IDataSource dataSource)
		{
			IList outParameters = new ArrayList(); 
			string sql = query.ToSqlScalar(query.PrimaryType, this, ref outParameters, query.Parameters);
			return m_SqlExecutor.ExecuteScalar(sql, dataSource, outParameters);
		}

		public virtual object ExecuteScalar(string npath, Type type) => ExecuteScalar(new NPathQuery(npath, type, this));

	    public virtual object ExecuteScalarByNPath(string npath, Type type) => ExecuteScalar(new NPathQuery(npath, type, this));

	    public virtual object ExecuteScalarByNPath(string npath, Type type, IList parameters ) => ExecuteScalar(new NPathQuery(npath, type, parameters, this));

	    public virtual object ExecuteScalarByNPath(string npath, Type type, IList parameters, IDataSource dataSource ) => ExecuteScalar(new NPathQuery(npath, type, parameters, this), dataSource );

	    public virtual object ExecuteScalarBySql(string sql) => ExecuteScalar(new SqlQuery(sql, this));

	    public virtual object ExecuteScalarBySql(string sql, IList parameters ) => ExecuteScalar(new SqlQuery(sql, parameters, this));

	    public virtual object ExecuteScalarBySql(string sql, IList parameters, IDataSource dataSource ) => ExecuteScalar(new SqlQuery(sql, parameters, this), dataSource );

	    public virtual object AttachObject(object obj) => AttachObject(obj, MergeBehaviorType.DefaultBehavior);

	    public virtual object AttachObject(object obj, MergeBehaviorType mergeBehavior)
		{
			//2-pass operation - first pass register in uow and id map, seond pass merge objects
			// Collect the object to be merged in first pass (the objects already in the id map)
			Hashtable merge = new Hashtable() ;
			string objId = this.ObjectManager.GetObjectIdentity(obj);
			this.PersistenceManager.AttachObject(obj, new Hashtable(), merge );
			foreach(object mergeObj in merge.Keys)
				this.PersistenceManager.MergeObjects(mergeObj, merge[mergeObj], mergeBehavior);
			return this.GetObjectById(objId, obj.GetType());
		}

		public virtual IList AttachObjects(IList objects) => AttachObjects(objects, MergeBehaviorType.DefaultBehavior);

	    public virtual IList AttachObjects(IList objects, MergeBehaviorType mergeBehavior) => null;

	    public virtual IIdentityGenerator GetIdentityGenerator(string name)
		{
			string useName = name;
			switch (useName.ToLower(CultureInfo.InvariantCulture))
			{
				case "guid" :
					useName = "GuidIdentityGenerator";
					break;
				case "sequential-guid" :
					useName = "SequentialGuidIdentityGenerator";
					break;
			}

			switch (useName)
			{
				case "GuidIdentityGenerator": 
				case "SequentialGuidIdentityGenerator" :
					return GetKnownIdentityGenerator(useName);
			}
			IIdentityGenerator identityGenerator = (IIdentityGenerator) this.identityGenerators[name];
			if (identityGenerator == null)
				throw new NPersistException("Unknown identity generator: " + name);
			return identityGenerator;
		}

		protected virtual IIdentityGenerator GetKnownIdentityGenerator(string name)
		{
			IIdentityGenerator identityGenerator = (IIdentityGenerator) this.identityGenerators[name];
			if (identityGenerator == null)
			{
				switch (name)
				{
					case "GuidIdentityGenerator" :
						identityGenerator = new GuidIdentityGenerator();
						break;
					case "SequentialGuidIdentityGenerator" :
						identityGenerator = new SequentialGuidIdentityGenerator();
						break;
				}

				this.identityGenerators[name] = identityGenerator;
			}
			return identityGenerator;
		} 

		public virtual void RefreshObject(object obj) => RefreshObject(obj, RefreshBehaviorType.DefaultBehavior);

	    public virtual void RefreshObject(object obj, RefreshBehaviorType refreshBehavior) => RefreshObjectProperty(obj, refreshBehavior, "*");

	    public virtual void RefreshObjects(IList objects) => RefreshObjects(objects, RefreshBehaviorType.DefaultBehavior);

	    public virtual void RefreshObjects(IList objects, RefreshBehaviorType refreshBehavior)
		{
			foreach(object obj in objects)
				RefreshObject(obj, refreshBehavior);
		}

		public virtual void RefreshProperty(object obj, string propertyName) => RefreshProperty(obj, propertyName, RefreshBehaviorType.DefaultBehavior);

	    public virtual void RefreshProperty(object obj, string propertyName, RefreshBehaviorType refreshBehavior) => RefreshObjectProperty(obj, refreshBehavior, propertyName);

	    protected virtual void RefreshObjectProperty(object obj, RefreshBehaviorType refreshBehavior, string propertyName)
		{
			string span = propertyName;
			if (span != "*")
			{
				IPropertyMap propertyMap = this.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
				if (propertyMap.IsCollection)
				{
					span += ".*";
				}				
			}
			NPathQuery npathQuery = GetLoadObjectNPathQuery(obj, span, refreshBehavior);
			GetObjectByNPath(npathQuery);
		}


        public virtual void Invalidate() => this.ObjectManager.InvalidateObjectsInCache(false);

	    public virtual void Invalidate(bool invalidateDirty) => this.ObjectManager.InvalidateObjectsInCache(invalidateDirty);

	    public virtual void Invalidate(IList objects) => this.ObjectManager.InvalidateObjects(objects, false);

	    public virtual void Invalidate(IList objects, bool invalidateDirty) => this.ObjectManager.InvalidateObjects(objects, invalidateDirty);

	    public virtual void Invalidate(object obj) => this.ObjectManager.InvalidateObject(obj, false);

	    public virtual void Invalidate(object obj, bool invalidateDirty) => this.ObjectManager.InvalidateObject(obj, invalidateDirty);

	    public virtual void Invalidate(object obj, string propertyName) => this.ObjectManager.InvalidateProperty(obj, propertyName, false);

	    public virtual void Invalidate(object obj, string propertyName, bool invalidateDirty) => this.ObjectManager.InvalidateProperty(obj, propertyName, invalidateDirty);

	    public virtual void Clear()
        {
            this.IdentityMap.Clear();
            this.UnitOfWork.Clear();
            this.InverseManager.Clear();
            this.SqlExecutor.Clear();
			this.conflicts.Clear();
        }


		public virtual NPathQuery GetLoadObjectNPathQuery(object obj, RefreshBehaviorType refreshBehavior) => GetLoadObjectNPathQuery(obj, "*", refreshBehavior);

	    public virtual NPathQuery GetLoadObjectNPathQuery(object obj, string span) => GetLoadObjectNPathQuery(obj, span, RefreshBehaviorType.DefaultBehavior);

	    public virtual NPathQuery GetLoadObjectNPathQuery(object obj, string span, RefreshBehaviorType refreshBehavior)
		{
			Type type = obj.GetType() ;
			IClassMap classMap = m_DomainMap.MustGetClassMap(type );
			NPathQuery npathQuery = new NPathQuery("", type );
			npathQuery.RefreshBehavior = refreshBehavior;
			StringBuilder npathBuilder = new StringBuilder() ;
			npathBuilder.Append("Select " + span + " From " + classMap.Name + " Where ");
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				object value = m_ObjectManager.GetPropertyValue(obj, propertyMap.Name);
				npathBuilder.Append(propertyMap.Name + " = ?");
				if (propertyMap.ReferenceType != ReferenceType.None)
					npathQuery.Parameters.Add(new QueryParameter(DbType.Object, value));
				else
					npathQuery.Parameters.Add(new QueryParameter(value));
				npathBuilder.Append(" And ");
			}
			npathBuilder.Length -= 5;
			npathQuery.Query = npathBuilder.ToString();
			return npathQuery;
		}


		private bool isEditing = false;

		public virtual bool IsEditing => this.isEditing;

	    public virtual void BeginEdit()
		{
			if (this.isEditing) 
				throw new EditException("Can't begin edit when already in editing mode!");

			this.isEditing = true;

			this.ObjectCloner.BeginEdit();
		}

		public virtual void CancelEdit()
		{
			if (!this.isEditing) 
				throw new EditException("Can't cancel edit when not in editing mode!");

			this.isEditing = false;

			this.ObjectCloner.CancelEdit();
		}

		public virtual void EndEdit()
		{
			if (!this.isEditing) 
				throw new EditException("Can't end edit when not in editing mode!");
			
			this.isEditing = false;

			this.ObjectCloner.EndEdit();
		}

		public IObjectCache GetObjectCache() => m_ObjectCacheManager.GetObjectCache();

	    #region Property  TimeToLive
		
		private long timeToLive = -1;
		
		public long TimeToLive
		{
			get => this.timeToLive;
		    set => this.timeToLive = value;
		}
		
		#endregion

		#region Property  TimeToLiveBehavior
		
		private TimeToLiveBehavior timeToLiveBehavior = TimeToLiveBehavior.Default;
		
		public TimeToLiveBehavior TimeToLiveBehavior
		{
			get => this.timeToLiveBehavior;
		    set => this.timeToLiveBehavior = value;
		}
		
		#endregion

		#region Property  LoadBehavior
		
		private LoadBehavior loadBehavior = LoadBehavior.Default;
		
		public LoadBehavior LoadBehavior
		{
			get => this.loadBehavior;
		    set => this.loadBehavior = value;
		}
		
		#endregion

		#region LoadedInLatestQuery

		public Hashtable LoadedInLatestQuery
		{
			get => loadedInLatestQuery;
		    set => loadedInLatestQuery = value;
		}

		#endregion

		#region Exceptions

		public IList Exceptions => this.UnitOfWork.Exceptions;

	    #endregion

		#endregion

		#region Validation

		#region Property  ValidationMode
		
		private ValidationMode validationMode = ValidationMode.Default;
		
		public ValidationMode ValidationMode
		{
			get => this.validationMode;
		    set => this.validationMode = value;
		}
		
		#endregion

		#region Property  ValidateBeforeCommit
		
		private bool validateBeforeCommit = true;
		
		public bool ValidateBeforeCommit
		{
			get => this.validateBeforeCommit;
		    set => this.validateBeforeCommit = value;
		}
		
		#endregion
		
		public virtual bool IsValidCache()
		{
			IList exceptions = new ArrayList();
			ValidateCache(exceptions);
			return exceptions.Count > 0;			
		}

		public virtual bool IsValidUnitOfWork()
		{
			IList exceptions = new ArrayList();
 			ValidateUnitOfWork(exceptions);
			return exceptions.Count > 0;
		}


		public virtual void ValidateCache() => ValidateCache(null);

	    public virtual void ValidateCache(IList exceptions)
		{
			foreach (object obj in this.IdentityMap.GetObjects () )
			{
				ValidateObject(obj, exceptions);
			}			
		}

		public virtual void ValidateUnitOfWork() => ValidateUnitOfWork(null);

	    public virtual void ValidateUnitOfWork(IList exceptions)
		{
			foreach (object obj in this.UnitOfWork.GetCreatedObjects() )
			{
				ValidateObject(obj, exceptions);
			}			
			foreach (object obj in this.UnitOfWork.GetDirtyObjects() )
			{
				ValidateObject(obj, exceptions);
			}			
//			foreach (object obj in this.UnitOfWork.GetDeletedObjects() )
//			{
//				ValidateObject(obj, exceptions);
//			}			
		}

				
		public virtual bool IsValid(object obj) => this.m_ObjectValidator.IsValid(obj);

	    public virtual bool IsValid(object obj, string propertyName) => this.m_ObjectValidator.IsValid(obj, propertyName);

	    public virtual void ValidateObjects(IList objects)
		{
			foreach (object obj in objects)
				this.m_ObjectValidator.ValidateObject(obj);						
		}

		public virtual void ValidateObjects(IList objects, IList exceptions)
		{
			foreach (object obj in objects)
				this.m_ObjectValidator.ValidateObject(obj, exceptions);				
		}

		public virtual void ValidateObject(object obj) => this.m_ObjectValidator.ValidateObject(obj);

	    public virtual void ValidateObject(object obj, IList exceptions) => this.m_ObjectValidator.ValidateObject(obj, exceptions);

	    public virtual void ValidateProperty(object obj, string propertyName) => this.m_ObjectValidator.ValidateProperty(obj, propertyName);

	    public virtual void ValidateProperty(object obj, string propertyName, IList exceptions) => this.m_ObjectValidator.ValidateProperty(obj, propertyName, exceptions);

	    #endregion

		#region Event Handlers

		void IObserver.OnBegunTransaction(object sender, TransactionEventArgs e)
		{
			if (BegunTransaction != null)
			{
				BegunTransaction(sender, e);
			}
		}

		void IObserver.OnBeginningTransaction(object sender, TransactionCancelEventArgs e)
		{
			if (BeginningTransaction != null)
			{
				BeginningTransaction(sender, e);
			}
		}

		void IObserver.OnCommittedTransaction(object sender, TransactionEventArgs e)
		{
			if (CommittedTransaction != null)
			{
				CommittedTransaction(sender, e);
			}
		}

		void IObserver.OnCommittingTransaction(object sender, TransactionCancelEventArgs e)
		{
			if (CommittingTransaction != null)
			{
				CommittingTransaction(sender, e);
			}
		}

		void IObserver.OnRolledbackTransaction(object sender, TransactionEventArgs e)
		{
			if (RolledbackTransaction != null)
			{
				RolledbackTransaction(sender, e);
			}
		}

		void IObserver.OnRollingbackTransaction(object sender, TransactionCancelEventArgs e)
		{
			if (RollingbackTransaction != null)
			{
				RollingbackTransaction(sender, e);
			}
		}

		void IObserver.OnExecutedSql(object sender, SqlExecutorEventArgs e)
		{
			if (ExecutedSql != null)
			{
				ExecutedSql(sender, e);
			}
		}

		void IObserver.OnExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			if (ExecutingSql != null)
			{
				ExecutingSql(sender, e);
			}
		}

		void IObserver.OnCalledWebService(object sender, WebServiceEventArgs e)
		{
			if (CalledWebService != null)
			{
				CalledWebService(sender, e);
			}
		}

		void IObserver.OnCallingWebService(object sender, WebServiceCancelEventArgs e)
		{
			if (CallingWebService != null)
			{
				CallingWebService(sender, e);
			}
		}

		void IObserver.OnCommitted(object sender, ContextEventArgs e)
		{
			if (Committed != null)
			{
				Committed(sender, e);
			}
		}

		void IObserver.OnCommitting(object sender, ContextCancelEventArgs e)
		{
			if (Committing != null)
			{
				Committing(sender, e);
			}
		}

		void IEventListener.OnCreatedObject(object sender, ObjectEventArgs e)
		{
			if (CreatedObject != null)
			{
				CreatedObject(sender, e);
			}
		}

		void IEventListener.OnCreatingObject(object sender, ObjectCancelEventArgs e)
		{
			if (CreatingObject != null)
			{
				CreatingObject(sender, e);
			}
		}

		void IEventListener.OnInsertedObject(object sender, ObjectEventArgs e)
		{
			if (InsertedObject != null)
			{
				InsertedObject(sender, e);
			}
		}

		void IEventListener.OnInsertingObject(object sender, ObjectCancelEventArgs e)
		{
			if (InsertingObject != null)
			{
				InsertingObject(sender, e);
			}
		}

		void IEventListener.OnDeletedObject(object sender, ObjectEventArgs e)
		{
			if (DeletedObject != null)
			{
				DeletedObject(sender, e);
			}
		}

		void IEventListener.OnDeletingObject(object sender, ObjectCancelEventArgs e)
		{
			if (DeletingObject != null)
			{
				DeletingObject(sender, e);
			}
		}

		void IEventListener.OnRemovedObject(object sender, ObjectEventArgs e)
		{
			if (RemovedObject != null)
			{
				RemovedObject(sender, e);
			}
		}

		void IEventListener.OnRemovingObject(object sender, ObjectCancelEventArgs e)
		{
			if (RemovingObject != null)
			{
				RemovingObject(sender, e);
			}
		}

		void IEventListener.OnCommittedObject(object sender, ObjectEventArgs e)
		{
			if (CommittedObject != null)
			{
				CommittedObject(sender, e);
			}
		}

		void IEventListener.OnCommittingObject(object sender, ObjectCancelEventArgs e)
		{
			if (CommittingObject != null)
			{
				CommittingObject(sender, e);
			}
		}

		void IEventListener.OnUpdatedObject(object sender, ObjectEventArgs e)
		{
			if (UpdatedObject != null)
			{
				UpdatedObject(sender, e);
			}
		}

		void IEventListener.OnUpdatingObject(object sender, ObjectCancelEventArgs e)
		{
			if (UpdatingObject != null)
			{
				UpdatingObject(sender, e);
			}
		}

		void IEventListener.OnGotObject(object sender, ObjectEventArgs e)
		{
			if (GotObject != null)
			{
				GotObject(sender, e);
			}
		}

		void IEventListener.OnGettingObject(object sender, ObjectCancelEventArgs e)
		{
			if (GettingObject != null)
			{
				GettingObject(sender, e);
			}
		}

		void IEventListener.OnLoadedObject(object sender, ObjectEventArgs e)
		{
			if (LoadedObject != null)
			{
				LoadedObject(sender, e);
			}
		}

		void IEventListener.OnLoadingObject(object sender, ObjectCancelEventArgs e)
		{
			if (LoadingObject != null)
			{
				LoadingObject(sender, e);
			}
		}

		void IEventListener.OnReadProperty(object sender, PropertyEventArgs e)
		{
			if (ReadProperty != null)
			{
				ReadProperty(sender, e);
			}
		}

		void IEventListener.OnReadingProperty(object sender, PropertyCancelEventArgs e)
		{
			if (ReadingProperty != null)
			{
				ReadingProperty(sender, e);
			}
		}

		void IEventListener.OnWroteProperty(object sender, PropertyEventArgs e)
		{
			if (WroteProperty != null)
			{
				WroteProperty(sender, e);
			}
		}

		//[DebuggerStepThrough()]
		void IEventListener.OnWritingProperty(object sender, PropertyCancelEventArgs e)
		{
			if (WritingProperty != null)
			{
				WritingProperty(sender, e);
			}
		}

		void IEventListener.OnLoadedProperty(object sender, PropertyEventArgs e)
		{
			if (LoadedProperty != null)
			{
				LoadedProperty(sender, e);
			}
		}

		void IEventListener.OnLoadingProperty(object sender, PropertyCancelEventArgs e)
		{
			if (LoadingProperty != null)
			{
				LoadingProperty(sender, e);
			}
		}

		void IEventListener.OnInstantiatedObject(object sender, ObjectEventArgs e)
		{
			if (InstantiatedObject != null)
			{
				InstantiatedObject(sender, e);
			}
		}

		void IEventListener.OnInstantiatingObject(object sender, ObjectCancelEventArgs e)
		{
			if (InstantiatingObject != null)
			{
				InstantiatingObject(sender, e);
			}
		}

		#endregion

        public virtual IList Conflicts => (IList) ((ArrayList) conflicts).Clone();

	    public virtual IList UnclonedConflicts => conflicts;

	    private ConsistencyMode readConsistency = ConsistencyMode.Default;

        public ConsistencyMode ReadConsistency
        {
            get => readConsistency;
            set => readConsistency = value;
        }

        private ConsistencyMode writeConsistency = ConsistencyMode.Default;

        public ConsistencyMode WriteConsistency
        {
            get => writeConsistency;
            set => writeConsistency = value;
        }

		private IPersistenceEngine GetPersistenceEngine()
		{
			if (m_PersistenceEngineManager != null)
				return m_PersistenceEngineManager;
			return m_PersistenceEngine;
		}

        #region .NET 2.0 Specific Code
#if NET2

        public virtual T TryGetObjectById<T>(object identity)
        {
            object o = this.TryGetObjectById(identity, typeof(T));
            return (T)o;
        }

        public virtual T GetObjectById<T>(object identity)
        {
            object o = this.GetObjectById(identity, typeof(T));
            return (T)o;
        }

        public virtual T GetObjectById<T>(object identity, bool lazy)
        {
            object o = this.GetObjectById(identity, typeof(T), lazy);
            return (T)o;
        }

        public virtual T TryGetObjectByNPath<T>(string npathQuery) => TryGetObjectByNPath<T>(npathQuery, new ArrayList());

	    public virtual T TryGetObjectByNPath<T>(string npathQuery, params QueryParameter[] parameters)
        {
            IList parameterList = new ArrayList(parameters);
            return TryGetObjectByNPath<T>(npathQuery, parameterList);
        }

        public virtual T TryGetObjectByNPath<T>(string npathQuery, IList parameters)
        {
            object o = this.TryGetObjectByNPath(npathQuery, typeof(T), parameters);
            return (T)o;
        }

        public virtual T GetObjectByNPath<T>(string npathQuery) => GetObjectByNPath<T>(npathQuery, new ArrayList());

	    public virtual T GetObjectByNPath<T>(string npathQuery, params QueryParameter[] parameters)
        {
            IList parameterList = new ArrayList(parameters);
            return GetObjectByNPath<T>(npathQuery, parameterList);
        }

        public virtual T GetObjectByNPath<T>(string npathQuery, IList parameters)
        {
            object o = this.GetObjectByNPath(npathQuery, typeof(T), parameters);
            return (T)o;
        }

        public virtual T CreateObject<T>(params object[] ctorArgs)
        {
            object o = this.CreateObject(typeof(T), ctorArgs);
            return (T)o;
        }

        public virtual IList<T> GetObjects<T>()
        {
            List<T> list = new List<T>();
            this.GetObjects (typeof(T), list);
            return list;
        }

        public virtual void DeleteObject<T>(object identity)
        {
            object obj = GetObjectById<T>(identity);
            this.DeleteObject(obj);
        }

        #region GetObjectsByNPath
        public virtual IList<T> GetObjectsByNPath<T>(string npathQuery)
        {
            List<T> list = new List<T>();
            IList parameterList = new ArrayList();
            this.GetObjectsByNPath(new NPathQuery(npathQuery, typeof(T), parameterList), list);
            return list;
        }

        public virtual IList<T> GetObjectsByNPath<T>(string npathQuery, params QueryParameter[] parameters)
        {            
            IList parameterList = new ArrayList(parameters);
            return GetObjectsByNPath<T>(npathQuery, parameterList);
        }

        public virtual IList<T> GetObjectsByNPath<T>(string npathQuery, IList parameters)
        {
            List<T> list = new List<T>();
            this.GetObjectsByNPath(new NPathQuery(npathQuery, typeof(T), parameters), list);
            return list;
        }
#endregion

        #region GetArrayByNPath
        public virtual T[] GetArrayByNPath<T>(string npathQuery) => GetArrayByNPath<T>(npathQuery, new ArrayList());

	    public virtual T[] GetArrayByNPath<T>(string npathQuery, IList parameters)
        {
            DataTable res = this.GetDataTable(npathQuery, typeof(T), parameters);
            if (res.Columns.Count != 1)
                throw new NPersistException("Query must return one column only");

            T[] elements = new T[res.Rows.Count];
            for (int i = 0; i < res.Rows.Count; i++)
            {
                elements[i] = (T)Convert.ChangeType(res.Rows[i][0], typeof(T));
            }

            return elements;
        }

        public virtual T[] GetArrayByNPath<T>(string npathQuery, params QueryParameter[] parameters)
        {
            IList parameterList = new ArrayList(parameters);
            return GetArrayByNPath<T>(npathQuery, parameterList);
        }
#endregion

        #region GetSnapshotObjectsByNPath

        public virtual IList<snapT> GetSnapshotObjectsByNPath<snapT, sourceT>(string npathQuery) => GetSnapshotObjectsByNPath<snapT, sourceT>(npathQuery, new ArrayList());

	    public virtual IList<snapT> GetSnapshotObjectsByNPath<snapT, sourceT>(string npathQuery, IList parameters)
        {
            DataTable res = this.GetDataTable(npathQuery, typeof(sourceT), parameters);
            ConstructorInfo[] constructors = typeof(snapT).GetConstructors();
            ConstructorInfo usedConstructor = null;
            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetParameters().Length == res.Columns.Count)
                {
                    usedConstructor = constructor;
                    break;
                }
            }
            if (usedConstructor == null)
            {
                throw new NPersistException(string.Format("Cound not find a constructor that matches your NPath query on type {0}", typeof(snapT).Name));
            }

            IList<snapT> snapshotObjects = new List<snapT>();
            foreach (DataRow dr in res.Rows)
            {
                for (int i = 0; i < res.Columns.Count; i++)
                {
                    if (dr[i] == DBNull.Value)
                        dr[i] = null;
                }

                snapT snapshotObject = (snapT)Activator.CreateInstance(typeof(snapT), dr.ItemArray);
                snapshotObjects.Add(snapshotObject);
            }

            return snapshotObjects;
        }

        public virtual IList<snapT> GetSnapshotObjectsByNPath<snapT, sourceT>(string npathQuery, params QueryParameter[] parameters)
        {
            IList parameterList = new ArrayList(parameters);
            return GetSnapshotObjectsByNPath<snapT, sourceT>(npathQuery, parameterList);
        }
#endregion

#endif
        #endregion
    }
}
