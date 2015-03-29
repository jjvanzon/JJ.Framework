using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class OneToManyHandler<TChild>
    {
        protected abstract void SetParent(TChild child);
        protected abstract void NullifyParent(TChild child);

        public void AddChild(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            SetParent(child);
        }

        public void RemoveChild(TChild child)
        {
            if (child == null) throw new NullException(() => child);

            NullifyParent(child);
        }
    }
}
