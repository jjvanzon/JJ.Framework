using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class ManyToOneHandler<TChild, TParent>
    {
        public TParent Parent { get; private set; }

        protected TChild _child;

        public ManyToOneHandler(TChild child)
        {
            if (child == null) throw new NullException(() => child);
            _child = child;
        }

        public void SetParent(TParent value)
        {
            if (ReferenceEquals(Parent, value)) return;

            if (Parent != null)
            {
                if (Contains(Parent))
                {
                    Remove(Parent);
                }
            }

            Parent = value;

            if (Parent != null)
            {
                if (!Contains(Parent))
                {
                    Add(Parent);
                }
            }
        }

        protected abstract bool Contains(TParent parent);
        protected abstract void Add(TParent parent);
        protected abstract void Remove(TParent parent);
    }
}
