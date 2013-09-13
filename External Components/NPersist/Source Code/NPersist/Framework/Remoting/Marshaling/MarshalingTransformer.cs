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
using System.Globalization;
using System.Reflection;
using System.Text;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;

namespace Puzzle.NPersist.Framework.Remoting.Marshaling
{
	/// <summary>
	/// Summary description for MarshalingTransformer.
	/// </summary>
	public class MarshalingTransformer : ContextChild, IMarshalingTransformer
	{

		public MarshalingTransformer()
		{
		}
		
		public MarshalingTransformer(IContext ctx) : base(ctx)
		{
		}

		public virtual void ToObject(MarshalObject marshalObject, ref object targetObject)
		{
			ToObject(marshalObject, ref targetObject, 0, RefreshBehaviorType.DefaultBehavior);
		}

		//pass 0 = get all properties (for ToObject overload) , pass 1 = get only primitive props, pass 2 = get only ref props
		public virtual void ToObject(MarshalObject marshalObject, ref object targetObject, int pass, RefreshBehaviorType refreshBehavior)
		{
			IClassMap classMap = Context.DomainMap.MustGetClassMap(targetObject.GetType());
			IPropertyMap propertyMap;
			//PropertyStatus propStatus;
			if (pass == 0 || pass == 1)
			{
				foreach (MarshalProperty mp in marshalObject.Properties)
				{
					//propStatus = ctx.GetPropertyStatus(targetObject, mp.Name);
					propertyMap = classMap.MustGetPropertyMap(mp.Name);
					ToProperty(targetObject, mp, propertyMap, refreshBehavior);
				}									
			}

			if (pass == 0 || pass == 2)
			{
				foreach (MarshalReference mr in marshalObject.References)
				{
					//propStatus = ctx.GetPropertyStatus(targetObject, mp.Name);
					propertyMap = classMap.MustGetPropertyMap(mr.Name);
					ToReference(targetObject, mr, propertyMap, refreshBehavior);
				}									
			}

			if (targetObject != null)
				if (pass == 0 || pass == 1)
					this.Context.IdentityMap.RegisterLoadedObject(targetObject);
		}

		
		protected virtual object GetObjectListObject(MarshalObject marshalObject, int pass, RefreshBehaviorType refreshBehavior)
		{
			IClassMap classMap = Context.DomainMap.MustGetClassMap(marshalObject.Type);
			Type realType = Context.AssemblyManager.MustGetTypeFromClassMap(classMap);
			string id = GetIdentity(marshalObject);
			object targetObject = this.Context.GetObjectById(id, realType, true); 
			ToObject(marshalObject, ref targetObject, pass, refreshBehavior);
			return targetObject;
		}

		public virtual MarshalObject FromObject(object sourceObject)
		{
			return FromObject(sourceObject, false);
		}

		public virtual MarshalObject FromObject(object sourceObject, bool upForCreation)
		{
			IClassMap classMap = Context.DomainMap.MustGetClassMap(sourceObject.GetType());
			MarshalObject mo = new MarshalObject();
			mo.Type = classMap.GetName();
			if (upForCreation)
			{
				if (classMap.HasIdAssignedBySource())
				{
					mo.TempId = Context.ObjectManager.GetObjectIdentity(sourceObject);					
				}
			}				
			PropertyStatus propStatus;
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				propStatus = Context.GetPropertyStatus(sourceObject, propertyMap.Name);
				if (propStatus != PropertyStatus.NotLoaded || upForCreation)
				{
					if (propertyMap.ReferenceType == ReferenceType.None)
					{					
						if (propertyMap.IsCollection)
						{

						}
						else
						{							
							if (upForCreation && propertyMap.GetIsAssignedBySource())
							{
								
							}
							else
							{
								mo.Properties.Add(FromProperty(sourceObject, propertyMap));																	
							}
						}
					}
					else
					{
						if (propertyMap.IsCollection)
						{					
							//mo.ReferenceLists.Add(FromReferenceList(sourceObject, propertyMap));
						}
						else
						{
							mo.References.Add(FromReference(sourceObject, propertyMap));
						}												
					}					
				}					
			}

