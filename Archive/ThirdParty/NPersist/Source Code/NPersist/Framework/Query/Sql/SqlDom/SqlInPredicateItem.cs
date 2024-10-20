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
	/// Summary description for SqlInPredicateItem.
	/// </summary>
	public class SqlInPredicateItem : SqlNodeBase
	{
		public SqlInPredicateItem(SqlInPredicate sqlInPredicate, SqlExpression sqlExpression)
		{
			this.Parent = sqlInPredicate;
			this.sqlExpression  = sqlExpression;
		}

		public SqlInPredicateItem(SqlInPredicate sqlInPredicate, SqlSelectStatement sqlSelectStatement)
		{
			this.Parent = sqlInPredicate;
			this.sqlSelectStatement = sqlSelectStatement;
		}

		public SqlInPredicate SqlInPredicate => this.Parent as SqlInPredicate;

	    #region Property  SqlExpression
		
		private SqlExpression sqlExpression;
		
		public SqlExpression SqlExpression
		{
			get => this.sqlExpression;
		    set => this.sqlExpression = value;
		}
		
		#endregion

		#region Property  SqlSelectStatement
		
		private SqlSelectStatement sqlSelectStatement;
		
		public SqlSelectStatement SqlSelectStatement
		{
			get => this.sqlSelectStatement;
		    set => this.sqlSelectStatement = value;
		}
		
		#endregion
	
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}	
	}
}
