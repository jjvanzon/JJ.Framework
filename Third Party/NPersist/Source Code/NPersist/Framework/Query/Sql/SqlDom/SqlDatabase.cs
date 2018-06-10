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
	/// Summary description for SqlDatabase.
	/// </summary>
	public class SqlDatabase : SqlNodeBase
	{
		private ISourceMap sourceMap;
		private string name;

		#region Constructors

		public SqlDatabase(SqlStatement sqlStatement, ISourceMap sourceMap)
		{
			this.Parent = sqlStatement;
			this.sourceMap = sourceMap;
		}

		public SqlDatabase(SqlStatement sqlStatement,string name)
		{
			this.Parent = sqlStatement;
			this.name = name;
		}

		#endregion

		public ISourceMap SourceMap
		{
			get => this.sourceMap;
		    set => this.sourceMap = value;
		}

		public SqlStatement SqlStatement => this.Parent as SqlStatement;

	    public string Name
		{
			get { 
				if ( this.sourceMap != null ) 
					return this.sourceMap.Name;
				return this.name; 
			}
		}

		#region Property  SqlTables
		
		private IList sqlTables = new ArrayList() ;
		
		public IList SqlTables
		{
			get => this.sqlTables;
		    set => this.sqlTables = value;
		}
		
		#endregion

		#region Property  SqlTableAliases
		
		private IList sqlTableAliases = new ArrayList() ;
		
		public IList SqlTableAliases
		{
			get => this.sqlTableAliases;
		    set => this.sqlTableAliases = value;
		}
		
		#endregion

		#region Get Table

		public SqlTable GetSqlTable(ITableMap tableMap)
		{
			SqlTable sqlTable = FindSqlTable(tableMap.Name) ;
			if (sqlTable == null)
				sqlTable = new SqlTable(this, tableMap) ;
			return sqlTable;
		}

		public SqlTable GetSqlTable(string name)
		{
			SqlTable sqlTable = FindSqlTable(name) ;
			if (sqlTable == null)
				sqlTable = new SqlTable(this, name) ;
			return sqlTable;
		}

		public SqlTable FindSqlTable(string name)
		{
			foreach(SqlTable sqlTable in this.sqlTables)
			{
				if (sqlTable.Name == name) 
					return sqlTable;
			}
			return null ;
		}

		#endregion

		#region Get Column

		public SqlColumn GetSqlColumn(string name, string tableName)
		{
			SqlTable sqlTable = GetSqlTable(tableName);
			SqlColumn sqlColumn = FindSqlColumn(sqlTable, name) ;
			if (sqlColumn == null)
				sqlColumn = new SqlColumn(sqlTable, name) ;				
			return sqlColumn;
		}

		public SqlColumn GetSqlColumn(IColumnMap columnMap)
		{
			SqlTable sqlTable = GetSqlTable(columnMap.TableMap);
			SqlColumn sqlColumn = FindSqlColumn(sqlTable, columnMap.Name) ;
			if (sqlColumn == null)
				sqlColumn = new SqlColumn(sqlTable, columnMap) ;				
			return sqlColumn;
		}

		public SqlColumn FindSqlColumn(SqlTable sqlTable, string name)
		{
			if (sqlTable != null)
				return sqlTable.FindSqlColumn(name);
			return null ;				
		}

		#endregion

		#region Get TableAlias

		public SqlTableAlias GetSqlTableAlias(ITableMap tableMap) => GetSqlTableAlias(tableMap, "");

	    public SqlTableAlias GetSqlTableAlias(string name) => GetSqlTableAlias(name, "");

	    public SqlTableAlias GetSqlTableAlias(ITableMap tableMap, string alias)
		{
			SqlTableAlias sqlTableAlias = FindSqlTableAlias(tableMap.Name, alias) ;
			if (sqlTableAlias == null)
			{
				SqlTable sqlTable = GetSqlTable(tableMap);
				sqlTableAlias = new SqlTableAlias(this, sqlTable, alias) ;
			}
			return sqlTableAlias;
		}

		public SqlTableAlias GetSqlTableAlias(string name, string alias)
		{
			SqlTableAlias sqlTableAlias = FindSqlTableAlias(name, alias) ;
			if (sqlTableAlias == null)
			{
				SqlTable sqlTable = GetSqlTable(name);
				sqlTableAlias = new SqlTableAlias(this, sqlTable, alias) ;
			}
			return sqlTableAlias;
		}

		public SqlTableAlias FindSqlTableAlias(string name, string alias)
		{
			if (alias == "")
				alias = name;
			foreach(SqlTableAlias sqlTableAlias in this.sqlTableAliases)
			{
				if (sqlTableAlias.Alias == alias) 
					return sqlTableAlias;
			}
			if (alias == name)
			{				
				foreach(SqlTableAlias sqlTableAlias in this.sqlTableAliases)
				{
					if (sqlTableAlias.SqlTable.Name == name) 
						return sqlTableAlias;
				}
			}
			return null ;
		}

		#endregion

		#region Get ColumnAlias

		public SqlColumnAlias GetSqlColumnAlias(string name, string tableName) => GetSqlColumnAlias(name, tableName, "", tableName);

	    public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap) => GetSqlColumnAlias(columnMap, "", columnMap.TableMap.Name);

	    public SqlColumnAlias GetSqlColumnAlias(string name, string tableName, string alias) => GetSqlColumnAlias(name, tableName, alias, tableName);

	    public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap, string alias) => GetSqlColumnAlias(columnMap, alias, columnMap.TableMap.Name);

	    public SqlColumnAlias GetSqlColumnAlias(string name, string tableName, string alias, string tableAlias)
		{
			SqlTableAlias sqlTableAlias = GetSqlTableAlias(tableName, tableAlias);
			SqlColumnAlias sqlColumnAlias = FindSqlColumnAlias(sqlTableAlias, name, alias, tableAlias) ;
			if (sqlColumnAlias == null)
			{
				SqlColumn sqlColumn = GetSqlColumn(name, tableName);
				sqlColumnAlias = new SqlColumnAlias(sqlTableAlias, sqlColumn, alias) ;				
			}
			return sqlColumnAlias;
		}

		public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap, string alias, string tableAlias)
		{
			SqlTableAlias sqlTableAlias = GetSqlTableAlias(columnMap.TableMap, tableAlias);
			SqlColumnAlias sqlColumnAlias = FindSqlColumnAlias(sqlTableAlias, columnMap.Name, alias, tableAlias) ;
			if (sqlColumnAlias == null)
			{
				SqlColumn sqlColumn = GetSqlColumn(columnMap);
				sqlColumnAlias = new SqlColumnAlias(sqlTableAlias, sqlColumn, alias) ;				
			}
			return sqlColumnAlias;
		}

		public SqlColumnAlias FindSqlColumnAlias(SqlTableAlias sqlTableAlias, string name, string alias, string tableAlias)
		{
			if (sqlTableAlias != null)
				return sqlTableAlias.FindSqlColumnAlias(name, alias);
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
