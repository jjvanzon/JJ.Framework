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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NCore.Framework.Logging;
using System.Collections;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class Transaction : TransactionBase
	{
		private IDbTransaction m_DbTransaction;
		private IDataSource m_DataSource;
		private bool m_OriginalKeepOpen;

		public Transaction(IDbTransaction dbTransaction, IDataSource dataSource, IContext ctx) : base(ctx)
		{
			m_DbTransaction = dbTransaction;
			m_DataSource = dataSource;
			m_OriginalKeepOpen = m_DataSource.KeepConnectionOpen;
			m_DataSource.KeepConnectionOpen = true;
		}

		public override IDbTransaction DbTransaction
		{
			get => m_DbTransaction;
		    set => m_DbTransaction = value;
		}

        public override void Commit()
		{
            base.Commit();

            LogMessage message = new LogMessage("Committing local transaction");
            LogMessage verbose = new LogMessage("Data source: {0}, Auto persist: {1}" , m_DataSource.Name , this.AutoPersistAllOnCommit  );
			this.Context.LogManager.Info(this, message , verbose); // do not localize	

			TransactionCancelEventArgs e = new TransactionCancelEventArgs(this, m_DataSource, this.IsolationLevel, this.AutoPersistAllOnCommit);
			this.Context.EventManager.OnCommittingTransaction(this, e);
			if (e.Cancel)
			{
				return;
			}
			this.AutoPersistAllOnCommit = e.AutoPersistAllOnCommit;			

			if (this.AutoPersistAllOnCommit)
			{
				this.Context.Commit();
			}
			m_DbTransaction.Commit();
			this.Context.OnTransactionComplete(this);
			m_DataSource.KeepConnectionOpen = m_OriginalKeepOpen;

			m_DataSource.ReturnConnection();

			TransactionEventArgs e2 = new TransactionEventArgs(this, m_DataSource, this.AutoPersistAllOnCommit);
			this.Context.EventManager.OnCommittedTransaction(this, e2);
		}

        public override IDbConnection Connection => m_DbTransaction.Connection;

	    public override IsolationLevel IsolationLevel => m_DbTransaction.IsolationLevel;

	    public override void Rollback()
		{
            base.Rollback();

            LogMessage message = new LogMessage("Rolling back local transaction");
            LogMessage verbose = new LogMessage("Data source: {0}, Auto persist: {1}", m_DataSource.Name, this.AutoPersistAllOnCommit);
            this.Context.LogManager.Info(this, message, verbose); // do not localize	

            TransactionCancelEventArgs e = new TransactionCancelEventArgs(this, m_DataSource, this.AutoPersistAllOnCommit);
			this.Context.EventManager.OnRollingbackTransaction(this, e);
			if (e.Cancel)
			{
				return;
			}
			this.AutoPersistAllOnCommit = e.AutoPersistAllOnCommit;			
			m_DbTransaction.Rollback();
			this.Context.OnTransactionComplete(this);
			m_DataSource.KeepConnectionOpen = m_OriginalKeepOpen;
			m_DataSource.ReturnConnection();

			TransactionEventArgs e2 = new TransactionEventArgs(this, m_DataSource, this.AutoPersistAllOnCommit);
			this.Context.EventManager.OnRolledbackTransaction(this, e2);
		}

		public override void Dispose()
		{
			m_DbTransaction.Dispose();
			GC.SuppressFinalize(this);
		}

        public override IDataSource DataSource
		{
			get => m_DataSource;
            set => m_DataSource = value;
        }
	}
}