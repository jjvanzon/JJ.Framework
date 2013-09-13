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
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlTable.
	/// </summary>
	public class SqlTable : SqlNodeBase
	{

		private ITableMap tableMap;
		private string name;

		#region Constructors

		public SqlTable(SqlDatabase sqlDatabase, ITableMap tableMap)
		{
			this.Parent = sqlDatabase;
			this.tableMap = tableMap;
			sqlDatabase.SqlTables.Add(this);
		}

		public SqlTable(SqlDatabase sqlDatabase, string name)
		{
			this.Parent = sqlDatabase;
			this.name = name;
			sqlDatabase.SqlTables.Add(this);
		}

		#endregion
	
		public ITableMap TableMap
		{
			get { return this.tableMap; }
			set { this.tableMap = value; }
		}

		public SqlDatabase SqlDatabase { get { return this.Parent as SqlDatabase; } }

		#region Property  SqlColumns
		
		private IList sqlColumns = new ArrayList() ;
		
		public IList SqlColumns
		{
			get { return this.sqlColumns; }
			set { this.sqlColumns = value; }
		}
		
		#endregion

		#region Get Column

		public SqlColumn GetSqlColumn(IColumnMap columnMap)
		{
			SqlColumn sqlColumn = FindSqlColumn(columnMap.Name) ;
			if (sqlColumn == null)
				sqlColumn = new SqlColumn(this, columnMap) ;
			return sqlColumn;
		}

		public SqlColumn GetSqlColumn(string name)
		{
			SqlColumn sqlColumn = FindSqlColumn(name) ;
			if (sqlColumn == null)
				sqlColumn = new SqlColumn(this, name) ;
			return sqlColumn;
		}

		public SqlColumn FindSqlColumn(string name)
		{
			foreach(SqlColumn sqlColumn in this.sqlColumns)
			{
				if (sqlColumn.Name == name) 
					return sqlColumn;
			}
			return null ;
		}

		#endregion

		public string Name
		{
			get 
			{ 
				if ( this.tableMap != null ) 
					return this.tableMap.Name;
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
