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
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Sql.Visitor;

namespace Puzzle.NPersist.Framework.Sql.Dom
{
	/// <summary>
	/// Summary description for SqlDefaultAliasGenerator.
	/// </summary>
	public class SqlDefaultAliasGenerator : ISqlAliasGenerator
	{
		public SqlDefaultAliasGenerator(SqlStatement sqlStatement)
		{
			this.sqlStatement = sqlStatement; 
		}

		#region Property  SqlStatement
		
		private SqlStatement sqlStatement;
		
		public SqlStatement SqlStatement
		{
			get { return this.sqlStatement; }
			set { this.sqlStatement = value; }
		}
		
		#endregion

		public string GenerateAlias(SqlTable sqlTable)
		{
			throw new IAmOpenSourcePleaseImplementMeException();
		}

		public string GenerateAlias(SqlColumn sqlColumn)
		{
			throw new IAmOpenSourcePleaseImplementMeException();
		}
	}
}
