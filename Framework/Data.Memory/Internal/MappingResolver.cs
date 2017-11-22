using JJ.Framework.Reflection;
using System;
using System.Reflection;

namespace JJ.Framework.Data.Memory.Internal
{
	internal static class MappingResolver
	{
		/// <summary>
		/// Finds an implementation of MemoryMapping&lt;TEntity&gt;.
		/// </summary>
		public static IMemoryMapping GetMapping(Type entityType, Assembly mappingAssembly)
		{
			Type baseType = typeof(MemoryMapping<>).MakeGenericType(entityType);
			Type derivedType = mappingAssembly.GetImplementation(baseType);
			IMemoryMapping instance = (IMemoryMapping)Activator.CreateInstance(derivedType);
			return instance;
		}
	}
}