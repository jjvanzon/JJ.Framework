using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework;

namespace Puzzle.NPersist.Framework.Linq
{
    public class Table<T> :  ITable<T> , ITable
    {
       #region Property IsLoaded
        private bool isLoaded;
        public virtual bool IsLoaded
        {
            get => this.isLoaded;
            set => this.isLoaded = value;
        }
        #endregion

       #region Property IsDirty
        private bool isDirty = true;
        public virtual bool IsDirty
        {
            get => this.isDirty;
            set => this.isDirty = value;
        }
        #endregion

       #region Property Query
       private LinqQuery<T> query = new LinqQuery<T> ();
       public virtual LinqQuery<T> Query
       {
           get => this.query;
           set => this.query = value;
       }
       #endregion

       #region Property Converter
       private LinqToNPathConverter converter = new LinqToNPathConverter();
       public virtual LinqToNPathConverter Converter
       {
           get => this.converter;
           set => this.converter = value;
       }
       #endregion



        protected virtual void EnsureLoaded()
        {
            if (IsDirty)
            {
                if (!IsLoaded)
                {
                    NPathQuery npquery = new NPathQuery(query.ToNPath(),typeof(T));
                    
                    Converter.Parameters
                        .ForEach(param => npquery.Parameters.Add(new QueryParameter (param)));
                    
                    innerList.Clear ();
                    query.Context.GetObjectsByNPath (npquery,innerList);
                //    IsLoaded = true;
                }
                else
                {
                    NPathQuery npquery = new NPathQuery(query.ToNPath(),typeof(T));
                    List<T> oldList = innerList;
                    IList tmp = query.Context.FilterObjects (innerList,npquery);
                    List<T> newList = new List<T>();
                    foreach (T item in tmp)
                    {
                        newList.Add (item);
                    }
                    this.innerList = newList;
                }
                IsDirty = false;
            }
        }


       private List<T> innerList = new List<T>();

       public int IndexOf(T item)
       {
           EnsureLoaded();
           return innerList.IndexOf (item);
       }

       public void Insert(int index, T item)
       {
           EnsureLoaded();
           innerList.Insert (index,item);
       }

       public void RemoveAt(int index)
       {
           EnsureLoaded();
           innerList.RemoveAt(index);
       }

       public T this[int index]
       {
           get
           {
               EnsureLoaded();
               return innerList[index];
           }
           set
           {
               EnsureLoaded();
               innerList[index] = value;
           }
       }

       public void Add(T item)
       {
           EnsureLoaded();
           innerList.Add (item);
       }

       public void Clear()
       {
           EnsureLoaded();
           innerList.Clear ();
       }

       public bool Contains(T item)
       {
           EnsureLoaded();
           return innerList.Contains (item);
       }

       public void CopyTo(T[] array, int arrayIndex)
       {
           EnsureLoaded();
           innerList.CopyTo (array,arrayIndex);
       }

       public int Count
       {
           get 
           { 
               EnsureLoaded();
               return innerList.Count; 
           }
       }

       public bool IsReadOnly
       {
           get 
           { 
               EnsureLoaded();
               return false; 
           }
       }

       public bool Remove(T item)
       {
           EnsureLoaded();
           return innerList.Remove (item);
       }

       IEnumerator<T> IEnumerable<T>.GetEnumerator()
       {
           EnsureLoaded();
           return innerList.GetEnumerator ();
       }

       IEnumerator IEnumerable.GetEnumerator()
       {
           EnsureLoaded();
           return innerList.GetEnumerator ();
       }

       public ITable<T> Clone()
       {
           Table<T> clone = new Table<T>();
           
           clone.innerList.AddRange (this.innerList);
           clone.IsDirty = this.IsDirty;
           clone.IsLoaded = this.IsLoaded;
           clone.Query = this.Query.Clone();

           return clone;
       }

       #region ILinqList Members

       public void Init(IContext context,ILoadSpan loadSpan)
       {
           this.Query.Context = context;
           this.Query.LoadSpan = loadSpan;
       }

       #endregion
   }
}
