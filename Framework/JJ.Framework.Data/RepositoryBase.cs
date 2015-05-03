using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Data
{
    public abstract class RepositoryBase<TEntity, TID> : IRepository<TEntity, TID>
        where TEntity : class, new()
    {
        protected IContext _context;

        public RepositoryBase(IContext context)
        {
            if (context == null) throw new NullException(() => context);
            _context = context;
        }

        public virtual TEntity TryGet(TID id)
        {
            return _context.TryGet<TEntity>(id);
        }

        public virtual TEntity Get(TID id)
        {
            return _context.Get<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.GetAll<TEntity>();
        }

        public virtual TEntity Create()
        {
            return _context.Create<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Delete(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        /// <summary>
        /// Sends pending statements to the data store but does not yet commit the transaction.
        /// This may fill in data store generated data you might require, such as ID's.
        /// </summary>
        public virtual void Flush()
        {
            _context.Flush();
        }

        public virtual void Commit()
        {
            _context.Commit();
        }


        public virtual void Rollback()
        {
            _context.Rollback();
        }
    }
}
