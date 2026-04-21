JJ.Framework.StringResources.Legacy
===================================

A small set of shared UI text resources and a helper for testing them.

It includes a few common titles, such as `Add`, `Cancel`, `Delete`, `Save`, `Search`, and `Yes` / `No`, with Dutch and US English translations.

In short, the tester checks that resource members return useful text, work in the cultures you list, fall back to the default culture when needed, and still format placeholder-based strings correctly.

Example:

```cs
var tester = new StringResourceTester<MyResources>(
    known: ["nl-NL", "pl-PL"],
    unknown: "de-DE",
    @default: "en-US");

tester.AssertAllMembers();
tester.AssertUnknownCultureFallback();
```
