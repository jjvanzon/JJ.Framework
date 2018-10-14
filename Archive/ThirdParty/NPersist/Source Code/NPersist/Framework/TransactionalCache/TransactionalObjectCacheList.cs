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
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using COMAdmin;
using COMSVCSLib;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.TransactionalCache
{
	/// <summary>
	/// Summary description for TransactionalObjectCacheList.
	/// </summary>
	[ComVisible(true)]
	[Guid("071FB34B-9465-40B8-99B7-B68B66813E8D")]
	public class TransactionalObjectCacheList : IComTransactionEvents
	{
		public static Hashtable ObjectCaches = new Hashtable() ; 

		public TransactionalObjectCacheList()
		{

		}

		public IObjectCache GetObjectCache()
		{
			lock(this)
			{
				Guid txId = ContextUtil.TransactionId;

				IObjectCache cache = (IObjectCache) ObjectCaches[txId];
				if (cache == null)
				{
					if (ObjectCaches.Count < 1)
					{
						RegisterComTransactionEventsListener(); 
					}
					cache = new ObjectCache() ;
					ObjectCaches[txId] = cache;
				}
				return cache;				
			}
		}

		#region IComTransactionEvents implementation

		public void OnTransactionStart(ref COMSVCSEVENTINFO pinfo, ref Guid guidTx, ref Guid tsid, int fRoot)
		{
			//we're to late in the chain to ever get this event...
		}

		public void OnTransactionPrepare(ref COMSVCSEVENTINFO pinfo, ref Guid guidTx, int fVoteYes)
		{
			//we're not realy interested in this event			
		}

		public void OnTransactionAbort(ref COMSVCSEVENTINFO pinfo, ref Guid guidTx)
		{
			//This event is treated the same way as a commit
			OnTransactionComplete(ref pinfo, ref guidTx);
		}

		public void OnTransactionCommit(ref COMSVCSEVENTINFO pinfo, ref Guid guidTx)
		{
			//This event is treated the same way as an abort			
			OnTransactionComplete(ref pinfo, ref guidTx);
		}

		#endregion

		#region COM+ Event Registration

		public string subID = "";

		//these method comes almost unmodified from the msdn example:
		//http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dv_vstechart/html/concreatingcomperfmoncounters.asp
		public void RegisterComTransactionEventsListener()
		{
			ICatalogObject pISub, pIProp;
			ICatalogCollection pISubs, pIProps;
			long lret=0;

			ICOMAdminCatalog pICat = new COMAdminCatalog();

			pISubs = (ICatalogCollection)pICat.GetCollection("TransientSubscriptions");

			pISubs.Populate();
			pISub = (ICatalogObject)pISubs.Add();
			pISub.set_Value("Name", "Method");
			pISub.set_Value("EventCLSID", "{ECABB0C3-7F19-11D2-978E-0000F8757E2A}");
			pISub.set_Value("InterfaceID", "{683130A8-2E50-11D2-98A5-00C04F8EE1C4}");
			IntPtr thisRef = Marshal.GetIUnknownForObject(this);
			pISub.set_Value("SubscriberInterface", thisRef);
			lret = pISubs.SaveChanges();
			subID = (string)pISub.get_Value("ID");
			string strKey = (pISub.Key).ToString();
			pIProps = 
				(ICatalogCollection)pISubs.GetCollection("TransientPublisherProperties",
				strKey);
			pIProps.Populate();
			ICatalogObject pITPP = (ICatalogObject)pIProps.Add();
			pITPP.set_Value("Name", "AppID");
			pITPP.set_Value("Value", "{071FB34B-9465-40B8-99B7-B68B66813E8D}");
			lret = pIProps.SaveChanges();			
		}

		public void UnregisterComTransactionEventsListener()
		{
			ICOMAdminCatalog pICat = new COMAdminCatalog();
			ICatalogCollection pISubs = (ICatalogCollection)pICat.GetCollection("TransientSubscriptions");

			long lCount = 0;
			int i = 0;
			ICatalogObject pISub;

			pISubs.Populate();            
			lCount = pISubs.Count;
			if (lCount == 0)
			{
				return;
			}
			for (i=0; i<lCount; i++)
			{
				pISub = (ICatalogObject)pISubs.get_Item(i);

				if (subID == (string)pISub.get_Value("ID"))
				{
					pISubs.Remove(i);
					pISubs.SaveChanges();
					return;
				}
			}
		}

		#endregion

		protected void OnTransactionComplete(ref COMSVCSEVENTINFO pinfo, ref Guid guidTx)
		{
			lock (this)
			{
				IObjectCache cache = (IObjectCache) ObjectCaches[guidTx];
				if (cache != null)
				{
					ObjectCaches.Remove(guidTx);
				}
				if (ObjectCaches.Count < 1)
				{
					UnregisterComTransactionEventsListener(); 
				}				
			}

		}

	}
}
