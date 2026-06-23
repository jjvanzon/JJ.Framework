🔩 JJ.Framework
================

__📔 Contents__

- [📢 Introduction](#-introduction)
- [🏋️ Stability](#️-stability)
- [🏡 In-House](#-in-house)
- [🏛️ History](#️-history)
- [🍱 Modularization](#-modularization)
- [💁 Platform Compatibility](#-platform-compatibility)
- [📋 Release Notes](#-release-notes)
- [💬 Feedback](#-feedback)


📢 Introduction
----------------

`JJ.Framework` are extensions of the `.NET Framework`: the nuts, bolts and screws of software development: *reusable components*. Some of which might be expected to be there in `.NET`, but seem to be missing there.

`JJ.Framework` contains reusable code, that was produced along with real-life applications.


🏋️ Stability
-------------

No software is bug free, but extra effort was made, testing the `JJ.Framework` components, that were published to [NuGet](https://www.nuget.org/profiles/jjvanzon) which includes automated testing.

The ones not on NuGet are available as a sneek peek in [JJs-Pre-Release-Package-Feed](https://dev.azure.com/jjvanzon/JJs-Software/_packaging?_a=feed&feed=JJs-Pre-Release-Package-Feed). But those may be used with caution, because they may not be tested that well. Those may need some more unit testing and could still be a bug or two in it.


🏡 In-House
------------

`JJ.Framework` was made in the spirit of: small things: develop your own, instead of importing a huge framework.

`JJ.Framework` components are compact: a couple of kilobytes each.

Developed *in-house* so that it could be adapted and extended as needed. It did not have to be complete, because then we would just extend it.

If a bug was found in the development of an app, we could just correct the `JJ.Framework` as needed and release a stable app.

Of course, this 'in-house development' argument does not apply, when other people use it. But I think these extensions could be of use to others too.


🏛️ History
-----------

Any reusable code independent of a particular business domain, was moved to this `JJ.Framework`, for reuse. The reusable code was gathered up between 2010 and 2026. It was a hobby project. But something similar to this framework, was also developed professionally in a team of 7 of which I was the technical lead at the time.


🍱 Modularization
------------------

`JJ.Framework` tends to have a separate assembly for each part of the `.NET Framework` that it extends. Separation may be found between technical aspects. That may allow being specific, on which parts of `.NET` an application becomes dependent.

`JJ.Framework` also likes to decouple platform-specific implementation details and hide them behind generalized interfaces.


💁 Platform Compatibility
--------------------------

That grip on dependency, was once a good plan for platform compatibility. Some of `JJ.Framework` is still based on `.NET 4.6.1` trying to keep it compatible with `Mono`. Around 2015 `JJ.Framework` was tested to be reasonably compatible with `Mono` and by extension `Android`, `iOS` and `Windows Phone`. This was before newer technology like `.NET Standard` and `.NET 5 +` emerged, which could make platform-compatibility a bit more doable. For this reason, some of the `JJ.Framework` is currently being ported to a newer `.NET`, but this is still in progress.


📋 Release Notes
-----------------

#### `2025-03-31` | `1.9` : __Build.csproj__

- Internal tooling
- Triggers initialization at start of [`JJ.Framework`](https://github.com/jjvanzon/JJ.Framework/tree/main) solution build.

#### `2025-06-14` | `2.5` : __Existence.Core__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- Initial release

#### `2025-06-24` | `2.6` : __Flags__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- `spaceMatters` flags everywhere 
- `caseMatters` replaced `ignoreCase`  
- `StringBulder`/`string` more combos possible  
- `x.In(a, b, c)` extension favored over static `In(x, a, b, c)`  

#### `2025-07-02` | `2.7`/`0.250` : __Legacy Lineage__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- [`JJ.Framework.Reflection.Legacy`](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy)
- Separate `Legacy` version lineages 
- For more stable package updates.
- Expanded IntelliSense docs.

#### `2025-07-21` | `2.8`/`0.250` : __Trimmable Libs__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- [`JJ.Framework.Reflection.Legacy`](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy)
- Compatibility with AOT "Ahead-Of-Time" native compilation, code trimming and single-executable, self-contained apps

#### `2026-01-25` | `2.9` : __zeroMatters__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- Flag when you consider `0` meaningful (not nully)

#### `2026-01-27` | `3.0`/`0.250` : __.NET 10__

- Upgraded with explicit support for `.NET 10`

#### `2026-01-28` | `3.1` : __Less Prios__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- Simplify overload picking removing some `[Prio]` attributes
- Sacrifices direct use of keywords e.g. `Coalesce(null, "Hallo")`; not a real use case anyway.

#### `2026-01-30` | `3.2`/`0.250` : __Leading Flags - Coalesce__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- [`JJ.Framework.Reflection.Legacy`](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy)
- Flags at the beginning of the parameter list, now don't come with a performance penalty.

#### `2026-01-31` | `3.3` : __Leading Flags - Contains__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- More notation options for flags for the `Contains` method

#### `2026-02-01` | `3.4` : __Leading Flags - FilledIn__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- Support flags in front for the `FilledIn` method

#### `2026-02-17` | `3.7` : __Clash of the Booleans__

- [`JJ.Framework.Existence.Core`](https://www.nuget.org/packages/JJ.Framework.Existence.Core)
- Leading flags for `Has`/`Is`/`In`/`IsNully` (supplements trailing flags)
- Improved `Coalesce` resolution and performance for 4+ values and collections.
- Added overloads for reduced clashes between `bool` flags and value lists.
- Various non-critical renames for clarity and modularity.
- [`JJ.Framework.Common.Core`](https://www.nuget.org/packages/JJ.Framework.Common.Core)
- `OverloadByName` helper for an optional parameter trick to simulate overloading by name, not normally possible in C#.

#### `2026-02-23` | `3.8`/`0.250` __Business.Legacy__ 

- [`JJ.Framework.Business.Legacy`](https://www.nuget.org/packages/JJ.Framework.Business.Legacy)
- Release of historic version. Full test coverage. Features:
- `EntityStatusManager` and `GetListIsDirty`:
- Framework-agnostic `New`/`Deleted`/`Dirty` flag container.
- `ISideEffect` for keeping business logic units separated.
- Bug fix: Entity status `New` and `Deleted` were accidentally stored as `Dirty`.

#### `2026-02-26` | `3.9`/`0.250` : __IO.Legacy__

- [`JJ.Framework.IO.Legacy`](https://www.nuget.org/packages/JJ.Framework.IO.Legacy)
- Full test coverage, and member docs.
- Release of historic version `0.250`.
- Features:
- `CsvReader`: simple streaming CSV reader supporting quoted fields and escaped double-quotes (`""`).
- `StreamHelper`: convenience conversions between `Stream`, `byte[]` and `string`
- `ReadStruct`/`WriteStruct`: methods for simple reading and writing structs to streams.
- Bug fix: `CsvReader` preserves a trailing escaped quotes
- Bug fix: `CsvReader` solved crash over trailing new line

#### `2026-03-13` | `4.0`/`0.250` : __Reflection.Legacy Re-Release__

- __2018__ variant of `ReflectionCacheLegacy` moved from 
- [`Reflection.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Reflection.Core) to 
- [`Reflection.Legacy`](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy) with test coverage.
- Trimming/AOT compatiblity.
- Auto-run trim test 
- upon build
- and inside NCrunch.

#### `2026-03-15` | `4.1`/`0.251` : __Validation.Legacy__

- [`JJ.Framework.Validation.Legacy`](https://www.nuget.org/packages/JJ.Framework.Validation.Legacy)
- Historic version + full test coverage / IntelliSense docs / code trimming / native AOT support
- .NET `10`, `9`, `8`, `7`, `6`, `5`, `4.6.1` / .NET Standard `2.0`, `2.1`
- `FluentValidator` syntax:  
  `For(() => player.TotalScore, "Total Score").Min(0).Max(100);`
- `NotNull`, `NotNullOrWhiteSpace`, `In`, `Is`, `IsNot`, `NotZero`, `Above`, `Min`, `Max`, `NotInteger`, `IsEnumValue`
- `IValidator` / `ValidatorBase` members:  
  `IsValid` (boo), `ValidationMessages`, `Verify()` (throws)
- Sub-validators and message prefixes:  
  `"Address: Street is required."`
- Localization: English (`en-US`) and Dutch (`nl-NL`)

#### `2026-04-04` | `4.4`/`0.252` : __PlatformCompatibility.Core Initial__ , __Validation.Legacy Docs__

- [`JJ.Framework.PlatformCompatibility.Core`](https://www.nuget.org/packages/JJ.Framework.PlatformCompatibility.Core)
- Run new code on older .NETs
- Shims for argument checks, language features, nullability, trimming/AOT, threading and hash codes
- Full test coverage and member docs
- [`JJ.Framework.Validation.Legacy`](https://www.nuget.org/packages/JJ.Framework.Validation.Legacy)
- More IntelliSense popups
- Reworked README

#### `2026-04-08` | `4.5`/`0.253` : __Math Legacy__ 

- [`JJ.Framework.Mathematics.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Mathematics)
- Integer-based `Pow` and `Log`, `GetRandomItem` and `Randomizer.GetInt32`, number base converter.
- 100% test coverage, compatibility with Code Trimming and AOT / native compilation, and a whole spread of .NET versions, and IntelliSense doc everywhere.
- Fix: `Pow` and `Log` edge-cases
- Fix: Removed dependency on [JJ.Framework.Reflection.Legacy](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy)
- [`JJ.Framework.Testing.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Testing.Core)
- Removed lambda from delta-based `AreEqual` (trim-friendly)
- [`JJ.Framework.Testing.Core.MSTestless`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Testing.Core.MSTestless)
- Added stubs for data-driven tests.
- Improved Testing Architecture

#### `2026-04-25` | `4.6`/`0.254` : StringResources Legacy

*+ Integrity Checker + Assert.Throws Syntax*

- [`JJ.Framework.StringResources.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Presentation.Resources)
- `2015`: Limited set of reusable string resources
- `2020`: Reusable tester verifying integrity
- `2026`: Extensions:
- Placeholder verification
- Resource and formatter classes
- Static and instance members
- Free to chose fallback culture
- Optional trace logging
- Customization options
- Wide .NET version compatibility, Trimming/AOT support
- IntelliSense docs, 100% test coverage
- [`JJ.Framework.Testing.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Testing.Core)
- `Throws` methods syntax shorter

#### `2026-06-22` | `4.7`/`0.255` : __Compilation.Core Preview__

*+ Various Fixes*

- [`JJ.Framework.Compilation.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Compilation.Core)
- Brand new dotnet.exe CLI wrapper. Run compilations and other dotnet actions programmatically at runtime.
- Preview release. Works in general. More coverage desired. More features desired.
- [`JJ.Framework.Configuration.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Configuration.Core)
- Auto-copy config files from proj to bin as classic System.Configuration did for you.
- [`JJ.Framework.Configuration.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Configuration)
- Prevent leaking System.Configuration.ConfigurationManager reference transiently to avoid clashes with older .NET versions.
- [`JJ.Framework.Testing.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Testing.Core)
- Show tested argument expression more often, even when a custom message provided, which would formerly override it.
- Complete test suite against regression.
- TestRunner parallel by default but respect [DoNotParallelize] attribute. Race conditions mitigated.
- Throws methods now return Exception in case they need further inspection.
- [`JJ.Framework.Exceptions.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Exceptions.Core)
- ThrowIf method for guard statements to assert any condition.
- Overload added for chainable NotNull assertion method.
- [`JJ.Framework.Reflection.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Reflection.Core)
- Fix DynamicallyAccessedMembers annotation for code trimming on AccessorCore's target object auto-instantiation (AllCtors instead of just PublicCtors).
- Add Assembly-related overloads.
- [`JJ.Framework.PlatformCompatibility.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/PlatformCompatibility.Core)
- Fix Lock shim that was accidentally not thread-safe.
- Add NotNullIfNotNull shim for nullable annotation support.
- Shim for ProcessSupport.Kill with entireProcessTree arg (does not actually kill entire process tree, but prevents compiler errors).
- [`JJ.Framework.SharedProject.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/SharedProject.Core)
- Improve reusable NoTrimReason strings, so they can be combined without redundancies with this syntax:
- [TrimWarn(PropertyTypeAnd + ObjectGetType)]
- The And-version includes a space separator and the non-And variant includes the DoWhatInstead.
- __`DevOps:`__
- Split Directory.Build.props into separate XML files / made modular.
- Use .NET versions MSBuild convenience variables.
- Add AutoPublish var for central conditions and the possibility to override (per project).
- ClearCache calls new ClearMisc to wipe Azure Pipelines folders.
- AzurePipelinesClearRetainFlags scripts helping to clean up locked Azure DevOps objects clearing excessive storage use.
- RunTrimTest.bat now operates on current dir, not bat file dir.


💬 Feedback 
------------

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)
