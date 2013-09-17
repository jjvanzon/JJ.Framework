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

        public override TEntity Create<TEntity>()
        {
            TEntity entity = _context.CreateObject<TEntity>();
            return entity;
        }

        public override TEntity Get<TEntity>(object id)
        {
            TEntity entity = _context.GetObjectById<TEntity>(id);
            return entity;
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            throw new NotImplementedException();
        }

        public override void Insert<TEntity>(TEntity entity)
        {
            _context.AttachObject(entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            _context.AttachObject(entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            _context.DeleteObject(entity);
        }

        public override IEnumerable<TEntity> Query<TEntity>()
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
    }
}
