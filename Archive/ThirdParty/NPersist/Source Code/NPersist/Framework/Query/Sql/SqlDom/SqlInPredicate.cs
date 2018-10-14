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
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlInPredicate.
	/// </summary>
	public class SqlInPredicate : SqlPredicate
	{
		public SqlInPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, bool negative) : base(sqlSearchCondition)
		{
			this.leftExpression = leftExpression;
			this.negative = negative;
		}

		public SqlInPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression) : this(sqlSearchCondition, leftExpression, false) 
		{			
		}

		#region Property  LeftExpression
		
		private SqlExpression leftExpression;
		
		public SqlExpression LeftExpression
		{
			get => this.leftExpression;
		    set => this.leftExpression = value;
		}
		
		#endregion
		
		#region Property  Negative
		
		private bool negative;
		
		public bool Negative
		{
			get => this.negative;
		    set => this.negative = value;
		}
		
		#endregion

		#region Property  SqlInPredicateItems
		
		private IList sqlInPredicateItems = new ArrayList() ;
		
		public IList SqlInPredicateItems
		{
			get => this.sqlInPredicateItems;
		    set => this.sqlInPredicateItems = value;
		}
		
		#endregion

		public SqlInPredicateItem AddSqlInPredicateItem(SqlExpression sqlExpression)
		{
			SqlInPredicateItem newSqlInPredicateItem = new SqlInPredicateItem(this, sqlExpression);
			this.sqlInPredicateItems.Add(newSqlInPredicateItem);
			return newSqlInPredicateItem;
		}

		public SqlInPredicateItem AddSqlInPredicateItem(SqlSelectStatement sqlSelectStatement)
		{
			SqlInPredicateItem newSqlInPredicateItem = new SqlInPredicateItem(this, sqlSelectStatement);
			this.sqlInPredicateItems.Add(newSqlInPredicateItem);
			return newSqlInPredicateItem;
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}	
	}
}
