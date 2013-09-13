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
    public class BindableInterceptableGenericList<T> : InterceptableGenericsList<T>, IBindingList, ICancelAddNew, IRaiseItemChangedEvents
	{

        public override void RemoveAt(int index)
        {
            T item = base[index];
            base.RemoveAt(index);
            UnhookPropertyChanged(item);
            OnListChanged(ListChangedType.ItemDeleted, index);
        }


        public override void Clear()
        {
            base.Clear();
            this.OnListChanged(ListChangedType.Reset, -1);
        }

        protected override int IListAdd(object value)
        {
            int index = list.Count;
            list.Add(value);
            this.OnListChanged(ListChangedType.ItemAdded, index);
            return index;
        }


        protected override void IListInsert(int index, object value)
        {
            list.Insert(index, value);
            HookPropertyChanged((T)value);
            this.OnListChanged(ListChangedType.ItemAdded, index);
        }

        protected override void IListRemove(object value)
        {
            int index = list.IndexOf(value);

            //the item does not exist in the list
            if (index == -1)
                return;

            list.Remove(value);

            UnhookPropertyChanged((T)value);
            this.OnListChanged(ListChangedType.ItemDeleted, index);
        }

        protected override void IListItemSet(int index, object value)
        {
            list[index] = value;
            HookPropertyChanged((T)value);
            this.OnListChanged(ListChangedType.ItemChanged, index);
        }

        #region IBindingList Members

        private void OnListChanged(ListChangedType type, int index)
        {
            if (this.ListChanged != null)
            {
                this.ListChanged(this, new ListChangedEventArgs(type, index));
            }
        }

        private void OnListChanged(ListChangedEventArgs args)
        {
            if (this.ListChanged != null)
            {
                this.ListChanged(this, args);
            }
        }

        public void AddIndex(PropertyDescriptor property)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object AddNew()
        {
            T entity = list.Context.CreateObject<T>();
            this.Add(entity);
            this.addNewPos = (entity != null) ? IndexOf(entity) : -1;

            return entity;
        }

        public bool AllowEdit
        {
            get
            {
                return true;
            }
        }

        public bool AllowNew
        {
            get
            {
                return true;
            }
        }

        public bool AllowRemove
        {
            get
            {
                return true;
            }
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsSorted
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public event ListChangedEventHandler ListChanged;

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RemoveSort()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ListSortDirection SortDirection
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public PropertyDescriptor SortProperty
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool SupportsChangeNotification
        {
            get
            {
                return true;
            }
        }

        public bool SupportsSearching
        {
            get
            {
                return false;
            }
        }

        public bool SupportsSorting
        {
            get
            {
                return false;
            }

        }

        protected virtual void HookPropertyChanged(T item)
        {
            INotifyPropertyChanged notificationItem = item as INotifyPropertyChanged;
            if (notificationItem != null)
            {
                if (this.propertyChangedEventHandler == null)
                {
                    this.propertyChangedEventHandler = new PropertyChangedEventHandler(this.Child_PropertyChanged);
                }
                notificationItem.PropertyChanged += this.propertyChangedEventHandler;
            }
        }

        private int lastChangeIndex = -1;
        private void Child_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            T item;

            if (((sender == null) || (e == null)) || string.IsNullOrEmpty(e.PropertyName))
            {
                this.ResetBindings();
                return;
            }
            try
            {
                item = (T)sender;
            }
            catch (InvalidCastException)
            {
                this.ResetBindings();
                return;
            }
            int index = this.lastChangeIndex;
            if ((index >= 0) && (index < Count))
            {
                T local2 = this[index];
                if (local2.Equals(item))
                {
                    goto Label_007B;
                }
            }
            index = IndexOf(item);
            this.lastChangeIndex = index;
        Label_007B:
            if (index == -1)
            {
                this.UnhookPropertyChanged(item);
                this.ResetBindings();
            }
            else
            {
                if (this.itemTypeProperties == null)
                {
                    this.itemTypeProperties = TypeDescriptor.GetProperties(typeof(T));
                }
                PropertyDescriptor changedProperty = this.itemTypeProperties.Find(e.PropertyName, true);
                ListChangedEventArgs changeArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, index, changedProperty);
                this.OnListChanged(changeArgs);
            }
        }

        private void ResetBindings()
        {
            OnListChanged(ListChangedType.Reset, -1);
        }

        protected virtual void UnhookPropertyChanged(T item)
        {
            INotifyPropertyChanged notificationItem = item as INotifyPropertyChanged;
            if ((notificationItem != null) && (this.propertyChangedEventHandler != null))
            {
                notificationItem.PropertyChanged -= this.propertyChangedEventHandler;
            }
        }





        #endregion

        #region ICancelAddNew Members

        private int addNewPos = -1;
        public void CancelNew(int itemIndex)
        {
            T entity = base[itemIndex];
            if ((this.addNewPos >= 0) && (this.addNewPos == itemIndex))
            {
                this.RemoveItem(this.addNewPos);
                this.addNewPos = -1;
                list.Context.DeleteObject(entity);
            }
        }

        protected virtual void RemoveItem(int index)
        {
            if (!this.AllowRemove && ((this.addNewPos < 0) || (this.addNewPos != index)))
            {
                throw new NotSupportedException();
            }
            this.EndNew(this.addNewPos);
            this.UnhookPropertyChanged(this[index]);
            this.RemoveAt(index);
            this.OnListChanged(ListChangedType.ItemDeleted, index);
        }



        public void EndNew(int itemIndex)
        {
            if ((this.addNewPos >= 0) && (this.addNewPos == itemIndex))
            {
                this.addNewPos = -1;
            }
        }

        #endregion

        #region IRaiseItemChangedEvents Members

        private PropertyDescriptorCollection itemTypeProperties;
        private PropertyChangedEventHandler propertyChangedEventHandler;

        public bool RaisesItemChangedEvents
        {
            get { return true; }
        }

        #endregion
    }
}
