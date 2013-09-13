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
	/// Summary description for SqlSelectStatement.
	/// </summary>
	public class SqlSelectStatement : SqlStatement
	{
		#region Constructors

		private SqlSelectStatement() : base()
		{
			SetupClauses();
		}

		public SqlSelectStatement(ISourceMap sourceMap) : base(sourceMap)
		{
			SetupClauses();
		}

		public SqlSelectStatement(string databaseName) : base(databaseName)
		{
			SetupClauses();
		}

		public SqlSelectStatement(SqlPredicate parent) : base()
		{
			this.Parent = parent;
			SetupClauses();
		}

		public SqlPredicate SqlPredicate { get { return this.Parent as SqlPredicate; } }

		private void SetupClauses()
		{
			this.sqlSelectClause = new SqlSelectClause(this);
			this.sqlIntoClause = new SqlIntoClause(this);
			this.sqlFromClause = new SqlFromClause(this);
			this.sqlWhereClause = new SqlWhereClause(this);
			this.sqlGroupByClause = new SqlGroupByClause(this);
			this.sqlHavingClause = new SqlHavingClause(this);
			this.sqlOrderByClause = new SqlOrderByClause(this);
		}

		#endregion

		#region Property  SqlSelectClause
		
		private SqlSelectClause sqlSelectClause;
		
		public SqlSelectClause SqlSelectClause
		{
			get { return this.sqlSelectClause; }
			set { this.sqlSelectClause = value; }
		}
		
		#endregion

		#region Property  SqlIntoClause
		
		private SqlIntoClause sqlIntoClause;
		
		public SqlIntoClause SqlIntoClause
		{
			get { return this.sqlIntoClause; }
			set { this.sqlIntoClause = value; }
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
		
		private SqlWhereClause sqlWhereClause ;
		
		public SqlWhereClause SqlWhereClause
		{
			get { return this.sqlWhereClause; }
			set { this.sqlWhereClause = value; }
		}
		
		#endregion

		#region Property  SqlGroupByClause
		
		private SqlGroupByClause sqlGroupByClause ;
		
		public SqlGroupByClause SqlGroupByClause
		{
			get { return this.sqlGroupByClause; }
			set { this.sqlGroupByClause = value; }
		}
		
		#endregion

		#region Property  SqlHavingClause
		
		private SqlHavingClause sqlHavingClause ;
		
		public SqlHavingClause SqlHavingClause
		{
			get { return this.sqlHavingClause; }
			set { this.sqlHavingClause = value; }
		}
		
		#endregion

		#region Property  SqlOrderByClause
		
		private SqlOrderByClause sqlOrderByClause ;
		
		public SqlOrderByClause SqlOrderByClause
		{
			get { return this.sqlOrderByClause; }
			set { this.sqlOrderByClause = value; }
		}
		
		#endregion

		#region Property  Distinct
		
		private bool distinct = false;
		
		public bool Distinct
		{
			get { return this.distinct; }
			set { this.distinct = value; }
		}
		
		#endregion

		#region Property  Top
		
		private long top = -1;
		
		public long Top
		{
			get { return this.top; }
			set { this.top = value; }
		}
		
		#endregion

		#region Property  Percent
		
		private bool percent;
		
		public bool Percent
		{
			get { return this.percent; }
			set { this.percent = value; }
		}
		
		#endregion

		#region Property  WithTies
		
		private bool withTies;
		
		public bool WithTies
		{
			get { return this.withTies; }
			set { this.withTies = value; }
		}
		
		#endregion

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			this.SqlSelectClause.Accept(visitor) ;
			this.SqlIntoClause.Accept(visitor);
			this.SqlFromClause.Accept(visitor);
			this.SqlWhereClause.Accept(visitor);
			this.SqlOrderByClause.Accept(visitor);
			this.SqlHavingClause.Accept(visitor);
			this.SqlGroupByClause.Accept(visitor);
			visitor.Visited(this);	
		}
	}
}
