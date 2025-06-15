Contributing to Existence.Core
==============================

Here are some specific patterns used internally in the code of `JJ.Framework.Existence.Core` to make the syntax work.


Overload Fields
---------------

Vast fields of overloads are normal in this projects. They exist, so an API consumer can call the same command in multiple different contexts. For instance, you can call `Has(x)` on many different types, while internally they may be handled differently.

The overload fields delegate to an internal utility class, with more explicit method names, to indicate the specific cases. That keeps control over, how the overloads route to the right implementation, which can otherwise become unwieldly.

It also makes sure that each overload in the field can just be one line of code in a sort of "table of overloads".


Magic Booleans
--------------

Instead of a `bool` flag, you can use a single-valued enum e.g.,

```cs
enum SpaceMatters { spaceMatters = 1 }
```

This lets callers write:

```cs
`Has(text, spaceMatters)`
```

without `: true` for cleaner syntax, instead of

```cs
`Has(text, spaceMatters: true)`
```

The explicit boolean value option is still available. That's what makes it look like a magic boolean, of which you can leave out the value `true`.


A side-effect of this pattern, is that the overload that takes the magic boolean, does not have to swich on `true`/`false`. Instead, it can assume the flag is set, which creates opportunities for optimization.



Generic vs Concrete Overloads
-----------------------------

`[TODO: Reformulate so it becomes less abstract.]`

Here's a tricky one, that almost broke my brain, but we got it untangled.

The `Has` method and others require that there's an method overload with an __unbound generic type T__.

`[ TODO: Code of unbound generic overload. ]`

Sounds harmless enough, but it has consequences, and they aren't pretty.

The crux is that once an unbound generic overload is present, things don't get routed to interface-based overloads as easily.

`[ TODO: Code of unbound generic overload + interface overload. ]`

Concrete types don't go the the interface-based onverloads. They go straight to the unbound generic overloads.

`[ TODO: Code of interface call works, code for concrete type doesn't. ]`

It would route fine if the overload field __only__ contained abstract/interface types. Or with __constrained__ generic overload (not unbounded) it might route fine too. But we can't drop the unbound generic overload, which ruins everything.

If there's no unbound generic overload for `Has` people can't use `Has` in a generic context unless they impose the same generic constraints as the `Has` method does. It ruins the experience of flexibly being able to use `Has` anywhere, the purpose of this library. Using different public names for variants like `HasObject`, `HasCollection` also ruins the terse, the reason for this lib's existence.

Now the ugly consequence: When there is an unbound generic overload, then in order to support concrete types that route to specific implementations, you have to add overloads for __each and every concrete type you support__. This breaks the substitution principle. Or at least brute-forces it back with into existence by means of a gazillion overloads. It isn't really we that broke the substitution principle here. Generics broke it. Generics just don't function the same as a regular type hierarchy, even when you might expect it. So we do it: we add a gazzilion overloads. In particular for the collection types. All the BCL collection types are supported explicitly, one overload each. Any other collection type only lands at the unbound generic overload, which just does a null/default check, without the "collection is empty" check.

It there would be another solution that doesn't introduce other ugly API surface problems that would be great. But all the ChatGPTs in the world couldn't come up with something that didn't break something else and neither could I. Go ahead, ask ChatGPT. It'll claim your code style is bad, and it has the solution, but that "solution" breaks the overload field in other areas.