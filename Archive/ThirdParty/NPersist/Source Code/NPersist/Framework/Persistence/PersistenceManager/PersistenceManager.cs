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
using System.Text;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Utility;
using System.Reflection;
using Puzzle.NCore.Framework.Logging;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class PersistenceManager : ContextChild, IPersistenceManager
	{
		private MergeBehaviorType m_MergeBehavior = MergeBehaviorType.DefaultBehavior;
		private RefreshBehaviorType m_RefreshBehavior = RefreshBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_DeleteOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;

		public virtual object GetObject(object identity, Type type, bool lazy) => this.Context.IdentityMap.GetObject(identity, type, lazy);

	    public virtual object GetObject(object identity, Type type, bool lazy, bool ignoreObjectNotFound) => this.Context.IdentityMap.GetObject(identity, type, lazy, ignoreObjectNotFound);

	    public virtual object GetObjectByKey(string keyPropertyName, object keyValue, Type type) => this.Context.IdentityMap.GetObjectByKey(keyPropertyName, keyValue, type);

	    public virtual object GetObjectByKey(string keyPropertyName, object keyValue, Type type, bool ignoreObjectNotFound) => this.Context.IdentityMap.GetObjectByKey(keyPropertyName, keyValue, type, ignoreObjectNotFound);

	    public void LoadProperty(object obj, string propertyName)
		{
			ObjectStatus objStatus = this.Context.ObjectManager.GetObjectStatus(obj);
			IPropertyMap propertyMap;
			if (objStatus == ObjectStatus.Deleted)
			{
				if (obj is IObjectHelper)
				{
					throw new DeletedObjectException("The object has been deleted!", obj, propertyName); // do not localize
				}
			}
			else if (objStatus == ObjectStatus.NotLoaded)
			{
				propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
				if (!(propertyMap.IsIdentity))
				{
					//this.Context.SqlEngineManager.LoadObject(obj);
					this.Context.PersistenceEngine.LoadObject(ref obj);
					if (obj == null)
					{
						throw new ObjectNotFoundException("Object not found!"); // do not localize
					}
				}
			}
			PropertyStatus propStatus = this.Context.ObjectManager.GetPropertyStatus(obj, propertyName);
			if (propStatus == PropertyStatus.Deleted)
			{
				if (obj is IObjectHelper)
				{
					throw new DeletedObjectException("The object has been deleted!", obj, propertyName); // do not localize
				}
			}
			else if (propStatus == PropertyStatus.NotLoaded)
			{
				if (!(objStatus == ObjectStatus.UpForCreation))
				{
					//this.Context.SqlEngineManager.LoadProperty(obj, propertyName);
					this.Context.PersistenceEngine.LoadProperty(obj, propertyName);
				}
			}
		}


		public virtual void CreateObject(object obj)
		{
			this.Context.UnitOfWork.RegisterCreated(obj);
			CascadeCreate(obj);
		}

		public virtual void CommitObject(object obj, int exceptionLimit) => this.Context.UnitOfWork.CommitObject(obj, exceptionLimit);

	    public virtual void DeleteObject(object obj)
		{
			CascadeDelete(obj);
			this.Context.InverseManager.RemoveAllReferencesToObject(obj);
			this.Context.UnitOfWork.RegisterDeleted(obj);
		}

		public virtual void Commit(int exceptionLimit)
		{
			this.Context.UnitOfWork.Commit(exceptionLimit);
			this.Context.SqlExecutor.ExecuteBatchedStatements();
		}


		public virtual object ManageLoadedValue(object obj, IPropertyMap propertyMap, object value) => ManageLoadedValue(obj, propertyMap, value, null);

	    public virtual object ManageLoadedValue(object obj, IPropertyMap propertyMap, object value, object discriminator)
		{
            try
            {
				if (propertyMap.IsCollection)
				{
					return ManageListCountValue(obj, propertyMap, value);
				}
				else
				{
					object managedValue;
					managedValue = ManageNullValue(obj, propertyMap, value);
					managedValue = ManageReferenceValue(obj, propertyMap, managedValue, discriminator);
					return managedValue;
				}
            }
            catch (Exception x)
            {
                string message = string.Format("Could not load value for property '{0}' on object {1}.{2}", propertyMap.Name, AssemblyManager.GetBaseType(obj).Name, this.Context.ObjectManager.GetObjectKeyOrIdentity(obj));
                throw new LoadException(message, x, obj);
            }
		}

		public virtual object ManageListCountValue(object obj, IPropertyMap propertyMap, object value)
		{
			if (value == null)
				return value;

			ITransaction tx = null;

			ConsistencyMode readConsistency = this.Context.ReadConsistency;
			if (readConsistency == ConsistencyMode.Pessimistic)
			{
				ISourceMap sourceMap = propertyMap.ClassMap.GetSourceMap();
				if (sourceMap != null)
				{
					if (sourceMap.PersistenceType.Equals(PersistenceType.ObjectRelational) || sourceMap.PersistenceType.Equals(PersistenceType.Default))
					{
						tx = this.Context.GetTransaction(this.Context.GetDataSource().GetConnection());
						if (tx == null)
							return value;
					}
				}
			}

			IInverseHelper inverseHelper = obj as IInverseHelper;
			if (inverseHelper == null)
				return value;

			IObjectManager om = this.Context.ObjectManager;
			PropertyStatus propStatus = om.GetPropertyStatus(obj, propertyMap.Name);
			if (!propStatus.Equals(PropertyStatus.NotLoaded))
				return value;

			if (inverseHelper.HasCount(propertyMap.Name, tx))
				return value;

			inverseHelper.SetCount(propertyMap.Name, (int) value, tx);

			inverseHelper.CheckPartiallyLoadedList(propertyMap.Name, tx);

			return value;
		}

		public virtual object ManageReferenceValue(object obj, string propertyName, object value) => ManageReferenceValue(obj, propertyName, value, null);

	    public virtual object ManageReferenceValue(object obj, string propertyName, object value, object discriminator) => ManageReferenceValue(obj, this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName), value, discriminator);

	    public virtual object ManageReferenceValue(object obj, IPropertyMap propertyMap, object value) => ManageReferenceValue(obj, propertyMap, value, null);

	    //if value is a list, values in list come in the same order as columns are returned from propertymap.refClassMap.GetIdentityCols! garantueed order !
		//type column value must have been extracted from list in advance and should be passed to discriminator param
		public virtual object ManageReferenceValue(object obj, IPropertyMap propertyMap, object value, object discriminator)
		{
			IClassMap refClassMap;
			IPropertyMap mapToId;
			if (!(propertyMap.ReferenceType == ReferenceType.None))
			{
				if (value != null)
				{
					refClassMap = propertyMap.MustGetReferencedClassMap();
					if (discriminator != null)
					{
						try
						{
							discriminator = discriminator.ToString() ;
						} 
						catch { discriminator = ""; }						
						refClassMap = refClassMap.GetSubClassWithTypeValue((string) discriminator);
						if (refClassMap == null)
							throw new NPersistException("Could not find class map with type value '" + (string) discriminator + "'");
					}
                    //TODO: bug if one slave prop in a subclass references another subclass in single table inheritance
                    IColumnMap propertyColumnMap = propertyMap.GetColumnMap();
                    IColumnMap inverseColumnMap = propertyColumnMap.MustGetPrimaryKeyColumnMap();
                    mapToId = refClassMap.MustGetPropertyMapForColumnMap(inverseColumnMap);

					if (mapToId.IsIdentity)
						value = this.Context.GetObjectById(value, this.Context.AssemblyManager.MustGetTypeFromClassMap(refClassMap), true);
					else
						value = this.Context.GetObjectByKey(mapToId.Name, Convert.ToString(value), obj.GetType().GetProperty(propertyMap.Name).PropertyType);
				}
			}
			return value;
		}

		public virtual object ManageNullValue(object obj, IPropertyMap propertyMap, object value)
		{
			if (propertyMap != null)
			{
				if (Convert.IsDBNull(value))
				{
					//The ManageLoadedValue method should be side-effect free....otherwise we
					//risk overwriting dirty objects with incorrect nullvalue statuses
					//this.Context.ObjectManager.SetNullValueStatus(obj, propertyMap.Name, true);
					if (!(propertyMap.ReferenceType == ReferenceType.None))
					{
						return null;
					}
					else
					{
						if (propertyMap.NullSubstitute.Length > 0)
						{
                                                    Type propType = obj.GetType().GetProperty(propertyMap.Name).PropertyType;
                                                    if (propType.IsEnum)
                                                    {
                                                        return Enum.ToObject(propType, Convert.ToInt32(propertyMap.NullSubstitute));
                                                    }
                                                    else if (propType == typeof(Boolean) || propType.IsSubclassOf(typeof(Boolean)))
                                                    {
                                                        return Convert.ToBoolean(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Byte) || propType.IsSubclassOf(typeof(Byte)))
                                                    {
                                                        return Convert.ToByte(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Char) || propType.IsSubclassOf(typeof(Char)))
                                                    {
                                                        return Convert.ToChar(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(DateTime) || propType.IsSubclassOf(typeof(DateTime)))
                                                    {
                                                        return DateTime.Parse(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Decimal) || propType.IsSubclassOf(typeof(Decimal)))
                                                    {
                                                        return Convert.ToDecimal(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Double) || propType.IsSubclassOf(typeof(Double)))
                                                    {
                                                        return Convert.ToDouble(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Guid) || propType.IsSubclassOf(typeof(Guid)))
                                                    {
                                                        return new Guid(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Int16) || propType.IsSubclassOf(typeof(Int16)))
                                                    {
                                                        return Convert.ToInt16(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Int32) || propType.IsSubclassOf(typeof(Int32)))
                                                    {
                                                        return Convert.ToInt32(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Int64) || propType.IsSubclassOf(typeof(Int64)))
                                                    {
                                                        return Convert.ToInt64(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(object) || propType.IsSubclassOf(typeof(object)))
                                                    {
                                                        return propertyMap.NullSubstitute;
                                                    }
                                                    else if (propType == typeof(SByte) || propType.IsSubclassOf(typeof(SByte)))
                                                    {
                                                        return Convert.ToByte(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(Single) || propType.IsSubclassOf(typeof(Single)))
                                                    {
                                                        return Convert.ToSingle(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(String) || propType.IsSubclassOf(typeof(String)))
                                                    {
                                                        return propertyMap.NullSubstitute;
                                                    }
                                                    else if (propType == typeof(ushort) || propType.IsSubclassOf(typeof(ushort)))
                                                    {
                                                        return Convert.ToUInt16(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(uint) || propType.IsSubclassOf(typeof(uint)))
                                                    {
                                                        return Convert.ToUInt32(propertyMap.NullSubstitute);
                                                    }
                                                    else if (propType == typeof(ulong) || propType.IsSubclassOf(typeof(ulong)))
                                                    {
                                                        return Convert.ToUInt64(propertyMap.NullSubstitute);
                                                    }
                                                    return propertyMap.NullSubstitute;
						}
						else
						{
							Type propType = obj.GetType().GetProperty(propertyMap.Name).PropertyType;
							if (propType == typeof (Boolean) || propType.IsSubclassOf(typeof (Boolean)))
							{
								return false;
							}
							else if (propType == typeof (Byte) || propType.IsSubclassOf(typeof (Byte)))
							{
								return Convert.ToByte(0);
							}
							else if (propType == typeof (Char) || propType.IsSubclassOf(typeof (Char)))
							{
								return Convert.ToChar("");
							}
							else if (propType == typeof (DateTime) || propType.IsSubclassOf(typeof (DateTime)))
							{
								return null;
							}
							else if (propType == typeof (Decimal) || propType.IsSubclassOf(typeof (Decimal)))
							{
								return Convert.ToDecimal(0);
							}
							else if (propType == typeof (Double) || propType.IsSubclassOf(typeof (Double)))
							{
								return Convert.ToDouble(0);
							}
							else if (propType == typeof (Guid) || propType.IsSubclassOf(typeof (Guid)))
							{
								return Guid.Empty;
							}
							else if (propType == typeof (Int16) || propType.IsSubclassOf(typeof (Int16)))
							{
								return Convert.ToInt16(0);
							}
							else if (propType == typeof (Int32) || propType.IsSubclassOf(typeof (Int32)))
							{
								return Convert.ToInt32(0);
							}
							else if (propType == typeof (Int64) || propType.IsSubclassOf(typeof (Int64)))
							{
								return Convert.ToInt64(0);
							}
							else if (propType == typeof (object) || propType.IsSubclassOf(typeof (object)))
							{
								return null;
							}
							else if (propType == typeof (SByte) || propType.IsSubclassOf(typeof (SByte)))
							{
								return Convert.ToByte(0);
							}
							else if (propType == typeof (Single) || propType.IsSubclassOf(typeof (Single)))
							{
								return Convert.ToSingle(0);
							}
							else if (propType == typeof (String) || propType.IsSubclassOf(typeof (String)))
							{
								return "";
							}
							else if (propType == typeof (ushort) || propType.IsSubclassOf(typeof (ushort)))
							{
								return Convert.ToUInt16(0);
							}
							else if (propType == typeof (uint) || propType.IsSubclassOf(typeof (uint)))
							{
								return Convert.ToUInt32(0);
							}
							else if (propType == typeof (ulong) || propType.IsSubclassOf(typeof (ulong)))
							{
								return Convert.ToUInt64(0);
							}
						}
					}
				}
//				else
//				{
//					//The ManageLoadedValue method should be side-effect free....otherwise we
//					//risk overwriting dirty objects with incorrect nullvalue statuses
//					//this.Context.ObjectManager.SetNullValueStatus(obj, propertyMap.Name, false);
//				}					
			}

			return value;
		}



		protected virtual bool PropertyIsPartOfCompositeIdentityRelationship(IPropertyMap propertyMap)
		{
			if (propertyMap.ReferenceType != ReferenceType.None)
				if (propertyMap.GetAdditionalIdColumnMaps().Count > 0) 
					return true;
			return false;
		}

		public virtual MergeBehaviorType GetMergeBehavior(MergeBehaviorType mergeBehavior, IClassMap classMap, IPropertyMap propertyMap)
		{
			if (mergeBehavior == MergeBehaviorType.DefaultBehavior)
			{
				mergeBehavior = propertyMap.MergeBehavior;
				if (mergeBehavior == MergeBehaviorType.DefaultBehavior)
				{
					mergeBehavior = classMap.MergeBehavior;
					if (mergeBehavior == MergeBehaviorType.DefaultBehavior)
					{
						mergeBehavior = classMap.DomainMap.MergeBehavior;
						if (mergeBehavior == MergeBehaviorType.DefaultBehavior)
						{
							mergeBehavior = m_MergeBehavior;
							if (mergeBehavior == MergeBehaviorType.DefaultBehavior)
							{
								mergeBehavior = MergeBehaviorType.TryResolveConflicts;
							}
						}
					}
				}
			}
			return mergeBehavior;
		}

		public virtual RefreshBehaviorType GetRefreshBehavior(RefreshBehaviorType refreshBehavior, IClassMap classMap, IPropertyMap propertyMap)
		{
			if (refreshBehavior == RefreshBehaviorType.DefaultBehavior)
			{
				if (this.Context.OptimisticConcurrencyMode == OptimisticConcurrencyMode.Early)
				{
					refreshBehavior = RefreshBehaviorType.ThrowConcurrencyException ;					
				}
				else
				{
					refreshBehavior = propertyMap.RefreshBehavior;
					if (refreshBehavior == RefreshBehaviorType.DefaultBehavior)
					{
						refreshBehavior = classMap.RefreshBehavior;
						if (refreshBehavior == RefreshBehaviorType.DefaultBehavior)
						{
							refreshBehavior = classMap.DomainMap.RefreshBehavior;
							if (refreshBehavior == RefreshBehaviorType.DefaultBehavior)
							{
								refreshBehavior = m_RefreshBehavior;
								if (refreshBehavior == RefreshBehaviorType.DefaultBehavior)
								{
									refreshBehavior = RefreshBehaviorType.OverwriteNotLoaded;
								}
							}
						}
					}					
				}
			}
			return refreshBehavior;
		}

		public virtual OptimisticConcurrencyBehaviorType GetUpdateOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IClassMap classMap)
		{
			if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
			{
				if (this.Context.OptimisticConcurrencyMode == OptimisticConcurrencyMode.Disabled)
				{
					optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
				}
				else
				{
					optimisticConcurrencyBehavior = classMap.UpdateOptimisticConcurrencyBehavior;
					if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
					{
						optimisticConcurrencyBehavior = classMap.DomainMap.UpdateOptimisticConcurrencyBehavior;
						if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
						{
							optimisticConcurrencyBehavior = m_UpdateOptimisticConcurrencyBehavior;
							if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
							{
								optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenDirty;
							}
						}
					}					
				}
			}
			return optimisticConcurrencyBehavior;
		}

		public virtual OptimisticConcurrencyBehaviorType GetDeleteOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IClassMap classMap)
		{
			if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
			{
				if (this.Context.OptimisticConcurrencyMode == OptimisticConcurrencyMode.Disabled)
				{
					optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
				}
				else
				{
					optimisticConcurrencyBehavior = classMap.DeleteOptimisticConcurrencyBehavior;
					if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
					{
						optimisticConcurrencyBehavior = classMap.DomainMap.DeleteOptimisticConcurrencyBehavior;
						if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
						{
							optimisticConcurrencyBehavior = m_DeleteOptimisticConcurrencyBehavior;
							if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
							{
								optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenLoaded;
							}
						}
					}
					
				}
			}
			return optimisticConcurrencyBehavior;
		}

		public virtual OptimisticConcurrencyBehaviorType GetUpdateOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IPropertyMap propertyMap)
		{
			IColumnMap columnMap = null;
			if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
			{
				if (this.Context.OptimisticConcurrencyMode == OptimisticConcurrencyMode.Disabled)
				{
					optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
				}
				else
				{
					optimisticConcurrencyBehavior = propertyMap.UpdateOptimisticConcurrencyBehavior;
					if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
					{
						optimisticConcurrencyBehavior = propertyMap.ClassMap.UpdateOptimisticConcurrencyBehavior;
						if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
						{
							optimisticConcurrencyBehavior = propertyMap.ClassMap.DomainMap.UpdateOptimisticConcurrencyBehavior;
							if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
							{
								optimisticConcurrencyBehavior = m_UpdateOptimisticConcurrencyBehavior;
							}
						}
					}					
				}
			}
			if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
			{
				columnMap = propertyMap.GetColumnMap();
				if (columnMap != null)
				{
					if (columnMap.DataType == DbType.AnsiString || columnMap.DataType == DbType.AnsiStringFixedLength || columnMap.DataType == DbType.String || columnMap.DataType == DbType.StringFixedLength)
					{
						if (columnMap.Precision == 0 || columnMap.Precision >= 4000)
						{
							optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
						}
						else
						{
							optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenDirty;
						}
					}
					else if (columnMap.DataType == DbType.Binary || columnMap.DataType == DbType.Object)
					{
						optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
					}
					else
					{
						optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenDirty;
					}
				}
			}
			else
			{
				if (!(optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.Disabled))
				{
					if (propertyMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
					{
						columnMap = propertyMap.GetColumnMap();
						if (columnMap != null)
						{
							if (columnMap.DataType == DbType.AnsiString || columnMap.DataType == DbType.AnsiStringFixedLength || columnMap.DataType == DbType.String || columnMap.DataType == DbType.StringFixedLength)
							{
//								if (columnMap.Precision == 0 || columnMap.Precision >= 4000)
//								{
//									optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
//								}
							}
							else if (columnMap.DataType == DbType.Binary || columnMap.DataType == DbType.Object)
							{
								optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
							}
						}
					}
				}
			}
			if (columnMap == null)
			{
				columnMap = propertyMap.GetColumnMap();
			}
			if (columnMap != null)
			{
				if (columnMap.DataType == DbType.Binary || columnMap.DataType == DbType.Object)
				{
					optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
				}
			}
			return optimisticConcurrencyBehavior;
		}

		public virtual OptimisticConcurrencyBehaviorType GetDeleteOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IPropertyMap propertyMap)
		{
			IColumnMap columnMap = null;
			if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
			{
				if (this.Context.OptimisticConcurrencyMode == OptimisticConcurrencyMode.Disabled)
				{
					optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
				}
				else
				{
					optimisticConcurrencyBehavior = propertyMap.DeleteOptimisticConcurrencyBehavior;
					if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
					{
						optimisticConcurrencyBehavior = propertyMap.ClassMap.DeleteOptimisticConcurrencyBehavior;
						if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
						{
							optimisticConcurrencyBehavior = propertyMap.ClassMap.DomainMap.DeleteOptimisticConcurrencyBehavior;
							if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
							{
								optimisticConcurrencyBehavior = m_DeleteOptimisticConcurrencyBehavior;
							}
						}
					}					
				}
			}
			if (optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
			{
				columnMap = propertyMap.GetColumnMap();
				if (columnMap != null)
				{
					if (columnMap.DataType == DbType.AnsiString || columnMap.DataType == DbType.AnsiStringFixedLength || columnMap.DataType == DbType.String || columnMap.DataType == DbType.StringFixedLength)
					{
						if (columnMap.Precision == 0 || columnMap.Precision >= 4000)
						{
							optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
						}
						else
						{
							optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenLoaded;
						}
					}
					else if (columnMap.DataType == DbType.Binary || columnMap.DataType == DbType.Object)
					{
						optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
					}
					else
					{
						optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.IncludeWhenLoaded;
					}
				}
			}
			else
			{
				if (!(optimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.Disabled))
				{
					if (propertyMap.DeleteOptimisticConcurrencyBehavior == OptimisticConcurrencyBehaviorType.DefaultBehavior)
					{
						columnMap = propertyMap.GetColumnMap();
						if (columnMap != null)
						{
							if (columnMap.DataType == DbType.AnsiString || columnMap.DataType == DbType.AnsiStringFixedLength || columnMap.DataType == DbType.String || columnMap.DataType == DbType.StringFixedLength)
							{
								if (columnMap.Precision == 0 || columnMap.Precision >= 4000)
								{
									optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
								}
							}
							else if (columnMap.DataType == DbType.Binary || columnMap.DataType == DbType.Object)
							{
								optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
							}
						}
					}
				}
			}
			if (columnMap == null)
			{
				columnMap = propertyMap.GetColumnMap();
			}
			if (columnMap != null)
			{
				if (columnMap.DataType == DbType.Binary || columnMap.DataType == DbType.Object)
				{
					optimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.Disabled;
				}
			}
			return optimisticConcurrencyBehavior;
		}

		public virtual LoadBehavior GetListCountLoadBehavior(LoadBehavior loadBehavior, IPropertyMap propertyMap)
		{
			if (loadBehavior == LoadBehavior.Default)
			{
				loadBehavior = propertyMap.ListCountLoadBehavior;
				if (loadBehavior == LoadBehavior.Default)
				{
					loadBehavior = propertyMap.ClassMap.ListCountLoadBehavior;
					if (loadBehavior == LoadBehavior.Default)
					{
						loadBehavior = propertyMap.ClassMap.DomainMap.ListCountLoadBehavior;
						if (loadBehavior == LoadBehavior.Default)
						{
							loadBehavior = this.listCountLoadBehavior ;
							if (loadBehavior == LoadBehavior.Default)
							{
								loadBehavior = LoadBehavior.Eager;
							}
						}
					}
				}
			}
			return loadBehavior;
		}

		public virtual RefreshBehaviorType RefreshBehavior
		{
			get => m_RefreshBehavior;
		    set => m_RefreshBehavior = value;
		}

		
		public virtual MergeBehaviorType MergeBehavior
		{
			get => m_MergeBehavior;
		    set => m_MergeBehavior = value;
		}

		public virtual OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior
		{
			get => m_UpdateOptimisticConcurrencyBehavior;
		    set => m_UpdateOptimisticConcurrencyBehavior = value;
		}

		public virtual OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior
		{
			get => m_DeleteOptimisticConcurrencyBehavior;
		    set => m_DeleteOptimisticConcurrencyBehavior = value;
		}

		private LoadBehavior listCountLoadBehavior = LoadBehavior.Default;

		public LoadBehavior ListCountLoadBehavior 
		{
			get => listCountLoadBehavior;
		    set => listCountLoadBehavior = value;
		}

        private Hashtable nullValueStatusTemplateCache = new Hashtable();
		public virtual void SetupNullValueStatuses(object obj)
		{
            NullValueStatusTemplate template = (NullValueStatusTemplate)nullValueStatusTemplateCache[obj.GetType()];
            if (template == null)
            {
                template = BuildNullValueStatusTemplate(obj);

            }
            IObjectManager om = this.Context.ObjectManager;
            foreach (string propertyName in template.Properties)
            {
                om.SetNullValueStatus(obj, propertyName, true);
            }
		}

        private NullValueStatusTemplate BuildNullValueStatusTemplate(object obj)
        {
            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
            IObjectManager om = this.Context.ObjectManager;
            NullValueStatusTemplate template = new NullValueStatusTemplate();
            if (classMap != null)
            {
                foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
                {
                    if (propertyMap.IsCollection == false)
                    {
                        if (propertyMap.GetIsNullable() || propertyMap.IsIdentity)
                        {
                            template.Properties.Add(propertyMap.Name);
                        }                            
                    }
                }
            }
            nullValueStatusTemplateCache[obj.GetType()] = template;
            return template;

        }

		public virtual void RegisterObject(object obj)
		{
			IObjectStatusHelper objectStatusHelper = obj as IObjectStatusHelper;
			if (objectStatusHelper == null)
				throw new NPersistException("Can't attach object of type " + obj.GetType().ToString()  + " since it does not implement the interface Puzzle.NPersist.Interface.IObjectStatusHelper!");
			ObjectStatus objectStatus = objectStatusHelper.GetObjectStatus();

			switch (objectStatus)
			{
				case ObjectStatus.NotLoaded :
					this.Context.IdentityMap.RegisterLazyLoadedObject(obj);
					break;
				case ObjectStatus.UpForCreation :
					this.Context.UnitOfWork.RegisterCreated(obj);
					break;
				case ObjectStatus.Clean :
					this.Context.IdentityMap.RegisterLoadedObject(obj);
					break;
				case ObjectStatus.Dirty :
					this.Context.IdentityMap.RegisterLoadedObject(obj);
					this.Context.UnitOfWork.RegisterDirty(obj);
					break;
				case ObjectStatus.UpForDeletion  :
					this.Context.UnitOfWork.RegisterDeleted(obj);

					break;
				case ObjectStatus.Deleted :

					break;

			}			
		}

		public virtual void MergeObjects(object obj, object existing, MergeBehaviorType mergeBehavior)
		{
			//What about transfering object status ? ...and property updated status ?
			INullValueHelper nullValueHelper = obj as INullValueHelper;
			if (nullValueHelper == null)
				throw new MissingInterfaceException("Can't merge object of type " + obj.GetType().ToString()  + " since it does not implement the interface Puzzle.NPersist.Interface.INullValueHelper!");
			IOriginalValueHelper originalValueHelper = obj as IOriginalValueHelper;
			if (originalValueHelper == null)
				throw new MissingInterfaceException("Can't merge object of type " + obj.GetType().ToString()  + " since it does not implement the interface Puzzle.NPersist.Interface.IOriginalValueHelper!");
			IUpdatedPropertyTracker updatedPropertyTracker = obj as IUpdatedPropertyTracker;
			if (updatedPropertyTracker == null)
				throw new MissingInterfaceException("Can't merge object of type " + obj.GetType().ToString()  + " since it does not implement the interface Puzzle.NPersist.Interface.IUpdatedPropertyTracker!");

			IObjectManager om = this.Context.ObjectManager;
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());


			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				PropertyStatus propStatus = om.GetPropertyStatus(obj, propertyMap.Name);
				PropertyStatus extPropStatus = om.GetPropertyStatus(existing, propertyMap.Name);
				if (propStatus == PropertyStatus.Clean || propStatus == PropertyStatus.Dirty)
				{
					if (propertyMap.ReferenceType == ReferenceType.None)
					{
						MergePrimitiveProperty(om, obj, classMap, propertyMap, existing, true, propStatus, extPropStatus, mergeBehavior);
						MergePrimitiveProperty(om, obj, classMap, propertyMap, existing, false, propStatus, extPropStatus, mergeBehavior);
					}
					else
					{
						if (propertyMap.IsCollection)
						{
							MergeListRefProperty(om, obj, classMap, propertyMap, existing, propStatus, extPropStatus, true, mergeBehavior);
							MergeListRefProperty(om, obj, classMap, propertyMap, existing, propStatus, extPropStatus, false, mergeBehavior);
						}
						else
						{
							MergeSingleRefProperty(om, obj, classMap, propertyMap, existing, true, propStatus, extPropStatus, mergeBehavior);
							MergeSingleRefProperty(om, obj, classMap, propertyMap, existing, false, propStatus, extPropStatus, mergeBehavior);
						}
					}					
				}
			}
		}

		private void MergePrimitiveProperty(IObjectManager om, object obj, IClassMap classMap, IPropertyMap propertyMap, object existing, bool forOrgValue, PropertyStatus propStatus, PropertyStatus extPropStatus, MergeBehaviorType mergeBehavior)
		{
			if (forOrgValue)
			{
				object value = om.GetPropertyValue(obj, propertyMap.Name);
				object extValue = om.GetPropertyValue(existing, propertyMap.Name);
				MergePrimitivePropertyValues(value, extValue, propStatus, extPropStatus, om, existing, classMap, propertyMap, obj, forOrgValue, mergeBehavior);
			}
			else
			{
				object orgValue = om.GetOriginalPropertyValue(obj, propertyMap.Name);
				object extOrgValue = om.GetOriginalPropertyValue(existing, propertyMap.Name);
				MergePrimitivePropertyValues(orgValue, extOrgValue, propStatus, extPropStatus, om, existing, classMap, propertyMap, obj, forOrgValue, mergeBehavior);
			}
		}

		private void MergePrimitivePropertyValues(object value, object extValue, PropertyStatus propStatus, PropertyStatus extPropStatus, IObjectManager om, object existing, IClassMap classMap, IPropertyMap propertyMap, object obj, bool forOrgValue, MergeBehaviorType mergeBehavior)
		{
			if (!value.Equals(extValue)) // May be to naive - possibly should use some advanced method like ComparePropertyValues..
			{
				bool keepExisting = KeepExistingValue(value, extValue, mergeBehavior, classMap, propertyMap, existing, obj, propStatus, extPropStatus, forOrgValue);
				if (!keepExisting)
				{
					if (forOrgValue)
					{
						om.SetPropertyValue(existing, propertyMap.Name, value);				
						om.SetNullValueStatus(existing, propertyMap.Name, om.GetNullValueStatus(obj, propertyMap.Name));
						if (propStatus == PropertyStatus.Dirty)
						{
							this.Context.UnitOfWork.RegisterDirty(existing);					
							om.SetUpdatedStatus(existing, propertyMap.Name, true);						
						}
					}
					else
					{
						om.SetOriginalPropertyValue(existing, propertyMap.Name, value);									
					}
				}
			}
		}

		private bool KeepExistingValue(object value, object extValue, MergeBehaviorType mergeBehavior, IClassMap classMap, IPropertyMap propertyMap, object existing, object obj, PropertyStatus propStatus, PropertyStatus extPropStatus, bool forOrgValue)
		{
			bool keepExisting = false;
			MergeBehaviorType useMergeBehavior = GetMergeBehavior(mergeBehavior, classMap, propertyMap);
			if (useMergeBehavior == MergeBehaviorType.ThrowConcurrencyException) 
				throw new MergeException("Merge Conflict!", extValue, value, existing, obj, propertyMap.Name, forOrgValue);

			//First try: Dirty wins..
			if (propStatus == PropertyStatus.Dirty && extPropStatus == PropertyStatus.Dirty)
			{
				if (useMergeBehavior == MergeBehaviorType.DefaultBehavior || useMergeBehavior == MergeBehaviorType.TryResolveConflicts)
					throw new BothDirtyMergeException("Unresovable Merge Conflict! Both values are dirty!", extValue, value, existing, obj, propertyMap.Name, forOrgValue);
				else if (useMergeBehavior == MergeBehaviorType.IgnoreConflictsUsingMergeValue)
					keepExisting = false;
				else if (useMergeBehavior == MergeBehaviorType.IgnoreConflictsUsingCashedValue)
					keepExisting = true;
				else
					throw new NPersistException("This should be unreachable code...if it is not, that means I made a mistake!" );					
			}
			else if (propStatus == PropertyStatus.Dirty)
				keepExisting = false;
			else if (extPropStatus == PropertyStatus.Dirty)
				keepExisting = true;
			else
			{
				//Second try: Clean wins
				if (propStatus == PropertyStatus.Clean && extPropStatus == PropertyStatus.Clean)
				{
					if (useMergeBehavior == MergeBehaviorType.DefaultBehavior || useMergeBehavior == MergeBehaviorType.TryResolveConflicts)
						throw new BothCleanMergeException("Unresovable Merge Conflict! Both values are clean!", extValue, value, existing, obj, propertyMap.Name, forOrgValue);
					else if (useMergeBehavior == MergeBehaviorType.IgnoreConflictsUsingMergeValue)
						keepExisting = false;
					else if (useMergeBehavior == MergeBehaviorType.IgnoreConflictsUsingCashedValue)
						keepExisting = true;
					else
						throw new NPersistException("This should be unreachable code...if it is not, that means I made a mistake!" );						
				}
				else if (propStatus == PropertyStatus.Clean)
					keepExisting = false;
				else if (extPropStatus == PropertyStatus.Clean)
					keepExisting = true;
				else
				{
					if (extPropStatus == PropertyStatus.NotLoaded)
						keepExisting = false;
					if (extPropStatus == PropertyStatus.Deleted)
						keepExisting = true;
					else
						throw new NPersistException("This should be unreachable code...if it is not, that means I made a mistake!" );					
				}
			}
			return keepExisting;
		}

		private void MergeListRefProperty(IObjectManager om, object obj, IClassMap classMap, IPropertyMap propertyMap, object existing, PropertyStatus propStatus, PropertyStatus extPropStatus, bool forOrgValue, MergeBehaviorType mergeBehavior)
		{
			IList list = ((IList) om.GetPropertyValue(obj, propertyMap.Name));
			IList orgList = ((IList) om.GetPropertyValue(existing, propertyMap.Name));
			MergeReferenceLists(list, orgList, om, obj, mergeBehavior, classMap, propertyMap, existing, propStatus, extPropStatus, forOrgValue);

		}

		
		private void MergeReferenceLists(IList list, IList orgList, IObjectManager om, object obj, MergeBehaviorType mergeBehavior, IClassMap classMap, IPropertyMap propertyMap, object existing, PropertyStatus propStatus, PropertyStatus extPropStatus, bool forOrgValue)
		{
			IList objectsToRemove = new ArrayList(); 
			IList objectsToAdd = new ArrayList();
			IUnitOfWork uow = this.Context.UnitOfWork;
			foreach (object itemOrgObj in orgList)
			{
				string itemOrgObjId = om.GetObjectIdentity(itemOrgObj);
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
				foreach (object itemOrgObj in orgList)
				{
					string itemOrgObjId = om.GetObjectIdentity(itemOrgObj);
					if (itemObjId == itemOrgObjId)
					{
						found = true;
						break;
					}								
				}
				if (!found)
				{
					object itemOrgObj = this.Context.GetObjectById(itemObjId, obj.GetType());
					objectsToAdd.Add(itemOrgObj);
				}
			}
	
			if (objectsToRemove.Count > 0 || objectsToAdd.Count > 0)
			{
				bool keepExisting = KeepExistingValue(list, orgList, mergeBehavior, classMap, propertyMap, existing, obj, propStatus, extPropStatus, forOrgValue);
				if (!keepExisting)
				{
					bool stackMute = false;
					IInterceptableList mList = orgList as IInterceptableList;					
					if (mList != null)
					{
						stackMute = mList.MuteNotify;
						mList.MuteNotify = true;
					}
					foreach (object itemOrgObj in objectsToRemove)
						orgList.Remove(itemOrgObj);
					foreach (object itemOrgObj in objectsToAdd)
						orgList.Add(itemOrgObj);	

					if (mList != null) { mList.MuteNotify = stackMute; }
					
					if (propStatus == PropertyStatus.Dirty)
					{
						uow.RegisterDirty(existing);					
						om.SetUpdatedStatus(existing, propertyMap.Name, true);						
					}
				}								
			}
		}

		private void MergeSingleRefProperty(IObjectManager om, object obj, IClassMap classMap, IPropertyMap propertyMap, object existing, bool forOrgValue, PropertyStatus propStatus, PropertyStatus extPropStatus, MergeBehaviorType mergeBehavior)
		{
			string extOrgObjId;
			string refObjId;
			object extRefObj;
			object refObj;
			object extOrgObj;
			if (forOrgValue)
			{
				refObj = om.GetOriginalPropertyValue(obj, propertyMap.Name);
				extOrgObj = om.GetOriginalPropertyValue(existing, propertyMap.Name);				
			}
			else
			{
				refObj = om.GetPropertyValue(obj, propertyMap.Name);
				extOrgObj = om.GetPropertyValue(existing, propertyMap.Name);			
			}	
			if (refObj != null && DBNull.Value.Equals(refObj) != true)
			{
                //hmmmm won't this fail if we have two objects of different classes but with the same id?
                //probably the type should be included (and preferably change to KeyStruct comparisons...)
				refObjId = om.GetObjectIdentity(refObj);
				extOrgObjId = "";
				if (extOrgObj != null)
					extOrgObjId = om.GetObjectIdentity(extOrgObj);

				if (!refObjId.Equals(extOrgObjId))
				{
					bool keepExisting = KeepExistingValue(refObj, extOrgObj, mergeBehavior, classMap, propertyMap, existing, obj, propStatus, extPropStatus, forOrgValue);
					if (keepExisting != true)
					{
						extRefObj = this.Context.GetObjectById(refObjId, refObj.GetType());

						SetSingleRefPropetyValue(forOrgValue, om, existing, propertyMap, extRefObj, propStatus);
					}
				}
			}
			else
			{
				if (extOrgObj != null)
				{
					bool keepExisting = KeepExistingValue(refObj, extOrgObj, mergeBehavior, classMap, propertyMap, existing, obj, propStatus, extPropStatus, forOrgValue);
					if (keepExisting)
					{
						SetSingleRefPropetyValue(forOrgValue, om, existing, propertyMap, null, propStatus);
					}
				}
			}
		}

		private void SetSingleRefPropetyValue(bool forOrgValue, IObjectManager om, object existing, IPropertyMap propertyMap, object value, PropertyStatus propStatus)
		{
			IUnitOfWork uow = this.Context.UnitOfWork;
			if (forOrgValue)
				om.SetOriginalPropertyValue(existing, propertyMap.Name, value);
			else
			{
				om.SetPropertyValue(existing, propertyMap.Name, value);
				if (value == null)
					om.SetNullValueStatus(existing, propertyMap.Name, true);
				else
					om.SetNullValueStatus(existing, propertyMap.Name, false);

				if (propStatus == PropertyStatus.Dirty)
				{
					uow.RegisterDirty(existing);					
					om.SetUpdatedStatus(existing, propertyMap.Name, true);						
				}
			}
		}

		public virtual void AttachObject(object obj, Hashtable visited, Hashtable merge)
		{
			if (visited[obj] != null)
				return;

			//We should check if the object isn't proxied. If not, we throw an exception
			IInterceptable interceptable = obj as IInterceptable;
			if (interceptable == null)
			{
				throw new NPersistException("Can't attach unproxied object!", obj);
			}
			
			IInterceptor interceptor = ((IInterceptable) obj).GetInterceptor();
			if (interceptor != null)
			{
				if (interceptor.IsDisposed == false)
				{
					IContext ctx = interceptor.Context ;
					if (ctx != null)
					{
						if (ctx.IsDisposed == false)
						{
							if (ctx == this.Context)
							{
								//same context, done
								return;
							}
						}
					}
				}
			}

            ((IInterceptable) obj).SetInterceptor(this.Context.Interceptor);

			string identity = this.Context.ObjectManager.GetObjectIdentity(obj);
			object existing = this.Context.IdentityMap.TryGetObject(identity, obj.GetType() );

			if (existing != null)
				merge[obj] = existing;
			else
				RegisterObject(obj);
			
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			object refObj;
			PropertyStatus propStatus;
			IObjectManager om = this.Context.ObjectManager;
			if (classMap != null)
			{
				foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
				{
					if (propertyMap.ReferenceType != ReferenceType.None)
					{
						propStatus = om.GetPropertyStatus(obj, propertyMap.Name);
						if (propStatus != PropertyStatus.NotLoaded)
						{
							if (propertyMap.IsCollection)
							{
								IList list = ((IList) om.GetPropertyValue(obj, propertyMap.Name));
								foreach (object itemRefObj in list)
								{
                                    LogMessage message = new LogMessage("Attaching referenced object");
                                    LogMessage verbose = new LogMessage("Type: {0}, Referenced by Type: {1}, Referencing Property: {2}" , obj.GetType(), itemRefObj.GetType(), propertyMap.Name);

									this.Context.LogManager.Info(this,message, verbose); // do not localize
									AttachObject(itemRefObj, visited, merge);
								}
							}
							else
							{
								refObj = om.GetPropertyValue(obj, propertyMap.Name);
								if (refObj != null)
								{
                                    LogMessage message = new LogMessage("Attaching referenced object");
                                    LogMessage verbose = new LogMessage("Type: {0}, Referenced by Type: {1}, Referencing Property: {2}" , obj.GetType(),refObj.GetType(), propertyMap.Name);

                                    this.Context.LogManager.Info(this, message, verbose); // do not localize

									AttachObject(refObj, visited, merge);
								}

							}
						}
					}
				}
			}

		}

		public void InitializeObject(object obj)
		{
			IInterceptable interceptable = obj as IInterceptable;
			if (interceptable != null)
			{
				IInterceptor interceptor = interceptable.GetInterceptor();
				if (interceptor != null)
					if (interceptor.IsDisposed)
						interceptor = null;
				if (interceptor == null)
				{
					interceptable.SetInterceptor(this.Context.Interceptor);
				}
				SetupObject(obj);
			}
		}

		public void SetupObject(object obj)
		{
			SetupNullValueStatuses(obj);				
			this.Context.ListManager.SetupListProperties(obj);						
		}

        protected virtual void CascadeCreate(object obj)
        {
            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
            object refObj;
            Type refType = null;
            IClassMap refClassMap;
            //IPropertyMap invPropertyMap;
            IList list;
            IObjectManager om = this.Context.ObjectManager;
            if (classMap != null)
            {
                foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
                {
                    if (propertyMap.ReferenceType != ReferenceType.None)
                    {
                        if (propertyMap.CascadingCreate)
                        {
                            if (propertyMap.IsCollection)
                            {
                                refClassMap = propertyMap.MustGetReferencedClassMap();
                                refType = this.Context.AssemblyManager.MustGetTypeFromClassMap(refClassMap);
                            }
                            else
                            {
                                refType = obj.GetType().GetProperty(propertyMap.Name).PropertyType;
                            }
                            LogMessage message = new LogMessage("Cascade creating and referencing object");
                            LogMessage verbose = new LogMessage("Type: {0}, Creating Type: {1}, Property: {2}" , obj.GetType(), refType, propertyMap.Name);
                            this.Context.LogManager.Info(this, message , verbose); // do not localize

                            if (propertyMap.IsCollection)
                            {
                                list = (IList)om.GetPropertyValue(obj, propertyMap.Name);
                                int amount = 1;
                                if (propertyMap.MinLength > 1)
                                    amount = propertyMap.MinLength;

                                for (int i = 0; i < amount; i++)
                                {
                                    refObj = this.Context.CreateObject(refType);
                                    list.Add(refObj);
                                }
                                om.SetPropertyValue(obj, propertyMap.Name, list);
                                //IList clone = this.Context.ListManager.CloneList(obj, propertyMap, list);
								IList clone = new ArrayList( list);
								om.SetOriginalPropertyValue(obj, propertyMap.Name, clone);
                            }
                            else
                            {
                                refObj = this.Context.CreateObject(refType);
                                this.Context.InverseManager.NotifyPropertySet(obj, propertyMap.Name, refObj);
                                om.SetPropertyValue(obj, propertyMap.Name, refObj);
                                om.SetOriginalPropertyValue(obj, propertyMap.Name, refObj);
                            }
                            om.SetNullValueStatus(obj, propertyMap.Name, false);

                        }
                    }
                }
            }
        }

		protected virtual void CascadeDelete(object obj)
		{
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType());
			object refObj;
			PropertyStatus propStatus;
			IObjectManager om = this.Context.ObjectManager;
			if (classMap != null)
			{
				foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
				{
					if (!(propertyMap.ReferenceType == ReferenceType.None))
					{
						if (propertyMap.CascadingDelete)
						{
							propStatus = om.GetPropertyStatus(obj, propertyMap.Name);
							if (propStatus == PropertyStatus.NotLoaded)
							{
								this.Context.PersistenceEngine.LoadProperty(obj, propertyMap.Name);
							}
							if (propertyMap.IsCollection)
							{
								IList list = ((IList) om.GetPropertyValue(obj, propertyMap.Name));
								list = new ArrayList(list);
								foreach (object itemRefObj in list)
								{
                                    LogMessage message = new LogMessage("Cascade deleting referenced object");
                                    LogMessage verbose = new LogMessage("Type: {0}, Deleting Type: {1}, Property: {2}" , obj.GetType(), itemRefObj.GetType(), propertyMap.Name);
									this.Context.LogManager.Info(this, message , verbose); // do not localize
									this.Context.DeleteObject(itemRefObj);
								}
							}
							else
							{
								refObj = om.GetPropertyValue(obj, propertyMap.Name);
								if (refObj != null)
								{
                                    LogMessage message = new LogMessage("Cascade deleting referenced object");
                                    LogMessage verbose = new LogMessage("Type: {0}, Deleting Type: {1}, Property: {2}", obj.GetType(), refObj.GetType(), propertyMap.Name);
                                    this.Context.LogManager.Info(this, message, verbose); // do not localize
									this.Context.DeleteObject(refObj);
								}
							}
						}
					}
				}
			}
		}
	}
}