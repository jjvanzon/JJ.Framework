using System;
using System.Collections;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping.Immutable
{
	public class ImmutableClassMap : IClassMap
	{

        public IDomainMap DomainMap
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

        public void SetDomainMap(IDomainMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList PropertyMaps
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

        public ArrayList CodeMaps
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

        public ArrayList EnumValueMaps
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

        public ICodeMap GetCodeMap(CodeLanguage codeLanguage)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ICodeMap EnsuredGetCodeMap(CodeLanguage codeLanguage)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IPropertyMap GetPropertyMap(string findName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IPropertyMap MustGetPropertyMap(string findName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IEnumValueMap GetEnumValueMap(string name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList GetEnumValueMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList GetSortedEnumValueMaps(ref bool failedSorting)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string InheritsClass
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

        public ClassType ClassType
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

        public IClassMap GetInheritedClassMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Source
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

        public ISourceMap GetSourceMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetSourceMap(ISourceMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Table
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

        public ITableMap MustGetTableMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ITableMap GetTableMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetTableMap(ITableMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetPrimaryPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetIdentityPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetKeyPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetSortedIdentityPropertyMaps(ref bool failedSorting, bool getInherited)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasAssignedBySource()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasGuid()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasIdAssignedBySource()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasIdGuid()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IPropertyMap GetAssignedBySourceIdentityPropertyMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasSingleIdAutoIncreaser()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IPropertyMap GetAutoIncreasingIdentityPropertyMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string IdentitySeparator
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

        public string GetIdentitySeparator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string KeySeparator
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

        public string GetKeySeparator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string TypeColumn
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

        public IColumnMap GetTypeColumnMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetTypeColumnMap(IColumnMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string TypeValue
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

        public MergeBehaviorType MergeBehavior
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

        public RefreshBehaviorType RefreshBehavior
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

        public bool IsAbstract
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

        public ArrayList GetAllPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetInheritedPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetNonInheritedPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetNonInheritedIdentityPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetInheritedIdentityPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void UpdateName(string newName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetFullName()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetName()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetNamespace()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetFullNamespace()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public InheritanceType InheritanceType
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

        public IPropertyMap MustGetPropertyMapForColumnMap(IColumnMap columnMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IPropertyMap GetPropertyMapForColumnMap(IColumnMap columnMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetDirectSubClassMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetSubClassMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsSubClass(IClassMap classMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsSubClassOrThisClass(IClassMap classMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasSubClasses()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IClassMap GetSubClassWithTypeValue(string value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IClassMap GetBaseClassMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsInHierarchy()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsLegalAsSuperClass(IClassMap classMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsReadOnly
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

        public IList GetCommitRegions()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string CommitRegions
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

        public string InheritsTransientClass
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

        public ArrayList ImplementsInterfaces
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

        public ArrayList ImportsNamespaces
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

        public OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior
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

        public OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior
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

        public bool IsInheritedProperty(IPropertyMap propertyMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsShadowingProperty(IPropertyMap propertyMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetInheritsTransientClass()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetImplementsInterfaces()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetImportsNamespaces()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string AssemblyName
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

        public string GetAssemblyName()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ValidationMode ValidationMode
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

        public string LoadSpan
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

        public long TimeToLive
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

        public TimeToLiveBehavior TimeToLiveBehavior
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

        public long GetTimeToLive()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public TimeToLiveBehavior GetTimeToLiveBehavior()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public LoadBehavior LoadBehavior
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

        public LoadBehavior GetLoadBehavior()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string SourceClass
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

        public IClassMap GetSourceClassMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IClassMap GetSourceClassMapOrSelf()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string DocSource
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

        public ISourceMap GetDocSourceMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetDocSourceMap(ISourceMap value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string DocElement
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

        public string GetDocElement()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DocClassMapMode DocClassMapMode
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

        public string DocParentProperty
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

        public IPropertyMap GetDocParentPropertyMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string DocRoot
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

        public string GetDocRoot()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasIdentityGenerators()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool HasUniDirectionalReferenceTo(IClassMap classMap, bool nullableOnly)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList GetUniDirectionalReferencesTo(IClassMap classMap, bool nullableOnly)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string ValidateMethod
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

        public void Accept(IMapVisitor visitor)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Name
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

        public string GetKey()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsInParents(IMap possibleParent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IMap GetParent()
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

        #region IClassMap Members


        public IList GetGeneratedPropertyMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
