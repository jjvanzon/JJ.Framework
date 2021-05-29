namespace JJ.Framework.Data.Xml.Internal
{
    internal interface IEntityStore
    {
        void Commit();
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
    }
}
