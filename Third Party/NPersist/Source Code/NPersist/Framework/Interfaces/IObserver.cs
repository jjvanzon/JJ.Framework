using Puzzle.NPersist.Framework.EventArguments;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Interfaces
{
	public interface IObserver : IEventListener
	{
		void OnBeginningTransaction(object sender, TransactionCancelEventArgs e);

		void OnBegunTransaction(object sender, TransactionEventArgs e);

		void OnCommittingTransaction(object sender, TransactionCancelEventArgs e);

		void OnCommittedTransaction(object sender, TransactionEventArgs e);

		void OnRollingbackTransaction(object sender, TransactionCancelEventArgs e);

		void OnRolledbackTransaction(object sender, TransactionEventArgs e);

		void OnExecutingSql(object sender, SqlExecutorCancelEventArgs e);

		void OnExecutedSql(object sender, SqlExecutorEventArgs e);

		void OnCallingWebService(object sender, WebServiceCancelEventArgs e);

		void OnCalledWebService(object sender, WebServiceEventArgs e);

		void OnCommitting(object sender, ContextCancelEventArgs e);

		void OnCommitted(object sender, ContextEventArgs e);
	}
}