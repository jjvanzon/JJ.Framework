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
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlExistsPredicate.
	/// </summary>
	public class SqlExistsPredicate : SqlPredicate
	{
		public SqlExistsPredicate(SqlSearchCondition sqlSearchCondition) : base(sqlSearchCondition)
		{
			this.sqlSelectStatement = new SqlSelectStatement(this);
		}

		#region Property  SqlSelectStatement
		
		private SqlSelectStatement sqlSelectStatement;
		
		public SqlSelectStatement SqlSelectStatement
		{
			get { return this.sqlSelectStatement; }
			set { this.sqlSelectStatement = value; }
		}
		
		#endregion
		
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
