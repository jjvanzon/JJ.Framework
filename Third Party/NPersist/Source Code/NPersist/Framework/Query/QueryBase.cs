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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Framework.Querying
{
	public abstract class QueryBase : ContextChild, IQuery
	{
		private string m_Query;
		private Type m_PrimaryType;
		private IList parameters = new ArrayList() ;

		protected QueryBase() : base()
		{
		}

		protected QueryBase(string query) : base() => m_Query = query;

	    protected QueryBase(string query, IContext ctx) : base(ctx) => m_Query = query;

	    protected QueryBase(string query, Type primaryType, IContext ctx) : this(query, primaryType, null, RefreshBehaviorType.DefaultBehavior, ctx)
		{
		}

		
		protected QueryBase(string query, Type primaryType, IList parameters, IContext ctx) : this(query, primaryType, parameters, RefreshBehaviorType.DefaultBehavior, ctx)
		{
		}

		protected QueryBase(string query, Type primaryType, IList parameters, RefreshBehaviorType refreshBehavior, IContext ctx) : base(ctx)
		{
			m_Query = query;
			m_PrimaryType = primaryType;
			this.refreshBehavior = refreshBehavior;
			if (parameters != null)
				this.parameters = parameters;
		}


		protected QueryBase(string query, Type primaryType) : this(query, primaryType, null, RefreshBehaviorType.DefaultBehavior)
		{
		}

		
		protected QueryBase(string query, Type primaryType, IList parameters) : this(query, primaryType, parameters, RefreshBehaviorType.DefaultBehavior)
		{
		}

		protected QueryBase(string query, Type primaryType, IList parameters, RefreshBehaviorType refreshBehavior) : base()
		{
			m_Query = query;
			m_PrimaryType = primaryType;
			this.refreshBehavior = refreshBehavior;
			if (parameters != null)
				this.parameters = parameters;
		}


		public object Query
		{
			get => m_Query;
		    set => m_Query = Convert.ToString(value);
		}


		public Type PrimaryType
		{
			get => m_PrimaryType;
		    set => m_PrimaryType = value;
		}

		public IList Parameters
		{
			get => this.parameters;
		    set => this.parameters = value;
		}


		#region Property  RefreshBehavior
		
		private RefreshBehaviorType refreshBehavior = RefreshBehaviorType.DefaultBehavior;
		
		public RefreshBehaviorType RefreshBehavior
		{
			get => this.refreshBehavior;
		    set => this.refreshBehavior = value;
		}
		
		#endregion

		public virtual string ToSqlScalar() => "";

	    public virtual string ToSqlScalar(Type primaryType) => "";

	    public virtual string ToSqlScalar(Type primaryType, IContext ctx) => "";

	    public virtual string ToSqlScalar(Type primaryType, IContext ctx, ref IList outParameters, IList inParameters) => "";

	    public virtual string ToSql() => "";

	    public virtual string ToSql(Type primaryType, IContext ctx, ref IList idColumns, ref IList typeColumns, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters) => "";
	}
}