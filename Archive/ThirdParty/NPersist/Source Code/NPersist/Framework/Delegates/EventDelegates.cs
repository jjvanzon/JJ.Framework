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
using Puzzle.NPersist.Framework.EventArguments;

namespace Puzzle.NPersist.Framework.Delegates
{
	/// <summary>
	/// Summary description for EventDelegates.
	/// </summary>
	public delegate void BegunTransactionEventHandler(Object sender, TransactionEventArgs e);

	public delegate void BeginningTransactionEventHandler(Object sender, TransactionCancelEventArgs e);

	public delegate void CommittedTransactionEventHandler(Object sender, TransactionEventArgs e);

	public delegate void CommittingTransactionEventHandler(Object sender, TransactionCancelEventArgs e);

	public delegate void RolledbackTransactionEventHandler(Object sender, TransactionEventArgs e);

	public delegate void RollingbackTransactionEventHandler(Object sender, TransactionCancelEventArgs e);

	public delegate void ExecutedSqlEventHandler(Object sender, SqlExecutorEventArgs e);

	public delegate void ExecutingSqlEventHandler(Object sender, SqlExecutorCancelEventArgs e);

	public delegate void CalledWebServiceEventHandler(Object sender, WebServiceEventArgs e);

	public delegate void CallingWebServiceEventHandler(Object sender, WebServiceCancelEventArgs e);

	public delegate void CommittingEventHandler(Object sender, ContextCancelEventArgs e);

	public delegate void CommittedEventHandler(Object sender, ContextEventArgs e);

	public delegate void CreatingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void CreatedObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void InsertingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void InsertedObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void DeletingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void DeletedObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void RemovingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void RemovedObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void CommittingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void CommittedObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void UpdatingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void UpdatedObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void GettingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void GotObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void LoadingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void LoadedObjectEventHandler(Object sender, ObjectEventArgs e);

	public delegate void ReadingPropertyEventHandler(Object sender, PropertyCancelEventArgs e);

	public delegate void ReadPropertyEventHandler(Object sender, PropertyEventArgs e);

	public delegate void WritingPropertyEventHandler(Object sender, PropertyCancelEventArgs e);

	public delegate void WrotePropertyEventHandler(Object sender, PropertyEventArgs e);

	public delegate void LoadingPropertyEventHandler(Object sender, PropertyCancelEventArgs e);

	public delegate void LoadedPropertyEventHandler(Object sender, PropertyEventArgs e);

	public delegate void InstantiatingObjectEventHandler(Object sender, ObjectCancelEventArgs e);

	public delegate void InstantiatedObjectEventHandler(Object sender, ObjectEventArgs e);

}
