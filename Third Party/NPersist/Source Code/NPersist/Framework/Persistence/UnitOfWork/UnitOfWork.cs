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
using System.Text;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NCore.Framework.Logging;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Sql.Dom;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class UnitOfWork : ContextChild, IUnitOfWork
	{
		private ArrayList m_listCreated = new ArrayList();
		private ArrayList m_listDirty = new ArrayList();
		private Hashtable m_hashStillDirty = new Hashtable();
		private ArrayList m_listDeleted = new ArrayList();
//		private ArrayList m_listPOCO = new ArrayList();
		private Hashtable m_objectStatusLookup = new Hashtable() ;

		private ArrayList m_listInserted = new ArrayList();
		private ArrayList m_listUpdated = new ArrayList();
		private ArrayList m_listRemoved = new ArrayList();

		private Hashtable m_hashSpeciallyUpdated = new Hashtable();

		private TopologicalGraph m_topologicalDelete = new TopologicalGraph();

		private IList exceptions = new ArrayList();

		public IList Exceptions => exceptions;

	    public virtual void RegisterCreated(object obj)
		{
            LogMessage message = new LogMessage("Registering object as up for creation");
            LogMessage verbose = new LogMessage("Type: {0}" ,obj.GetType());
			this.Context.LogManager.Info(this, message,verbose ); // do not localize
			object result = m_objectStatusLookup[obj];
			if (result != null)
			{
				ObjectStatus objStatus = (ObjectStatus) result;
				if (objStatus == ObjectStatus.Dirty)
				{
					throw new UnitOfWorkException("Can't register object as 'Created' when it is already registered as 'Dirty'!"); // do not localize					
				}
				if (objStatus == ObjectStatus.UpForDeletion)
				{
					throw new UnitOfWorkException("Can't register object as 'Created' when it is already registered as 'Deleted'!"); // do not localize
				}
				if (objStatus == ObjectStatus.UpForCreation)
				{
					throw new UnitOfWorkException("Object is already registered as 'Created'!"); // do not localize
				}
			}
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
			m_listCreated.Add(obj);
			m_objectStatusLookup[obj] = ObjectStatus.UpForCreation;
			this.Context.ObjectManager.SetObjectStatus(obj, ObjectStatus.UpForCreation);
			this.Context.IdentityMap.RegisterCreatedObject(obj);
		}

		public virtual void RegisterDirty(object obj)
		{
            LogMessage message = new LogMessage("Registering object as dirty");
            LogMessage verbose = new LogMessage("Type: {0}" , obj.GetType());

            this.Context.LogManager.Info(this, message, verbose); // do not localize
			object result = m_objectStatusLookup[obj];
			if (result != null)
			{
				ObjectStatus objStatus = (ObjectStatus) result;
				if (objStatus == ObjectStatus.UpForDeletion)
				{
					throw new UnitOfWorkException("Can't register object as 'Dirty' when it is already registered as 'Deleted'!"); // do not localize
				}
				if (objStatus == ObjectStatus.UpForCreation)
				{
					return;
				}
			}
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);

			//Following bug fix (adding the if) submitted by Vlad Ivanov
			if(m_listDirty.IndexOf(obj)==-1) 
			{ 
				m_listDirty.Add(obj); 
			} 

			m_objectStatusLookup[obj] = ObjectStatus.Dirty;
			this.Context.ObjectManager.SetObjectStatus(obj, ObjectStatus.Dirty);
		}

		public virtual void RegisterDeleted(object obj)
		{
            LogMessage message = new LogMessage("Registering object as up for deletion");
            LogMessage verbose = new LogMessage("Type: {0}" , obj.GetType());

			this.Context.LogManager.Info(this,message , verbose); // do not localize

			object result = m_objectStatusLookup[obj];
            bool addToDeleted = true;
			if (result != null)
			{
				ObjectStatus objStatus = (ObjectStatus) result;
				if (objStatus == ObjectStatus.UpForCreation)
				{
                    //If the object has been created during the same Unit of Work, we don't have to
                    //wait for a commit operation to let the object enter a state of Deleted (that is,
                    //the object does not have to enter the state of UpForDeletion until commit makes it Deleted)
					m_listCreated.Remove(obj);
					m_objectStatusLookup.Remove(obj);
                    this.Context.ObjectManager.ClearUpdatedStatuses(obj);
                    this.Context.ObjectManager.SetObjectStatus(obj, ObjectStatus.Deleted);
                    addToDeleted = false;
				}
			}
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
            if (addToDeleted)
            {
                m_listDirty.Remove(obj);
                m_listDeleted.Add(obj);
                m_objectStatusLookup[obj] = ObjectStatus.UpForDeletion;
                this.Context.ObjectManager.SetObjectStatus(obj, ObjectStatus.UpForDeletion);
            }
			//this.Context.IdentityMap.RemoveObject(obj);
		}

		public virtual void RegisterClean(object obj)
		{
            LogMessage message = new LogMessage("Registering object as clean");
            LogMessage verbose = new LogMessage("Type: {0}", obj.GetType());

			this.Context.LogManager.Info(this,message , verbose); // do not localize
			m_objectStatusLookup.Remove(obj);
			m_listCreated.Remove(obj);
			m_listDirty.Remove(obj);
			m_listDeleted.Remove(obj);
			this.Context.ObjectManager.SetObjectStatus(obj, ObjectStatus.Clean);
		}

		public virtual void Complete()
		{
            NotifyCommitted();
			CommitInserted();
			CommitUpdated();
			CommitRemoved();
			CommitSpeciallyUpdated();
			if (this.Context.IsEditing)
				this.Context.EndEdit() ;
		}

		public virtual void Abort()
		{
			AbortInserted();
			AbortUpdated();
			AbortRemoved();
			AbortSpeciallyUpdated();
			if (this.Context.IsEditing)
				this.Context.CancelEdit() ;
		}

		public virtual void AbortInserted()
		{
			IObjectManager om = this.Context.ObjectManager;
			foreach (object obj in m_listInserted)
			{
				IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );
				//we must roll back autoincreasers
				if (classMap.HasAssignedBySource() )
				{
					foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
					{
						if (propertyMap.IsAssignedBySource)
						{
							string prevId = om.GetObjectIdentity(obj);
							om.SetPropertyValue(obj, propertyMap.Name, 0);			
							this.Context.IdentityMap.UpdateIdentity(obj, prevId);
						}
					}
				}
				m_listCreated.Add(obj);
				om.SetObjectStatus(obj, ObjectStatus.UpForCreation);
			}			
			m_listInserted.Clear() ;
		}

		public virtual void AbortUpdated()
		{
			foreach (object obj in m_listUpdated)
			{
				m_listDirty.Add(obj);
			}			
			m_listUpdated.Clear() ;
		}

		public virtual void AbortRemoved()
		{
			foreach (object obj in m_listRemoved)
			{
				m_listDeleted.Add(obj);
			}			
			m_listRemoved.Clear() ;
		}

   
		protected void AddSpeciallyUpdated(object obj)
		{
			Hashtable cachedOriginals = (Hashtable) m_hashSpeciallyUpdated[obj];
			if (cachedOriginals != null)
				return;

			cachedOriginals = new Hashtable();
			m_hashSpeciallyUpdated[obj] = cachedOriginals;

			IObjectManager om = this.Context.ObjectManager;
			IListManager lm = this.Context.ListManager;
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );

			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
			{
				cachedOriginals[propertyMap.Name] = om.GetOriginalPropertyValue(obj, propertyMap.Name);			
				CopyValuesToOriginals(propertyMap, lm, obj, om);
			}
		}

		protected void AbortSpeciallyUpdated()
		{
			foreach (object obj in m_hashSpeciallyUpdated.Keys)
			{
				AbortSpeciallyUpdated(obj);
			}
		}

		protected void AbortSpeciallyUpdated(object obj)
		{
			Hashtable cachedOriginals = (Hashtable) m_hashSpeciallyUpdated[obj];
			if (cachedOriginals != null)
				return;

			cachedOriginals = new Hashtable();
			m_hashSpeciallyUpdated[obj] = cachedOriginals;

			IObjectManager om = this.Context.ObjectManager;
			IListManager lm = this.Context.ListManager;
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );

			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
			{
				om.SetOriginalPropertyValue(obj, propertyMap.Name, cachedOriginals[propertyMap.Name]);
			}
		}


        public virtual void NotifyCommitted()
		{
			foreach (object obj in m_listInserted)
			{
                this.Context.InverseManager.NotifyCommitted(obj);
			}
			foreach (object obj in m_listUpdated)
			{
                this.Context.InverseManager.NotifyCommitted(obj);
			}			
			foreach (object obj in m_listRemoved)
			{
                this.Context.InverseManager.NotifyCommitted(obj);
			}			
		}

		public virtual void CommitInserted()
		{
			foreach (object obj in m_listInserted)
			{
				CommitPersisted(obj, true);
			}
			m_listInserted.Clear() ;
		}

		public virtual void CommitUpdated()
		{
			foreach (object obj in m_listUpdated)
			{
				CommitPersisted(obj, false);
			}			
			m_listUpdated.Clear() ;
		}

		public virtual void CommitRemoved()
		{
			foreach (object obj in m_listRemoved)
			{
				m_objectStatusLookup.Remove(obj);
				this.Context.ObjectManager.ClearUpdatedStatuses(obj);
				this.Context.ObjectManager.SetObjectStatus(obj, ObjectStatus.Deleted);
				this.Context.IdentityMap.RemoveObject(obj);
			}			
			m_listRemoved.Clear() ;
		}

		public virtual void CommitSpeciallyUpdated() => m_hashSpeciallyUpdated.Clear();

	    protected virtual void CommitPersisted(object obj, bool isInserted)
		{
			IObjectManager om = this.Context.ObjectManager;
			IListManager lm = this.Context.ListManager;
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
			{
				if (isInserted || om.GetPropertyStatus(obj, propertyMap.Name) != PropertyStatus.NotLoaded)
					CopyValuesToOriginals(propertyMap, lm, obj, om);
				else
					Console.WriteLine(propertyMap.Name);
			}
			m_objectStatusLookup.Remove(obj);
			this.Context.ObjectManager.ClearUpdatedStatuses(obj);
			this.Context.ObjectManager.SetObjectStatus(obj, ObjectStatus.Clean);
		}

		protected void CopyValuesToOriginals(IPropertyMap propertyMap, IListManager lm, object obj, IObjectManager om)
		{
			if (propertyMap.IsCollection)
			{
				//IList list =   lm.CloneList(obj, propertyMap, ((IList) (om.GetPropertyValue(obj, propertyMap.Name))));
				IInterceptableList list = om.GetPropertyValue(obj, propertyMap.Name) as IInterceptableList;
				IList orgList = null;
				if (list != null)
				{
					bool stackMute = list.MuteNotify;
					list.MuteNotify = true;
					orgList =  new ArrayList( list );
					list.MuteNotify = stackMute;
				}
				om.SetOriginalPropertyValue(obj, propertyMap.Name, orgList);						
			}
			else
			{
				if (om.GetNullValueStatus(obj, propertyMap.Name))
				{
					om.SetOriginalPropertyValue(obj, propertyMap.Name, System.DBNull.Value);						
				}
				else
				{						
					om.SetOriginalPropertyValue(obj, propertyMap.Name, om.GetPropertyValue(obj, propertyMap.Name));
				}						
			}
		}


		public virtual void Commit(int exceptionLimit)
		{
			this.Context.LogManager.Info(this, "Committing Unit of Work"); // do not localize

            if (this.Context.UnclonedConflicts.Count > 0)
                throw new UnresolvedConflictsException("There are unresolved conflicts. Please resolve all conflicts before committing.", this.Context.Conflicts);

			exceptions = new ArrayList(); 

			m_hashSpeciallyUpdated.Clear() ;

			try
			{
				if (this.Context.ValidateBeforeCommit)
				{
					this.Context.ValidateUnitOfWork(exceptions);

					//Bug in following line fixed by Vlad Ivanov
					if (exceptions!=null && exceptions.Count > 0)
					{
						Abort();	

						throw new ExceptionLimitExceededException(exceptions);					
					}
				}

				this.Context.PersistenceEngine.Begin();

				RefreshCommitRegions();

				if (this.Context.UnclonedConflicts.Count > 0)
				{
					this.Context.PersistenceEngine.Abort();
					Abort();	

					throw new UnresolvedConflictsException("Refreshing the commit regions yielded optimistic concurrency conflicts. Please resolve these conflicts before committing.", this.Context.Conflicts);
				}

				if (exceptions!=null && exceptions.Count > 0)
				{
					this.Context.PersistenceEngine.Abort();
					Abort();	

					throw new ExceptionLimitExceededException(exceptions);					
				}

                TouchLockTables(null, exceptionLimit, DeadlockStrategy.Default, null);
                InsertCreated(exceptionLimit); 
				UpdateDirty(exceptionLimit);
				UpdateStillDirty(exceptionLimit);
                ExamineDeletedObjects();
				RemoveDeleted(exceptionLimit);	
				
				this.Context.PersistenceEngine.Commit();

				//Bug in following line fixed by Vlad Ivanov
				if (exceptions!=null && exceptions.Count > 0)
				{
    				this.Context.PersistenceEngine.Abort();
					Abort();	

					throw new ExceptionLimitExceededException(exceptions);					
				}
				else
				{
					Complete();					
				}
			}

			catch (Exception ex)
			{
				this.Context.PersistenceEngine.Abort();
				Abort();	

				if (exceptionLimit == 1)
				{
					if (ex is ExceptionLimitExceededException)
						foreach (Exception inner in ((ExceptionLimitExceededException) ex).InnerExceptions )
							throw inner;
					throw ex;
				}

				if (ex != null && ex.GetType() != typeof(ExceptionLimitExceededException))
					exceptions.Add(ex);

				if (exceptions.Count == 1)
					throw (Exception) exceptions[0];

				throw new ExceptionLimitExceededException(exceptions);
			}
		}

		public void CommitObject(object obj, int exceptionLimit)
		{
            LogMessage message = new LogMessage("Committing object");
            LogMessage verbose = new LogMessage("Type: {0}" , obj.GetType());

			this.Context.LogManager.Info(this, message, verbose); // do not localize

			if (this.Context.Conflicts.Count > 0)
				throw new UnresolvedConflictsException("There are unresolved conflicts. Please resolve all conflicts before committing.", this.Context.Conflicts);

			exceptions = new ArrayList(); 
			m_hashSpeciallyUpdated.Clear() ;
			
			try
			{
				this.Context.PersistenceEngine.Begin();

				RefreshCommitRegions(obj);

				if (this.Context.Conflicts.Count > 0)
				{
					this.Context.PersistenceEngine.Abort();
					Abort();	

					throw new UnresolvedConflictsException("Refreshing the commit regions yielded optimistic concurrency conflicts. Please resolve these conflicts before committing.", this.Context.Conflicts);
				}

				if (exceptions!=null && exceptions.Count > 0)
				{
					this.Context.PersistenceEngine.Abort();
					Abort();	

					throw new ExceptionLimitExceededException(exceptions);					
				}

                TouchLockTables(obj, exceptionLimit, DeadlockStrategy.Default, null);
                InsertCreated(obj, exceptionLimit);
				UpdateDirty(obj, exceptionLimit);
				UpdateStillDirty(obj, exceptionLimit);
				RemoveDeleted(obj, exceptionLimit);

				this.Context.PersistenceEngine.Commit();

				//Bug in following line fixed by Vlad Ivanov
				if (exceptions != null && exceptions.Count > 0)
				{
					this.Context.PersistenceEngine.Abort();
					Abort();	

					throw new ExceptionLimitExceededException(exceptions);					
				}
				else
				{
					Complete();					
				}
			}
			catch (Exception ex)
			{
				this.Context.PersistenceEngine.Abort();
				Abort();				

				if (exceptionLimit == 1)
				{
					if (ex is ExceptionLimitExceededException)
						foreach (Exception inner in ((ExceptionLimitExceededException) ex).InnerExceptions )
							throw inner;
					throw ex;
				}

				if (ex != null && ex.GetType() != typeof(ExceptionLimitExceededException) )
					exceptions.Add(ex);

				if (exceptions.Count == 1)
					throw (Exception) exceptions[0];

				throw new ExceptionLimitExceededException(exceptions);
			}

		}

		protected virtual void RefreshCommitRegions()
		{
			Hashtable commitRegionObjects = new Hashtable();

			foreach (object obj in m_listDirty)
				RefreshCommitRegions(commitRegionObjects, obj);
			foreach (object obj in m_listDeleted)
				RefreshCommitRegions(commitRegionObjects, obj);

			ValidateCommitRegions(commitRegionObjects);

		}

		protected virtual void RefreshCommitRegions(object obj)
		{
			Hashtable commitRegionObjects = new Hashtable();
			RefreshCommitRegions(commitRegionObjects, obj);

			if (this.Context.Conflicts.Count < 1)
				ValidateCommitRegions(commitRegionObjects);
		}

		protected virtual void RefreshCommitRegions(Hashtable commitRegionObjects, object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			IList commitRegions = classMap.GetCommitRegions();
			RefreshCommitRegions(commitRegions, commitRegionObjects, obj);

			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (this.Context.GetPropertyStatus(obj, propertyMap.Name) == PropertyStatus.Dirty)
				{
					commitRegions = propertyMap.GetCommitRegions();
					RefreshCommitRegions(commitRegions, commitRegionObjects, obj);					
				}
			}
		}

		protected virtual void RefreshCommitRegions(IList commitRegions, Hashtable commitRegionObjects, object obj)
		{
			foreach (string commitRegion in commitRegions)
			{
				NPathQuery npathQuery = null;
				if (commitRegion.ToLower().TrimStart().Substring(0, "select".Length) == "select")
					npathQuery = GetLoadObjectNPathQueryWithSelect(obj, commitRegion, RefreshBehaviorType.LogConcurrencyConflict);
				else
					npathQuery = this.Context.GetLoadObjectNPathQuery(obj, commitRegion, RefreshBehaviorType.LogConcurrencyConflict);
				this.Context.GetObjectsByNPath(npathQuery);
				foreach (object regionObject in this.Context.LoadedInLatestQuery.Values)
					commitRegionObjects[regionObject] = regionObject;
			}
		}

		public virtual NPathQuery GetLoadObjectNPathQueryWithSelect(object obj, string npathQueryString, RefreshBehaviorType refreshBehavior)
		{
			IClassMap classMap = this.Context.NPathEngine.GetRootClassMap(npathQueryString, this.Context.DomainMap);
			Type type = this.Context.AssemblyManager.MustGetTypeFromClassMap(classMap);

			NPathQuery npathQuery = new NPathQuery(npathQueryString, type);
			npathQuery.RefreshBehavior = refreshBehavior;

			npathQuery.Parameters.Add(new QueryParameter(DbType.Object, obj));

			return npathQuery;
		}


		protected virtual void ValidateCommitRegions(Hashtable commitRegionObjects)
		{
			if (this.Context.Conflicts.Count < 1)
			{
				foreach (object obj in commitRegionObjects.Values)
					this.Context.ValidateObject(obj, this.exceptions);
			}			
		}

        public virtual void TouchLockTables(object obj, int exceptionLimit, DeadlockStrategy deadlockStrategy, IList tables)
        {
            if (deadlockStrategy == DeadlockStrategy.Default)
                deadlockStrategy = this.Context.GetDeadlockStrategy();
            
            switch (deadlockStrategy)
            {
                case DeadlockStrategy.Default:
                case DeadlockStrategy.None:
                    return;
                case DeadlockStrategy.TouchLockTable:
                    TouchLockTable(obj, exceptionLimit);
                    break;
                case DeadlockStrategy.TouchTablesInOrder:
                    TouchLockTablesInOrder(obj, exceptionLimit, tables);
                    break;

                default:
                    throw new NPersistException(String.Format("Unknown deadlock strategy {0}!", deadlockStrategy.ToString()));
            }
        }

        protected virtual void TouchLockTablesInOrder(object obj, int exceptionLimit, IList tables)
        {
            ArrayList sorted = null;
            if (tables == null)
            {
                Hashtable tableMaps = GetConcernedTableMaps(obj, exceptionLimit);
                sorted = new ArrayList(tableMaps.Keys);
            }
            else
                sorted = (ArrayList) tables;

            sorted.Sort(new TableLockIndexSorter());

            foreach (ITableMap tableMap in sorted)
                this.Context.PersistenceEngineManager.TouchTable(tableMap, exceptionLimit);
        }

        protected virtual void TouchLockTable(object obj, int exceptionLimit)
        {
            Hashtable sourceMaps = GetConcernedSourceMaps(obj, exceptionLimit);
            foreach (ISourceMap sourceMap in sourceMaps.Keys)
            {
                ITableMap tableMap = sourceMap.GetLockTable();
                if (tableMap != null)
                    this.Context.PersistenceEngineManager.TouchTable(tableMap, exceptionLimit);
            }
        }

        protected virtual Hashtable GetConcernedSourceMaps(object obj, int exceptionLimit)
        {
            Hashtable sourceMaps = new Hashtable();
            IDomainMap dm = this.Context.DomainMap;
            IObjectManager om = this.Context.ObjectManager;
            if (dm.SourceMaps.Count > 0)
            {
                if (dm.SourceMaps.Count == 1)
                {
                    ISourceMap sourceMap = dm.GetSourceMap();
                    sourceMaps[sourceMap] = sourceMap;
                }
                else
                {
                    if (obj != null)
                    {
                        GetConcernedSourceMaps(obj, exceptionLimit, sourceMaps, dm, om, false);
                    }
                    else
                    {
                        foreach (object iObj in m_listCreated)
                            GetConcernedSourceMaps(iObj, exceptionLimit, sourceMaps, dm, om, false);
                        foreach (object iObj in m_listDirty)
                            GetConcernedSourceMaps(iObj, exceptionLimit, sourceMaps, dm, om, true);
                        foreach (object iObj in m_listDeleted)
                            GetConcernedSourceMaps(iObj, exceptionLimit, sourceMaps, dm, om, false);
                    }
                }
            }
            return sourceMaps;
        }

        protected virtual Hashtable GetConcernedSourceMaps(object obj, int exceptionLimit, Hashtable sourceMaps, IDomainMap dm, IObjectManager om, bool update)
        {
            if (obj == null)
                return null;
            ITableMap tableMap = null;
            IClassMap classMap = dm.MustGetClassMap(obj.GetType());
            if (classMap.Table != "")
            {
                tableMap = classMap.GetTableMap();
                if (tableMap != null)
                    sourceMaps[tableMap.SourceMap] = tableMap.SourceMap;
                foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
                {
                    if (propertyMap.Table != "")
                    {
                        if (!(propertyMap.IsSlave || propertyMap.IsReadOnly))
                        {
                            bool ok = true;
                            if (update)
                            {
                                PropertyStatus propStatus = om.GetPropertyStatus(obj, propertyMap.Name);
                                if (propStatus != PropertyStatus.Dirty)
                                    ok = false;
                            }
                            if (ok)
                            {
                                tableMap = propertyMap.GetTableMap();
                                if (tableMap != null)
                                    sourceMaps[tableMap.SourceMap] = tableMap.SourceMap;
                            }
                        }
                    }
                }
            }

            return sourceMaps;
        }


        protected virtual Hashtable GetConcernedTableMaps(object obj, int exceptionLimit)
        {
            Hashtable tableMaps = new Hashtable();
            IDomainMap dm = this.Context.DomainMap;
            IObjectManager om = this.Context.ObjectManager;
            if (dm.SourceMaps.Count > 0)
            {
                if (obj != null)
                {
                    GetConcernedTableMaps(obj, exceptionLimit, tableMaps, dm, om, false);
                }
                else
                {
                    foreach (object iObj in m_listCreated)
                        GetConcernedTableMaps(iObj, exceptionLimit, tableMaps, dm, om, false);
                    foreach (object iObj in m_listDirty)
                        GetConcernedTableMaps(iObj, exceptionLimit, tableMaps, dm, om, true);
                    foreach (object iObj in m_listDeleted)
                        GetConcernedTableMaps(iObj, exceptionLimit, tableMaps, dm, om, false);
                }
            }
            return tableMaps;
        }

        protected virtual Hashtable GetConcernedTableMaps(object obj, int exceptionLimit, Hashtable tableMaps, IDomainMap dm, IObjectManager om, bool update)
        {
            if (obj == null)
                return null;
            ITableMap tableMap = null;
            IClassMap classMap = dm.MustGetClassMap(obj.GetType());
            if (classMap.Table != "")
            {
                tableMap = classMap.GetTableMap();
                if (tableMap != null)
                    tableMaps[tableMap] = tableMap;
                foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
                {
                    if (propertyMap.Table != "")
                    {
                        if (!(propertyMap.IsSlave || propertyMap.IsReadOnly))
                        {
                            bool ok = true;
                            if (update)
                            {
                                PropertyStatus propStatus = om.GetPropertyStatus(obj, propertyMap.Name);
                                if (propStatus != PropertyStatus.Dirty)
                                    ok = false;
                            }
                            if (ok)
                            {
                                tableMap = propertyMap.GetTableMap();
                                if (tableMap != null)
                                    tableMaps[tableMap] = tableMap;
                            }
                        }
                    }
                }
            }

            return tableMaps;
        }

		protected virtual void InsertCreated(int exceptionLimit) => InsertCreated(null, exceptionLimit);

	    protected virtual void InsertCreated(object forObj, int exceptionLimit)
		{
            this.Context.LogManager.Debug(this, "Inserting objects that are up for creation");	 // do not localize			

			try
			{
				long cnt;
				int cntStale = 0;
				bool noCheck = false;
				IList stillDirty = new ArrayList() ;
				ArrayList insertObjects = new ArrayList();
				cnt = m_listCreated.Count;
				IObjectManager om = this.Context.ObjectManager;
				IPersistenceEngine pe = this.Context.PersistenceEngine;
				while (cnt > 0)
				{
					try
					{
						insertObjects.Clear();
						foreach (object obj in m_listCreated)
						{
							try
							{
								if (forObj != null)
								{
									if (obj == forObj)
									{
										insertObjects.Add(obj);
									}
								}
								else
								{
									if (noCheck)
									{							
										if (MayInsert(obj, true, true))
										{							
											insertObjects.Add(obj);
											noCheck = false;
										}
									}
									else
									{
										if (MayInsert(obj, true, false))
										{							
											insertObjects.Add(obj);
										}							
									}
								}							
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						foreach (object obj in insertObjects)
						{
							//this should be the only necessary try block in this 
							//method (and it ought only to be around the call to the
							//persistence engine, at that) but we add the other tries
							//to ensure that some exception from the framework doesn't
							//ruin the beautiful concept with collecting exceptions :-)
							try 
							{
								m_listCreated.Remove(obj);
								m_listInserted.Add(obj);
								stillDirty.Clear() ;
								pe.InsertObject(obj, stillDirty);
								om.SetObjectStatus(obj, ObjectStatus.Clean);

                                LogMessage message = new LogMessage("Inserted object");
                                LogMessage verbose = new LogMessage("Type: {0},  Still dirty: {1}" , obj.GetType(), stillDirty);
								this.Context.LogManager.Debug(this,message , verbose); // do not localize
								if (stillDirty.Count > 0)
								{
									IList cloneList = new ArrayList();
									foreach (object clone in stillDirty)
									{
										cloneList.Add(clone);
									}
									m_hashStillDirty[obj] = cloneList ;
								}
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						if (m_listCreated.Count == cnt)
						{
							noCheck = true;
							cntStale++;
							if (cntStale > 1)
							{
								throw new NPersistException("Cyclic dependency among objects up for creation could not be resolved!"); // do not localize
							}
						}
						else
						{
							cntStale = 0;
							noCheck = false;
						}
						if (forObj != null)
						{
							cnt = 0;
						}
						else
						{
							cnt = m_listCreated.Count;
						}
					}
					catch (Exception ex)
					{
						if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
							throw ex;
						exceptions.Add(ex);
					}
				}				
			}
			catch (Exception ex)
			{
				if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
					throw ex;
				exceptions.Add(ex);
			}
		}

		protected virtual void UpdateDirty(int exceptionLimit) => UpdateDirty(null, exceptionLimit);

	    protected virtual void UpdateDirty(object forObj, int exceptionLimit)
		{
			this.Context.LogManager.Debug(this, "Updating dirty objects"); // do not localize				

			try
			{
				long cnt;
				bool noCheck = false;
				ArrayList updateObjects = new ArrayList();
				IList stillDirty = new ArrayList() ;
				cnt = m_listDirty.Count;
				IObjectManager om = this.Context.ObjectManager;
				IPersistenceEngine pe = this.Context.PersistenceEngine;
				while (cnt > 0)
				{
					try
					{
						updateObjects.Clear();
						foreach (object obj in m_listDirty)
						{
							try
							{
								if (forObj != null)
								{
									if (obj == forObj)
									{
										updateObjects.Add(obj);
									}
								}
								else
								{
									if (noCheck || MayUpdate(obj))
									{
										updateObjects.Add(obj);
										noCheck = false;
									}
								}						
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						foreach (object obj in updateObjects)
						{
							try 
							{
								m_listDirty.Remove(obj);
								m_listUpdated.Add(obj);
								stillDirty.Clear() ;
								pe.UpdateObject(obj, stillDirty);
                                LogMessage message = new LogMessage("Updated object");
                                LogMessage verbose = new LogMessage("Type: {0}, Still dirty: {1}" , obj.GetType(),stillDirty.Count);

								this.Context.LogManager.Debug(this, message, verbose ); // do not localize
								if (stillDirty.Count > 0)
								{
									IList cloneList = new ArrayList();
									foreach (object clone in stillDirty)
									{
										cloneList.Add(clone);
									}
									m_hashStillDirty[obj] = cloneList ;						
								}
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						if (m_listDirty.Count == cnt)
						{
							noCheck = true;
						}
						if (forObj != null)
						{
							cnt = 0;
						}
						else
						{
							cnt = m_listDirty.Count;
						}
					
					}
					catch (Exception ex)
					{
						if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
							throw ex;
						exceptions.Add(ex);
					}
				}				
			}
			catch (Exception ex)
			{
				if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
					throw ex;
				exceptions.Add(ex);
			}
		}

		protected virtual void UpdateStillDirty(int exceptionLimit) => UpdateStillDirty(null, exceptionLimit);

	    protected virtual void UpdateStillDirty(object forObj, int exceptionLimit)
		{
			this.Context.LogManager.Debug(this, "Updating still dirty objects"); // do not localize				

			try
			{
				long cnt;
				bool noCheck = false;
				ArrayList updateObjects = new ArrayList();
				IList stillDirty;
				cnt = m_hashStillDirty.Count;
				IObjectManager om = this.Context.ObjectManager;
				IPersistenceEngine pe = this.Context.PersistenceEngine;
				while (cnt > 0)
				{
					try
					{
						updateObjects.Clear();
						foreach (object obj in m_hashStillDirty.Keys)
						{
							try
							{
								if (forObj != null)
								{
									if (obj == forObj)
									{
										updateObjects.Add(obj);
									}
								}
								else
								{
									if (noCheck || MayUpdate(obj))
									{
										updateObjects.Add(obj);
										noCheck = false;
									}
								}						
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						foreach (object obj in updateObjects)
						{
							try
							{
								stillDirty = (IList) m_hashStillDirty[obj] ;
								m_hashStillDirty.Remove(obj);
								pe.UpdateObject(obj, stillDirty);
                                LogMessage message = new LogMessage("Updated still dirty object");
                                LogMessage verbose = new LogMessage("Type: {0}, Still dirty: {1}" , obj.GetType(), stillDirty.Count);
								this.Context.LogManager.Debug(this,message ,verbose); // do not localize
								if (stillDirty.Count > 0)
								{
									IList cloneList = new ArrayList();
									foreach (object clone in stillDirty)
									{
										cloneList.Add(clone);
									}
									m_hashStillDirty[obj] = cloneList ;						
								}						
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						if (m_hashStillDirty.Count == cnt)
						{
							noCheck = true;
						}
						if (forObj != null)
						{
							cnt = 0;
						}
						else
						{
							cnt = m_hashStillDirty.Count;
						}
					
					}
					catch (Exception ex)
					{
						if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
							throw ex;
						exceptions.Add(ex);
					}
				}
				
			}
			catch (Exception ex)
			{
				if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
					throw ex;
				exceptions.Add(ex);
			}
		}

		protected virtual void RemoveDeleted(int exceptionLimit) => RemoveDeleted(null, exceptionLimit);

	    protected virtual void RemoveDeleted(object forObj, int exceptionLimit)
		{
			this.Context.LogManager.Debug(this, "Removing objects that are up for deletion"); // do not localize			
	
			try
			{
				long cnt;
				long staleCnt = 0;
				bool tryForce = false;
				ArrayList removeObjects = new ArrayList();
				cnt = m_listDeleted.Count;
				IObjectManager om = this.Context.ObjectManager;
				IPersistenceEngine pe = this.Context.PersistenceEngine;
				while (cnt > 0)
				{
					try
					{
						removeObjects.Clear();
						foreach (object obj in m_listDeleted)
						{
							try
							{
								if (forObj != null)
								{
									if (obj == forObj)
									{
										removeObjects.Add(obj);
									}
								}
								else
								{
                                    if (tryForce)
                                    {
                                        if (MayForceDelete(obj))
                                        {
											//Force an update all the referencing objects, which should have had their
											//references to our object set to null in advance during the delete operation.
											//This way all the references to our object should be set to null in the database.
											TopologicalNode node = (TopologicalNode) m_topologicalDelete.Graph[obj];
											if (node != null)
											{
												foreach (TopologicalNode waitForNode in node.WaitFor)
												{
													IList dummyStillDirty = new ArrayList();
													pe.UpdateObject(waitForNode.Obj, dummyStillDirty);
													AddSpeciallyUpdated(waitForNode.Obj);
												}
											}
											tryForce = false;
											removeObjects.Add(obj);												
										}
                                    }
                                    else
                                    {
									    if (MayRemove(obj))
									    {
										    removeObjects.Add(obj);
									    }
                                    }
								}						
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						foreach (object obj in removeObjects)
						{
							try
							{
								m_listDeleted.Remove(obj);
								m_listRemoved.Add(obj);
								m_topologicalDelete.RemoveNode(obj);
								pe.RemoveObject(obj);
								this.Context.LogManager.Debug(this, "Removed object" ); // do not localize						
							}
							catch (Exception ex)
							{
								if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
									throw ex;
								exceptions.Add(ex);
							}
						}
						if (m_listDeleted.Count == cnt)
						{
                            if (staleCnt > 0)
                            {
                                throw new UnitOfWorkException("The objects that are up for deletion in the unit of work are arranged in an unresolvable graph!");
                            }
                            else 
                            {
							    tryForce = true;
                                staleCnt++;
                            }
						}
                        else
                        {
                            staleCnt = 0;
                        }
						if (forObj != null)
						{
							cnt = 0;
						}
						else
						{
							cnt = m_listDeleted.Count;
						}					
					}
					catch (Exception ex)
					{
						if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
							throw ex;
						exceptions.Add(ex);
					}
				}				
			}
			catch (Exception ex)
			{
				if (exceptionLimit > 0 && exceptions.Count >= exceptionLimit - 1)
					throw ex;
				exceptions.Add(ex);
			}
		}

		protected virtual bool MayInsert(object obj, bool checkAllReferences, bool weakCheck)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			IObjectManager om = this.Context.ObjectManager;
			IList list;
			object refObj;
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (!propertyMap.IsReadOnly && !propertyMap.IsSlave)
				{
					if (!(propertyMap.ReferenceType == ReferenceType.None))
					{
						if (checkAllReferences || propertyMap.MustGetReferencedClassMap().HasIdAssignedBySource())
						{
							if (propertyMap.IsCollection)
							{
								list = (IList) om.GetPropertyValue(obj, propertyMap.Name);
								if (list != null)
								{
									foreach (object itemRefObj in list)
									{
										if (m_listCreated.Contains(itemRefObj))
										{
											if (weakCheck)
											{
												if (propertyMap.IsIdentity)
												{
													return false;													
												}
											}
											else
											{
												return false;												
											}
										}
									}
								}
							}
							else
							{
								refObj = om.GetPropertyValue(obj, propertyMap.Name);
								if (refObj != null)
								{
									if (m_listCreated.Contains(refObj))
									{
										if (weakCheck)
										{
											if (propertyMap.IsIdentity)
											{
												return false;													
											}
										}
										else
										{
											return false;												
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}

		protected virtual bool MayUpdate(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			IObjectManager om = this.Context.ObjectManager;
			object refObj;
			IList list;
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (!propertyMap.IsReadOnly && !propertyMap.IsSlave)
				{
					if (!(propertyMap.ReferenceType == ReferenceType.None))
					{
						if (propertyMap.IsCollection)
						{
							list = (IList) om.GetPropertyValue(obj, propertyMap.Name);
							if (list != null)
							{
								foreach (object itemRefObj in list)
								{
									if (m_listCreated.Contains(itemRefObj))
									{
										return false;
									}
								}
							}
						}
						else
						{
							refObj = om.GetPropertyValue(obj, propertyMap.Name);
							if (refObj != null)
							{
								if (m_listCreated.Contains(refObj))
								{
									return false;
								}
							}
						}
					}
				}
			}
			return true;
		}

		protected virtual bool MayRemove(object obj)
		{
            if (m_topologicalDelete.IsWaiting(obj))
                return false;
            return true;
		}

		public ArrayList GetCreatedObjects() => m_listCreated;

	    public ArrayList GetDeletedObjects() => m_listDeleted;

	    public ArrayList GetDirtyObjects() => m_listDirty;

	    private void ExamineDeletedObjects()
        {
            m_topologicalDelete.Graph.Clear();
            IObjectManager om = this.Context.ObjectManager;
            Hashtable hashDeleted = new Hashtable();
			foreach (object delObj in m_listDeleted)
			{
                hashDeleted[delObj] = delObj;
            }
			foreach (object delObj in m_listDeleted)
			{
                ExamineDeletedObject(hashDeleted, om, delObj);
            }
        }

        private void ExamineDeletedObject(Hashtable hashDeleted, IObjectManager om, object delObj)
        {
			IClassMap delObjClassMap = this.Context.DomainMap.MustGetClassMap(delObj.GetType());
			foreach (IPropertyMap propertyMap in delObjClassMap.GetAllPropertyMaps())
			{
				if (!propertyMap.IsReadOnly && !propertyMap.IsSlave)
				{
					if (propertyMap.ReferenceType != ReferenceType.None)
					{
						if (propertyMap.IsCollection)
						{
                            //It is the value in the database, not the current value, that is of importance
                            //for avoiding violations of the foreign key constraint 
							//IList list = (IList) om.GetPropertyValue(delObj, propertyMap.Name);
							IList list = (IList) om.GetOriginalPropertyValue(delObj, propertyMap.Name);
							if (list != null)
							{
								foreach (object itemRefObj in list)
								{
                                    object isDeleted = hashDeleted[itemRefObj];
									if (isDeleted != null)
									{
										m_topologicalDelete.AddNode(itemRefObj, delObj);
									}
								}
							}
						}
						else
						{
                            //It is the value in the database, not the current value, that is of importance
                            //for avoiding violations of the foreign key constraint 
							//object refObj = om.GetPropertyValue(delObj, propertyMap.Name);
							object refObj = om.GetOriginalPropertyValue(delObj, propertyMap.Name);
							if (refObj != null)
							{
                                object isDeleted = hashDeleted[refObj];
								if (isDeleted != null)
								{
									m_topologicalDelete.AddNode(refObj, delObj);
								}
							}
						}
					}
				}
			}
        }

        private bool MayForceDelete(object delObj)
        {
            TopologicalNode node = (TopologicalNode) m_topologicalDelete.Graph[delObj];
            if (node == null)
                return true;

            IObjectManager om = this.Context.ObjectManager;
            foreach (TopologicalNode waitForNode in node.WaitFor)
            {
                if (!ExamineWaitForNode(om, delObj, waitForNode.Obj))
                    return false;
            }

            return true;
        }
 
        private bool ExamineWaitForNode(IObjectManager om, object delObj, object waitForObj)
        {
			IClassMap waitForObjClassMap = this.Context.DomainMap.MustGetClassMap(waitForObj.GetType());
			foreach (IPropertyMap propertyMap in waitForObjClassMap.GetAllPropertyMaps())
			{
				if (!propertyMap.IsReadOnly && !propertyMap.IsSlave)
				{
					if (propertyMap.ReferenceType != ReferenceType.None)
					{
						if (propertyMap.IsCollection)
						{
							IList list = (IList) om.GetPropertyValue(waitForObj, propertyMap.Name);
							if (list != null)
							{
								foreach (object itemRefObj in list)
								{
									if (itemRefObj == delObj)
									{
										return false;
									}
								}
							}
						}
						else
						{
							object refObj = om.GetPropertyValue(waitForObj, propertyMap.Name);
							if (refObj != null)
							{
								if (refObj == delObj)
								{
									return false;
								}
							}
						}
					}
				}
			}
            return true;
        }

        public virtual void Clear()
        {
            this.m_hashSpeciallyUpdated.Clear();
            this.m_hashStillDirty.Clear();
            this.m_listCreated.Clear();
            this.m_listDeleted.Clear();
            this.m_listDirty.Clear();
            this.m_listInserted.Clear();
            this.m_listRemoved.Clear();
            this.m_listUpdated.Clear();
            this.m_objectStatusLookup.Clear();
            this.m_topologicalDelete.Clear();
        }

    }
}