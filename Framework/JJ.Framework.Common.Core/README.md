JJ.Framework.Common.Core
========================

General-purpose utilities with minimal dependencies.  
An extension to [JJ.Framework.Common.Legacy](https://www.nuget.org/packages/JJ.Framework.Common.Legacy).

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

    - `TryGetSection` method that complements `GetSection` but now when the configuration section is not found, `null` is returned, instead of a crash. (This helper avoids direct use of `System.Configuration`.)

-----

- `OverloadByName` / `NameOvl`

    - Allows overloading by parameter name, which you normally cannot do:
        ```
        MyMethod(10, arg: true);
        MyMethod(10, differentArg: true);
        ```
    - One of those methods has a hidden optional parameter:
        ```
        MyMethod(int num, bool arg);
        MyMethod(int num, bool differentArg, OverloadByName ovl = default);
        ```

After Upgrading
===============

Links to legacy dependencies may have changed. If you experience problems, these things might help:

#### Option `1`
- Do nothing. Everything works.
#### Option `2`
- Use the [`JJ.Framework.Common.Legacy`](https://www.nuget.org/packages/JJ.Framework.Common.Legacy) namespace where you currently use [`JJ.Framework.Common`](https://www.nuget.org/packages/JJ.Framework.Common/0.250.3184).
#### Option `3`
- Install [`JJ.Framework.Common`](https://www.nuget.org/packages/JJ.Framework.Common/0.250.3184) explicitly. You may need a downgrade to a `0.*` version.

Release Notes
-------------

|       |                                         |   |
|-------|-----------------------------------------|---|
| `3.7` | __Clash of the Booleans__               | `OverloadByName` helper for an optional parameter trick to simulate overloading by name, not normally possible in C#.


💬 Feedback
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)