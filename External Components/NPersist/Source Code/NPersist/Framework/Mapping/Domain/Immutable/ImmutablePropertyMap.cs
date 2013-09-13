using System;
using System.Collections;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;
using System.Globalization;

namespace Puzzle.NPersist.Framework.Mapping.Immutable
{
	public class ImmutablePropertyMap : IPropertyMap
	{
        #region Property ClassMap 
        private IClassMap classMap;
        public IClassMap ClassMap
        {
            get
            {
                return this.classMap;
            }
            set
            {
                this.classMap = value;
            }
        }                        
        #endregion
        
        public void SetClassMap(IClassMap value)
        {
            this.ClassMap = value;
        }

        #region Property FieldName 
        private string fieldName;
        public string FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }                        
        #endregion
        
        public string GetFieldName()
        {
            return this.FieldName;
        }

        #region Property DataType 
        private string dataType;
        public string DataType
        {
            get
            {
                return this.dataType;
            }
            set
            {
                this.dataType = value;
            }
        }                        
        #endregion

        #region Property ItemType 
        private string itemType;
        public string ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }                        
        #endregion

        #region Property DefaultValue 
        private string defaultValue;
        public string DefaultValue
        {
            get
            {
                return this.defaultValue;
            }
            set
            {
                this.defaultValue = value;
            }
        }                        
        #endregion

        #region Property IsGenerated
        private bool isGenerated;
        public bool IsGenerated
        {
            get
            {
                return this.isGenerated;
            }
            set
            {
                this.isGenerated = value;
            }
        }
        #endregion

        #region Property IsCollection 
        private bool isCollection;
        public bool IsCollection
        {
            get
            {
                return this.isCollection;
            }
            set
            {
                this.isCollection = value;
            }
        }                        
        #endregion

        #region Property IsNullable 
        private bool isNullable;
        public bool IsNullable
        {
            get
            {
                return this.isNullable;
            }
            set
            {
                this.isNullable = value;
            }
        }                        
        #endregion

        public IList GetCommitRegions()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property CommitRegions
        private bool commitRegions;
        public bool CommitRegions
        {
            get
            {
                return this.CommitRegions;
            }
            set
            {
                this.CommitRegions = value;
            }
        }
        #endregion

        public bool GetIsNullable()
        {
            return this.IsNullable;
        }

        #region Property MaxLength 
        private int maxLength;
        public int MaxLength
        {
            get
            {
                return this.maxLength;
            }
            set
            {
                this.maxLength = value;
            }
        }                        
        #endregion

        public int GetMaxLength()
        {
            return this.MaxLength;
        }

        #region Property MinLength 
        private int minLength;
        public int MinLength
        {
            get
            {
                return this.minLength;
            }
            set
            {
                this.minLength = value;
            }
        }                        
        #endregion

        #region Property MaxValue 
        private string maxValue;
        public string MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;
            }
        }                        
        #endregion
        
        #region Property MinValue 
        private string minValue;
        public string MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;
            }
        }                        
        #endregion
        
        #region Property IsAssignedBySource 
        private bool isAssignedBySource;
        public bool IsAssignedBySource
        {
            get
            {
                return this.isAssignedBySource;
            }
            set
            {
                this.isAssignedBySource = value;
            }
        }                        
        #endregion

        public bool GetIsAssignedBySource()
        {
            return this.IsAssignedBySource;
        }

        #region Property ReferencedClassMap 
        private IClassMap referencedClassMap;
        public IClassMap ReferencedClassMap
        {
            get
            {
                return this.referencedClassMap;
            }
            set
            {
                this.referencedClassMap = value;
            }
        }                        
        #endregion

        public IClassMap MustGetReferencedClassMap()
        {
            if (this.ReferencedClassMap == null)
                throw new NullReferenceException();

            return this.ReferencedClassMap;
        }

        public IClassMap GetReferencedClassMap()
        {
            return this.ReferencedClassMap;
        }

        #region Property Source 
        private string source;
        public string Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }                        
        #endregion

        public ISourceMap GetSourceMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetSourceMap(ISourceMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property Table 
        private string table;
        public string Table
        {
            get
            {
                return this.table;
            }
            set
            {
                this.table = value;
            }
        }                        
        #endregion

        #region Property TableMap 
        private ITableMap tableMap;
        public ITableMap TableMap
        {
            get
            {
                return this.tableMap;
            }
            set
            {
                this.tableMap = value;
            }
        }                        
        #endregion

        public ITableMap MustGetTableMap()
        {
            if (this.TableMap == null)
                throw new NullReferenceException();

            return this.TableMap;
        }

        public ITableMap GetTableMap()
        {
            return this.TableMap;
        }

        public void SetTableMap(ITableMap value)
        {
            this.TableMap = value;
        }

        #region Property Column 
        private string column;
        public string Column
        {
            get
            {
                return this.column;
            }
            set
            {
                this.column = value;
            }
        }                        
        #endregion

        #region Property ColumnMap 
        private IColumnMap columnMap;
        public IColumnMap ColumnMap
        {
            get
            {
                return this.columnMap;
            }
            set
            {
                this.columnMap = value;
            }
        }                        
        #endregion

        public IColumnMap GetColumnMap()
        {
            return this.ColumnMap;
        }

        public IColumnMap MustGetColumnMap()
        {
            if (this.ColumnMap == null)
                throw new NullReferenceException();
            return this.ColumnMap;
        }

        public void SetColumnMap(IColumnMap value)
        {
            this.ColumnMap = value;
        }

        #region Property IdColumn 
        private string idColumn;
        public string IdColumn
        {
            get
            {
                return this.idColumn;
            }
            set
            {
                this.idColumn = value;
            }
        }                        
        #endregion

        public IColumnMap GetIdColumnMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetIdColumnMap(IColumnMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property AdditionalColumns 
        private ArrayList additionalColumns;
        public ArrayList AdditionalColumns
        {
            get
            {
                return this.additionalColumns;
            }
            set
            {
                this.additionalColumns = value;
            }
        }                        
        #endregion

        public ArrayList GetAdditionalColumnMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property AdditionalIdColumns 
        private ArrayList additionalIdColumns;
        public ArrayList AdditionalIdColumns
        {
            get
            {
                return this.additionalIdColumns;
            }
            set
            {
                this.additionalIdColumns = value;
            }
        }                        
        #endregion

        public ArrayList GetAdditionalIdColumnMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property Inverse 
        private string inverse;
        public string Inverse
        {
            get
            {
                return this.inverse;
            }
            set
            {
                this.inverse = value;
            }
        }                        
        #endregion

        #region Property InversePropertyMap 
        private IPropertyMap inversePropertyMap;
        public IPropertyMap InversePropertyMap
        {
            get
            {
                return this.inversePropertyMap;
            }
            set
            {
                this.inversePropertyMap = value;
            }
        }                        
        #endregion

        public IPropertyMap MustGetInversePropertyMap()
        {
            if (this.InversePropertyMap == null)
                throw new NullReferenceException();

            return this.InversePropertyMap;
        }

        public IPropertyMap GetInversePropertyMap()
        {
            return this.InversePropertyMap;
        }

        public void SetInversePropertyMap(IPropertyMap value)
        {
            this.InversePropertyMap = value;
        }

        #region Property IsIdentity 
        private bool isIdentity;
        public bool IsIdentity
        {
            get
            {
                return this.isIdentity;
            }
            set
            {
                this.isIdentity = value;
            }
        }                        
        #endregion

        #region Property IdentityIndex 
        private int identityIndex;
        public int IdentityIndex
        {
            get
            {
                return this.identityIndex;
            }
            set
            {
                this.identityIndex = value;
            }
        }                        
        #endregion
        
        #region Property IsKey 
        private bool isKey;
        public bool IsKey
        {
            get
            {
                return this.isKey;
            }
            set
            {
                this.isKey = value;
            }
        }                        
        #endregion

        #region Property KeyIndex 
        private int keyIndex;
        public int KeyIndex
        {
            get
            {
                return this.keyIndex;
            }
            set
            {
                this.keyIndex = value;
            }
        }                        
        #endregion

        #region Property IdentityGenerator 
        private string identityGenerator;
        public string IdentityGenerator
        {
            get
            {
                return this.identityGenerator;
            }
            set
            {
                this.identityGenerator = value;
            }
        }                        
        #endregion

        #region Property LazyLoad 
        private bool lazyLoad;
        public bool LazyLoad
        {
            get
            {
                return this.lazyLoad;
            }
            set
            {
                this.lazyLoad = value;
            }
        }                        
        #endregion

        #region Property IsReadOnly 
        private bool isReadOnly;
        public bool IsReadOnly
        {
            get
            {
                return this.isReadOnly;
            }
            set
            {
                this.isReadOnly = value;
            }
        }                        
        #endregion

        #region Property IsSlave 
        private bool isSlave;
        public bool IsSlave
        {
            get
            {
                return this.isSlave;
            }
            set
            {
                this.isSlave = value;
            }
        }                        
        #endregion

        #region Property NullSubstitute 
        private string nullSubstitute;
        public string NullSubstitute
        {
            get
            {
                return this.nullSubstitute;
            }
            set
            {
                this.nullSubstitute = value;
            }
        }                        
        #endregion

        #region Property NoInverseManagement 
        private bool noInverseManagement;
        public bool NoInverseManagement
        {
            get
            {
                return this.noInverseManagement;
            }
            set
            {
                this.noInverseManagement = value;
            }
        }                        
        #endregion

        #region Property InheritInverseMappings 
        private bool inheritInverseMappings;
        public bool InheritInverseMappings
        {
            get
            {
                return this.inheritInverseMappings;
            }
            set
            {
                this.inheritInverseMappings = value;
            }
        }                        
        #endregion

        public bool DoesInheritInverseMappings()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property ReferenceType 
        private ReferenceType referenceType;
        public ReferenceType ReferenceType
        {
            get
            {
                return this.referenceType;
            }
            set
            {
                this.referenceType = value;
            }
        }                        
        #endregion

        #region Property ReferenceQualifier 
        private ReferenceQualifier referenceQualifier;
        public ReferenceQualifier ReferenceQualifier
        {
            get
            {
                return this.referenceQualifier;
            }
            set
            {
                this.referenceQualifier = value;
            }
        }                        
        #endregion

        #region Property CascadingCreate 
        private bool cascadingCreate;
        public bool CascadingCreate
        {
            get
            {
                return this.cascadingCreate;
            }
            set
            {
                this.cascadingCreate = value;
            }
        }                        
        #endregion

        #region Property CascadingDelete 
        private bool cascadingDelete;
        public bool CascadingDelete
        {
            get
            {
                return this.cascadingDelete;
            }
            set
            {
                this.cascadingDelete = value;
            }
        }                        
        #endregion

        public void UpdateName(string newName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property Accessibility 
        private AccessibilityType accessibility;
        public AccessibilityType Accessibility
        {
            get
            {
                return this.accessibility;
            }
            set
            {
                this.accessibility = value;
            }
        }                        
        #endregion

        #region Property FieldAccessibility 
        private AccessibilityType fieldAccessibility;
        public AccessibilityType FieldAccessibility
        {
            get
            {
                return this.fieldAccessibility;
            }
            set
            {
                this.fieldAccessibility = value;
            }
        }                        
        #endregion

        #region Property UpdateOptimisticConcurrencyBehavior 
        private OptimisticConcurrencyBehaviorType updateOptimisticConcurrencyBehavior;
        public OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior
        {
            get
            {
                return this.updateOptimisticConcurrencyBehavior;
            }
            set
            {
                this.updateOptimisticConcurrencyBehavior = value;
            }
        }                        
        #endregion

        #region Property DeleteOptimisticConcurrencyBehavior 
        private OptimisticConcurrencyBehaviorType deleteOptimisticConcurrencyBehavior;
        public OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior
        {
            get
            {
                return this.deleteOptimisticConcurrencyBehavior;
            }
            set
            {
                this.deleteOptimisticConcurrencyBehavior = value;
            }
        }                        
        #endregion

        #region Property OnCreateBehavior 
        private PropertySpecialBehaviorType onCreateBehavior;
        public PropertySpecialBehaviorType OnCreateBehavior
        {
            get
            {
                return this.onCreateBehavior;
            }
            set
            {
                this.onCreateBehavior = value;
            }
        }                        
        #endregion

        #region Property OnPersistBehavior 
        private PropertySpecialBehaviorType onPersistBehavior;
        public PropertySpecialBehaviorType OnPersistBehavior
        {
            get
            {
                return this.onPersistBehavior;
            }
            set
            {
                this.onPersistBehavior = value;
            }
        }                        
        #endregion

        #region Property OrderBy 
        private string orderBy;
        public string OrderBy
        {
            get
            {
                return this.orderBy;
            }
            set
            {
                this.orderBy = value;
            }
        }                        
        #endregion

        public IPropertyMap GetOrderByPropertyMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetDataOrItemType()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetAllColumnMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetAllIdColumnMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property PropertyModifier 
        private PropertyModifier propertyModifier;
        public PropertyModifier PropertyModifier
        {
            get
            {
                return this.propertyModifier;
            }
            set
            {
                this.propertyModifier = value;
            }
        }                        
        #endregion

        #region Property SourceProperty 
        private string sourceProperty;
        public string SourceProperty
        {
            get
            {
                return this.sourceProperty;
            }
            set
            {
                this.sourceProperty = value;
            }
        }                        
        #endregion

        public IPropertyMap GetSourcePropertyMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IPropertyMap GetSourcePropertyMapOrSelf()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property MergeBehavior 
        private MergeBehaviorType mergeBehavior;
        public MergeBehaviorType MergeBehavior
        {
            get
            {
                return this.mergeBehavior;
            }
            set
            {
                this.mergeBehavior = value;
            }
        }                        
        #endregion

        #region Property RefreshBehavior 
        private RefreshBehaviorType refreshBehavior;
        public RefreshBehaviorType RefreshBehavior
        {
            get
            {
                return this.refreshBehavior;
            }
            set
            {
                this.refreshBehavior = value;
            }
        }                        
        #endregion

        #region Property ValidationMode 
        private ValidationMode validationMode;
        public ValidationMode ValidationMode
        {
            get
            {
                return this.validationMode;
            }
            set
            {
                this.validationMode = value;
            }
        }                        
        #endregion

        #region Property TimeToLive 
        private long timeToLive;
        public long TimeToLive
        {
            get
            {
                return this.timeToLive;
            }
            set
            {
                this.timeToLive = value;
            }
        }                        
        #endregion

        #region Property TimeToLiveBehavior 
        private TimeToLiveBehavior timeToLiveBehavior;
        public TimeToLiveBehavior TimeToLiveBehavior
        {
            get
            {
                return this.timeToLiveBehavior;
            }
            set
            {
                this.timeToLiveBehavior = value;
            }
        }                        
        #endregion

        public long GetTimeToLive()
        {
            return this.TimeToLive;
        }

        public TimeToLiveBehavior GetTimeToLiveBehavior()
        {
            return this.TimeToLiveBehavior;
        }

        #region Property DocSource 
        private string docSource;
        public string DocSource
        {
            get
            {
                return this.docSource;
            }
            set
            {
                this.docSource = value;
            }
        }                        
        #endregion

        public ISourceMap GetDocSourceMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetDocSourceMap(ISourceMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Property DocAttribute 
        private string docAttribute;
        public string DocAttribute
        {
            get
            {
                return this.docAttribute;
            }
            set
            {
                this.docAttribute = value;
            }
        }                        
        #endregion

        public string GetDocAttribute()
        {
            return this.DocAttribute;
        }

        #region Property DocElement 
        private string docElement;
        public string DocElement
        {
            get
            {
                return this.docElement;
            }
            set
            {
                this.docElement = value;
            }
        }                        
        #endregion

        public string GetDocElement()
        {
            return this.DocElement;
        }

        #region Property DocPropertyMapMode 
        private DocPropertyMapMode docPropertyMapMode;
        public DocPropertyMapMode DocPropertyMapMode
        {
            get
            {
                return this.docPropertyMapMode;
            }
            set
            {
                this.docPropertyMapMode = value;
            }
        }                        
        #endregion

        #region Property ValidateMethod 
        private string validateMethod;
        public string ValidateMethod
        {
            get
            {
                return this.validateMethod;
            }
            set
            {
                this.validateMethod = value;
            }
        }                        
        #endregion



        #region Property Name 
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }                        
        #endregion


        string key;
        public string GetKey()
        {
            if (key == null)
                key = ClassMap.DomainMap.Name + "." + ClassMap.Name + "." + this.Name;

            return key;
        }

        public bool IsInParents(IMap possibleParent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IMap GetParent()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region ignore

        public void Accept(IMapVisitor visitor)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IMap Clone()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IMap DeepClone()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Copy(IMap mapObject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void DeepCopy(IMap mapObject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void DeepMerge(IMap mapObject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Compare(IMap compareTo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool DeepCompare(IMap compareTo)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        public ArrayList MetaData
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object GetMetaData(string key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetMetaData(string key, object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasMetaData(string key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RemoveMetaData(string key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CompareTo(object obj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Fixate()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void UnFixate()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsFixed()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsFixed(string memberName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object GetFixedValue(string memberName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetFixedValue(string memberName, object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

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

        #region IPropertyMap Members


        string IPropertyMap.CommitRegions
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
