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
	/// Summary description for SqlTableAlias.
	/// </summary>
	public class SqlTableAlias : SqlNodeBase
	{
		private SqlTable sqlTable;

		#region Constructors

		public SqlTableAlias(SqlDatabase sqlDatabase, SqlTable sqlTable) : this(sqlDatabase, sqlTable, "") {}

		public SqlTableAlias(SqlDatabase sqlDatabase, SqlTable sqlTable, string alias)
		{
			this.Parent = sqlDatabase;
			this.sqlTable = sqlTable;
			this.alias = alias;
			sqlDatabase.SqlTableAliases.Add(this);
		}

		#endregion
		
		public SqlTable SqlTable
		{
			get => this.sqlTable;
		    set => this.sqlTable = value;
		}

		public SqlDatabase SqlDatabase => this.Parent as SqlDatabase;

	    #region Property  Alias
		
		private string alias;
		
		public string Alias
		{
			get 
			{
				if (this.alias == "")
					return sqlTable.Name;
				else
					return this.alias;
			}
			set => this.alias = value;
		}
		
		#endregion

		#region Property  SqlColumnAliases
		
		private IList sqlColumnAliases = new ArrayList() ;
		
		public IList SqlColumnAliases
		{
			get => this.sqlColumnAliases;
		    set => this.sqlColumnAliases = value;
		}
		
		#endregion


		#region Get ColumnAlias

		public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap) => GetSqlColumnAlias(columnMap, "");

	    public SqlColumnAlias GetSqlColumnAlias(string name) => GetSqlColumnAlias(name, "");

	    public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap, string alias)
		{
            if (columnMap == null)
                throw new ArgumentNullException("columnMap");

			SqlColumnAlias sqlColumnAlias = FindSqlColumnAlias(columnMap.Name, alias) ;
			if (sqlColumnAlias == null)
			{
				SqlColumn sqlColumn = this.SqlTable.GetSqlColumn(columnMap);
				sqlColumnAlias = new SqlColumnAlias(this, sqlColumn, alias) ;
			}
			return sqlColumnAlias;
		}

		public SqlColumnAlias GetSqlColumnAlias(string name, string alias)
		{
			SqlColumnAlias sqlColumnAlias = FindSqlColumnAlias(name, alias) ;
			if (sqlColumnAlias == null)
			{
				SqlColumn sqlColumn = this.SqlTable.GetSqlColumn(name);
				sqlColumnAlias = new SqlColumnAlias(this, sqlColumn, alias) ;
			}
			return sqlColumnAlias;
		}

		public SqlColumnAlias FindSqlColumnAlias(string name, string alias)
		{
			if (alias == "")
				alias = name;
			foreach(SqlColumnAlias sqlColumnAlias in this.sqlColumnAliases)
			{
				if (sqlColumnAlias.Alias == alias) 
					return sqlColumnAlias;
			}
			if (alias == name)
			{
				foreach(SqlColumnAlias sqlColumnAlias in this.sqlColumnAliases)
				{
					if (sqlColumnAlias.SqlColumn.Name == name) 
						return sqlColumnAlias;
				}				
			}
			return null ;
		}

		#endregion

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
