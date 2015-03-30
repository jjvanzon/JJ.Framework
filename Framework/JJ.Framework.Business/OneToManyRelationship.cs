using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    /// <summary>
    /// Don't forget to use _parent in your method implementations.
    /// </summary>
    public abstract class OneToManyRelationship<TParent, TChild>
        where TChild : class
    {
        protected TParent _parent;
        private ICollection<TChild> _children;

        [DebuggerHidden]
        public OneToManyRelationship(TParent parent, ICollection<TChild> children)
        {
            if (parent == null) throw new NullException(() => parent);
            if (children == null) throw new NullException(() => children);

            _parent = parent;
            _children = children;
        }

        protected abstract void SetParent(TChild child);
        protected abstract void NullifyParent(TChild child);

        public void Add(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            if (_children.Contains(child)) return;

            _children.Add(child);

            SetParent(child);
        }

        public void Remove(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            if (!_children.Contains(child)) return;

            _children.Remove(child);

            NullifyParent(child);
        }
    }
}
