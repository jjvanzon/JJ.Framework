using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.EntityFramework5
{
    public class EntityFramework5Context : ContextBase
    {
        private DbContext _context;

        public EntityFramework5Context(string persistenceLocation, params Assembly[] modelAssemblies)
            : base(persistenceLocation, modelAssemblies)
        {
            _context = UnderlyingEntityFramework5ContextFactory.CreateContext(persistenceLocation, modelAssemblies);
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            return _context.Set<TEntity>();
        }

        public override TEntity Create<TEntity>()
        {
            var entity = new TEntity();
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public override void Insert<TEntity>(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            return Enumerable.Union(
                    _context.ChangeTracker.Entries<TEntity>().Select(x => x.Entity),
                    _context.Set<TEntity>()).Distinct();
        }

        /*public override IEnumerable<TEntity> Query<TEntity>()
        {
            return _context.Set<TEntity>();
        }

        public override IEnumerable<TEntity> QueryUncommitted<TEntity>()
        {
            return _context.ChangeTracker.Entries<TEntity>().Select(x => x.Entity);
        }*/

        public override void Commit()
        {
            _context.SaveChanges();
        }

        public override void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
