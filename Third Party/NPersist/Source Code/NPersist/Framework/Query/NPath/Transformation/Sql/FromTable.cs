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
using Puzzle.NPersist.Framework.Sql.Dom;

namespace Puzzle.NPersist.Framework.NPath.Sql
{
	/// <summary>
	/// Summary description for FromTable.
	/// </summary>
	public class FromTable
	{
		public FromTable()
		{
		}

		public FromTable(SqlTableAlias alias, SqlTableAlias linksToAlias)
		{
			this.alias = alias;
			this.linksToAlias = linksToAlias;
		}

		#region Property  Alias
		
		private SqlTableAlias alias;
		
		public SqlTableAlias Alias
		{
			get => this.alias;
		    set => this.alias = value;
		}
		
		#endregion

		#region Property  LinksToAlias
		
		private SqlTableAlias linksToAlias = null;
		
		public SqlTableAlias LinksToAlias
		{
			get => this.linksToAlias;
		    set => this.linksToAlias = value;
		}
		
		#endregion

		#region Property  Columns
		
		private IList columns = new ArrayList() ;
		
		public IList Columns
		{
			get => this.columns;
		    set => this.columns = value;
		}
		
		#endregion

		#region Property  LinksToColumns
		
		private IList linksToColumns = new ArrayList() ;
		
		public IList LinksToColumns
		{
			get => this.linksToColumns;
		    set => this.linksToColumns = value;
		}
		
		#endregion
	}
}
