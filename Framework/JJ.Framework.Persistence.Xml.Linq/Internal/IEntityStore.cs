using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence.Xml.Linq.Internal
{
    internal interface IEntityStore
    {
        void Commit();
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
    }
}
