JJ.Framework.Validation.Legacy 
------------------------------

Historic release for compatibility with older projects from `2015`, now upgraded to the newest .NET, doc comments everywhere and compatible with code trimming and native compilation.

Contains a class `FluentValidator`. It offers a neat fluent notation:

	For(() => Thing.Value).NotNull().MaxLength(100);

If you separate validations from the rest of your code and turn them into validator classes, your business rules may become better maintainable. The validation messages are dry pairs of keys and message texts, which makes the output of the validations easily integratable with any other system. The set of fluent methods might be incomplete, but we just add things at the time we need it.

We use this framework to support our developments, and extend it on the fly, as needed.

This framework is also kind of a proof that you do not need an external validation framework. You can easily do it yourself.

Release Notes
-------------

#### `2026-03`, `0.251` : __Legacy__

- Release of historic version
- Full test coverage
- Member docs
- Trimming/AOT support
- .NET `10` -> `4.6.1`
- .NET Standard `2.0` and `2.1`
- `FluentValidator` syntax
- `For(() => player.TotalScore, "Total Score").Min(0).Max(100);`
- `NotNull`, `NotNullOrWhiteSpace`, `In`, `Is`, `IsNot`, `NotZero`, `Above`, `Min`, `Max`, `NotInteger`, `IsEnumValue`
- `IValidator` / `ValidatorBase` members
- `IsValid` (boo), `ValidationMessages`, `Verify()` (throws)
- Sub-validators and message prefixes: `"Address: Street is required."`
- Localization English (`en-US`) and Dutch (`nl-NL`)

💬 Feedback
============

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)