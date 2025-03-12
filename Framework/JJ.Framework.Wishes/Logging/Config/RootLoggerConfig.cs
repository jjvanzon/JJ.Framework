using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Wishes.Logging.Config
{
    public class RootLoggerConfig
    {
        public bool Active { get; set; }
        public IList<LoggerConfig> Loggers { get; set; }
    }
}
