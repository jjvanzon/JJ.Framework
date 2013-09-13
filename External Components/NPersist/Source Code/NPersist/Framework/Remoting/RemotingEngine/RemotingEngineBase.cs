using System;
using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Remoting.Formatting;
using Puzzle.NPersist.Framework.Remoting.Marshaling;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Remoting
{
	/// <summary>
	/// Summary description for RemotingEngineBase.
	/// </summary>
	public abstract class RemotingEngineBase : ContextChild, IRemotingEngine
	{

		public RemotingEngineBase()
		{			
		}

		public RemotingEngineBase(IFormatter formater)
		{
			this.formatter = formater;			
		}

		
		private IFormatter formatter = null;
		private ArrayList listInsert = new ArrayList();
		private ArrayList listUpdate = new ArrayList();
		private ArrayList listRemove = new ArrayList();

		public IFormatter Formatter
		{
			get { return this.formatter; }
			set { this.formatter = value; }
		}

		public abstract void Begin();

		public abstract void Commit();

		public abstract void Abort();

		public virtual MarshalUnitOfWork GetUnitOfWork()
		{
			MarshalUnitOfWork muow = new MarshalUnitOfWork();
			IMarshalingTransformer transformer = new MarshalingTransformer(Context);
			MarshalObject mo;
			foreach (object obj in listInsert)
			{
				mo = transformer.FromObject(obj, true);
				muow.InsertObjects.Add(mo);
			} 
			foreach (object obj in listUpdate)
			{
				mo = transformer.FromObject(obj);
				muow.UpdateObjects.Add(mo);
			} 
			foreach (object obj in listRemove)
			{
				mo = transformer.FromObject(obj);
				muow.RemoveObjects.Add(mo);
			} 
			return muow;
		}

		public void UpdateSourceAssigned(MarshalObjectList mol)
		{
			IObjectManager om = Context.ObjectManager;
			IMarshalingTransformer transformer = new MarshalingTransformer(Context);
			IClassMap classMap;
			MarshalProperty mp;
			object obj;
			object newValue;
			foreach (MarshalObject mo in mol.Objects)
			{
				if (mo.TempId.Length > 0)
				{
					obj = GetInsertedObjectWithTemporaryIdentity(mo.TempId);
					if (obj != null)
					{
						classMap = Context.DomainMap.MustGetClassMap(obj.GetType());
						foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
						{
							if (propertyMap.GetIsAssignedBySource())
							{
								mp = mo.GetProperty(propertyMap.Name);
								if (mp != null)
								{
									newValue = transformer.ToPropertyValue(obj, mp.Value, mp, propertyMap);
									om.SetPropertyValue(obj, propertyMap.Name, newValue);									
									om.SetOriginalPropertyValue(obj, propertyMap.Name, newValue);							
									om.SetNullValueStatus(obj, propertyMap.Name, false);									
								}									
							}
						}
						Context.IdentityMap.UpdateIdentity(obj, mo.TempId);
					}
				}
				else
				{
					classMap = Context.DomainMap.MustGetClassMap(mo.Type);
					if (classMap.HasAssignedBySource() )
					{
						obj = GetObjectByMarshalObject(transformer, mo, classMap);
						foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
						{
							if (propertyMap.GetIsAssignedBySource())
							{
								mp = mo.GetProperty(propertyMap.Name);
								if (mp != null)
								{
									newValue = transformer.ToPropertyValue(obj, mp.Value, mp, propertyMap);
									om.SetPropertyValue(obj, propertyMap.Name, newValue);									
									om.SetOriginalPropertyValue(obj, propertyMap.Name, newValue);							
									om.SetNullValueStatus(obj, propertyMap.Name, false);									
								}									
							}
						}							
					}
				}
			}
		}

		private object GetInsertedObjectWithTemporaryIdentity(string tempId)
		{
			IObjectManager om = Context.ObjectManager;
			foreach (object obj in listInsert)
			{
				if (om.GetObjectIdentity(obj) == tempId)
				{					
					return obj;
				}
			}			
			return null;
		}

		private object GetObjectByMarshalObject(IMarshalingTransformer transformer, MarshalObject mo, IClassMap classMap)
		{
			Type type = this.Context.AssemblyManager.MustGetTypeFromClassMap(classMap);
			return this.Context.GetObjectById(transformer.GetIdentity(mo), type, true);
		}


		public void ClearUnitOfWork()
		{
			listInsert.Clear();			
			listUpdate.Clear();			
			listRemove.Clear();			
		}

		public abstract void LoadObject(ref object obj);

		public abstract void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue);

		public virtual void InsertObject(object obj, IList stillDirty)
		{
			listInsert.Add(obj);
		}

		public virtual void UpdateObject(object obj, IList stillDirty)
		{
			listUpdate.Add(obj);			
		}

		public virtual void RemoveObject(object obj)
		{
			listRemove.Add(obj);						
		}

		public abstract void LoadProperty(object obj, string propertyName);

		public abstract IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj);

		public abstract IList LoadObjects(IQuery query, IList listToFill);

        public virtual IList LoadObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            string npath = "Select * From " + type.Name;
            return LoadObjects(new NPathQuery(npath, type, null, refreshBehavior), listToFill);
        }

		public abstract DataTable LoadDataTable(IQuery query);

		public abstract IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill);

        public virtual void TouchTable(ITableMap tableMap, int exceptionLimit) { ; }

	}
}
