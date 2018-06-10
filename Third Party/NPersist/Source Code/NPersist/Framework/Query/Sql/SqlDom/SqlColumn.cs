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
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlColumn.
	/// </summary>
	public class SqlColumn : SqlNodeBase
	{
		private IColumnMap columnMap;
		private string name;

		#region Constructors

		public SqlColumn(SqlTable sqlTable, IColumnMap columnMap)
		{
			this.Parent = sqlTable;
			this.columnMap = columnMap;
			sqlTable.SqlColumns.Add(this);
		}

		public SqlColumn(SqlTable sqlTable, string name)
		{
			this.Parent = sqlTable;
			this.name = name;
			sqlTable.SqlColumns.Add(this);
		}

		#endregion

		public IColumnMap ColumnMap
		{
			get => this.columnMap;
		    set => this.columnMap = value;
		}

		public SqlTable SqlTable => this.Parent as SqlTable;

	    public string Name
		{
			get 
			{ 
				if ( this.columnMap != null ) 
					return this.columnMap.Name;
				return this.name; 
			}
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
