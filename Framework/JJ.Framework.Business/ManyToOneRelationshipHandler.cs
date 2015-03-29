using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class ManyToOneRelationshipHandler<TChild, TParent>
    {
        private TChild _child;

        public ManyToOneRelationshipHandler(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            _child = child;
        }

        public void SetParent(TChild child, TParent oldParent, TParent newParent)
        {
            if (oldParent != null)
            {
                if (Contains(oldParent, _child))
                {
                    Remove(oldParent, _child);
                }
            }

            if (newParent != null)
            {
                if (!Contains(newParent, _child))
                {
                    Add(newParent, _child);
                }
            }
        }

        protected abstract bool Contains(TParent parent, TChild child);
        protected abstract void Add(TParent parent, TChild child);
        protected abstract void Remove(TParent parent, TChild child);
    }
}
