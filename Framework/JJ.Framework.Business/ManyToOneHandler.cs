using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class ManyToOneHandler<TParent>
    {
        public void SetParent(TParent oldParent, TParent newParent)
        {
            if (ReferenceEquals(oldParent, newParent)) return;

            if (oldParent != null)
            {
                if (Contains(oldParent))
                {
                    Remove(oldParent);
                }
            }

            if (newParent != null)
            {
                if (!Contains(newParent))
                {
                    Add(newParent);
                }
            }
        }

        protected abstract bool Contains(TParent parent);
        protected abstract void Add(TParent parent);
        protected abstract void Remove(TParent parent);
    }
}
