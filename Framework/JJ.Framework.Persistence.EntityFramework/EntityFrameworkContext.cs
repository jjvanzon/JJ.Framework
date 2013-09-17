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

        public override TEntity Get<TEntity>(object id)
        {
            throw new NotImplementedException();
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
            return _context.Set<TEntity>();
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
    }
}
