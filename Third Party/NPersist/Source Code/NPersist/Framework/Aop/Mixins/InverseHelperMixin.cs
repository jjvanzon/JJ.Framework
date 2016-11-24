// *
// * Copyright (C) 2008 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *


using System.Collections;
using Puzzle.NCore.Framework.Collections;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Exceptions;

namespace Puzzle.NPersist.Framework.Aop.Mixins
{
    public class InverseHelperMixin : IInverseHelper, IProxyAware
	{
		public InverseHelperMixin()
		{
		}

        private IAopProxy target = null;

        #region IProxyAware Members

        public void SetProxy(Puzzle.NAspect.Framework.IAopProxy target)
        {
            this.target = target;
        }

        #endregion

        #region IInverseHelper Members

        private Hashtable counts;
        private Hashtable txCounts;

        private Hashtable Counts
        {
            get
            {
                if (counts == null)
                    counts = new Hashtable();
                return counts;
            }
        }

        private Hashtable TxCounts
        {
            get
            {
                if (txCounts == null)
                    txCounts = new Hashtable();
                return txCounts;
            }
        }

        private Hashtable GetTxCounts(ITransaction transaction)
        {
            Hashtable txCounts = TxCounts;
            if (!txCounts.ContainsKey(transaction))
                txCounts[transaction] = new Hashtable();
            return (Hashtable)txCounts[transaction];
        }

        public bool HasCount(string propertyName)
        {
            if (counts == null)
                return false;

            return counts.ContainsKey(propertyName);
        }

        public bool HasCount(string propertyName, ITransaction transaction)
        {
            if (transaction == null)
                return HasCount(propertyName);

            if (txCounts == null)
                return false;

            Hashtable txCount = (Hashtable) txCounts[transaction];
            if (txCount == null)
                return false;

            return txCount.ContainsKey(propertyName);
        }

        //Note: We don't double check hascount here because
        //we expect all client code to do this. Perf optimisation,
        //based on how all scenarios using this would have to check
        //HasCount first.
        public int GetCount(string propertyName)
        {
            return (int)counts[propertyName];
        }

        public int GetCount(string propertyName, ITransaction transaction)
        {
            if (transaction == null)
                return GetCount(propertyName);

            return (int)((Hashtable)txCounts[transaction])[propertyName];
        }

        public void SetCount(string propertyName, int count)
        {
            Counts[propertyName] = count;
        }

        public void SetCount(string propertyName, int count, ITransaction transaction)
        {
			if (transaction == null)
			{
				SetCount(propertyName, count);
				return;
			}

            transaction.InverseHelpers[target] = this;

            GetTxCounts(transaction)[propertyName] = count;
        }

        private Hashtable lists;
        private Hashtable txLists;


        public IList GetPartiallyLoadedList(string propertyName)
        {
            if (lists == null)
                lists = new Hashtable();

            if (!lists.ContainsKey(propertyName))
                lists[propertyName] = new ArrayList();

            return (IList) lists[propertyName];
        }

        public IList GetPartiallyLoadedList(string propertyName, ITransaction transaction)
        {
            if (transaction == null)
                return GetPartiallyLoadedList(propertyName);

            if (txLists == null)
                txLists = new Hashtable();

            if (!txLists.ContainsKey(transaction))
                txLists[transaction] = new Hashtable();

            Hashtable txList = (Hashtable)txLists[transaction];

            if (!txList.ContainsKey(propertyName))
                txList[propertyName] = new ArrayList();

            transaction.InverseHelpers[target] = this;

            return (IList) txList[propertyName];
        }

        public void Clear()
        {
            counts = null;
            txCounts = null;
            lists = null;
            txLists = null;
        }

        public void Clear(ITransaction transaction)
        {
            if (transaction == null)
                Clear();

            if (txCounts != null)
            {
                if (txCounts.ContainsKey(transaction))
                {
                    txCounts.Remove(transaction);
                    if (txCounts.Count < 1)
                        txCounts = null;
                }
            }

            if (txLists != null)
            {
                if (txLists.ContainsKey(transaction))
                {
                    txLists.Remove(transaction);
                    if (txLists.Count < 1)
                        txLists = null;
                }
            }
        }

		public void CheckPartiallyLoadedList(string propertyName)
		{
			CheckPartiallyLoadedList(propertyName, null);
		}

		public void CheckPartiallyLoadedList(string propertyName, ITransaction transaction)
		{
			IList partialList = GetPartiallyLoadedList(propertyName, transaction);
			int count = GetCount(propertyName, transaction);

			if (count == partialList.Count)
			{
				IContext context = ((IInterceptable) this.target).GetInterceptor().Context;
				IObjectManager om = context.ObjectManager;

				IInterceptableList iList = om.GetPropertyValue(target, propertyName) as IInterceptableList;
				if (iList == null)
					throw new NPersistException(string.Format("Object of type {0} and identity {1} does not have an interceptable list injected in property {2}", target.GetType(), om.GetObjectIdentity(target), propertyName));

				bool stackMute = iList.MuteNotify;
				iList.MuteNotify = true;

				if (iList.Count < 1)
				{
					IList orgList = new ArrayList();
					foreach (object refObj in partialList)
					{
						iList.Add(refObj);
						orgList.Add(refObj);
					}
					iList.MuteNotify = stackMute;
					om.SetPropertyValue(target, propertyName, iList);
					om.SetOriginalPropertyValue(target, propertyName, orgList);
					om.SetNullValueStatus(target, propertyName, false);
					om.SetUpdatedStatus(target, propertyName, false);

					context.InverseManager.NotifyPropertyGet(target, propertyName);
				}
				else
					iList.MuteNotify = stackMute;
			}

		}

        #endregion

    }
}
