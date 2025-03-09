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
        public IList<CategoryConfig> Categories { get; set; }
        /// <inheritdoc cref="_loggerexcludedcategories" />
        public IList<CategoryConfig> ExcludedCategories { get; set; }
    }
}
