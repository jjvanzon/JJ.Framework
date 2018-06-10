using System;
using System.Data;
using System.Diagnostics;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.EventArguments;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.BaseClasses
{
	/// <summary>
	/// Summary description for Interceptor.
	/// </summary>
	public class Interceptor : ContextChild, IInterceptor
	{
		public Interceptor()
		{
		}

		private Notification notification = Notification.Full;

	
		public Notification Notification
		{
			get => this.notification;
		    set => this.notification = value;
		}

		public virtual void NotifyPropertyGet(object obj, string propertyName)
		{
			    if (this.isDisposed) { return; }
			if (notification == Notification.Disabled) { return; }
			object value = null;
			bool cancel = false;
			NotifyPropertyGet(obj, propertyName, ref value, ref cancel);
		}

		public virtual void NotifyPropertyGet(object obj, string propertyName, ref object value, ref bool cancel)
		{
			if (this.isDisposed) { return; }
			if (notification == Notification.Disabled) { return; }
			ObjectStatus objStatus = this.Context.ObjectManager.GetObjectStatus(obj);
			IPropertyMap propertyMap = null;
			PropertyStatus propStatus = PropertyStatus.Clean;
			bool hasPropertyStatus = false;
			PropertyCancelEventArgs e = new PropertyCancelEventArgs(obj, propertyName, null, value, this.Context.ObjectManager.GetNullValueStatus(obj, propertyName));
			this.Context.EventManager.OnReadingProperty(this, e);

			//For a caching before get event, it would set the 
			//Value from cache and raise the cancel flag to return it
			value = e.Value;

			if (e.Cancel)
			{
				cancel = true;
				return;
			}
			
			if (objStatus == ObjectStatus.Deleted)
			{
				throw new DeletedObjectException("The object has been deleted!", obj, propertyName); // do not localize
			}
			else if (objStatus == ObjectStatus.UpForDeletion)
			{
				throw new DeletedObjectException("The object has been registered as up for deletion!", obj, propertyName); // do not localize
			}
			else if (objStatus == ObjectStatus.NotLoaded)
			{
				propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
				if (!(propertyMap.IsIdentity))
				{
					propStatus = this.Context.ObjectManager.GetPropertyStatus(obj, propertyName);
					hasPropertyStatus = true;
					//it would be sweet to be able to determine beforehand if this property would be part of the span 
					//that is loaded with LoadObject and only call LoadObject if that is the case....
					if (propStatus == PropertyStatus.NotLoaded) 
					{
						hasPropertyStatus = false;
						//this.Context.PersistenceEngine.LoadObject(ref obj);
						this.Context.IdentityMap.LoadObject(ref obj, true);
						if (obj == null)
						{
							throw new ObjectNotFoundException("Object not found!"); // do not localize
						}
					}
				}
			}
			if (!hasPropertyStatus)
				propStatus = this.Context.ObjectManager.GetPropertyStatus(obj, propertyName);
	
			if (propStatus == PropertyStatus.Deleted)
			{
				if (obj is IObjectHelper)
				{
					throw new DeletedObjectException("The object has been deleted!", obj, propertyName); // do not localize
				}
			}
			else if (propStatus == PropertyStatus.NotLoaded)
			{
				if (!(objStatus == ObjectStatus.UpForCreation))
				{
					if (propertyMap == null)
						propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);

					if (!propertyMap.IsCollection)
					{
						this.Context.PersistenceEngine.LoadProperty(obj, propertyName);
					}
				}
			}
			this.Context.InverseManager.NotifyPropertyGet(obj, propertyName);
		}

		public virtual void NotifyPropertySet(object obj, string propertyName, ref object value)
		{
			if (this.isDisposed) { return; }
			if (notification == Notification.Disabled) { return; }
			bool cancel = false;
			NotifyPropertySet(obj, propertyName, ref value, ref cancel);
		}

		//[DebuggerStepThrough()]
		public virtual void NotifyPropertySet(object obj, string propertyName, ref object value, ref bool cancel)
		{
			if (this.isDisposed) { return; }
			if (notification == Notification.Disabled) { return; }
			DoNotifyPropertySet(obj, propertyName, ref value, null, false, ref cancel);
		}

		//[DebuggerStepThrough()]
		public virtual void NotifyPropertySet(object obj, string propertyName, ref object value, object oldValue, ref bool cancel)
		{
			if (this.isDisposed) { return; }
			if (notification == Notification.Disabled) { return; }
			DoNotifyPropertySet(obj, propertyName, ref value, oldValue, true, ref cancel);
		}

		public virtual void NotifyReadProperty(object obj, string propertyName, ref object value)
		{
			if (this.isDisposed) { return; }
			if (notification != Notification.Full) { return; }
			PropertyEventArgs e = new PropertyEventArgs(obj, propertyName, null, value, this.Context.ObjectManager.GetNullValueStatus(obj, propertyName));
            this.Context.EventManager.OnReadProperty(this, e);
            value = e.Value;
		}

		public virtual void NotifyWroteProperty(object obj, string propertyName, object value)
		{
			if (this.isDisposed) { return; }
			if (notification != Notification.Full) { return; }
			PropertyEventArgs e = new PropertyEventArgs(obj, propertyName, value, this.Context.ObjectManager.GetPropertyValue(obj, propertyName), this.Context.ObjectManager.GetNullValueStatus(obj, propertyName));
			this.Context.EventManager.OnWroteProperty(this, e);
		}

		public virtual void NotifyWroteProperty(object obj, string propertyName, object value, object oldValue)
		{
			if (this.isDisposed) { return; }
			if (notification != Notification.Full) { return; }
			PropertyEventArgs e = new PropertyEventArgs(obj, propertyName, value, this.Context.ObjectManager.GetPropertyValue(obj, propertyName), this.Context.ObjectManager.GetNullValueStatus(obj, propertyName));
			this.Context.EventManager.OnWroteProperty(this, e);
		}

		public void NotifyInstantiatingObject(object obj)
		{
			if (this.isDisposed) { return; }
			bool cancel = false;
			NotifyInstantiatingObject(obj, ref cancel);
		}

		public void NotifyInstantiatingObject(object obj, ref bool cancel)
		{
			if (this.isDisposed) { return; }
			//this.Context.PersistenceManager.SetupObject(obj);
			this.Context.PersistenceManager.InitializeObject(obj);

			if (notification == Notification.Disabled) { return; }
			ObjectCancelEventArgs e = new ObjectCancelEventArgs(obj);
			this.Context.EventManager.OnInstantiatingObject(this, e);
			if (e.Cancel)
			{
				cancel = true;
				return;
			}
		}

		public void NotifyInstantiatedObject(object obj)
		{
			if (this.isDisposed) { return; }
			if (notification != Notification.Full) { return; }
			ObjectEventArgs e = new ObjectEventArgs(obj);
			this.Context.EventManager.OnInstantiatedObject(this, e);			
		}

		//[DebuggerStepThrough()]
		protected virtual void DoNotifyPropertySet(object obj, string propertyName, ref object value, object oldValue, bool hasOldValue, ref bool cancel)
		{
			IContext ctx = this.Context;
			IObjectManager om = ctx.ObjectManager;
			IPersistenceEngine pe = ctx.PersistenceEngine;
			PropertyCancelEventArgs e;
			if (hasOldValue)
			{
				e = new PropertyCancelEventArgs(obj, propertyName, value, oldValue, this.Context.ObjectManager.GetNullValueStatus(obj, propertyName));
			}
			else
			{
				e = new PropertyCancelEventArgs(obj, propertyName, value, this.Context.ObjectManager.GetPropertyValue(obj, propertyName), this.Context.ObjectManager.GetNullValueStatus(obj, propertyName));
			}
			this.Context.EventManager.OnWritingProperty(this, e);
			if (e.Cancel)
			{
				cancel = true;
				return;
			}
			value = e.NewValue;
			IClassMap classMap = ctx.DomainMap.MustGetClassMap(obj.GetType());
			IPropertyMap propertyMap;
			string prevId;
			string newId;
			propertyMap = classMap.MustGetPropertyMap(propertyName);

            if (propertyMap.ReferenceType != ReferenceType.None && value != null)
            {
                if (propertyMap.ReferenceType == ReferenceType.OneToMany || propertyMap.ReferenceType == ReferenceType.OneToOne)
                {
                    //parent object
                    IInterceptable ivalue = value as IInterceptable;
                    if (ivalue == null)
                    {
                        throw new NPersistException(string.Format("Object is not a NPersist managed object, do not use 'new' on Entities. (Property='{0}', Owner={1})", propertyName,obj));
                    }
                    else
                    {
						if (ivalue.GetInterceptor().Context != this.Context)
						{
							throw new NPersistException(string.Format("Object does not belong to the same context object as the property owner. (Property='{0}', Owner={1})", propertyName, obj));
						}
						ObjectStatus valueObjectStatus = om.GetObjectStatus(value);
						if (valueObjectStatus == ObjectStatus.UpForDeletion || valueObjectStatus == ObjectStatus.Deleted)
						{
							throw new DeletedObjectException(string.Format("Object has been deleted. (Object={0})", value), value);
						}
                    }

                }
                else if (propertyMap.ReferenceType == ReferenceType.ManyToOne || propertyMap.ReferenceType == ReferenceType.ManyToMany)
                {
                    IInterceptableList ivalue = value as IInterceptableList;
                    if (ivalue == null)
                    {
                        throw new NPersistException(string.Format("List is not a NPersist managed list, do not use 'new' to initialize lists, NPersist does this for you. (Property='{0}', Owner={1})", propertyName, obj));
                    }
                    else if (ivalue.Interceptable.GetInterceptor ().Context != this.Context)
                    {
                        throw new NPersistException(string.Format("List does not belong to the same context object as the property owner. (Property='{0}', Owner={1})", propertyName, obj));
                    }
                }
            }

			if (propertyMap.IsReadOnly)
			{
				//Let read-only inverse properties through
				if (!(propertyMap.ReferenceType != ReferenceType.None && propertyMap.Inverse.Length > 0 && propertyMap.NoInverseManagement == false))
				{
					//Special - if someone forgot to make their ManyOne read-only,
					//why bug them about it? (so don't add an "else" with an exception...)
					if (propertyMap.ReferenceType != ReferenceType.ManyToOne)
					{
						throw new ReadOnlyException("Property '" + classMap.Name + "." + propertyName + "' is read-only!"); // do not localize								
					}
				}
			}
			PropertyStatus propStatus = PropertyStatus.Clean;
			ObjectStatus objStatus = om.GetObjectStatus(obj);
			bool hasPropertyStatus = false;
			if (objStatus == ObjectStatus.Deleted)
			{
				throw new DeletedObjectException("The object has been deleted!", obj, propertyName); // do not localize
			}
			else if (objStatus == ObjectStatus.UpForDeletion)
			{
				throw new DeletedObjectException("The object has been registered as up for deletion!", obj, propertyName); // do not localize
			}

			this.Context.ObjectCloner.EnsureIsClonedIfEditing(obj);
			EnsureWriteConsistency(obj, propertyMap, value);

			if (objStatus == ObjectStatus.UpForCreation)
			{
			}
			else if (objStatus == ObjectStatus.Clean)
			{
				propStatus = om.GetPropertyStatus(obj, propertyName);
				if (propStatus == PropertyStatus.NotLoaded)
				{
					pe.LoadProperty(obj, propertyName);
				}
				if (!(hasOldValue))
				{
					if (!(om.ComparePropertyValues(obj, propertyName, value, om.GetPropertyValue(obj, propertyName))))
					{
						this.Context.UnitOfWork.RegisterDirty(obj);
					}
				}
			}
			else if (objStatus == ObjectStatus.NotLoaded)
			{
				propertyMap = this.Context.DomainMap.MustGetClassMap(obj.GetType()).MustGetPropertyMap(propertyName);
				if (!(propertyMap.IsIdentity))
				{
					propStatus = this.Context.ObjectManager.GetPropertyStatus(obj, propertyName);
					hasPropertyStatus = true;
					//it would be sweet to be able to determine beforehand if this property would be part of the span 
					//that is loaded with LoadObject and only call LoadObject if that is the case....
					if (propStatus == PropertyStatus.NotLoaded) 
					{
						hasPropertyStatus = false;
						//this.Context.PersistenceEngine.LoadObject(ref obj);
						this.Context.IdentityMap.LoadObject(ref obj, true);
						if (obj == null)
						{
							throw new ObjectNotFoundException("Object not found!"); // do not localize
						}
					}
					if (!hasPropertyStatus)
						propStatus = om.GetPropertyStatus(obj, propertyName);

					if (propStatus == PropertyStatus.NotLoaded)
					{
						pe.LoadProperty(obj, propertyName);
					}
				}			

				if (!(hasOldValue))
				{
					if (!(om.ComparePropertyValues(obj, propertyName, value, om.GetPropertyValue(obj, propertyName))))
					{
						this.Context.UnitOfWork.RegisterDirty(obj);
					}
				}
			}
			else if (objStatus == ObjectStatus.Dirty)
			{
				propStatus = om.GetPropertyStatus(obj, propertyName);
				if (propStatus == PropertyStatus.NotLoaded)
				{
					pe.LoadProperty(obj, propertyName);
				}
			}
			if (propertyMap.IsIdentity)
			{
				prevId = om .GetObjectIdentity(obj);
				newId = om.GetObjectIdentity(obj, propertyMap, value);
				if (prevId != newId)
				{
					ctx.IdentityMap.UpdateIdentity(obj, prevId, newId);					
				}
			}
			om.SetNullValueStatus(obj, propertyName, false);
			om.SetUpdatedStatus(obj, propertyName, true);
			if (hasOldValue)
			{
				ctx.InverseManager.NotifyPropertySet(obj, propertyName, value, oldValue);
				ctx.UnitOfWork.RegisterDirty(obj);
			}
			else
			{
				ctx.InverseManager.NotifyPropertySet(obj, propertyName, value);
			}
		}

		private void EnsureWriteConsistency(object obj, IPropertyMap propertyMap, object value)
		{
			IContext ctx = Context;
			if (ctx.WriteConsistency.Equals(ConsistencyMode.Pessimistic))
			{
				IIdentityHelper identityHelper = obj as IIdentityHelper;
				if (obj == null)
					throw new NPersistException(string.Format("Object of type {0} does not implement IIdentityHelper", obj.GetType()));

				ISourceMap sourceMap = propertyMap.ClassMap.GetSourceMap();
				if (sourceMap != null)
				{
					if (sourceMap.PersistenceType.Equals(PersistenceType.ObjectRelational) || sourceMap.PersistenceType.Equals(PersistenceType.Default))
					{
						ITransaction tx = ctx.GetTransaction(ctx.GetDataSource(sourceMap).GetConnection());
						if (tx == null)
						{
							throw new WriteConsistencyException(
								string.Format("A write consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was updated with a value outside of a transaction. This is not permitted in a context using Pessimistic WriteConsistency.",
								propertyMap.Name,
								obj.GetType(),
								ctx.ObjectManager.GetObjectIdentity(obj)),									 
								obj);
						}

						Guid txGuid = identityHelper.GetTransactionGuid();
						if (!(tx.Guid.Equals(txGuid)))
						{
							throw new WriteConsistencyException(
								string.Format("A write consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was loaded or initialized inside a transactions with Guid {3} and was now updated with a value under another transaction with Guid {4}. This is not permitted in a context using Pessimistic WriteConsistency.",
								propertyMap.Name,
								obj.GetType(),
								ctx.ObjectManager.GetObjectIdentity(obj),
								txGuid, 
								tx.Guid),
								txGuid, 
								tx.Guid, 
								obj);
						}

						if (value != null)
						{
							if (propertyMap.ReferenceType.Equals(ReferenceType.OneToMany) || propertyMap.ReferenceType.Equals(ReferenceType.OneToOne))
							{
								IIdentityHelper valueIdentityHelper = value as IIdentityHelper;
								if (valueIdentityHelper == null)
									throw new NPersistException(string.Format("Object of type {0} does not implement IIdentityHelper", value.GetType()));

								Guid valueTxGuid = valueIdentityHelper.GetTransactionGuid();
								if (!(tx.Guid.Equals(valueTxGuid)))
								{
									throw new WriteConsistencyException(
										string.Format("A write consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was loaded or initialized inside a transactions with Guid {3} and was now updated with a reference to an object that was loaded under another transaction with Guid {4}. This is not permitted in a context using Pessimistic WriteConsistency.",
										propertyMap.Name,
										obj.GetType(),
										ctx.ObjectManager.GetObjectIdentity(obj),
										tx.Guid, 
										valueTxGuid),
										tx.Guid, 
										valueTxGuid, 
										obj);
								}
							}
						}
					}
				}
			}
		}

		#region Property  IsDisposed
		
		private bool isDisposed;
		
		public bool IsDisposed => this.isDisposed;

	    #endregion

		public void Dispose() => this.isDisposed = true;
	}
}
