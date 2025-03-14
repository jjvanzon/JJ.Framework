using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Core.docs;

namespace JJ.Framework.Core.Logging.Config
{
    public class LoggerConfig
    {
        public bool Active { get; set; }
        public string Type { get; set; }
        /// <inheritdoc cref="_loggerformat">
        public string Format { get; set; }
        public IList<string> Categories { get; set; }
        /// <inheritdoc cref="_loggerexcludedcategories" />
        public IList<string> ExcludedCategories { get; set; }
    }
}
