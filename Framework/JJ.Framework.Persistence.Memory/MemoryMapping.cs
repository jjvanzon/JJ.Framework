using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence.Memory
{
    public abstract class MemoryMapping<TEntity> : IMemoryMapping
    {
        public IdentityType IdentityType { get; protected set; }
        public string IdentityPropertyName { get; protected set; }
    }
}
