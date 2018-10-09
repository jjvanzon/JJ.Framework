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
	/// Summary description for SqlAliasTableSource.
	/// </summary>
	public class SqlAliasTableSource : SqlTableSource 
	{
		public SqlAliasTableSource(SqlFromClause sqlFromClause, SqlTableAlias sqlTableAlias) : base(sqlFromClause) => this.sqlTableAlias = sqlTableAlias;

	    #region Property  SqlTableAlias 
		
		private SqlTableAlias sqlTableAlias ;
		
		public SqlTableAlias SqlTableAlias 
		{
			get => this.sqlTableAlias;
		    set => this.sqlTableAlias  = value;
		}
		
		#endregion
		
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			this.sqlTableAlias.Accept(visitor) ;
			visitor.Visited(this);	
		}
	}
}
