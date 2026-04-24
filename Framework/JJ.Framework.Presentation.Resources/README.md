JJ.Framework.StringResources.Legacy
===================================

A small set of reusable texts for button and such + a helper to test their integrity.

It includes common titles, such as `Add`, `Cancel`, `Delete`, `Save`, `Search`, and `Yes` / `No`, with `Dutch` and `US English` translations.

The tester checks that resource members return any text, work in the cultures you list, fall back to the default culture when needed, and correctly format placeholder-based strings.

Example:

```cs
var tester = new StringResourceTester<MyResources>(
    known: ["nl-NL", "pl-PL"],
    unknown: "de-DE",
    @default: "en-US");

tester.AssertResourceMembers();
tester.AssertCultureFallback();
```


Release Notes
-------------

#### `2026-04-23` | `0.254`/`4.6` : __Legacy + Integrity Checker__

- `2015`: Limited set of reusable string resources
- `2021`: Reusable `StringResourceTester` verifies integrity
- `2026`: Extensions:
- Placeholder verification
- Optional trace logging
- Both resource and formatter classes supported
- Static and instance members
- Free to chose fallback culture
- Wide .NET version compatibility, Trimming/AOT support
- IntelliSense docs, 100% test coverage


💬 Feedback
============

Questions or found an issues? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)