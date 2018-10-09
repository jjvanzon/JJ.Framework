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
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;
using Puzzle.NPersist.Framework.Mapping.Serialization;

namespace Puzzle.NPersist.Framework.Mapping
{
	public interface IDomainMap : IMap
	{
		void Save();

		void Save(string path);

		void Save(string path, IMapSerializer mapSerializer);

		void Setup();

		[XmlArrayItem(typeof (IClassMap))]
		ArrayList ClassMaps { get; set; }

		IList GetPersistentClassMaps();

		IList GetClassMaps(ClassType classType);

		IClassMap GetClassMap(string findName);

		IClassMap GetClassMap(Type type);
		
		IClassMap MustGetClassMap(string findName);

		IClassMap MustGetClassMap(Type type);

		[XmlArrayItem(typeof (ISourceMap))]
		ArrayList SourceMaps { get; set; }

		ISourceMap GetSourceMap(string findName);

		
		[XmlArrayItem(typeof (ICodeMap))]
		ArrayList CodeMaps { get; set; }

		ICodeMap GetCodeMap(CodeLanguage codeLanguage);

		ICodeMap EnsuredGetCodeMap(CodeLanguage codeLanguage);


		ArrayList SourceListMapPaths { get; set; }

		ArrayList ClassListMapPaths { get; set; }

		string Source { get; set; }

		ISourceMap GetSourceMap();

		void SetSourceMap(ISourceMap SourceMap);

		MergeBehaviorType MergeBehavior { get; set; }

		RefreshBehaviorType RefreshBehavior { get; set; }

		LoadBehavior ListCountLoadBehavior { get; set; }

		string GetLoadedFromPath();

		void SetLoadedFromPath(string value);

		string GetLastSavedToPath();

		void SetLastSavedToPath(string value);

		ArrayList GetNamespaces();

		ArrayList GetNamespaceClassMaps(string name);

		bool IsReadOnly { get; set; }

		bool Dirty { get; set; }

		string RootNamespace { get; set; }

		string FieldPrefix { get; set; }

		FieldNameStrategyType FieldNameStrategy { get; set; }

		string InheritsTransientClass { get; set; }

		ArrayList ImplementsInterfaces { get; set; }

		ArrayList ImportsNamespaces { get; set; }

		bool VerifyCSharpReservedWords { get; set; }

		bool VerifyVbReservedWords { get; set; }

		bool VerifyDelphiReservedWords { get; set; }

		ArrayList GetClassMapsForTable(ITableMap tableMap);

		ArrayList GetPropertyMapsForTable(ITableMap tableMap);

		ArrayList GetPropertyMapsForColumn(IColumnMap columnMap);

		ArrayList GetPropertyMapsForColumn(IColumnMap columnMap, bool noIdColumns);

		OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior { get; set; }

		OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior { get; set; }

		MapSerializer MapSerializer { get; set; }

		string AssemblyName { get; set; }

		string GetAssemblyName();

		LoadBehavior LoadBehavior { get; set; }

		string DocSource { get; set; }

		ISourceMap GetDocSourceMap();

		void SetDocSourceMap(ISourceMap value);

		//Returns all classMaps with one or more uni-directional (lacking inverse property) 
		//reference properties to the specified class or any of its superclasses
		IList GetClassMapsWithUniDirectionalReferenceTo(IClassMap classMap, bool nullableOnly);

		CodeLanguage CodeLanguage { get; set; }

		ValidationMode ValidationMode { get; set; }
		
		long TimeToLive { get; set; }

		TimeToLiveBehavior TimeToLiveBehavior { get; set; }

        DeadlockStrategy DeadlockStrategy { get; set; }

	}
}