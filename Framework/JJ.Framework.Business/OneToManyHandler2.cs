using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class OneToManyHandler2<TParent, TChild>
        where TParent : class
        where TChild : class
    {
        protected abstract TParent OnGetParent(TChild child);
        protected abstract void OnSetParent(TChild child, TParent parent);
        protected abstract void OnAddChild(TParent parent, TChild child);
        protected abstract void OnRemoveChild(TParent parent, TChild child);
        protected abstract bool OnContainsChild(TParent parent, TChild child);
    
        /// <summary>
        /// Set the child's parent and automatically manages the inverse relationship
        /// between the parent and its children.
        /// </summary>
        /// <param name="oldParent">nullable</param>
        /// <param name="newParent">nullable</param>
        public void SetParent(TChild child, TParent oldParent, TParent newParent)
        {
            if (child == null) throw new NullException(() => child);

            if (ReferenceEquals(oldParent, newParent)) return;

            if (oldParent != null)
            {
                if (OnContainsChild(oldParent, child))
                {
                    OnRemoveChild(oldParent, child);
                }
            }

            OnSetParent(child, newParent);

            if (newParent != null)
            {
                if (!OnContainsChild(newParent, child))
                {
                    OnAddChild(newParent, child);
                }
            }
        }

        /// <summary>
        /// Adds the child to the parent and automatically manages the inverse relationship
        /// between the child and the parent.
        /// </summary>
        public void AddChild(TParent parent, TChild child)
        {
            if (parent == null) throw new NullException(() => parent);
            if (child == null) throw new NullException(() => child);

            if (OnContainsChild(parent, child)) return;

            TParent originalParent = OnGetParent(child);
            if (originalParent != null)
            {
                OnRemoveChild(originalParent, child);
                OnSetParent(child, null);
            }

            OnAddChild(parent, child);
            OnSetParent(child, parent);
        }

        /// <summary>
        /// Removes the child from the parent and automatically manages the inverse relationship
        /// between the child and the parent.
        /// </summary>
        public void RemoveChild(TParent parent, TChild child)
        {
            if (parent == null) throw new NullException(() => parent);
            if (child == null) throw new NullException(() => child);

            TParent originalParent = OnGetParent(child);
            if (originalParent != null)
            {
                OnRemoveChild(originalParent, child);
                OnSetParent(child, (TParent)null);
            }
        }
    }
}
