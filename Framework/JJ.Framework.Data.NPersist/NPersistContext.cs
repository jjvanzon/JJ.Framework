﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Puzzle.NPersist.Framework;

namespace JJ.Framework.Data.NPersist
{
    public class NPersistContext : ContextBase
    {
        public Context Context { get; private set; }

        public NPersistContext(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(location, modelAssembly, mappingAssembly, dialect)
        {
            Context = OpenContext();
        }

        public override TEntity Create<TEntity>()
        {
            return Context.CreateObject<TEntity>();
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            return Context.TryGetObjectById<TEntity>(id);
        }

        public override IList<TEntity> GetAll<TEntity>()
        {
            return Context.GetObjects<TEntity>();
        }

        public override void Insert(object entity)
        {
            Context.AttachObject(entity);
        }

        public override void Update(object entity)
        {
            Context.AttachObject(entity);
        }

        public override void Delete(object entity)
        {
            Context.DeleteObject(entity);
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            return Context.Repository<TEntity>();
        }

        // Transactions

        private Context OpenContext()
        {
            Context context = UnderlyingNPersistContextFactory.CreateContext(Location, ModelAssembly, MappingAssembly);
            return context;
        }

        private void CloseContext(Context context)
        {
            context.Dispose();
        }

        public override void Commit()
        {
            Context.Commit();

            CloseContext(Context);
            Context = OpenContext();
        }

        public override void Flush()
        {
            // TODO: Is There an NPersist equivalent of an NHibernate Flush()?
        }

        public override void Rollback()
        {
            CloseContext(Context);
            Context = OpenContext();
        }

        public override void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
