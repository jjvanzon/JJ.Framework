﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence.Memory
{
    public interface IMemoryMapping
    {
        IdentityType IdentityType { get; }
        string IdentityPropertyName { get; }
    }
}