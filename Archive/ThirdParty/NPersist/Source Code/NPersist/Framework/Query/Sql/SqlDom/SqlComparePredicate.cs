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
	/// Summary description for SqlComparePredicate.
	/// </summary>
	public class SqlComparePredicate : SqlPredicate
	{

		public SqlComparePredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlCompareOperator sqlCompareOperator, SqlExpression rightExpression) : base(sqlSearchCondition)
		{
			this.leftExpression = leftExpression;
			this.sqlCompareOperator = sqlCompareOperator;
			this.rightExpression = rightExpression;
		}

		public SqlComparePredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlCompareOperatorType sqlCompareOperatorType, SqlExpression rightExpression) : this(sqlSearchCondition, leftExpression, new SqlCompareOperator(sqlCompareOperatorType), rightExpression) 
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

		#region Property  SqlCompareOperator
		
		private SqlCompareOperator sqlCompareOperator;
		
		public SqlCompareOperator SqlCompareOperator
		{
			get => this.sqlCompareOperator;
		    set => this.sqlCompareOperator = value;
		}
		
		#endregion

		#region Property  RightExpression
		
		private SqlExpression rightExpression;
		
		public SqlExpression RightExpression
		{
			get => this.rightExpression;
		    set => this.rightExpression = value;
		}
		
		#endregion
		
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			this.leftExpression.Accept(visitor);
			this.sqlCompareOperator.Accept(visitor);
			this.rightExpression.Accept(visitor);
			visitor.Visited(this);	
		}
	}
}
