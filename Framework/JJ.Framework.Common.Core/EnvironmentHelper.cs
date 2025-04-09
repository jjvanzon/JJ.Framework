namespace JJ.Framework.Common.Core
{
    public static class EnvironmentHelper
    {
        public static bool EnvironmentVariableIsDefined(string environmentVariableName, string environmentVariableValue)
            => String.Equals(Environment.GetEnvironmentVariable(environmentVariableName), environmentVariableValue, StringComparison.OrdinalIgnoreCase);
    }
}