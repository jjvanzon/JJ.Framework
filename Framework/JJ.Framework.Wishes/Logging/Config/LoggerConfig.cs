using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Wishes.docs;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class LoggerConfig
    {
        public string Type { get; set; }
        public IList<string> Categories { get; set; }
        /// <inheritdoc cref="_loggerexcludedcategories" />
        public IList<string> ExcludedCategories { get; set; }
    }
}
