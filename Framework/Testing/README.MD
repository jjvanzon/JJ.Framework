# JJ.Framework.Testing

Helper for unit tests. Mimics the Assert class, but will display the tested expression in error messages, instead of being vague about it or laborious to program.

That is something that is very helpful when unit test assertions fail, and usually very laborious would you use the `Assert` class from `Microsoft.VisualStudio.QualityTools.UnitTestFramework`. With the `AssertHelper` class you get that for free.

It also offers methods to evaluate if the right exception goes off in the right spot with the right exception type and / or the right message.
