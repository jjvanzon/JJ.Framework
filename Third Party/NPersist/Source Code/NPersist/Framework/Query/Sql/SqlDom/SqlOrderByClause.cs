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
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlOrderByClause.
	/// </summary>
	public class SqlOrderByClause : SqlClause
	{
		public SqlOrderByClause(SqlStatement sqlStatement) : base(sqlStatement)
		{
		}

		#region Property  SqlOrderByItems
		
		private IList sqlOrderByItems = new ArrayList() ;
		
		public IList SqlOrderByItems
		{
			get { return this.sqlOrderByItems; }
			set { this.sqlOrderByItems = value; }
		}
		
		#endregion

		public SqlOrderByItem AddSqlOrderByItem(SqlExpression sqlExpression, bool descending)
		{
			SqlOrderByItem sqlOrderByItem = new SqlOrderByItem(this, sqlExpression, descending);
			this.sqlOrderByItems.Add(sqlOrderByItem);
			return sqlOrderByItem;
		}

		public SqlOrderByItem AddSqlOrderByItem(SqlExpression sqlExpression)
		{
			return AddSqlOrderByItem(sqlExpression, false);
		}

		public SqlOrderByItem AddSqlOrderByItem(SqlColumnAlias sqlColumnAlias, bool descending)
		{
			SqlColumnAliasReference sqlColumnAliasReference = new SqlColumnAliasReference(sqlColumnAlias);
			return AddSqlOrderByItem(sqlColumnAliasReference, descending);
		}

		public SqlOrderByItem AddSqlOrderByItem(SqlColumnAlias sqlColumnAlias)
		{
			return AddSqlOrderByItem(sqlColumnAlias, false);
		}

		public SqlOrderByItem AddSqlOrderByItem(IColumnMap columnMap, bool descending)
		{
			SqlColumnAlias sqlColumnAlias = this.SqlStatement.GetSqlColumnAlias(columnMap);
			SqlColumnAliasReference sqlColumnAliasReference = new SqlColumnAliasReference(sqlColumnAlias);
			return AddSqlOrderByItem(sqlColumnAliasReference, descending);
		}

		public SqlOrderByItem AddSqlOrderByItem(IColumnMap columnMap)
		{
			return AddSqlOrderByItem(columnMap, false);
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			foreach (SqlOrderByItem sqlOrderByItem in this.sqlOrderByItems)
				sqlOrderByItem.Accept(visitor);
			visitor.Visited(this);	
		}
	}
}
