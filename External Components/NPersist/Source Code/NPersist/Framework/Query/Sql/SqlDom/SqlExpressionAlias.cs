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
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlExpressionAlias.
	/// </summary>
	public class SqlExpressionAlias : SqlNodeBase
	{
		private SqlExpression sqlExpression;

		#region Constructors

		public SqlExpressionAlias(SqlDatabase sqlDatabase, SqlExpression sqlExpression, string alias)
		{
			this.Parent = sqlDatabase;
			this.sqlExpression = sqlExpression;
			this.alias = alias;
		}

		#endregion
		
		public SqlExpression SqlExpression
		{
			get { return this.sqlExpression; }
			set { this.sqlExpression = value; }
		}

		public SqlDatabase SqlDatabase { get { return this.Parent as SqlDatabase; } }

		#region Property  Alias
		
		private string alias;
		
		public string Alias
		{
			get { return this.alias; }
		}
		
		#endregion

		
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
