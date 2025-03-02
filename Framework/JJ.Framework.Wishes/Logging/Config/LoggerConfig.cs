using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class LoggerConfig
    {
        public string Type { get; set; }
        public IList<CategoryConfig> Categories { get; set; }
    }
}
