JJ.Framework.Compilation.Core
=============================

`[ Preview ]`

A simple wrapper for the `dotnet.exe` CLI.

To kick off compilations of `.NET` projects at runtime, this tool can be helpful for testing MSBuild-related behaviors of your code, keeping it close the the logical flow of behavior of dotnet related actions.

The problem this package solves, is managing the call around `Process.Start`, kicking off `dotnet.exe`, which comes with subtle issues.

Error Handling
--------------

One of the issues is that the output of the `dotnet.exe` process indicates error or success in subtle ways, that are not obvious. If handled incorrectly it would swallow the error that you were actually trying to test, or your logic will dwell into undefined behavior.

This package will throw an exception if such error occurs, so your logic can act appropriately. A future version would allow a `nothrow` option, which places the responsibility on you, the caller, to inspect the `Result` output, which offers a structured view on what happened, including error codes, output text and parameters used.

Parameterization
----------------

Another issue is parameterization of `dotnet.exe`. This package gives a strongly-typed view on those parameters, so there is less confusion about the basics that can be used with `dotnet.exe`, because they are hard-coded into the interface.

Default parameterizations ensure protection against traps that come with heavily conccurent situations, that come with the dotnet CLI. These defaults are *on* by default (that's what default means), but you can turn them on and off individually in the code.

Extensibility
-------------

The `Compilation.Core` package offers explicit methods and parameters for commonly used `dotnet.exe` commands. The interface also supports a flexible (structured but string-based) way to call any other command.

Alternatives
------------

As mentioned, calling `Process.Start("dotnet.exe" ...)` yourself is an alternative but comes with caveats that this library explictly solves.

There are CLI wrappers out there not specifically tailored to `dotnet.exe`, which may simplify some of the logic, but don't address the specific issues for the `.NET CLI`, which means you'll still be manually solving them, face undefined results, and not focusing as much on your behavioral (testing) logic.

There are also big MSBuild-wrapper libraries that though powerful, do not offer the simplicity that this package does.

This is simply a lightweight in-between option that's both simple and full-proof for basic compilation and other actions you could run using `dotnet.exe` in a strongly-typed way at runtime.

Features
--------

- One __Utility__ class:
    - Single entry point `DotNet` class so you can simply call `DotNet.Build()`.
- Explicit __Commands__
    - `Restore()` | `Build()` | `Rebuild()` | `MSBuild()` | `MSRebuild()`  
    - `InstallPackage(id, ver)` | `UninstallPackage(id)` | (`Clean` and `Test` in the future.)
- __Custom__ commands and parameters:
    - Ones not explicitly supported can still be used e.g.:
    - `DotNet.Exe("pack")`
- __Result__ object with error info, output and parameters:
    - `Build => new DotNetResult { Suffessful, Args, Opts, OutputText, ... }`
- __Logging & Diagnostics__
    - *Throws* when expected. Does not swallow errors.
    - (`nothrow` option in the future.)
    - `.ToString()` provides well-readable overview of the current state of options, args and result.
    - Well formatted debugger displays.
    - Logging actions for flexibly logging output.
    - Logging verbosity adjusts to .NET's own verbosity.
    - Support for *log file* output and *bin logs*.
    - Methods for checking emptiness, filled-in-ness or defaultness of opts, args and results.
- __Options__ object:
    - For parameterization that might not vary much in your logic, you can pass along any command.
    - Examples:
    - `Build(new { Dir = "C:/MyRepo", BuildConf = "Release" })`
    - `var opt = new DotNetOptions { BuildConf = "Release", Dir = "C:/MyRepo" };`  
      `Build(opt);`
    - `Build(opt with { BuildConf = "Release" }`
- __Parallelism__:
    - Well-behaved under parallel loads.
    - Default options for well-behaved parallel execution.
    - Can be turned off/tuned as needed.

Pre-Release
-----------

I'm releasing this prematurely. I almost never do this. I was going for fully tested, and fully worked out, but there are things that have been bogging me down.

AI-generated tests had been weighing down on me, because I had to redo them, without the courage to throw away any existing tests.

Then `dotnet.exe` experienced *hanging* behavior for the 2nd time during this project and after that I had basically had it with it.

This tool is good. But the polish is currently missing. I don't want to withhold it from anyone that could use it.

But I'm pretty much done with it right now. It doesn't seem to be anyone's priority to keep `dotnet.exe` working reliably, performant, under concurrent load. Forced updates might come with regressions and are getting harder and harder to stop. It's been capable of good highly concurrent performance, at some points in time, only to regress again without warning. And this whole project is based on that premise, so I'm leaving it at this. Sorry for the rant. I don't usually do that in a package README. I'm off to focus on other things now.


Planned Features
----------------

These features were planned for the final release, before this project was pushed into perpetual pre-release state:

- `nothrow` option
- Input sanitization / validation  
  (though things really just boil down to raw text command lines anyway.)
- Extra commands: Clean, Test.
- Diagnostics texts fine-tuning:
- Some newer options are not always currently displayed, such as bin log and log file paths.
- Logging and diagnostics may not be fully covered by unit tests.
- Diagnostics texts usually look good, but there may be edge cases in which they do not.


Release Notes
-------------

#### `2026-06-22` | `4.7` : __Preview Release__

- Brand new dotnet.exe CLI wrapper.
- Run compilations and other dotnet actions programmatically at runtime.
- Preview release. Works in general. More coverage derised. More features desired.


💬 Feedback
============

Questions or found an issues? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)