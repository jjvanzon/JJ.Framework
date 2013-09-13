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
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Querying
{
	public class NPathQuery : QueryBase
	{
		public NPathQuery() : base()
		{
		}

		public NPathQuery(string query) : base(query)
		{
		}

		public NPathQuery(string query, IContext ctx) : base(query, ctx)
		{
		}

		public NPathQuery(string query, Type primaryType, IContext ctx) : base(query, primaryType, ctx)
		{
		}

		public NPathQuery(string query, Type primaryType, IList parameters, IContext ctx) : base(query, primaryType, parameters, ctx)
		{
		}

		
		public NPathQuery(string query, Type primaryType, IList parameters, RefreshBehaviorType refreshBehavior, IContext ctx) : base(query, primaryType, parameters, refreshBehavior, ctx)
		{
		}

		
		public NPathQuery(string query, Type primaryType) : base(query, primaryType)
		{
		}

		public NPathQuery(string query, Type primaryType, IList parameters) : base(query, primaryType, parameters)
		{
		}

		
		public NPathQuery(string query, Type primaryType, IList parameters, RefreshBehaviorType refreshBehavior) : base(query, primaryType, parameters, refreshBehavior)
		{
		}

		public override string ToSqlScalar()
		{
			if (PrimaryType == null)
			{
				throw new NPathException("A primary type must first be supplied before the NPath statement can be converted to sql!"); // do not localize
			}
			return ToSqlScalar(PrimaryType);
		}

		public override string ToSqlScalar(Type primaryType)
		{
			if (this.Context == null)
			{
				throw new NPathException("A context manager must first be supplied before the NPath statement can be converted to sql!"); // do not localize
			}
			return ToSqlScalar(primaryType, this.Context);
		}

		public override string ToSqlScalar(Type primaryType, IContext ctx)
		{
			IList outParameters = new ArrayList() ;
			IList inParameters = new ArrayList() ;
			return ToSqlScalar(primaryType, ctx, ref outParameters, inParameters);
		}

		public override string ToSqlScalar(Type primaryType, IContext ctx, ref IList outParameters, IList inParameters)
		{
			string sql = ctx.NPathEngine.ToScalarSql((string) Query, primaryType, ref outParameters, inParameters);
			this.Parameters = outParameters;
			return sql;
		}

		public override string ToSql()
		{
			IList outParameters = new ArrayList();
			IList inParameters = new ArrayList();
			if (this.Context == null)
			{
				throw new NPathException("A context manager must first be supplied before the NPath statement can be converted to sql!"); // do not localize
			}
			if (PrimaryType == null)
			{
				throw new NPathException("A primary type must first be supplied before the NPath statement can be converted to sql!"); // do not localize
			}
			IList idColumns = new ArrayList();
			IList typeColumns = new ArrayList();
			Hashtable propertyColumnMaps = new Hashtable();
			return ToSql(PrimaryType, this.Context, ref idColumns, ref typeColumns, ref propertyColumnMaps, ref outParameters, inParameters);

		}

		public override string ToSql(Type primaryType, IContext ctx, ref IList idColumns, ref IList typeColumns, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters)
		{
			IClassMap classMap;
			IColumnMap columnMap;
			//INPathSelectClause NPathSelectClause;
			classMap = ctx.DomainMap.MustGetClassMap(primaryType);
			columnMap = classMap.GetTypeColumnMap();
			if (columnMap != null)
			{
				typeColumns.Add(columnMap.Name);
			}
			foreach (IPropertyMap propertyMap in classMap.GetIdentityPropertyMaps())
			{
				columnMap = propertyMap.GetColumnMap();
				if (columnMap != null)
				{
					idColumns.Add(columnMap.Name);
				}
			}
			string sql = ctx.NPathEngine.ToSql( (string) Query, primaryType, ref propertyColumnMap, ref outParameters, inParameters);
			this.Parameters = outParameters;
			return sql;
		}
	}
}