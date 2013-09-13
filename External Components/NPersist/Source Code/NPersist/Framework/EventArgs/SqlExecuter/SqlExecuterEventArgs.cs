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
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class SqlExecutorEventArgs : EventArgs
	{
		private string m_Sql;
		private IDataSource m_DataSource;
		private IList m_Parameters;
		private bool m_PostPoned = false;

		public SqlExecutorEventArgs() : base()
		{
		}

		public SqlExecutorEventArgs(string sql, IDataSource ds, IList parameters) : base()
		{
			m_Sql = sql;
			m_DataSource = ds;
			m_Parameters = parameters;
		}

		public SqlExecutorEventArgs(string sql, IDataSource ds, IList parameters, bool postPoned) : base()
		{
			m_Sql = sql;
			m_DataSource = ds;
			m_Parameters = parameters;
			m_PostPoned = postPoned;
		}

		public string Sql
		{
			get { return m_Sql; }
			set { m_Sql = value; }
		}

		public IDataSource DataSource
		{
			get { return m_DataSource; }
			set { m_DataSource = value; }
		}

		public IList Parameters
		{
			get { return m_Parameters; }
			set { m_Parameters = value; }
		}

		public bool PostPoned
		{
			get { return m_PostPoned; }
			set { m_PostPoned = value; }
		}

	}
}