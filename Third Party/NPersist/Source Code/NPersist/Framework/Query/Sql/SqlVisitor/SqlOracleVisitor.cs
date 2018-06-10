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
using System.Text;
using Puzzle.NPersist.Framework.Sql.Dom;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Visitor
{
	/// <summary>
	/// Summary description for SqlOracleVisitor.
	/// </summary>
	public class SqlOracleVisitor : SqlVisitorBase
	{
		public SqlOracleVisitor()
		{
		}


		#region Template

		#region Property  LeftEncapsulator
		
		private string leftEncapsulator = "";
		
		public override string LeftEncapsulator
		{
			get => this.leftEncapsulator;
		    set => this.leftEncapsulator = value;
		}
		
		#endregion

		#region Property  RightEncapsulator
		
		private string rightEncapsulator = "";
		
		public override string RightEncapsulator
		{
			get => this.rightEncapsulator;
		    set => this.rightEncapsulator = value;
		}
		
		#endregion

		#region Property  ColumnAliasKeyword
		
		private string columnAliasKeyword = "As ";
		
		public override string ColumnAliasKeyword
		{
			get => this.columnAliasKeyword;
		    set => this.columnAliasKeyword = value;
		}
		
		#endregion

		#region Property  TableAliasKeyword
		
		private string tableAliasKeyword = "";
		
		public override string TableAliasKeyword
		{
			get => this.tableAliasKeyword;
		    set => this.tableAliasKeyword = value;
		}
		
		#endregion


		#endregion


	}
}
