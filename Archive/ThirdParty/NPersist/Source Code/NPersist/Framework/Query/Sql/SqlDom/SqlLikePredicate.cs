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
	/// Summary description for SqlLikePredicate.
	/// </summary>
	public class SqlLikePredicate : SqlComparePredicate
	{
		public SqlLikePredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlExpression rightExpression, bool negative, string escapeCharacter) : base(sqlSearchCondition, leftExpression, SqlCompareOperatorType.Like, rightExpression)
		{
			this.negative = negative;
			this.escapeCharacter = escapeCharacter;
		}

		public SqlLikePredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlExpression rightExpression, bool negative) : this(sqlSearchCondition, leftExpression, rightExpression, negative, "")
		{
		}

		public SqlLikePredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlExpression rightExpression) : this(sqlSearchCondition, leftExpression, rightExpression, false, "")
		{
		}

		#region Property  Negative
		
		private bool negative;
		
		public bool Negative
		{
			get => this.negative;
		    set => this.negative = value;
		}
		
		#endregion
		
		#region Property  EscapeCharacter
		
		private string escapeCharacter = "";
		
		public string EscapeCharacter
		{
			get => this.escapeCharacter;
		    set => this.escapeCharacter = value;
		}
		
		#endregion

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}	
	}
}
