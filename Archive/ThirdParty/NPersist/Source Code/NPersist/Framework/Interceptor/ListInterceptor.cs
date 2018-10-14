// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
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
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.BaseClasses
{
	public class ListInterceptor : IListInterceptor
	{
		
		public Notification Notification
		{
			get 
            {
                IInterceptor interceptor = this.interceptable.GetInterceptor();
                if (interceptor == null)
                    return Notification.Disabled;
                return interceptor.Notification; 
            }
		}


		#region Property PROPERTYNAME
		private string propertyName;
		public virtual string PropertyName
		{
			get => propertyName;
		    set => propertyName = value;
		}
		#endregion

		#region Property INTERCEPTABLE
		private IInterceptable interceptable;
		public virtual IInterceptable Interceptable
		{
			get => interceptable;
		    set => interceptable = value;
		}
		#endregion

		#region Property MUTENOTIFY
		private bool muteNotify;
		public virtual bool MuteNotify
		{
			get => muteNotify;
		    set => muteNotify = value;
		}
		#endregion

		#region Property LIST
		private IList list;
		public virtual IList List
		{
			get => list;
		    set => list = value;
		}
		#endregion

		#region Property OldList
		private IList oldList;
		public virtual IList OldList
		{
			get => oldList;
		    set => oldList = value;
		}
		#endregion

		#region Method NotifyBefore
		protected virtual void NotifyBefore()
		{
			if (Notification == Notification.Disabled) { return; }
			if (MuteNotify)
			{
				return;
			}
			if (Interceptable != null)
			{
				if (PropertyName.Length > 0)
				{				
					bool cancel=false;
					object newList = List;

                    IInterceptor interceptor = Interceptable.GetInterceptor();
                    if (interceptor != null)
                    {
					    interceptor.NotifyPropertySet(Interceptable, PropertyName, ref newList,OldList,ref cancel);
					    if (cancel)
						    RollBack();
                    }
				}
				else
				{
					throw new NPersistException("Managed list has not been associated with a property of the holder object!"); // do not localize
				}
			}
			else
			{
				throw new NPersistException("Managed list has not been associated with a holder object!"); // do not localize
			}
		}
		#endregion

		#region Method NotifyAfter
		protected virtual void NotifyAfter()
		{
			if (Notification != Notification.Full) { return; }
			if (MuteNotify)
			{
				return;
			}
			if (Interceptable != null)
			{
				if (PropertyName.Length > 0)
				{
                    IInterceptor interceptor = this.interceptable.GetInterceptor();
                    if (interceptor != null)
    					interceptor.NotifyWroteProperty(Interceptable, PropertyName, List, OldList);
				}
				else
				{
					throw new NPersistException("Managed list has not been associated with a property of the holder object!"); // do not localize
				}
			}
			else
			{
				throw new NPersistException("Managed list has not been associated with a holder object!"); // do not localize
			}
		}
		#endregion

		//rollback the old data
		private void RollBack()
		{
			bool stackMute = MuteNotify;
			MuteNotify = true;
			this.List.Clear() ;
			foreach (object o in OldList)
				this.List.Add(o);
			MuteNotify = stackMute;
		}
	
		//called by the proxylist before executing the call to the base
		int stackLevel=0;
		public void BeforeCall()
		{
			stackLevel ++;



			if (MuteNotify)
			{
				return;
			}

			if (stackLevel == 1)
				OldList = CloneList();						
		}

		//called by the proxylist after executing the call to the base
		public void AfterCall()
		{
			stackLevel --;

			if (stackLevel > 0)
			{
				return;
			}

			if (MuteNotify)
				return;

			NotifyBefore ();
			NotifyAfter ();
			OldList = null;
			
		}

		//clones the current list
		private IList CloneList()
		{
			bool stackMute = MuteNotify;
			MuteNotify = true;
			ArrayList copy = new ArrayList();
			copy.AddRange(List) ;
			MuteNotify = stackMute;
			return copy;
		}

        public bool BeforeCount(ref int count)
        {
			if (MuteNotify)
				return false;

			if (HasCount(ref count))
				return true;
			
			EnsureLoaded();
			return false;
        }

        public void AfterCount(ref int count)
        {
        }

		public void BeforeRead()
		{
			if (MuteNotify)
				return;

			EnsureLoaded();
		}

		private bool HasCount(ref int count)
		{
			IContext context = interceptable.GetInterceptor().Context;

			PropertyStatus propStatus = context.ObjectManager.GetPropertyStatus(interceptable, propertyName);
			if (propStatus != PropertyStatus.NotLoaded)
				return false;
			
			IInverseHelper inverseHelper = interceptable as IInverseHelper;
			if (inverseHelper == null)
				return false;

			ITransaction tx = null;

			ConsistencyMode readConsistency = context.ReadConsistency;
			if (readConsistency == ConsistencyMode.Pessimistic)
			{
				IClassMap classMap = context.DomainMap.MustGetClassMap(interceptable.GetType());
				ISourceMap sourceMap = classMap.GetSourceMap();
				if (sourceMap != null)
				{
					if (sourceMap.PersistenceType.Equals(PersistenceType.ObjectRelational) || sourceMap.PersistenceType.Equals(PersistenceType.Default))
					{
						tx = context.GetTransaction(context.GetDataSource(sourceMap).GetConnection());
						if (tx == null)
							return false;
					}
				}
			}

			if (inverseHelper.HasCount(propertyName, tx))
			{
				count = inverseHelper.GetCount(propertyName, tx);
				return true;
			}
			
			return false;
		}

		public void EnsureLoaded()
		{
			if (MuteNotify)
				return;

			IContext ctx = interceptable.GetInterceptor().Context;
			IObjectManager om = ctx.ObjectManager;
			PropertyStatus propStatus = om.GetPropertyStatus(interceptable, propertyName);
			if (propStatus == PropertyStatus.NotLoaded)
			{
				ObjectStatus objStatus = om.GetObjectStatus(interceptable); 
				if (!(objStatus == ObjectStatus.UpForCreation))
				{
					bool stackMute = MuteNotify;
					MuteNotify = true;

					ctx.PersistenceEngine.LoadProperty(interceptable, propertyName);

					MuteNotify = stackMute;
				}
			}						
		}
	}
}