			return mo;
		}

		//TODO: The whole refresh thingy...
		public void ToProperty(object targetObject, MarshalProperty mp, IPropertyMap propertyMap, RefreshBehaviorType refreshBehavior)
		{
			IObjectManager om = this.Context.ObjectManager ;
			IPersistenceManager pm = this.Context.PersistenceManager ;

			object value = null;
			
			if (!mp.IsNull)
				value = ToPropertyValue(targetObject, mp.Value, mp, propertyMap);

			bool doWrite = false;
			bool doWriteOrg = false;

			RefreshProperty(om, targetObject, propertyMap, pm, refreshBehavior, value, out doWrite, out doWriteOrg);
			if (doWrite || doWriteOrg)
			{
				//To keep inverse management correct,
				//We really should pick out a ref to any
				//eventual already referenced object here (in the
				//case of MergeBehaviorType.OverwriteDirty)
				//and perform proper inverse management on that object...

				if (doWrite)
				{
					if (mp.IsNull != true)
					{
						om.SetPropertyValue(targetObject, propertyMap.Name, value);
					}					
					Context.ObjectManager.SetNullValueStatus(targetObject, propertyMap.Name, mp.IsNull);
				}
				if (doWriteOrg)
				{
					if (mp.HasOriginal)
					{
						object orgValue = DBNull.Value ;
						if (mp.WasNull != true)
							orgValue = ToPropertyValue(targetObject, mp.OriginalValue,mp, propertyMap);

						if (propertyMap.ReferenceType == ReferenceType.None)
							om.SetOriginalPropertyValue(targetObject, propertyMap.Name, orgValue);
						else
							om.SetOriginalPropertyValue(targetObject, propertyMap.Name, value);


						if (mp.IsNull != mp.WasNull || (value != null && orgValue != null && value.Equals(orgValue) == false))
						{
							this.Context.ObjectManager.SetUpdatedStatus(targetObject, propertyMap.Name, true);					
							//redundant, done once for object by outer caller
							//this.Context.UnitOfWork.RegisterDirty(targetObject, propertyMap.Name, true);						
						}					
					}				
				}
//
//				if (propertyMap.ReferenceType != ReferenceType.None )
//				{
//	
//					if (value != null)
//					{
//						this.Context.IdentityMap.RegisterLoadedObject(value);
//
//						//Inverse management
//						if (doWrite)
//							this.Context.InverseManager.NotifyPropertyLoad(refObj, propertyMap, value);
//					}
//				}
			}										
		}

