JJ.Framework.Compilation.Core
=============================

A simple wrapper for the `dotnet.exe` CLI.

To kick off compilations of `.NET` projects at runtime, this tool can be helpful for testing build-related behaviors of your code keeping it close the the logical flow of behavior of dotnet related actions.

The problem this package solves, is managing the call around `Process.Start`, kicking off `dotnet.exe`, which comes with subtle issues.

Error Handling
------------

One of the issues, is that the output of the `dotnet.exe` process indicates error or success in subtle ways that aren't trivial to interpret. If handled incorrectly it would swallow the error that you were actually trying to test or your logic will dwell into undefined behavior.

This package will throw an exception if such error occurs, so your logic can act appropriately. A future version would allow a `nothrow` option, which places the responsibility on you, the caller, to inspect the `Result` output, which offers a structured view on what happened, including error codes, output text and parameters used.

Parameterization
----------------

Another issue is parameterization of `dotnet.exe`. This package gives a strongly-typed view on those parameters, so there is less confusion about the basics that can be used with `dotnet.exe`, because they are hard-coded into the interface.

Default parameterizations ensure protection against traps that come with heavily conccurent situations, which also comes with trap doors in the dotnet CLI. These defaults are on by default (that's what default means), but you can turn these things on and off individually in a code-first matter.

Extensibility
-------------

The `Compilation.Core` package offers explicit methods and parameters for commonly used `dotnet.exe` commands. The interface also supports a flexible (structured but string-based) way to call any other command.

Alternatives
------------

As mentioned, calling `Process.Start("dotnet.exe" ...)` yourself is an alternative but comes with caveats that this library explictly solves.

There are CLI wrappers out there not specifically tailored to `dotnet.exe`, which may simplify some of the logic, but don't address the specific issues for the `.NET CLI`, which means you'll still be manually solving them, face undefined results, and not focusing as much on your behavioral (testing) logic.

`[ TODO: Add link to CLI wrapper package. ]`

There are also big MSBuild-wrapper libraries that though powerful, do not offer the simplicity that this package does.

`[ TODO: Add link to one. ]`

This is simply a lightweight in-between option that's both simple and full-proof for basic compilation and other actions you could run using `dotnet.exe` in a strongly-typed way at runtime.

Features
--------

- One __Utility__ class:
    - Single entry point `DotNet` class so you can simply call `DotNet.Build()`.
- Explicit __Commands__
    - `Restore()` | `Build()` | `Rebuild()` | `MSBuild()` | `MSRebuild()` | `InstallPackage(id, ver)` | `UninstallPackage(id)` | (`Clean` and `Test` in the future.)
- __Custom__ commands and parameters:
    - Commands and arguments not explicitly supported can still be used e.g.:
    - `DotNet.Exe("pack")`
- __Result__ object with error info, output and parameters used:
    - `Build => new DotNetResult { Suffessful, Args, Opts, OutputText, ... }`
- __Logging & Diagnostics__
    - Throws when expected. Does not swallor errors.
    - (`nothrow` option in the future.)
    - `.ToString()` with well-readable overview of the current state of options, args and result objects .
    - Well formatted debugger displays.
    - Logging actions for flexibly logging output.
    - Logging verbosity adjusts to .NET's own verbosity setting (use `DotNetOptions.Verbosity`)
    - Support for log file output and bin logs.
    - Methods for checking emptiness, filled-in-ness or defaultness of opts, args or result.
- __Options__ object:
    - For set-and-forget parameterization you can pass along any command.
    - Example:
    - `var opt = new DotNetOptions { BuildConf = "Release", Dir = "C:/MyRepo" };`
    - `Build(opt);`
    - Or:
    - `Build(new { Dir = "C:/MyRepo", BuildConf = "Release" })`
    - Or:
    - `Build(opt with { BuildConf = "Release" }`
- __Parallelism__:
    - Well-behaved under parallel load.
    - Default options for well-behaved parallel execution
    - Can be turned off/tuned to your needs.