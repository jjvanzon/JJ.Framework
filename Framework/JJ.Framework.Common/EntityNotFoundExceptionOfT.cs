using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common
{
    public class EntityNotFoundException<TEntity> : EntityNotFoundException
    {
        public EntityNotFoundException(object id)
            : base(typeof(TEntity), id)
        { }
    }
}
