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
	/// Summary description for SqlAliasSelectListItem.
	/// </summary>
	public class SqlAliasSelectListItem : SqlSelectListItem
	{
		public SqlAliasSelectListItem(SqlSelectClause sqlSelectClause, SqlColumnAlias sqlColumnAlias) : base(sqlSelectClause) => this.sqlColumnAlias = sqlColumnAlias;

	    public SqlAliasSelectListItem(SqlSelectClause sqlSelectClause, SqlExpressionAlias sqlExpressionAlias) : base(sqlSelectClause) => this.sqlExpressionAlias = sqlExpressionAlias;

	    #region Property  SqlColumnAlias 
		
		private SqlColumnAlias sqlColumnAlias ;
		
		public SqlColumnAlias SqlColumnAlias 
		{
			get => this.sqlColumnAlias;
		    set => this.sqlColumnAlias  = value;
		}
		
		#endregion

		#region Property  SqlExpressionAlias
		
		private SqlExpressionAlias sqlExpressionAlias;
		
		public SqlExpressionAlias SqlExpressionAlias
		{
			get => this.sqlExpressionAlias;
		    set => this.sqlExpressionAlias = value;
		}
		
		#endregion
		
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);
			if (this.sqlColumnAlias != null)
				this.sqlColumnAlias.Accept(visitor) ;
			else if (this.sqlExpressionAlias != null)
				this.sqlExpressionAlias.Accept(visitor) ;
			visitor.Visited(this);	
		}

	
	}
}
