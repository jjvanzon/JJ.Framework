JJ.Framework.Common.Core
========================

A tiny extension to [JJ.Framework.Common](https://www.nuget.org/packages/JJ.Framework.Common/0.250.2175) to complement a code freeze from 2015.

`ConfigurationHelperCore`

- `TryGetSection` method complements `ConfigurationHelper.GetSection` but now null is returned if the configuration section is not found.

`EnvironmentHelper`

- `EnvironmentVariableIsDefined` method for shorthand to check if an environment variable is defined with a specific key and value.
