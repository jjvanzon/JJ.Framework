using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence
{
    public abstract class RepositoryBase<TEntity, TID> : IRepository<TEntity, TID>
        where TEntity : class, new()
    {
        protected IContext _context;

        public RepositoryBase(IContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public TEntity TryGet(TID id)
        {
            return _context.TryGet<TEntity>(id);
        }

        public TEntity Get(TID id)
        {
            return _context.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.GetAll<TEntity>();
        }

        public TEntity Create()
        {
            return _context.Create<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _context.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        /// <summary>
        /// Sends pending statements to the data store but does not yet commit the transaction.
        /// This may fill in data store generated data you might require, such as ID's.
        /// </summary>
        public void Flush()
        {
            _context.Flush();
        }

        public void Commit()
        {
            _context.Commit();
        }
    }
}
