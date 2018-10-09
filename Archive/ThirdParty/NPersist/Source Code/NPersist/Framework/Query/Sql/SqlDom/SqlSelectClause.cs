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
	/// Summary description for SqlSelectClause.
	/// </summary>
	public class SqlSelectClause : SqlClause
	{
		public SqlSelectClause(SqlStatement sqlStatement) : base(sqlStatement)
		{
		}

		#region Property  SqlSelectListItems
		
		private IList sqlSelectListItems = new ArrayList() ;
		
		public IList SqlSelectListItems
		{
			get => this.sqlSelectListItems;
		    set => this.sqlSelectListItems = value;
		}

		#endregion

		#region SqlSelectListItems Methods

		public SqlAllColumnsInTableSelectListItem AddSqlAllColumnsInTableSelectListItem(string name)
		{
			SqlTableAlias sqlTableAlias = this.SqlStatement.GetSqlTableAlias(name);
			return AddSqlAllColumnsInTableSelectListItem(sqlTableAlias) ;
		}

		public SqlAllColumnsInTableSelectListItem AddSqlAllColumnsInTableSelectListItem(ITableMap tableMap)
		{
			SqlTableAlias sqlTableAlias = this.SqlStatement.GetSqlTableAlias(tableMap);
			return AddSqlAllColumnsInTableSelectListItem(sqlTableAlias) ;
		}

		public SqlAllColumnsInTableSelectListItem AddSqlAllColumnsInTableSelectListItem(SqlTable sqlTable)
		{
			SqlTableAlias sqlTableAlias = this.SqlStatement.GetSqlTableAlias(sqlTable.Name);
			return AddSqlAllColumnsInTableSelectListItem(sqlTableAlias) ;
		}

		public SqlAllColumnsInTableSelectListItem AddSqlAllColumnsInTableSelectListItem(SqlTableAlias sqlTableAlias)
		{
			SqlTableAliasReference sqlTableAliasReference = new SqlTableAliasReference(sqlTableAlias);
			return AddSqlAllColumnsInTableSelectListItem(sqlTableAliasReference) ;
		}

		public SqlAllColumnsInTableSelectListItem AddSqlAllColumnsInTableSelectListItem(SqlTableAliasReference sqlTableAliasReference) => new SqlAllColumnsInTableSelectListItem(this, sqlTableAliasReference);

	    public SqlAllColumnsSelectListItem AddSqlAllColumnsSelectListItem() => new SqlAllColumnsSelectListItem(this);

	    public SqlAliasSelectListItem AddSqlAliasSelectListItem(string name, string tableName)
		{
			SqlColumnAlias sqlColumnAlias = this.SqlStatement.GetSqlColumnAlias(name, tableName);
			return AddSqlAliasSelectListItem(sqlColumnAlias) ;
		}

		public SqlAliasSelectListItem AddSqlAliasSelectListItem(SqlColumn sqlColumn)
		{
			SqlColumnAlias sqlColumnAlias = this.SqlStatement.GetSqlColumnAlias(sqlColumn.Name, sqlColumn.SqlTable.Name);
			return AddSqlAliasSelectListItem(sqlColumnAlias) ;
		}

		public SqlAliasSelectListItem AddSqlAliasSelectListItem(SqlColumnAlias sqlColumnAlias) => new SqlAliasSelectListItem(this, sqlColumnAlias);

	    public SqlAliasSelectListItem AddSqlAliasSelectListItem(SqlExpressionAlias sqlExpressionAlias) => new SqlAliasSelectListItem( this, sqlExpressionAlias);

	    public SqlAliasSelectListItem AddSqlAliasSelectListItem(SqlExpression sqlExpression)
		{
			SqlExpressionAlias sqlExpressionAlias = new SqlExpressionAlias(this.SqlStatement.SqlDatabase, sqlExpression, "");
			return new SqlAliasSelectListItem( this, sqlExpressionAlias) ;
		}

		public SqlAliasSelectListItem AddSqlAliasSelectListItem(SqlExpression sqlExpression, string alias)
		{
			if (alias == null)
				alias = "";
			SqlExpressionAlias sqlExpressionAlias = new SqlExpressionAlias(this.SqlStatement.SqlDatabase, sqlExpression, alias);
			return new SqlAliasSelectListItem( this, sqlExpressionAlias) ;
		}

		public SqlExpressionSelectListItem AddSqlExpressionSelectListItem() => new SqlExpressionSelectListItem(this);

	    #endregion

		#region Property  Distinct
		
		private bool distinct;
		
		public bool Distinct
		{
			get => this.distinct;
		    set => this.distinct = value;
		}
		
		#endregion

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);
			foreach(SqlSelectListItem sqlSelectListItem in this.sqlSelectListItems)
				sqlSelectListItem.Accept(visitor);
			visitor.Visited(this);
		}
	}
}