		private void RefreshProperty(IObjectManager om, object targetObject, IPropertyMap propertyMap, IPersistenceManager pm, RefreshBehaviorType refreshBehavior, object value, out bool doWrite, out bool doWriteOrg)
		{
			doWrite = false;
			doWriteOrg = false;
			PropertyStatus propStatus = om.GetPropertyStatus(targetObject, propertyMap.Name);
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(targetObject.GetType());
	
			RefreshBehaviorType useRefreshBehavior = pm.GetRefreshBehavior(refreshBehavior, classMap, propertyMap);
	
			if (useRefreshBehavior == RefreshBehaviorType.OverwriteNotLoaded || useRefreshBehavior == RefreshBehaviorType.DefaultBehavior)
			{
				//Overwrite both value and original far all unloaded properties
				if (propStatus == PropertyStatus.NotLoaded)
				{
					doWrite = true;
					doWriteOrg = true;
				}
			}
			else if (useRefreshBehavior == RefreshBehaviorType.OverwriteLoaded)
			{
				//Overwrite original for all properties
				//Overwrite value for all clean or unloaded properties (but not for dirty or deleted properties)
				doWriteOrg = true;
				if (propStatus == PropertyStatus.Clean || propStatus == PropertyStatus.NotLoaded)
					doWrite = true;
			}
			else if (useRefreshBehavior == RefreshBehaviorType.ThrowConcurrencyException)
			{
				//Overwrite original for all properties unless the old originial value and the fresh value from the
				//database mismatch, in that case raise an exception
				//Overwrite value for all clean or unloaded properties (but not for dirty or deleted properties)
				if (propStatus == PropertyStatus.Clean || propStatus == PropertyStatus.NotLoaded || propStatus == PropertyStatus.Dirty)
				{
					if (!(propStatus == PropertyStatus.NotLoaded))
					{
						object testValue = om.GetOriginalPropertyValue(targetObject,propertyMap.Name);
						object testValue2 = value;
						if (DBNull.Value.Equals(testValue)) { testValue = null; }
						if (DBNull.Value.Equals(testValue2)) { testValue2 = null; }
						if (testValue2 != testValue)
						{
							string cachedValue = "null";
							string freshValue = "null";
							try
							{
								if (testValue != null)
									cachedValue = testValue.ToString() ;
							} 
							catch { ; }
							try
							{
								if (value != null)
									freshValue = value.ToString() ;
							} 
							catch { ; }
							throw new RefreshException("A refresh concurrency exception occurred when refreshing a cached object of type " + targetObject.GetType().ToString() + " with fresh data from the data source. The data source row has been modified since the last time this version of the object was loaded, specifically the value for property " + propertyMap.Name + ". (this exception occurs because ThrowConcurrencyExceptions refresh behavior was selected). Cashed value: " + cachedValue + ", Fresh value: " + freshValue, cachedValue, freshValue, targetObject, propertyMap.Name); // do not localize
						}
					}
					if (!(propStatus == PropertyStatus.Dirty))
						doWrite = true;
				}
			}
			else if (useRefreshBehavior == RefreshBehaviorType.OverwriteDirty)
			{
				//Overwrite original for all properties
				//Overwrite value for all clean, unloaded or dirty properties (but not for deleted properties)
				doWriteOrg = true;
				if (!(propStatus == PropertyStatus.Deleted))
					doWrite = true;
			}
			else
			{
				throw new NPersistException("Unknown object refresh behavior specified!"); // do not localize
			}
		}

		private void ToReference(object targetObject, MarshalReference mr, IPropertyMap propertyMap, RefreshBehaviorType refreshBehavior)
		{
			object value = null;
			if (mr.Type.Length > 0 && mr.IsNull == false)
				value = ToReferenceValue(targetObject, mr.Type, mr.Value, mr, propertyMap);
			
			Context.ObjectManager.SetPropertyValue(targetObject, propertyMap.Name, value);
			if (mr.HasOriginal)
			{
				object orgValue = null;
				if (mr.OriginalType.Length > 0 && mr.WasNull == false)
					orgValue = ToReferenceValue(targetObject, mr.OriginalType, mr.OriginalValue,mr, propertyMap);

				Context.ObjectManager.SetOriginalPropertyValue(targetObject, propertyMap.Name, orgValue);
				if (mr.IsNull != mr.WasNull || (value != null && orgValue != null && value.Equals(orgValue) == false))
				{
					this.Context.ObjectManager.SetUpdatedStatus(targetObject, propertyMap.Name, true);					
					//redundant, done once for object by outer caller
					//this.Context.UnitOfWork.RegisterDirty(targetObject, propertyMap.Name, true);						
				}
			}				
			Context.ObjectManager.SetNullValueStatus(targetObject, propertyMap.Name, mr.IsNull);
		}

