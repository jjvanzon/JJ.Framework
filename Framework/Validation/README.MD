JJ.Framework.Validation
=======================

May contain a class __VersatileValidator__. It might offer a neat fluent notation:

	For(Thing.Value).NotNull().MaxLength(100);

When validations would be separated from the rest of the code, like turning them into validator classes, 
business logic might become better maintainable. The validation messages would be dry lists of strings, 
to try to make the output of the validations better integratable with other systems. 
The set of fluent methods might be a bit incomplete, because currently things are only extended on the fly as needed. 

You can also add validation messages imperatively, for instance:

	ValidationMessages.AddIsZeroMessage(...)

The __ValidationMessages__ methods might be a little more complete.

The simplicity of this framework might also be kind of a proof that you might not need an external validation framework. Doing it yourself might also be an option.