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
using System.Diagnostics;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using System.Globalization;
using System.Reflection;
using Puzzle.NPersist.Framework.Utility;
using Puzzle.NCore.Framework.Collections;
using Puzzle.NAspect.Framework;


namespace Puzzle.NPersist.Framework.Persistence
{
	public class DefaultObjectManager : ContextChild, IObjectManager
	{
		public DefaultObjectManager() : base()
		{
		}

		private Hashtable m_hashTempIds = new Hashtable();

		public virtual string GetObjectKey(object obj)
		{
			string key = "";
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			string sep = classMap.KeySeparator;
			if (sep == "")
			{
				sep = " ";
			}
			object value;
			foreach (IPropertyMap propertyMap in classMap.GetKeyPropertyMaps())
			{
				value = GetPropertyValue(obj, propertyMap.Name);
				if (value == null || GetNullValueStatus(obj, propertyMap.Name))
				{
					return "";
				}
				if (!(propertyMap.ReferenceType == ReferenceType.None))
				{
					value = GetObjectKey(value);
					if (((string)value).Length < 1)
						return "";
				}
				key += Convert.ToString(value) + sep;
			}
			if (key.Length > sep.Length)
			{
				key = key.Substring(0, key.Length - sep.Length);
			}
			return key;
		}

		public virtual string GetObjectKeyOrIdentity(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			string key = "";
			if (classMap.GetKeyPropertyMaps().Count > 0)
			{
				key = GetObjectKey(obj);
			}
			if (key.Length < 1)
			{
				key = GetObjectIdentity(obj);
			}
			return key;
		}

		public virtual string GetObjectIdentity(object obj) => GetObjectIdentity(obj, null, null);

	    public virtual string GetObjectIdentity(object obj, IPropertyMap newPropertyMap, object newValue)
		{
			string id = BuildObjectIdentity(obj, newPropertyMap, newValue);
			return id;
		}

		public bool HasIdentity(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());

