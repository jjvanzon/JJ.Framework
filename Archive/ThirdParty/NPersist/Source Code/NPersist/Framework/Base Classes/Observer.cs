using System;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Interfaces;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *


//HACK: Roger was here again..
//förslag till basimplementation för observers ,
//ärv och overrida det du behöver istället för att få en stor bloatad kodfil med massa tomma metoder

namespace Puzzle.NPersist.Framework.BaseClasses
{
	public abstract class Observer : IObserver
	{
		protected Observer()
		{
		}

		public virtual void OnBeginningTransaction(object sender, TransactionCancelEventArgs e)
		{
		}

		public virtual void OnBegunTransaction(object sender, TransactionEventArgs e)
		{
		}

		public virtual void OnCommittingTransaction(object sender, TransactionCancelEventArgs e)
		{
		}

		public virtual void OnCommittedTransaction(object sender, TransactionEventArgs e)
		{
		}

		public virtual void OnRollingbackTransaction(object sender, TransactionCancelEventArgs e)
		{
		}

		public virtual void OnRolledbackTransaction(object sender, TransactionEventArgs e)
		{
		}

		public virtual void OnExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
		}

		public virtual void OnExecutedSql(object sender, SqlExecutorEventArgs e)
		{
		}

		public void OnCallingWebService(object sender, WebServiceCancelEventArgs e)
		{			
		}

		public void OnCalledWebService(object sender, WebServiceEventArgs e)
		{
		}

		public virtual void OnCommitting(object sender, ContextCancelEventArgs e)
		{
		}

		public virtual void OnCommitted(object sender, ContextEventArgs e)
		{
		}

		public virtual void OnCreatingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnCreatedObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnInsertingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnInsertedObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnDeletingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnDeletedObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnRemovingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnRemovedObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnCommittingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnCommittedObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnUpdatingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnUpdatedObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnGettingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnGotObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnLoadingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnLoadedObject(object sender, ObjectEventArgs e)
		{
		}

		public virtual void OnReadingProperty(object sender, PropertyCancelEventArgs e)
		{
		}

		public virtual void OnReadProperty(object sender, PropertyEventArgs e)
		{
		}

		public virtual void OnWritingProperty(object sender, PropertyCancelEventArgs e)
		{
		}

		public virtual void OnWroteProperty(object sender, PropertyEventArgs e)
		{
		}

		public virtual void OnLoadingProperty(object sender, PropertyCancelEventArgs e)
		{
		}

		public virtual void OnLoadedProperty(object sender, PropertyEventArgs e)
		{
		}


		public virtual void OnInstantiatingObject(object sender, ObjectCancelEventArgs e)
		{
		}

		public virtual void OnInstantiatedObject(object sender, ObjectEventArgs e)
		{
		}
	}
}