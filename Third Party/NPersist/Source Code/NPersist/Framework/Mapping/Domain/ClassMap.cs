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
using System.Reflection.Emit;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Attributes;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class ClassMap : MapBase, IClassMap
	{

		public override void Accept(IMapVisitor visitor) => visitor.Visit(this);

	    public override IMap GetParent() => m_DomainMap;

	    #region Private Member Variables

		private ArrayList m_PropertyMaps = new ArrayList();
		private ArrayList m_CodeMaps = new ArrayList();
		private ArrayList m_EnumValueMaps = new ArrayList();
		private DomainMap m_DomainMap;
		private string m_name = "";
		private string m_Source = "";
		private string m_Table = "";
		private string m_IdentitySeparator = "";
		private string m_KeySeparator = "";
		private string m_TypeColumn = "";
		private string m_TypeValue = "";
		private string m_InheritsClass = "";
		private ClassType m_ClassType = ClassType. Default;
		private InheritanceType m_InheritanceType = InheritanceType.None;
		private MergeBehaviorType m_MergeBehavior = MergeBehaviorType.DefaultBehavior;
		private RefreshBehaviorType m_RefreshBehavior = RefreshBehaviorType.DefaultBehavior;
		private LoadBehavior m_ListCountLoadBehavior = LoadBehavior.Default;
		private bool m_IsAbstract = false;
		private bool m_IsReadOnly = false;
		private string m_InheritsTransientClass = "";
		private ArrayList m_ImplementsInterfaces = new ArrayList();
		private ArrayList m_ImportsNamespaces = new ArrayList();
		private OptimisticConcurrencyBehaviorType m_UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_DeleteOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private string m_AssemblyName = "";
		private string m_ValidateMethod = "";
		private ValidationMode m_ValidationMode = ValidationMode.Default ;
		private string m_LoadSpan = "";
		private long m_TimeToLive = -1;
		private TimeToLiveBehavior m_TimeToLiveBehavior = TimeToLiveBehavior.Default;
		private LoadBehavior m_LoadBehavior = LoadBehavior.Default;
		private string commitRegions = "";

		//O/O Mapping
		private string m_SourceClass = "";

		//O/D Mapping
		private string m_DocSource = "";
		private string m_DocElement = "";
		private string m_DocRoot = "";
		private DocClassMapMode m_DocClassMapMode = DocClassMapMode.Default;
		private string m_DocParentProperty = "";

		//misc
		private bool isFixed = false;

		#endregion

		#region Constructors

		public ClassMap() : base()
		{
		}

		public ClassMap(string name) : base() => m_name = name;

	    #endregion

		#region Object/Relational Mapping

		[XmlIgnore()]
		public virtual IDomainMap DomainMap
		{
			get => m_DomainMap;
		    set
			{
				if (m_DomainMap != null)
				{
					m_DomainMap.ClassMaps.Remove(this);
				}
				m_DomainMap = (DomainMap) value;
				if (m_DomainMap != null)
				{
					m_DomainMap.ClassMaps.Add(this);
				}
			}
		}

		public virtual void SetDomainMap(IDomainMap value)
		{
			m_DomainMap = (DomainMap) value;
			foreach (IPropertyMap propertyMap in m_PropertyMaps)
			{
				propertyMap.SetClassMap(this);
			}
		}

		[XmlArrayItem(typeof (PropertyMap))]
		public virtual ArrayList PropertyMaps
		{
			get => m_PropertyMaps;
		    set => m_PropertyMaps = value;
		}

				
		public virtual IPropertyMap MustGetPropertyMap(string findName)
		{
			IPropertyMap propertyMap = GetPropertyMap(findName);

			if (propertyMap == null)
				throw new MappingException("Could not find property " + findName + " for the type " + this.GetFullName() + " in map file!");

			return propertyMap;
		}

        private bool fixedGetPropertyMap = false;
        private Hashtable fixedValueGetPropertyMap = new Hashtable();

		//Mats : Added case insensitivity
		//[DebuggerStepThrough()]
		public virtual IPropertyMap GetPropertyMap(string findName)
		{
			if (findName == null) { return null; }
			if (findName == "") { return null; }
			findName = findName.ToLower(CultureInfo.InvariantCulture);
			if (fixedGetPropertyMap)
			{
				return (IPropertyMap) fixedValueGetPropertyMap[findName];
			}
            if (isFixed)
            {
                IPropertyMap result = null;
                foreach (IPropertyMap propertyMap in this.GetAllPropertyMaps())
                {
					string low = propertyMap.Name.ToLower(CultureInfo.InvariantCulture);
                    fixedValueGetPropertyMap[low] = propertyMap;
                    if (low == findName)
                        result = propertyMap;
                }
                fixedGetPropertyMap = true;
                return result;
            }
            else
            {
                foreach (IPropertyMap propertyMap in this.GetAllPropertyMaps())
                    if (propertyMap.Name.ToLower(CultureInfo.InvariantCulture) == findName)
                        return propertyMap;
            }
			return null;
		}

		[XmlArrayItem(typeof (CodeMap))]
		public virtual ArrayList CodeMaps
		{
			get => m_CodeMaps;
		    set => m_CodeMaps = value;
		}

		public virtual ICodeMap GetCodeMap(CodeLanguage codeLanguage)
		{
			if (IsFixed("GetCodeMap_" + codeLanguage.ToString() ))
			{
				return (ICodeMap) GetFixedValue("GetCodeMap_" + codeLanguage.ToString());
			}
			foreach (ICodeMap codeMap in this.m_CodeMaps)
			{
				if (codeMap.CodeLanguage.Equals(codeLanguage))
				{
					if (IsFixed())
					{
						SetFixedValue("GetCodeMap_" + codeLanguage.ToString(), codeMap);
					}
					return codeMap;
				}
			}
			return null;
		}

		public virtual ICodeMap EnsuredGetCodeMap(CodeLanguage codeLanguage)
		{
			ICodeMap codeMap = GetCodeMap(codeLanguage);
			if (codeMap == null)
			{
				codeMap = new CodeMap() ;
				codeMap.CodeLanguage = codeLanguage;
				this.m_CodeMaps.Add(codeMap);
			}				
			return codeMap;	
		}

				
		[XmlArrayItem(typeof (EnumValueMap))]
		public virtual ArrayList EnumValueMaps
		{
			get => m_EnumValueMaps;
		    set => m_EnumValueMaps = value;
		}

		//[DebuggerStepThrough()]
		public virtual IEnumValueMap GetEnumValueMap(string findName)
		{
			if (findName == null) { return null; }
			if (findName == "") { return null; }
			findName = findName.ToLower(CultureInfo.InvariantCulture);
			if (IsFixed("GetEnumValueMap_" + findName))
			{
				return (IEnumValueMap) GetFixedValue("GetEnumValueMap_" + findName);
			}
			foreach (IEnumValueMap enumValueMap in this.EnumValueMaps)
			{
				if (enumValueMap.Name.ToLower(CultureInfo.InvariantCulture) == findName)
				{
					if (IsFixed())
					{
						SetFixedValue("GetEnumValueMap_" + findName, enumValueMap);
					}
					return enumValueMap;
				}
			}
			return null;
		}

		public virtual IList GetEnumValueMaps()
		{
			bool sortingFailed = false;
			return GetSortedEnumValueMaps(ref sortingFailed);
		}

		public virtual IList GetSortedEnumValueMaps(ref bool failedSorting)
		{
			IList arrVals = new ArrayList();
			foreach (IEnumValueMap enumValueMap in m_EnumValueMaps)
			{
				arrVals.Add(enumValueMap);
			}
			object[] arr = new object[arrVals.Count];
			foreach (IEnumValueMap enumValueMap in arrVals)
			{
				if (enumValueMap.Index > arr.GetUpperBound(0))
				{
					failedSorting = true;
					return arrVals;
				}
				if (!(arr[enumValueMap.Index] == null))
				{
					failedSorting = true;
					return arrVals;
				}
				arr[enumValueMap.Index] = enumValueMap;
			}
			arrVals.Clear();
			foreach (IEnumValueMap enumValueMap in arr)
			{
				arrVals.Add(enumValueMap);
			}
			return arrVals;
		}

		public override string Name
		{
			get => m_name;
		    set => m_name = value;
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

				IClassMap superClassMap;
				if (m_InheritsClass.Length > 0)
				{
					superClassMap = GetInheritedClassMap();
					if (superClassMap != null)
					{
						source = superClassMap.Source;
					}
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

			if (Source == "")
			{
				sourceMap = m_DomainMap.GetSourceMap();
			}
			else
			{
				sourceMap = m_DomainMap.GetSourceMap(Source);
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
		private string fixedValueGetTable = null;

		public virtual string Table
		{
			get
			{
				if (fixedGetTable)
					return fixedValueGetTable;

				string table = m_Table;

				IClassMap superClassMap;
				if (m_InheritsClass.Length > 0)
				{
					superClassMap = GetInheritedClassMap();
					if (superClassMap != null)
					{
						table = superClassMap.Table;
					}
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
				throw new MappingException("Could not find table " + m_Table + " mapped to by type " + this.GetFullName() + " in map file!");

			return tableMap;
		}

		private bool fixedGetTableMap = false;
		private ITableMap fixedValueGetTableMap = null;

		public virtual ITableMap GetTableMap()
		{
			if (fixedGetTableMap)
				return fixedValueGetTableMap;

			ITableMap tableMap = null;
			ISourceMap sourceMap = GetSourceMap();
			if (sourceMap != null)
			{
				tableMap = sourceMap.GetTableMap(Table);
			}

			if (isFixed)
			{
				fixedValueGetTableMap = tableMap;
				fixedGetTableMap = true;
			}

			return tableMap;
		}

		public virtual void SetTableMap(ITableMap value) => m_Table = value.Name;

	    private bool fixedGetPrimaryPropertyMaps = false;
		private ArrayList fixedValueGetPrimaryPropertyMaps = null;

		public virtual ArrayList GetPrimaryPropertyMaps()
		{
			if (fixedGetPrimaryPropertyMaps)
				return fixedValueGetPrimaryPropertyMaps;

			ArrayList arrProps = new ArrayList();
			ITableMap tableMap = null;
			foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
			{
				arrProps.Add(propertyMap);
			}
			foreach (IPropertyMap propertyMap in m_PropertyMaps)
			{
				if (!(propertyMap.IsIdentity))
				{
					tableMap = propertyMap.GetTableMap();
					if (tableMap != null)
					{
						if (tableMap == GetTableMap())
						{
							arrProps.Add(propertyMap);
						}
					}
				}
			}

			if (isFixed)
			{
				fixedValueGetPrimaryPropertyMaps = arrProps;
				fixedGetPrimaryPropertyMaps = true;
			}

			return arrProps;
		}

		private bool fixedGetIdentityPropertyMaps = false;
		private ArrayList fixedValueGetIdentityPropertyMaps = null;

		public virtual ArrayList GetIdentityPropertyMaps()
		{
			if (fixedGetIdentityPropertyMaps)
				return fixedValueGetIdentityPropertyMaps;

			bool sortingFailed = false;
			ArrayList props = GetSortedIdentityPropertyMaps(ref sortingFailed, true);

			if (isFixed)
			{
				fixedValueGetIdentityPropertyMaps = props;
				fixedGetIdentityPropertyMaps = true;
			}

			return props;
		}

		private bool fixedGetSortedIdentityPropertyMaps = false;
		private ArrayList fixedValueGetSortedIdentityPropertyMaps = null;
		private bool fixedValueFailedGetSortedIdentityPropertyMaps = false;
		private bool fixedGetSortedIdentityPropertyMapsInherited = false;
		private ArrayList fixedValueGetSortedIdentityPropertyMapsInherited = null;
		private bool fixedValueFailedGetSortedIdentityPropertyMapsInherited = false;

		public virtual ArrayList GetSortedIdentityPropertyMaps(ref bool failedSorting, bool getInherited)
		{
			if (getInherited)
			{
				if (fixedGetSortedIdentityPropertyMapsInherited)
				{
					failedSorting = fixedValueFailedGetSortedIdentityPropertyMapsInherited;
					return fixedValueGetSortedIdentityPropertyMapsInherited;
				}
			}
			else
			{
				if (fixedGetSortedIdentityPropertyMaps)
				{
					failedSorting = fixedValueFailedGetSortedIdentityPropertyMaps;
					return fixedValueGetSortedIdentityPropertyMaps;
				}
			}

			ArrayList arrProps = new ArrayList();
			IClassMap superClassMap = GetInheritedClassMap();
			if (getInherited)
			{
				if (superClassMap != null)
				{
					foreach (IPropertyMap propertyMap in superClassMap.GetIdentityPropertyMaps())
					{
						if (propertyMap.IsIdentity)
						{
							arrProps.Add(propertyMap);
						}
					}
				}
			}
			foreach (IPropertyMap propertyMap in m_PropertyMaps)
			{
				if (propertyMap.IsIdentity)
				{
					arrProps.Add(propertyMap);
				}
			}
			object[] arr = new object[arrProps.Count];
			foreach (IPropertyMap propertyMap in arrProps)
			{
				if (propertyMap.IdentityIndex > arr.GetUpperBound(0))
				{
					failedSorting = true;
					break;
				}
				if (!(arr[propertyMap.IdentityIndex] == null))
				{
					failedSorting = true;
					break;
				}
				arr[propertyMap.IdentityIndex] = propertyMap;
			}
			if (!failedSorting)
			{
				arrProps.Clear();
				foreach (IPropertyMap propertyMap in arr)
				{
					arrProps.Add(propertyMap);
				}				
			}

			if (isFixed)
			{
				if (getInherited)
				{
					fixedValueFailedGetSortedIdentityPropertyMapsInherited = failedSorting;
					fixedValueGetSortedIdentityPropertyMapsInherited = arrProps;
					fixedGetSortedIdentityPropertyMapsInherited = true;
				}
				else
				{
					fixedValueFailedGetSortedIdentityPropertyMaps = failedSorting;
					fixedValueGetSortedIdentityPropertyMaps = arrProps;
					fixedGetSortedIdentityPropertyMaps = true;										
				}
			}

			return arrProps;
		}

		private bool fixedGetKeyPropertyMaps = false;
		private ArrayList fixedValueGetKeyPropertyMaps = null;

		public virtual ArrayList GetKeyPropertyMaps()
		{
			if (fixedGetKeyPropertyMaps)
				return fixedValueGetKeyPropertyMaps;

			bool sortingFailed = false;
			ArrayList props = GetSortedKeyPropertyMaps(ref sortingFailed, true);

			if (isFixed)
			{
				fixedValueGetKeyPropertyMaps = props;
				fixedGetKeyPropertyMaps = true;
			}

			return props;
		}

		private bool fixedGetSortedKeyPropertyMaps = false;
		private ArrayList fixedValueGetSortedKeyPropertyMaps = null;
		private bool fixedValueFailedGetSortedKeyPropertyMaps = false;
		private bool fixedGetSortedKeyPropertyMapsInherited = false;
		private ArrayList fixedValueGetSortedKeyPropertyMapsInherited = null;
		private bool fixedValueFailedGetSortedKeyPropertyMapsInherited = false;

		public virtual ArrayList GetSortedKeyPropertyMaps(ref bool failedSorting, bool getInherited)
		{
			if (getInherited)
			{
				if (fixedGetSortedKeyPropertyMapsInherited)
				{
					failedSorting = fixedValueFailedGetSortedKeyPropertyMapsInherited;
					return fixedValueGetSortedKeyPropertyMapsInherited;
				}
			}
			else
			{
				if (fixedGetSortedKeyPropertyMaps)
				{
					failedSorting = fixedValueFailedGetSortedKeyPropertyMaps;
					return fixedValueGetSortedKeyPropertyMaps;
				}
			}

			ArrayList arrProps = new ArrayList();
			IClassMap superClassMap = GetInheritedClassMap();
			if (getInherited)
			{
				if (superClassMap != null)
				{
					foreach (IPropertyMap propertyMap in superClassMap.GetKeyPropertyMaps())
					{
						if (propertyMap.IsKey)
						{
							arrProps.Add(propertyMap);
						}
					}
				}
			}
			foreach (IPropertyMap propertyMap in m_PropertyMaps)
			{
				if (propertyMap.IsKey)
				{
					arrProps.Add(propertyMap);
				}
			}
			object[] arr = new object[arrProps.Count];
			foreach (IPropertyMap propertyMap in arrProps)
			{
				if (propertyMap.KeyIndex > arr.GetUpperBound(0))
				{
					failedSorting = true;
					break;
				}
				if (!(arr[propertyMap.KeyIndex] == null))
				{
					failedSorting = true;
					break;
				}
				arr[propertyMap.KeyIndex] = propertyMap;
			}
			if (!failedSorting)
			{
				arrProps.Clear();
				foreach (IPropertyMap propertyMap in arr)
				{
					arrProps.Add(propertyMap);
				}				
			}

			if (isFixed)
			{
				if (getInherited)
				{
					fixedValueFailedGetSortedKeyPropertyMapsInherited = failedSorting;
					fixedValueGetSortedKeyPropertyMapsInherited = arrProps;
					fixedGetSortedKeyPropertyMapsInherited = true;
				}
				else
				{
					fixedValueFailedGetSortedKeyPropertyMaps = failedSorting;
					fixedValueGetSortedKeyPropertyMaps = arrProps;
					fixedGetSortedKeyPropertyMaps = true;										
				}
			}

			return arrProps;
		}

		private bool fixedHasAssignedBySource = false;
		private bool fixedValueHasAssignedBySource = false;

		public virtual bool HasAssignedBySource()
		{
			if (fixedHasAssignedBySource)
				return fixedValueHasAssignedBySource;

			bool hasAssignedBySource = false;
			foreach (IPropertyMap propertyMap in GetAllPropertyMaps())
			{
				if (propertyMap.GetIsAssignedBySource())
				{
					hasAssignedBySource = true;
					break;
				}
			}

			if (isFixed)
			{
				fixedValueHasAssignedBySource = hasAssignedBySource;
				fixedHasAssignedBySource = true;
			}

			return hasAssignedBySource;
		}

		private bool fixedHasGuid = false;
		private bool fixedValueHasGuid = false;

		public virtual bool HasGuid()
		{
			if (fixedHasGuid)
				return fixedValueHasGuid;

			bool hasGuid = false;

			IColumnMap columnMap;
			foreach (IPropertyMap propertyMap in GetAllPropertyMaps())
			{
				columnMap = propertyMap.GetColumnMap();
				if (columnMap != null)
				{
					if (columnMap.DataType == DbType.Guid)
					{
						hasGuid = true;
						break;
					}
				}
			}

			if (isFixed)
			{
				fixedValueHasGuid = hasGuid;
				fixedHasGuid = true;
			}

			return hasGuid;
		}

		private bool fixedHasIdAssignedBySource = false;
		private bool fixedValueHasIdAssignedBySource = false;

		public virtual bool HasIdAssignedBySource()
		{
			if (fixedHasIdAssignedBySource)
				return fixedValueHasIdAssignedBySource;

			bool hasIdAssignedBySource = false;

			foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
			{
				if (propertyMap.GetIsAssignedBySource())
				{
					hasIdAssignedBySource = true;
					break;
				}
			}

			if (isFixed)
			{
				fixedValueHasIdAssignedBySource = hasIdAssignedBySource;
				fixedHasIdAssignedBySource = true;
			}

			return hasIdAssignedBySource;
		}

		private bool fixedHasIdGuid = false;
		private bool fixedValueHasIdGuid = false;

		public virtual bool HasIdGuid()
		{
			if (fixedHasIdGuid)
				return fixedValueHasIdGuid;

			bool hasIdGuid = false;

			IColumnMap columnMap;
			foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
			{
				columnMap = propertyMap.GetColumnMap();
				if (columnMap != null)
				{
					if (columnMap.DataType == DbType.Guid)
					{
						hasIdGuid = true;
						break;
					}
				}
			}

			if (isFixed)
			{
				fixedValueHasIdGuid = hasIdGuid;
				fixedHasIdGuid = true;
			}

			return hasIdGuid;
		}

		private bool fixedHasSingleIdAutoIncreaser = false;
		private bool fixedValueHasSingleIdAutoIncreaser = false;

		public virtual bool HasSingleIdAutoIncreaser()
		{
			if (fixedHasSingleIdAutoIncreaser)
				return fixedValueHasSingleIdAutoIncreaser;

			bool hasSingleIdAutoIncreaser = false;

			IColumnMap columnMap;
			foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
			{
				columnMap = propertyMap.GetColumnMap();
				if (columnMap != null)
				{
					if (columnMap.IsAutoIncrease)
					{
						hasSingleIdAutoIncreaser = true;
						break;
					}
				}
			}

			if (isFixed)
			{
				fixedValueHasSingleIdAutoIncreaser = hasSingleIdAutoIncreaser;
				fixedHasSingleIdAutoIncreaser = true;
			}

			return hasSingleIdAutoIncreaser;
		}

		private bool fixedGetAutoIncreasingIdentityPropertyMap = false;
		private IPropertyMap fixedValueGetAutoIncreasingIdentityPropertyMap = null;

		public virtual IPropertyMap GetAutoIncreasingIdentityPropertyMap()
		{
			if (fixedGetAutoIncreasingIdentityPropertyMap)
				return fixedValueGetAutoIncreasingIdentityPropertyMap;

			IPropertyMap autoIncreasingIdentityPropertyMap = null;

			foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
			{
				IColumnMap columnMap = propertyMap.GetColumnMap();
				if (columnMap != null)
				{
					if (columnMap.IsAutoIncrease)
					{
						autoIncreasingIdentityPropertyMap = propertyMap;
						break;
					}
				}
			}

			if (isFixed)
			{
				fixedValueGetAutoIncreasingIdentityPropertyMap = autoIncreasingIdentityPropertyMap;
				fixedGetAutoIncreasingIdentityPropertyMap = true;
			}

			return autoIncreasingIdentityPropertyMap ;
		}

		private bool fixedGetAssignedBySourceIdentityPropertyMap = false;
		private IPropertyMap fixedValueGetAssignedBySourceIdentityPropertyMap = null;

		public virtual IPropertyMap GetAssignedBySourceIdentityPropertyMap()
		{
			if (fixedGetAssignedBySourceIdentityPropertyMap)
				return fixedValueGetAssignedBySourceIdentityPropertyMap;

			IPropertyMap assignedBySourceIdentityPropertyMap = null;

			foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
			{
				if (propertyMap.GetIsAssignedBySource())
				{
					assignedBySourceIdentityPropertyMap = propertyMap;
					break;
				}
			}

			if (isFixed)
			{
				fixedValueGetAssignedBySourceIdentityPropertyMap = assignedBySourceIdentityPropertyMap;
				fixedGetAssignedBySourceIdentityPropertyMap = true;
			}

			return assignedBySourceIdentityPropertyMap;
		}

		public virtual string IdentitySeparator
		{
			get => m_IdentitySeparator;
		    set => m_IdentitySeparator = value;
		}

		private bool fixedGetIdentitySeparator = false;
		private string fixedValueGetIdentitySeparator = null;

		public virtual string GetIdentitySeparator()
		{
			if (fixedGetIdentitySeparator)
				return fixedValueGetIdentitySeparator;

			string identitySeparator = InternalGetIdentitySeparator(new Hashtable());

			if (isFixed)
			{
				fixedValueGetIdentitySeparator = identitySeparator;
				fixedGetIdentitySeparator = true;
			}

			return identitySeparator;
		}

		private string InternalGetIdentitySeparator(Hashtable visited)
		{
			if (visited[this] != null)
				return "";
			visited[this] = this;

			IClassMap superClassMap = this.GetInheritedClassMap() ;
			
			if (superClassMap != null)
				return superClassMap.GetIdentitySeparator();
			return m_IdentitySeparator;			
		}

		public virtual string KeySeparator
		{
			get => m_KeySeparator;
		    set => m_KeySeparator = value;
		}

		private bool fixedGetKeySeparator = false;
		private string fixedValueGetKeySeparator = null;

		public virtual string GetKeySeparator()
		{
			if (fixedGetKeySeparator)
				return fixedValueGetKeySeparator;

			string keySeparator = InternalGetKeySeparator(new Hashtable());

			if (isFixed)
			{
				fixedValueGetKeySeparator = keySeparator;
				fixedGetKeySeparator = true;
			}

			return keySeparator;
		}

		private string InternalGetKeySeparator(Hashtable visited)
		{
			if (visited[this] != null)
				return "";
			visited[this] = this;

			IClassMap superClassMap = this.GetInheritedClassMap() ;
			
			if (superClassMap != null)
				return superClassMap.GetKeySeparator();
			return m_KeySeparator;			
		}

		public virtual string TypeValue
		{
			get => m_TypeValue;
		    set => m_TypeValue = value;
		}

		public virtual string TypeColumn
		{
			get => m_TypeColumn;
		    set => m_TypeColumn = value;
		}

		private bool fixedGetTypeColumnMap = false;
		private IColumnMap fixedValueGetTypeColumnMap = null;

		public virtual IColumnMap GetTypeColumnMap()
		{
			if (fixedGetTypeColumnMap)
				return fixedValueGetTypeColumnMap;

			IColumnMap typeColumnMap = null;
			ITableMap tableMap = GetTableMap();
			if (tableMap != null)
			{
				typeColumnMap = GetTableMap().GetColumnMap(m_TypeColumn);
			}

			if (isFixed)
			{
				fixedValueGetTypeColumnMap = typeColumnMap;
				fixedGetTypeColumnMap = true;
			}

			return typeColumnMap ;
		}

		public virtual void SetTypeColumnMap(IColumnMap value) => m_TypeColumn = value.Name;

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

		public virtual bool IsAbstract
		{
			get => m_IsAbstract;
		    set => m_IsAbstract = value;
		}

		private bool fixedGetAllPropertyMaps = false;
		private ArrayList fixedValueGetAllPropertyMaps = null;
		
		public virtual ArrayList GetAllPropertyMaps()
		{
			if (fixedGetAllPropertyMaps)
				return fixedValueGetAllPropertyMaps;

			ArrayList arrProps = new ArrayList();
			Hashtable hashAdded;
			IClassMap superClass;
			superClass = GetInheritedClassMap();
			if (superClass == null)
			{
				foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
				{
					arrProps.Add(propertyMap);
				}
				foreach (IPropertyMap propertyMap in m_PropertyMaps)
				{
					if (propertyMap.Name.Length > 0)
					{
						if (!(propertyMap.IsIdentity))
						{
							arrProps.Add(propertyMap);
						}
					}
				}
			}
			else
			{
				hashAdded = new Hashtable();
				foreach (IPropertyMap propertyMap in GetIdentityPropertyMaps())
				{
					arrProps.Add(propertyMap);
					hashAdded[propertyMap.Name.ToLower(CultureInfo.InvariantCulture)] = true;
				}
				foreach (IPropertyMap propertyMap in m_PropertyMaps)
				{
					if (propertyMap.Name.Length > 0)
					{
						if (!(propertyMap.IsIdentity))
						{
							arrProps.Add(propertyMap);
							hashAdded[propertyMap.Name.ToLower(CultureInfo.InvariantCulture)] = true;
						}
					}
				}
				if (superClass != null)
				{
					foreach (IPropertyMap propertyMap in superClass.GetAllPropertyMaps())
					{
						if (!(hashAdded.ContainsKey(propertyMap.Name.ToLower(CultureInfo.InvariantCulture))))
						{
							arrProps.Add(propertyMap);
							hashAdded[propertyMap.Name.ToLower(CultureInfo.InvariantCulture)] = true;
						}
					}
				}
			}
			if (isFixed)
			{
				fixedValueGetAllPropertyMaps = arrProps;
				fixedGetAllPropertyMaps = true;
			}

			return arrProps;
		}

		private bool fixedGetInheritedPropertyMaps = false;
		private ArrayList fixedValueGetInheritedPropertyMaps = null;

		public virtual ArrayList GetInheritedPropertyMaps()
		{
			if (fixedGetInheritedPropertyMaps)
				return fixedValueGetInheritedPropertyMaps;

			IClassMap superClass = GetInheritedClassMap();
			ArrayList propertyMaps = new ArrayList();
			if (superClass != null)
			{
				Hashtable hashProps = new Hashtable();
				foreach (IPropertyMap propertyMap in m_PropertyMaps)
				{
					hashProps[propertyMap.Name.ToLower(CultureInfo.InvariantCulture)] = true;
				}
				foreach (IPropertyMap propertyMap in superClass.GetAllPropertyMaps())
				{
					if (!(hashProps.ContainsKey(propertyMap.Name.ToLower(CultureInfo.InvariantCulture))))
					{
						propertyMaps.Add(propertyMap);
					}
				}
			}
			if (isFixed)
			{
				fixedValueGetInheritedPropertyMaps = propertyMaps;
				fixedGetInheritedPropertyMaps = true;
			}

			return propertyMaps;
		}

		private bool fixedGetNonInheritedPropertyMaps = false;
		private ArrayList fixedValueGetNonInheritedPropertyMaps = null;

		public virtual ArrayList GetNonInheritedPropertyMaps()
		{
			if (fixedGetNonInheritedPropertyMaps)
				return fixedValueGetNonInheritedPropertyMaps;

			ArrayList arrProps = new ArrayList();
			foreach (IPropertyMap propertyMap in GetNonInheritedIdentityPropertyMaps())
			{
				arrProps.Add(propertyMap);
			}
			foreach (IPropertyMap propertyMap in m_PropertyMaps)
			{
				if (!(propertyMap.IsIdentity))
				{
					arrProps.Add(propertyMap);
				}
			}

			if (isFixed)
			{
				fixedValueGetNonInheritedPropertyMaps = arrProps;
				fixedGetNonInheritedPropertyMaps = true;
			}

			return arrProps;
		}

		private bool fixedGetNonInheritedIdentityPropertyMaps = false;
		private ArrayList fixedValueGetNonInheritedIdentityPropertyMaps = null;

		public virtual ArrayList GetNonInheritedIdentityPropertyMaps()
		{
			if (fixedGetNonInheritedIdentityPropertyMaps)
				return fixedValueGetNonInheritedIdentityPropertyMaps;

			bool sortingFailed = false;
			ArrayList sortedIdentityPropertyMaps = GetSortedIdentityPropertyMaps(ref sortingFailed, false);

			if (isFixed)
			{
				fixedValueGetNonInheritedIdentityPropertyMaps = sortedIdentityPropertyMaps;
				fixedGetNonInheritedIdentityPropertyMaps = true;
			}

			return sortedIdentityPropertyMaps;
		}

		private bool fixedGetInheritedIdentityPropertyMaps = false;
		private ArrayList fixedValueGetInheritedIdentityPropertyMaps = null;

		public virtual ArrayList GetInheritedIdentityPropertyMaps()
		{
			if (fixedGetInheritedIdentityPropertyMaps)
				return fixedValueGetInheritedIdentityPropertyMaps;

			ArrayList inheritedIdentityPropertyMaps = null ;

			IClassMap superClass = GetInheritedClassMap();
			if (superClass == null)
				inheritedIdentityPropertyMaps = new ArrayList();
			else
				inheritedIdentityPropertyMaps = superClass.GetIdentityPropertyMaps();

			if (isFixed)
			{
				fixedValueGetInheritedIdentityPropertyMaps = inheritedIdentityPropertyMaps;
				fixedGetInheritedIdentityPropertyMaps = true;
			}

			return inheritedIdentityPropertyMaps ;
		}


		public virtual IList GetGeneratedPropertyMaps()
		{
			IList generatedPropertyMaps = new ArrayList();

			foreach (IPropertyMap propertyMap in this.GetAllPropertyMaps())
				if (propertyMap.IsGenerated)
					generatedPropertyMaps.Add(propertyMap);

			return generatedPropertyMaps;
		}


		private bool fixedGetInheritedClassMap = false;
		private IClassMap fixedValueGetInheritedClassMap = null;

		public virtual IClassMap GetInheritedClassMap()
		{
			if (fixedGetInheritedClassMap)
				return fixedValueGetInheritedClassMap;

			IClassMap classMap = null;

			if (m_InheritsClass.Length > 0)
			{
				string ns;
				classMap = DomainMap.GetClassMap(m_InheritsClass);
				if (classMap == null)
				{
					ns = GetNamespace();
					if (ns.Length > 0)
					{
						classMap = DomainMap.GetClassMap(ns + "." + m_InheritsClass);
					}
				}
			}

			if (isFixed)
			{
				fixedValueGetInheritedClassMap = classMap;
				fixedGetInheritedClassMap = true;
			}

			return classMap;
		}

		public virtual string InheritsClass
		{
			get => m_InheritsClass;
		    set
			{
				if (DomainMap != null)
				{
					if (value.Length > 0)
					{
						string ns;
						IClassMap classMap = DomainMap.GetClassMap(value);
						if (classMap == null)
						{
							ns = GetNamespace();
							if (ns.Length > 0)
							{
								classMap = DomainMap.GetClassMap(ns + "." + value);
							}
						}
						if (classMap != null)
						{
							if (!(IsLegalAsSuperClass(classMap)))
							{
								throw new MappingException("Class '" + classMap.Name + "' is illegal as superclass for class '" + this.Name + "'! Would create cyclic inheritance hierarchy!"); // do not localize
							}
						}
					}
				}
				m_InheritsClass = value;
			}
		}

		public ClassType ClassType
		{
			get => this.m_ClassType;
		    set => this.m_ClassType = value;
		}

		public void UpdateName(string newName)
		{
			foreach (IClassMap classMap in DomainMap.ClassMaps)
			{
				if (classMap.GetInheritedClassMap() == this)
				{
					classMap.InheritsClass = newName;
				}
				foreach (IPropertyMap propertyMap in classMap.GetNonInheritedPropertyMaps())
				{
					if (!(propertyMap.ReferenceType == ReferenceType.None))
					{
						if (propertyMap.GetReferencedClassMap() == this)
						{
							if (propertyMap.IsCollection)
							{
								propertyMap.ItemType = newName;
							}
							else
							{
								propertyMap.DataType = newName;
							}
						}
					}
				}
			}
			m_name = newName;
		}

		private bool fixedGetFullName = false;
		private string fixedValueGetFullName = null;

		public virtual string GetFullName()
		{
			if (fixedGetFullName)
				return fixedValueGetFullName;

			string name = m_name;
			if (name != "")
			{
				if (m_DomainMap.RootNamespace.Length > 0)
					name = m_DomainMap.RootNamespace + "." + name;
			}

			if (isFixed)
			{
				fixedValueGetFullName = name;
				fixedGetFullName = true;
			}

			return name;
		}

		private bool fixedGetName = false;
		private string fixedValueGetName = null;

		public virtual string GetName()
		{
			if (fixedGetName)
				return fixedValueGetName;

			string name = m_name;

			if (name != "")
			{
				string[] arrName = name.Split('.');
				name = arrName[arrName.GetUpperBound(0)];
			}

			if (isFixed)
			{
				fixedValueGetName = name;
				fixedGetName = true;
			}

			return name;
		}

		private bool fixedGetNamespace = false;
		private string fixedValueGetNamespace = null;

		public virtual string GetNamespace()
		{
			if (fixedGetNamespace)
				return fixedValueGetNamespace;

			string name = m_name;

			if (name != "")
			{
				string[] arrName = m_name.Split('.');
                if (arrName.GetUpperBound(0) < 1)
                    name = "";
                else
                    name = m_name.Substring(0, m_name.Length - 1 - arrName[arrName.GetUpperBound(0)].Length);
            }

			if (isFixed)
			{
				fixedValueGetNamespace = name;
				fixedGetNamespace = true;
			}

			return name;
		}

		private bool fixedGetFullNamespace = false;
		private string fixedValueGetFullNamespace = null;

		public virtual string GetFullNamespace()
		{
			if (fixedGetFullNamespace)
				return fixedValueGetFullNamespace;

			string rootNs = this.DomainMap.RootNamespace;
			string ns = this.GetNamespace();
			if (rootNs.Length > 0)
			{
				if (ns.Length > 0)
				{
					ns = rootNs + "." + ns;					
				}
				else
				{
					ns = rootNs;
				}
			}

			if (isFixed)
			{
				fixedValueGetFullNamespace = ns;
				fixedGetFullNamespace = true;
			}

			return ns;
		}

		public virtual InheritanceType InheritanceType
		{
			get => m_InheritanceType;
		    set => m_InheritanceType = value;
		}

		public virtual IPropertyMap MustGetPropertyMapForColumnMap(IColumnMap columnMap)
		{
			IPropertyMap propertyMap = GetPropertyMapForColumnMap(columnMap);

			if (propertyMap == null)
				throw new MappingException("Could not find any property mapping to column " + columnMap.TableMap.Name + "." + columnMap.Name + " in the type " + this.GetFullName() + " in map file!");

			return propertyMap;
		}

		public virtual IPropertyMap GetPropertyMapForColumnMap(IColumnMap columnMap)
		{
			string key = "GetPropertyMapForColumnMap_" + columnMap.TableMap.SourceMap.Name + "." + columnMap.TableMap.Name + "." + columnMap.Name;

			if (IsFixed(key))
				return (IPropertyMap) GetFixedValue(key);

			IPropertyMap propertyMapForColumnMap = null;
			foreach (IPropertyMap propertyMap in this.GetAllPropertyMaps())
			{
				IColumnMap testColumnMap = propertyMap.GetColumnMap();
				if (testColumnMap != null)
				{
					if (testColumnMap == columnMap)
					{
						propertyMapForColumnMap = propertyMap;
						break;
					}
				}
				testColumnMap = propertyMap.GetIdColumnMap();
				if (testColumnMap != null)
				{
					if (testColumnMap == columnMap)
					{
						propertyMapForColumnMap = propertyMap;
						break;
					}
				}					
				foreach (IColumnMap checkColumnMap in propertyMap.GetAdditionalColumnMaps())
				{
					if (checkColumnMap == columnMap)
					{
						propertyMapForColumnMap = propertyMap;
						break;
					}
				}					
				foreach (IColumnMap checkColumnMap in propertyMap.GetAdditionalIdColumnMaps())
				{
					if (checkColumnMap == columnMap)
					{
						propertyMapForColumnMap = propertyMap;
						break;
					}
				}
			}

			if (IsFixed())
				SetFixedValue(key, propertyMapForColumnMap);

			return propertyMapForColumnMap;
		}

		private bool fixedGetDirectSubClassMaps = false;
		private ArrayList fixedValueGetDirectSubClassMaps = null;

		public virtual ArrayList GetDirectSubClassMaps()
		{
			if (fixedGetDirectSubClassMaps)
				return fixedValueGetDirectSubClassMaps;

			ArrayList classMaps = new ArrayList();
			IClassMap superClassMap;
			foreach (IClassMap classMap in m_DomainMap.ClassMaps)
			{
				if (!(classMap == this))
				{
					superClassMap = classMap.GetInheritedClassMap();
					if (superClassMap == null)
					{
						if (superClassMap == this)
						{
							classMaps.Add(classMap);
						}
					}
				}
			}

			if (isFixed)
			{
				fixedValueGetDirectSubClassMaps = classMaps;
				fixedGetDirectSubClassMaps = true;
			}

			return classMaps;
		}

		private bool fixedGetSubClassMaps = false;
		private ArrayList fixedValueGetSubClassMaps = null;

		public virtual ArrayList GetSubClassMaps()
		{
			if (fixedGetSubClassMaps)
				return fixedValueGetSubClassMaps;

			ArrayList classMaps = new ArrayList();
			foreach (IClassMap classMap in m_DomainMap.ClassMaps)
			{
				if (!(classMap == this))
				{
					if (IsSubClass(classMap))
					{
						classMaps.Add(classMap);
					}
				}
			}

			if (isFixed)
			{
				fixedValueGetSubClassMaps = classMaps;
				fixedGetSubClassMaps = true;
			}

			return classMaps;
		}

		//retrns true if this class equals any of the passed 
		//in class' superclasses. ("Is the passed in class a subclass
		//of this class)
		public virtual bool IsSubClass(IClassMap classMap)
		{
			IClassMap superClassMap = null;
			superClassMap = classMap.GetInheritedClassMap();
			while (superClassMap != null)
			{
				if (superClassMap == this)
				{
					return true;
				}
				superClassMap = superClassMap.GetInheritedClassMap();
			}
			return false;
		}

		public virtual bool IsSubClassOrThisClass(IClassMap classMap)
		{
			if (classMap == this)
			{
				return true;
			}
			return IsSubClass(classMap);
		}

		public virtual bool HasSubClasses()
		{
			foreach (IClassMap classMap in m_DomainMap.ClassMaps)
			{
				if (!(classMap == this))
				{
					if (IsSubClass(classMap))
					{
						return true;
					}
				}
			}
			return false;
		}


		public virtual IClassMap GetSubClassWithTypeValue(string value)
		{
			if (TypeValue == value)
			{
				return this;
			}
			foreach (IClassMap classMap in GetSubClassMaps())
			{
				if (classMap.TypeValue == value)
				{
					return classMap;
				}
			}
			return null;
		}

		private bool fixedGetBaseClassMap = false;
		private IClassMap fixedValueGetBaseClassMap = null;

		public virtual IClassMap GetBaseClassMap()
		{
			if (fixedGetBaseClassMap)
				return fixedValueGetBaseClassMap;

			IClassMap classMap = this;
			IClassMap baseClassMap = classMap.GetInheritedClassMap();
			while (baseClassMap != null)
			{
				classMap = baseClassMap;
				baseClassMap = classMap.GetInheritedClassMap();
			}

			if (isFixed)
			{
				fixedValueGetBaseClassMap = classMap;
				fixedGetBaseClassMap = true;
			}

			return classMap;
		}

		private bool fixedIsInHierarchy = false;
		private bool fixedValueIsInHierarchy = false;

		public virtual bool IsInHierarchy()
		{
			if (fixedIsInHierarchy)
				return fixedValueIsInHierarchy;

			bool isInHierarchy = false;

			if (this.GetInheritedClassMap() != null)
				isInHierarchy = true;
			else if (this.HasSubClasses())
				isInHierarchy = true;

			if (isFixed)
			{
				fixedValueIsInHierarchy = isInHierarchy;
				fixedIsInHierarchy = true;
			}

			return isInHierarchy;
		}

		public bool IsInheritedProperty(IPropertyMap propertyMap)
		{
			IClassMap superClass = GetInheritedClassMap();
			if (superClass != null)
			{
				foreach (IPropertyMap testPropertyMap in superClass.GetAllPropertyMaps())
				{
					if (testPropertyMap.Name == propertyMap.Name)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool IsShadowingProperty(IPropertyMap propertyMap)
		{
			IClassMap superClass = GetInheritedClassMap();
			if (superClass != null)
			{
				foreach (IPropertyMap testPropertyMap in superClass.GetAllPropertyMaps())
				{
					if (testPropertyMap.Name == propertyMap.Name)
					{
						foreach (IPropertyMap testPropertyMap2 in m_PropertyMaps)
						{
							if (testPropertyMap2.Name == propertyMap.Name)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}


		public virtual bool IsReadOnly
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get
			{
				if (DomainMap.IsReadOnly)
				{
					return true;
				}
				return m_IsReadOnly;
			}
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_IsReadOnly = value;
		}

		public virtual string InheritsTransientClass
		{
			get => m_InheritsTransientClass;
		    set => m_InheritsTransientClass = value;
		}

		[XmlArrayItem(typeof (string))]
		public virtual ArrayList ImplementsInterfaces
		{
			get => m_ImplementsInterfaces;
		    set => m_ImplementsInterfaces = value;
		}

		[XmlArrayItem(typeof (string))]
		public virtual ArrayList ImportsNamespaces
		{
			get => m_ImportsNamespaces;
		    set => m_ImportsNamespaces = value;
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

		public virtual string AssemblyName
		{
			get => m_AssemblyName;
		    set => m_AssemblyName = value;
		}

				
		public ValidationMode ValidationMode
		{
			get => this.m_ValidationMode;
		    set => this.m_ValidationMode = value;
		}

		public virtual string ValidateMethod
		{
			get => m_ValidateMethod;
		    set => m_ValidateMethod = value;
		}

		public virtual string LoadSpan
		{
			get => m_LoadSpan;
		    set => m_LoadSpan = value;
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
				return this.DomainMap.TimeToLive;
			return this.m_TimeToLive;
		}
		
		public TimeToLiveBehavior GetTimeToLiveBehavior()
		{
			if (this.m_TimeToLiveBehavior == TimeToLiveBehavior.Default)
				return this.DomainMap.TimeToLiveBehavior;
			return this.m_TimeToLiveBehavior;
		}

		public LoadBehavior LoadBehavior
		{
			get => this.m_LoadBehavior;
		    set => this.m_LoadBehavior = value;
		}

		public LoadBehavior GetLoadBehavior()
		{
			if (this.m_LoadBehavior == LoadBehavior.Default)
				return this.DomainMap.LoadBehavior;
			return this.m_LoadBehavior;
		}


		public virtual string GetAssemblyName()
		{
			if (m_AssemblyName.Length > 0)
			{
				return m_AssemblyName;
			}
			else
			{
				return this.DomainMap.GetAssemblyName();
			}
		}

		
		
		public virtual string GetInheritsTransientClass()
		{
			if (m_InheritsTransientClass.Length > 0)
			{
				return m_InheritsTransientClass;
			}
			else
			{
				if (m_DomainMap != null)
				{
					return m_DomainMap.InheritsTransientClass;
				}
			}
			return "";
		}

		public virtual ArrayList GetImplementsInterfaces()
		{
			ArrayList returnList = (ArrayList) m_DomainMap.ImplementsInterfaces.Clone();
			Hashtable added = new Hashtable();
			foreach (string interfaceName in returnList)
			{
				if (!(added.ContainsKey(interfaceName.ToLower(CultureInfo.InvariantCulture))))
				{
					added[interfaceName.ToLower(CultureInfo.InvariantCulture)] = true;
				}
			}
			foreach (string interfaceName in m_ImplementsInterfaces)
			{
				if (!(added.ContainsKey(interfaceName.ToLower(CultureInfo.InvariantCulture))))
				{
					returnList.Add(interfaceName);
				}
			}
			return returnList;
		}

		public virtual ArrayList GetImportsNamespaces()
		{
			ArrayList returnList = (ArrayList) m_DomainMap.ImportsNamespaces.Clone();
			Hashtable added = new Hashtable();
			foreach (string namespaceName in returnList)
			{
				if (!(added.ContainsKey(namespaceName.ToLower(CultureInfo.InvariantCulture))))
				{
					added[namespaceName.ToLower(CultureInfo.InvariantCulture)] = true;
				}
			}
			foreach (string namespaceName in m_ImportsNamespaces)
			{
				if (!(added.ContainsKey(namespaceName.ToLower(CultureInfo.InvariantCulture))))
				{
					returnList.Add(namespaceName);
				}
			}
			return returnList;
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

		public virtual string SourceClass
		{
			get => m_SourceClass;
		    set => m_SourceClass = value;
		}

		public virtual IClassMap GetSourceClassMap()
		{
			if (m_SourceClass == "")
				return null;

			return this.DomainMap.GetClassMap(m_SourceClass);
		}

		public virtual IClassMap GetSourceClassMapOrSelf()
		{
			if (m_SourceClass == "")
				return this;

			IClassMap sourceClassMap = this.GetSourceClassMap();

			if (sourceClassMap == null)
				sourceClassMap = this;

			return sourceClassMap;
		}

		#endregion

		#region Object/Document Mapping

		public virtual string DocSource
		{
			get => m_DocSource;
		    set => m_DocSource = value;
		}

		public virtual string DocElement
		{
			get => m_DocElement;
		    set => m_DocElement = value;
		}
		
		public virtual string  GetDocElement()
		{
			if (m_DocElement.Length > 0)
				return m_DocElement;

			return this.GetName();
		}
		
		public virtual string DocRoot
		{
			get => m_DocRoot;
		    set => m_DocRoot = value;
		}
				
		public virtual string GetDocRoot()
		{
			if (m_DocRoot.Length > 0)
				return m_DocRoot;

			return this.GetName();
		}

		public virtual ISourceMap GetDocSourceMap()
		{
			if (DocSource == "")
			{
				return m_DomainMap.GetDocSourceMap();
			}
			else
			{
				return m_DomainMap.GetSourceMap(DocSource);
			}
		}

		public virtual void SetDocSourceMap(ISourceMap value) => m_DocSource = value.Name;

	    public virtual DocClassMapMode DocClassMapMode
		{
			get => m_DocClassMapMode;
	        set => m_DocClassMapMode = value;
	    }

		
		public virtual string DocParentProperty
		{
			get => m_DocParentProperty;
		    set => m_DocParentProperty = value;
		}

				
		public virtual IPropertyMap GetDocParentPropertyMap()
		{
			if (m_DocParentProperty.Length < 1)
				return null;
			
			return MustGetPropertyMap(m_DocParentProperty);
		}

		#endregion

		#region Cloning

		public override IMap Clone()
		{
			IClassMap classMap = new ClassMap();
			Copy(classMap);
			return classMap;
		}

		public override IMap DeepClone()
		{
			IClassMap classMap = new ClassMap();
			DeepCopy(classMap);
			return classMap;
		}

		protected virtual void DoDeepCopy(IClassMap classMap)
		{
			IPropertyMap clonePropertyMap;
			ICodeMap cloneCodeMap;
			IEnumValueMap cloneEnumValueMap;
			foreach (IPropertyMap propertyMap in this.PropertyMaps)
			{
				clonePropertyMap = (IPropertyMap) propertyMap.DeepClone();
				clonePropertyMap.ClassMap = classMap;
			}
			foreach (ICodeMap codeMap in this.CodeMaps)
			{
				cloneCodeMap = (ICodeMap) codeMap.DeepClone();
				classMap.CodeMaps.Add(cloneCodeMap);
			}
			foreach (IEnumValueMap enumValueMap in this.EnumValueMaps)
			{
				cloneEnumValueMap = (IEnumValueMap) enumValueMap.DeepClone();
				classMap.EnumValueMaps.Add(cloneEnumValueMap);
			}
		}

		public override void DeepCopy(IMap mapObject)
		{
			IClassMap classMap = (IClassMap) mapObject;
			classMap.PropertyMaps.Clear();
			classMap.CodeMaps.Clear();
			classMap.EnumValueMaps.Clear();
			Copy(classMap);
			DoDeepCopy(classMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			IClassMap classMap = (IClassMap) compareTo;
			IPropertyMap checkPropertyMap;
			ICodeMap checkCodeMap;
			IEnumValueMap checkEnumValueMap;
			if (!(this.PropertyMaps.Count == classMap.PropertyMaps.Count))
			{
				return false;
			}
			if (!(this.CodeMaps.Count == classMap.CodeMaps.Count))
			{
				return false;
			}
			if (!(this.EnumValueMaps.Count == classMap.EnumValueMaps.Count))
			{
				return false;
			}
			foreach (IPropertyMap propertyMap in this.PropertyMaps)
			{
				checkPropertyMap = classMap.GetPropertyMap(propertyMap.Name);
				if (checkPropertyMap == null)
				{
					return false;
				}
				else
				{
					if (!(propertyMap.DeepCompare(checkPropertyMap)))
					{
						return false;
					}
				}
			}
			foreach (ICodeMap codeMap in this.CodeMaps)
			{
				checkCodeMap = classMap.GetCodeMap(codeMap.CodeLanguage);
				if (checkCodeMap == null)
				{
					return false;
				}
				else
				{
					if (!(codeMap.DeepCompare(checkCodeMap)))
					{
						return false;
					}
				}
			}
			foreach (IEnumValueMap enumValueMap in this.EnumValueMaps)
			{
				checkEnumValueMap = classMap.GetEnumValueMap(enumValueMap.Name);
				if (checkEnumValueMap == null)
				{
					return false;
				}
				else
				{
					if (!(enumValueMap.DeepCompare(checkEnumValueMap)))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override void DeepMerge(IMap mapObject)
		{
			Copy(mapObject);
			IClassMap classMap = (IClassMap) mapObject;
			IPropertyMap propertyMap;
			IPropertyMap checkPropertyMap;
			ICodeMap codeMap;
			ICodeMap checkCodeMap;
			IEnumValueMap enumValueMap;
			IEnumValueMap checkEnumValueMap;
			ArrayList remove = new ArrayList();
			foreach (IPropertyMap iPropertyMap in this.PropertyMaps)
			{
				checkPropertyMap = classMap.GetPropertyMap(iPropertyMap.Name);
				if (checkPropertyMap == null)
				{
					checkPropertyMap = (IPropertyMap) iPropertyMap.DeepClone();
					checkPropertyMap.ClassMap = classMap;
				}
				else
				{
					iPropertyMap.DeepMerge(checkPropertyMap);
				}
			}
			foreach (IPropertyMap iPropertyMap in classMap.PropertyMaps)
			{
				propertyMap = this.GetPropertyMap(iPropertyMap.Name);
				if (propertyMap == null)
				{
					remove.Add(iPropertyMap);
				}
			}
			foreach (IPropertyMap iPropertyMap in remove)
			{
				classMap.PropertyMaps.Remove(iPropertyMap);
			}

			remove.Clear() ;
			foreach (ICodeMap iCodeMap in this.CodeMaps)
			{
				checkCodeMap = classMap.GetCodeMap(iCodeMap.CodeLanguage);
				if (checkCodeMap == null)
				{
					checkCodeMap = (ICodeMap) iCodeMap.DeepClone();
					classMap.CodeMaps.Add(checkCodeMap);
				}
				else
				{
					iCodeMap.DeepMerge(checkCodeMap);
				}
			}
			foreach (ICodeMap iCodeMap in classMap.CodeMaps)
			{
				codeMap = this.GetCodeMap(iCodeMap.CodeLanguage );
				if (codeMap == null)
				{
					remove.Add(iCodeMap);
				}
			}
			foreach (ICodeMap iCodeMap in remove)
			{
				classMap.CodeMaps.Remove(iCodeMap);
			}

			remove.Clear() ;
			foreach (IEnumValueMap iEnumValueMap in this.EnumValueMaps)
			{
				checkEnumValueMap = classMap.GetEnumValueMap(iEnumValueMap.Name);
				if (checkEnumValueMap == null)
				{
					checkEnumValueMap = (IEnumValueMap) iEnumValueMap.DeepClone();
					classMap.EnumValueMaps.Add(checkEnumValueMap);
				}
				else
				{
					iEnumValueMap.DeepMerge(checkEnumValueMap);
				}
			}
			foreach (IEnumValueMap iEnumValueMap in classMap.EnumValueMaps)
			{
				enumValueMap = this.GetEnumValueMap(iEnumValueMap.Name);
				if (enumValueMap == null)
				{
					remove.Add(iEnumValueMap);
				}
			}
			foreach (IEnumValueMap iEnumValueMap in remove)
			{
				classMap.EnumValueMaps.Remove(iEnumValueMap);
			}

		}

		public override void Copy(IMap mapObject)
		{
			IClassMap classMap = (IClassMap) mapObject;
			classMap.IdentitySeparator = this.IdentitySeparator;
			classMap.KeySeparator = this.KeySeparator;
			classMap.InheritanceType = this.InheritanceType;
			classMap.InheritsClass = this.InheritsClass;
			classMap.MergeBehavior = this.MergeBehavior;
			classMap.RefreshBehavior = this.RefreshBehavior;
			classMap.ListCountLoadBehavior = this.ListCountLoadBehavior;
			classMap.Name = this.Name;
			classMap.ClassType = this.ClassType;
			classMap.Source = this.Source;
			classMap.Table = this.Table;
			classMap.TypeColumn = this.TypeColumn;
			classMap.TypeValue = this.TypeValue;
			classMap.IsAbstract = this.IsAbstract;
			classMap.IsReadOnly = this.IsReadOnly;
			classMap.InheritsTransientClass = this.InheritsTransientClass;
			classMap.ImplementsInterfaces = (ArrayList) this.ImplementsInterfaces.Clone();
			classMap.ImportsNamespaces = (ArrayList) this.ImportsNamespaces.Clone();
			classMap.DeleteOptimisticConcurrencyBehavior = this.DeleteOptimisticConcurrencyBehavior;
			classMap.UpdateOptimisticConcurrencyBehavior = this.UpdateOptimisticConcurrencyBehavior;
			classMap.AssemblyName = this.AssemblyName;
			classMap.ValidateMethod = this.ValidateMethod;
			classMap.LoadSpan = this.LoadSpan;
			classMap.ValidationMode = this.ValidationMode;
			classMap.TimeToLive = this.TimeToLive;
			classMap.TimeToLiveBehavior = this.TimeToLiveBehavior;
			classMap.CommitRegions = this.CommitRegions;
			classMap.LoadBehavior = this.LoadBehavior;
			classMap.SourceClass = this.SourceClass;
			classMap.DocSource = this.DocSource;
			classMap.DocElement = this.DocElement;
			classMap.DocClassMapMode = this.DocClassMapMode;
			classMap.DocParentProperty = this.DocParentProperty;
			classMap.DocRoot = this.DocRoot;
		}

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			IClassMap classMap = (IClassMap) compareTo;
			if (!(classMap.IdentitySeparator == this.IdentitySeparator))
			{
				return false;
			}
			if (!(classMap.ClassType  == this.ClassType))
			{
				return false;
			}
			if (!(classMap.KeySeparator == this.KeySeparator))
			{
				return false;
			}
			if (!(classMap.InheritanceType == this.InheritanceType))
			{
				return false;
			}
			if (!(classMap.InheritsClass == this.InheritsClass))
			{
				return false;
			}
			if (!(classMap.MergeBehavior == this.MergeBehavior))
			{
				return false;
			}
			if (!(classMap.RefreshBehavior == this.RefreshBehavior))
			{
				return false;
			}
			if (!(classMap.ListCountLoadBehavior == this.ListCountLoadBehavior))
			{
				return false;
			}
			if (!(classMap.Name == this.Name))
			{
				return false;
			}
			if (!(classMap.Source == this.Source))
			{
				return false;
			}
			if (!(classMap.Table == this.Table))
			{
				return false;
			}
			if (!(classMap.TypeColumn == this.TypeColumn))
			{
				return false;
			}
			if (!(classMap.TypeValue == this.TypeValue))
			{
				return false;
			}
			if (!(classMap.IsAbstract == this.IsAbstract))
			{
				return false;
			}
			if (!(classMap.IsReadOnly == this.IsReadOnly))
			{
				return false;
			}
			if (!(classMap.InheritsTransientClass == this.InheritsTransientClass))
			{
				return false;
			}
			if (!(classMap.DeleteOptimisticConcurrencyBehavior == this.DeleteOptimisticConcurrencyBehavior))
			{
				return false;
			}
			if (!(classMap.UpdateOptimisticConcurrencyBehavior == this.UpdateOptimisticConcurrencyBehavior))
			{
				return false;
			}
			if (!(classMap.AssemblyName == this.AssemblyName))
			{
				return false;
			}
			if (!(classMap.LoadSpan == this.LoadSpan))
			{
				return false;
			}
			if (!(classMap.TimeToLive == this.TimeToLive))
			{
				return false;
			}
			if (!(classMap.TimeToLiveBehavior == this.TimeToLiveBehavior))
			{
				return false;
			}
			if (!(classMap.CommitRegions == this.commitRegions))
			{
				return false;
			}
			if (!(classMap.LoadBehavior == this.LoadBehavior))
			{
				return false;
			}
			if (!(classMap.ValidateMethod == this.ValidateMethod))
			{
				return false;
			}
			if (!(classMap.ValidationMode == this.ValidationMode))
			{
				return false;
			}
			if (!(classMap.SourceClass == this.SourceClass))
			{
				return false;
			}
			if (!(classMap.DocSource == this.DocSource))
			{
				return false;
			}
			if (!(classMap.DocElement == this.DocElement))
			{
				return false;
			}
			if (!(classMap.DocRoot == this.DocRoot))
			{
				return false;
			}
			if (!(classMap.DocClassMapMode == this.DocClassMapMode))
			{
				return false;
			}
			if (!(classMap.DocParentProperty == this.DocParentProperty))
			{
				return false;
			}
			if (!(CompareArrayLists(classMap.ImplementsInterfaces, this.ImplementsInterfaces)))
			{
				return false;
			}
			if (!(CompareArrayLists(classMap.ImportsNamespaces, this.ImportsNamespaces)))
			{
				return false;
			}
			return true;
		}

		#endregion

		#region IMap

		public override string GetKey() => m_DomainMap.Name + "." + this.Name;

	    #endregion

		#region IFixate

		public override void Fixate()
		{
			base.Fixate();
			foreach (IPropertyMap propertyMap in m_PropertyMaps)
			{
				propertyMap.Fixate();
			}
			this.isFixed = true; 
		}

		public override void UnFixate()
		{
			base.UnFixate();
			foreach (IPropertyMap propertyMap in m_PropertyMaps)
			{
				propertyMap.UnFixate();
			}
			this.isFixed = false; 
			this.fixedGetSource = false;
			this.fixedGetSourceMap = false;
			this.fixedGetTable = false;
			this.fixedGetTableMap = false;
			this.fixedGetPrimaryPropertyMaps = false;
			this.fixedGetIdentityPropertyMaps = false;
			this.fixedGetSortedIdentityPropertyMaps = false;
			this.fixedGetSortedIdentityPropertyMapsInherited = false;
			this.fixedGetSortedKeyPropertyMaps = false;
			this.fixedGetSortedKeyPropertyMapsInherited = false;
			this.fixedHasAssignedBySource = false;
			this.fixedHasGuid = false;
			this.fixedHasIdAssignedBySource = false;
			this.fixedHasIdGuid = false;
			this.fixedHasSingleIdAutoIncreaser = false;
			this.fixedGetAutoIncreasingIdentityPropertyMap = false;
			this.fixedGetAssignedBySourceIdentityPropertyMap = false;
			this.fixedGetIdentitySeparator = false;
			this.fixedGetTypeColumnMap = false;
			this.fixedGetAllPropertyMaps = false;
			this.fixedGetInheritedPropertyMaps = false;
			this.fixedGetNonInheritedPropertyMaps = false;
			this.fixedGetNonInheritedIdentityPropertyMaps = false;
			this.fixedGetInheritedIdentityPropertyMaps = false;
			this.fixedGetInheritedClassMap = false;
			this.fixedGetFullName = false;
			this.fixedGetName = false;
			this.fixedGetNamespace = false;
			this.fixedGetFullNamespace = false;
			this.fixedGetDirectSubClassMaps = false;
			this.fixedGetSubClassMaps = false;
			this.fixedGetBaseClassMap = false;
			this.fixedIsInHierarchy = false;
			this.fixedGetCommitRegions = false;
            this.fixedGetPropertyMap = false;
            this.fixedValueGetPropertyMap.Clear();
		}

		#endregion
		
		#region FromClassMapAttribute

		public static void FromClassMapAttribute(ClassMapAttribute attrib, Type type, IClassMap classMap)
		{
			classMap.Name = type.Name;

			if (type.IsInterface)
				classMap.ClassType = ClassType.Interface;
			else if (type.IsEnum)
				classMap.ClassType = ClassType.Enum;
			else
				classMap.ClassType = ClassType.Class;

			classMap.IsAbstract = type.IsAbstract;
			
			Type tmp = type;

			while (tmp.Assembly is AssemblyBuilder)
				tmp = tmp.BaseType;

			Type baseType = tmp.BaseType;

			IClassMap baseClassMap = (classMap.DomainMap.GetClassMap(baseType.GetType()));
			if (baseClassMap != null)
				classMap.InheritsClass = baseClassMap.Name;

			classMap.CommitRegions = attrib.CommitRegions ;
			classMap.DeleteOptimisticConcurrencyBehavior = attrib.DeleteOptimisticConcurrencyBehavior ;
			classMap.DocClassMapMode = attrib.DocClassMapMode ;
			classMap.DocElement = attrib.DocElement  ;
			classMap.DocParentProperty = attrib.DocParentProperty ;
			classMap.DocRoot = attrib.DocRoot ;
			classMap.DocSource = attrib.DocSource ;
			classMap.IdentitySeparator = attrib.IdentitySeparator ;
			classMap.InheritanceType = attrib.InheritanceType ;
			classMap.IsReadOnly = attrib.IsReadOnly ;
			classMap.KeySeparator = attrib.KeySeparator ;
			classMap.LoadBehavior = attrib.LoadBehavior ;
			classMap.LoadSpan = attrib.LoadSpan ;
			classMap.MergeBehavior = attrib.MergeBehavior ;
			classMap.RefreshBehavior = attrib.RefreshBehavior ;
			classMap.ListCountLoadBehavior = attrib.ListCountLoadBehavior;
			classMap.Source = attrib.Source ;
			classMap.SourceClass = attrib.SourceClass ;
			classMap.Table = attrib.Table ;
			classMap.TimeToLive = attrib.TimeToLive ;
			classMap.TimeToLiveBehavior = attrib.TimeToLiveBehavior ;
			classMap.TypeColumn = attrib.TypeColumn ;
			classMap.TypeValue = attrib.TypeValue ;
			classMap.UpdateOptimisticConcurrencyBehavior = attrib.UpdateOptimisticConcurrencyBehavior  ;
			classMap.ValidateMethod = attrib.ValidateMethod ;
			classMap.ValidationMode = attrib.ValidationMode ;
		}

		#endregion

		public virtual bool IsLegalAsSuperClass(IClassMap classMap)
		{
			IClassMap superClassMap = null;
			if (classMap == null)
			{
				return true;
			}
			if (classMap == this)
			{
				return false;
			}
			superClassMap = classMap.GetInheritedClassMap();
			while (superClassMap != null)
			{
				if (superClassMap == this)
				{
					return false;
				}
				superClassMap = superClassMap.GetInheritedClassMap();
			}
			return true;
		}

		//Determines if this classMap has one or more uni-directional (lacking inverse property) 
		//reference properties to the specified class or any of its superclasses
		public virtual bool HasUniDirectionalReferenceTo(IClassMap classMap, bool nullableOnly)
		{
			foreach (IPropertyMap propertyMap in this.GetAllPropertyMaps())
			{
				if (propertyMap.ReferenceType != ReferenceType.None)
				{
					IClassMap refClassMap = propertyMap.GetReferencedClassMap();
					if (refClassMap != null)
					{
						if (refClassMap.IsSubClassOrThisClass(classMap))
						{
							if (propertyMap.GetInversePropertyMap() == null)
							{
								if (nullableOnly == false || propertyMap.GetIsNullable())
								{
									return true;									
								}
							}
						}						
					}
				}
			}
			return false;
		}

		public virtual IList GetUniDirectionalReferencesTo(IClassMap classMap, bool nullableOnly)
		{
			IList result = new ArrayList() ; 
			foreach (IPropertyMap propertyMap in this.GetAllPropertyMaps())
			{
				if (propertyMap.ReferenceType != ReferenceType.None)
				{
					IClassMap refClassMap = propertyMap.GetReferencedClassMap();
					if (refClassMap != null)
					{
						if (refClassMap.IsSubClassOrThisClass(classMap))
						{
							if (propertyMap.GetInversePropertyMap() == null)
							{
								if (nullableOnly == false || propertyMap.GetIsNullable())
								{
									result.Add(propertyMap);
								}
							}
						}						
					}
				}
			}
			return result;
		}

		public virtual bool HasIdentityGenerators()
		{
			foreach (IPropertyMap propertyMap in this.GetIdentityPropertyMaps())
				if (propertyMap.IdentityGenerator.Length > 0)
					return true;
			return false;
		}


	}
}