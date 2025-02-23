using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Array;
using static JJ.Framework.Configuration.CustomConfigurationManager;
using static JJ.Framework.Wishes.Common.FilledInWishes;

namespace JJ.Framework.Wishes.Logging
{
    internal class LogConfigHelper
    {
        public const bool DefaultActive = true;
        
        /// <inheritdoc cref="docs._defaultconfigsectionname" />
        private const string DefaultConfigSectionName = "jj.framework.logging";
        
        public static LogConfig GetConfigSection(string name = null)
        {
            string resolvedName = Coalesce(name, DefaultConfigSectionName);
            return GetSection<LogConfig>(resolvedName);
        }
        
        public static void CoalesceConfig(ref LogConfig config)
        {
            config = config ?? new LogConfig();
            config.Logs = config.Logs ?? Empty<LoggerElement>();
            
            for (int i = 0; i < config.Logs.Length; i++)
            {
                config.Logs[i] = config.Logs[i] ?? new LoggerElement();
            }
        }
    }
}
