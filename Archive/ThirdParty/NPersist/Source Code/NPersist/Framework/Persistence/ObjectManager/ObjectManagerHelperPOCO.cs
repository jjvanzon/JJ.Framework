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
//using System;
//using System.Collections;
//using System.Globalization;
//using System.Reflection;
//using Puzzle.NPersist.Framework.Enumerations;
//using Puzzle.NPersist.Framework.Mapping;
//using Puzzle.NPersist.Framework.Utility;
//using Puzzle.NCore.Framework.Collections;
//using Puzzle.NPersist.Framework.Interfaces;
//using Puzzle.NAspect.Framework;
//using Puzzle.NPersist.Framework.Exceptions;
//
//namespace Puzzle.NPersist.Framework.Persistence
//{
//    public class ObjectManagerHelperPOCO
//    {
//        private IObjectManager m_ObjectManager;
//        private Hashtable m_hashTempIds = new Hashtable();
//
//        public virtual IObjectManager ObjectManager
//        {
//            get { return m_ObjectManager; }
//            set { m_ObjectManager = value; }
//        }
//
//        //[DebuggerStepThrough()]
//        public virtual object GetPropertyValue(object obj, string propertyName)
//        {
//            return GetPropertyValue(obj, obj.GetType(), propertyName);
//        }
//
//        //[DebuggerStepThrough()]
//        public virtual object GetPropertyValue(object obj, Type type, string propertyName)
//        {
//       //     IPropertyMap propertyMap = m_ObjectManager.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
//
//       //     FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(propertyMap, type, propertyName);
//
//#if NET2
//            FastFieldGetter getter = GetFastGetter(obj, propertyName);
//            return getter(obj);
//#else
//            FieldInfo fieldInfo = (FieldInfo)propertyLookup[obj.GetType().Name +"."+ propertyName];
//            if (fieldInfo == null)
//            {
//                fieldInfo = GetFieldInfo(obj, propertyName);
//            }
//
//            return fieldInfo.GetValue(obj);
//#endif
//        }
//
//        public virtual void SetPropertyValue(object obj, string propertyName, object value)
//        {
//            try
//            {
//                SetPropertyValue(obj, obj.GetType(), propertyName, value);
//            }
//            catch(Exception x)
//            {
//                string message = string.Format("Failed to set property {0} to value {1} on object {2}.{3}", propertyName, value == null ? "null" : value,AssemblyManager.GetBaseType (obj).Name, this.ObjectManager.GetObjectKeyOrIdentity(obj));
//                throw new LoadException(message, x,obj);
//            }
//        }
//
//        private Hashtable propertyLookup = new Hashtable();
//        private FieldInfo GetFieldInfo(object obj, string propertyName)
//        {
//            IPropertyMap propertyMap = m_ObjectManager.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
//            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(propertyMap, obj.GetType (), propertyName);
//            if (fieldInfo == null)
//                throw new MappingException("Could not find a field with the name '" + propertyMap.GetFieldName() + "' in class " + obj.GetType().Name);
//            propertyLookup[obj.GetType().Name + "." + propertyName] = fieldInfo;
//            return fieldInfo;
//        }
//
//#if NET2
//        private Hashtable fastFieldGetterLookup = new Hashtable();
//        private Hashtable fastFieldSetterLookup = new Hashtable();
//        private FastFieldGetter GetFastGetter(object obj, string propertyName)
//        {
//            string key = obj.GetType().Name + "." + propertyName;
//            FastFieldGetter res = (FastFieldGetter)fastFieldGetterLookup[key];
//            if (res == null)
//            {
//                FieldInfo fieldInfo = GetFieldInfo(obj, propertyName);
//                res = FastFieldAccess.GetFieldGetter(fieldInfo);
//                fastFieldGetterLookup[key] = res;
//            }
//
//            return res;
//        }
//#endif
//
//        
//        public virtual void SetPropertyValue(object obj, Type type, string propertyName, object value)
//        {
//#if NET2
//            if (value == null)
//            {
//                SetPropertyValueReflection(obj, propertyName, value);
//            }
//            else
//            {
//                string key = obj.GetType().Name + "." + propertyName;
//                FastFieldSetter setter = (FastFieldSetter)fastFieldSetterLookup[key];
//                if (setter == null)
//                {
//                    FieldInfo fieldInfo = GetFieldInfo(obj, propertyName);
//                    setter = FastFieldAccess.GetFieldSetter(fieldInfo);
//                    fastFieldSetterLookup[key] = setter;
//                }
//
//                setter(obj, value);
//            }
//#else
//            SetPropertyValueReflection(obj, propertyName, value);  
//#endif
//        }
//
//        private void SetPropertyValueReflection(object obj, string propertyName, object value)
//        {
//            FieldInfo fieldInfo = (FieldInfo)propertyLookup[obj.GetType().Name + "." + propertyName];
//            if (fieldInfo == null)
//            {
//                fieldInfo = GetFieldInfo(obj, propertyName);
//            }
//            if (fieldInfo.FieldType.IsEnum)
//            {
//                if (value != null)
//                {
//                    fieldInfo.SetValue(obj, Enum.ToObject(fieldInfo.FieldType, value));
//                    return;
//                }
//            }
//            fieldInfo.SetValue(obj, value);
//        }
//
//        public virtual PropertyStatus GetPropertyStatus(object obj, string propertyName)
//        {
//            ObjectStatus objStatus = m_ObjectManager.GetObjectStatus(obj);
//            if (objStatus == ObjectStatus.UpForCreation)
//            {
//                return PropertyStatus.Dirty;
//
//            }
//            if (objStatus == ObjectStatus.Deleted)
//            {
//                return PropertyStatus.Deleted;
//            }
//            if (m_ObjectManager.IsDirtyProperty(obj, propertyName))
//            {
//                return PropertyStatus.Dirty;
//            }
//            if (m_ObjectManager.HasOriginalValues(obj, propertyName))
//            {
//                return PropertyStatus.Clean;
//            }
//            return PropertyStatus.NotLoaded;
//        }
//
//        public virtual bool IsDirtyProperty(object obj, string propertyName)
//        {				
//			if (!this.ObjectManager.GetUpdatedStatus(obj, propertyName))
//				return false;
//
//			if (!(m_ObjectManager.HasOriginalValues(obj, propertyName)))
//				return false;
//
//            object orgValue = m_ObjectManager.GetOriginalPropertyValue(obj, propertyName);
//            if (Convert.IsDBNull(orgValue))
//            {
//                if (m_ObjectManager.GetNullValueStatus(obj, propertyName))
//					return false;
//				else
//					return true;
//			}
//            else
//            {
//                if (m_ObjectManager.GetNullValueStatus(obj, propertyName))
//					return true;
//			}
//
//			object value = m_ObjectManager.GetPropertyValue(obj, propertyName);
//			if (!(ComparePropertyValues(obj, propertyName, value, orgValue)))
//			{
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
//
////		public virtual bool IsDirtyProperty(object obj, string propertyName)
////		{
////			if (!(m_ObjectManager.HasOriginalValues(obj, propertyName)))
////			{
////				return false;
////			}
////			object orgValue = m_ObjectManager.GetOriginalPropertyValue(obj, propertyName);
////			if (Convert.IsDBNull(orgValue))
////			{
////				if (!(m_ObjectManager.GetNullValueStatus(obj, propertyName)))
////				{
////					return true;
////				}
////				else
////				{
////					return false;
////				}
////			}
////			else
////			{
////				if (m_ObjectManager.GetNullValueStatus(obj, propertyName))
////				{
////					return true;
////				}
////			}
////			if (this.ObjectManager.GetUpdatedStatus(obj, propertyName))
////			{
////				object value = m_ObjectManager.GetPropertyValue(obj, propertyName);
////				if (!(ComparePropertyValues(obj, propertyName, value, orgValue)))
////				{
////					return true;
////				}
////				else
////				{
////					return false;
////				}
////			}
////			else
////			{
////				return false;
////			}
////		}
//
//        public virtual bool ComparePropertyValues(object obj, string propertyName, object value1, object value2)
//        {
//            IPropertyMap propertyMap = m_ObjectManager.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
//            Array arr1;
//            Array arr2;
//            if (propertyMap.IsCollection)
//            {
//                return this.m_ObjectManager.Context.ListManager.CompareLists((IList)value1, (IList)value2);
//            }
//            else
//            {
//                if (!(propertyMap.ReferenceType == ReferenceType.None))
//                {
//                    if (value1 == value2)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                else
//                {
//                    if (Util.IsArray(value1) || Util.IsArray(value2))
//                    {
//                        if (!((Util.IsArray(value1) && Util.IsArray(value2))))
//                        {
//                            return false;
//                        }
//                    }
//                    if (Util.IsArray(value1) && Util.IsArray(value2))
//                    {
//                        if (((Array)(value1)).Length == ((Array)(value2)).Length)
//                        {
//                            arr1 = ((Array)(value1));
//                            arr2 = ((Array)(value2));
//                            if (!(CompareArrays(arr1, arr2)))
//                            {
//                                return false;
//                            }
//                        }
//                        else
//                        {
//                            return false;
//                        }
//                    }
//                    else
//                    {
//                        string lowTypeName = propertyMap.DataType.ToLower(CultureInfo.InvariantCulture);
//                        if (lowTypeName == "guid" || lowTypeName == "system.guid")
//                        {
//                            if (((Guid)(value1)).Equals(value2))
//                            {
//                                return true;
//                            }
//                            else
//                            {
//                                return false;
//                            }
//                        }
//                        else
//                        {
//                            if (value1 == null || value2 == null)
//                            {
//                                if (value1 == null && value2 == null)
//                                {
//                                    return true;
//                                }
//                                else
//                                {
//                                    return false;
//                                }
//                            }
//                            else
//                            {
//                                if (value1.Equals(value2))
//                                {
//                                    return true;
//                                }
//                                else
//                                {
//                                    return false;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            return true;
//        }
//
//        protected virtual bool CompareArrays(Array arr1, Array arr2)
//        {
//            object value1;
//            object value2;
//            for (int i = 0; i <= arr1.GetUpperBound(0); i++)
//            {
//                value1 = arr1.GetValue(i);
//                value2 = arr2.GetValue(i);
//                if (value1 == null || value2 == null)
//                {
//                    if (!(value1 == null && value2 == null))
//                    {
//                        return false;
//                    }
//                }
//                else
//                {
//                    if (!(value1.Equals(value2)))
//                    {
//                        return false;
//                    }
//                }
//            }
//            return true;
//        }
//
//
//        public virtual object ConvertValueToType(object obj, IPropertyMap propertyMap, string value)
//        {
//            return ConvertValueToType(obj.GetType(), propertyMap, value);
//        }
//
//        public virtual object ConvertValueToType(Type type, IPropertyMap propertyMap, string value)
//        {
//            Type propType = type.GetProperty(propertyMap.Name).PropertyType;
//            if (propType == typeof(Boolean) || propType.IsSubclassOf(typeof(Boolean)))
//            {
//                return Convert.ToBoolean(value);
//            }
//            else if (propType == typeof(Byte) || propType.IsSubclassOf(typeof(Byte)))
//            {
//                return Convert.ToByte(value);
//            }
//            else if (propType == typeof(Char) || propType.IsSubclassOf(typeof(Char)))
//            {
//                return Convert.ToChar(value);
//            }
//            else if (propType == typeof(DateTime) || propType.IsSubclassOf(typeof(DateTime)))
//            {
//                return Convert.ToDateTime(value);
//            }
//            else if (propType == typeof(Decimal) || propType.IsSubclassOf(typeof(Decimal)))
//            {
//                return Convert.ToDecimal(value);
//            }
//            else if (propType == typeof(Double) || propType.IsSubclassOf(typeof(Double)))
//            {
//                return Convert.ToDouble(value);
//            }
//            else if (propType == typeof(Guid) || propType.IsSubclassOf(typeof(Guid)))
//            {
//                return new Guid(value);
//            }
//            else if (propType == typeof(Int16) || propType.IsSubclassOf(typeof(Int16)))
//            {
//                return Convert.ToInt16(value);
//            }
//            else if (propType == typeof(Int32) || propType.IsSubclassOf(typeof(Int32)))
//            {
//                return Convert.ToInt32(value);
//            }
//            else if (propType == typeof(Int64) || propType.IsSubclassOf(typeof(Int64)))
//            {
//                return Convert.ToInt64(value);
//            }
//            else if (propType == typeof(SByte) || propType.IsSubclassOf(typeof(SByte)))
//            {
//                return Convert.ToByte(value);
//            }
//            else if (propType == typeof(Single) || propType.IsSubclassOf(typeof(Single)))
//            {
//                return Convert.ToSingle(value);
//            }
//            else if (propType == typeof(String) || propType.IsSubclassOf(typeof(String)))
//            {
//                return Convert.ToString(value);
//            }
//            else if (propType == typeof(ushort) || propType.IsSubclassOf(typeof(ushort)))
//            {
//                return UInt16.Parse(value);
//            }
//            else if (propType == typeof(uint) || propType.IsSubclassOf(typeof(uint)))
//            {
//                return UInt32.Parse(value);
//            }
//            else if (propType == typeof(ulong) || propType.IsSubclassOf(typeof(ulong)))
//            {
//                return UInt64.Parse(value);
//            }
//            else if (propType == typeof(object) || propType.IsSubclassOf(typeof(object)))
//            {
//                return value;
//            }
//            else
//            {
//                return value;
//            }
//        }
//
//    }
//}
