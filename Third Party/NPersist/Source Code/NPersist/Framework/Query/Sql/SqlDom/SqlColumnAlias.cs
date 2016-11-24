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
	/// Summary description for SqlColumnAlias.
	/// </summary>
	public class SqlColumnAlias : SqlNodeBase
	{

		private SqlColumn sqlColumn;

		#region Constructors

		public SqlColumnAlias(SqlTableAlias sqlTableAlias, SqlColumn sqlColumn) : this(sqlTableAlias, sqlColumn, "") {}

		public SqlColumnAlias(SqlTableAlias sqlTableAlias, SqlColumn sqlColumn, string alias)
		{
			this.Parent = sqlTableAlias;
			this.sqlColumn = sqlColumn;
			this.alias = alias;
			sqlTableAlias.SqlColumnAliases.Add(this);
		}

		#endregion

		public SqlColumn SqlColumn
		{
			get { return this.sqlColumn; }
			set { this.sqlColumn = value; }
		}

		public SqlTableAlias SqlTableAlias { get { return this.Parent as SqlTableAlias; } }

		#region Property  Alias
		
		private string alias;
		
		public string Alias
		{
			get 
			{
				if (this.alias == "")
					return sqlColumn.Name;
				else
					return this.alias;
			}
		}
		
		#endregion

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}

		public override string ToString()
		{
			return this.sqlColumn.Name + " as " + this.alias;
		}

	}
}
