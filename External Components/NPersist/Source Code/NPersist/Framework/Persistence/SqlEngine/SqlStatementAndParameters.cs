using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for SqlStatementAndDbParameter.
	/// </summary>
	public class SqlStatementAndDbParameters
	{
		public SqlStatementAndDbParameters()
		{
		}

		public SqlStatementAndDbParameters(string sql, ArrayList dbParams)
		{
			this.sqlStatement = sql;
			this.dbParameters = dbParams;
		}

		private string sqlStatement;
		
		public string SqlStatement
		{
			get { return this.sqlStatement; }
			set { this.sqlStatement = value; }
		}
		
		private IList dbParameters;
		
		public IList DbParameters
		{
			get { return this.dbParameters; }
			set { this.dbParameters = value; }
		}

	}
}
