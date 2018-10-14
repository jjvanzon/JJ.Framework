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
using System.Diagnostics;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class EventManager : ContextChild, IEventManager
	{
		private IObserver m_Observer = null;
		private IValidationManager m_ValidationManager = null;
		private bool m_RaiseEvents = true;
		private bool m_RaiseBeforeEvents = true;
		private bool m_RaiseAfterEvents = true;
		private bool m_RaiseSqlExecutorEvents = true;
		private bool m_RaiseTransactionEvents = true;
		private bool m_RaiseWebServiceEvents = true;
		private bool m_RaiseExceptionEvents = true;
		private bool m_RaiseObjectEvents = true;
		private bool m_RaiseContextEvents = true;
		private bool m_RaisePropertyEvents = true;
		private ArrayList m_Observers = new ArrayList();
		private ArrayList m_ContextObservers = new ArrayList();
		private ArrayList m_AllTypeObservers = new ArrayList();
		private Hashtable m_TypeObservers; // Note! do not init...lazy init for best perf (used in GetTypeObservers() to avoid checks if this is null..
		private Hashtable m_ObjectObservers = new Hashtable();

		private ArrayList m_EmptyList = new ArrayList();

		public virtual IObserver Observer
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_Observer;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_Observer = value;
		}

		public virtual IValidationManager ValidationManager
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_ValidationManager;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set => m_ValidationManager = value;
		}

		public virtual bool RaiseEvents
		{
			get => m_RaiseEvents;
		    set => m_RaiseEvents = value;
		}

		public virtual bool RaiseBeforeEvents
		{
			get => m_RaiseBeforeEvents;
		    set => m_RaiseBeforeEvents = value;
		}

		public virtual bool RaiseAfterEvents
		{
			get => m_RaiseAfterEvents;
		    set => m_RaiseAfterEvents = value;
		}

		public virtual bool RaiseSqlExecutorEvents
		{
			get => m_RaiseSqlExecutorEvents;
		    set => m_RaiseSqlExecutorEvents = value;
		}
		public virtual bool RaiseWebServiceEvents
		{
			get => m_RaiseWebServiceEvents;
		    set => m_RaiseWebServiceEvents = value;
		}

		public virtual bool RaiseTransactionEvents
		{
			get => m_RaiseTransactionEvents;
		    set => m_RaiseTransactionEvents = value;
		}

		public virtual bool RaiseExceptionEvents
		{
			get => m_RaiseExceptionEvents;
		    set => m_RaiseExceptionEvents = value;
		}

		public virtual bool RaiseObjectEvents
		{
			get => m_RaiseObjectEvents;
		    set => m_RaiseObjectEvents = value;
		}

		public virtual bool RaiseContextEvents
		{
			get => m_RaiseContextEvents;
		    set => m_RaiseContextEvents = value;
		}

		public virtual bool RaisePropertyEvents
		{
			get => m_RaisePropertyEvents;
		    set => m_RaisePropertyEvents = value;
		}


		public virtual void OnBegunTransaction(object sender, TransactionEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseTransactionEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnBegunTransaction(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnBegunTransaction(sender, e);
			}
			this.Observer.OnBegunTransaction(sender, e);
		}

		public virtual void OnBeginningTransaction(object sender, TransactionCancelEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseTransactionEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
					observer.OnBeginningTransaction(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnBeginningTransaction(sender, e);
			}
			this.Observer.OnBeginningTransaction(sender, e);
		}


		public virtual void OnCommittedTransaction(object sender, TransactionEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseTransactionEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCommittedTransaction(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnCommittedTransaction(sender, e);
			}
			this.Observer.OnCommittedTransaction(sender, e);
		}

		public virtual void OnCommittingTransaction(object sender, TransactionCancelEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseTransactionEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCommittingTransaction(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnCommittingTransaction(sender, e);
			}
			this.Observer.OnCommittingTransaction(sender, e);
		}

		
		public virtual void OnRolledbackTransaction(object sender, TransactionEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseTransactionEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnRolledbackTransaction(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnRolledbackTransaction(sender, e);
			}
			this.Observer.OnRolledbackTransaction(sender, e);
		}

		public virtual void OnRollingbackTransaction(object sender, TransactionCancelEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseTransactionEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnRollingbackTransaction(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnRollingbackTransaction(sender, e);
			}
			this.Observer.OnRollingbackTransaction(sender, e);
		}

		public virtual void OnExecutedSql(object sender, SqlExecutorEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseSqlExecutorEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnExecutedSql(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnExecutedSql(sender, e);
			}
			this.Observer.OnExecutedSql(sender, e);
		}

		public virtual void OnExecutingSql(object sender, SqlExecutorCancelEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseSqlExecutorEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnExecutingSql(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnExecutingSql(sender, e);
			}
			this.Observer.OnExecutingSql(sender, e);
		}

		public virtual void OnCalledWebService(object sender, WebServiceEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseWebServiceEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCalledWebService(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnCalledWebService(sender, e);
			}
			this.Observer.OnCalledWebService(sender, e);
		}

		public virtual void OnCallingWebService(object sender, WebServiceCancelEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseWebServiceEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCallingWebService(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnCallingWebService(sender, e);
			}
			this.Observer.OnCallingWebService(sender, e);
		}

		public void OnCommitted(object sender, ContextEventArgs e)
		{
			IUnitOfWork unitOfWork;
			if (this.ValidationManager.ValidateOnCommitted)
			{
				unitOfWork = this.Context.UnitOfWork;
				foreach (object obj in unitOfWork.GetCreatedObjects())
				{
					if (obj is IValidatable)
					{
						((IValidatable) (obj)).Validate();
					}
				}
				foreach (object obj in unitOfWork.GetDirtyObjects())
				{
					if (obj is IValidatable)
					{
						((IValidatable) (obj)).Validate();
					}
				}
				foreach (object obj in unitOfWork.GetDeletedObjects())
				{
					if (obj is IValidatable)
					{
						((IValidatable) (obj)).Validate();
					}
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseContextEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCommitted(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnCommitted(sender, e);
			}
			this.Observer.OnCommitted(sender, e);
		}

		public void OnCommitting(object sender, ContextCancelEventArgs e)
		{
			IUnitOfWork unitOfWork;
			if (this.ValidationManager.ValidateOnCommitting)
			{
				unitOfWork = this.Context.UnitOfWork;
				foreach (object obj in unitOfWork.GetCreatedObjects())
				{
					if (obj is IValidatable)
					{
						((IValidatable) (obj)).Validate();
					}
				}
				foreach (object obj in unitOfWork.GetDirtyObjects())
				{
					if (obj is IValidatable)
					{
						((IValidatable) (obj)).Validate();
					}
				}
				foreach (object obj in unitOfWork.GetDeletedObjects())
				{
					if (obj is IValidatable)
					{
						((IValidatable) (obj)).Validate();
					}
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseContextEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCommitting(sender, e);
			}
			foreach (IObserver observer in m_ContextObservers)
			{
				observer.OnCommitting(sender, e);
			}
			this.Observer.OnCommitting(sender, e);
		}

		public virtual void OnCreatedObject(object sender, ObjectEventArgs e)
		{
			if (this.ValidationManager.ValidateOnAfterCreate)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCreatedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnCreatedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnCreatedObject(sender, e);
				}
			}
			this.Observer.OnCreatedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnCreatedObject(sender, e);
			}
		}

		public virtual void OnCreatingObject(object sender, ObjectCancelEventArgs e)
		{
			IClassMap classMap;
			IObjectManager om = this.Context.ObjectManager;
			classMap = this.Context.DomainMap.MustGetClassMap(e.EventObject.GetType());
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				EvaluatePropertySpecialBehavior(e.EventObject, propertyMap, propertyMap.OnCreateBehavior, om);
			}
			if (this.ValidationManager.ValidateOnBeforeCreate)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCreatingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnCreatingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnCreatingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnCreatingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnCreatingObject(sender, e);
				}
			}
			this.Observer.OnCreatingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnCreatingObject(sender, e);
			}
		}

		public virtual void OnInsertedObject(object sender, ObjectEventArgs e)
		{
			if (this.ValidationManager.ValidateOnAfterInsert)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnInsertedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnInsertedObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnInsertedObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnInsertedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnInsertedObject(sender, e);
				}
			}
			this.Observer.OnInsertedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnInsertedObject(sender, e);
			}
		}

		public virtual void OnInsertingObject(object sender, ObjectCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnBeforeInsert)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnInsertingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnInsertingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnInsertingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnInsertingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnInsertingObject(sender, e);
				}
			}
			this.Observer.OnInsertingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnInsertingObject(sender, e);
			}
		}

		public virtual void OnDeletedObject(object sender, ObjectEventArgs e)
		{
			if (this.ValidationManager.ValidateOnAfterDelete)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnDeletedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnDeletedObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnDeletedObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnDeletedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnDeletedObject(sender, e);
				}
			}
			this.Observer.OnDeletedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnDeletedObject(sender, e);
			}
		}

		public virtual void OnDeletingObject(object sender, ObjectCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnBeforeDelete)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnDeletingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnDeletingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnDeletingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnDeletingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnDeletingObject(sender, e);
				}
			}
			this.Observer.OnDeletingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnDeletingObject(sender, e);
			}
		}

		public virtual void OnRemovedObject(object sender, ObjectEventArgs e)
		{
			if (this.ValidationManager.ValidateOnAfterRemove)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnRemovedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnRemovedObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnRemovedObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnRemovedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnRemovedObject(sender, e);
				}
			}
			this.Observer.OnRemovedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnRemovedObject(sender, e);
			}
		}

		public virtual void OnRemovingObject(object sender, ObjectCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnBeforeRemove)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnRemovingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnRemovingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnRemovingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnRemovingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnRemovingObject(sender, e);
				}
			}
			this.Observer.OnRemovingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnRemovingObject(sender, e);
			}
		}

		public virtual void OnCommittedObject(object sender, ObjectEventArgs e)
		{
			if (this.ValidationManager.ValidateOnAfterPersist)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCommittedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnCommittedObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnCommittedObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnCommittedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnCommittedObject(sender, e);
				}
			}
			this.Observer.OnCommittedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnCommittedObject(sender, e);
			}
		}

		public virtual void OnCommittingObject(object sender, ObjectCancelEventArgs e)
		{
			IClassMap classMap;
			IObjectManager om = this.Context.ObjectManager;
			classMap = this.Context.DomainMap.MustGetClassMap(e.EventObject.GetType());
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				EvaluatePropertySpecialBehavior(e.EventObject, propertyMap, propertyMap.OnPersistBehavior, om);
			}
			if (this.ValidationManager.ValidateOnBeforePersist)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnCommittingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnCommittingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnCommittingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnCommittingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnCommittingObject(sender, e);
				}
			}
			this.Observer.OnCommittingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnCommittingObject(sender, e);
			}
		}

		public virtual void OnUpdatedObject(object sender, ObjectEventArgs e)
		{
			if (this.ValidationManager.ValidateOnAfterUpdate)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnUpdatedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnUpdatedObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnUpdatedObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnUpdatedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnUpdatedObject(sender, e);
				}
			}
			this.Observer.OnUpdatedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnUpdatedObject(sender, e);
			}
		}

		public virtual void OnUpdatingObject(object sender, ObjectCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnBeforeUpdate)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnUpdatingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnUpdatingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnUpdatingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnUpdatingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnUpdatingObject(sender, e);
				}
			}
			this.Observer.OnUpdatingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnUpdatingObject(sender, e);
			}
		}

		public virtual void OnGotObject(object sender, ObjectEventArgs e)
		{
			if ( e.EventObject == null ) { return; }
			if (this.ValidationManager.ValidateOnAfterGet)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnGotObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnGotObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnGotObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnGotObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnGotObject(sender, e);
				}
			}
			this.Observer.OnGotObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnGotObject(sender, e);
			}
		}

		public virtual void OnGettingObject(object sender, ObjectCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnBeforeGet)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnGettingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnGettingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnGettingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnGettingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnGettingObject(sender, e);
				}
			}
			this.Observer.OnGettingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnGettingObject(sender, e);
			}
		}

		public virtual void OnLoadedObject(object sender, ObjectEventArgs e)
		{
			if (e.EventObject == null) { return ; }
			if (this.ValidationManager.ValidateOnAfterLoad)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnLoadedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnLoadedObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnLoadedObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnLoadedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnLoadedObject(sender, e);
				}
			}
			this.Observer.OnLoadedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnLoadedObject(sender, e);
			}
		}

		public virtual void OnLoadingObject(object sender, ObjectCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnBeforeLoad)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaiseObjectEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnLoadingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnLoadingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnLoadingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnLoadingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnLoadingObject(sender, e);
				}
			}
			this.Observer.OnLoadingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnLoadingObject(sender, e);
			}
		}

		public virtual void OnReadProperty(object sender, PropertyEventArgs e)
		{
			if (this.ValidationManager.ValidateOnReadProperty)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnReadProperty(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnReadProperty(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnReadProperty(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnReadProperty(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnReadProperty(sender, e);
				}
			}
			this.Observer.OnReadProperty(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnReadProperty(sender, e);
			}
		}

		public virtual void OnReadingProperty(object sender, PropertyCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnReadingProperty)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnReadingProperty(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnReadingProperty(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnReadingProperty(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnReadingProperty(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnReadingProperty(sender, e);
				}
			}
			this.Observer.OnReadingProperty(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnReadingProperty(sender, e);
			}
		}

		public virtual void OnLoadedProperty(object sender, PropertyEventArgs e)
		{
			if (this.ValidationManager.ValidateOnAfterPropertyLoad)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnLoadedProperty(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnLoadedProperty(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnLoadedProperty(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnLoadedProperty(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnLoadedProperty(sender, e);
				}
			}
			this.Observer.OnLoadedProperty(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnLoadedProperty(sender, e);
			}
		}

		public void OnInstantiatingObject(object sender, ObjectCancelEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnInstantiatingObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnInstantiatingObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnInstantiatingObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnInstantiatingObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnInstantiatingObject(sender, e);
				}
			}
			this.Observer.OnInstantiatingObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnInstantiatingObject(sender, e);
			}
		}
		public virtual void OnInstantiatedObject(object sender, ObjectEventArgs e)
		{
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnInstantiatedObject(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnInstantiatedObject(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnInstantiatedObject(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnInstantiatedObject(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnInstantiatedObject(sender, e);
				}
			}
			this.Observer.OnInstantiatedObject(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnInstantiatedObject(sender, e);
			}
		}


		public virtual void OnLoadingProperty(object sender, PropertyCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnBeforePropertyLoad)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnLoadingProperty(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnLoadingProperty(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnLoadingProperty(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnLoadingProperty(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnLoadingProperty(sender, e);
				}
			}
			this.Observer.OnLoadingProperty(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnLoadingProperty(sender, e);
			}
		}

		public virtual void OnWroteProperty(object sender, PropertyEventArgs e)
		{
			if (this.ValidationManager.ValidateOnWroteProperty)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseAfterEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnWroteProperty(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnWroteProperty(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnWroteProperty(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnWroteProperty(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnWroteProperty(sender, e);
				}
			}
			this.Observer.OnWroteProperty(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnWroteProperty(sender, e);
			}
		}


		//[DebuggerStepThrough()]
		public virtual void OnWritingProperty(object sender, PropertyCancelEventArgs e)
		{
			if (this.ValidationManager.ValidateOnWritingProperty)
			{
				if (e.EventObject is IValidatable)
				{
					((IValidatable) (e.EventObject)).Validate();
				}
			}
			if (!(m_RaiseEvents))
			{
				return;
			}
			if (!(m_RaiseBeforeEvents))
			{
				return;
			}
			if (!(m_RaisePropertyEvents))
			{
				return;
			}
			foreach (IObserver observer in m_Observers)
			{
				observer.OnWritingProperty(sender, e);
			}
			foreach (IObserver observer in m_AllTypeObservers)
			{
				observer.OnWritingProperty(sender, e);
			}
			foreach (IObserver observer in GetTypeObservers(e.EventObject))
			{
				observer.OnWritingProperty(sender, e);
			}
			foreach (IObserver observer in GetObjectObservers(e.EventObject))
			{
				observer.OnWritingProperty(sender, e);
			}
			if (e.EventObject is IObservable)
			{
				foreach (IEventListener eventListener in ((IObservable) (e.EventObject)).GetEventListeners())
				{
					eventListener.OnWritingProperty(sender, e);
				}
			}
			this.Observer.OnWritingProperty(sender, e);
			if (e.EventObject is IEventListener)
			{
				((IEventListener) (e.EventObject)).OnWritingProperty(sender, e);
			}
		}

		private IList GetTypeObservers(Type type)
		{
			if (m_TypeObservers == null)
				return m_EmptyList;

            type = AssemblyManager.GetBaseType(type);            

			ArrayList result = (ArrayList) m_TypeObservers[type];
			if (result != null)
			{
				return result;
			}		
			return m_EmptyList ;
		}

		//[DebuggerStepThrough()]
		private IList GetTypeObservers(object obj) => GetTypeObservers(obj.GetType());

	    //[DebuggerStepThrough()]
		private IList GetObjectObservers(object obj)
		{
			ArrayList result = (ArrayList) m_ObjectObservers[obj];
			if (result != null)
			{
				return result;
			}		
			return m_EmptyList ;			
		}

		public void AddContextObserver(IObserver observer) => m_ContextObservers.Add(observer);

	    public void AddAllTypeObserver(IObserver observer) => m_AllTypeObservers.Add(observer);

	    public void AddObserver(IObserver observer) => m_Observers.Add(observer);

	    public void AddObserver(IObserver observer, ObserverTarget observerTarget)
		{
			switch (observerTarget)
			{
				case ObserverTarget.All:
					m_Observers.Add(observer);
					break;
				case ObserverTarget.Context:
					m_ContextObservers.Add(observer);
					break;
				case ObserverTarget.Objects:
					m_AllTypeObservers.Add(observer);
					break;
				default:
					throw new NPersistException("Unknown observer target type"); // do not localize
			}
		}

		public void AddObserver(IObserver observer, Type type)
		{
			if (m_TypeObservers == null)
				m_TypeObservers = new Hashtable();

			ArrayList result = (ArrayList) m_TypeObservers[type];
			if (result == null)
			{
				result = new ArrayList();
				m_TypeObservers[type] = result;				
			}
			result.Add(observer);
		}

		public void AddObserver(IObserver observer, object obj)
		{
			ArrayList result = (ArrayList) m_ObjectObservers[obj];
			if (result == null)
			{
				result = new ArrayList();
				m_ObjectObservers[obj] = result;				
			}
			result.Add(observer);
		}

		public void AddObserver(IObserver observer, params object[] targets)
		{
			foreach (object target in targets)
			{
				if (target is Type)
				{
					AddObserver(observer, (Type) target);
				}
				else
				{
					AddObserver(observer, target);					
				}
			}
		}


		public IList GetAllObservers() => m_Observers;

	    public IList GetObservers() => m_Observers;

	    public IList GetObservers(ObserverTarget observerTarget)
		{
			switch (observerTarget)
			{
				case ObserverTarget.All:
					return m_Observers;
				case ObserverTarget.Context:
					return m_ContextObservers;
				case ObserverTarget.Objects:
					return m_AllTypeObservers;
				default:
					throw new NPersistException("Unknown observer target type"); // do not localize
			}
		}

		public IList GetObservers(Type type) => GetTypeObservers(type);

	    public IList GetObservers(object obj) => GetObjectObservers(obj);

	    protected virtual void EvaluatePropertySpecialBehavior(object obj, IPropertyMap propertyMap, PropertySpecialBehaviorType specialBehavior, IObjectManager om)
		{
			bool wrote = false;
			if (specialBehavior == PropertySpecialBehaviorType.Increase)
			{
				om.SetPropertyValue(obj, propertyMap.Name, Convert.ToInt64(om.GetPropertyValue(obj, propertyMap.Name)) + 1);
				wrote = true;
			}
			else if (specialBehavior == PropertySpecialBehaviorType.SetDateTime)
			{
				om.SetPropertyValue(obj, propertyMap.Name, DateTime.Now);
				wrote = true;
			}
			if (wrote)
			{
				om.SetNullValueStatus(obj, propertyMap.Name, false);				
				om.SetUpdatedStatus(obj, propertyMap.Name, true);				
			}
		}
	}
}