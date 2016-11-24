using System;
using System.Collections;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping.Immutable
{
	public class ImmutableDomainMap : IDomainMap
	{
        public void Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Save(string path)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Save(string path, Puzzle.NPersist.Framework.Mapping.Serialization.IMapSerializer mapSerializer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Setup()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList ClassMaps
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

        public IList GetPersistentClassMaps()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList GetClassMaps(ClassType classType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IClassMap GetClassMap(string findName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IClassMap GetClassMap(Type type)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IClassMap MustGetClassMap(string findName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IClassMap MustGetClassMap(Type type)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList SourceMaps
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

        public ISourceMap GetSourceMap(string findName)
        {
            throw new Exception("The method or operation is not implemented.");
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

        public ICodeMap GetCodeMap(CodeLanguage codeLanguage)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ICodeMap EnsuredGetCodeMap(CodeLanguage codeLanguage)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList SourceListMapPaths
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

        public ArrayList ClassListMapPaths
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

        public void SetSourceMap(ISourceMap SourceMap)
        {
            throw new Exception("The method or operation is not implemented.");
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

        public string GetLoadedFromPath()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetLoadedFromPath(string value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetLastSavedToPath()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetLastSavedToPath(string value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetNamespaces()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetNamespaceClassMaps(string name)
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

        public bool Dirty
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

        public string RootNamespace
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

        public string FieldPrefix
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

        public FieldNameStrategyType FieldNameStrategy
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

        public bool VerifyCSharpReservedWords
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

        public bool VerifyVbReservedWords
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

        public bool VerifyDelphiReservedWords
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

        public ArrayList GetClassMapsForTable(ITableMap tableMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetPropertyMapsForTable(ITableMap tableMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetPropertyMapsForColumn(IColumnMap columnMap)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ArrayList GetPropertyMapsForColumn(IColumnMap columnMap, bool noIdColumns)
        {
            throw new Exception("The method or operation is not implemented.");
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

        public MapSerializer MapSerializer
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

        public IList GetClassMapsWithUniDirectionalReferenceTo(IClassMap classMap, bool nullableOnly)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CodeLanguage CodeLanguage
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

        #region IDomainMap Members


        public DeadlockStrategy DeadlockStrategy
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
