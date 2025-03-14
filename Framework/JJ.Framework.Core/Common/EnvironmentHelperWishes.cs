using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Core.Common
{
    public static class EnvironmentHelperWishes
    {
        public static bool EnvironmentVariableIsDefined(string environmentVariableName, string environmentVariableValue)
            => String.Equals(Environment.GetEnvironmentVariable(environmentVariableName), environmentVariableValue, StringComparison.OrdinalIgnoreCase);
    }
}