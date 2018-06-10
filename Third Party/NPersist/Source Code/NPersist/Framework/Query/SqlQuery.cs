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
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Querying
{
	public class SqlQuery : QueryBase
	{
		public SqlQuery() : base()
		{
		}

		public SqlQuery(string query) : base(query)
		{
		}

		public SqlQuery(string query, IContext ctx) : base(query, ctx)
		{
		}

		public SqlQuery(string query, Type primaryType, IContext ctx) : base(query, primaryType, ctx)
		{
		}
		
		public SqlQuery(string query, Type primaryType, IList parameters, IContext ctx) : base(query, primaryType, parameters, ctx)
		{
		}
		
		public SqlQuery(string query, Type primaryType, IList parameters, RefreshBehaviorType refreshBehavior, IContext ctx) : base(query, primaryType, parameters, refreshBehavior, ctx)
		{
		}

		public SqlQuery(string query, IList parameters, IContext ctx) : base(query, null, parameters, ctx)
		{
		}

		public SqlQuery(string query, IList parameters, RefreshBehaviorType refreshBehavior, IContext ctx) : base(query, null, parameters, refreshBehavior, ctx)
		{
		}

		public SqlQuery(string query, Type primaryType) : base(query, primaryType)
		{
		}
		
		public SqlQuery(string query, Type primaryType, IList parameters) : base(query, primaryType, parameters)
		{
		}
		
		public SqlQuery(string query, Type primaryType, IList parameters, RefreshBehaviorType refreshBehavior) : base(query, primaryType, parameters, refreshBehavior)
		{
		}

		public override string ToSqlScalar() => Convert.ToString(Query);

	    public override string ToSqlScalar(Type primaryType) => Convert.ToString(Query);

	    public override string ToSqlScalar(Type primaryType, IContext ctx) => Convert.ToString(Query);

	    public override string ToSqlScalar(Type primaryType, IContext ctx, ref IList outParameters, IList inParameters)
		{
			outParameters = new ArrayList() ;
			return Convert.ToString(Query);
		}

		public override string ToSql() => Convert.ToString(Query);

	    public override string ToSql(Type primaryType, IContext ctx, ref IList idColumns, ref IList typeColumns, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters)
		{
			outParameters = new ArrayList(); 
			IClassMap classMap;
			IColumnMap columnMap;
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
			foreach (IPropertyMap propertyMap in classMap.GetPrimaryPropertyMaps())
			{
				if (!(propertyMap.IsCollection))
				{
					if (!(propertyMap.IsIdentity))
					{
						if (propertyMap.ReferenceType == ReferenceType.None)
						{
							columnMap = propertyMap.GetColumnMap();
							if (columnMap != null)
							{
								propertyColumnMap[propertyMap.Name] = columnMap.Name;
							}
						}
					}
				}
			}
			return Convert.ToString(Query);
		}
	}
}