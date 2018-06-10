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
	/// Summary description for SqlWhereClause.
	/// </summary>
	public class SqlWhereClause : SqlClause, ISqlConditionChainPart 
	{
		public SqlWhereClause(SqlStatement sqlStatement) : base(sqlStatement)
		{
		}

		#region Property  SqlSearchCondition
		
		private SqlSearchCondition sqlSearchCondition;
		
		public SqlSearchCondition SqlSearchCondition
		{
			get => this.sqlSearchCondition;
		    set => this.sqlSearchCondition = value;
		}
		
		#endregion

		#region Property  SqlOldOuterJoin
		
		private SqlOldOuterJoin sqlOldOuterJoin;
		
		public SqlOldOuterJoin SqlOldOuterJoin
		{
			get => this.sqlOldOuterJoin;
		    set => this.sqlOldOuterJoin = value;
		}
		
		#endregion

		#region Property  NextSqlSearchCondition 
		
		public SqlSearchCondition NextSqlSearchCondition 
		{
			get => this.sqlSearchCondition;
		    set => this.sqlSearchCondition  = value;
		}
		
		#endregion

		public SqlSearchCondition GetSqlSearchCondition() => GetSqlSearchCondition(false);

	    public SqlSearchCondition GetSqlSearchCondition(bool orNext)
		{
			if (this.sqlSearchCondition == null)
			{
				this.sqlSearchCondition = new SqlSearchCondition(this) ;
				this.sqlSearchCondition.OrNext = orNext;
			}
			return this.sqlSearchCondition;				
		}

		public SqlSearchCondition GetNextSqlSearchCondition()
		{
			if (this.sqlSearchCondition == null)
			{
				this.sqlSearchCondition = new SqlSearchCondition(this) ;

                //fix parens
                //SqlSearchCondition search = this.sqlSearchCondition.GetNextSqlSearchCondition();
                //search = search.GetSubSqlSearchCondition();
                //return search;							
	
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

		public SqlSearchCondition GetCurrentSqlSearchCondition()
		{
			if (this.sqlSearchCondition == null)
			{
				this.sqlSearchCondition = new SqlSearchCondition(this) ;

                //fix parens
                //SqlSearchCondition search = this.sqlSearchCondition.GetNextSqlSearchCondition();
                //search = search.GetSubSqlSearchCondition();
                //return search;							
	
				return this.sqlSearchCondition;								
			}
			SqlSearchCondition sqlSearchCondition = this.sqlSearchCondition;
			while (sqlSearchCondition.NextSqlSearchCondition != null)
			{
				sqlSearchCondition = sqlSearchCondition.NextSqlSearchCondition;
			}
			return sqlSearchCondition;
		}

		public SqlOldOuterJoin GetSqlOldOuterJoin()
		{
			if (this.sqlOldOuterJoin == null)
				this.sqlOldOuterJoin = new SqlOldOuterJoin(this) ;
			return this.sqlOldOuterJoin;			
		}

		public bool HasChild()
		{
			if (HasSearchCondition() || HasOldOuterJoin())
				return true;
			return false;
		}

		public bool HasOldOuterJoin()
		{
			if (this.sqlOldOuterJoin != null)
				return true;
			return false;
		}

		public bool HasSearchCondition()
		{
			if (this.sqlSearchCondition != null)
				return true;
			return false;
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			if (this.sqlSearchCondition != null)
				this.sqlSearchCondition.Accept(visitor);
			if (this.sqlOldOuterJoin != null)
				this.sqlOldOuterJoin.Accept(visitor);
			visitor.Visited(this);	
		}
	}
}
