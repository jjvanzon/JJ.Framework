using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Exceptions
{
    public class NotFoundException<TEntity> : NotFoundException
    {
        public NotFoundException(object key)
            : base(typeof(TEntity), key)
        { }
    }
}
