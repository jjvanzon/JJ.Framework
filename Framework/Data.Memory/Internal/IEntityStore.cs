namespace JJ.Framework.Data.Memory.Internal
{
	internal interface IEntityStore
	{
		void Insert(object entity);
		void Delete(object entity);
	}
}
