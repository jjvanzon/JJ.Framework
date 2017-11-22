namespace JJ.Framework.Data.Memory
{
	// ReSharper disable once UnusedTypeParameter
	public abstract class MemoryMapping<TEntity> : IMemoryMapping
	{
		public IdentityType IdentityType { get; protected set; }
		public string IdentityPropertyName { get; protected set; }

		// IMemoryMapping

		IdentityType IMemoryMapping.IdentityType => IdentityType;
		string IMemoryMapping.IdentityPropertyName => IdentityPropertyName;
	}
}
