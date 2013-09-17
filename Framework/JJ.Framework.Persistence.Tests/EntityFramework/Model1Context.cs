using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.Tests.EntityFramework
{
    public class Model1Context : DbContext
    {
        public Model1Context(string specialConnectionString)
            : base(specialConnectionString)
        { }
    }
}
