﻿using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Persistence.Legacy.Memory.Internal
{
    internal static class MappingResolver
    {
        /// <summary>
        /// Finds an implementation of MemoryMapping&lt;TEntity&gt;.
        /// </summary>
        public static IMemoryMapping GetMapping(Type entityType, Assembly mappingAssembly)
        {
            Type baseType = typeof(MemoryMapping<>).MakeGenericType(entityType);
            Type derivedType = ReflectionHelper.GetImplementation(mappingAssembly, baseType);
            IMemoryMapping instance = (IMemoryMapping)Activator.CreateInstance(derivedType);
            return instance;
        }
    }
}