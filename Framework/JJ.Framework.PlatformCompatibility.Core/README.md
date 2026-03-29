JJ.Framework.PlatformCompatibility.Core
=======================================

Shims that mimic new features for old `.NETs`, so new code can compile for older tech.  
It's internal tooling in support of the `JJ` projects and only supports a limited selection.

Background
----------

When you want a single code base to compile on both old and new `.NETs`, you run into trouble. Things like `init`, `required` and nullability attributes: they just aren't there on older targets.

These shims step in silently: on platforms that already have the real thing, they stay out of the way. On older ones, they provide just enough so the compiler stops complaining. Sometimes the behavior may be a no-op, but at least it compiles and things keep working.

Argument Checks
---------------

Newer `.NETs` added shorthand `throws` which aren't there yet in some older `.NET` versions:

- `ThrowIfNull`
- `ThrowIfNullOrWhiteSpace`

Language Features
-----------------

A few language keywords that older `.NET` versions don't support without a stub somewhere:

- `[RequiredMember]` - needed for the `required` keyword on older targets.
- `[CallerArgumentExpression]` - needed to extract the text of the expression of how the argument is passed.
- `[OverloadResolutionPriority]` - hints to the compiler which overload to prefer, when there's ambiguity.
- `IsExternalInit` - needed for `init`-only setters.
- `[CompilerFeatureRequired]` - lets a type signal it relies on a specific compiler feature.

Nullability
-----------

Nullability attributes might be missing on older platforms:

- `[NotNull]` - tells the compiler a value won't come out `null`.
- `[NotNullWhen]` - same, but only when the method returns a particular Boolean value.

As `PlatformCompatibility.Core` makes sure they're there, the compiler knows what to do with them, and the nullability intents are used, even for older .NET versions.

Trimming / AOT
--------------

When publishing with trimming or native compilation (AOT), the compiler needs hints about what to keep. These attributes carry those hints. On platforms that don't know them yet, the shims provide the same code at least compiles:

- `[DynamicallyAccessedMembers]`
- `[DynamicallyAccessedMemberTypes]`
- `[DynamicDependency]`
- `[RequiresUnreferencedCode]`
- `[RequiresDynamicCode]`
- `[UnconditionalSuppressMessage]`

Threading
---------

- `Lock` - a new type introduced for more efficient locking, backported so the same locking pattern compiles on older targets.

Utilities
---------

- `HashCode` - `HashCode.Combine(...)` for older `.NET` versions that don't have it built in.