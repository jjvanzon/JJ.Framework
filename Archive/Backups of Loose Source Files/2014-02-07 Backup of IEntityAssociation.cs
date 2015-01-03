using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    /// <summary>
    /// Implement this interface so that the repository factory can find the repository that is associated with the entity.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityAssociation<TEntity>
    { }
}
