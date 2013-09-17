using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.EntityFramework
{
    public class EntityFrameworkContext : ContextBase
    {
        private DbContext _context;

        public EntityFrameworkContext(string persistenceLocation, params Assembly[] modelAssemblies)
            : base(persistenceLocation, modelAssemblies)
        {
            _context = UnderlyingEntityFrameworkContextFactory.CreateContext(persistenceLocation, modelAssemblies);
        }

        public override EntityWrapper<TEntity> GetEntity<TEntity>(object id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<EntityWrapper<TEntity>> GetEntities<TEntity>()
        {
            foreach (var x in _context.Set<TEntity>())
            {
                yield return new EntityWrapper<TEntity>(this, x);
            }
        }

        public override EntityWrapper<TEntity> CreateEntity<TEntity>()
        {
            var entity = new TEntity();
            _context.Set<TEntity>().Add(entity);
            return CreateWrapper(entity);
        }

        public override EntityWrapper<TEntity> Insert<TEntity>(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return CreateWrapper(entity);
        }

        public override EntityWrapper<TEntity> Update<TEntity>(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            return CreateWrapper(entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public override IEnumerable<EntityWrapper<TEntity>> Query<TEntity>()
        {
            //return _context.Set<TEntity>().Select(x => new EntityWrapper<TEntity>(this, x));
            foreach (var x in _context.Set<TEntity>())
            {
                yield return new EntityWrapper<TEntity>(this, x);
            }
        }

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

        private EntityWrapper<TEntity> CreateWrapper<TEntity>(TEntity entity)
        {
            var entityWrapper = new EntityWrapper<TEntity>(this, entity);
            return entityWrapper;
        }
    }
}
