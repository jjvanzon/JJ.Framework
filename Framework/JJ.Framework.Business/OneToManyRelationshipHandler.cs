using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Business
{
    public abstract class OneToManyRelationshipHandler<TParent, TChild>
    {
        public abstract void SetParent(TChild child, TParent parent);
    }
}
