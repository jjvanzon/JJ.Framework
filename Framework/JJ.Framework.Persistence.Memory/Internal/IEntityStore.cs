using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence.Memory.Internal
{
    internal interface IEntityStore
    {
        void Insert(object entity);
        void Delete(object entity);
    }
}
