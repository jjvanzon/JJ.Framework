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
	/// Summary description for SqlInsertStatement.
	/// </summary>
	public class SqlInsertStatement : SqlStatement
	{
		#region Constructors

		private SqlInsertStatement() : base()
		{
			SetupClauses();
		}

		public SqlInsertStatement(ISourceMap sourceMap) : base(sourceMap)
		{
			SetupClauses();
		}

		public SqlInsertStatement(string databaseName) : base(databaseName)
		{
			SetupClauses();
		}


		private void SetupClauses()
		{
			this.sqlInsertClause = new SqlInsertClause(this);
		}

		#endregion

		#region Property  SqlInsertClause
		
		private SqlInsertClause sqlInsertClause;
		
		public SqlInsertClause SqlInsertClause
		{
			get { return this.sqlInsertClause; }
			set { this.sqlInsertClause = value; }
		}
		
		#endregion

		#region Property  DefaultValues
		
		private bool defaultValues;
		
		public bool DefaultValues
		{
			get { return this.defaultValues; }
			set { this.defaultValues = value; }
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
