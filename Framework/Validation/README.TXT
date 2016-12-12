JJ.Framework.Validation contains a class VersatileValidator. It offers a neat fluent notation:

	For(() => Thing.Value).NotNull().MaxLength(100);

If you separate validations from the rest of your code and turn them into validator classes, your business rules may become better maintainable. The validation messages are dry pairs of keys and message texts, which makes the output of the validations easily integratable with any other system. The set of fluent methods might be incomplete, but we just add things at the time we need it. You can also add validation messages imperatively:

	ValidationMessages.AddIsZeroMessage(...)

The ValidationMessages methods are a little more complete, but I am not making any promises about that. We use this framework to support our developments, and extend it on the fly, as needed.

This framework is also kind of a proof that you do not need an external validation framework. You can easily do it yourself.