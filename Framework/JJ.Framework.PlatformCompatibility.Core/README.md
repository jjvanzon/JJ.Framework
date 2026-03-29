JJ.Framework.PlatformCompatibility.Core
=======================================

Shims that mimic new features for old `.NETs`, so new code can compile for older tech.


Background
----------

When you want a single code base to compile on both old and new `.NETs`, you run into trouble. Things like `init`, `required` and nullability attributes: they just aren't there on older targets.

These shims step in silently: on platforms that already have the real thing, they stay out of the way. On older ones, they provide just enough of a stub so the compiler stops complaining. Sometimes the behavior may be a no-op, but at least it compiles and things keep working.

It's only a limited selection, in support of the `JJ` projects.


Argument Checks
---------------

Newer `.NETs` added shorthand throws directly onto the exception types:

- `ArgumentNullException.ThrowIfNull` - backported for pre `.NET 6`.
- `ArgumentException.ThrowIfNullOrWhiteSpace` - backported for pre `.NET 8`.

Language Features
-----------------

A few language keywords that older compilers don't support without a stub type somewhere:

- `[RequiredMember]` - needed for the `required` keyword on older targets.
- `[CallerArgumentExpression]` - needed to pass the original expression text of an argument into a method. Pre `.NET 5`.
- `[OverloadResolutionPriority]` - hints to the compiler which overload to prefer, when there's ambiguity. Pre `.NET 9`.
- `[CompilerFeatureRequired]` - lets a type signal it relies on a specific compiler feature.
- `IsExternalInit` - needed for `init`-only setters on `.NET Framework` and `.NET Standard`.

Nullability
-----------

The nullability attributes live in `System.Diagnostics.CodeAnalysis`. On older platforms they might be missing:

- `[NotNull]` - tells the compiler a value won't come out `null`.
- `[NotNullWhen]` - same, but only when the method returns a particular `bool`.

Trimming / AOT
--------------

When publishing with trimming or native compilation (AOT), the compiler needs hints about what to keep. These attributes carry those hints. On platforms that don't know them yet, the shims provide the same code at least compiles:

- `[DynamicallyAccessedMembers]` / `[DynamicallyAccessedMemberTypes]`
- `[DynamicDependency]`
- `[RequiresUnreferencedCode]`
- `[RequiresDynamicCode]`
- `[UnconditionalSuppressMessage]`

Threading
---------

- `Lock` - a new type introduced in `.NET 9` for more efficient locking, backported so the same locking pattern compiles on older targets too.

Utilities
---------

- `HashCode` - `HashCode.Combine(...)` for `.NET Framework` and `.NET Standard 2.0`, which don't have it built in.