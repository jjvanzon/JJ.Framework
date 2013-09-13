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
	/// Summary description for SqlDeleteStatement.
	/// </summary>
	public class SqlDeleteStatement : SqlStatement
	{
		#region Constructors

		private SqlDeleteStatement() : base()
		{
			SetupClauses();
		}

		public SqlDeleteStatement(ISourceMap sourceMap) : base(sourceMap)
		{
			SetupClauses();
		}

		public SqlDeleteStatement(string databaseName) : base(databaseName)
		{
			SetupClauses();
		}

		
		private void SetupClauses()
		{
			this.sqlDeleteClause = new SqlDeleteClause(this);
			this.sqlFromClause = new SqlFromClause(this);
			this.sqlWhereClause = new SqlWhereClause(this);
		}

		#endregion

		#region Property  SqlDeleteClause
		
		private SqlDeleteClause sqlDeleteClause;
		
		public SqlDeleteClause SqlDeleteClause
		{
			get { return this.sqlDeleteClause; }
			set { this.sqlDeleteClause = value; }
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

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			this.SqlDeleteClause.Accept(visitor) ;
			this.SqlFromClause.Accept(visitor);
			this.SqlWhereClause.Accept(visitor);
			visitor.Visited(this);	
		}
	}
}
