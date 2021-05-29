namespace JJ.Framework.Data.Xml.Linq.Internal
{
    internal interface IEntityStore
    {
        void Commit();
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
    }
}
