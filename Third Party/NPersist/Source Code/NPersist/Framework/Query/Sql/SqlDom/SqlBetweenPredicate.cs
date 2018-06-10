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
	/// Summary description for SqlBetweenPredicate.
	/// </summary>
	public class SqlBetweenPredicate : SqlPredicate
	{
		public SqlBetweenPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlExpression middleExpression, SqlExpression rightExpression, bool negative) : base(sqlSearchCondition)
		{
			this.leftExpression = leftExpression;
			this.middleExpression = middleExpression;
			this.rightExpression = rightExpression;
			this.negative = negative;
		}

		public SqlBetweenPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlExpression middleExpression, SqlExpression rightExpression) : this(sqlSearchCondition, leftExpression, middleExpression, rightExpression, false)
		{
			this.leftExpression = leftExpression;
			this.middleExpression = middleExpression;
			this.rightExpression = rightExpression;
		}
		
		#region Property  LeftExpression
		
		private SqlExpression leftExpression;
		
		public SqlExpression LeftExpression
		{
			get => this.leftExpression;
		    set => this.leftExpression = value;
		}
		
		#endregion

		#region Property  MiddleExpression
		
		private SqlExpression middleExpression;
		
		public SqlExpression MiddleExpression
		{
			get => this.middleExpression;
		    set => this.middleExpression = value;
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

		#region Property  Negative
		
		private bool negative;
		
		public bool Negative
		{
			get => this.negative;
		    set => this.negative = value;
		}
		
		#endregion
		
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
