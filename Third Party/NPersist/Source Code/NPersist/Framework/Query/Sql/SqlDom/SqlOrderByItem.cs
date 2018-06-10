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
	/// Summary description for SqlOrderByItem.
	/// </summary>
	public class SqlOrderByItem : SqlNodeBase 
	{
		public SqlOrderByItem(SqlOrderByClause sqlOrderByClause, SqlExpression sqlExpression) : this(sqlOrderByClause, sqlExpression, false)
		{
		}

		public SqlOrderByItem(SqlOrderByClause sqlOrderByClause, SqlExpression sqlExpression, bool descending)
		{
			this.Parent = sqlOrderByClause;
			this.sqlExpression = sqlExpression;
			this.descending = descending;
		}

		public SqlOrderByClause SqlOrderByClause => this.Parent as SqlOrderByClause;

	    #region Property  Descending
		
		private bool descending;
		
		public bool Descending
		{
			get => this.descending;
		    set => this.descending = value;
		}
		
		#endregion

		#region Property  SqlExpression 
		
		private SqlExpression sqlExpression ;
		
		public SqlExpression SqlExpression 
		{
			get => this.sqlExpression;
		    set => this.sqlExpression  = value;
		}
		
		#endregion
	
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
