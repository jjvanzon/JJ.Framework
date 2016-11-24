//// *
//// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
//// *
//// * This library is free software; you can redistribute it and/or modify it
//// * under the terms of the GNU Lesser General Public License 2.1 or later, as
//// * published by the Free Software Foundation. See the included license.txt
//// * or http://www.gnu.org/copyleft/lesser.html for details.
//// *
//// *
//
//using System.Collections;
//using Puzzle.NPersist.Framework.BaseClasses;
//using Puzzle.NPersist.Framework.Exceptions;
//using Puzzle.NPersist.Framework.Mapping;
//
//namespace Puzzle.NPersist.Framework.Persistence
//{
//	public class DataManager : ContextChild, IDataManager
//	{
//		private Hashtable m_hashOriginalValues = new Hashtable();
//		private Hashtable m_hashNullValues = new Hashtable();
//		private Hashtable m_hashUpdated = new Hashtable();
//
//		public virtual object GetOriginalPropertyValue(object obj, string propertyName)
//		{
//			Hashtable result = (Hashtable) m_hashOriginalValues[obj];
//			if (result == null)
//				throw new NPersistException("Original values for object have not been registered!"); // do not localize
//			object result2 = result[propertyName];
//			if (result2 == null)
//				throw new NPersistException("Original values for property '" + propertyName + "' of object have not been registered!"); // do not localize
//			return result2;
//		}
//
//		public virtual void SetOriginalPropertyValue(object obj, string propertyName, object value)
//		{
//			Hashtable result = (Hashtable) m_hashOriginalValues[obj];
//			if (result == null)
//			{
//				result = new Hashtable();
//				m_hashOriginalValues[obj] = result;
//			}
//			result[propertyName] = value;
//		}
//
//		public virtual bool HasOriginalValues(object obj)
//		{
//			Hashtable result = (Hashtable) m_hashOriginalValues[obj];
//			if (result == null)
//			{
//				return false;
//			}
//			return true;
//		}
//
//		public virtual bool HasOriginalValues(object obj, string propertyName)
//		{
//			Hashtable result = (Hashtable) m_hashOriginalValues[obj];
//			if (result == null)
//			{
//				return false;
//			}
//			object result2 = result[propertyName];
//			if (result2 == null)
//			{
//				return false;
//			}
//			return true;
//		}
//
//		public virtual void RemoveOriginalValues(object obj, string propertyName)
//		{
//			Hashtable result = (Hashtable) m_hashOriginalValues[obj];
//			if (result == null)
//			{
//				return;
//			}
//			result[propertyName] = null;
//		}
//
//		public virtual bool GetNullValueStatus(object obj, string propertyName)
//		{
//			Hashtable result = (Hashtable) m_hashNullValues[obj];
//			if (result == null)
//			{
//				return false;
//			}
//			object result2 = result[propertyName];
//			if (result2 == null)
//			{
//				return false;
//			}
//			return true;
//		}
//
//		public virtual void SetNullValueStatus(object obj, string propertyName, bool value)
//		{
//			if (!(value))
//			{
//				Hashtable result = (Hashtable) m_hashNullValues[obj];
//				if (result == null)
//				{
//					return;
//				}
//				result[propertyName] = null;
////				object result2 = result[propertyName];
////				if (result2 == null)
////				{
////					return;
////				}
//				if (result.Count < 1)
//				{
//					m_hashNullValues[obj] = null;
//				}
//			}
//			else
//			{
//				Hashtable result = (Hashtable) m_hashNullValues[obj];
//				if (result == null)
//				{
//					result = new Hashtable() ;
//					m_hashNullValues[obj] = result;
//				}
//				result[propertyName] = true;
//			}
//		}
//
//		public virtual void SetNullValueStatus(object obj, bool value)
//		{
//			IDomainMap domainMap = this.Context.DomainMap;
//			IClassMap classMap = domainMap.GetClassMap(obj.GetType());
//			if (classMap != null)
//			{
//				foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
//				{
//					if (!(propertyMap.IsIdentity))
//					{
//						if (!(propertyMap.IsCollection))
//						{
//							SetNullValueStatus(obj, propertyMap.Name, value);
//						}
//					}
//				}
//			}
//		}
//
//		public virtual bool GetUpdatedStatus(object obj, string propertyName)
//		{
//			Hashtable result = (Hashtable) m_hashUpdated[obj];
//			if (result == null)
//			{
//				return false;
//			}
//			object result2 = result[propertyName];
//			if (result2 == null)
//			{
//				return false;
//			}
//			return true;
//		}
//
////		public virtual void SetUpdatedStatus(object obj, string propertyName, bool value)
////		{
////			if (!(value))
////			{
////				if (!(m_hashUpdated.ContainsKey(obj)))
////				{
////					return;
////				}
////				if (!(((Hashtable) (m_hashUpdated[obj])).ContainsKey(propertyName)))
////				{
////					return;
////				}
////				((Hashtable) (m_hashUpdated[obj])).Remove(propertyName);
////				if (((Hashtable) (m_hashUpdated[obj])).Count < 1)
////				{
////					m_hashUpdated.Remove(obj);
////				}
////			}
////			else
////			{
////				if (!(m_hashUpdated.ContainsKey(obj)))
////				{
////					m_hashUpdated[obj] = new Hashtable();
////				}
////				((Hashtable) (m_hashUpdated[obj]))[propertyName] = true;
////			}
////		}
//
//		
//		public virtual void SetUpdatedStatus(object obj, string propertyName, bool value)
//		{
//			if (!(value))
//			{
//				Hashtable result = (Hashtable) m_hashUpdated[obj];
//				if (result == null)
//				{
//					return;
//				}
//				result[propertyName] = null;
//				if (result.Count < 1)
//				{
//					m_hashUpdated[obj] = null;
//				}
//			}
//			else
//			{
//				Hashtable result = (Hashtable) m_hashUpdated[obj];
//				if (result == null)
//				{
//					result = new Hashtable() ;
//					m_hashUpdated[obj] = result;
//				}
//				result[propertyName] = true;
//			}
//		}
//
//		public virtual void ClearUpdatedStatuses(object obj)
//		{
//			IDomainMap domainMap = this.Context.DomainMap;
//			IClassMap classMap = domainMap.GetClassMap(obj.GetType());
//			if (classMap != null)
//			{
//				foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
//				{
//					SetUpdatedStatus(obj, propertyMap.Name, false);
//				}
//			}
//		}
//	
//	}
//}