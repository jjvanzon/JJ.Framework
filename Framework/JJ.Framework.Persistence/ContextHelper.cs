﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Persistence;
using JJ.Framework.Configuration;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence
{
    public static class ContextHelper
    {
        /// <summary>
        /// Creates a context using the values out of the config file.
        /// A configuration example can be found in your bin directory.
        /// </summary>
        public static IContext CreateContext()
        {
            PersistenceConfiguration persistenceConfiguration = CustomConfigurationManager.GetSection<PersistenceConfiguration>();

            return ContextFactory.CreateContext(
                persistenceConfiguration.ContextType,
                persistenceConfiguration.Location,
                persistenceConfiguration.ModelAssemblies);
        }
    }
}