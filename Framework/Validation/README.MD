JJ.Framework.Validation
=======================

Contains a class __VersatileValidator__. that offers a neat fluent notation:

	For(Thing.Value).NotNull().MaxLength(100);

When validations are separated from the rest of the code, turning them into validator classes, 
business logic becomes better maintainable. The validation messages are dry lists of strings, 
to try to make the output of the validations better integratable with other systems. 
The set of fluent methods is a bit incomplete, because currently things are only extended on the fly as needed. 

You can also add validation messages imperatively, for instance:

	ValidationMessages.AddIsZeroMessage(...)

The __ValidationMessages__ methods are more complete than the fluent validation methods.

The simplicity of this framework might also be kind of a proof that you might not need an external validation framework. Doing it yourself is also an option.