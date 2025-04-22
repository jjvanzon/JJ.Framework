using JJ.Framework.Common.Core.docs;

namespace JJ.Framework.Common.Core
{
    /// <inheritdoc cref="_environmentvariableisdefined" />
    public static class EnvironmentHelper
    {
        /// <inheritdoc cref="_environmentvariableisdefined" />
        public static bool EnvironmentVariableIsDefined(string environmentVariableName, string environmentVariableValue)
            => String.Equals(Environment.GetEnvironmentVariable(environmentVariableName), environmentVariableValue, StringComparison.OrdinalIgnoreCase);
    }
}