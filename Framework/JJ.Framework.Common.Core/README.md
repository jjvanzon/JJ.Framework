JJ.Framework.Common.Core
========================

A tiny extension to [JJ.Framework.Common](https://www.nuget.org/packages/JJ.Framework.Common/0.250.2204) to complement a code freeze from 2015.

- `ConfigurationHelperCore`

    - `TryGetSection` method that complements `GetSection` but now when the configuration section is not found, `null` is returned, instead of a crash.

-----

- `EnvironmentHelper`

    - `EnvironmentVariableIsDefined` method: shorthand to check if an environment variable is defined with a specific key and value.
