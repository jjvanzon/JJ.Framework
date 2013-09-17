using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.NPersist
{
    public class NPersistContext : ContextBase
    {
        private Puzzle.NPersist.Framework.Context _context;

        public NPersistContext(string persistenceLocation, params Assembly[] modelAssemblies)
            : base(persistenceLocation, modelAssemblies)
        {
            _context = UnderlyingNPersistContextFactory.CreateContext(persistenceLocation, modelAssemblies);
        }

        public override EntityWrapper<TEntity> CreateEntity<TEntity>()
        {
            TEntity entity = _context.CreateObject<TEntity>();
            return CreateWrapper(entity);
        }

        public override EntityWrapper<TEntity> GetEntity<TEntity>(object id)
        {
            TEntity entity = _context.GetObjectById<TEntity>(id);
            return CreateWrapper(entity);
        }

        public override IEnumerable<EntityWrapper<TEntity>> GetEntities<TEntity>()
        {
            throw new NotImplementedException();
        }

        public override EntityWrapper<TEntity> Insert<TEntity>(TEntity entity)
        {
            _context.AttachObject(entity);
            return CreateWrapper(entity);
        }

        public override EntityWrapper<TEntity> Update<TEntity>(TEntity entity)
        {
            _context.AttachObject(entity);
            return CreateWrapper(entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            _context.DeleteObject(entity);
        }

        public override IEnumerable<EntityWrapper<TEntity>> Query<TEntity>()
        {
            throw new NotImplementedException();
        }

        public override void Commit()
        {
            _context.Commit();
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
