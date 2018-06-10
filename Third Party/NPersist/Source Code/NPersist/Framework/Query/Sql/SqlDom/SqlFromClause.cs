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
	/// Summary description for SqlFromClause.
	/// </summary>
	public class SqlFromClause : SqlClause
	{
		public SqlFromClause(SqlStatement sqlStatement) : base(sqlStatement)
		{
		}

		#region Property  SqlTableSources
		
		private IList sqlTableSources = new ArrayList() ;
		
		public IList SqlTableSources
		{
			get => this.sqlTableSources;
		    set => this.sqlTableSources = value;
		}
		
		#endregion

		public SqlAliasTableSource AddSqlAliasTableSource(SqlTable sqlTable)
		{
			SqlTableAlias sqlTableAlias = this.SqlStatement.GetSqlTableAlias(sqlTable);
			return AddSqlAliasTableSource(sqlTableAlias );
		}

		public SqlAliasTableSource AddSqlAliasTableSource(string name)
		{
			SqlTableAlias sqlTableAlias = this.SqlStatement.GetSqlTableAlias(name);
			return AddSqlAliasTableSource(sqlTableAlias) ;
		}

		public SqlAliasTableSource AddSqlAliasTableSource(ITableMap tableMap)
		{
			SqlTableAlias sqlTableAlias = this.SqlStatement.GetSqlTableAlias(tableMap);
			return AddSqlAliasTableSource(sqlTableAlias) ;
		}

		public SqlAliasTableSource AddSqlAliasTableSource(SqlTableAlias sqlTableAlias) => new SqlAliasTableSource(this, sqlTableAlias);

	    public SqlJoinTableSource AddSqlJoinTableSource(SqlTableAlias leftTable, SqlTableAlias rightTable, SqlJoinType joinType) => new SqlJoinTableSource(this, leftTable, rightTable, joinType);

	    public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
