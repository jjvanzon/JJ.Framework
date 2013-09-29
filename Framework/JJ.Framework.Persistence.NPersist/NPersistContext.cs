using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Puzzle.NPersist.Framework;

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
            return _context.CreateObject<TEntity>();
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            return _context.TryGetObjectById<TEntity>(id);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            return _context.GetObjects<TEntity>();
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
            return _context.Repository<TEntity>();
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

        /*public override IEnumerable<TEntity> QueryUncommitted<TEntity>()
        {
            throw new NotImplementedException();
        }*/
    }
}
