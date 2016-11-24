// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for BatchedSqlStatement.
	/// </summary>
	public class BatchedSqlStatement
	{
		public BatchedSqlStatement()
		{
		}

		public BatchedSqlStatement(string sql, IList parameters)
		{
			this.sql = sql;
			this.parameters = parameters;
		}

		#region Property  Sql
		
		private string sql = "";
		
		public string Sql
		{
			get { return this.sql; }
			set { this.sql = value; }
		}
		
		#endregion

		#region Property  Parameters
		
		private IList parameters = new ArrayList() ;
		
		public IList Parameters
		{
			get { return this.parameters; }
			set { this.parameters = value; }
		}
		
		#endregion

	}
}
