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
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Attributes;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class PropertyMap : MapBase, IPropertyMap
	{
				
		public override void Accept(IMapVisitor visitor) => visitor.Visit(this);

	    public override IMap GetParent() => m_ClassMap;

	    #region Private Member Variables

		//O/R Mapping
		private IClassMap m_ClassMap;
		private string m_Name = "";
		private string m_ValidateMethod = "";
		private string m_FieldName = "";
		private string m_DataType = "";
		private string m_ItemType = "";
		private string m_DefaultValue = "";
		private bool m_IsGenerated = false;
		private bool m_IsCollection = false;
		private bool m_IsIdentity = false;
		private int m_IdentityIndex = 0;
		private bool m_IsKey = false;
		private int m_KeyIndex = 0;
		private string m_IdentityGenerator = "";
		private bool m_IsNullable = false;
		private bool m_IsAssignedBySource = false;
		private int m_MaxLength = -1;
		private int m_MinLength = -1;
		private string m_MaxValue = "";
		private string m_MinValue = "";
		private string m_Source = "";
		private string m_Table = "";
		private string m_Column = "";
		private string m_IdColumn = "";
		private ArrayList m_AdditionalColumns = new ArrayList();
		private ArrayList m_AdditionalIdColumns = new ArrayList();
		private string m_Inverse = "";
		private bool m_LazyLoad = false;
		private bool m_IsReadOnly = false;
		private bool m_IsSlave = false;
		private string m_NullSubstitute = "";
		private bool m_NoInverseManagement = false;
		private bool m_InheritInverseMappings = false;
		private ReferenceType m_ReferenceType = ReferenceType.None;
		private ReferenceQualifier m_ReferenceQualifier = ReferenceQualifier.Default;
		private bool m_CascadingCreate = false;
		private bool m_CascadingDelete = false;
		private AccessibilityType m_Accessibility = AccessibilityType.PublicAccess;
		private AccessibilityType m_FieldAccessibility = AccessibilityType.PrivateAccess;
		private OptimisticConcurrencyBehaviorType m_UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_DeleteOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private PropertySpecialBehaviorType m_OnCreateBehavior = PropertySpecialBehaviorType.None;
		private PropertySpecialBehaviorType m_OnPersistBehavior = PropertySpecialBehaviorType.None;
		private string m_OrderBy = "";
		private PropertyModifier m_PropertyModifier = PropertyModifier.Default;
		private MergeBehaviorType m_MergeBehavior = MergeBehaviorType.DefaultBehavior;
		private RefreshBehaviorType m_RefreshBehavior = RefreshBehaviorType.DefaultBehavior;
		private ValidationMode m_ValidationMode = ValidationMode.Default;
		private LoadBehavior m_ListCountLoadBehavior = LoadBehavior.Default;
		private long m_TimeToLive = -1;
		private TimeToLiveBehavior m_TimeToLiveBehavior = TimeToLiveBehavior.Default ;
		private string commitRegions = "";

		//O/O Mapping
		private string m_SourceProperty = "";

		//O/D Mapping
		private string m_DocSource = "";
		private string m_DocAttribute = "";
		private string m_DocElement = "";
		private DocPropertyMapMode m_DocPropertyMapMode = DocPropertyMapMode.Default;

		//misc
		private bool isFixed = false;

		#endregion

		#region Constructors

		public PropertyMap() : base()
		{
		}

		public PropertyMap(string name) : base() => m_Name = name;

	    #endregion

		#region Object/Relational Mapping

		[XmlIgnore()]
		public virtual IClassMap ClassMap
		{
			get => m_ClassMap;
		    set
			{
				if (m_ClassMap != null)
				{
					m_ClassMap.PropertyMaps.Remove(this);
				}
				m_ClassMap = value;
				if (m_ClassMap != null)
				{
					m_ClassMap.PropertyMaps.Add(this);
				}
			}
		}

		public virtual void SetClassMap(IClassMap value) => m_ClassMap = value;

	    public override string Name
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_Name;
	        //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_Name = value;
	    }

		public virtual bool IsGenerated
		{
			get => m_IsGenerated;
		    set => m_IsGenerated = value;
		}

		
		public virtual string ValidateMethod
		{
			get => m_ValidateMethod;
		    set => m_ValidateMethod = value;
		}


		public virtual string FieldName
		{
			get => m_FieldName;
		    set => m_FieldName = value;
		}

		public virtual bool IsNullable
		{
			get => m_IsNullable;
		    set => m_IsNullable = value;
		}

		public virtual bool IsAssignedBySource
		{
			get => m_IsAssignedBySource;
		    set => m_IsAssignedBySource = value;
		}
		public virtual int MaxLength
		{
			get => m_MaxLength;
		    set => m_MaxLength = value;
		}

		public virtual int MinLength
		{
			get => m_MinLength;
		    set => m_MinLength = value;
		}

		public virtual string MaxValue
		{
			get => m_MaxValue;
		    set => m_MaxValue = value;
		}

		public virtual string MinValue
		{
			get => m_MinValue;
		    set => m_MinValue = value;
		}

		private bool fixedGetIsNullable = false;
		private bool fixedValueGetIsNullable = false;

        //Because there is no difference in the table model when 
        //the slave table has the same number of rows as the master table 
        //(for example: Users and Profiles)) and when the slave table
        //has more rows than the master, it is not dicernable from the 
        //table model if the slave property in a OneToOne relationship
        //is nullable or not! Thus we have to use the Nullable attribute
        //of the propertyMap for a slave OneToOne property!!
		public virtual bool GetIsNullable()
		{
			if (fixedGetIsNullable)
				return fixedValueGetIsNullable;
			
			bool isNullable = false;
			IColumnMap columnMap = null;
            if (this.ReferenceType == ReferenceType.OneToOne && this.IsSlave)
            {
                //This would have worked if it wasn't for the fact that when 
                //the id column is /not/ nullable, the slave OneToOne property 
                //may still be nullable if the slave table contains more rows
                //than the master table (see comment ^^)
			    //columnMap = this.GetIdColumnMap();
            }
            else
            {
			    columnMap = this.GetColumnMap();
            }
            if (columnMap != null)
            {
                isNullable = columnMap.AllowNulls;
            }
            else
            {
                isNullable = this.m_IsNullable;
            }
			if (isFixed)
			{
				fixedValueGetIsNullable = isNullable;
				fixedGetIsNullable = true;
			}

            return isNullable;
		}

		private bool fixedGetIsAssignedBySource = false;
		private bool fixedValueGetIsAssignedBySource = false;

		public virtual bool GetIsAssignedBySource()
		{
			if (fixedGetIsAssignedBySource)
				return fixedValueGetIsAssignedBySource;

			bool isAssignedBySource = this.m_IsAssignedBySource;

			IColumnMap columnMap = this.GetColumnMap();
			if (columnMap != null)
			{
				//KS: We fix it, since this is a one-to-one
				if (columnMap.IsAutoIncrease && !this.CascadingCreate)
				{
					isAssignedBySource = true;
				}
			}
			if (isFixed)
			{
				fixedValueGetIsAssignedBySource = isAssignedBySource;
				fixedGetIsAssignedBySource = true;
			}

			return isAssignedBySource;
		}

		private bool fixedGetMaxLength = false;
		private int fixedValueGetMaxLength = 0;

		public virtual int GetMaxLength()
		{
			if (fixedGetMaxLength)
				return fixedValueGetMaxLength;

			int maxLength = this.m_MaxLength;
			if (!this.IsCollection)
			{
				IColumnMap columnMap = this.GetColumnMap();
				if (columnMap != null)
				{
					switch (columnMap.DataType)
					{
						case DbType.AnsiString :
							maxLength = columnMap.Precision ;
							break;
						case DbType.AnsiStringFixedLength :
							maxLength = columnMap.Precision ;
							break;
						case DbType.String  :
							maxLength = columnMap.Precision ;
							break;
						case DbType.StringFixedLength :
							maxLength = columnMap.Precision ;
							break;
					}
				}
			}
			if (isFixed)
			{
				fixedValueGetMaxLength = maxLength;
				fixedGetMaxLength = true;
			}

			return maxLength;
		}

		private bool fixedGetFieldName = false;
		private string fixedValueGetFieldName = "";

		public virtual string GetFieldName()
		{
			if (fixedGetFieldName)
				return fixedValueGetFieldName;

			string fn;
			fn = GenerateFieldName();

			if (isFixed)
			{
				fixedValueGetFieldName = fn;
				fixedGetFieldName = true;
			}

			return fn;
		}

		public string GenerateFieldName()
		{
			string fn;
			if (m_FieldName == "")
			{
				fn = GenerateMemberName(m_Name);
			}
			else
			{
				fn = m_FieldName;
			}
			return fn;
		}

		public string GenerateMemberName(string name)
		{
			string fn;
			IDomainMap dm = ClassMap.DomainMap;
			string pre = dm.FieldPrefix;
			string strategyName = "";
			if (dm.FieldNameStrategy == FieldNameStrategyType.None)
			{
				strategyName = name;
			}
			else if (dm.FieldNameStrategy == FieldNameStrategyType.CamelCase)
			{
				strategyName = name.Substring(0, 1).ToLower(CultureInfo.InvariantCulture) + name.Substring(1);
			}
			else if (dm.FieldNameStrategy == FieldNameStrategyType.PascalCase)
			{
				strategyName = name.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture) + name.Substring(1);
			}
            else if (dm.FieldNameStrategy == FieldNameStrategyType.LowerCase)
            {
                strategyName = name.ToLower(CultureInfo.InvariantCulture);
            }
            else if (dm.FieldNameStrategy == FieldNameStrategyType.UpperCase)
            {
                strategyName = name.ToUpper(CultureInfo.InvariantCulture);
            }
            if (pre.Length > 0)
			{
				fn = pre + strategyName;

			}
			else
			{
				if (!(strategyName == name))
				{
					fn = strategyName;
				}
				else
				{
					if (!(name.Substring(0, 1) == name.Substring(0, 1).ToLower(CultureInfo.InvariantCulture)))
					{
						fn = name.Substring(0, 1).ToLower(CultureInfo.InvariantCulture) + name.Substring(1);
					}
					else
					{
						fn = "m_" + name;
					}
				}
			}
			return fn;
		}

		private bool fixedGetDataType = false;
		private string fixedValueGetDataType = "";

		public virtual string DataType
		{
			get
			{
				if (fixedGetDataType)
					return fixedValueGetDataType;

				string dataType = m_DataType;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					if (inv.ReferenceType == ReferenceType.ManyToMany || inv.ReferenceType == ReferenceType.OneToMany)
					{
						if (m_DataType == "")
						{
							if (m_IsCollection)
							{
								dataType = "System.Collections.IList";
							}
						}
					}
					else if (inv.ReferenceType == ReferenceType.ManyToOne || inv.ReferenceType == ReferenceType.OneToOne)
					{
						dataType = inv.ClassMap.Name;
					}
				}
				else
				{
					if (IsSlave == false && IsCollection && ReferenceType == ReferenceType.ManyToMany && Inverse.Length > 0 && NoInverseManagement == false)
					{
						dataType = "System.Collections.IList";
					}
					if (m_DataType == "")
					{
						if (m_IsCollection)
						{
							dataType = "System.Collections.IList";
						}
					}
				}

				if (isFixed)
				{
					fixedValueGetDataType = dataType;
					fixedGetDataType = true;
				}

				return dataType;
			}
			set => m_DataType = value;
		}

		private bool fixedGetItemType = false;
		private string fixedValueGetItemType = "";

		public virtual string ItemType
		{
			get
			{
				if (fixedGetItemType)
					return fixedValueGetItemType;

				string itemType = m_ItemType;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					if (inv.ReferenceType == ReferenceType.ManyToMany || inv.ReferenceType == ReferenceType.OneToMany)
					{
						itemType = inv.ClassMap.Name;
					}
					else if (inv.ReferenceType == ReferenceType.ManyToOne || inv.ReferenceType == ReferenceType.OneToOne)
					{
						itemType = m_ItemType;
					}
				}

				if (isFixed)
				{
					fixedValueGetItemType = itemType;
					fixedGetItemType = true;
				}

				return itemType;
			}
			set => m_ItemType = value;
		}

		public virtual string DefaultValue
		{
			get
			{
				if (IsCollection)
				{
					return "";
				}
				else
				{
					return m_DefaultValue;
				}
			}
			set => m_DefaultValue = value;
		}

		private bool fixedGetIsCollection = false;
		private bool fixedValueGetIsCollection = false;

		public virtual bool IsCollection
		{
			get
			{
				if (fixedGetIsCollection)
					return fixedValueGetIsCollection;

                bool isCollection = false;
				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					if (inv.ReferenceType == ReferenceType.ManyToMany || inv.ReferenceType == ReferenceType.OneToMany)
					{
						isCollection = true;
					}
                    else if (inv.ReferenceType == ReferenceType.ManyToOne || inv.ReferenceType == ReferenceType.OneToOne)
                    {
                        isCollection = false;
                    }
                    else
                    {
                        isCollection = false;
                    }
				}
				else
				{
                    isCollection = m_IsCollection;
				}

				if (isFixed)
				{
					fixedValueGetIsCollection = isCollection;
					fixedGetIsCollection = true;
				}
				return isCollection;
            }
			set => m_IsCollection = value;
		}

		public virtual IClassMap MustGetReferencedClassMap()
		{
			IClassMap classMap = GetReferencedClassMap();

			if (classMap == null)
			{
				string className;
				if (m_IsCollection)
				{
					className = m_ItemType;
				}
				else
				{
					className = m_DataType;
				}
				
				throw new MappingException("Could not find type " + className + ", referenced by property " + this.ClassMap.Name + "." + this.Name + ", in map file!");
			}

			return classMap;
		}

		private bool fixedGetReferencedClassMap = false;
		private IClassMap fixedValueGetReferencedClassMap = null;

		public virtual IClassMap GetReferencedClassMap()
		{
			if (fixedGetReferencedClassMap)
				return fixedValueGetReferencedClassMap;

			IClassMap classMap = null;

			if (m_ReferenceType != ReferenceType.None)
			{
				string className;
				if (m_IsCollection)
					className = m_ItemType;
				else
					className = m_DataType;

				if (className.Length > 0)
				{
					string ns;
					classMap = m_ClassMap.DomainMap.GetClassMap(className);
					if (classMap == null)
					{
						ns = m_ClassMap.GetNamespace();
						if (ns.Length > 0)
							classMap = m_ClassMap.DomainMap.GetClassMap(ns + "." + className);
					}
				}
			}
			if (isFixed)
			{
				fixedValueGetReferencedClassMap = classMap;
				fixedGetReferencedClassMap = true;
			}

			return classMap;
		}

		private bool fixedGetSource = false;
		private string fixedValueGetSource = null;

		public virtual string Source
		{
			get
			{
				if (fixedGetSource)
					return fixedValueGetSource;

				string source = m_Source;
				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					source = inv.Source;
				}

				if (isFixed)
				{
					fixedValueGetSource = source;
					fixedGetSource = true;
				}

				return source;
			}
			set => m_Source = value;
		}

		private bool fixedGetSourceMap = false;
		private ISourceMap fixedValueGetSourceMap = null;

		public virtual ISourceMap GetSourceMap()
		{
			if (fixedGetSourceMap)
				return fixedValueGetSourceMap;

			ISourceMap sourceMap = null;

			if (this.Source == "")
			{
				sourceMap = m_ClassMap.GetSourceMap();
			}
			else
			{
				sourceMap = m_ClassMap.DomainMap.GetSourceMap(this.Source);
			}

			if (isFixed)
			{
				fixedValueGetSourceMap = sourceMap;
				fixedGetSourceMap = true;
			}

			return sourceMap;
		}

		public virtual void SetSourceMap(ISourceMap value) => m_Source = value.Name;

	    private bool fixedGetTable = false;
		private string fixedValueGetTable = "";

		public virtual string Table
		{
			get
			{
				if (fixedGetTable)
					return fixedValueGetTable;

				string table = m_Table;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					if (inv.Table.Length < 1)
						table = inv.ClassMap.Table;
					else
						table = inv.Table;
				}

				if (isFixed)
				{
					fixedValueGetTable = table;
					fixedGetTable = true;
				}

				return table;
			}
			set => m_Table = value;
		}


		public virtual ITableMap MustGetTableMap()
		{
			ITableMap tableMap = GetTableMap();

			if (tableMap == null)
				throw new MappingException("Could not find table " + m_Table + ", mapped to by property " + this.ClassMap.Name + "." + this.Name + ", in map file!");

			return tableMap;
		}

		private bool fixedGetTableMap = false;
		private ITableMap fixedValueGetTableMap = null;

		public virtual ITableMap GetTableMap()
		{
			if (fixedGetTableMap)
				return fixedValueGetTableMap;

			ITableMap tableMap = null;

			if (this.Table == "")
			{
				tableMap = m_ClassMap.GetTableMap();
			}
			else
			{
				ISourceMap sourceMap = GetSourceMap();
				if (sourceMap != null)
				{
					tableMap = GetSourceMap().GetTableMap(this.Table);
				}
			}

			if (isFixed)
			{
				fixedValueGetTableMap = tableMap;
				fixedGetTableMap = true;
			}

			return tableMap;
		}

		public virtual void SetTableMap(ITableMap value) => m_Table = value.Name;

	    private bool fixedGetColumn = false;
		private string fixedValueGetColumn = "";

		public virtual string Column
		{
			get
			{
				if (fixedGetColumn)
					return fixedValueGetColumn;

				string column = m_Column;

				if (DoesInheritInverseMappings())
				{
					if (ReferenceType == ReferenceType.ManyToOne)
						column = "";
					else
					{
						IPropertyMap inv = GetInversePropertyMap();
						if (inv.IdColumn.Length > 0)
						{
							column = inv.IdColumn;
						}
						else
						{
							ArrayList idProps = inv.ClassMap.GetIdentityPropertyMaps();
							if (idProps.Count == 1)
							{
								column = ((IPropertyMap) (idProps[0])).Column;
							}
						}
					}
				}

				if (isFixed)
				{
					fixedValueGetColumn = column;
					fixedGetColumn = true;
				}

				return column;
			}
			set => m_Column = value;
		}

		public virtual IColumnMap MustGetColumnMap()
		{
			IColumnMap columnMap = GetColumnMap();

			if (columnMap == null)
				throw new MappingException("Could not find column '" + this.Column + "' for the property " + this.Name + " of type " + this.ClassMap.GetFullName() + " in map file!");

			return columnMap;
		}

		private bool fixedGetColumnMap = false;
		private IColumnMap fixedValueGetColumnMap = null;

		public virtual IColumnMap GetColumnMap()
		{
			if (fixedGetColumnMap)
				return fixedValueGetColumnMap;

			IColumnMap columnMap = null;

			if (this.Column.Length > 0)
			{
				ITableMap tableMap = GetTableMap();
				if (tableMap != null)
				{
					columnMap = tableMap.GetColumnMap(this.Column);
				}
			}

			if (isFixed)
			{
				fixedValueGetColumnMap = columnMap;
				fixedGetColumnMap = true;
			}

			return columnMap;
		}

		public virtual void SetColumnMap(IColumnMap value) => m_Column = value.Name;

	    private bool fixedGetIdColumn = false;
		private string fixedValueGetIdColumn = "";

		public virtual string IdColumn
		{
			get
			{
				if (fixedGetIdColumn)
					return fixedValueGetIdColumn;

				string idColumn = m_IdColumn;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					idColumn = inv.Column;
				}

				if (isFixed)
				{
					fixedValueGetIdColumn = idColumn;
					fixedGetIdColumn = true;
				}

				return idColumn;
			}
			set => m_IdColumn = value;
		}

		private bool fixedGetIdColumnMap = false;
		private IColumnMap fixedValueGetIdColumnMap = null;

		public virtual IColumnMap GetIdColumnMap()
		{
			if (fixedGetIdColumnMap)
				return fixedValueGetIdColumnMap;

			IColumnMap idColumnMap = null;

			if (this.IdColumn.Length > 0)
			{
				ITableMap tableMap = GetTableMap();
				if (tableMap != null)
				{
					idColumnMap = tableMap.GetColumnMap(this.IdColumn);
				}
			}

			if (isFixed)
			{
				fixedValueGetIdColumnMap = idColumnMap;
				fixedGetIdColumnMap = true;
			}

			return idColumnMap;
		}

		public virtual void SetIdColumnMap(IColumnMap value) => m_IdColumn = value.Name;

	    private bool fixedGetAdditionalColumns = false;
		private ArrayList fixedValueGetAdditionalColumns = null;

		[XmlArrayItem(typeof (string))]
		public virtual ArrayList AdditionalColumns
		{
			get
			{
				if (fixedGetAdditionalColumns)
					return fixedValueGetAdditionalColumns;

				ArrayList additionalColumns = m_AdditionalColumns;

				if (DoesInheritInverseMappings())
				{
					if (ReferenceType == ReferenceType.ManyToOne)
					{
						additionalColumns = new ArrayList();
					}
					else
					{
						IPropertyMap inv = GetInversePropertyMap();
						additionalColumns = inv.AdditionalIdColumns;						
					}
				}

				if (isFixed)
				{
					fixedValueGetAdditionalColumns = additionalColumns;
					fixedGetAdditionalColumns = true;
				}

				return additionalColumns;
			}
			set => m_AdditionalColumns = value;
		}

		private bool fixedGetAdditionalColumnMaps = false;
		private ArrayList fixedValueGetAdditionalColumnMaps = null;

		public virtual ArrayList GetAdditionalColumnMaps()
		{
			if (fixedGetAdditionalColumnMaps)
				return fixedValueGetAdditionalColumnMaps;

			ArrayList columnMaps = new ArrayList();
			ITableMap tableMap = GetTableMap();
			if (tableMap != null)
			{
				IColumnMap columnMap;
				foreach (string colName in AdditionalColumns)
				{
					columnMap = tableMap.GetColumnMap(colName);
					if (columnMap != null)
					{
						columnMaps.Add(columnMap);
					}
				}
			}

			if (isFixed)
			{
				fixedValueGetAdditionalColumnMaps = columnMaps;
				fixedGetAdditionalColumnMaps = true;
			}

			return columnMaps;
		}

		private bool fixedGetAdditionalIdColumns = false;
		private ArrayList fixedValueGetAdditionalIdColumns = null;

		[XmlArrayItem(typeof (string))]
		public virtual ArrayList AdditionalIdColumns
		{
			get
			{
				if (fixedGetAdditionalIdColumns)
					return fixedValueGetAdditionalIdColumns;

				ArrayList additionalIdColumns = m_AdditionalIdColumns;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					additionalIdColumns = inv.AdditionalColumns;
				}

				if (isFixed)
				{
					fixedValueGetAdditionalIdColumns = additionalIdColumns;
					fixedGetAdditionalIdColumns = true;
				}

				return additionalIdColumns;
			}
			set => m_AdditionalIdColumns = value;
		}

		private bool fixedGetAdditionalIdColumnMaps = false;
		private ArrayList fixedValueGetAdditionalIdColumnMaps = null;

		public virtual ArrayList GetAdditionalIdColumnMaps()
		{
			if (fixedGetAdditionalIdColumnMaps)
				return fixedValueGetAdditionalIdColumnMaps;

			ArrayList columnMaps = new ArrayList();
			ITableMap tableMap = GetTableMap();
			if (tableMap != null)
			{
				IColumnMap columnMap;
				foreach (string colName in AdditionalIdColumns)
				{
					columnMap = tableMap.GetColumnMap(colName);
					if (columnMap != null)
					{
						columnMaps.Add(columnMap);
					}
				}
			}

			if (isFixed)
			{
				fixedValueGetAdditionalIdColumnMaps = columnMaps;
				fixedGetAdditionalIdColumnMaps = true;
			}

			return columnMaps;
		}

		private bool fixedGetInverse = false;
		private string fixedValueGetInverse = null;

		public virtual string Inverse
		{
			get
			{
				if (fixedGetInverse)
					return fixedValueGetInverse;

				string inverse = m_Inverse;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					inverse = inv.Name;
				}

				if (isFixed)
				{
					fixedValueGetInverse = inverse;
					fixedGetInverse = true;
				}

				return inverse;
			}
			set => m_Inverse = value;
		}

		public virtual IPropertyMap MustGetInversePropertyMap()
		{
			IPropertyMap propertyMap = GetInversePropertyMap();

			if (propertyMap == null)
				throw new MappingException("Could not find property " + m_Inverse + ", specified as inverse to property " + this.ClassMap.Name + "." + this.Name + ", in map file!");

			return propertyMap;
		}

		private bool fixedGetInversePropertyMap = false;
		private IPropertyMap fixedValueGetInversePropertyMap = null;

		public virtual IPropertyMap GetInversePropertyMap()
		{
			if (fixedGetInversePropertyMap)
				return fixedValueGetInversePropertyMap;

			IPropertyMap inversePropertyMap = null;

			if (m_Inverse.Length > 0)
			{
				IClassMap classMap = GetReferencedClassMap();
				if (classMap != null)
				{
					inversePropertyMap = classMap.GetPropertyMap(m_Inverse);
				}
			}

			if (isFixed)
			{
				fixedValueGetInversePropertyMap = inversePropertyMap;
				fixedGetInversePropertyMap = true;
			}

			return inversePropertyMap;
		}

		public virtual void SetInversePropertyMap(IPropertyMap value) => m_Inverse = value.Name;

	    public virtual bool IsIdentity
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_IsIdentity;
	        //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_IsIdentity = value;
	    }

		public int IdentityIndex
		{
			get => m_IdentityIndex;
		    set => m_IdentityIndex = value;
		}

		public virtual bool IsKey
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_IsKey;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_IsKey = value;
		}

		public int KeyIndex
		{
			get => m_KeyIndex;
		    set => m_KeyIndex = value;
		}

		public string IdentityGenerator
		{
			get => m_IdentityGenerator;
		    set => m_IdentityGenerator = value;
		}

		public virtual bool LazyLoad
		{
			get => m_LazyLoad;
		    set => m_LazyLoad = value;
		}

		public virtual bool IsReadOnly
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get
			{
				if (ClassMap.IsReadOnly)
				{
					return true;
				}
				else
				{
					return m_IsReadOnly;
				}
			}
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_IsReadOnly = value;
		}

		private bool fixedGetIsSlave = false;
		private bool fixedValueGetIsSlave = false;

		public virtual bool IsSlave
		{
			get
			{
				if (fixedGetIsSlave)
					return fixedValueGetIsSlave;

				bool isSlave = m_IsSlave;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					isSlave = !(inv.IsSlave);
				}

				if (isFixed)
				{
					fixedValueGetIsSlave = isSlave;
					fixedGetIsSlave = true;
				}

				return isSlave;
			}
			set => m_IsSlave = value;
		}

		public virtual string NullSubstitute
		{
			get => m_NullSubstitute;
		    set => m_NullSubstitute = value;
		}

		private bool fixedGetNoInverseManagement = false;
		private bool fixedValueGetNoInverseManagement = false;

		public virtual bool NoInverseManagement
		{
			get
			{
				if (fixedGetNoInverseManagement)
					return fixedValueGetNoInverseManagement;

				bool noInverseManagement = m_NoInverseManagement;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					noInverseManagement = inv.NoInverseManagement;
				}

				if (isFixed)
				{
					fixedValueGetNoInverseManagement = noInverseManagement;
					fixedGetNoInverseManagement = true;
				}

				return noInverseManagement;
			}
			set => m_NoInverseManagement = value;
		}

		public virtual bool InheritInverseMappings
		{
			get => m_InheritInverseMappings;
		    set => m_InheritInverseMappings = value;
		}

		public virtual bool CascadingCreate
		{
			get => m_CascadingCreate;
		    set => m_CascadingCreate = value;
		}

		public virtual bool CascadingDelete
		{
			get => m_CascadingDelete;
		    set => m_CascadingDelete = value;
		}

		private bool fixedDoesInheritInverseMappings = false;
		private bool fixedValueDoesInheritInverseMappings = false;

		public virtual bool DoesInheritInverseMappings()
		{
			if (fixedDoesInheritInverseMappings)
				return fixedValueDoesInheritInverseMappings;

			bool doesInheritInverseMappings = true;

			if (!m_InheritInverseMappings)
			{
				doesInheritInverseMappings = false;
			}
			if (m_ReferenceType == ReferenceType.None)
			{
				doesInheritInverseMappings =false;
			}
			if (!(m_Inverse.Length > 0))
			{
				doesInheritInverseMappings =false;
			}
			IPropertyMap inv = GetInversePropertyMap();
			if (inv == null)
			{
				doesInheritInverseMappings =false;
			}
			else
			{
				if (inv == this)
				{
					doesInheritInverseMappings =false;
				}
				if (inv.InheritInverseMappings)
				{
					doesInheritInverseMappings =false;
				}				
			}

			if (isFixed)
			{
				fixedValueDoesInheritInverseMappings = doesInheritInverseMappings;
				fixedDoesInheritInverseMappings = true;
			}

			return doesInheritInverseMappings;
		}

		private bool fixedGetReferenceType = false;
		private ReferenceType fixedValueGetReferenceType = ReferenceType.None;

		public virtual ReferenceType ReferenceType
		{
			get
			{
				if (fixedGetReferenceType)
					return fixedValueGetReferenceType;

				ReferenceType referenceType = m_ReferenceType;

				if (DoesInheritInverseMappings())
				{
					IPropertyMap inv = GetInversePropertyMap();
					if (inv.ReferenceType == ReferenceType.ManyToMany)
					{
						referenceType = ReferenceType.ManyToMany;
					}
					else if (inv.ReferenceType == ReferenceType.ManyToOne)
					{
						referenceType =ReferenceType.OneToMany;
					}
					else if (inv.ReferenceType == ReferenceType.OneToMany)
					{
						referenceType = ReferenceType.ManyToOne;
					}
					else if (inv.ReferenceType == ReferenceType.OneToOne)
					{
						referenceType = ReferenceType.OneToOne;
					}
					else if (inv.ReferenceType == ReferenceType.None)
					{
						referenceType = ReferenceType.None;
					}
					else
						referenceType = ReferenceType.None;
				}

				if (isFixed)
				{
					fixedValueGetReferenceType = referenceType;
					fixedGetReferenceType = true;
				}

				return referenceType;
			}
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_ReferenceType = value;
		}

		public ReferenceQualifier ReferenceQualifier
		{
			get => this.m_ReferenceQualifier;
		    set => this.m_ReferenceQualifier = value;
		}

		public virtual void UpdateName(string newName)
		{
			foreach (IClassMap checkClassMap in ClassMap.DomainMap.ClassMaps)
			{
				foreach (IPropertyMap propertyMap in checkClassMap.GetNonInheritedPropertyMaps())
				{
					if (!(propertyMap.ReferenceType == ReferenceType.None))
					{
						if (propertyMap.GetInversePropertyMap() == this)
						{
							propertyMap.Inverse = newName;
						}
					}
				}
			}
			m_Name = newName;
		}

		public virtual AccessibilityType Accessibility
		{
			get => m_Accessibility;
		    set => m_Accessibility = value;
		}

		public virtual AccessibilityType FieldAccessibility
		{
			get => m_FieldAccessibility;
		    set => m_FieldAccessibility = value;
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

		public virtual PropertySpecialBehaviorType OnCreateBehavior
		{
			get => m_OnCreateBehavior;
		    set => m_OnCreateBehavior = value;
		}

		public virtual PropertySpecialBehaviorType OnPersistBehavior
		{
			get => m_OnPersistBehavior;
		    set => m_OnPersistBehavior = value;
		}

		public virtual string OrderBy
		{
			get => m_OrderBy;
		    set => m_OrderBy = value;
		}

		private bool fixedGetOrderByPropertyMap = false;
		private IPropertyMap fixedValueGetOrderByPropertyMap = null;

		public virtual IPropertyMap GetOrderByPropertyMap()
		{
			if (fixedGetOrderByPropertyMap)
				return fixedValueGetOrderByPropertyMap;

			IPropertyMap propertyMap = null;

			if (m_OrderBy.Length > 0)
			{
				IClassMap classMap = GetReferencedClassMap();
				if (classMap != null)
				{
					propertyMap = classMap.GetPropertyMap(m_OrderBy);
				}
			}

			if (isFixed)
			{
				fixedValueGetOrderByPropertyMap = propertyMap;
				fixedGetOrderByPropertyMap = true;
			}

			return propertyMap;
		}

		public virtual PropertyModifier PropertyModifier
		{
			get => m_PropertyModifier;
		    set => m_PropertyModifier = value;
		}

		public virtual MergeBehaviorType MergeBehavior
		{
			get => m_MergeBehavior;
		    set => m_MergeBehavior = value;
		}

		public virtual RefreshBehaviorType RefreshBehavior
		{
			get => m_RefreshBehavior;
		    set => m_RefreshBehavior = value;
		}

		public virtual LoadBehavior ListCountLoadBehavior
		{
			get => m_ListCountLoadBehavior;
		    set => m_ListCountLoadBehavior = value;
		}

		private bool fixedGetAllColumnMaps = false;
		private ArrayList fixedValueGetAllColumnMaps = null;

		public ArrayList GetAllColumnMaps()
		{
			if (fixedGetAllColumnMaps)
				return fixedValueGetAllColumnMaps;

			ArrayList columnMaps = new ArrayList();
			IColumnMap columnMap = this.GetColumnMap();
			if (columnMap != null)
			{
				columnMaps.Add(columnMap);
			}
			//Thanks to Steven Miller for fixing a bug here
			columnMaps.AddRange(this.GetAdditionalColumnMaps());

			if (isFixed)
			{
				fixedValueGetAllColumnMaps = columnMaps;
				fixedGetAllColumnMaps = true;
			}

			return columnMaps;
		}

		private bool fixedGetAllIdColumnMaps = false;
		private ArrayList fixedValueGetAllIdColumnMaps = null;

		public ArrayList GetAllIdColumnMaps()
		{
			if (fixedGetAllIdColumnMaps)
				return fixedValueGetAllIdColumnMaps;

			ArrayList columnMaps = new ArrayList();
			IColumnMap columnMap = this.GetIdColumnMap();
			if (columnMap != null)
			{
				columnMaps.Add(columnMap);
			}
			//Thanks to Steven Miller for fixing a bug here
			columnMaps.AddRange(this.GetAdditionalIdColumnMaps());

			if (isFixed)
			{
				fixedValueGetAllIdColumnMaps = columnMaps;
				fixedGetAllIdColumnMaps = true;
			}

			return columnMaps;
		}


		public string GetDataOrItemType()
		{
			if (this.IsCollection)
			{
				return this.ItemType;
			}
			else
			{
				return this.DataType;
			}
		}
		
		public ValidationMode ValidationMode
		{
			get => this.m_ValidationMode;
		    set => this.m_ValidationMode = value;
		}
		
		public long TimeToLive
		{
			get => this.m_TimeToLive;
		    set => this.m_TimeToLive = value;
		}
		
		public TimeToLiveBehavior TimeToLiveBehavior
		{
			get => this.m_TimeToLiveBehavior;
		    set => this.m_TimeToLiveBehavior = value;
		}

		public long GetTimeToLive()
		{
			if (this.m_TimeToLive < 0)
				return this.ClassMap.GetTimeToLive();
			return this.m_TimeToLive;
		}
		
		public TimeToLiveBehavior GetTimeToLiveBehavior()
		{
			if (this.m_TimeToLiveBehavior == TimeToLiveBehavior.Default)
				return this.ClassMap.GetTimeToLiveBehavior();
			return this.m_TimeToLiveBehavior;
		}

		public virtual string CommitRegions
		{
			get => commitRegions;
		    set => commitRegions = value;
		}

		private bool fixedGetCommitRegions = false;
		private IList fixedValueGetCommitRegions = null;

		public IList GetCommitRegions()
		{
			if (fixedGetCommitRegions)
				return fixedValueGetCommitRegions;

			string[] regions = commitRegions.Split(";".ToCharArray());
			IList result = new ArrayList();
			foreach (string region in regions)
			{
				if (region != "")
					result.Add(region);
			}

			if (isFixed)
			{
				fixedValueGetCommitRegions = result;
				fixedGetCommitRegions = true;
			}

			return result;
		}

		#endregion

		#region Object/Object Mapping

		public virtual string SourceProperty
		{
			get => m_SourceProperty;
		    set => m_SourceProperty = value;
		}

		public virtual IPropertyMap GetSourcePropertyMap()
		{
			if (m_SourceProperty == "")
				return null;

			IClassMap sourceClassMap = this.ClassMap.GetSourceClassMap();

			if (sourceClassMap != null)
			{
				return sourceClassMap.GetPropertyMap(m_SourceProperty);
			}

			return null;
		}


		public virtual IPropertyMap GetSourcePropertyMapOrSelf()
		{
			if (m_SourceProperty == "")
				return this;

			IPropertyMap sourcePropertyMap = this.GetSourcePropertyMap();

			if (sourcePropertyMap == null)
			{
				IClassMap sourceClassMap = this.ClassMap.GetSourceClassMapOrSelf() ;

				if (sourceClassMap != null)
				{
					sourcePropertyMap = sourceClassMap.GetPropertyMap(m_SourceProperty);					
				}
			}

			if (sourcePropertyMap == null)
				sourcePropertyMap = this;

			return sourcePropertyMap;
		}

		#endregion

		#region Object/Document Mapping
		
		public virtual string DocSource
		{
			get => m_DocSource;
		    set => m_DocSource = value;
		}
		
		public virtual ISourceMap GetDocSourceMap()
		{
			if (this.DocSource == "")
			{
				return m_ClassMap.GetDocSourceMap();
			}
			else
			{
				return m_ClassMap.DomainMap.GetSourceMap(this.DocSource);
			}
		}

		public virtual void SetDocSourceMap(ISourceMap value) => m_DocSource = value.Name;

	    public virtual string DocAttribute
		{
			get => m_DocAttribute;
	        set => m_DocAttribute = value;
	    }

		public virtual string GetDocAttribute()
		{
			if (m_DocAttribute.Length > 0)
				return m_DocAttribute;

			return this.Name;
		}

		public virtual string DocElement
		{
			get => m_DocElement;
		    set => m_DocElement = value;
		}

		public virtual string GetDocElement()
		{
			if (m_DocElement.Length > 0)
				return m_DocElement;

			return this.Name;
		}
		
		public virtual DocPropertyMapMode DocPropertyMapMode
		{
			get => m_DocPropertyMapMode;
		    set => m_DocPropertyMapMode = value;
		}

		#endregion

		#region Cloning

		public override IMap Clone()
		{
			IPropertyMap propertyMap = new PropertyMap();
			Copy(propertyMap);
			return propertyMap;
		}

		public override IMap DeepClone()
		{
			IPropertyMap propertyMap = new PropertyMap();
			DeepCopy(propertyMap);
			return propertyMap;
		}

		protected virtual void DoDeepCopy(IPropertyMap propertyMap)
		{
		}

		public override void DeepCopy(IMap mapObject)
		{
			IPropertyMap propertyMap = (IPropertyMap) mapObject;
			Copy(propertyMap);
			DoDeepCopy(propertyMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			return true;
		}

		public override void DeepMerge(IMap mapObject) => Copy(mapObject);

	    public override void Copy(IMap mapObject)
		{
			IPropertyMap propertyMap = (IPropertyMap) mapObject;
			propertyMap.Name = this.Name;
			propertyMap.Column = this.Column;
			propertyMap.ValidateMethod = this.ValidateMethod;
			propertyMap.ValidationMode = this.ValidationMode ;
			propertyMap.DataType = this.DataType;
			propertyMap.DefaultValue = this.DefaultValue;
			propertyMap.FieldName = this.FieldName;
			propertyMap.IdColumn = this.IdColumn;
			propertyMap.IdentityIndex = this.IdentityIndex;
			propertyMap.IsKey = this.IsKey;
			propertyMap.KeyIndex = this.KeyIndex;
			propertyMap.IdentityGenerator = this.IdentityGenerator;
			propertyMap.InheritInverseMappings = this.InheritInverseMappings;
			propertyMap.Inverse = this.Inverse;
			propertyMap.IsGenerated = this.IsGenerated;
			propertyMap.IsCollection = this.IsCollection;
			propertyMap.IsNullable = this.IsNullable;
			propertyMap.IsAssignedBySource = this.IsAssignedBySource;
			propertyMap.MaxLength = this.MaxLength;
			propertyMap.MinLength = this.MinLength;
			propertyMap.MaxValue= this.MaxValue;
			propertyMap.MinValue= this.MinValue;
			propertyMap.IsIdentity = this.IsIdentity;
			propertyMap.IsReadOnly = this.IsReadOnly;
			propertyMap.IsSlave = this.IsSlave;
			propertyMap.ItemType = this.ItemType;
			propertyMap.LazyLoad = this.LazyLoad;
			propertyMap.NoInverseManagement = this.NoInverseManagement;
			propertyMap.NullSubstitute = this.NullSubstitute;
			propertyMap.Source = this.Source;
			propertyMap.Table = this.Table;
			propertyMap.ReferenceType = this.ReferenceType;
			propertyMap.ReferenceQualifier = this.ReferenceQualifier;
			propertyMap.AdditionalColumns = (ArrayList) this.AdditionalColumns.Clone();
			propertyMap.AdditionalIdColumns = (ArrayList) this.AdditionalIdColumns.Clone();
			propertyMap.Accessibility = this.Accessibility;
			propertyMap.FieldAccessibility = this.FieldAccessibility;
			propertyMap.DeleteOptimisticConcurrencyBehavior = this.DeleteOptimisticConcurrencyBehavior;
			propertyMap.UpdateOptimisticConcurrencyBehavior = this.UpdateOptimisticConcurrencyBehavior;
			propertyMap.OnCreateBehavior = this.OnCreateBehavior;
			propertyMap.OnPersistBehavior = this.OnPersistBehavior;
			propertyMap.OrderBy = this.OrderBy;
			propertyMap.PropertyModifier = this.PropertyModifier;
			propertyMap.MergeBehavior = this.MergeBehavior;
			propertyMap.RefreshBehavior = this.RefreshBehavior;
			propertyMap.ListCountLoadBehavior  = this.ListCountLoadBehavior;
			propertyMap.CascadingCreate = this.CascadingCreate;
			propertyMap.CascadingDelete = this.CascadingDelete;
			propertyMap.TimeToLive = this.TimeToLive;
			propertyMap.TimeToLiveBehavior = this.TimeToLiveBehavior;
			propertyMap.CommitRegions = this.CommitRegions;
			propertyMap.DocSource = this.DocSource;
			propertyMap.DocAttribute = this.DocAttribute;
			propertyMap.DocElement= this.DocElement;
			propertyMap.DocPropertyMapMode = this.DocPropertyMapMode;
		}

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			IPropertyMap propertyMap = (IPropertyMap) compareTo;
			if (!(propertyMap.Column == this.Column))
			{
				return false;
			}
			if (!(propertyMap.ValidateMethod == this.ValidateMethod))
			{
				return false;
			}
			if (!(propertyMap.ValidationMode == this.ValidationMode))
			{
				return false;
			}
			if (!(propertyMap.DataType == this.DataType))
			{
				return false;
			}
			if (!(propertyMap.DefaultValue == this.DefaultValue))
			{
				return false;
			}
			if (!(propertyMap.FieldName == this.FieldName))
			{
				return false;
			}
			if (!(propertyMap.IdColumn == this.IdColumn))
			{
				return false;
			}
			if (!(propertyMap.IdentityIndex == this.IdentityIndex))
			{
				return false;
			}
			if (!(propertyMap.IsKey == this.IsKey))
			{
				return false;
			}
			if (!(propertyMap.KeyIndex == this.KeyIndex))
			{
				return false;
			}
			if (!(propertyMap.IdentityGenerator == this.IdentityGenerator))
			{
				return false;
			}
			if (!(propertyMap.IsNullable == this.IsNullable))
			{
				return false;
			}
			if (!(propertyMap.IsAssignedBySource == this.IsAssignedBySource))
			{
				return false;
			}
			if (!(propertyMap.MaxLength == this.MaxLength))
			{
				return false;
			}
			if (!(propertyMap.MinLength == this.MinLength))
			{
				return false;
			}
			if (!(propertyMap.MaxValue == this.MaxValue))
			{
				return false;
			}
			if (!(propertyMap.MinValue == this.MinValue))
			{
				return false;
			}
			if (!(propertyMap.InheritInverseMappings == this.InheritInverseMappings))
			{
				return false;
			}
			if (!(propertyMap.Inverse == this.Inverse))
			{
				return false;
			}
			if (!(propertyMap.IsGenerated == this.IsGenerated))
			{
				return false;
			}
			if (!(propertyMap.IsCollection == this.IsCollection))
			{
				return false;
			}
			if (!(propertyMap.IsIdentity == this.IsIdentity))
			{
				return false;
			}
			if (!(propertyMap.IsReadOnly == this.IsReadOnly))
			{
				return false;
			}
			if (!(propertyMap.IsSlave == this.IsSlave))
			{
				return false;
			}
			if (!(propertyMap.ItemType == this.ItemType))
			{
				return false;
			}
			if (!(propertyMap.LazyLoad == this.LazyLoad))
			{
				return false;
			}
			if (!(propertyMap.Name == this.Name))
			{
				return false;
			}
			if (!(propertyMap.NoInverseManagement == this.NoInverseManagement))
			{
				return false;
			}
			if (!(propertyMap.NullSubstitute == this.NullSubstitute))
			{
				return false;
			}
			if (!(propertyMap.Source == this.Source))
			{
				return false;
			}
			if (!(propertyMap.Table == this.Table))
			{
				return false;
			}
			if (!(propertyMap.ReferenceType == this.ReferenceType))
			{
				return false;
			}
			if (!(propertyMap.ReferenceQualifier == this.ReferenceQualifier))
			{
				return false;
			}
			if (!(propertyMap.Accessibility == this.Accessibility))
			{
				return false;
			}
			if (!(propertyMap.FieldAccessibility == this.FieldAccessibility))
			{
				return false;
			}
			if (!(propertyMap.DeleteOptimisticConcurrencyBehavior == this.DeleteOptimisticConcurrencyBehavior))
			{
				return false;
			}
			if (!(propertyMap.UpdateOptimisticConcurrencyBehavior == this.UpdateOptimisticConcurrencyBehavior))
			{
				return false;
			}
			if (!(propertyMap.OnCreateBehavior == this.OnCreateBehavior))
			{
				return false;
			}
			if (!(propertyMap.OnPersistBehavior == this.OnPersistBehavior))
			{
				return false;
			}
			if (!(propertyMap.OrderBy == this.OrderBy))
			{
				return false;
			}
			if (!(propertyMap.PropertyModifier == this.PropertyModifier))
			{
				return false;
			}
			if (!(propertyMap.MergeBehavior == this.MergeBehavior))
			{
				return false;
			}
			if (!(propertyMap.RefreshBehavior == this.RefreshBehavior))
			{
				return false;
			}
			if (!(propertyMap.ListCountLoadBehavior == this.ListCountLoadBehavior))
			{
				return false;
			}
			if (!(propertyMap.CascadingCreate == this.CascadingCreate))
			{
				return false;
			}
			if (!(propertyMap.CascadingDelete == this.CascadingDelete))
			{
				return false;
			}
			if (!(propertyMap.TimeToLive == this.TimeToLive))
			{
				return false;
			}
			if (!(propertyMap.TimeToLiveBehavior == this.TimeToLiveBehavior))
			{
				return false;
			}
			if (!(propertyMap.CommitRegions == this.CommitRegions))
			{
				return false;
			}
			if (!(propertyMap.DocSource == this.DocSource))
			{
				return false;
			}
			if (!(propertyMap.DocAttribute == this.DocAttribute))
			{
				return false;
			}
			if (!(propertyMap.DocElement == this.DocElement))
			{
				return false;
			}
			if (!(propertyMap.DocPropertyMapMode == this.DocPropertyMapMode))
			{
				return false;
			}
			if (!(CompareArrayLists(propertyMap.AdditionalColumns, this.AdditionalColumns)))
			{
				return false;
			}
			if (!(CompareArrayLists(propertyMap.AdditionalIdColumns, this.AdditionalIdColumns)))
			{
				return false;
			}
			return true;
		}

		#endregion

		#region IMap

		public override string GetKey() => m_ClassMap.DomainMap.Name + "." + m_ClassMap.Name + "." + this.Name;

	    #endregion

		#region IFixate

		public override void Fixate()
		{
			base.Fixate();
			this.isFixed = true;
		}

		public override void UnFixate()
		{
			base.UnFixate();
			this.isFixed = false;
			this.fixedGetIsNullable = false;
			this.fixedGetIsAssignedBySource = false;
			this.fixedGetMaxLength = false;
			this.fixedGetFieldName = false;
			this.fixedGetDataType = false;
			this.fixedGetItemType = false;
			this.fixedGetIsCollection = false;
			this.fixedGetReferencedClassMap = false;
			this.fixedGetSource = false;
			this.fixedGetSourceMap = false;
			this.fixedGetTable = false;
			this.fixedGetTableMap = false;
			this.fixedGetColumn = false;
			this.fixedGetColumnMap = false;
			this.fixedGetIdColumn = false;
			this.fixedGetIdColumnMap = false;
			this.fixedGetAdditionalColumns = false;
			this.fixedGetAdditionalColumnMaps = false;
			this.fixedGetAdditionalIdColumns = false;
			this.fixedGetAdditionalIdColumnMaps = false;
			this.fixedGetInverse = false;
			this.fixedGetInversePropertyMap = false;
			this.fixedGetIsSlave = false;
			this.fixedGetNoInverseManagement = false;
			this.fixedDoesInheritInverseMappings = false;
			this.fixedGetReferenceType = false;
			this.fixedGetOrderByPropertyMap = false;
			this.fixedGetAllColumnMaps = false;
			this.fixedGetAllIdColumnMaps = false;
			this.fixedGetCommitRegions = false;
		}

		#endregion

		#region FromPropertyMapAttribute

		public static void FromPropertyMapAttribute(PropertyMapAttribute attrib, PropertyInfo propInfo, IPropertyMap propertyMap)
		{
			propertyMap.Name = propInfo.Name;
			propertyMap.DataType = propInfo.PropertyType.ToString();

			propertyMap.CascadingCreate = attrib.CascadingCreate ;
			propertyMap.CascadingDelete = attrib.CascadingDelete ;

			propertyMap.Column = attrib.GetColumn() ;
			foreach (string column in attrib.GetAdditionalColumns())
				propertyMap.AdditionalColumns.Add(column);

			propertyMap.IdColumn = attrib.GetIdColumn() ;
			foreach (string column in attrib.GetAdditionalIdColumns())
				propertyMap.AdditionalIdColumns.Add(column);

			propertyMap.CommitRegions = attrib.CommitRegions ;
			propertyMap.DeleteOptimisticConcurrencyBehavior = attrib.DeleteOptimisticConcurrencyBehavior  ;
			propertyMap.DocAttribute = attrib.DocAttribute ;
			propertyMap.DocElement = attrib.DocElement ;
			propertyMap.DocPropertyMapMode = attrib.DocPropertyMapMode ;
			propertyMap.DocSource = attrib.DocSource ;
			propertyMap.FieldName = attrib.FieldName ;
			propertyMap.IdentityGenerator = attrib.IdentityGenerator ;
			propertyMap.IdentityIndex = attrib.IdentityIndex ;
			propertyMap.InheritInverseMappings = attrib.InheritInverseMappings  ;
			propertyMap.Inverse = attrib.Inverse ;
			propertyMap.IsAssignedBySource = attrib.IsAssignedBySource ;
			propertyMap.IsCollection = attrib.IsCollection ;
			propertyMap.IsIdentity = attrib.IsIdentity ;
			propertyMap.IsKey = attrib.IsKey ;
			propertyMap.IsNullable = attrib.IsNullable ;
			propertyMap.IsReadOnly = attrib.IsReadOnly ;
			propertyMap.IsSlave = attrib.IsSlave ;
			propertyMap.ItemType = attrib.ItemType ;
			propertyMap.KeyIndex = attrib.KeyIndex ;
			propertyMap.LazyLoad = attrib.LazyLoad ;
			propertyMap.ListCountLoadBehavior = attrib.ListCountLoadBehavior;
			propertyMap.MaxLength = attrib.MaxLength ;
			propertyMap.MaxValue = attrib.MaxValue ;
			propertyMap.MergeBehavior = attrib.MergeBehavior ;
			propertyMap.MinLength = attrib.MinLength ;
			propertyMap.MinValue = attrib.MinValue ;
			propertyMap.NoInverseManagement = attrib.NoInverseManagement ;
			propertyMap.NullSubstitute = attrib.NullSubstitute ;
			propertyMap.OnCreateBehavior = attrib.OnCreateBehavior ;
			propertyMap.OnPersistBehavior = attrib.OnPersistBehavior ;
			propertyMap.OrderBy = attrib.OrderBy ;
			propertyMap.ReferenceQualifier = attrib.ReferenceQualifier ;
			propertyMap.ReferenceType = attrib.ReferenceType ;
			propertyMap.RefreshBehavior = attrib.RefreshBehavior ;
			propertyMap.Source = attrib.Source ;
			propertyMap.SourceProperty = attrib.SourceProperty ;
			propertyMap.Table = attrib.Table ;
			propertyMap.TimeToLive = attrib.TimeToLive ;
			propertyMap.TimeToLiveBehavior = attrib.TimeToLiveBehavior ;
			propertyMap.UpdateOptimisticConcurrencyBehavior = attrib.UpdateOptimisticConcurrencyBehavior ;
			propertyMap.ValidateMethod = attrib.ValidateMethod ;
			propertyMap.ValidationMode = attrib.ValidationMode ;
		}

		#endregion

	}
}
