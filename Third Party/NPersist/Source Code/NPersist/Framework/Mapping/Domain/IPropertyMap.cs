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
	public interface IPropertyMap : IMap
	{
		[XmlIgnore()]
		IClassMap ClassMap { get; set; }

		void SetClassMap(IClassMap value);

		string FieldName { get; set; }

		string GetFieldName();

		bool IsGenerated { get; set; }

		string DataType { get; set; }

		string ItemType { get; set; }

		string DefaultValue { get; set; }

		bool IsCollection { get; set; }

        //This value is overridden by the nullability 
        //of the column if the property maps to a column
        //EXCEPT for a slave OneToOne property!!
		bool IsNullable { get; set; }

		bool GetIsNullable();

		int MaxLength { get; set; }

		int GetMaxLength();

		int MinLength { get; set; }

		string MaxValue { get; set; }

		string MinValue { get; set; }

		bool IsAssignedBySource { get; set; }

		bool GetIsAssignedBySource();

		IClassMap MustGetReferencedClassMap();

		IClassMap GetReferencedClassMap();

		string Source { get; set; }

		ISourceMap GetSourceMap();

		void SetSourceMap(ISourceMap value);

		string Table { get; set; }

		ITableMap MustGetTableMap();

		ITableMap GetTableMap();

		void SetTableMap(ITableMap value);

		string Column { get; set; }

		IColumnMap GetColumnMap();

		IColumnMap MustGetColumnMap();

		void SetColumnMap(IColumnMap value);

		string IdColumn { get; set; }

		IColumnMap GetIdColumnMap();

		void SetIdColumnMap(IColumnMap value);

		ArrayList AdditionalColumns { get; set; }

		ArrayList GetAdditionalColumnMaps();

		ArrayList AdditionalIdColumns { get; set; }

		ArrayList GetAdditionalIdColumnMaps();

		string Inverse { get; set; }

		IPropertyMap MustGetInversePropertyMap();

		IPropertyMap GetInversePropertyMap();

		void SetInversePropertyMap(IPropertyMap value);

		bool IsIdentity { get; set; }

		int IdentityIndex { get; set; }

		bool IsKey { get; set; }

		int KeyIndex { get; set; }

		string IdentityGenerator { get; set; }

		bool LazyLoad { get; set; }

		bool IsReadOnly { get; set; }

		bool IsSlave { get; set; }

		string NullSubstitute { get; set; }

		bool NoInverseManagement { get; set; }

		bool InheritInverseMappings { get; set; }

		bool DoesInheritInverseMappings();

		ReferenceType ReferenceType { get; set; }

		ReferenceQualifier ReferenceQualifier { get; set; }

		bool CascadingCreate { get; set; }

		bool CascadingDelete { get; set; }

		void UpdateName(string newName);

		AccessibilityType Accessibility { get; set; }

		AccessibilityType FieldAccessibility { get; set; }

		OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior { get; set; }

		OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior { get; set; }

		PropertySpecialBehaviorType OnCreateBehavior { get; set; }

		PropertySpecialBehaviorType OnPersistBehavior { get; set; }

		string OrderBy { get; set; }

		IPropertyMap GetOrderByPropertyMap();

		string GetDataOrItemType();

		ArrayList GetAllColumnMaps();

		ArrayList GetAllIdColumnMaps();

		PropertyModifier PropertyModifier { get; set; }
		
		string SourceProperty { get; set; }

		IPropertyMap GetSourcePropertyMap() ;

		IPropertyMap GetSourcePropertyMapOrSelf() ;

		
		MergeBehaviorType MergeBehavior { get; set; }

		RefreshBehaviorType RefreshBehavior { get; set; }

		ValidationMode ValidationMode { get; set; }

		LoadBehavior ListCountLoadBehavior { get; set; }

		long TimeToLive { get; set; }

		TimeToLiveBehavior TimeToLiveBehavior { get; set; }

		long GetTimeToLive();

		TimeToLiveBehavior GetTimeToLiveBehavior();

		string GenerateMemberName(string name);


		string CommitRegions { get; set; }

		IList GetCommitRegions();



		//O/D Mapping

		string DocSource { get; set; }

		ISourceMap GetDocSourceMap();

		void SetDocSourceMap(ISourceMap value);

		string DocAttribute { get; set; } 

		string GetDocAttribute();

		string DocElement { get; set; } 

		string GetDocElement();

		DocPropertyMapMode DocPropertyMapMode { get; set; }

		string ValidateMethod { get; set; }

	}
}