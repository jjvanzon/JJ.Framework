using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public interface IEntityWrapper
    {
        IContext Context { get; set; }
        object Entity { get; set; }
    }
}
