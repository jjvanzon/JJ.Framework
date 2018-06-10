// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Data;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class TransactionCancelEventArgs : TransactionEventArgs
	{
		private bool m_Cancel;

		public TransactionCancelEventArgs() : base()
		{
		}

		public TransactionCancelEventArgs(IDataSource dataSource, IsolationLevel isolationLevel, bool autoPersistAllOnCommit) : base(dataSource, isolationLevel, autoPersistAllOnCommit)
		{
		}

		public TransactionCancelEventArgs(ITransaction transaction, IDataSource dataSource, IsolationLevel isolationLevel, bool autoPersistAllOnCommit) : base(transaction, dataSource, isolationLevel, autoPersistAllOnCommit)
		{
		}

		public TransactionCancelEventArgs(ITransaction transaction, IDataSource dataSource, bool autoPersistAllOnCommit) : base(transaction, dataSource, autoPersistAllOnCommit)
		{
		}

		public bool Cancel
		{
			get => m_Cancel;
		    set => m_Cancel = value;
		}
	}
}