Contributing to JJ.Framework.PlatformCompatibility
==================================================

Back in the day, there were many different .NET variants. Deploying to multiple platforms was possible, but quite a hassle. That's what these __Platform Compatibility__ helpers were built for. Whenever a class or method wasn't available on a certain platform, a portable alternative was added here.

The structure aimed to help the developer discover platform-safe variants while typing with IntelliSense. So if you typed `String`, you'd immediately see `String_PlatformSafe` as a suggestion.

To improve discoverability even more, there was a central `PlatformHelper` that gathered all the problem cases into one place.

But this also meant that the same functionality was accessible from multiple entry points, which made the internal code structure harder to follow.

At one point, the `static` methods were deprecated in favor of extension methods, to reduce duplication. But later C# was revised and you could only use `static using` (short static invocation) syntax along with extension method syntax if you define them both.

The result is a bit of a Frankenstein API. It isn't even needed anymore on newer platforms, but still relied upon by some projects and legacy code that we pull in.