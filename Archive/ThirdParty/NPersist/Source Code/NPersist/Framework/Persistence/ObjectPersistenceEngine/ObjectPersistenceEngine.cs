using System;
using System.Collections;
using System.Data;
using System.Threading;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Querying;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ObjectPersistenceEngine.
	/// </summary>
	public class ObjectPersistenceEngine : ContextChild, IPersistenceEngine
	{

		private IContext sourceContext;

		private ArrayList listInsert = new ArrayList();
		private ArrayList listUpdate = new ArrayList();
		private ArrayList listRemove = new ArrayList();
		private Hashtable hashInserted = new Hashtable();

		public ObjectPersistenceEngine(IContext sourceContext) : base() => this.sourceContext = sourceContext;

	    public IContext SourceContext
		{
			get => this.sourceContext;
	        set => this.sourceContext = value;
	    }

		public void Begin()
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				if (this.sourceContext.IsDirty)
					throw new EditException("Can't begin commit operation against dirty root context!");

			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		public void Commit()
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				this.sourceContext.BeginEdit() ;

                //We make this 2-pass:
                //If we create A and B in a leaf ctx and commit,
                //where A has a ref to B, if we insert A into root ctx
                //first and save it (copy values from leaf A to root A)
                //a ghost B will be created in the root and a ref is made
                //to it from the root A. When we then want to insert the 
                //leaf B into the root ctx, it already exists and we get
                //an id map exception...
				foreach (object obj in listInsert)
				{
					DoInsertObject(obj);
				}
                foreach (object obj in listInsert)
                {
                    DoSaveInsertedObject(obj);
                }

				foreach (object obj in listUpdate)
				{
					DoUpdateObject(obj);
				}

				foreach (object obj in listRemove)
				{
					DoRemoveObject(obj);
				}

				this.sourceContext.Commit() ;				

				listInsert.Clear() ;
				listUpdate.Clear() ;
				listRemove.Clear() ;

				UpdateIdentities();

				hashInserted.Clear() ;

			}
			catch (Exception ex)
			{
				try
				{
					Abort() ;					
				}
				catch (Exception ex2)
				{
					throw new EditException("Failed abort!", ex2);
				}	
				throw ex;				
			}	
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		public void Abort()
		{
			listInsert.Clear() ;
			listUpdate.Clear() ;
			listRemove.Clear() ;
			hashInserted.Clear() ;
		}

		public virtual void UpdateIdentities()
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IObjectManager om = this.Context.ObjectManager;
				IObjectManager sourceOm = this.sourceContext.ObjectManager;
				foreach (object obj in hashInserted.Keys)
				{
					IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );
					if (classMap.HasIdAssignedBySource())
					{
						object sourceObject = hashInserted[obj];
						string prevId = om.GetObjectIdentity(obj);
						foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps() )
						{
							if (propertyMap.GetIsAssignedBySource())
							{
								IPropertyMap sourcePropertyMap = propertyMap.GetSourcePropertyMapOrSelf() ;	
								om.SetPropertyValue(obj, propertyMap.Name,  sourceOm.GetPropertyValue(sourceObject, sourcePropertyMap.Name) ) ;	
								om.SetOriginalPropertyValue(obj, propertyMap.Name,  sourceOm.GetPropertyValue(sourceObject, sourcePropertyMap.Name) ) ;	
								om.SetNullValueStatus(obj, propertyMap.Name, false) ;	
							}
						}
						this.Context.IdentityMap.UpdateIdentity(obj, prevId, om.GetObjectIdentity(obj));
					} 
				}	
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		public virtual void LoadObject(ref object obj)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				string identity = this.Context.ObjectManager.GetObjectIdentity(obj);
				Type sourceType = ToSourceType(GetSourceType(obj));
			
				//object sourceObject = sourceContext.GetObjectById(identity, sourceType);
                object sourceObject = sourceContext.TryGetObjectById(identity, sourceType);

				if (sourceObject == null)
				{
					obj = null;
				}
				else
				{
					this.Context.IdentityMap.RegisterLoadedObject(obj);
                    LoadObject(obj, sourceObject, RefreshBehaviorType.DefaultBehavior);
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		public virtual void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{

			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}
		}

		public virtual void InsertObject(object obj, IList stillDirty) => listInsert.Add(obj);

	    public virtual void DoInsertObject(object obj)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );
				Type sourceType = ToSourceType(GetSourceType(obj));
				object sourceObject = null;
				if (classMap.HasIdAssignedBySource())
				{
					sourceObject = sourceContext.CreateObject(sourceType);
				} 
				else
				{
					string identity = this.Context.ObjectManager.GetObjectIdentity(obj);			
					sourceObject = sourceContext.CreateObject(identity, sourceType);
				}
				hashInserted[obj] = sourceObject;

				//SaveObject(obj, sourceObject, true);
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

        public virtual void DoSaveInsertedObject(object obj)
        {
            if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
                throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms");

            try
            {
                object sourceObject = hashInserted[obj];

                if (sourceContext == null)
                    throw new NPersistException("Internal Error! Could not find associated source context object for leaf context object in hash table!");

                SaveObject(obj, sourceObject, true);
            }
            finally
            {
                Monitor.Exit(sourceContext);
            }
        }


		public virtual void RemoveObject(object obj) => listRemove.Add(obj);

	    public virtual void DoRemoveObject(object obj)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				string identity = this.Context.ObjectManager.GetObjectIdentity(obj);
				Type sourceType = ToSourceType(GetSourceType(obj));
			
				object sourceObject = sourceContext.GetObjectById(identity, sourceType, true);

				SaveObject(obj, sourceObject);

				this.sourceContext.DeleteObject(sourceObject);
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}


		public virtual void UpdateObject(object obj, IList stillDirty) => listUpdate.Add(obj);

	    public virtual void DoUpdateObject(object obj)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				string identity = this.Context.ObjectManager.GetObjectIdentity(obj);
				Type sourceType = ToSourceType(GetSourceType(obj));
			
				object sourceObject = sourceContext.GetObjectById(identity, sourceType, true);

				SaveObject(obj, sourceObject);

				this.sourceContext.UnitOfWork.RegisterDirty(sourceObject);
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		public virtual void LoadProperty(object obj, string propertyName)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				string identity = this.Context.ObjectManager.GetObjectIdentity(obj);
				Type sourceType = ToSourceType(GetSourceType(obj));
			
				//object sourceObject = sourceContext.GetObjectById(identity, sourceType, true);
				object sourceObject = sourceContext.GetObjectById(identity, sourceType);

				if (sourceObject == null)
				{
					obj = null;
				}
				else
				{
					this.Context.IdentityMap.RegisterLoadedObject(obj);
					LoadProperty(obj, sourceObject, propertyName);
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		protected virtual void LoadProperty(object obj, object source, string propertyName)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IDomainMap domainMap = this.Context.DomainMap;
				IObjectManager om = this.Context.ObjectManager;
				IObjectManager sourceOm = this.sourceContext.ObjectManager;
				IClassMap classMap = domainMap.MustGetClassMap(obj.GetType());
				IPropertyMap sourcePropertyMap;
				IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
			
				sourcePropertyMap = propertyMap.GetSourcePropertyMapOrSelf() ;	

				LoadProperty(obj, propertyMap, sourceOm, source, sourcePropertyMap, om, RefreshBehaviorType.DefaultBehavior);
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}
		}


		public virtual IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj) => throw new IAmOpenSourcePleaseImplementMeException("");

	    //Refresh Issues!!
		public virtual IList LoadObjects(IQuery query, IList listToFill)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IList sourceResult = this.sourceContext.GetObjectsByQuery(query);
				//IList result = new ArrayList(); 
				IList result = listToFill; 
				foreach (object source in sourceResult)
				{
					string identity = this.sourceContext.ObjectManager.GetObjectIdentity(source);
					Type type = ToLeafType(GetTypeFromSource(source));
			
					//object sourceObject = sourceContext.GetObjectById(identity, sourceType, true);
					object obj = this.Context.GetObjectById(identity, type, true);
					//this.Context.IdentityMap.RegisterLoadedObject(obj);
					LoadObject(obj, source, query.RefreshBehavior);
					result.Add(obj);
				}
				return result;
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

        public virtual IList LoadObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            string npath = "Select * From " + type.Name;
            return LoadObjects(new NPathQuery(npath, type, null, refreshBehavior), listToFill);
        }

		
		public virtual DataTable LoadDataTable(IQuery query)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				return null;
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				return null;
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		protected virtual Type GetSourceType(object obj)
		{
			IDomainMap domainMap = this.Context.DomainMap;
			IClassMap classMap = domainMap.MustGetClassMap(obj.GetType());
			IClassMap sourceClassMap = classMap.GetSourceClassMapOrSelf();
			if (sourceClassMap == classMap)
			{
				return obj.GetType() ;	
			}
			else
			{
				return this.Context.AssemblyManager.MustGetTypeFromClassMap(sourceClassMap);
			}			
		}

		protected virtual Type GetTypeFromSource(object source) => source.GetType();

	    protected virtual void LoadObject(object obj, object source, RefreshBehaviorType refreshBehavior)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IDomainMap domainMap = this.Context.DomainMap;
				IObjectManager om = this.Context.ObjectManager;
				IObjectManager sourceOm = this.sourceContext.ObjectManager;
				IClassMap classMap = domainMap.MustGetClassMap(obj.GetType());
				IPropertyMap sourcePropertyMap;
				PropertyStatus sourcePropStatus;
                PropertyStatus propStatus;
                foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
				{
					sourcePropertyMap = propertyMap.GetSourcePropertyMapOrSelf() ;	
					sourcePropStatus = sourceOm.GetPropertyStatus(source, sourcePropertyMap.Name ) ;
					propStatus = om.GetPropertyStatus(obj, propertyMap.Name) ;
                    IUpdatedPropertyTracker tracker = obj as IUpdatedPropertyTracker;
                    if (tracker != null)
                    {
                        if (tracker.GetUpdatedStatus(propertyMap.Name))
                            propStatus = PropertyStatus.Dirty;
                    }

                    RefreshBehaviorType useRefreshBehavior = this.Context.PersistenceManager.GetRefreshBehavior(refreshBehavior, classMap, propertyMap);
                    
					if (sourcePropStatus != PropertyStatus.NotLoaded)
					{
                        bool doLoad = false;

                        if (useRefreshBehavior == RefreshBehaviorType.DefaultBehavior || useRefreshBehavior == RefreshBehaviorType.OverwriteNotLoaded)
                        {
                            if (propStatus == PropertyStatus.NotLoaded)
                                doLoad = true;
                        }

                        if (doLoad)
    						LoadProperty(obj, propertyMap, sourceOm, source, sourcePropertyMap, om, refreshBehavior);
					}
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

        private void LoadProperty(object obj, IPropertyMap propertyMap, IObjectManager om, object source, IPropertyMap sourcePropertyMap, IObjectManager sourceOm, RefreshBehaviorType refreshBehavior)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				sourceOm.EnsurePropertyIsLoaded(source, sourcePropertyMap.Name);

				bool nullValueStatus;
				object value;
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					if (!(propertyMap.IsCollection))
					{
						value = sourceOm.GetPropertyValue(source, sourcePropertyMap.Name);
						nullValueStatus = sourceOm.GetNullValueStatus(source, sourcePropertyMap.Name);

						om.SetPropertyValue(obj, propertyMap.Name, value);
						if (nullValueStatus)
						{
							om.SetOriginalPropertyValue(obj, propertyMap.Name, DBNull.Value);								
						}
						else
						{
							om.SetOriginalPropertyValue(obj, propertyMap.Name, value);
						}
						om.SetNullValueStatus(obj, propertyMap.Name, nullValueStatus);								
					}				
					else
					{
						//Using CloneList will work when it is only primitive values 
						//(or immutable objects such as strings and dates) 
						//that can be copied between contexts
						IList list = (IList) sourceOm.GetPropertyValue(source, sourcePropertyMap.Name);
						IList listClone = this.Context.ListManager.CloneList(obj, propertyMap, list);
						//IList listCloneOrg = this.Context.ListManager.CloneList(obj, propertyMap, list);
						IList listCloneOrg = new ArrayList( list);
						om.SetPropertyValue(obj, propertyMap.Name, listClone);
						om.SetOriginalPropertyValue(obj, propertyMap.Name, listCloneOrg);
					}
				}									
				else
				{
					if (!(propertyMap.IsCollection))
					{
						object refObject = sourceOm.GetPropertyValue(source, sourcePropertyMap.Name);

						if (refObject == null)
						{
							om.SetPropertyValue(obj, propertyMap.Name, null);
							om.SetOriginalPropertyValue(obj, propertyMap.Name, null);

							om.SetNullValueStatus(obj, propertyMap.Name, true);								
						}
						else
						{
							string identity = sourceOm.GetObjectIdentity(refObject);

							Type refType = ToLeafType(refObject);

							//Impossible to solve for inheritance scenarios when mapping presentation model to domain model!!!!
							//We could try checking which presentation domain map which class map that maps to the 
							//domain class map, but that could be a many-one relationship (many presentation model classes
							//map to the same domain model class!)
							//								IClassMap sourceOrgClassMap = this.sourceContext.DomainMap.GetClassMap(orgObject.GetType() );
							//								IClassMap leafOrgClassMap = this.sourceContext.DomainMap.GetClassMap(sourceOrgClassMap.Name );
							//								IClassMap theClassMap = this.sourceContext.DomainMap.GetClassMap (sourceOrgClassMap.Name );																

							value = this.Context.GetObjectById(identity, refType, true);
							nullValueStatus = sourceOm.GetNullValueStatus(source, sourcePropertyMap.Name);								

							om.SetPropertyValue(obj, propertyMap.Name, value);
							om.SetOriginalPropertyValue(obj, propertyMap.Name, value);

							om.SetNullValueStatus(obj, propertyMap.Name, nullValueStatus);								
						}
					}				
					else
					{
						//Using CloneList will not work when there are reference values (to mutable objects) 
						//that can be copied between contexts
						IList orgList = (IList) sourceOm.GetPropertyValue(source, sourcePropertyMap.Name);
						IList list = (IList) om.GetPropertyValue(obj, sourcePropertyMap.Name);

                        this.LoadReferenceList(list, orgList, refreshBehavior);

						//for the org-list we can use ListManager.CloneList and clone the list of leaf objects
						//IList listOrg = this.Context.ListManager.CloneList(obj, propertyMap, list);
						IList listOrg = new ArrayList( list);
						om.SetPropertyValue(obj, propertyMap.Name, list);
						om.SetOriginalPropertyValue(obj, propertyMap.Name, listOrg);
							
					}							
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

        public virtual void LoadReferenceList(IList list, IList orgList, RefreshBehaviorType refreshBehavior)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IInterceptableList mList;
				bool stackMute = false;

				mList = list as IInterceptableList;
				if (mList != null)
				{
					stackMute = mList.MuteNotify;
					mList.MuteNotify = true;
				}
				list.Clear() ;
				foreach (object item in orgList)
				{
					string identity = this.sourceContext.ObjectManager.GetObjectIdentity(item);
					Type leafType = ToLeafType(item);
			
					//object sourceObject = sourceContext.GetObjectById(identity, sourceType, true);
					object clone = this.Context.GetObjectById(identity, leafType, true);

                    LoadObject(clone, item, refreshBehavior);
					this.Context.IdentityMap.RegisterLoadedObject(clone);

					list.Add(clone);
				}
				if (mList != null)
				{
					mList.MuteNotify = stackMute;
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		//if we do use optimistic concurrency we don't really have to clone the originals, but we can't assume that optimistic concurrency is used...
		private void SaveReferenceList(IList list, IList sourceList)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IObjectManager om = this.Context.ObjectManager;
				IObjectManager sourceOm = this.sourceContext.ObjectManager;
				IList objectsToRemove = new ArrayList(); 
				IList objectsToAdd = new ArrayList();
				foreach (object itemOrgObj in sourceList)
				{
					string itemOrgObjId = sourceOm.GetObjectIdentity(itemOrgObj);
					bool found = false;
					foreach (object itemObj in list)
					{
						string itemObjId = om.GetObjectIdentity(itemObj);
						if (itemObjId == itemOrgObjId)
						{
							found = true;
							break;
						}								
					}
					if (!found)
						objectsToRemove.Add(itemOrgObj);
				}
				foreach (object itemObj in list)
				{
					string itemObjId = om.GetObjectIdentity(itemObj);
					bool found = false;
					foreach (object itemOrgObj in sourceList)
					{
						string itemOrgObjId = sourceOm.GetObjectIdentity(itemOrgObj);
						if (itemObjId == itemOrgObjId)
						{
							found = true;
							break;
						}								
					}
					if (!found)
					{
						Type sourceType = ToSourceType(itemObj);
                        object itemOrgObj = null;
                        //if (creating)
    					//	itemOrgObj = this.sourceContext.CreateObject(sourceType);
                        //else
    						itemOrgObj = this.sourceContext.GetObjectById(itemObjId, sourceType, true);

                        if (itemOrgObj != null)
    						objectsToAdd.Add(itemOrgObj);
					}
				}
	
				if (objectsToRemove.Count > 0 || objectsToAdd.Count > 0)
				{
					bool stackMute = false;
					IInterceptableList mList = sourceList as IInterceptableList;					
					if (mList != null)
					{
						stackMute = mList.MuteNotify;
						mList.MuteNotify = true;
					}
					foreach (object itemOrgObj in objectsToRemove)
						sourceList.Remove(itemOrgObj);
					foreach (object itemOrgObj in objectsToAdd)
						sourceList.Add(itemOrgObj);	

					if (mList != null) { mList.MuteNotify = stackMute; }
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}


		//if we do use optimistic concurrency we don't really have to clone the originals, but we can't assume that optimistic concurrency is used...
		private void SaveList(IList list, IList sourceList)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IList itemsToRemove = new ArrayList(); 
				IList itemsToAdd = new ArrayList();
				foreach (object itemOrg in sourceList)
				{
					bool found = false;
					foreach (object item in list)
					{
						if (item.Equals(itemOrg))
						{
							found = true;
							break;
						}								
					}
					if (!found)
						itemsToRemove.Add(itemOrg);
				}
				foreach (object item in list)
				{
					bool found = false;
					foreach (object itemOrg in sourceList)
					{
						if (item.Equals(itemOrg))
						{
							found = true;
							break;
						}								
					}
					if (!found)
					{
						itemsToAdd.Add(item);
					}
				}
	
				if (itemsToRemove.Count > 0 || itemsToAdd.Count > 0)
				{
					bool stackMute = false;
					IInterceptableList mList = sourceList as IInterceptableList;					
					if (mList != null)
					{
						stackMute = mList.MuteNotify;
						mList.MuteNotify = true;
					}
					foreach (object itemOrg in itemsToRemove)
						sourceList.Remove(itemOrg);
					foreach (object itemOrg in itemsToAdd)
						sourceList.Add(itemOrg);	

					if (mList != null) { mList.MuteNotify = stackMute; }
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}


		private Type ToLeafType(object refObject) => ToLeafType(refObject.GetType());

	    private Type ToLeafType(Type type)
		{
			IClassMap sourceRefClassMap = this.sourceContext.DomainMap.MustGetClassMap(type );
			IClassMap leafRefClassMap = this.Context.DomainMap.MustGetClassMap(sourceRefClassMap.Name );
			return this.Context.AssemblyManager.MustGetTypeFromClassMap(leafRefClassMap);
		}

		//Optimistic Concurrency Issues!!
		protected virtual void SaveObject(object obj, object source) => SaveObject(obj, source, false);

	    protected virtual void SaveObject(object obj, object source, bool creating)
		{
			if (!Monitor.TryEnter(sourceContext, this.Context.Timeout))
				throw new NPersistTimeoutException("Could not aquire exclusive lock on root context before timeout: " + this.Context.Timeout.ToString() + " ms" );

			try
			{
				IListManager lm = this.Context.ListManager ;
				IDomainMap domainMap = this.Context.DomainMap;
				IObjectManager om = this.Context.ObjectManager;
				IObjectManager sourceOm = this.sourceContext.ObjectManager;
				IClassMap classMap = domainMap.MustGetClassMap(obj.GetType());
				IPropertyMap sourcePropertyMap;
				object value;
				bool nullValueStatus;
				PropertyStatus propStatus;
				foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
				{
					sourcePropertyMap = propertyMap.GetSourcePropertyMapOrSelf() ;	
					propStatus = om.GetPropertyStatus(obj, propertyMap.Name ) ;

					if (!(creating && propertyMap.GetIsAssignedBySource() ))
					{
						if (creating || propStatus != PropertyStatus.NotLoaded)
						{
							if (propertyMap.ReferenceType == ReferenceType.None)
							{
								if (!(propertyMap.IsCollection))
								{

									object orgValue = om.GetOriginalPropertyValue(obj, propertyMap.Name);

									if (!creating)
									{
										//Optimistic concurrency
										object currValue = sourceOm.GetPropertyValue(source, sourcePropertyMap.Name);
										bool currNullValueStatus = sourceOm.GetNullValueStatus(source, sourcePropertyMap.Name);
										if (DBNull.Value.Equals(orgValue))
											orgValue = null;
										if (DBNull.Value.Equals(currValue))
											currValue = null;
										if (currNullValueStatus)
											currValue = null;

										if (!CompareValues(orgValue, currValue))
										{
											string orgValueString = "<null>";											
											string currValueString = "<null>";											
											if (orgValue != null)
												orgValueString = orgValue.ToString() ;
											if (currValue != null)
												currValueString = currValue.ToString() ;

											throw new OptimisticConcurrencyException("An optimistic concurrency exception occurred when persisting to the data source! Object: " + obj.GetType().ToString() + om.GetObjectKeyOrIdentity(obj) + ", Property: " + sourcePropertyMap.Name + ", Cached original value: " + orgValueString + ", Data source value: " + currValueString, orgValue, currValue, obj, propertyMap.Name);
										}

									}

									value = om.GetPropertyValue(obj, propertyMap.Name);
									nullValueStatus = om.GetNullValueStatus(obj, propertyMap.Name);									

									sourceOm.SetPropertyValue(source, sourcePropertyMap.Name, value);
									sourceOm.SetNullValueStatus(source, sourcePropertyMap.Name, nullValueStatus);

									if (orgValue == null || DBNull.Value.Equals(orgValue))
										sourceOm.SetOriginalPropertyValue(source, sourcePropertyMap.Name, DBNull.Value);
									else
										sourceOm.SetOriginalPropertyValue(source, sourcePropertyMap.Name, orgValue);

									if (creating == false && CompareValues(value, orgValue) == false)
										sourceOm.SetUpdatedStatus(source, sourcePropertyMap.Name, true);

								}				
								else
								{
									IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name);
									IList listOrg = (IList) om.GetOriginalPropertyValue(obj, propertyMap.Name);

									//OBS! listOrg may be null if the object is under creation!
									if (listOrg == null)
									{				
										//listOrg = lm.CreateList(obj, propertyMap) ;
										listOrg = new ArrayList() ;
										om.SetOriginalPropertyValue(obj, propertyMap.Name, listOrg);
									}

									IList sourceList = (IList) om.GetPropertyValue(obj, propertyMap.Name);

									if (!creating)
									{
										//Optimistic concurrency
										if (!CompareListsById(listOrg, sourceList))
										{
											string orgValueString = "<list>";		
											string currValueString = "<list>";

											throw new OptimisticConcurrencyException("An optimistic concurrency exception occurred when persisting to the data source! Object: " + obj.GetType().ToString() + om.GetObjectKeyOrIdentity(obj) + ", Property: " + sourcePropertyMap.Name + ", Cached original value: " + orgValueString + ", Data source value: " + currValueString, listOrg, sourceList, obj, propertyMap.Name);
										}
									}	
							
									SaveList(list, sourceList);

									IList sourceListOrg = (IList) om.GetOriginalPropertyValue(obj, propertyMap.Name);

									//OBS! sourceListOrg may be null if the object is under creation!
									if (sourceListOrg == null)
									{				
										//sourceListOrg = lm.CreateList(source, sourcePropertyMap) ;
										sourceListOrg = new ArrayList() ;
										om.SetOriginalPropertyValue(source, sourcePropertyMap.Name, sourceListOrg);
									}

									SaveList(listOrg, sourceListOrg);

									if (creating == false && CompareListsById(list, listOrg) == false)
										sourceOm.SetUpdatedStatus(source, sourcePropertyMap.Name, true);							
								}
							}									
							else
							{
								if (!(propertyMap.IsCollection))
								{
									object refObject = om.GetPropertyValue(obj, propertyMap.Name);

									if (refObject == null)
									{
										sourceOm.SetPropertyValue(source, sourcePropertyMap.Name, null);
										//sourceOm.SetOriginalPropertyValue(source, sourcePropertyMap.Name, null);

										sourceOm.SetNullValueStatus(source, sourcePropertyMap.Name, true);								
									}
									else
									{
										string identity = om.GetObjectIdentity(refObject);

										Type refType = ToSourceType(refObject);

										//Impossible to solve for inheritance scenarios when mapping presentation model to domain model!!!!
										//We could try checking which presentation domain map which class map that maps to the 
										//domain class map, but that could be a many-one relationship (many presentation model classes
										//map to the same domain model class!)
										//								IClassMap sourceOrgClassMap = this.sourceContext.DomainMap.GetClassMap(orgObject.GetType() );
										//								IClassMap leafOrgClassMap = this.sourceContext.DomainMap.GetClassMap(sourceOrgClassMap.Name );
										//								IClassMap theClassMap = this.sourceContext.DomainMap.GetClassMap (sourceOrgClassMap.Name );																

										object orgValue = om.GetOriginalPropertyValue(obj, propertyMap.Name);

										if (!creating)
										{
											//Optimistic concurrency
											object currValue = sourceOm.GetPropertyValue(source, sourcePropertyMap.Name);
											if (orgValue == null || currValue == null)
											{
												if (!(orgValue == null && currValue == null))
												{
													string orgValueString = "<null>";											
													string currValueString = "<null>";											
													if (orgValue != null)
														orgValueString = orgValue.ToString() ;
													if (currValue != null)
														currValueString = currValue.ToString() ;

													throw new OptimisticConcurrencyException("An optimistic concurrency exception occurred when persisting to the data source! Object: " + obj.GetType().ToString() + om.GetObjectKeyOrIdentity(obj) + ", Property: " + sourcePropertyMap.Name + ", Cached original value: " + orgValueString + ", Data source value: " + currValueString, orgValue, currValue, obj, propertyMap.Name);
												}
											}
											else
											{
												string orgIdentity = om.GetObjectIdentity(orgValue);
												string currIdentity = sourceOm.GetObjectIdentity(currValue);

												//											IClassMap leafOrgClassMap = this.Context.DomainMap.GetClassMap(refObject.GetType() );
												//											IClassMap sourceOrgClassMap = this.sourceContext.DomainMap.GetClassMap(leafOrgClassMap.Name );
												//											Type orgType = this.sourceContext.AssemblyManager.GetTypeFromClassMap(sourceOrgClassMap);

//												Type orgType = ToSourceType(orgValue) ;
//
//												object sourceOrgvalue = this.sourceContext.GetObjectById(orgIdentity, orgType, true);

												if (!(orgIdentity.Equals(currIdentity)))
												{
													string orgValueString = "<null>";											
													string currValueString = "<null>";											
													if (orgValue != null)
														orgValueString = om.GetObjectKeyOrIdentity(orgValue) ;
													if (currValue != null)
														currValueString = om.GetObjectKeyOrIdentity(currValue) ;

													throw new OptimisticConcurrencyException("An optimistic concurrency exception occurred when persisting to the data source! Object: " + obj.GetType().ToString() + om.GetObjectKeyOrIdentity(obj) + ", Property: " + sourcePropertyMap.Name + ", Cached original value: " + orgValueString + ", Data source value: " + currValueString, orgValue, currValue, obj, propertyMap.Name);
												}

											}
										}

										value = this.sourceContext.GetObjectById(identity, refType, true);
										nullValueStatus = om.GetNullValueStatus(obj, propertyMap.Name);										

										sourceOm.SetPropertyValue(source, sourcePropertyMap.Name, value);
										sourceOm.SetNullValueStatus(source, sourcePropertyMap.Name, nullValueStatus);								

										if (orgValue == null || DBNull.Value.Equals(orgValue))
											sourceOm.SetOriginalPropertyValue(source, sourcePropertyMap.Name, null);
										else
											sourceOm.SetOriginalPropertyValue(source, sourcePropertyMap.Name, orgValue);

										if (creating == false && CompareValues(value, orgValue) == false)
											sourceOm.SetUpdatedStatus(source, sourcePropertyMap.Name, true);

									}
								}				
								else
								{
									IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name);
									IList listOrg = (IList) om.GetOriginalPropertyValue(obj, propertyMap.Name);

									//OBS! listOrg may be null if the object is under creation!
									if (listOrg == null)
									{				
										//listOrg = lm.CreateList(obj, propertyMap) ;
										listOrg = new ArrayList() ;
										om.SetOriginalPropertyValue(obj, propertyMap.Name, listOrg);
									}

									//IList sourceList = (IList) om.GetPropertyValue(obj, propertyMap.Name);
                                    IList sourceList = (IList)sourceOm.GetPropertyValue(source, sourcePropertyMap.Name);

									if (!creating)
									{
										//Optimistic concurrency
										if (!CompareListsById(listOrg, sourceList))
										{
											string orgValueString = "<list>";		
											string currValueString = "<list>";

											throw new OptimisticConcurrencyException("An optimistic concurrency exception occurred when persisting to the data source! Object: " + obj.GetType().ToString() + om.GetObjectKeyOrIdentity(obj) + ", Property: " + sourcePropertyMap.Name + ", Cached original value: " + orgValueString + ", Data source value: " + currValueString, listOrg, sourceList, obj, propertyMap.Name);
										}
									}	
							
									SaveReferenceList(list, sourceList);

									IList sourceListOrg = (IList) om.GetOriginalPropertyValue(obj, propertyMap.Name);

									//OBS! sourceListOrg may be null if the object is under creation!
									if (sourceListOrg == null)
									{				
										//sourceListOrg = lm.CreateList(source, sourcePropertyMap) ;
										sourceListOrg = new ArrayList() ;
										om.SetOriginalPropertyValue(source, sourcePropertyMap.Name, sourceListOrg);
									}

									SaveReferenceList(listOrg, sourceListOrg);

									if (creating == false && CompareListsById(list, listOrg) == false)
										sourceOm.SetUpdatedStatus(source, sourcePropertyMap.Name, true);

								}							
							}
						}					
					}
				}
			}
			finally
			{
				Monitor.Exit(sourceContext);			
			}	
		}

		private Type ToSourceType(object refObject) => ToSourceType(refObject.GetType() );

	    private Type ToSourceType(Type type)
		{
			IClassMap leafRefClassMap = this.Context.DomainMap.MustGetClassMap(type );
			IClassMap sourceRefClassMap = this.sourceContext.DomainMap.MustGetClassMap(leafRefClassMap.Name );
			return this.sourceContext.AssemblyManager.MustGetTypeFromClassMap(sourceRefClassMap);
		}

		private bool CompareValues(object orgValue, object currValue)
		{
			if (orgValue == null || currValue == null)
			{
				if (!(orgValue == null && currValue == null))
					return false;
			}
			else
			{
				if (orgValue is System.DateTime)
				{
					if (!(((DateTime)orgValue).ToString("yyyy-MM-dd HH:mm:ss").Equals(((DateTime)currValue).ToString("yyyy-MM-dd HH:mm:ss"))))
						return false;											
				}
				else
				{
					if (!(orgValue.Equals(currValue)))
						return false;											
				}				
			}
			return true;
		}

        //private bool CompareLists(IList orgValue, IList currValue)
        //{
        //    return this.Context.ListManager.CompareLists(orgValue, currValue);
        //}

        private bool CompareListsById(IList orgValue, IList currValue) => this.Context.ListManager.CompareListsById(orgValue, currValue);

	    public virtual void TouchTable(ITableMap tableMap, int exceptionLimit) { ; }

    }
}
