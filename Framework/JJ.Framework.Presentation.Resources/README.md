JJ.Framework.StringResources.Legacy
===================================

A small set of shared UI text resources and a helper for testing them.

It includes a few common titles, such as `Add`, `Cancel`, `Delete`, `Save`, `Search`, and `Yes` / `No`, with Dutch and US English translations.

It also includes a useful helper for verifying the integrity of your string resources.

Example:

```cs
var tester = new StringResourceTester<MyResources>(
    known: ["nl-NL", "pl-PL"],
    unknown: "de-DE",
    @default: "en-US");

tester.AssertAllMembers();
tester.AssertUnknownCultureFallback();
```
