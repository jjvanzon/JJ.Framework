using System;

namespace JJ.Framework.Wishes.Common
{
    public static class EnvironmentHelperWishes
    {
        public static bool EnvironmentVariableIsDefined(string environmentVariableName, string environmentVariableValue)
            => String.Equals(Environment.GetEnvironmentVariable(environmentVariableName), environmentVariableValue, StringComparison.OrdinalIgnoreCase);
    }
}