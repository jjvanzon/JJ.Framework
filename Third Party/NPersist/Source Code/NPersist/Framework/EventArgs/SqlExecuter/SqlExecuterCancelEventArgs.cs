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
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class SqlExecutorCancelEventArgs : SqlExecutorEventArgs
	{
		private bool m_Cancel;

		public SqlExecutorCancelEventArgs() : base()
		{
		}

		public SqlExecutorCancelEventArgs(string sql, IDataSource ds, IList parameters) : base(sql, ds, parameters)
		{
		}

		public SqlExecutorCancelEventArgs(string sql, IDataSource ds, IList parameters, bool postPoned) : base(sql, ds, parameters, postPoned)
		{
		}

		public bool Cancel
		{
			get { return m_Cancel; }
			set { m_Cancel = value; }
		}
	}
}