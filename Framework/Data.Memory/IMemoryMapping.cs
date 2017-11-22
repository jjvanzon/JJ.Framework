namespace JJ.Framework.Data.Memory
{
	internal interface IMemoryMapping
	{
		IdentityType IdentityType { get; }
		string IdentityPropertyName { get; }
	}
}
