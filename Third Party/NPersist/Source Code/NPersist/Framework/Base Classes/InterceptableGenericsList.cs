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
using Puzzle.NPersist.Framework.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Puzzle.NPersist.Framework.BaseClasses
{
    public class InterceptableGenericsList<T> : IList<T>, IList, IInterceptableList 
	{

        protected InterceptableList list;

        public InterceptableGenericsList()
        {
            list = new InterceptableList();
            list.Interceptor.List = this;
        }


        #region IList<T> Members

        public virtual int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public new virtual T this[int index]
        {
            get
            {
                return (T)list[index];
            }
            set
            {
                IListItemSet(index, value);
            }
        }

        #endregion

        #region ICollection<T> Members

        public virtual void Add(T item)
        {
            IListAdd(item);
        }

        public virtual bool Contains(T item)
        {
            return list.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public virtual bool Remove(T item)
        {
            int oldCount = this.Count;
            IListRemove(item);

            return (oldCount != this.Count);
        }

        #endregion

        #region IEnumerable<T> Members

        public new virtual IEnumerator<T> GetEnumerator()
        {
            foreach (T item in (IEnumerable)this)
            {
                yield return item;
            }
        }

        #endregion

        #region IList Members

        

        public virtual void Clear()
        {
            list.Clear();
        }



        public bool IsFixedSize
        {
            get { return list.IsFixedSize; }
        }

        public bool IsReadOnly
        {
            get { return list.IsReadOnly; }
        }

        

        public virtual void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            list.CopyTo(array, index);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsSynchronized
        {
            get { return list.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return list.SyncRoot; }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion

        #region IInterceptableListState Members

        public IListInterceptor Interceptor
        {
            get { return list.Interceptor; }
        }

        public IInterceptable Interceptable
        {
            get
            {
                return list.Interceptable;
            }
            set
            {
                list.Interceptable = value;
            }
        }

        public string PropertyName
        {
            get
            {
                return list.PropertyName;
            }
            set
            {
                list.PropertyName = value;
            }
        }

        public bool MuteNotify
        {
            get
            {
                return list.MuteNotify;
            }
            set
            {
                list.MuteNotify = value;
            }
        }

        #endregion


        int IList.Add(object value)
        {
            return IListAdd(value);
        }

        protected virtual int IListAdd(object value)
        {
            return list.Add(value);
        }

        bool IList.Contains(object value)
        {
            return list.Contains(value);
        }

        int IList.IndexOf(object value)
        {
            return list.IndexOf(value);
        }

        void IList.Insert(int index, object value)
        {
            IListInsert(index, value);
        }

        protected virtual void IListInsert(int index, object value)
        {
            list.Insert(index, value);
        }

        void IList.Remove(object value)
        {
            IListRemove(value);
        }

        protected virtual void IListRemove(object value)
        {
            list.Remove(value);
        }

        object IList.this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                IListItemSet(index, value);
            }
        }

        protected virtual void IListItemSet(int index, object value)
        {
            list[index] = value;                        
        }

        public void Sort(IComparer<T> comparer)
        {
            WrapperComparer<T> wrapper = new WrapperComparer<T>(comparer);
            bool stackMute = list.MuteNotify;
            list.MuteNotify = true;
            list.EnsureLoaded();
            list.Sort(wrapper);
            list.MuteNotify = stackMute;
        }
    }

    public class WrapperComparer<T> : IComparer
    {
        private IComparer<T> genericComparer;
        public IComparer<T> GenericComparer
        {
            get { return genericComparer; }
            set { genericComparer = value; }
        }
    
        public WrapperComparer (IComparer<T> genericComparer)
        {
            GenericComparer = genericComparer;
        }

        public int Compare(object x, object y)
        {
            return GenericComparer.Compare ((T)x,(T)y);
        }        
    }
}
