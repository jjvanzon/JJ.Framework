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
using System.Data;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class TransactionEventArgs : EventArgs
	{
		private ITransaction m_Transaction = null;
		private IDataSource m_DataSource = null;
		private IsolationLevel m_IsolationLevel = IsolationLevel.ReadCommitted;
		private bool m_AutoPersistAllOnCommit = true;

		public TransactionEventArgs() : base()
		{
		}

		public TransactionEventArgs(IDataSource dataSource, IsolationLevel isolationLevel, bool autoPersistAllOnCommit) : base()
		{
			m_DataSource = dataSource;
			m_IsolationLevel = isolationLevel;
			m_AutoPersistAllOnCommit = autoPersistAllOnCommit;
		}

		public TransactionEventArgs(ITransaction transaction, IDataSource dataSource, IsolationLevel isolationLevel, bool autoPersistAllOnCommit) : base()
		{
			m_Transaction = transaction;
			m_DataSource = dataSource;
			m_IsolationLevel = isolationLevel;
			m_AutoPersistAllOnCommit = autoPersistAllOnCommit;
		}

		public TransactionEventArgs(ITransaction transaction, IDataSource dataSource, bool autoPersistAllOnCommit) : base()
		{
			m_Transaction = transaction;
			m_DataSource = dataSource;
			m_AutoPersistAllOnCommit = autoPersistAllOnCommit;
		}

		public ITransaction Transaction
		{
			get => m_Transaction;
		    set => m_Transaction = value;
		}

		public IDataSource DataSource
		{
			get => m_DataSource;
		    set => m_DataSource = value;
		}

		public IsolationLevel IsolationLevel
		{
			get => m_IsolationLevel;
		    set => m_IsolationLevel = value;
		}

		public bool AutoPersistAllOnCommit
		{
			get => m_AutoPersistAllOnCommit;
		    set => m_AutoPersistAllOnCommit = value;
		}
		

	}
}