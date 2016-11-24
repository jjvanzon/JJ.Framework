//// *
//// * Copyright (C) 2005 Roger Alsing
//// *
//// * This library is free software; you can redistribute it and/or modify it
//// * under the terms of the GNU Lesser General Public License 2.1 or later, as
//// * published by the Free Software Foundation. See the included license.txt
//// * or http://www.gnu.org/copyleft/lesser.html for details.
//// *
//// *
//using System.Collections;
//using MatsSoft.NPersist.Framework;
//
//namespace MatsSoft.NPersist.Framework.Proxy
//{
//	public class ListInterceptor : IListInterceptor
//	{
//		#region Property PROPERTYNAME
//		private string propertyName;
//		public virtual string PropertyName
//		{
//			get
//			{
//				return propertyName;
//			}
//			set
//			{
//				propertyName = value;
//			}
//		}
//		#endregion
//
//		#region Property INTERCEPTABLE
//		private IInterceptable interceptable;
//		public virtual IInterceptable Interceptable
//		{
//			get
//			{
//				return interceptable;
//			}
//			set
//			{
//				interceptable = value;
//			}
//		}
//		#endregion
//
//		#region Property MUTENOTIFY
//		private bool muteNotify;
//		public virtual bool MuteNotify
//		{
//			get
//			{
//				return muteNotify;
//			}
//			set
//			{
//				muteNotify = value;
//			}
//		}
//		#endregion
//
//		#region Property LIST
//		private IList list;
//		public virtual IList List
//		{
//			get
//			{
//				return list;
//			}
//			set
//			{
//				list = value;
//			}
//		}
//		#endregion
//
//		#region Property OldList
//		private IList oldList;
//		public virtual IList OldList
//		{
//			get
//			{
//				return oldList;
//			}
//			set
//			{
//				oldList = value;
//			}
//		}
//		#endregion
//
//		#region Method NotifyBefore
//		protected virtual void NotifyBefore()
//		{
//			if (MuteNotify)
//			{
//				return;
//			}
//			if (Interceptable != null)
//			{
//				if (PropertyName.Length > 0)
//				{				
//					bool cancel=false;
//					object newList = CloneList();
//					Interceptable.GetInterceptor().NotifyPropertySet(Interceptable, PropertyName, ref newList,OldList,ref cancel);
//					if (cancel)
//						RollBack();
//				}
//				else
//				{
//					throw new NPersistException("Managed list has not been associated with a property of the holder object!");
//				}
//			}
//			else
//			{
//				throw new NPersistException("Managed list has not been associated with a holder object!");
//			}
//		}
//		#endregion
//
//		#region Method NotifyAfter
//		protected virtual void NotifyAfter()
//		{
//			if (MuteNotify)
//			{
//				return;
//			}
//			if (Interceptable != null)
//			{
//				if (PropertyName.Length > 0)
//				{
//					Interceptable.GetInterceptor().NotifyAfterPropertySet(Interceptable, PropertyName, List, OldList);
//				}
//				else
//				{
//					throw new NPersistException("Managed list has not been associated with a property of the holder object!");
//				}
//			}
//			else
//			{
//				throw new NPersistException("Managed list has not been associated with a holder object!");
//			}
//		}
//		#endregion
//
//		//rollback the old data
//		private void RollBack()
//		{
//			bool oldMuteNotify = MuteNotify;
//			MuteNotify = true;
//			this.List.Clear() ;
//			foreach (object o in OldList)
//				this.List.Add(o);
//			MuteNotify = oldMuteNotify;
//		}
//	
//		//called by the proxylist before executing the call to the base
//		public void BeforeCall()
//		{
//			if (MuteNotify)
//				return;
//
//			OldList = CloneList();		
//		}
//
//		//called by the proxylist after executing the call to the base
//		public void AfterCall()
//		{
//			if (MuteNotify)
//				return;
//
//			NotifyBefore ();
//			NotifyAfter ();
//			OldList = null;
//		}
//
//		//clones the current list
//		private IList CloneList()
//		{
//			ArrayList copy = new ArrayList();
//			copy.AddRange(List) ;
//			return copy;
//		}
//	}
//
//	public interface IListInterceptor
//	{
//		void BeforeCall();
//		void AfterCall();
//
//		string PropertyName 
//		{
//			get;
//			set;
//		}
//
//		IInterceptable Interceptable 
//		{
//			get;
//			set;
//		}
//
//		bool MuteNotify
//		{
//			get;
//			set;
//		}
//
//		IList List
//		{
//			get;
//			set;
//		}
//
//	}
//
//	public interface IInterceptableList
//	{
//		void SetInterceptor(IListInterceptor value);
//
//		IListInterceptor GetInterceptor();
//
//
//		IInterceptable Interceptable
//		{
//			get;
//			set;
//		}
//
//		string PropertyName
//		{
//			get;
//			set;
//		}
//
//		bool MuteNotify
//		{
//			get;
//			set;
//		}
//	}
//}