			object value;
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				value = GetPropertyValue(obj, propertyMap.Name);
				if (value == null || GetNullValueStatus(obj, propertyMap.Name) == true)
				{
					return false;
				}
				else if (propertyMap.ReferenceType != ReferenceType.None)
				{
					//this ensures that a complete id can be created ahead in case of auto-in
					//m_ObjectManager.GetPropertyValue(obj, propertyMap.Name);
					if (!HasIdentity(value))
						return false;
				}
			}
			return true;
		}


		private string BuildObjectIdentity(object obj, IPropertyMap newPropertyMap, object newValue)
		{
			string id = "";
			IIdentityHelper identityHelper = obj as IIdentityHelper;
			if (identityHelper != null)
			{
				id = identityHelper.GetIdentity();
				if (id != null)
					return id;
				id = "";
			}

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			string sep = classMap.IdentitySeparator;

			if (sep == "")
				sep = "|";

			object value;
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				if (propertyMap == newPropertyMap)
				{
					value = newValue;
					if (propertyMap.ReferenceType != ReferenceType.None)
					{
						if (!HasIdentity(value))
							return GetTempId(obj);

						value = GetObjectIdentity(value);
					}
				}
				else
				{
					value = GetPropertyValue(obj, propertyMap.Name);
					if (value == null || GetNullValueStatus(obj, propertyMap.Name) == true)
					{
						return GetTempId(obj);
					}
					else if (propertyMap.ReferenceType != ReferenceType.None)
					{
						//this ensures that a complete id can be created ahead in case of auto-in
						//m_ObjectManager.GetPropertyValue(obj, propertyMap.Name);
						if (!HasIdentity(value))
							return GetTempId(obj);

						value = GetObjectIdentity(value);
					}
				}

				id += Convert.ToString(value) + sep;
			}
			if (id.Length > sep.Length)
			{
				id = id.Substring(0, id.Length - sep.Length);
			}
			if (identityHelper != null)
				identityHelper.SetIdentity(id);

			return id;
		}


		private string GetTempId(object obj)
		{
			if (!(m_hashTempIds.ContainsKey(obj)))
			{
				m_hashTempIds[obj] = Guid.NewGuid().ToString();
			}
			return (string)m_hashTempIds[obj];
		}


		public virtual IList GetObjectIdentityKeyParts(object obj) => GetObjectIdentityKeyParts(obj, null, null);

	    public virtual IList GetObjectIdentityKeyParts(object obj, IPropertyMap newPropertyMap, object newValue) => BuildObjectIdentityKeyParts(obj, newPropertyMap, newValue);

	    private IList BuildObjectIdentityKeyParts(object obj, IPropertyMap newPropertyMap, object newValue)
		{
			IIdentityHelper identityHelper = obj as IIdentityHelper;
			if (identityHelper != null)
			{
				if (identityHelper.HasIdentityKeyParts())
					return identityHelper.GetIdentityKeyParts();
			}

			IList idKeyParts = new ArrayList(1);

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());

			object value;
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				if (propertyMap == newPropertyMap)
				{
					value = newValue;
					if (propertyMap.ReferenceType != ReferenceType.None)
					{
						value = GetObjectIdentity(value);
					}
				}
				else
				{
					value = GetPropertyValue(obj, propertyMap.Name);
					if (value == null || GetNullValueStatus(obj, propertyMap.Name) == true)
					{
						if (!(m_hashTempIds.ContainsKey(obj)))
						{
							m_hashTempIds[obj] = Guid.NewGuid().ToString();
						}
						idKeyParts.Clear();
						idKeyParts.Add(m_hashTempIds[obj]);
						return idKeyParts;
					}
					else if (propertyMap.ReferenceType != ReferenceType.None)
					{
						//this ensures that a complete id can be created ahead in case of auto-in
						//m_ObjectManager.GetPropertyValue(obj, propertyMap.Name);
						value = GetObjectIdentity(value);
					}
				}
				idKeyParts.Add(value);
			}

			if (identityHelper != null)
			{
				IList cached = identityHelper.GetIdentityKeyParts();
				foreach (object keyPart in idKeyParts)
					cached.Add(keyPart);
			}

			return idKeyParts;
		}


		public virtual void SetObjectIdentity(object obj, string identity)
		{
            try
            {
				IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
				string sep = classMap.IdentitySeparator;
				if (sep == "")
				{
					sep = "|";
				}
				string[] arrId = identity.Split(sep.ToCharArray());
				long i = 0;
				Type refType;
				object refObj;
				object val;
				foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
				{
					if (propertyMap.ReferenceType != ReferenceType.None)
					{
						//Bad...only works for referenced objects with non-composite ids...
						refType = obj.GetType().GetProperty(propertyMap.Name).PropertyType;
						refObj = this.Context.GetObjectById(Convert.ToString(arrId[i]), refType, true);
						SetPropertyValue(obj, propertyMap.Name, refObj);
						SetOriginalPropertyValue(obj, propertyMap.Name, refObj);
						SetNullValueStatus(obj, propertyMap.Name, false);
					}
					else
					{
						val = ConvertValueToType(obj, propertyMap, arrId[i]);
						SetPropertyValue(obj, propertyMap.Name, val);
						SetOriginalPropertyValue(obj, propertyMap.Name, val);
						SetNullValueStatus(obj, propertyMap.Name, false);
					}
					i += 1;
				}
			}
            catch (Exception ex)
            {
                throw new NPersistException(string.Format ("Could not set Identity '{0}' on object '{1}'",identity,obj), ex);
            }
		}

		public virtual void SetObjectIdentity(object obj, KeyStruct keyStruct)
		{
			try
			{
				IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
				long i = 1;
				Type refType;
				object refObj;
				object val;
				foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
				{
					if (propertyMap.ReferenceType != ReferenceType.None)
					{
						//Bad...only works for referenced objects with non-composite ids...
						refType = obj.GetType().GetProperty(propertyMap.Name).PropertyType;
						refObj = this.Context.GetObjectById(keyStruct.keys[i], refType, true);
						SetPropertyValue(obj, propertyMap.Name, refObj);
						SetOriginalPropertyValue(obj, propertyMap.Name, refObj);
						SetNullValueStatus(obj, propertyMap.Name, false);
					}
					else
					{
						val = keyStruct.keys[i];
						SetPropertyValue(false, obj, propertyMap.Name, val);
						SetOriginalPropertyValue(obj, propertyMap.Name, val);
						SetNullValueStatus(obj, propertyMap.Name, false);
					}
					i += 1;
				}
			}
			catch (Exception ex)
			{
				throw new NPersistException(string.Format ("Could not set Identity '{0}' on object '{1}'",keyStruct.keys[1].ToString(),obj), ex);
			}
		}


		public virtual string GetPropertyDisplayName(object obj, string propertyName) => propertyName;

	    public virtual string GetPropertyDescription(object obj, string propertyName) => "";

	    //[DebuggerStepThrough()]
		public virtual object GetPropertyValue(object obj, string propertyName) => GetPropertyValue(obj, obj.GetType(), propertyName);

	    public virtual object GetPropertyValue(object obj, Type type, string propertyName)
		{
#if NET2
            FastFieldGetter getter = GetFastGetter(obj, propertyName);
            return getter(obj);
#else
			FieldInfo fieldInfo = (FieldInfo)propertyLookup[obj.GetType().Name +"."+ propertyName];
			if (fieldInfo == null)
			{
				fieldInfo = GetFieldInfo(obj, propertyName);
			}

			return fieldInfo.GetValue(obj);
#endif
		}

		public virtual void SetPropertyValue(object obj, string propertyName, object value) => SetPropertyValue(true, obj, propertyName, value);

	    public virtual void SetPropertyValue(bool ensureReadConsistency, object obj, string propertyName, object value)
		{
			if (ensureReadConsistency)
				EnsureReadConsistency(obj, propertyName);
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
			try
			{
				SetPropertyValue(obj, obj.GetType(), propertyName, value);
			}
			catch(Exception x)
			{
				string message = string.Format("Failed to set property {0} to value {1} on object {2}.{3}", propertyName, value == null ? "null" : value,AssemblyManager.GetBaseType (obj).Name, GetObjectKeyOrIdentity(obj));
				throw new LoadException(message, x,obj);
			}
		}

		private void EnsureReadConsistency(object obj, string propertyName)
		{
			IContext ctx = this.Context;

			if (ctx.ReadConsistency.Equals(ConsistencyMode.Pessimistic))
			{
				IIdentityHelper identityHelper = obj as IIdentityHelper;
				if (identityHelper == null)
					throw new NPersistException(string.Format("Object of type {0} does not implement IIdentityHelper", obj.GetType()));

				IClassMap classMap = ctx.DomainMap.MustGetClassMap(obj.GetType());
				ISourceMap sourceMap = classMap.GetSourceMap();
				if (sourceMap != null)
				{
					if (sourceMap.PersistenceType.Equals(PersistenceType.ObjectRelational) || sourceMap.PersistenceType.Equals(PersistenceType.Default))
					{
						ITransaction tx = ctx.GetTransaction(ctx.GetDataSource(sourceMap).GetConnection());
						if (tx == null)
						{
							throw new ReadConsistencyException(
								string.Format("A read consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was loaded or initialized with a value outside of a transaction. This is not permitted in a context using Pessimistic ReadConsistency.",
								propertyName,
								obj.GetType(),
								ctx.ObjectManager.GetObjectIdentity(obj)),									 
								obj);
						}

						Guid txGuid = identityHelper.GetTransactionGuid();
						if (!(tx.Guid.Equals(txGuid)))
						{
							throw new ReadConsistencyException(
								string.Format("A read consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} has already been loaded or initialized inside a transactions with Guid {3} and was now loaded or initialized again under another transaction with Guid {4}. This is not permitted in a context using Pessimistic ReadConsistency.",
								propertyName,
								obj.GetType(),
								ctx.ObjectManager.GetObjectIdentity(obj),
								txGuid, 
								tx.Guid),
								txGuid, 
								tx.Guid, 
								obj);
						}
					}
				}
			}
		}

		private Hashtable propertyLookup = new Hashtable();
		private FieldInfo GetFieldInfo(object obj, string propertyName)
		{
			IPropertyMap propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
			FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(propertyMap, obj.GetType (), propertyName);
			if (fieldInfo == null)
				throw new MappingException("Could not find a field with the name '" + propertyMap.GetFieldName() + "' in class " + obj.GetType().Name);
			propertyLookup[obj.GetType().Name + "." + propertyName] = fieldInfo;
			return fieldInfo;
		}

