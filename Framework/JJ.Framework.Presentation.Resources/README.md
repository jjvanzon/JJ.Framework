JJ.Framework.StringResources.Legacy
===================================

A small set of shared UI text resources and a helper for testing them.

It includes a few common titles, such as `Add`, `Cancel`, `Delete`, `Save`, `Search`, and `Yes` / `No`, with __Dutch__ and __US English__ translations.

The tester checks that resource members return useful text, work in the cultures you list, fall back to the default culture when needed, and still format placeholder-based strings correctly.

Example:

```cs
var tester = new StringResourceTester<MyResources>(
    known: ["nl-NL", "pl-PL"],
    unknown: "de-DE",
    @default: "en-US");

tester.AssertAllMembers();
tester.AssertUnknownCultureFallback();
```


Release Notes
-------------

#### `2026-04-23` | `0.254`/`4.6` : __Legacy + Integrity Checker + Assert.Throws Syntax__

- [`JJ.Framework.StringResources.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Presentation.Resources)
- `2015`: Limited set of reusable string resources
- `2021`: Reusable `StringResourceTester` verifies integrity
- `2026`: Extensions
- Placeholder verification
- Optional trace logging
- Both resource and formatter classes supported
- Static and instance members
- Free to chose fallback culture
- Wide .NET version compatibility, Trimming/AOT support, IntelliSense docs, 100% test coverage
- [`JJ.Framework.Testing.Core`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/Testing.Core)
- `Throws` methods syntax shorter


💬 Feedback
============

Questions or found an issues? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)