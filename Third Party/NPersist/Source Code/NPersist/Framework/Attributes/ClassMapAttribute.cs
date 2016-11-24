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
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Framework.Attributes
{
	/// <summary>
	/// Summary description for ClassMapAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class ClassMapAttribute : Attribute
	{
		public ClassMapAttribute()
		{
		}

		#region Private Fields

		private string m_Source = "";
		private string m_Table = "";
		private string m_IdentitySeparator = "";
		private string m_KeySeparator = "";
		private string m_TypeColumn = "";
		private string m_TypeValue = "";
		private InheritanceType m_InheritanceType = InheritanceType.None;
		private MergeBehaviorType m_MergeBehavior = MergeBehaviorType.DefaultBehavior;
		private LoadBehavior m_ListCountLoadBehavior = LoadBehavior.Default;
		private RefreshBehaviorType m_RefreshBehavior = RefreshBehaviorType.DefaultBehavior;
		private bool m_IsReadOnly = false;
		private OptimisticConcurrencyBehaviorType m_UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_DeleteOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
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

		#endregion

		#region Object/Relational Mapping

		public virtual string Source
		{
			get { return m_Source; }
			set { m_Source = value; }
		}

		public virtual string Table
		{
			get { return m_Table; }
			set { m_Table = value; }
		}

		public virtual string IdentitySeparator
		{
			get { return m_IdentitySeparator; }
			set { m_IdentitySeparator = value; }
		}

		public virtual string KeySeparator
		{
			get { return m_KeySeparator; }
			set { m_KeySeparator = value; }
		}

		public virtual string TypeValue
		{
			get { return m_TypeValue; }
			set { m_TypeValue = value; }
		}

		public virtual string TypeColumn
		{
			get { return m_TypeColumn; }
			set { m_TypeColumn = value; }
		}

		public virtual MergeBehaviorType MergeBehavior
		{
			get { return m_MergeBehavior; }
			set { m_MergeBehavior = value; }
		}

		public virtual RefreshBehaviorType RefreshBehavior
		{
			get { return m_RefreshBehavior; }
			set { m_RefreshBehavior = value; }
		}

		public virtual LoadBehavior ListCountLoadBehavior
		{
			get { return m_ListCountLoadBehavior; }
			set { m_ListCountLoadBehavior = value; }
		}

		public virtual InheritanceType InheritanceType
		{
			get { return m_InheritanceType; }
			set { m_InheritanceType = value; }
		}

		public virtual bool IsReadOnly
		{
			get { return m_IsReadOnly; }
			set { m_IsReadOnly = value; }
		}

		public virtual OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior
		{
			get { return m_UpdateOptimisticConcurrencyBehavior; }
			set { m_UpdateOptimisticConcurrencyBehavior = value; }
		}

		public virtual OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior
		{
			get { return m_DeleteOptimisticConcurrencyBehavior; }
			set { m_DeleteOptimisticConcurrencyBehavior = value; }
		}
				
		public ValidationMode ValidationMode
		{
			get { return this.m_ValidationMode; }
			set { this.m_ValidationMode = value; }
		}

		public virtual string ValidateMethod
		{
			get { return m_ValidateMethod; }
			set { m_ValidateMethod = value; }
		}

		public virtual string LoadSpan
		{
			get { return m_LoadSpan; }
			set { m_LoadSpan = value; }
		}

		public long TimeToLive
		{
			get { return this.m_TimeToLive; }
			set { this.m_TimeToLive = value; }
		}
		
		public TimeToLiveBehavior TimeToLiveBehavior
		{
			get { return this.m_TimeToLiveBehavior; }
			set { this.m_TimeToLiveBehavior = value; }
		}

		public LoadBehavior LoadBehavior
		{
			get { return this.m_LoadBehavior; }
			set { this.m_LoadBehavior = value; }
		}

		public virtual string CommitRegions
		{
			get { return commitRegions; }
			set { commitRegions = value; }
		}

		#endregion

		#region Object/Object Mapping

		public virtual string SourceClass
		{
			get { return m_SourceClass; }
			set { m_SourceClass = value; }
		}

		#endregion

		#region Object/Document Mapping

		public virtual string DocSource
		{
			get { return m_DocSource; }
			set { m_DocSource = value; }
		}

		public virtual string DocElement
		{
			get { return m_DocElement; }
			set { m_DocElement = value; }
		}
		
		public virtual string DocRoot
		{
			get { return m_DocRoot; }
			set { m_DocRoot = value; }
		}
		
		public virtual DocClassMapMode DocClassMapMode
		{
			get { return m_DocClassMapMode; }
			set { m_DocClassMapMode = value; }
		}

		
		public virtual string DocParentProperty
		{
			get { return m_DocParentProperty; }
			set { m_DocParentProperty = value; }
		}

		#endregion

	}
}
