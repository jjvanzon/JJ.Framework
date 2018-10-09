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
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Attributes
{
	/// <summary>
	/// Summary description for PropertyMapAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class PropertyMapAttribute : Attribute
	{
		public PropertyMapAttribute()
		{
		}

		#region Private Member Variables

		//O/R Mapping
		private string m_ValidateMethod = "";
		private string m_FieldName = "";
		private string m_DataType = "";
		private string m_ItemType = "";
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
		private string m_Columns = "";
		private string m_IdColumns = "";
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
		private OptimisticConcurrencyBehaviorType m_UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_DeleteOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private PropertySpecialBehaviorType m_OnCreateBehavior = PropertySpecialBehaviorType.None;
		private PropertySpecialBehaviorType m_OnPersistBehavior = PropertySpecialBehaviorType.None;
		private string m_OrderBy = "";
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

		#endregion


		#region Object/Relational Mapping
		
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

		public virtual string DataType
		{
			get => m_DataType;
		    set => m_DataType = value;
		}

		public virtual string ItemType
		{
			get => m_ItemType;
		    set => m_ItemType = value;
		}

		public virtual bool IsCollection
		{
			get => m_IsCollection;
		    set => m_IsCollection = value;
		}

		public virtual string Source
		{
			get => m_Source;
		    set => m_Source = value;
		}

		public virtual string Table
		{
			get => m_Table;
		    set => m_Table = value;
		}

		public virtual string Columns
		{
			get => m_Columns;
		    set => m_Columns = value;
		}

		public virtual string IdColumns
		{
			get => m_IdColumns;
		    set => m_IdColumns = value;
		}

		public virtual string Inverse
		{
			get => m_Inverse;
		    set => m_Inverse = value;
		}

		public virtual bool IsIdentity
		{
			get => m_IsIdentity;
		    set => m_IsIdentity = value;
		}

		public int IdentityIndex
		{
			get => m_IdentityIndex;
		    set => m_IdentityIndex = value;
		}

		public virtual bool IsKey
		{
			get => m_IsKey;
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
			get => m_IsReadOnly;
		    set => m_IsReadOnly = value;
		}

		public virtual bool IsSlave
		{
			get => m_IsSlave;
		    set => m_IsSlave = value;
		}

		public virtual string NullSubstitute
		{
			get => m_NullSubstitute;
		    set => m_NullSubstitute = value;
		}

		public virtual bool NoInverseManagement
		{
			get => m_NoInverseManagement;
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

		public virtual ReferenceType ReferenceType
		{
			get => m_ReferenceType;
		    set => m_ReferenceType = value;
		}

		public ReferenceQualifier ReferenceQualifier
		{
			get => this.m_ReferenceQualifier;
		    set => this.m_ReferenceQualifier = value;
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

		public virtual string CommitRegions
		{
			get => commitRegions;
		    set => commitRegions = value;
		}

		#endregion

		#region Object/Object Mapping

		public virtual string SourceProperty
		{
			get => m_SourceProperty;
		    set => m_SourceProperty = value;
		}

		#endregion

		#region Object/Document Mapping
		
		public virtual string DocSource
		{
			get => m_DocSource;
		    set => m_DocSource = value;
		}

		public virtual string DocAttribute
		{
			get => m_DocAttribute;
		    set => m_DocAttribute = value;
		}

		public virtual string DocElement
		{
			get => m_DocElement;
		    set => m_DocElement = value;
		}
		
		public virtual DocPropertyMapMode DocPropertyMapMode
		{
			get => m_DocPropertyMapMode;
		    set => m_DocPropertyMapMode = value;
		}

		#endregion

		public virtual string GetColumn()
		{
			foreach (string column in GetColumns())
				return column.Trim();
			return "";
		}

		public virtual IList GetAdditionalColumns()
		{
			IList columns = new ArrayList();
			bool skip = true;
			foreach (string column in GetColumns())
			{
				if (!skip)
					if (column.Length > 0)
						columns.Add(column.Trim());
				skip = false;				
			}
			return columns;
		}

		public virtual string[] GetColumns() => m_Columns.Split(",".ToCharArray());

	    public virtual string GetIdColumn()
		{
			foreach (string column in GetIdColumns())
				return column.Trim();
			return "";
		}

		public virtual IList GetAdditionalIdColumns()
		{
			IList columns = new ArrayList();
			bool skip = true;
			foreach (string column in GetIdColumns())
			{
				if (!skip)
					if (column.Length > 0)
					columns.Add(column.Trim());
				skip = false;				
			}
			return columns;
		}

		public virtual string[] GetIdColumns() => m_IdColumns.Split(",".ToCharArray());
	}
}
