using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public interface IPersistenceSettings
    {
        string PersistenceLocation { get; }
        string PersistenceContextType { get; }
        string PersistenceModelAssembly { get; }
        string PersistenceModelAssembly2 { get; }
    }
}
