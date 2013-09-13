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
using System.Data;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlStatement.
	/// </summary>
	public abstract class SqlStatement : SqlExpression
	{
		#region Constructors

		protected SqlStatement()
		{
			this.sqlDatabase = new SqlDatabase(this, "");
			this.sqlAliasGenerator = new SqlDefaultAliasGenerator(this);
		}

		protected SqlStatement(ISourceMap sourceMap)
		{
			this.sqlDatabase = new SqlDatabase(this, sourceMap);
			this.sqlAliasGenerator = new SqlDefaultAliasGenerator(this);
		}

		protected SqlStatement(string databaseName)
		{
			this.sqlDatabase = new SqlDatabase(this, databaseName);
			this.sqlAliasGenerator = new SqlDefaultAliasGenerator(this);
		}

		#endregion

		#region Private Member Variables

		private int nextParameterIndex = 0;
		private int nextTableAliasIndex = 0;
		private int nextColumnAliasIndex = 0;

		#endregion

		#region Property  SqlDatabase
		
		private SqlDatabase sqlDatabase;
		
		public SqlDatabase SqlDatabase
		{
			get { return this.sqlDatabase; }
			set { this.sqlDatabase = value; }
		}
		
		#endregion

		#region GetTable

		public SqlTable GetSqlTable(ITableMap tableMap)
		{
			return this.sqlDatabase.GetSqlTable(tableMap);
		}

		public SqlTable GetSqlTable(string name)
		{
			return this.sqlDatabase.GetSqlTable(name);
		}

		#endregion

		#region GetColumn

		public SqlColumn GetSqlColumn(string name, string tableName)
		{
			return this.sqlDatabase.GetSqlColumn(name, tableName);
		}

		public SqlColumn GetSqlColumn(IColumnMap columnMap)
		{
			return this.sqlDatabase.GetSqlColumn(columnMap);
		}

		#endregion
		
		#region Get TableAlias

		public SqlTableAlias GetSqlTableAlias(SqlTable sqlTable)
		{
			return this.sqlDatabase.GetSqlTableAlias(sqlTable.Name);
		}

		public SqlTableAlias GetSqlTableAlias(ITableMap tableMap)
		{
			return this.sqlDatabase.GetSqlTableAlias(tableMap);
		}

		public SqlTableAlias GetSqlTableAlias(string name)
		{
			return this.sqlDatabase.GetSqlTableAlias(name);
		}

		public SqlTableAlias GetSqlTableAlias(ITableMap tableMap, string alias)
		{
			return this.sqlDatabase.GetSqlTableAlias(tableMap, alias);
		}

		public SqlTableAlias GetSqlTableAlias(string name, string alias)
		{
			return this.sqlDatabase.GetSqlTableAlias(name, alias);
		}

		#endregion

		#region Get ColumnAlias
	
		public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap)
		{
			return this.sqlDatabase.GetSqlColumnAlias(columnMap);
		}

		public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap, string alias)
		{
			return this.sqlDatabase.GetSqlColumnAlias(columnMap, alias);
		}

		public SqlColumnAlias GetSqlColumnAlias(IColumnMap columnMap, string alias, string tableAlias)
		{
			return this.sqlDatabase.GetSqlColumnAlias(columnMap, alias, tableAlias);
		}

	
		public SqlColumnAlias GetSqlColumnAlias(string name, string tableName)
		{
			return this.sqlDatabase.GetSqlColumnAlias(name, tableName);
		}

		public SqlColumnAlias GetSqlColumnAlias(string name, string tableName, string alias)
		{
			return this.sqlDatabase.GetSqlColumnAlias(name, tableName, alias);
		}

		public SqlColumnAlias GetSqlColumnAlias(string name, string tableName, string alias, string tableAlias)
		{
			return this.sqlDatabase.GetSqlColumnAlias(name, tableName, alias, tableAlias);
		}


		#endregion

		#region Property  SqlAliasGenerator
		
		private ISqlAliasGenerator sqlAliasGenerator;
		
		public ISqlAliasGenerator SqlAliasGenerator
		{
			get { return this.sqlAliasGenerator; }
			set { this.sqlAliasGenerator = value; }
		}
		
		#endregion

		#region Property  SqlParameters
		
		private IList sqlParameters = new ArrayList() ;
		
		public IList SqlParameters
		{
			get { return this.sqlParameters; }
			set { this.sqlParameters = value; }
		}
		
		#endregion

		#region AddSqlParameter method

		public SqlParameter AddSqlParameter(string name)
		{
			return AddSqlParameter(name, DbType.AnsiString, null );
		}

		public SqlParameter AddSqlParameter(DbType dbType)
		{
			return AddSqlParameter("", dbType, null);
		}

		public SqlParameter AddSqlParameter(DbType dbType, object value)
		{
			return AddSqlParameter("", dbType, value);
		}

		public SqlParameter AddSqlParameter(string name, DbType dbType)
		{
			return AddSqlParameter(name, dbType, null);
		}

		public SqlParameter AddSqlParameter(string name, DbType dbType, object value)
		{
			SqlParameter sqlParameter = new SqlParameter(this, value, dbType, name);
			this.sqlParameters.Add(sqlParameter);
			return sqlParameter;
		}

		#endregion

		public int GetNextParameterIndex()
		{
			nextParameterIndex++;
			return nextParameterIndex;
		}

		public int GetNextTableAliasIndex()
		{
			nextTableAliasIndex++;
			return nextTableAliasIndex;
		}

		public int GetNextColumnAliasIndex()
		{
			nextColumnAliasIndex++;
			return nextColumnAliasIndex;
		}
	}
}
