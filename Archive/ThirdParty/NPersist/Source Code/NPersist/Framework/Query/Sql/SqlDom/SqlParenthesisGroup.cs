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
using Puzzle.NPath.Framework.CodeDom;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlHavingClause.
	/// </summary>
	public class SqlParenthesisGroup : SqlExpression
	{
		public SqlParenthesisGroup(bool isNegative,SqlExpression expression)
		{
			this.IsNegative = isNegative;
			this.Expression = expression;
		}

		#region Public Property Expression
		private SqlExpression expression;
		public SqlExpression Expression
		{
			get => this.expression;
		    set => this.expression = value;
		}
		#endregion

		#region Public Property IsNegative
		private bool isNegative;
		public bool IsNegative
		{
			get => this.isNegative;
		    set => this.isNegative = value;
		}
		#endregion

		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this) ;
			visitor.Visited(this) ;
		}
	}
}