#if NET2
        private Hashtable fastFieldGetterLookup = new Hashtable();
        private Hashtable fastFieldSetterLookup = new Hashtable();
        private FastFieldGetter GetFastGetter(object obj, string propertyName)
        {
            string key = obj.GetType().Name + "." + propertyName;
            FastFieldGetter res = (FastFieldGetter)fastFieldGetterLookup[key];
            if (res == null)
            {
                FieldInfo fieldInfo = GetFieldInfo(obj, propertyName);
                res = FastFieldAccess.GetFieldGetter(fieldInfo);
                fastFieldGetterLookup[key] = res;
            }

            return res;
        }
#endif

        
		public virtual void SetPropertyValue(object obj, Type type, string propertyName, object value)
		{
#if NET2
            if (value == null)
            {
                SetPropertyValueReflection(obj, propertyName, value);
            }
            else
            {
                string key = obj.GetType().Name + "." + propertyName;
                FastFieldSetter setter = (FastFieldSetter)fastFieldSetterLookup[key];
                if (setter == null)
                {
                    FieldInfo fieldInfo = GetFieldInfo(obj, propertyName);
                    setter = FastFieldAccess.GetFieldSetter(fieldInfo);
                    fastFieldSetterLookup[key] = setter;
                }

                setter(obj, value);
            }
#else
			SetPropertyValueReflection(obj, propertyName, value);  
#endif
		}

		private void SetPropertyValueReflection(object obj, string propertyName, object value)
		{
			FieldInfo fieldInfo = (FieldInfo)propertyLookup[obj.GetType().Name + "." + propertyName];
			if (fieldInfo == null)
			{
				fieldInfo = GetFieldInfo(obj, propertyName);
			}
			if (fieldInfo.FieldType.IsEnum)
			{
				if (value != null)
				{
					fieldInfo.SetValue(obj, Enum.ToObject(fieldInfo.FieldType, value));
					return;
				}
			}
			fieldInfo.SetValue(obj, value);
		}


		//[DebuggerStepThrough()]
		public virtual ObjectStatus GetObjectStatus(object obj) => ((IObjectStatusHelper) obj).GetObjectStatus();

	    public virtual void SetObjectStatus(object obj, ObjectStatus value)
		{
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
			((IObjectStatusHelper) obj).SetObjectStatus(value);
		}
		
		public virtual PropertyStatus GetPropertyStatus(object obj, string propertyName)
		{
			ObjectStatus objStatus = GetObjectStatus(obj);
			if (objStatus == ObjectStatus.UpForCreation)
			{
				return PropertyStatus.Dirty;

			}
			if (objStatus == ObjectStatus.Deleted)
			{
				return PropertyStatus.Deleted;
			}
			if (IsDirtyProperty(obj, propertyName))
			{
				return PropertyStatus.Dirty;
			}
			if (HasOriginalValues(obj, propertyName))
			{
				return PropertyStatus.Clean;
			}
			return PropertyStatus.NotLoaded;
		}

		public virtual object GetOriginalPropertyValue(object obj, string propertyName) => ((IOriginalValueHelper) obj).GetOriginalPropertyValue(propertyName);

	    public virtual void SetOriginalPropertyValue(object obj, string propertyName, object value)
		{
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
			((IOriginalValueHelper) obj).SetOriginalPropertyValue(propertyName, value);
		}

		public virtual void RemoveOriginalValues(object obj, string propertyName) => ((IOriginalValueHelper) obj).RemoveOriginalValues(propertyName);

	    public virtual bool HasOriginalValues(object obj) => ((IOriginalValueHelper) obj).HasOriginalValues();

	    public virtual bool HasOriginalValues(object obj, string propertyName) => ((IOriginalValueHelper) obj).HasOriginalValues(propertyName);

	    public virtual bool IsDirtyProperty(object obj, string propertyName)
		{				
			if (!GetUpdatedStatus(obj, propertyName))
				return false;

			if (!(HasOriginalValues(obj, propertyName)))
				return false;

			object orgValue = GetOriginalPropertyValue(obj, propertyName);
			if (Convert.IsDBNull(orgValue))
			{
				if (GetNullValueStatus(obj, propertyName))
					return false;
				else
					return true;
			}
			else
			{
				if (GetNullValueStatus(obj, propertyName))
					return true;
			}

			object value = GetPropertyValue(obj, propertyName);
			if (!(ComparePropertyValues(obj, propertyName, value, orgValue)))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public virtual bool ComparePropertyValues(object obj, string propertyName, object value1, object value2)
		{
			IPropertyMap propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
			Array arr1;
			Array arr2;
			if (propertyMap.IsCollection)
			{
				return this.Context.ListManager.CompareLists((IList)value1, (IList)value2);
			}
			else
			{
				if (!(propertyMap.ReferenceType == ReferenceType.None))
				{
					if (value1 == value2)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					if (Util.IsArray(value1) || Util.IsArray(value2))
					{
						if (!((Util.IsArray(value1) && Util.IsArray(value2))))
						{
							return false;
						}
					}
					if (Util.IsArray(value1) && Util.IsArray(value2))
					{
						if (((Array)(value1)).Length == ((Array)(value2)).Length)
						{
							arr1 = ((Array)(value1));
							arr2 = ((Array)(value2));
							if (!(CompareArrays(arr1, arr2)))
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					}
					else
					{
						string lowTypeName = propertyMap.DataType.ToLower(CultureInfo.InvariantCulture);
						if (lowTypeName == "guid" || lowTypeName == "system.guid")
						{
							if (((Guid)(value1)).Equals(value2))
							{
								return true;
							}
							else
							{
								return false;
							}
						}
						else
						{
							if (value1 == null || value2 == null)
							{
								if (value1 == null && value2 == null)
								{
									return true;
								}
								else
								{
									return false;
								}
							}
							else
							{
								if (value1.Equals(value2))
								{
									return true;
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
			return true;
		}

		protected virtual bool CompareArrays(Array arr1, Array arr2)
		{
			object value1;
			object value2;
			for (int i = 0; i <= arr1.GetUpperBound(0); i++)
			{
				value1 = arr1.GetValue(i);
				value2 = arr2.GetValue(i);
				if (value1 == null || value2 == null)
				{
					if (!(value1 == null && value2 == null))
					{
						return false;
					}
				}
				else
				{
					if (!(value1.Equals(value2)))
					{
						return false;
					}
				}
			}
			return true;
		}

		//[DebuggerStepThrough()]
		public virtual bool GetNullValueStatus(object obj, string propertyName)
		{
			INullValueHelper nullValueHelper = obj as INullValueHelper;
			if (nullValueHelper != null)
				return nullValueHelper.GetNullValueStatus(propertyName);
			return false;
		}

		//[DebuggerStepThrough()]
		public virtual void SetNullValueStatus(object obj, string propertyName, bool value)
		{
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
			((INullValueHelper) obj).SetNullValueStatus(propertyName, value);
		}

		
		public virtual bool GetUpdatedStatus(object obj, string propertyName) => ((IUpdatedPropertyTracker) obj).GetUpdatedStatus(propertyName);

	    //[DebuggerStepThrough()]
		public virtual void SetUpdatedStatus(object obj, string propertyName, bool value)
		{
			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
			((IUpdatedPropertyTracker) obj).SetUpdatedStatus(propertyName, value);
		}

		public virtual void ClearUpdatedStatuses(object obj) => ((IUpdatedPropertyTracker) obj).ClearUpdatedStatuses();

	    public virtual void EnsurePropertyIsLoaded(object obj, string propertyName)
		{
			IPropertyMap propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
			EnsurePropertyIsLoaded(obj, propertyMap);
		}

		public virtual void EnsurePropertyIsLoaded(object obj, IPropertyMap propertyMap)
		{
			IObjectManager om = this.Context.ObjectManager;
			IPersistenceEngine pe = this.Context.PersistenceEngineManager ;
			if (pe == null)
				pe = this.Context.PersistenceEngine ;

			ObjectStatus objStatus;
			PropertyStatus propStatus;
			objStatus = om.GetObjectStatus(obj) ;
			if (objStatus != ObjectStatus.Deleted )
			{
				if (objStatus == ObjectStatus.NotLoaded )
				{
					pe.LoadObject(ref obj);
					if (pe == null)
					{
						throw new ObjectNotFoundException("Object not found!"); // do not localize
					}
				}
				propStatus = om.GetPropertyStatus(obj, propertyMap.Name) ;
				if (propStatus == PropertyStatus.NotLoaded )
				{
					pe.LoadProperty(obj, propertyMap.Name);
				}
			}
			else
			{
				//We really ought to throw an exception here...
			}
		}			



		public virtual void InvalidateObjectsInCache(bool invalidateDirty) 
        {
            IList objects = this.Context.IdentityMap.GetObjects(); 
            InvalidateObjects(objects, invalidateDirty);
        }

		public virtual void InvalidateObjects(IList objects, bool invalidateDirty)
        {
            foreach (object obj in objects)
                InvalidateObject(obj, invalidateDirty);
        }

		public virtual void InvalidateObject(object obj, bool invalidateDirty)
		{
			IObjectManager om = this.Context.ObjectManager;
            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			//ObjectStatus objStatus = om.GetObjectStatus(obj) ;
            foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
            {
                if (!propertyMap.IsIdentity)
                    InvalidateProperty(obj, propertyMap, invalidateDirty );
            }
            //if (!(objStatus == ObjectStatus.Dirty && invalidateDirty == false))
            //{
            //    RemoveOriginalValues(obj, propertyMap.Name);
            //}
		}


		public virtual void InvalidateProperty(object obj, string propertyName, bool invalidateDirty)
		{
			IPropertyMap propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
			InvalidateProperty(obj, propertyMap, invalidateDirty);
		}

		public virtual void InvalidateProperty(object obj, IPropertyMap propertyMap, bool invalidateDirty)
		{
            if (propertyMap.IsIdentity)
                throw new NPersistException("Identity properties can not be invalidated! Property: " + AssemblyManager.GetBaseType(obj).Name + "." + propertyMap.Name, obj, propertyMap.Name);

			IObjectManager om = this.Context.ObjectManager;
			IPersistenceEngine pe = this.Context.PersistenceEngine ;
			PropertyStatus propStatus;
			propStatus = om.GetPropertyStatus(obj, propertyMap.Name) ;
			if (!(propStatus == PropertyStatus.Dirty && invalidateDirty == false))
			{
				RemoveOriginalValues(obj, propertyMap.Name);
			}
		}			

		
		public virtual long GetTimeToLive(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			return GetTimeToLive(classMap);
		}

		public virtual long GetTimeToLive(IClassMap classMap)
		{
			long ttl = classMap.GetTimeToLive();
			if (ttl < 0)
				ttl = this.Context.TimeToLive ;
			return ttl;
		}

		public virtual long GetTimeToLive(object obj, string propertyName)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
			return GetTimeToLive(propertyMap);
		}

		public virtual long GetTimeToLive(IPropertyMap propertyMap)
		{
			long ttl = propertyMap.GetTimeToLive();
			if (ttl < 0)
				ttl = this.Context.TimeToLive ;
			return ttl;			
		}

		public virtual TimeToLiveBehavior GetTimeToLiveBehavior(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			return GetTimeToLiveBehavior(classMap);			
		}

		public virtual TimeToLiveBehavior GetTimeToLiveBehavior(IClassMap classMap)
		{
			TimeToLiveBehavior ttlBehavior = classMap.GetTimeToLiveBehavior();
			if (ttlBehavior == TimeToLiveBehavior.Default)
				ttlBehavior = this.Context.TimeToLiveBehavior ;
			return ttlBehavior;			
		}

		public virtual TimeToLiveBehavior GetTimeToLiveBehavior(object obj, string propertyName)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
			return GetTimeToLiveBehavior(propertyMap);
		}

		public virtual TimeToLiveBehavior GetTimeToLiveBehavior(IPropertyMap propertyMap)
		{
			TimeToLiveBehavior ttlBehavior = propertyMap.GetTimeToLiveBehavior();
			if (ttlBehavior == TimeToLiveBehavior.Default)
				ttlBehavior = this.Context.TimeToLiveBehavior ;
			return ttlBehavior;									
		}


		public virtual LoadBehavior GetLoadBehavior(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			return GetLoadBehavior(classMap);			
		}

		public virtual LoadBehavior GetLoadBehavior(Type type)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(type);
			return GetLoadBehavior(classMap);			
		}

		public virtual LoadBehavior GetLoadBehavior(IClassMap classMap)
		{
			LoadBehavior loadBehavior = classMap.GetLoadBehavior();
			if (loadBehavior == LoadBehavior.Default)
				loadBehavior = this.Context.LoadBehavior;
			return loadBehavior;			
		}

		public virtual object ConvertValueToType(object obj, IPropertyMap propertyMap, string value) => ConvertValueToType(obj.GetType(), propertyMap, value);

	    public virtual object ConvertValueToType(Type type, IPropertyMap propertyMap, string value)
		{
			Type propType = type.GetProperty(propertyMap.Name).PropertyType;
			if (propType == typeof(String) || propType.IsSubclassOf(typeof(String)))
			{
				return value;
			}
			else if (propType == typeof(Boolean) || propType.IsSubclassOf(typeof(Boolean)))
			{
				return Convert.ToBoolean(value);
			}
			else if (propType == typeof(Byte) || propType.IsSubclassOf(typeof(Byte)))
			{
				return Convert.ToByte(value);
			}
			else if (propType == typeof(Char) || propType.IsSubclassOf(typeof(Char)))
			{
				return Convert.ToChar(value);
			}
			else if (propType == typeof(DateTime) || propType.IsSubclassOf(typeof(DateTime)))
			{
				return Convert.ToDateTime(value);
			}
			else if (propType == typeof(Decimal) || propType.IsSubclassOf(typeof(Decimal)))
			{
				return Convert.ToDecimal(value);
			}
			else if (propType == typeof(Double) || propType.IsSubclassOf(typeof(Double)))
			{
				return Convert.ToDouble(value);
			}
			else if (propType == typeof(Guid) || propType.IsSubclassOf(typeof(Guid)))
			{
				return new Guid(value);
			}
			else if (propType == typeof(Int16) || propType.IsSubclassOf(typeof(Int16)))
			{
				return Convert.ToInt16(value);
			}
			else if (propType == typeof(Int32) || propType.IsSubclassOf(typeof(Int32)))
			{
				return Convert.ToInt32(value);
			}
			else if (propType == typeof(Int64) || propType.IsSubclassOf(typeof(Int64)))
			{
				return Convert.ToInt64(value);
			}
			else if (propType == typeof(SByte) || propType.IsSubclassOf(typeof(SByte)))
			{
				return Convert.ToByte(value);
			}
			else if (propType == typeof(Single) || propType.IsSubclassOf(typeof(Single)))
			{
				return Convert.ToSingle(value);
			}
			else if (propType == typeof(ushort) || propType.IsSubclassOf(typeof(ushort)))
			{
				return UInt16.Parse(value);
			}
			else if (propType == typeof(uint) || propType.IsSubclassOf(typeof(uint)))
			{
				return UInt32.Parse(value);
			}
			else if (propType == typeof(ulong) || propType.IsSubclassOf(typeof(ulong)))
			{
				return UInt64.Parse(value);
			}
			else if (propType == typeof(object) || propType.IsSubclassOf(typeof(object)))
			{
				return value;
			}
			else
			{
				return value;
			}
		}

        public virtual IList ParseObjectIdentityKeyParts(Type type, string identity)
        {
            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(type);
            return ParseObjectIdentityKeyParts(classMap, classMap.GetIdentityPropertyMaps(), type, identity);
        }

        public virtual IList ParseObjectIdentityKeyParts(IClassMap classMap, IList idPropertyMaps, Type type, string identity)
        {
            string sep = classMap.IdentitySeparator;
            if (sep == "")
            {
                sep = "|";
            }
            string[] arrId = identity.Split(sep.ToCharArray());
            IList idKeyParts = new ArrayList(1);
            long i = 0;
            foreach (IPropertyMap propertyMap in idPropertyMaps)
            {
                if (propertyMap.ReferenceType != ReferenceType.None)
                {
                    //Bad...only works for referenced objects with non-composite ids...
                    IClassMap refClassMap = propertyMap.MustGetReferencedClassMap();
                    Type refType = this.Context.AssemblyManager.MustGetTypeFromClassMap(refClassMap);
                    idKeyParts.Add(ConvertValueToType(refType, (IPropertyMap) refClassMap.GetIdentityPropertyMaps()[0], arrId[i]));
                }
                else
                {
                    idKeyParts.Add(ConvertValueToType(type, propertyMap, arrId[i]));
                }
                i += 1;
            }
            return idKeyParts;
        }


	}
}