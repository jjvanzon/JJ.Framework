using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class OneToManyHandler<TChild>
        where TChild : class
    {
        protected abstract void OnSetParent(TChild child);

        public void AddChild(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            OnSetParent(child);
        }

        public void RemoveChild(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            OnSetParent(null);
        }
    }
}
