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
	/// Summary description for SqlInsertClause.
	/// </summary>
	public class SqlInsertClause : SqlClause
	{
		public SqlInsertClause(SqlInsertStatement sqlInsertStatement) : base(sqlInsertStatement)
		{
		}


		#region Property  SqlTable
		
		private SqlTable sqlTable;
		
		public SqlTable SqlTable
		{
			get => this.sqlTable;
		    set => this.sqlTable = value;
		}
		
		#endregion
			
		public override void Accept(ISqlVisitor visitor)
		{
			visitor.Visiting(this);	
			visitor.Visited(this);	
		}
	}
}
