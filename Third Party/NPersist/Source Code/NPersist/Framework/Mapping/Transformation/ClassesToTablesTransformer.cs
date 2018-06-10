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
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Framework.Mapping.Transformation
{
	/// <summary>
	/// Summary description for ClassesToTablesTransformer.
	/// </summary>
	public class ClassesToTablesTransformer
	{
		public ClassesToTablesTransformer()
		{
		}

		private string m_TablePrefix = "tbl";
		private string m_TableSuffix = "";
		private int m_MaxTableLength = 0;
		private int m_MaxColumnLength = 0;
		private int m_DefaultStringLength = 0;

		public virtual string GetTableNameForClass(IClassMap classMap) => GetTableNameForClass(classMap, false);

	    public virtual string GetTableNameForClass(IClassMap classMap, bool useThisClass)
		{
			string name;
			IClassMap useClassMap = classMap;
			if (!(useThisClass)) 
			{
				if (useClassMap.IsInHierarchy()) 
				{
					if (!(useClassMap.InheritanceType == InheritanceType.None)) 
					{
						while (!(useClassMap.GetInheritedClassMap() == null)) 
						{
							useClassMap = useClassMap.GetInheritedClassMap();
						}
					}
				}
			}
			if (useClassMap.Table.Length > 0 & !(useThisClass)) 
			{
				return useClassMap.Table;
			} 
			else 
			{
				name = TablePrefix + useClassMap.GetName() + TableSuffix;
				if (m_MaxTableLength > 0) 
				{
					if (name.Length > m_MaxTableLength) 
					{
						name = name.Substring(0, m_MaxTableLength);
					}
				}
				return name;
			}
		}

		public virtual string GetTypeColumnNameForClass(IClassMap classMap)
		{
			string name;
			IClassMap useClassMap = classMap;
			if (useClassMap.IsInHierarchy()) 
			{
				if (!(useClassMap.InheritanceType == InheritanceType.None)) 
				{
					while (!(useClassMap.GetInheritedClassMap() == null)) 
					{
						useClassMap = useClassMap.GetInheritedClassMap();
					}
				}
			}
			if (useClassMap.TypeColumn.Length > 0) 
			{
				return useClassMap.TypeColumn;
			} 
			else 
			{
				name = useClassMap.GetName() + "Type";
				if (m_MaxColumnLength > 0) 
				{
					if (name.Length > m_MaxColumnLength) 
					{
						name = name.Substring(0, m_MaxColumnLength);
					}
				}
				return name;
			}
		}

		public virtual string GetTableNameForProperty(Puzzle.NPersist.Framework.Mapping.IPropertyMap propertyMap)
		{
			string name;
			string clsName;
			IClassMap refClassMap;
			string refClsName;
			if (propertyMap.IsCollection) 
			{
				if (!(propertyMap.ReferenceType == ReferenceType.None)) 
				{
					clsName = propertyMap.ClassMap.GetName();
					refClassMap = propertyMap.GetReferencedClassMap();
					if (!(propertyMap.GetReferencedClassMap() == null)) 
					{
						refClsName = refClassMap.GetName();
						if (clsName.GetHashCode() > refClsName.GetHashCode()) 
						{
							name = TablePrefix + refClsName + "_" + clsName + TableSuffix;
						} 
						else 
						{
							name = TablePrefix + clsName + "_" + refClsName + TableSuffix;
						}
					} 
					else 
					{
						throw new Exception("Referenced class does not exists! Can't create table name for property!");
					}
				} 
				else 
				{
					name = TablePrefix + propertyMap.ClassMap.GetName() + "_" + propertyMap.Name + TableSuffix;
				}
			} 
			else 
			{
				name = GetTableNameForClass(propertyMap.ClassMap, true);
			}
			if (m_MaxColumnLength > 0) 
			{
				if (name.Length > m_MaxColumnLength) 
				{
					name = name.Substring(0, m_MaxColumnLength);
				}
			}
			return name;
		}

		public virtual string GetColumnNameForProperty(Puzzle.NPersist.Framework.Mapping.IPropertyMap propertyMap)
		{
			string name = "";
			IClassMap refClassMap;
			IClassMap useClassMap;
			if (propertyMap.IsIdentity) 
			{
				useClassMap = propertyMap.ClassMap;
				if (useClassMap.IsInHierarchy()) 
				{
					if (!(useClassMap.InheritanceType == InheritanceType.None)) 
					{
						while (!(useClassMap.GetInheritedClassMap() == null)) 
						{
							useClassMap = useClassMap.GetInheritedClassMap();
						}
					}
				}
				if (propertyMap.Name.ToLower() == "id" || propertyMap.Name.ToLower() == "key") 
				{
					name = useClassMap.GetName() + propertyMap.Name;
				}
			}
			if (name == "") 
			{
				if (!(propertyMap.ReferenceType == ReferenceType.None)) 
				{
					refClassMap = propertyMap.GetReferencedClassMap();
					if (!(refClassMap == null)) 
					{
						foreach (IPropertyMap idProp in refClassMap.GetIdentityPropertyMaps()) 
						{
							if (idProp.ReferenceType == ReferenceType.None) 
							{
								if (idProp.Column.Length > 0) 
								{
									name = propertyMap.Name + "_" + idProp.Column;
								} 
								else 
								{
									name = propertyMap.Name + "_" + GetColumnNameForProperty(idProp);
								}
							}
							break;
						}
					}
				}
			}
			if (name == "") 
			{
				name = propertyMap.Name;
			}
			if (m_MaxColumnLength > 0) 
			{
				if (name.Length > m_MaxColumnLength) 
				{
					name = name.Substring(0, m_MaxColumnLength);
				}
			}
			return name;
		}

		public virtual string TablePrefix 
		{
			get => m_TablePrefix;
		    set => m_TablePrefix = value;
		}

		public virtual string TableSuffix 
		{
			get => m_TableSuffix;
		    set => m_TableSuffix = value;
		}

		public virtual int MaxColumnLength 
		{
			get => m_MaxColumnLength;
		    set => m_MaxColumnLength = value;
		}

		public virtual int MaxTableLength 
		{
			get => m_MaxTableLength;
		    set => m_MaxTableLength = value;
		}

		public virtual int DefaultStringLength 
		{
			get => m_DefaultStringLength;
		    set => m_DefaultStringLength = value;
		}

		public virtual System.Data.DbType GetColumnTypeForProperty(Puzzle.NPersist.Framework.Mapping.IPropertyMap propertyMap)
		{
			string dataType = "";
			System.Data.DbType columnType;
			IPropertyMap refProp = null;
			IClassMap refClassMap;
			if (!(propertyMap.ReferenceType == ReferenceType.None)) 
			{
				refClassMap = propertyMap.GetReferencedClassMap();
				if (!(refClassMap == null)) 
				{
					foreach (IPropertyMap idProp in refClassMap.GetIdentityPropertyMaps()) 
					{
						refProp = idProp;
						break;
					}
					if (refProp != null) 
					{
						if (refProp.IsCollection) 
						{
							dataType = refProp.ItemType;
						} 
						else 
						{
							dataType = refProp.DataType;
						}
					} 
					else 
					{
						//throw...
					}
				}
			} 
			else 
			{
				if (propertyMap.IsCollection) 
				{
					dataType = propertyMap.ItemType;
				} 
				else 
				{
					dataType = propertyMap.DataType;
				}
			}
			string dataTypeTrimmedLow = dataType.ToLower().Trim();
			if (dataTypeTrimmedLow == "string" || dataTypeTrimmedLow == "system.string") 
			{
				columnType = DbType.AnsiString;
			} 
			else if (dataTypeTrimmedLow == "guid" || dataTypeTrimmedLow == "system.guid") 
			{
				columnType = DbType.Guid;
			} 
			else if (dataTypeTrimmedLow == "integer" || dataTypeTrimmedLow == "int32" || dataTypeTrimmedLow == "int" || dataTypeTrimmedLow == "system.int32") 
			{
				columnType = DbType.Int32;
			} 
			else if (dataTypeTrimmedLow == "int16" || dataTypeTrimmedLow == "system.int16" || dataTypeTrimmedLow == "short") 
			{
				columnType = DbType.Int16;
			} 
			else if (dataTypeTrimmedLow == "int64" || dataTypeTrimmedLow == "system.int64" || dataTypeTrimmedLow == "long") 
			{
				columnType = DbType.Int64;
			} 
			else if (dataTypeTrimmedLow == "uint16" || dataTypeTrimmedLow == "system.uint16") 
			{
				columnType = DbType.UInt16;
			} 
			else if (dataTypeTrimmedLow == "uint32" || dataTypeTrimmedLow == "system.uint32") 
			{
				columnType = DbType.UInt32;
			} 
			else if (dataTypeTrimmedLow == "uint64" || dataTypeTrimmedLow == "system.uint64") 
			{
				columnType = DbType.UInt64;
			} 
			else if (dataTypeTrimmedLow == "date" || dataTypeTrimmedLow == "time" || dataTypeTrimmedLow == "datetime" || dataTypeTrimmedLow == "system.datetime") 
			{
				columnType = DbType.DateTime;
			} 
			else if (dataTypeTrimmedLow == "bool" || dataTypeTrimmedLow == "boolean" || dataTypeTrimmedLow == "system.boolean") 
			{
				columnType = DbType.Boolean;
			} 
			else if (dataTypeTrimmedLow == "byte" || dataTypeTrimmedLow == "system.byte" || dataTypeTrimmedLow == "char" || dataTypeTrimmedLow == "system.char") 
			{
				columnType = DbType.Byte;
			} 
			else if (dataTypeTrimmedLow == "decimal" || dataTypeTrimmedLow == "system.decimal") 
			{
				columnType = DbType.Decimal;
			} 
			else if (dataTypeTrimmedLow == "double" || dataTypeTrimmedLow == "system.double") 
			{
				columnType = DbType.Double;
			} 
			else if (dataTypeTrimmedLow == "object" || dataTypeTrimmedLow == "system.object") 
			{
				columnType = DbType.Object;
			} 
			else if (dataTypeTrimmedLow == "single" || dataTypeTrimmedLow == "system.single") 
			{
				columnType = DbType.Single;
			} 
			else if (dataTypeTrimmedLow == "byte()" || dataTypeTrimmedLow == "system.byte()" || dataTypeTrimmedLow == "byte[]" || dataTypeTrimmedLow == "system.byte[]") 
			{
				columnType = DbType.Object;
			} 
			else 
			{
				columnType = DbType.Int32;
			}
			return columnType;
		}

		public virtual int GetColumnLengthForProperty(Puzzle.NPersist.Framework.Mapping.IPropertyMap propertyMap)
		{
			string dataType = "";
			int length;
			IPropertyMap refProp = null;
			IClassMap refClassMap;
			if (!(propertyMap.ReferenceType == ReferenceType.None)) 
			{
				refClassMap = propertyMap.GetReferencedClassMap();
				if (!(refClassMap == null)) 
				{
					foreach (IPropertyMap idProp in refClassMap.GetIdentityPropertyMaps()) 
					{
						refProp = idProp;
						break;
					}
					if (!(refProp == null)) 
					{
						if (refProp.IsCollection) 
						{
							dataType = refProp.ItemType;
						} 
						else 
						{
							dataType = refProp.DataType;
						}
					} 
					else 
					{
						//throw...
					}
				}
			} 
			else 
			{
				if (propertyMap.IsCollection) 
				{
					dataType = propertyMap.ItemType;
				} 
				else 
				{
					dataType = propertyMap.DataType;
				}
			}
			string dataTypeTrimmedLow = dataType.ToLower().Trim();
			if (dataTypeTrimmedLow == "string" || dataTypeTrimmedLow == "system.string") 
			{
				if (propertyMap.MaxLength > -1) 
				{
					length = propertyMap.MaxLength;
				} 
				else 
				{
					length = 16;
				}
			} 
			else if (dataTypeTrimmedLow == "integer" || dataTypeTrimmedLow == "int32" || dataTypeTrimmedLow == "int" || dataTypeTrimmedLow == "system.int32") 
			{
				length = 4;
			} 
			else if (dataTypeTrimmedLow == "short" || dataTypeTrimmedLow == "int16" || dataTypeTrimmedLow == "system.int16") 
			{
				length = 2;
			} 
			else if (dataTypeTrimmedLow == "long" || dataTypeTrimmedLow == "int64" || dataTypeTrimmedLow == "system.int64") 
			{
				length = 8;
			} 
			else if (dataTypeTrimmedLow == "uint16" || dataTypeTrimmedLow == "system.uint16") 
			{
				length = 2;
			} 
			else if (dataTypeTrimmedLow == "uint32" || dataTypeTrimmedLow == "system.uint32") 
			{
				length = 4;
			} 
			else if (dataTypeTrimmedLow == "uint64" || dataTypeTrimmedLow == "system.uint64") 
			{
				length = 8;
			} 
			else if (dataTypeTrimmedLow == "date" || dataTypeTrimmedLow == "time" || dataTypeTrimmedLow == "datetime" || dataTypeTrimmedLow == "system.datetime") 
			{
				length = 8;
			} 
			else if (dataTypeTrimmedLow == "bool" || dataTypeTrimmedLow == "boolean" || dataTypeTrimmedLow == "system.boolean") 
			{
				length = 1;
			} 
			else if (dataTypeTrimmedLow == "byte" || dataTypeTrimmedLow == "system.byte" || dataTypeTrimmedLow == "char" || dataTypeTrimmedLow == "system.char") 
			{
				length = 1;
			} 
			else if (dataTypeTrimmedLow == "decimal" || dataTypeTrimmedLow == "system.decimal") 
			{
				length = 9;
			} 
			else if (dataTypeTrimmedLow == "double" || dataTypeTrimmedLow == "system.double") 
			{
				length = 9;
			} 
			else if (dataTypeTrimmedLow == "object" || dataTypeTrimmedLow == "system.object") 
			{
				length = 0;
			} 
			else if (dataTypeTrimmedLow == "single" || dataTypeTrimmedLow == "system.single") 
			{
				length = 8;
			} 
			else if (dataTypeTrimmedLow == "byte()" || dataTypeTrimmedLow == "system.byte()" || dataTypeTrimmedLow == "byte[]" || dataTypeTrimmedLow == "system.byte[]") 
			{
				length = 16;
			} 
			else 
			{
				length = 4;
			}
			return length;
		}

		public virtual int GetColumnPrecisionForProperty(Puzzle.NPersist.Framework.Mapping.IPropertyMap propertyMap)
		{
			string dataType = "";
			int prec;
			IPropertyMap refProp = null;
			IClassMap refClassMap;
			if (!(propertyMap.ReferenceType == ReferenceType.None)) 
			{
				refClassMap = propertyMap.GetReferencedClassMap();
				if (!(refClassMap == null)) 
				{
					foreach (IPropertyMap idProp in propertyMap.GetReferencedClassMap().GetIdentityPropertyMaps()) 
					{
						refProp = idProp;
						break;
					}
					if (!(refProp == null)) 
					{
						if (refProp.IsCollection) 
						{
							dataType = refProp.ItemType;
						} 
						else 
						{
							dataType = refProp.DataType;
						}
					} 
					else 
					{
					}
				}
			} 
			else 
			{
				if (propertyMap.IsCollection) 
				{
					dataType = propertyMap.ItemType;
				} 
				else 
				{
					dataType = propertyMap.DataType;
				}
			}
			string dataTypeTrimmedLow = dataType.ToLower().Trim();
			if (dataTypeTrimmedLow == "string" || dataTypeTrimmedLow == "system.string") 
			{
				if (propertyMap.MaxLength > -1) 
				{
					prec = propertyMap.MaxLength;
				} 
				else 
				{
					prec = 0;
				}
			} 
			else if (dataTypeTrimmedLow == "integer" || dataTypeTrimmedLow == "int32" || dataTypeTrimmedLow == "int" || dataTypeTrimmedLow == "system.int32") 
			{
				prec = 10;
			} 
			else if (dataTypeTrimmedLow == "short" || dataTypeTrimmedLow == "int16" || dataTypeTrimmedLow == "system.int16") 
			{
				prec = 5;
			} 
			else if (dataTypeTrimmedLow == "long" || dataTypeTrimmedLow == "int64" || dataTypeTrimmedLow == "system.int64") 
			{
				prec = 19;
			} 
			else if (dataTypeTrimmedLow == "uint16" || dataTypeTrimmedLow == "system.uint16") 
			{
				prec = 5;
			} 
			else if (dataTypeTrimmedLow == "uint32" || dataTypeTrimmedLow == "system.uint32") 
			{
				prec = 10;
			} 
			else if (dataTypeTrimmedLow == "uint64" || dataTypeTrimmedLow == "system.uint64") 
			{
				prec = 15;
			} 
			else if (dataTypeTrimmedLow == "date" || dataTypeTrimmedLow == "time" || dataTypeTrimmedLow == "datetime" || dataTypeTrimmedLow == "system.datetime") 
			{
				prec = 23;
			} 
			else if (dataTypeTrimmedLow == "bool" || dataTypeTrimmedLow == "boolean" || dataTypeTrimmedLow == "system.boolean") 
			{
				prec = 1;
			} 
			else if (dataTypeTrimmedLow == "byte" || dataTypeTrimmedLow == "system.byte" || dataTypeTrimmedLow == "char" || dataTypeTrimmedLow == "system.char") 
			{
				prec = 3;
			} 
			else if (dataTypeTrimmedLow == "decimal" || dataTypeTrimmedLow == "system.decimal") 
			{
				prec = 18;
			} 
			else if (dataTypeTrimmedLow == "double" || dataTypeTrimmedLow == "system.double") 
			{
				prec = 18;
			} 
			else if (dataTypeTrimmedLow == "object" || dataTypeTrimmedLow == "system.object") 
			{
				prec = 0;
			} 
			else if (dataTypeTrimmedLow == "single" || dataTypeTrimmedLow == "system.single") 
			{
				prec = 19;
			} 
			else if (dataTypeTrimmedLow == "byte()" || dataTypeTrimmedLow == "system.byte()" || dataTypeTrimmedLow == "byte[]" || dataTypeTrimmedLow == "system.byte[]") 
			{
				prec = 0;
			} 
			else 
			{
				prec = 10;
			}
			return prec;
		}

		public virtual int GetColumnScaleForProperty(Puzzle.NPersist.Framework.Mapping.IPropertyMap propertyMap)
		{
			string dataType = "";
			int scale;
			IPropertyMap refProp = null;
			IClassMap refClassMap;
			if (!(propertyMap.ReferenceType == ReferenceType.None)) 
			{
				refClassMap = propertyMap.GetReferencedClassMap();
				if (!(refClassMap == null)) 
				{
					foreach (IPropertyMap idProp in propertyMap.GetReferencedClassMap().GetIdentityPropertyMaps()) 
					{
						refProp = idProp;
						break;
					}
					if (!(refProp == null)) 
					{
						if (refProp.IsCollection) 
						{
							dataType = refProp.ItemType;
						} 
						else 
						{
							dataType = refProp.DataType;
						}
					} 
					else 
					{
						//throw...
					}
				}
			} 
			else 
			{
				if (propertyMap.IsCollection) 
				{
					dataType = propertyMap.ItemType;
				} 
				else 
				{
					dataType = propertyMap.DataType;
				}
			}
			string dataTypeTrimmedLow = dataType.ToLower().Trim();
			if (dataTypeTrimmedLow == "string" || dataTypeTrimmedLow == "system.string") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "integer" || dataTypeTrimmedLow == "int32" || dataTypeTrimmedLow == "int" || dataTypeTrimmedLow == "system.int32") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "short" || dataTypeTrimmedLow == "int16" || dataTypeTrimmedLow == "system.int16") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "long" || dataTypeTrimmedLow == "int64" || dataTypeTrimmedLow == "system.int64") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "uint16" || dataTypeTrimmedLow == "system.uint16") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "uint32" || dataTypeTrimmedLow == "system.uint32") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "uint64" || dataTypeTrimmedLow == "system.uint64") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "date" || dataTypeTrimmedLow == "time" || dataTypeTrimmedLow == "datetime" || dataTypeTrimmedLow == "system.datetime") 
			{
				scale = 3;
			} 
			else if (dataTypeTrimmedLow == "bool" || dataTypeTrimmedLow == "boolean" || dataTypeTrimmedLow == "system.boolean") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "byte" || dataTypeTrimmedLow == "system.byte" || dataTypeTrimmedLow == "char" || dataTypeTrimmedLow == "system.char") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "decimal" || dataTypeTrimmedLow == "system.decimal") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "double" || dataTypeTrimmedLow == "system.double") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "object" || dataTypeTrimmedLow == "system.object") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "single" || dataTypeTrimmedLow == "system.single") 
			{
				scale = 0;
			} 
			else if (dataTypeTrimmedLow == "byte()" || dataTypeTrimmedLow == "system.byte()" || dataTypeTrimmedLow == "byte[]" || dataTypeTrimmedLow == "system.byte[]") 
			{
				scale = 0;
			} 
			else 
			{
				scale = 0;
			}
			return scale;
		}

		public virtual void GenerateTablesForClasses(IDomainMap sourceDomainMap, IDomainMap targetDomainMap) => GenerateTablesForClasses(sourceDomainMap, targetDomainMap, false);

	    public virtual void GenerateTablesForClasses(IDomainMap sourceDomainMap, IDomainMap targetDomainMap, bool generateMappings) => GenerateTablesForClasses(sourceDomainMap, targetDomainMap, false, false);

	    public virtual void GenerateTablesForClasses(IDomainMap sourceDomainMap, IDomainMap targetDomainMap, bool generateMappings, bool onlyForComputed)
		{
			IList propertyMaps = new ArrayList();
			IList allPropertyMaps;
			bool ok = false;
			IList classMaps = sourceDomainMap.GetPersistentClassMaps();
			foreach (IClassMap classMap in classMaps) 
			{
				if (!(classMap.SourceClass.Length > 0)) 
				{
					ISourceMap sourceMap = classMap.GetSourceMap();
					if (onlyForComputed && sourceMap != null && sourceMap.Compute)
					{
						if (!((classMap.IsAbstract & (classMap.InheritanceType == InheritanceType.None || (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance & !(classMap.GetInheritedClassMap() == null)))))) 
						{
							if (classMap.GetTableMap() == null) 
							{
								CreateTableForClass(classMap, targetDomainMap, generateMappings);
							}
							if (classMap.TypeColumn.Length > 0 || classMap.InheritanceType != InheritanceType.None) 
							{
								if (classMap.GetTypeColumnMap() == null) 
								{
									CreateTypeColumnForClass(classMap, targetDomainMap, generateMappings);
								}
							}
						}						
					}
				}
			}
			foreach (IClassMap classMap in classMaps) 
			{
				if (!(classMap.SourceClass.Length > 0)) 
				{
					ISourceMap sourceMap = classMap.GetSourceMap();
					if (onlyForComputed && sourceMap != null && sourceMap.Compute)
					{
						if (!((classMap.IsAbstract & (classMap.InheritanceType == InheritanceType.None || (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance & !(classMap.GetInheritedClassMap() == null)))))) 
						{
							if (classMap.InheritanceType == InheritanceType.None) 
							{
								propertyMaps = classMap.GetAllPropertyMaps();
							} 
							else if (classMap.InheritanceType == InheritanceType.SingleTableInheritance || classMap.InheritanceType == InheritanceType.ClassTableInheritance) 
							{
								propertyMaps = classMap.GetNonInheritedPropertyMaps();
							} 
							else if (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance) 
							{
								if (classMap.GetInheritedClassMap() == null) 
								{
									propertyMaps = classMap.GetAllPropertyMaps();
								} 
								else 
								{
									allPropertyMaps = classMap.GetAllPropertyMaps();
									propertyMaps = new ArrayList();
									foreach (IPropertyMap addPropertyMap in allPropertyMaps) 
									{
										if (!(addPropertyMap.IsIdentity)) 
										{
											propertyMaps.Add(addPropertyMap);
										}
									}
								}
							}
							foreach (IPropertyMap propertyMap in propertyMaps) 
							{
								ISourceMap propSourceMap = propertyMap.GetSourceMap();
								if (onlyForComputed && propSourceMap != null && propSourceMap.Compute)
								{
									if (!(propertyMap.InheritInverseMappings)) 
									{
										if (propertyMap.Table.Length > 0 || propertyMap.IsCollection || IsOutbrokenByInheritance(propertyMap, classMap)) 
										{
											ok = true;
											if (propertyMap.IsCollection) 
											{
												if (propertyMap.ReferenceType == ReferenceType.ManyToOne) 
												{
													ok = false;
												}
											}
											if (ok) 
											{
												if (propertyMap.GetTableMap() == null) 
												{
													CreateTableForProperty(propertyMap, targetDomainMap, generateMappings);
												}
											}
										}
									}									
								}
							}
						}						
					}
				}
			}
			foreach (IClassMap classMap in classMaps) 
			{
				if (!(classMap.SourceClass.Length > 0)) 
				{
					ISourceMap sourceMap = classMap.GetSourceMap();
					if (onlyForComputed && sourceMap != null && sourceMap.Compute)
					{
						if (!((classMap.IsAbstract & (classMap.InheritanceType == InheritanceType.None || (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance & !(classMap.GetInheritedClassMap() == null)))))) 
						{
							if (classMap.InheritanceType == InheritanceType.None) 
							{
								propertyMaps = classMap.GetAllPropertyMaps();
							} 
							else if (classMap.InheritanceType == InheritanceType.SingleTableInheritance || classMap.InheritanceType == InheritanceType.ClassTableInheritance) 
							{
								propertyMaps = classMap.GetNonInheritedPropertyMaps();
							} 
							else if (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance) 
							{
								if (classMap.GetInheritedClassMap() == null) 
								{
									propertyMaps = classMap.GetAllPropertyMaps();
								} 
								else 
								{
									allPropertyMaps = classMap.GetAllPropertyMaps();
									propertyMaps = new ArrayList();
									foreach (IPropertyMap addPropertyMap in allPropertyMaps) 
									{
										if (!(addPropertyMap.IsIdentity)) 
										{
											propertyMaps.Add(addPropertyMap);
										}
									}
								}
							}
							foreach (IPropertyMap propertyMap in propertyMaps) 
							{
								ISourceMap propSourceMap = propertyMap.GetSourceMap();
								if (onlyForComputed && propSourceMap != null && propSourceMap.Compute)
								{
									if (!(propertyMap.InheritInverseMappings)) 
									{
										ok = true;
										if (propertyMap.IsCollection) 
										{
											if (propertyMap.ReferenceType == ReferenceType.ManyToOne) 
											{
												ok = false;
											}
										}
										if (ok) 
										{
											if (propertyMap.IdColumn.Length > 0 || propertyMap.IsCollection || propertyMap.Table.Length > 0 || IsOutbrokenByInheritance(propertyMap, classMap)) 
											{
												if (propertyMap.GetIdColumnMap() == null) 
												{
													CreateIDColumnForProperty(propertyMap, targetDomainMap, generateMappings, classMap);
												}
											}
											if (propertyMap.GetColumnMap() == null) 
											{
												CreateColumnForProperty(propertyMap, targetDomainMap, generateMappings, classMap);
											}
										}
									}									
								}
							}
						}						
					}
				}
			}
		}

		protected virtual void CreateTableForClass(IClassMap classMap, IDomainMap targetDomainMap, bool generateMappings)
		{
			ITableMap tableMap = null;
			ISourceMap addToSourceMap = null;
			IClassMap classMapClone = null;
			string name = "";
			ISourceMap sourceMap = classMap.GetSourceMap();
			if (sourceMap == null) 
			{
				sourceMap = classMap.DomainMap.GetSourceMap();
				if (sourceMap == null) 
				{
					throw new Exception("No default data source specified for domain model! Can't add table for class!");
				}
			}
			addToSourceMap = targetDomainMap.GetSourceMap(sourceMap.Name);
			if (addToSourceMap == null) 
			{
				addToSourceMap = (ISourceMap) sourceMap.Clone();
				addToSourceMap.DomainMap = targetDomainMap;
			}
			if (classMap.Table.Length > 0) 
			{
				name = classMap.Table;
			} 
			else 
			{
				name = GetTableNameForClass(classMap);
			}
			tableMap = addToSourceMap.GetTableMap(name);
			if (tableMap == null) 
			{
				tableMap = new TableMap();
				tableMap.Name = name;
				tableMap.SourceMap = addToSourceMap;
			}
			if (generateMappings & classMap.Table.Length < 1) 
			{
				classMapClone = targetDomainMap.GetClassMap(classMap.Name);
				if (classMapClone == null) 
				{
					classMapClone = (IClassMap) classMap.Clone();
					classMapClone.DomainMap = targetDomainMap;
				}
				classMapClone.Table = tableMap.Name;
				if (!(addToSourceMap.Name == targetDomainMap.Source)) 
				{
					classMapClone.Source = addToSourceMap.Name;
				}
				classMapClone.DomainMap = targetDomainMap;
			}
		}

		protected virtual void CreateTypeColumnForClass(IClassMap classMap, IDomainMap targetDomainMap, bool generateMappings)
		{
			ITableMap tableMap = null;
			ISourceMap sourceMap = null;
			ISourceMap addToSourceMap = null;
			IClassMap classMapClone = null;
			IColumnMap columnMap = null;
			string tableName = "";
			string name = "";
			sourceMap = classMap.GetSourceMap();
			if (sourceMap == null) 
			{
				sourceMap = classMap.DomainMap.GetSourceMap();
				if (sourceMap == null) 
				{
					throw new Exception("No default data source specified for domain model! Can't add table for class!");
				}
			}
			addToSourceMap = targetDomainMap.GetSourceMap(sourceMap.Name);
			if (addToSourceMap == null) 
			{
				addToSourceMap = (ISourceMap) sourceMap.Clone();
				addToSourceMap.DomainMap = targetDomainMap;
			}
			if (classMap.Table.Length > 0) 
			{
				tableName = classMap.Table;
			} 
			else 
			{
				tableName = GetTableNameForClass(classMap);
			}
			tableMap = addToSourceMap.GetTableMap(tableName);
			if (tableMap == null) 
			{
				tableMap = new TableMap();
				tableMap.Name = tableName;
				tableMap.SourceMap = addToSourceMap;
			}
			if (classMap.TypeColumn.Length > 0) 
			{
				name = classMap.TypeColumn;
			} 
			else 
			{
				name = GetTypeColumnNameForClass(classMap);
			}
			columnMap = tableMap.GetColumnMap(name);
			if (columnMap == null) 
			{
				columnMap = new ColumnMap();
				columnMap.Name = name;
				columnMap.TableMap = tableMap;
			}
			columnMap.DataType = DbType.AnsiStringFixedLength;
			columnMap.Length = 1;
			columnMap.Precision = 1;
			columnMap.Scale = 0;
			columnMap.IsPrimaryKey = true;
			columnMap.AllowNulls = false;
			if (generateMappings & classMap.TypeColumn.Length < 1) 
			{
				classMapClone = targetDomainMap.GetClassMap(classMap.Name);
				if (classMapClone == null) 
				{
					classMapClone = (IClassMap) classMap.Clone();
					classMapClone.DomainMap = targetDomainMap;
				}
				classMapClone.TypeColumn = name;
			}
		}

		protected virtual void CreateTableForProperty(IPropertyMap propertyMap, IDomainMap targetDomainMap, bool generateMappings)
		{
			IClassMap classMap = propertyMap.ClassMap;
			ITableMap tableMap = null;
			ISourceMap sourceMap = null;
			ISourceMap addToSourceMap = null;
			IClassMap classMapClone = null;
			IPropertyMap propertyMapClone = null;
			string name = "";
			sourceMap = classMap.GetSourceMap();
			if (sourceMap == null) 
			{
				sourceMap = classMap.DomainMap.GetSourceMap();
				if (sourceMap == null) 
				{
					throw new Exception("No default data source specified for domain model! Can't add table for class!");
				}
			}
			addToSourceMap = targetDomainMap.GetSourceMap(sourceMap.Name);
			if (addToSourceMap == null) 
			{
				addToSourceMap = (ISourceMap) sourceMap.Clone();
				addToSourceMap.DomainMap = targetDomainMap;
			}
			if (propertyMap.Table.Length > 0) 
			{
				name = propertyMap.Table;
			} 
			else 
			{
				name = GetTableNameForProperty(propertyMap);
			}
			tableMap = addToSourceMap.GetTableMap(name);
			if (tableMap == null) 
			{
				tableMap = new TableMap();
				tableMap.Name = name;
				tableMap.SourceMap = addToSourceMap;
			}
			if (generateMappings & propertyMap.Table.Length < 1) 
			{
				classMapClone = targetDomainMap.GetClassMap(classMap.Name);
				if (classMapClone == null) 
				{
					classMapClone = (IClassMap) classMap.Clone();
					classMapClone.Table = tableMap.Name;
					if (!(addToSourceMap.Name == targetDomainMap.Source)) 
					{
						classMapClone.Source = addToSourceMap.Name;
					}
					classMapClone.DomainMap = targetDomainMap;
				}
				propertyMapClone = classMapClone.GetPropertyMap(propertyMap.Name);
				if (propertyMapClone == null) 
				{
					propertyMapClone = (IPropertyMap) propertyMap.Clone();
					propertyMapClone.ClassMap = classMapClone;
				}
				propertyMapClone.Table = tableMap.Name;
				if (!(addToSourceMap.Name == classMapClone.Source)) 
				{
					if (!(addToSourceMap.Name == targetDomainMap.Source)) 
					{
						propertyMapClone.Source = addToSourceMap.Name;
					}
				}
			}
		}

		protected virtual void CreateColumnForProperty(IPropertyMap propertyMap, IDomainMap targetDomainMap, bool generateMappings, IClassMap ownerClassMap)
		{
			IClassMap classMap = propertyMap.ClassMap;
			ITableMap tableMap = null;
			ISourceMap sourceMap = null;
			ISourceMap addToSourceMap = null;
			IClassMap classMapClone = null;
			IPropertyMap propertyMapClone = null;
			IColumnMap columnMap = null;
			string classTableName = "";
			string name = "";
			string tableName = "";
			bool allowNulls = false;
			IClassMap refClassMap = null;
			string forTableName = "";
			string forColumnName = "";
			int cnt = 0;
			bool found = false;
			string primColName = "";
			string ownerClassTableName = "";
			string foreignKeyName = "";
			sourceMap = classMap.GetSourceMap();
			if (sourceMap == null) 
			{
				sourceMap = classMap.DomainMap.GetSourceMap();
				if (sourceMap == null) 
				{
					throw new Exception("No default data source specified for domain model! Can't add table for class!");
				}
			}
			addToSourceMap = targetDomainMap.GetSourceMap(sourceMap.Name);
			if (addToSourceMap == null) 
			{
				addToSourceMap = (ISourceMap) sourceMap.Clone();
				addToSourceMap.DomainMap = targetDomainMap;
			}
			if (propertyMap.ClassMap.Table.Length > 0) 
			{
				classTableName = propertyMap.ClassMap.Table;
			} 
			else 
			{
				classTableName = GetTableNameForClass(propertyMap.ClassMap);
			}
			if (propertyMap.Table.Length > 0) 
			{
				tableName = propertyMap.Table;
			} 
			else if (propertyMap.IsCollection) 
			{
				tableName = GetTableNameForProperty(propertyMap);
			} 
			else 
			{
				if (IsOutbrokenByInheritance(propertyMap, ownerClassMap)) 
				{
					ownerClassTableName = GetTableNameForClass(ownerClassMap, true);
					tableName = ownerClassTableName;
				} 
				else 
				{
					tableName = classTableName;
				}
			}
			tableMap = addToSourceMap.GetTableMap(tableName);
			if (tableMap == null) 
			{
				tableMap = new TableMap();
				tableMap.Name = tableName;
				tableMap.SourceMap = addToSourceMap;
			}
			if (propertyMap.Column.Length > 0) 
			{
				name = propertyMap.Column;
			} 
			else 
			{
				name = GetColumnNameForProperty(propertyMap);
			}
			columnMap = tableMap.GetColumnMap(name);
			if (columnMap == null) 
			{
				columnMap = new ColumnMap();
				columnMap.Name = name;
				columnMap.TableMap = tableMap;
			}
			columnMap.DataType = GetColumnTypeForProperty(propertyMap);
			columnMap.Length = GetColumnLengthForProperty(propertyMap);
			columnMap.Precision = GetColumnPrecisionForProperty(propertyMap);
			columnMap.Scale = GetColumnScaleForProperty(propertyMap);
			allowNulls = propertyMap.IsNullable;
			if (propertyMap.IsIdentity) 
			{
				allowNulls = false;
			}
			columnMap.AllowNulls = allowNulls;
			if (propertyMap.IsIdentity) 
			{
				columnMap.IsPrimaryKey = true;
				columnMap.AllowNulls = false;
				if (propertyMap.ReferenceType == ReferenceType.None) 
				{
					if (columnMap.DataType == DbType.Int16 || columnMap.DataType == DbType.Int32 || columnMap.DataType == DbType.Int64) 
					{
						if (propertyMap.ClassMap.GetIdentityPropertyMaps().Count == 1) 
						{
							if (propertyMap.GetIsAssignedBySource()) 
							{
								columnMap.IsAutoIncrease = true;
								columnMap.Seed = 1;
								columnMap.Increment = 1;
							}
						}
					}
				}
			}
			if (!(propertyMap.ReferenceType == ReferenceType.None)) 
			{
				foreignKeyName = "FK_" + columnMap.TableMap.Name + "_" + columnMap.Name;
				refClassMap = propertyMap.GetReferencedClassMap();
				if (!(refClassMap == null)) 
				{
					foreach (IPropertyMap idProp in refClassMap.GetIdentityPropertyMaps()) 
					{
						if (cnt > 0) 
						{
							if (idProp.Column.Length > 0) 
							{
								name = idProp.Column;
							} 
							else 
							{
								name = GetColumnNameForProperty(idProp);
							}
							foreignKeyName += "_" + name;
						}
					}
				}
				primColName = "";
				if (refClassMap.TypeColumn.Length > 0) 
				{
					primColName = refClassMap.TypeColumn;
				} 
				else 
				{
					if (!(refClassMap.InheritanceType == InheritanceType.None)) 
					{
						primColName = GetTypeColumnNameForClass(refClassMap);
					}
				}
				if (primColName.Length > 0) 
				{
					name = propertyMap.Name + "_" + primColName;
					foreignKeyName += "_" + name;
				} 
				else 
				{
					name = propertyMap.Name;
				}
			}
			if (!(propertyMap.ReferenceType == ReferenceType.None)) 
			{
				columnMap.IsForeignKey = true;
				columnMap.ForeignKeyName = foreignKeyName;
				refClassMap = propertyMap.GetReferencedClassMap();
				if (!(refClassMap == null)) 
				{
					if (refClassMap.Table.Length > 0) 
					{
						forTableName = refClassMap.Table;
					} 
					else 
					{
						forTableName = GetTableNameForClass(refClassMap);
					}
					columnMap.PrimaryKeyTable = forTableName;
					foreach (IPropertyMap idProp in refClassMap.GetIdentityPropertyMaps()) 
					{
						if (idProp.Column.Length > 0) 
						{
							forColumnName = idProp.Column;
						} 
						else 
						{
							forColumnName = GetColumnNameForProperty(idProp);
						}
						break;
					}
					columnMap.PrimaryKeyColumn = forColumnName;
				}
			}
			if (generateMappings & propertyMap.Column.Length < 1) 
			{
				classMapClone = targetDomainMap.GetClassMap(classMap.Name);
				if (classMapClone == null) 
				{
					classMapClone = (IClassMap) classMap.Clone();
					if (tableMap.Name == classTableName) 
					{
						classMapClone.Table = tableMap.Name;
						if (!(addToSourceMap.Name == targetDomainMap.Source)) 
						{
							classMapClone.Source = addToSourceMap.Name;
						}
					}
					classMapClone.DomainMap = targetDomainMap;
				}
				propertyMapClone = classMapClone.GetPropertyMap(propertyMap.Name);
				if (propertyMapClone == null) 
				{
					propertyMapClone = (IPropertyMap) propertyMap.Clone();
					propertyMapClone.ClassMap = classMapClone;
				}
				propertyMapClone.Column = columnMap.Name;
				if (!(tableMap.Name == classTableName)) 
				{
					propertyMapClone.Table = tableMap.Name;
					if (!(addToSourceMap.Name == classMapClone.Source)) 
					{
						if (!(addToSourceMap.Name == targetDomainMap.Source)) 
						{
							propertyMapClone.Source = addToSourceMap.Name;
						}
					}
				}
			}
			if (!(propertyMap.ReferenceType == ReferenceType.None)) 
			{
				refClassMap = propertyMap.GetReferencedClassMap();
				if (!(refClassMap == null)) 
				{
					foreach (IPropertyMap idProp in refClassMap.GetIdentityPropertyMaps()) 
					{
						if (cnt > 0) 
						{
							if (idProp.Column.Length > 0) 
							{
								name = idProp.Column;
							} 
							else 
							{
								name = GetColumnNameForProperty(idProp);
							}
							columnMap = tableMap.GetColumnMap(name);
							if (columnMap == null) 
							{
								columnMap = new ColumnMap();
								columnMap.Name = name;
								columnMap.TableMap = tableMap;
							}
							columnMap.DataType = GetColumnTypeForProperty(idProp);
							columnMap.Length = GetColumnLengthForProperty(idProp);
							columnMap.Precision = GetColumnPrecisionForProperty(idProp);
							columnMap.Scale = GetColumnScaleForProperty(idProp);
							columnMap.IsForeignKey = true;
							columnMap.ForeignKeyName = foreignKeyName;
							columnMap.PrimaryKeyTable = forTableName;
							if (idProp.Column.Length > 0) 
							{
								forColumnName = idProp.Column;
							} 
							else 
							{
								forColumnName = GetColumnNameForProperty(idProp);
							}
							columnMap.PrimaryKeyColumn = forColumnName;
							if (generateMappings) 
							{
								classMapClone = targetDomainMap.GetClassMap(classMap.Name);
								if (classMapClone == null) 
								{
									classMapClone = (IClassMap) classMap.Clone();
									if (tableMap.Name == classTableName) 
									{
										classMapClone.Table = tableMap.Name;
										if (!(addToSourceMap.Name == targetDomainMap.Source)) 
										{
											classMapClone.Source = addToSourceMap.Name;
										}
									}
									classMapClone.DomainMap = targetDomainMap;
								}
								propertyMapClone = classMapClone.GetPropertyMap(propertyMap.Name);
								if (propertyMapClone == null) 
								{
									propertyMapClone = (IPropertyMap) propertyMap.Clone();
									propertyMapClone.ClassMap = classMapClone;
									if (!(tableMap.Name == classTableName)) 
									{
										propertyMapClone.Table = tableMap.Name;
										if (!(addToSourceMap.Name == classMapClone.Source)) 
										{
											if (!(addToSourceMap.Name == targetDomainMap.Source)) 
											{
												propertyMapClone.Source = addToSourceMap.Name;
											}
										}
									}
								}
								found = false;
								foreach (string iterName in propertyMapClone.AdditionalColumns) 
								{
									if (iterName == columnMap.Name) 
									{
										found = true;
									}
								}
								if (!(found)) 
								{
									propertyMapClone.AdditionalColumns.Add(columnMap.Name);
								}
							}
						}
						cnt += 1;
					}
					if (refClassMap.InheritanceType != InheritanceType.None) 
					{
						if (refClassMap.TypeColumn.Length > 0) 
						{
							primColName = refClassMap.TypeColumn;
						} 
						else 
						{
							primColName = GetTypeColumnNameForClass(refClassMap);
						}
						name = propertyMap.Name + "_" + primColName;
						columnMap = tableMap.GetColumnMap(name);
						if (columnMap == null) 
						{
							columnMap = new ColumnMap();
							columnMap.Name = name;
							columnMap.TableMap = tableMap;
						}
						columnMap.DataType = DbType.AnsiStringFixedLength;
						columnMap.Length = 1;
						columnMap.Precision = 1;
						columnMap.Scale = 0;
						columnMap.AllowNulls = true;
						if (propertyMap.IsIdentity) 
						{
							columnMap.AllowNulls = false;
						}
						columnMap.IsForeignKey = true;
						columnMap.ForeignKeyName = foreignKeyName;
						columnMap.PrimaryKeyTable = forTableName;
						columnMap.PrimaryKeyColumn = primColName;
						if (generateMappings) 
						{
							classMapClone = targetDomainMap.GetClassMap(classMap.Name);
							if (classMapClone == null) 
							{
								classMapClone = (IClassMap) classMap.Clone();
								if (tableMap.Name == classTableName) 
								{
									classMapClone.Table = tableMap.Name;
									if (!(addToSourceMap.Name == targetDomainMap.Source)) 
									{
										classMapClone.Source = addToSourceMap.Name;
									}
								}
								classMapClone.DomainMap = targetDomainMap;
							}
							propertyMapClone = classMapClone.GetPropertyMap(propertyMap.Name);
							if (propertyMapClone == null) 
							{
								propertyMapClone = (IPropertyMap) propertyMap.Clone();
								propertyMapClone.ClassMap = classMapClone;
								if (!(tableMap.Name == classTableName)) 
								{
									propertyMapClone.Table = tableMap.Name;
									if (!(addToSourceMap.Name == classMapClone.Source)) 
									{
										if (!(addToSourceMap.Name == targetDomainMap.Source)) 
										{
											propertyMapClone.Source = addToSourceMap.Name;
										}
									}
								}
							}
							found = false;
							foreach (string iterName in propertyMapClone.AdditionalColumns) 
							{
								if (iterName == columnMap.Name) 
								{
									found = true;
								}
							}
							if (!(found)) 
							{
								propertyMapClone.AdditionalColumns.Add(columnMap.Name);
							}
						}
					}
				}
			}
		}

		protected virtual void CreateIDColumnForProperty(IPropertyMap propertyMap, IDomainMap targetDomainMap, bool generateMappings, IClassMap ownerClassMap)
		{
			IClassMap classMap = propertyMap.ClassMap;
			ITableMap tableMap = null;
			ISourceMap sourceMap = null;
			ISourceMap addToSourceMap = null;
			IClassMap classMapClone = null;
			IPropertyMap propertyMapClone = null;
			IColumnMap columnMap = null;
			string classTableName = "";
			string ownerClassTableName = "";
			string name = "";
			string forColName = "";
			string tableName = "";
			string foreignKeyName = "";
			bool isClassTableOrConcrete = false;
			sourceMap = classMap.GetSourceMap();
			if (sourceMap == null) 
			{
				sourceMap = classMap.DomainMap.GetSourceMap();
				if (sourceMap == null) 
				{
					throw new Exception("No default data source specified for domain model! Can't add table for class!");
				}
			}
			addToSourceMap = targetDomainMap.GetSourceMap(sourceMap.Name);
			if (addToSourceMap == null) 
			{
				addToSourceMap = (ISourceMap) sourceMap.Clone();
				addToSourceMap.DomainMap = targetDomainMap;
			}
			if (propertyMap.ClassMap.Table.Length > 0) 
			{
				classTableName = propertyMap.ClassMap.Table;
			} 
			else 
			{
				classTableName = GetTableNameForClass(propertyMap.ClassMap);
			}
			if (propertyMap.Table.Length > 0) 
			{
				tableName = propertyMap.Table;
			} 
			else if (propertyMap.IsCollection) 
			{
				tableName = GetTableNameForProperty(propertyMap);
			} 
			else 
			{
				if (IsOutbrokenByInheritance(propertyMap, ownerClassMap)) 
				{
					isClassTableOrConcrete = true;
					ownerClassTableName = GetTableNameForClass(ownerClassMap, true);
					tableName = ownerClassTableName;
				} 
				else 
				{
					tableName = classTableName;
				}
			}
			tableMap = addToSourceMap.GetTableMap(tableName);
			if (tableMap == null) 
			{
				tableMap = new TableMap();
				tableMap.Name = tableName;
				tableMap.SourceMap = addToSourceMap;
			}
			foreignKeyName = "FK_" + tableMap.Name;
			foreach (IPropertyMap idPropertyMap in propertyMap.ClassMap.GetIdentityPropertyMaps()) 
			{
				if (idPropertyMap.Column.Length > 0) 
				{
					forColName = idPropertyMap.Column;
				} 
				else 
				{
					forColName = GetColumnNameForProperty(idPropertyMap);
				}
				foreignKeyName += "_" + forColName;
			}
			if (!(classMap.InheritanceType == InheritanceType.None)) 
			{
				if (classMap.TypeColumn.Length > 0) 
				{
					foreignKeyName += "_" + classMap.TypeColumn;
				} 
				else 
				{
					foreignKeyName += "_" + GetTypeColumnNameForClass(classMap);
				}
			}
			foreach (IPropertyMap idPropertyMap in propertyMap.ClassMap.GetIdentityPropertyMaps()) 
			{
				if (idPropertyMap.Column.Length > 0) 
				{
					forColName = idPropertyMap.Column;
				} 
				else 
				{
					forColName = GetColumnNameForProperty(idPropertyMap);
				}
				if (propertyMap.IdColumn.Length > 0) 
				{
					name = propertyMap.IdColumn;
				} 
				else 
				{
					name = forColName;
				}
				columnMap = tableMap.GetColumnMap(name);
				if (columnMap == null) 
				{
					columnMap = new ColumnMap();
					columnMap.Name = name;
					columnMap.TableMap = tableMap;
				}
				columnMap.DataType = GetColumnTypeForProperty(idPropertyMap);
				columnMap.Length = GetColumnLengthForProperty(idPropertyMap);
				columnMap.Precision = GetColumnPrecisionForProperty(idPropertyMap);
				columnMap.Scale = GetColumnScaleForProperty(idPropertyMap);
				if (!(propertyMap.IsCollection)) 
				{
					columnMap.IsPrimaryKey = true;
					columnMap.AllowNulls = false;
				}
				if (propertyMap.IsCollection || propertyMap.Table.Length > 0 || isClassTableOrConcrete) 
				{
					columnMap.IsForeignKey = true;
					columnMap.PrimaryKeyTable = classTableName;
					columnMap.PrimaryKeyColumn = forColName;
					columnMap.ForeignKeyName = foreignKeyName;
				}
				if (generateMappings & propertyMap.IdColumn.Length < 1) 
				{
					classMapClone = targetDomainMap.GetClassMap(classMap.Name);
					if (classMapClone == null) 
					{
						classMapClone = (IClassMap) classMap.Clone();
						classMapClone.DomainMap = targetDomainMap;
					}
					propertyMapClone = classMapClone.GetPropertyMap(propertyMap.Name);
					if (propertyMapClone == null) 
					{
						propertyMapClone = (IPropertyMap) propertyMap.Clone();
						propertyMapClone.ClassMap = classMapClone;
					}
					propertyMapClone.IdColumn = columnMap.Name;
					if (tableMap.Name != classTableName) 
					{
						propertyMapClone.Table = tableMap.Name;
						if (!(addToSourceMap.Name == classMapClone.Source)) 
						{
							if (!(addToSourceMap.Name == targetDomainMap.Source)) 
							{
								propertyMapClone.Source = addToSourceMap.Name;
							}
						}
					}
				}
			}
			if (classMap.InheritanceType != InheritanceType.None) 
			{
				if (classMap.TypeColumn.Length > 0) 
				{
					name = classMap.TypeColumn;
				} 
				else 
				{
					name = GetTypeColumnNameForClass(classMap);
				}
				columnMap = tableMap.GetColumnMap(name);
				if (columnMap == null) 
				{
					columnMap = new ColumnMap();
					columnMap.Name = name;
					columnMap.TableMap = tableMap;
				}
				columnMap.DataType = DbType.AnsiStringFixedLength;
				columnMap.Length = 1;
				columnMap.Precision = 1;
				columnMap.Scale = 0;
				if (!(propertyMap.IsCollection)) 
				{
					columnMap.IsPrimaryKey = true;
					columnMap.ForeignKeyName = foreignKeyName;
					columnMap.AllowNulls = false;
				}
				columnMap.IsForeignKey = true;
				columnMap.PrimaryKeyTable = classTableName;
				columnMap.PrimaryKeyColumn = name;
				if (generateMappings) 
				{
					classMapClone = targetDomainMap.GetClassMap(classMap.Name);
					if (classMapClone == null) 
					{
						classMapClone = (IClassMap) classMap.Clone();
						classMapClone.DomainMap = targetDomainMap;
					}
					propertyMapClone = classMapClone.GetPropertyMap(propertyMap.Name);
					if (propertyMapClone == null) 
					{
						propertyMapClone = (IPropertyMap) propertyMap.Clone();
						propertyMapClone.ClassMap = classMapClone;
					}
					foreach (string iterName in propertyMapClone.AdditionalIdColumns) 
					{
						if (iterName == columnMap.Name) 
						{
							return;
						}
					}
					propertyMapClone.AdditionalIdColumns.Add(columnMap.Name);
				}
			}
		}

		protected virtual bool IsOutbrokenByInheritance(IPropertyMap propertyMap, IClassMap classMap)
		{
			if (((classMap.InheritanceType == InheritanceType.ClassTableInheritance || classMap.InheritanceType == InheritanceType.ConcreteTableInheritance) && !(classMap.GetInheritedClassMap() == null && (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance || classMap.IsInheritedProperty(propertyMap) == false)))) 
			{
				return true;
			}
			return false;
		}

	}
}
