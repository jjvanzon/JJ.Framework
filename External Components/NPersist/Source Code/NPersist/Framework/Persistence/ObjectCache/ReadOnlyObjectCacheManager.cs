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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ReadOnlyObjectCacheManager.
	/// </summary>
	public class ReadOnlyObjectCacheManager : ContextChild, IReadOnlyObjectCacheManager
	{

		public static ReadOnlyObjectCache ReadOnlyObjectCache = new ReadOnlyObjectCache(); 

		public ReadOnlyObjectCacheManager()
		{
		}

		#region Property  MaxSize
		
		public long MaxSize
		{
			get
			{
				lock (ReadOnlyObjectCache)
				{
					return ReadOnlyObjectCache.MaxSize;					
				}
			}
			set
			{
				lock (ReadOnlyObjectCache)
				{
					ReadOnlyObjectCache.MaxSize = value;					
				} 
			}
		}
		
		#endregion

		#region IReadOnlyObjectCacheManager implementation

		public virtual bool HasObject(object obj)
		{
			string id = this.Context.ObjectManager.GetObjectIdentity(obj);
			string key = GetKey(obj, id);

			lock (ReadOnlyObjectCache) 
			{
				ReadOnlyClone clone = (ReadOnlyClone) ReadOnlyObjectCache.ObjectCache[key];
				if (clone != null)
					clone = UnloadIfExpired(clone);
				if (clone != null)
					return true;
			}			
			return false;
		}

		public virtual bool LoadObject(object obj)
		{
			lock (ReadOnlyObjectCache) 
			{
				if (!HasObject(obj))
					return false;

				Deserialize(obj);
				return true;
			}			
		}

		public virtual void SaveObject(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			if (!classMap.IsReadOnly)
				return;

			lock (ReadOnlyObjectCache) 
			{
				if (!HasObject(obj))
				{
					Serialize(obj);
				}
				CleanUp();
			}			
		}


		public virtual void Clear()
		{
			lock (ReadOnlyObjectCache) 
			{
				ReadOnlyObjectCache.ObjectCache.Clear() ;
			}			
		}

		public virtual void Clear(Type type)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(type);
			string typeName = classMap.GetFullName();
			lock (ReadOnlyObjectCache) 
			{
				IList clear = new ArrayList(); 
				foreach (ReadOnlyClone clone in ReadOnlyObjectCache.ObjectCache)
				{
					if (clone.Type == typeName)
						clear.Add(clone);
				}
				foreach (ReadOnlyClone clone in clear)
				{
					ReadOnlyObjectCache.ObjectCache.Remove(clone);
				}
				ReadOnlyObjectCache.ObjectCache.Clear() ;
			}			
		}

		#endregion

		#region Serialization

		public virtual void Serialize(object obj)
		{
			string id = this.Context.ObjectManager.GetObjectIdentity(obj);
			string key = GetKey(obj, id);

			lock (ReadOnlyObjectCache) 
			{
				ReadOnlyClone clone = (ReadOnlyClone) ReadOnlyObjectCache.ObjectCache[key];
				if (clone == null)
				{
					clone = new ReadOnlyClone() ;
					ReadOnlyObjectCache.ObjectCache[key] = clone;
				}
				SerializeClone(obj, clone, id, key);
			}
		}

		public virtual void Deserialize(object obj)
		{
			string id = this.Context.ObjectManager.GetObjectIdentity(obj);
			string key = GetKey(obj, id);

			lock (ReadOnlyObjectCache) 
			{
				ReadOnlyClone clone = (ReadOnlyClone) ReadOnlyObjectCache.ObjectCache[key];
				if (clone == null)
					throw new ObjectNotFoundException("Could not find object with identity " + id + " and of type " + obj.GetType() + " in read-only cache!");
				DeserializeClone(obj, clone);
				clone.IncUseCount();
			}
		}

		protected virtual void SerializeClone(object obj, ReadOnlyClone clone, string id, string key)
		{
			IObjectManager om = this.Context.ObjectManager ;
			IDomainMap dm = this.Context.DomainMap;
			IAssemblyManager am = this.Context.AssemblyManager;
			IClassMap classMap = dm.MustGetClassMap(obj.GetType() );
			IListManager lm = this.Context.ListManager ;
			clone.Identity = id;
			clone.Key = key;
			clone.Type = classMap.GetFullName();
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					if (propertyMap.IsCollection)
					{
						IList values = new ArrayList()  ;
						IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name);

						foreach (object value in list)
							values.Add(value);

						clone.PropertyValues[propertyMap.Name] = values;
						clone.NullValueStatuses[propertyMap.Name] = false;
					}
					else
					{
						object value = om.GetPropertyValue(obj, propertyMap.Name);
						clone.PropertyValues[propertyMap.Name] = value;
						clone.NullValueStatuses[propertyMap.Name] = om.GetNullValueStatus(obj, propertyMap.Name);
					}
				}
				else
				{
					IClassMap refClassMap = propertyMap.MustGetReferencedClassMap() ;
					if (refClassMap.IsReadOnly)
					{
						if (propertyMap.IsCollection)
						{
							IList values = new ArrayList() ;
							IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name);

							foreach (object value in list)
							{
								if (value != null)
								{
									refClassMap = dm.MustGetClassMap(value.GetType() );
									string refIdentity = om.GetObjectIdentity(value);
									SerializedReference refId = new SerializedReference(refIdentity, refClassMap.GetFullName()) ;
									values.Add(refId);	
								}								
							}
							clone.PropertyValues[propertyMap.Name] = values;
							clone.NullValueStatuses[propertyMap.Name] = false;
						}
						else
						{
							object value = om.GetPropertyValue(obj, propertyMap.Name) ;
							if (value != null)
							{
								refClassMap = dm.MustGetClassMap(value.GetType() );
								string refIdentity = om.GetObjectIdentity(value);
								SerializedReference refId = new SerializedReference(refIdentity, refClassMap.GetFullName()) ;
								value = refId;
							}
							clone.PropertyValues[propertyMap.Name] = value;
							clone.NullValueStatuses[propertyMap.Name] = om.GetNullValueStatus(obj, propertyMap.Name);
						}						
					}
				}
			}
		}


		protected virtual void DeserializeClone(object obj, ReadOnlyClone clone)
		{
			IObjectManager om = this.Context.ObjectManager ;
			IDomainMap dm = this.Context.DomainMap;
			IAssemblyManager am = this.Context.AssemblyManager;
			IClassMap classMap = dm.MustGetClassMap(obj.GetType() );
			IListManager lm = this.Context.ListManager ;
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					if (propertyMap.IsCollection)
					{
						IList values = (IList) clone.PropertyValues[propertyMap.Name];
						IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name);

						bool stackMute = false;
						IInterceptableList mList = list as IInterceptableList;					
						if (mList != null)
						{
							stackMute = mList.MuteNotify;
							mList.MuteNotify = true;
						}
						list.Clear() ;

						foreach (object value in values)
							list.Add(value);	

						IList cloneList = new ArrayList( list);

						if (mList != null) { mList.MuteNotify = stackMute; }

						om.SetOriginalPropertyValue(obj, propertyMap.Name, cloneList);
						om.SetNullValueStatus(obj, propertyMap.Name, false);
					}
					else
					{
						object value = clone.PropertyValues[propertyMap.Name];
						om.SetPropertyValue(obj, propertyMap.Name, value);
						om.SetOriginalPropertyValue(obj, propertyMap.Name, value);
						om.SetNullValueStatus(obj, propertyMap.Name, (bool) clone.NullValueStatuses[propertyMap.Name]);
					}
				}
				else
				{
					IClassMap refClassMap = propertyMap.MustGetReferencedClassMap() ;
					if (refClassMap.IsReadOnly)
					{
						if (propertyMap.IsCollection)
						{
							IList values = (IList) clone.PropertyValues[propertyMap.Name];
							IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name);

							bool stackMute = false;
							IInterceptableList mList = list as IInterceptableList;
							if (mList != null)
							{
								stackMute = mList.MuteNotify;
								mList.MuteNotify = true;
							}
							list.Clear() ;

							foreach (SerializedReference refId in values)
							{
								object value = null;
								if (refId != null)
								{
									refClassMap = dm.MustGetClassMap(refId.Type);
									Type refType = am.GetTypeFromClassMap(refClassMap);
									value = this.Context.GetObjectById(refId.Identity, refType, true);
									list.Add(value);	
								}								
							}

							IList cloneList = new ArrayList( list);

							if (mList != null) { mList.MuteNotify = stackMute; }

							om.SetOriginalPropertyValue(obj, propertyMap.Name, cloneList);
							om.SetNullValueStatus(obj, propertyMap.Name, false);							
						}
						else
						{
							object value = null;
							SerializedReference refId = (SerializedReference) clone.PropertyValues[propertyMap.Name];
							if (refId != null)
							{
								refClassMap = dm.MustGetClassMap(refId.Type);
								Type refType = am.GetTypeFromClassMap(refClassMap);
								value = this.Context.GetObjectById(refId.Identity, refType, true);
							}
							om.SetPropertyValue(obj, propertyMap.Name, value);
							om.SetOriginalPropertyValue(obj, propertyMap.Name, value);
							om.SetNullValueStatus(obj, propertyMap.Name, (bool) clone.NullValueStatuses[propertyMap.Name]);
						}						
					}
				}
			}
		}

		#endregion

		#region CleanUp

		protected virtual void CleanUp()
		{
			long maxSize = this.MaxSize ;
			if (maxSize < 0)
				return;

			if (ReadOnlyObjectCache.ObjectCache.Count > maxSize)
			{
				UnloadAllExpired(ReadOnlyObjectCache.ObjectCache.Count - maxSize);
			}

			if (ReadOnlyObjectCache.ObjectCache.Count > maxSize)
			{
				//UnloadLeastUsed();
			}
		}


		#endregion

		#region Unloading

		protected virtual void UnloadAllExpired()
		{
			UnloadAllExpired(0);
		}

		protected virtual void UnloadAllExpired(long max)
		{
			long cntUnloaded = 0;
			foreach (ReadOnlyClone clone in ReadOnlyObjectCache.ObjectCache.Values)
			{
				ReadOnlyClone check = UnloadIfExpired(clone);
				if (check == null)
				{
					cntUnloaded++;
					if (max > 0)
					{
						if (cntUnloaded == max)
						{
							return;
						}						
					}
				}
			}		
		}

		protected virtual ReadOnlyClone UnloadIfExpired(ReadOnlyClone clone)
		{
			if (IsExpired(clone))
			{
				UnloadClone(clone);
				return null;
			}
			return clone;
		}

		private void UnloadClone(ReadOnlyClone clone)
		{
			string key = clone.Key;
			ReadOnlyObjectCache.ObjectCache.Remove(key);				
		}

		protected virtual bool IsExpired(ReadOnlyClone clone)
		{
			IObjectManager om = this.Context.ObjectManager;
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(clone.Type);
			TimeToLiveBehavior ttlBehavior = om.GetTimeToLiveBehavior(classMap);
			if (ttlBehavior == TimeToLiveBehavior.Default || ttlBehavior == TimeToLiveBehavior.On)
			{
				long ttl = om.GetTimeToLive(classMap);
				if (ttl > 0)
				{
					if (clone.LoadedTime.AddSeconds(ttl) < DateTime.Now)
						return true;									
				}
			}
			return false;
		}

		#endregion

		protected virtual string GetKey(object obj, string identity)
		{
			if (obj == null)
				throw new NullReferenceException("Can't create key for null object!"); // do not localize

			Type type = AssemblyManager.GetBaseType(obj);
			return type.ToString() + "." + identity;
			//			return obj.GetType().ToString() + "." + identity;
		}
	}
}
