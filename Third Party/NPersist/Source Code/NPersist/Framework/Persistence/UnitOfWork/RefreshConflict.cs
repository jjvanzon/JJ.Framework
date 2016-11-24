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
using System.Text;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class RefreshConflict : ContextChild, IRefreshConflict 
	{
        public RefreshConflict()
        {
        }

        public RefreshConflict(IContext context, object obj, string propertyName, object cachedValue, object cachedOriginalValue, object freshValue)
        {
            this.Context = context;
            this.obj = obj;
            this.propertyName = propertyName;
            this.cachedValue = cachedValue;
            this.freshValue = freshValue;
        }

        private object obj;
        public virtual object Obj
        {
            get { return obj; }
            set { obj = value; }
        }

        private string propertyName;
        public virtual string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }

        private object cachedOriginalValue;
        public virtual object CachedOriginalValue
        {
            get { return cachedOriginalValue; }
            set { cachedOriginalValue = value; }
        }

        private object cachedValue;
        public virtual object CachedValue
        {
            get { return cachedValue; }
            set { cachedValue = value; }
        }

        private object freshValue;
        public virtual object FreshValue
        {
            get { return freshValue; }
            set { freshValue = value; }
        }

        public void Resolve(ConflictResolution resolution)
        {
        	IClassMap classMap = this.Context.DomainMap.MustGetClassMap(this.obj.GetType());
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(this.propertyName);

			if (propertyMap.IsCollection)
			{
				ResolveList(resolution);
			}
			else
			{
				switch (resolution)
				{
					case ConflictResolution.UseCachedValue:
						UseCachedValue();
						break;
					case ConflictResolution.UseFreshValue:
						UseFreshValue();
						break;
				}				
			}
			this.Context.UnclonedConflicts.Remove(this);
		}

		protected void ResolveList(ConflictResolution resolution)
		{
			switch (resolution)
			{
				case ConflictResolution.UseCachedValue:
					UseCachedValueList();
					break;
				case ConflictResolution.UseFreshValue:
					UseFreshValueList();
					break;
			}
		}


        protected void UseCachedValue()
        {
            this.Context.ObjectManager.SetOriginalPropertyValue(obj, propertyName, freshValue);
        }

        protected void UseFreshValue()
        {
            this.Context.ObjectManager.SetPropertyValue(obj, propertyName, freshValue);
            this.Context.ObjectManager.SetOriginalPropertyValue(obj, propertyName, freshValue);
        }


		protected void UseCachedValueList()
		{
			OverwriteOriginalList();
		}

		protected void UseFreshValueList()
		{
			OverwriteList();
			OverwriteOriginalList();
		}

        protected void OverwriteList()
        {
            bool stackMute = false;
            IList list = this.cachedValue as IList;
            IList freshList = this.freshValue as IList;

            IInterceptableList mList = list as IInterceptableList;
            if (mList != null)
            {
                stackMute = mList.MuteNotify;
                mList.MuteNotify = true;
            }
            list.Clear();

            foreach (object value in freshList)
                list.Add(value);

            if (mList != null)
            {
                mList.MuteNotify = stackMute;
            }
        }

        protected void OverwriteOriginalList()
        {
            bool stackMute = false;
            IList orgList = this.cachedOriginalValue as IList;
            IList freshList = this.freshValue as IList;

            IInterceptableList mList = orgList as IInterceptableList;
            if (mList != null)
            {
                stackMute = mList.MuteNotify;
                mList.MuteNotify = true;
            }
            orgList.Clear();

            foreach (object value in freshList)
                orgList.Add(value);

            if (mList != null)
            {
                mList.MuteNotify = stackMute;
            }
        }

    }
}
