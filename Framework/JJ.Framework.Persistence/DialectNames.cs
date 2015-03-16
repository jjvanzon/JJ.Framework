using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence
{
    /// <summary>
    /// Provides some constants for different dialects,
    /// even though it is a free text and each implementation of 
    /// IContext can have use its own dialect string values.
    /// </summary>
    public class DialectNames
    {
        public const string SqlServer2008 = "SqlServer2008";
    }
}
