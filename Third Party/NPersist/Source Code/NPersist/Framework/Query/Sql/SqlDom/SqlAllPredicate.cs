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
	/// Summary description for SqlAllPredicate.
	/// </summary>
	public class SqlAllPredicate : SqlPredicate
	{
		public SqlAllPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlCompareOperator sqlCompareOperator, SqlAllPredicateType sqlAllPredicateType) : base(sqlSearchCondition)
		{
			this.leftExpression = leftExpression;
			this.sqlCompareOperator = sqlCompareOperator;
			this.sqlSelectStatement = new SqlSelectStatement(this);
			this.sqlAllPredicateType = sqlAllPredicateType;
		}

		public SqlAllPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlCompareOperatorType sqlCompareOperatorType, SqlAllPredicateType sqlAllPredicateType) : this(sqlSearchCondition, leftExpression, new SqlCompareOperator(sqlCompareOperatorType), sqlAllPredicateType) 
		{			
		}

		public SqlAllPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlCompareOperatorType sqlCompareOperatorType) : this(sqlSearchCondition, leftExpression, new SqlCompareOperator(sqlCompareOperatorType), SqlAllPredicateType.All) 
		{			
		}

		public SqlAllPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression,SqlCompareOperator sqlCompareOperator) : this(sqlSearchCondition, leftExpression, sqlCompareOperator, SqlAllPredicateType.All) 
		{			
		}

		#region Property  LeftExpression
		
		private SqlExpression leftExpression;
		
		public SqlExpression LeftExpression
		{
			get { return this.leftExpression; }
			set { this.leftExpression = value; }
		}
		
		#endregion

		#region Property  SqlCompareOperator
		
		private SqlCompareOperator sqlCompareOperator;
		
		public SqlCompareOperator SqlCompareOperator
		{
			get { return this.sqlCompareOperator; }
			set { this.sqlCompareOperator = value; }
		}
		
		#endregion

		#region Property  SqlAllPredicateType
		
		private SqlAllPredicateType sqlAllPredicateType = SqlAllPredicateType.All;
		
		public SqlAllPredicateType SqlAllPredicateType
		{
			get { return this.sqlAllPredicateType; }
			set { this.sqlAllPredicateType = value; }
		}
		
		#endregion

		#region Property  SqlSelectStatement
		
		private SqlSelectStatement sqlSelectStatement;
		
		public SqlSelectStatement SqlSelectStatement
		{
			get { return this.sqlSelectStatement; }
			set { this.sqlSelectStatement = value; }
		}
		
		#endregion
		
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
