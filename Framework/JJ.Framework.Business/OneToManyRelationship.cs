using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class OneToManyRelationship<TParent, TChild>
        where TChild : class
    {
        protected TParent _parent;
        private ICollection<TChild> _children;

        public OneToManyRelationship(TParent parent, ICollection<TChild> children)
        {
            if (parent == null) throw new NullException(() => parent);
            if (children == null) throw new NullException(() => children);

            _parent = parent;
            _children = children;
        }

        protected abstract void SetParent(TChild child);
        protected abstract void NullifyParent(TChild child);

        public void AddChild(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            if (_children.Contains(child)) return;

            _children.Add(child);

            SetParent(child);
        }

        public void RemoveChild(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            if (!_children.Contains(child)) return;

            _children.Remove(child);

            NullifyParent(child);
        }
    }
}
