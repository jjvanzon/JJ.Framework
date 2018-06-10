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
	/// Summary description for SqlPredicate.
	/// </summary>
	public abstract class SqlPredicate : SqlExpression
	{
		protected SqlPredicate(SqlSearchCondition sqlSearchCondition)
		{
			this.Parent = sqlSearchCondition;
			sqlSearchCondition.SqlPredicate = this;
		}

		public SqlSearchCondition SqlSearchCondition => this.Parent as SqlSearchCondition;
	}
}
