// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public interface IClassMap : IMap
	{
		[XmlIgnore()]
		IDomainMap DomainMap { get; set; }

		void SetDomainMap(IDomainMap value);

		[XmlArrayItem(typeof (IPropertyMap))]
		ArrayList PropertyMaps { get; set; }

		[XmlArrayItem(typeof (ICodeMap))]
		ArrayList CodeMaps { get; set; }

		[XmlArrayItem(typeof (IEnumValueMap))]
		ArrayList EnumValueMaps { get; set; }

		ICodeMap GetCodeMap(CodeLanguage codeLanguage);

		ICodeMap EnsuredGetCodeMap(CodeLanguage codeLanguage);

		IPropertyMap GetPropertyMap(string findName);

		IPropertyMap MustGetPropertyMap(string findName);

		IEnumValueMap GetEnumValueMap(string name);

		IList GetEnumValueMaps();

		IList GetSortedEnumValueMaps(ref bool failedSorting);

		string InheritsClass { get; set; }
		
		ClassType ClassType { get; set; }

		IClassMap GetInheritedClassMap();

		string Source { get; set; }

		ISourceMap GetSourceMap();

		void SetSourceMap(ISourceMap value);

		string Table { get; set; }

		ITableMap MustGetTableMap();

		ITableMap GetTableMap();

		void SetTableMap(ITableMap value);

		ArrayList GetPrimaryPropertyMaps();

		ArrayList GetIdentityPropertyMaps();

		ArrayList GetKeyPropertyMaps();

		/// <summary>
		/// This method is primarily exposed for the Verifier visitors
		/// </summary>
		/// <param name="failedSorting">Returns true if the identity propertymaps could not be sorted</param>
		/// <param name="getInherited">Indicates if inherited identityproperties should be included in the result</param>
		/// <returns>A list of the identity properties for the class, sorted by identity index</returns>
		ArrayList GetSortedIdentityPropertyMaps(ref bool failedSorting, bool getInherited);

		bool HasAssignedBySource();

		bool HasGuid();

		bool HasIdAssignedBySource();

		bool HasIdGuid();

		IPropertyMap GetAssignedBySourceIdentityPropertyMap();

		bool HasSingleIdAutoIncreaser();

		IPropertyMap GetAutoIncreasingIdentityPropertyMap();

		string IdentitySeparator { get; set; }

		string GetIdentitySeparator();
		
		string KeySeparator { get; set; }

		string GetKeySeparator();

		string TypeColumn { get; set; }

		IColumnMap GetTypeColumnMap();

		void SetTypeColumnMap(IColumnMap value);

		string TypeValue { get; set; }

		MergeBehaviorType MergeBehavior { get; set; }

		RefreshBehaviorType RefreshBehavior { get; set; }

		LoadBehavior ListCountLoadBehavior { get; set; }

		bool IsAbstract { get; set; }

		ArrayList GetAllPropertyMaps();

		ArrayList GetInheritedPropertyMaps();

		ArrayList GetNonInheritedPropertyMaps();

		ArrayList GetNonInheritedIdentityPropertyMaps();

		ArrayList GetInheritedIdentityPropertyMaps();

		IList GetGeneratedPropertyMaps();

		void UpdateName(string newName);

		string GetFullName();

		string GetName();

		string GetNamespace();

		string GetFullNamespace();

		InheritanceType InheritanceType { get; set; }

		IPropertyMap MustGetPropertyMapForColumnMap(IColumnMap columnMap);

		IPropertyMap GetPropertyMapForColumnMap(IColumnMap columnMap);

		ArrayList GetDirectSubClassMaps();

		ArrayList GetSubClassMaps();

		bool IsSubClass(IClassMap classMap);

		bool IsSubClassOrThisClass(IClassMap classMap);

		bool HasSubClasses();

		IClassMap GetSubClassWithTypeValue(string value);

		IClassMap GetBaseClassMap();

		bool IsInHierarchy();

		bool IsLegalAsSuperClass(IClassMap classMap);

		bool IsReadOnly { get; set; }

		string InheritsTransientClass { get; set; }

		ArrayList ImplementsInterfaces { get; set; }

		ArrayList ImportsNamespaces { get; set; }

		OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior { get; set; }

		OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior { get; set; }

		bool IsInheritedProperty(IPropertyMap propertyMap);

		bool IsShadowingProperty(IPropertyMap propertyMap);

		string GetInheritsTransientClass();

		ArrayList GetImplementsInterfaces();

		ArrayList GetImportsNamespaces();

		string AssemblyName { get; set; }

		string GetAssemblyName();

		ValidationMode ValidationMode { get; set; }

		string LoadSpan { get; set; }

		long TimeToLive { get; set; }

		TimeToLiveBehavior TimeToLiveBehavior { get; set; }

		long GetTimeToLive();

		TimeToLiveBehavior GetTimeToLiveBehavior();

		LoadBehavior LoadBehavior { get; set; }

		LoadBehavior GetLoadBehavior();

		string CommitRegions { get; set; }

		IList GetCommitRegions();

		//O/O Mapping

		string SourceClass { get; set; }

		IClassMap GetSourceClassMap() ;

		IClassMap GetSourceClassMapOrSelf() ;

		//O/D Mapping

		string DocSource { get; set; }

		ISourceMap GetDocSourceMap();

		void SetDocSourceMap(ISourceMap value);

		string DocElement { get; set; }

		string GetDocElement();

		DocClassMapMode DocClassMapMode { get; set; }

		string DocParentProperty { get; set; }

		IPropertyMap GetDocParentPropertyMap(); 
		
		string DocRoot { get; set; }

		string GetDocRoot();
		
		bool HasIdentityGenerators() ;

		//Determines if this classMap has one or more uni-directional (lacking inverse property) 
		//reference properties to the specified class or any of its superclasses
		bool HasUniDirectionalReferenceTo(IClassMap classMap, bool nullableOnly);
		
		IList GetUniDirectionalReferencesTo(IClassMap classMap, bool nullableOnly);

		string ValidateMethod { get; set; }

	}
}