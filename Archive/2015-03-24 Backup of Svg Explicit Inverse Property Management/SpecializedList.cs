using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public abstract class SpecializedList<T> : IList<T>
    {
        protected readonly List<T> _list = new List<T>();

        public virtual int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public virtual T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        public virtual bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get { return _list.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public virtual bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public virtual void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public virtual void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public virtual void Add(T item)
        {
            _list.Add(item);
        }

        public virtual void Clear()
        {
            _list.Count();
        }

        public virtual void AddRange(IEnumerable<T> source)
        {
            _list.AddRange(source);
        }
    }
}
