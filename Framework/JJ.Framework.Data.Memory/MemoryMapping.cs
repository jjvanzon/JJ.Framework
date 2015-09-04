namespace JJ.Framework.Data.Memory
{
    public abstract class MemoryMapping<TEntity> : IMemoryMapping
    {
        public IdentityType IdentityType { get; protected set; }
        public string IdentityPropertyName { get; protected set; }

        // IMemoryMapping

        IdentityType IMemoryMapping.IdentityType 
        {
            get { return this.IdentityType; } 
        }

        string IMemoryMapping.IdentityPropertyName 
        {
            get { return this.IdentityPropertyName; } 
        }
    }
}
