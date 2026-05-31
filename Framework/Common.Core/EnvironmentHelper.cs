namespace JJ.Framework.Common.Core
{
    /// <inheritdoc cref="_environmentvariableisdefined" />
    public static class EnvironmentHelper
    {
        /// <inheritdoc cref="_environmentvariableisdefined" />
        public static bool EnvironmentVariableIsDefined(string environmentVariableName, string environmentVariableValue)
            => String.Equals(Environment.GetEnvironmentVariable(environmentVariableName), environmentVariableValue, StringComparison.OrdinalIgnoreCase);

        /// <inheritdoc cref="_isazurepipelines" />
        public static bool IsAzurePipelines =>  EnvironmentVariableIsDefined("TF_BUILD", "True");

        /// <inheritdoc cref="_isncrunch" />
        public static bool IsNCrunch =>  EnvironmentVariableIsDefined("NCrunch", "1");
    }
}