		public MarshalProperty FromProperty(object sourceObject, IPropertyMap propertyMap)
		{
			object value = Context.ObjectManager.GetPropertyValue(sourceObject, propertyMap.Name);
			MarshalProperty mp = new MarshalProperty();
			mp.Name = propertyMap.Name;
			mp.IsNull = Context.ObjectManager.GetNullValueStatus(sourceObject, propertyMap.Name);
			if (value == null)
				mp.IsNull = true;
			if (mp.IsNull == false)
			{
				string mpValue = FromPropertyValue(sourceObject, value, propertyMap);
				if (mpValue != null)
					mp.Value = mpValue;
				else
					mp.IsNull = true;
			}
			if (Context.ObjectManager.HasOriginalValues(sourceObject, propertyMap.Name))
			{
				object orgValue = Context.ObjectManager.GetOriginalPropertyValue(sourceObject, propertyMap.Name);

				if (orgValue == null || DBNull.Value.Equals(orgValue))
					mp.WasNull = true;

				if (mp.WasNull == false)
				{
					string mpOrgValue = FromPropertyValue(sourceObject, orgValue, propertyMap);
					if (mpOrgValue != null)
						mp.OriginalValue = mpOrgValue;
					else
						mp.IsNull = true;
				}
				mp.HasOriginal = true;
			}
			else
			{
				mp.HasOriginal = false;	
			}
			mp.IsNull = Context.ObjectManager.GetNullValueStatus(sourceObject, propertyMap.Name);
			return mp;
		}

		private MarshalReference FromReference(object sourceObject, IPropertyMap propertyMap)
		{
			MarshalReference mr = new MarshalReference(); 
			mr.Name = propertyMap.Name;
			object value = Context.ObjectManager.GetPropertyValue(sourceObject, propertyMap.Name);
			if (value != null)
			{
				IClassMap classMap = Context.DomainMap.MustGetClassMap(value.GetType());
				mr.Type = classMap.GetName() ;
				mr.IsNull = false;
			}
			else
			{
				IClassMap refClassMap = propertyMap.MustGetReferencedClassMap() ;
				if (refClassMap != null)
					mr.Type = refClassMap.GetName() ;				
				mr.IsNull = true;
			}
			mr.Value = FromPropertyReference(sourceObject, value, propertyMap);
			if (Context.ObjectManager.HasOriginalValues(sourceObject, propertyMap.Name))
			{
				object orgValue =  Context.ObjectManager.GetOriginalPropertyValue(sourceObject, propertyMap.Name);
				mr.OriginalValue = FromPropertyReference(sourceObject, orgValue, propertyMap);				
				mr.HasOriginal = true;
				if (orgValue != null)
				{
					IClassMap orgClassMap = Context.DomainMap.MustGetClassMap(orgValue.GetType());
					mr.OriginalType = orgClassMap.GetName() ;
					mr.WasNull = false;
				}
				else
				{
					IClassMap refClassMap = propertyMap.MustGetReferencedClassMap() ;
					if (refClassMap != null)
						mr.OriginalType = refClassMap.GetName() ;				
					mr.WasNull = true;
				}
			}
			else
			{
				//mr.OriginalValue = FromPropertyReference(sourceObject, null, propertyMap);
				mr.HasOriginal = false;
			}
			return mr;
		}


