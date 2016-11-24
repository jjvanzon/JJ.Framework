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
	/// Summary description for SqlUpdateStatement.
	/// </summary>
	public class SqlUpdateStatement : SqlStatement
	{
		#region Constructors

		private SqlUpdateStatement() : base()
		{
			SetupClauses();
		}

		public SqlUpdateStatement(ISourceMap sourceMap) : base(sourceMap)
		{
			SetupClauses();
		}

		public SqlUpdateStatement(string databaseName) : base(databaseName)
		{
			SetupClauses();
		}


		private void SetupClauses()
		{
			this.sqlUpdateClause = new SqlUpdateClause(this);
			this.sqlFromClause = new SqlFromClause(this);
			this.sqlWhereClause = new SqlWhereClause(this);
		}

		#endregion
		
		#region Property  SqlUpdateClause
		
		private SqlUpdateClause sqlUpdateClause;
		
		public SqlUpdateClause SqlUpdateClause
		{
			get { return this.sqlUpdateClause; }
			set { this.sqlUpdateClause = value; }
		}
		
		#endregion

		#region Property  SqlFromClause
		
		private SqlFromClause sqlFromClause;
		
		public SqlFromClause SqlFromClause
		{
			get { return this.sqlFromClause; }
			set { this.sqlFromClause = value; }
		}
		
		#endregion

		#region Property  SqlWhereClause
		
		private SqlWhereClause sqlWhereClause;
		
		public SqlWhereClause SqlWhereClause
		{
			get { return this.sqlWhereClause; }
			set { this.sqlWhereClause = value; }
		}
		
		#endregion

		#region Property  SqlColumnList
		
		private IList sqlColumnList = new ArrayList() ;
		
		public IList SqlColumnList
		{
			get { return this.sqlColumnList; }
			set { this.sqlColumnList = value; }
		}
		
		#endregion

		#region Property  ValueList
		
		private IList valueList = new ArrayList();
		
		public IList ValueList
		{
			get { return this.valueList; }
			set { this.valueList = value; }
		}
		
		#endregion

		public void AddSqlColumnAndValue(SqlColumnAlias sqlColumnAlias, SqlExpression sqlExpression)
		{
			AddSqlColumnAndValue(sqlColumnAlias.SqlColumn, sqlExpression);
		}

		public void AddSqlColumnAndValue(SqlColumn sqlColumn, SqlExpression sqlExpression)
		{
			this.sqlColumnList.Add(sqlColumn);
			this.valueList.Add(sqlExpression);
		}

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}

	}
}
