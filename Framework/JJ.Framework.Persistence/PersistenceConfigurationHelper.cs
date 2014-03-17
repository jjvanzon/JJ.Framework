using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Persistence;
using JJ.Framework.Configuration;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence
{
    public static class PersistenceConfigurationHelper
    {
        public static PersistenceConfiguration GetPersistenceConfiguration()
        {
            return CustomConfigurationManager.GetSection<PersistenceConfiguration>();
        }
    }
}
