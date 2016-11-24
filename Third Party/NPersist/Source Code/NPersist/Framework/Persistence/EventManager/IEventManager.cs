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
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface IEventManager : IContextChild
	{
		IObserver Observer { get; set; }

		IValidationManager ValidationManager { get; set; }

		bool RaiseEvents { get; set; }

		bool RaiseBeforeEvents { get; set; }

		bool RaiseAfterEvents { get; set; }

		bool RaiseSqlExecutorEvents { get; set; }

		bool RaiseWebServiceEvents { get; set; }

		bool RaiseTransactionEvents { get; set; }

		bool RaiseExceptionEvents { get; set; }

		bool RaiseContextEvents { get; set; }

		bool RaiseObjectEvents { get; set; }

		bool RaisePropertyEvents { get; set; }

		
		//void OnException(object sender, ExceptionCancelEventArgs e);


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

		void OnCreatingObject(object sender, ObjectCancelEventArgs e);

		void OnCreatedObject(object sender, ObjectEventArgs e);

		void OnInsertingObject(object sender, ObjectCancelEventArgs e);

		void OnInsertedObject(object sender, ObjectEventArgs e);

		void OnDeletingObject(object sender, ObjectCancelEventArgs e);

		void OnDeletedObject(object sender, ObjectEventArgs e);

		void OnRemovingObject(object sender, ObjectCancelEventArgs e);

		void OnRemovedObject(object sender, ObjectEventArgs e);

		void OnCommittingObject(object sender, ObjectCancelEventArgs e);

		void OnCommittedObject(object sender, ObjectEventArgs e);

		void OnUpdatingObject(object sender, ObjectCancelEventArgs e);

		void OnUpdatedObject(object sender, ObjectEventArgs e);

		void OnGettingObject(object sender, ObjectCancelEventArgs e);

		void OnGotObject(object sender, ObjectEventArgs e);

		void OnLoadingObject(object sender, ObjectCancelEventArgs e);

		void OnLoadedObject(object sender, ObjectEventArgs e);

		void OnReadingProperty(object sender, PropertyCancelEventArgs e);

		void OnReadProperty(object sender, PropertyEventArgs e);

		void OnWritingProperty(object sender, PropertyCancelEventArgs e);

		void OnWroteProperty(object sender, PropertyEventArgs e);

		void OnLoadingProperty(object sender, PropertyCancelEventArgs e);

		void OnLoadedProperty(object sender, PropertyEventArgs e);

		void OnInstantiatingObject(object sender, ObjectCancelEventArgs e);

		void OnInstantiatedObject(object sender, ObjectEventArgs e);


		void AddObserver(IObserver observer);

		void AddObserver(IObserver observer, ObserverTarget observerTarget);

		void AddObserver(IObserver observer, Type type);

		void AddObserver(IObserver observer, object obj);

		void AddObserver(IObserver observer, params object[] targets);

		IList GetAllObservers();

		IList GetObservers();

		IList GetObservers(ObserverTarget observerTarget);

		IList GetObservers(Type type);

		IList GetObservers(object obj);

	}
}