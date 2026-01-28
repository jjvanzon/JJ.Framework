🔩 JJ.Framework
================

__📔 Contents__

- [📢 Introduction](#-introduction)
- [🏋️ Stability](#️-stability)
- [🏡 In-House](#-in-house)
- [🏛️ History](#️-history)
- [🍱 Modularization](#-modularization)
- [💁 Platform Compatibility](#-platform-compatibility)
- [📋 Release Notes](#-release-notes)
- [💬 Feedback](#-feedback)


📢 Introduction
----------------

`JJ.Framework` are extensions of the `.NET Framework`: the nuts, bolts and screws of software development: *reusable components*. Some of which might be expected to be there in `.NET`, but seem to be missing there.

`JJ.Framework` contains reusable code, that was produced along with real-life applications.


🏋️ Stability
-------------

No software is bug free, but extra effort was made, testing the `JJ.Framework` components, that were published to [NuGet](https://www.nuget.org/profiles/jjvanzon) which includes automated testing.

The ones not on NuGet are available as a sneek peek in [JJs-Pre-Release-Package-Feed](https://dev.azure.com/jjvanzon/JJs-Software/_packaging?_a=feed&feed=JJs-Pre-Release-Package-Feed). But those may be used with caution, because they may not be tested that well. Those may need some more unit testing and could still be a bug or two in it.


🏡 In-House
------------

`JJ.Framework` was made in the spirit of: small things: develop your own, instead of importing a huge framework.

`JJ.Framework` components are compact: a couple of kilobytes each.

Developed *in-house* so that it could be adapted and extended as needed. It did not have to be complete, because then we would just extend it.

If a bug was found in the development of an app, we could just correct the `JJ.Framework` as needed and release a stable app.

Of course, this 'in-house development' argument does not apply, when other people use it. But I think these extensions could be of use to others too.


🏛️ History
-----------

Any reusable code independent of a particular business domain, was moved to this `JJ.Framework`, for reuse. The reusable code was gathered up between 2010 and 2026. It was a hobby project. But something similar to this framework, was also developed professionally in a team of 7 of which I was the technical lead at the time.


🍱 Modularization
------------------

`JJ.Framework` tends to have a separate assembly for each part of the `.NET Framework` that it extends. Separation may be found between technical aspects. That may allow being specific, on which parts of `.NET` an application becomes dependent.

`JJ.Framework` also likes to decouple platform-specific implementation details and hide them behind generalized interfaces.


💁 Platform Compatibility
--------------------------

That grip on dependency, was once a good plan for platform compatibility. Some of `JJ.Framework` is still based on `.NET 4.6.1` trying to keep it compatible with `Mono`. Around 2015 `JJ.Framework` was tested to be reasonably compatible with `Mono` and by extension `Android`, `iOS` and `Windows Phone`. This was before newer technology like `.NET Standard` and `.NET 5 +` emerged, which could make platform-compatibility a bit more doable. For this reason, some of the `JJ.Framework` is currently being ported to a newer `.NET`, but this is still in progress.

📋 Release Notes
-----------------

<h4><code>1.9</code> Build.csproj</h4>
<h4><code>2.5</code> Existence.Core</h4>
<h4><code>2.6</code> Flags</h4>

- [JJ.Framework.Existence.Core](https://www.nuget.org/packages/JJ.Framework.Existence.Core):
- `spaceMatters` flags everywhere  
- `caseMatters` replaced `ignoreCase`  
- `StringBulder`/`string` more combos possible  
- `x.In(a, b, c)` extension favored over static `In(x, a, b, c)`  

<h4><code>2.7</code> Version Lineages + IntelliSense</h4>

- [JJ.Framework.Existence.Core](https://www.nuget.org/packages/JJ.Framework.Existence.Core), [JJ.Framework.Reflection.Legacy](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy) + dependencies.
- Improved separation of `Legacy` version lineages for a more stable package update.
- IntelliSense for [JJ.Framework.PlatformCompatibility.Legacy](https://www.nuget.org/packages/JJ.Framework.PlatformCompatibility.Legacy) and [JJ.Framework.Reflection.Legacy](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy)

<h4><code>2.8</code> AOT, Trimming and Self-Contained App Support</h4>

- [JJ.Framework.Existence.Core](https://www.nuget.org/packages/JJ.Framework.Existence.Core), [JJ.Framework.Reflection.Legacy](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy) + dependencies.
- Compatibility with AOT "Ahead-Of-Time" native compilation, code trimming and single-executable, self-contained apps.

<h4><code>2.9</code> ZeroMatters</h4>

- [JJ.Framework.Existence.Core](https://www.nuget.org/packages/JJ.Framework.Existence.Core) + dependencies.
- Added optional <code>zeroMatters</code> flags to indicate if <code>0</code> is a meaningful value, or to favor a fallback to a something less 'nully' instead.
- Includes [JJ.Framework.Reflection.Legacy](https://www.nuget.org/packages/JJ.Framework.Reflection.Legacy) to keepi version lineage consistent.

<h4><code>3.0</code> .NET 10 Support</h4>

<h4><code>3.1</code> No Priorities </h4>

- [JJ.Framework.Existence.Core](https://www.nuget.org/packages/JJ.Framework.Existence.Core) + dependencies.
- Sacrifice direct use of keywords e.g. `Coalesce(null, "Hallo")` over simpler overload resolution priorities, removing `OverloadResolutionPriority]` (or `[Prio]`) attributes.

💬 Feedback 
------------

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)