		private MarshalReferenceValue FromPropertyReference(object sourceObject, object value, IPropertyMap propertyMap)
		{
			MarshalReferenceValue mrv = new MarshalReferenceValue() ;
			if (value != null)
			{
				foreach (IPropertyMap idPropertyMap in propertyMap.MustGetReferencedClassMap().GetIdentityPropertyMaps())
				{
					if (idPropertyMap.ReferenceType == ReferenceType.None)
					{					
						mrv.ReferenceProperties.Add(FromProperty(value, idPropertyMap)) ;
					}
					else
					{
						mrv.ReferenceReferences.Add(FromReference(value, idPropertyMap)) ;				
					}					
				}
			}
			return mrv;
		}

		
		public string GetIdentity(MarshalObject marshalObject)
		{
			IClassMap classMap = Context.DomainMap.MustGetClassMap(marshalObject.Type);
			StringBuilder id = new StringBuilder() ;
			string sep = classMap.IdentitySeparator;
			if (sep == "") { sep = "|"; }
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					MarshalProperty mp = marshalObject.GetProperty(propertyMap.Name);
					id.Append(mp.Value + sep);					
				}
				else
				{
					MarshalReference mr = marshalObject.GetReference(propertyMap.Name);
					id.Append(GetIdentity(mr, mr.Value) + sep);										
				}
			} 	
			if (id.Length > 0) { id.Length -= sep.Length; }
			return id.ToString();
		}

		
		public string GetIdentity(MarshalReference marshalReference, MarshalReferenceValue marshalReferenceValue)
		{
			IClassMap classMap = Context.DomainMap.MustGetClassMap(marshalReference.Type);
			StringBuilder id = new StringBuilder() ;
			string sep = classMap.IdentitySeparator;
			if (sep == "") { sep = "|"; }
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					MarshalProperty mp = marshalReferenceValue.GetReferenceProperty(propertyMap.Name);
					id.Append(mp.Value + sep);					
				}
				else
				{
					MarshalReference mr = marshalReferenceValue.GetReferenceReference(propertyMap.Name);
					id.Append(GetIdentity(mr, marshalReferenceValue) + sep);										
				}
			} 
			if (id.Length > 0) { id.Length -= sep.Length; }
			return id.ToString();
		}

		
		public object ToReferenceValue(object targetObject, string type, MarshalReferenceValue value, MarshalReference mr, IPropertyMap propertyMap)
		{
			IClassMap classMap = Context.DomainMap.MustGetClassMap(type);
			Type realType = Context.AssemblyManager.MustGetTypeFromClassMap(classMap);
			string identity = GetIdentity(mr, value);
			return Context.GetObjectById(identity, realType, true);
		}

		public object ToPropertyValue(object targetObject, string value, MarshalProperty mp, IPropertyMap propertyMap)
		{
			return ToValue(propertyMap, value);
		}

		
		public string FromPropertyValue(object sourceObject, object value, IPropertyMap propertyMap)
		{
			if (Type.GetType(propertyMap.DataType) == typeof(System.Byte[]))
				return Convert.ToBase64String((byte[]) value);
			else
				return Convert.ToString(value);
		}

		private static object ToValue(IPropertyMap propertyMap, string value)
		{		
			if (Type.GetType(propertyMap.DataType) == typeof(System.Byte[]))
				return Convert.FromBase64String(value);			
			else
				return Convert.ChangeType(value, Type.GetType(propertyMap.DataType), CultureInfo.InvariantCulture);				
		}

		private static object ToValue(DbType dbType, string value)
		{
			if (dbType == DbType.AnsiString || dbType == DbType.AnsiStringFixedLength || dbType == DbType.String || dbType == DbType.StringFixedLength )
			{
				return value;				
			}
			if (dbType == DbType.Binary ) { return Convert.FromBase64String(value); }
			if (dbType == DbType.Boolean) { return Convert.ToBoolean(value); }
			if (dbType == DbType.Byte) { return Convert.ToByte(value); }
			if (dbType == DbType.Currency) { return Convert.ToDecimal(value); }
			if (dbType == DbType.Date) { return Convert.ToDateTime(value); }
			if (dbType == DbType.Date || dbType == DbType.DateTime || dbType == DbType.Time)
				if (value == "")
					return System.DateTime.MinValue;					
				else
					return Convert.ToDateTime(value);					
	
			if (dbType == DbType.Decimal) { return Convert.ToDecimal(value); }
			if (dbType == DbType.Double) { return Convert.ToDouble(value); }
			if (dbType == DbType.Guid) { return new Guid(value); }
			if (dbType == DbType.Int16) { return Convert.ToInt16(value); }
			if (dbType == DbType.Int32) { return Convert.ToInt32(value); }
			if (dbType == DbType.Int64) { return Convert.ToInt64(value); }
			//if (dbType == DbType.Object) { return Convert.ToBoolean(value); }
			if (dbType == DbType.SByte) { return Convert.ToSByte(value); }
			if (dbType == DbType.Single) { return Convert.ToSingle(value); }
			if (dbType == DbType.Time) { return Convert.ToDateTime(value); }
			if (dbType == DbType.UInt16) { return Convert.ToUInt16(value); }
			if (dbType == DbType.UInt32) { return Convert.ToUInt32(value); }
			if (dbType == DbType.UInt64) { return Convert.ToUInt64(value); }
			if (dbType == DbType.VarNumeric) { return Convert.ToDecimal(value); }
	
			return value;
		}


		public virtual MarshalQuery FromQuery(IQuery query)
		{
			MarshalQuery mq = new MarshalQuery() ;
			if (query is NPathQuery)
				mq.QueryType = "NPathQuery";
			if (query is SqlQuery)
				mq.QueryType = "SqlQuery";
			IClassMap classMap = Context.DomainMap.MustGetClassMap(query.PrimaryType);
			mq.PrimitiveType = classMap.GetName() ;
			mq.QueryString = query.Query.ToString() ;
			foreach (IQueryParameter p in query.Parameters)
			{
				MarshalParameter mp = new MarshalParameter() ;
				mp.DbType = p.DbType;
				mp.Name = p.Name ;
				mp.Value = FromParameterValue(p) ;
				mq.Parameters.Add(mp);
			}
			return mq;
		}

		public string FromParameterValue(IQueryParameter parameter)
		{
			return Convert.ToString(parameter.Value);
		}

		public object ToParameterValue(MarshalParameter parameter)
		{
			return ToValue(parameter.DbType, parameter.Value);
		}


		public virtual IQuery ToQuery(MarshalQuery marshalQuery)
		{
			IQuery query = null;
			IContext ctx = this.Context;
			IClassMap classMap = ctx.DomainMap.MustGetClassMap(marshalQuery.PrimitiveType);
			Type realType = ctx.AssemblyManager.MustGetTypeFromClassMap(classMap);
			if (marshalQuery.QueryType == "NPathQuery")
				query = new NPathQuery(marshalQuery.QueryString, realType, this.Context);
			if (marshalQuery.QueryType == "SqlQuery")
				query = new SqlQuery(marshalQuery.QueryString, realType, this.Context);
			query.Query = marshalQuery.QueryString;
			foreach (MarshalParameter mp in marshalQuery.Parameters)
			{
				object value = ToParameterValue(mp);
				IQueryParameter param = new QueryParameter(mp.Name, mp.DbType, value);
				query.Parameters.Add(param);
			}
			return query;
		}	


		public virtual MarshalObjectList FromObjectList(IList sourceObjects)
		{
			MarshalObjectList mol = new MarshalObjectList();
			foreach (object obj in sourceObjects)
			{
				MarshalObject mo = FromObject(obj);
				mol.Objects.Add(mo);
			}

			return mol;
		}

		//Two pass operation - first deserialise all objects, the set up relationships
		public virtual IList ToObjectList(MarshalObjectList marshalObjectList, RefreshBehaviorType refreshBehavior, IList listToFill)
		{
			foreach (MarshalObject mo in marshalObjectList.Objects)
			{
				GetObjectListObject(mo, 1, refreshBehavior);
			}

			foreach (MarshalObject mo in marshalObjectList.Objects)
			{
				object obj = GetObjectListObject(mo, 2, refreshBehavior);
				listToFill.Add(obj);
			}

			return listToFill;
		}

		public virtual MarshalReference FromObjectAsReference(object sourceObject)
		{
			IClassMap classMap = Context.DomainMap.MustGetClassMap(sourceObject.GetType());
			MarshalReference mr = new MarshalReference();
			mr.Type = classMap.GetName();
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{					
					if (propertyMap.IsCollection)
					{					

					}
					else
					{
						mr.Value.ReferenceProperties.Add(FromProperty(sourceObject, propertyMap));									
					}
				}
				else
				{
					if (propertyMap.IsCollection)
					{					

					}
					else
					{
						mr.Value.ReferenceProperties.Add(FromReference(sourceObject, propertyMap));
					}												
				}					
			}

			return mr;
		}



	}
}
