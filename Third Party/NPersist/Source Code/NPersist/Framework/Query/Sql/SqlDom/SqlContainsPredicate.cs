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
	/// Summary description for SqlContainsPredicate.
	/// </summary>
	public class SqlContainsPredicate : SqlPredicate
	{
		public SqlContainsPredicate(SqlSearchCondition sqlSearchCondition, SqlExpression leftExpression, SqlExpression rightExpression) : base(sqlSearchCondition)
		{
			this.leftExpression = leftExpression;
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
			visitor.Visited(this);	
		}
	}
}
