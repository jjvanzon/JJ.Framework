using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public class EntityWrapper<TEntity> : IEntityWrapper
    {
        public EntityWrapper(IContext context, TEntity entity)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (entity == null) throw new ArgumentNullException("entity");

            Context = context;
            Entity = entity;
        }

        public IContext Context { get; private set; }
        public TEntity Entity { get; private set; }

        IContext IEntityWrapper.Context
        {
            get { return Context; }
            set { Context = value; }
        }

        object IEntityWrapper.Entity
        {
            get { return Entity; }
            set { Entity = (TEntity)value; }
        }
    }
}
