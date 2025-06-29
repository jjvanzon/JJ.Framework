using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence.Legacy.Memory
{
    internal interface IMemoryMapping
    {
        IdentityType IdentityType { get; }
        string IdentityPropertyName { get; }
    }
}
