Contributing to Existence.Core
==============================


The Easy Part
-------------

The API surface doesn't look hard. It's just a simple set of commands:  
`Has`, `FilledIn`, `IsNully`, `Is`, `In`, `Contains`.

What they do internally essentially it isn't difficult either. Things like:
`x != null || x != 0` - the stuff you'd otherwise program yourself.


The Challenge
-------------

Making the connection between those two,  
gives `FilledIn` checks many different overloads.  
They all need to lead to the correct empty check  
(preferably with 0 performance cost).

And before you know it, it gets ugly.  
Overload clashes lurking everywhere.

This doc describes some specific patterns used internally in the code to keep it all working.

On top of that, there is even more added syntax flexibility, so be prepared to make the overload field even worse by choice: extension methods, static methods, flag specifiers of different sorts and parameter order switcheroo all over.

All to give the API consumer the most intuitive experience.


Overload Fields
---------------

We try to offer the most transparent and widely applicable use of basic commands like `Has`, `Coalesce` and the like.

Vast fields of overloads are normal in this project. They exist, so an API consumer can call the same command in multiple different contexts. For instance, you can call `Has(x)` on many different types, while internally they may be handled quite differently.

The overload fields delegate to an internal utility class, with more explicit method names, to indicate the specific checks. That keeps control over, how the overloads route to the right implementation, which would otherwise be hard to control.

It also makes sure that each of the overloads, can just be one line of code in a sort of "table of overloads".

Is this easy? No not really. Things can clash. The __tests__ are the ultimate judge whether overload resolution works.


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

The explicit boolean value option is still available. That's what makes it look like a magic boolean, of which you can leave out the value.

A side-effect of this pattern, is that the overload that takes the magic boolean, does not have to swich on `true`/`false`. Instead, it can assume the flag is set, creating opportunities for optimization.



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

It would route fine if the overload field __only__ contained abstract/interface types. Or with __constrained__ generic overload it might route fine too. But we can't get rid of the unbound generic overload, which ruins everything.

If there wouldn't be an unbound generic overload the `Has` method, people couldn't use it in generic contexts, unless they impose the same generic constraints as the `Has` method. It ruins the experience of flexibly being able to use `Has` anywhere: the purpose of this library. Using different public names for variants like `HasObject`, `HasCollection` also harms the terse syntax: the reason for this lib's existence.

Now the ugly consequence: When there is an unbound generic overload, then in order to support concrete types that route to specific implementations, you have to add overloads for __each and every concrete type you support__. This breaks the substitution principle. Or at least brute-forces it back with into existence by means of a gazillion overloads. It isn't really we that broke the substitution principle here. Generics broke it. Generics just don't function the same as a regular type hierarchy, even when it looks like they should. So we do it: we add a gazzilion overloads. In particular for the collection types. All the BCL collection types are supported explicitly, one overload each. Any other collection type only lands at the unbound generic overload, which just does a null/default check, skipping the "collection is empty" check.

If there would be another solution that doesn't introduce other ugly API surface problems that would be great. But all the ChatGPTs in the world couldn't come up with something that didn't break something else and neither could I. Go ahead, ask ChatGPT. It'll claim your code style is bad, and it has the solution, but that "solution" breaks the overload field.