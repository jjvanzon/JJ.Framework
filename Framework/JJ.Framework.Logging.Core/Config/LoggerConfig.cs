using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Logging.Core.docs;

namespace JJ.Framework.Logging.Core.Config
{
    public class LoggerConfig
    {
        public bool Active { get; set; }
        public string Type { get; set; } = "";
        /// <inheritdoc cref="_loggerformat" />
        public string Format { get; set; } = "";
        public IList<string> Categories { get; set; } = [ ];
        /// <inheritdoc cref="_loggerexcludedcategories" />
        public IList<string> ExcludedCategories { get; set; } = [ ];
    }
}
