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
	/// Summary description for DomainMapAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	public class DomainMapAttribute : Attribute
	{
		public DomainMapAttribute()
		{
		}


		#region Private Member Variables

		private string m_Source = "";
		private MergeBehaviorType m_MergeBehavior = MergeBehaviorType.DefaultBehavior;
		private RefreshBehaviorType m_RefreshBehavior = RefreshBehaviorType.DefaultBehavior;
		private LoadBehavior m_ListCountLoadBehavior = LoadBehavior.Default;
		private bool m_IsReadOnly = false;
		private string m_RootNamespace = "";
		private string m_FieldPrefix = "m_";
		private FieldNameStrategyType m_FieldNameStrategy = FieldNameStrategyType.None;
		private OptimisticConcurrencyBehaviorType m_UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_DeleteOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private LoadBehavior m_LoadBehavior = LoadBehavior.Default;
		private ValidationMode m_ValidationMode = ValidationMode.Default ;
		private long m_TimeToLive = -1;
		private TimeToLiveBehavior m_TimeToLiveBehavior = TimeToLiveBehavior.Default ;
		private DeadlockStrategy m_DeadlockStrategy = DeadlockStrategy.Default ;

		//O/D Mapping
		private string m_DocSource = "";

		#endregion


		#region Object/Relational Mapping

		public virtual string Source
		{
			get => m_Source;
		    set => m_Source = value;
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

		public virtual bool IsReadOnly
		{
			get => m_IsReadOnly;
		    set => m_IsReadOnly = value;
		}

		public virtual string RootNamespace
		{
			get => m_RootNamespace;
		    set => m_RootNamespace = value;
		}

		public virtual string FieldPrefix
		{
			get => m_FieldPrefix;
		    set => m_FieldPrefix = value;
		}

		public virtual FieldNameStrategyType FieldNameStrategy
		{
			get => m_FieldNameStrategy;
		    set => m_FieldNameStrategy = value;
		}

		public virtual OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior
		{
			get => m_UpdateOptimisticConcurrencyBehavior;
		    set => m_UpdateOptimisticConcurrencyBehavior = value;
		}

		public virtual OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior		{
			get => m_DeleteOptimisticConcurrencyBehavior;
		    set => m_DeleteOptimisticConcurrencyBehavior = value;
		}

		public virtual LoadBehavior LoadBehavior
		{
			get => m_LoadBehavior;
		    set => m_LoadBehavior = value;
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
		
		public DeadlockStrategy DeadlockStrategy
		{
			get => this.m_DeadlockStrategy;
		    set => this.m_DeadlockStrategy = value;
		}

		#endregion

		#region Object/Object Mapping

		#endregion

		#region Object/Document Mapping

		public virtual string DocSource
		{
			get => m_DocSource;
		    set => m_DocSource = value;
		}

		#endregion

	}
}
