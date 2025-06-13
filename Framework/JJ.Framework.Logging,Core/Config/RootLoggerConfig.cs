using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Logging.Core.Config
{
    public class RootLoggerConfig
    {
        public IList<LoggerConfig> Loggers { get; set; } = [ ];
    }
}
