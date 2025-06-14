JJ.Framework.Common.Core
========================

General-purpose utilities with minimal dependencies.  
An extension to [JJ.Framework.Common](https://www.nuget.org/packages/JJ.Framework.Common/0.250.2204).

- `NameHelper`

    - `Name()` returns the current method name or current property name.
    - `TextOf(...)` gets the string representation of an expression.

-----


- `Flagging`

    - Sets or gets flags from bit fields (ints) and flag enums.  
    These otherwise require (hard to remember) bit operations.  
    These can help you in a moment of confusion:  

    - `HasFlag` to ask: "Is this bit or flag set?"  
    - `SetFlag` / `ClearFlag` toggles a single flag  
    - `SetFlags` / `ClearFlags` when you've got a collection of flags  

-----

- `EnvironmentHelper`

    - `EnvironmentVariableIsDefined` method: shorthand to check if an environment variable is defined with a specific key and value.

-----

- `ConfigurationHelperCore`

    - `TryGetSection` method that complements `GetSection` but now when the configuration section is not found, `null` is returned, instead of a crash.


💬 Feedback
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)