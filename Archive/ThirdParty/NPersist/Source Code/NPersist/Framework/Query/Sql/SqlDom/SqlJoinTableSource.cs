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
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlJoinTableSource.
	/// </summary>
	public class SqlJoinTableSource : SqlTableSource 
	{
		public SqlJoinTableSource(SqlFromClause sqlFromClause, SqlTableAlias leftTable, SqlTableAlias rightTable, SqlJoinType joinType) : base(sqlFromClause)
		{
			this.Parent = sqlFromClause;
			this.leftSqlTableAlias = leftTable;
			this.rightTableAlias = rightTable;
			this.sqlJoinType = joinType;
		}

		public SqlFromClause SqlFromClause => this.Parent as SqlFromClause;

	    #region Property  SqlJoinType
		
		private SqlJoinType sqlJoinType = SqlJoinType.Inner ;
		
		public SqlJoinType SqlJoinType
		{
			get => this.sqlJoinType;
		    set => this.sqlJoinType = value;
		}
		
		#endregion

		#region Property  LeftSqlTableAlias
		
		private SqlTableAlias leftSqlTableAlias;
		
		public SqlTableAlias LeftSqlTableAlias
		{
			get => this.leftSqlTableAlias;
		    set => this.leftSqlTableAlias = value;
		}
		
		#endregion

		#region Property  RightTableAlias 
		
		private SqlTableAlias rightTableAlias ;
		
		public SqlTableAlias RightTableAlias 
		{
			get => this.rightTableAlias;
		    set => this.rightTableAlias  = value;
		}
		
		#endregion

		#region Property  SqlSearchCondition
		
		private SqlSearchCondition sqlSearchCondition;
		
		public SqlSearchCondition SqlSearchCondition
		{
			get => this.sqlSearchCondition;
		    set => this.sqlSearchCondition = value;
		}
		
		#endregion

		public SqlSearchCondition GetSqlSearchCondition()
		{
			if (this.sqlSearchCondition == null)
			{
				this.sqlSearchCondition = new SqlSearchCondition(this) ;
			}
			return this.sqlSearchCondition;				
		}

		public SqlSearchCondition GetNextSqlSearchCondition()
		{
			if (this.sqlSearchCondition == null)
			{
				this.sqlSearchCondition = new SqlSearchCondition(this) ;
				return this.sqlSearchCondition;								
			}
			SqlSearchCondition sqlSearchCondition = this.sqlSearchCondition;
			while (sqlSearchCondition.NextSqlSearchCondition != null)
			{
				sqlSearchCondition = sqlSearchCondition.NextSqlSearchCondition;
			}
			sqlSearchCondition = sqlSearchCondition.GetNextSqlSearchCondition();
			return sqlSearchCondition;
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
