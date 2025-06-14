Existence.Core
==============

Ever find yourself trying to decide on `IsNullOrEmpty`, `IsNullOrWhiteSpace`, a `null` check, empty list check or no check at all?

Well, no more. Now you just type `Has(text)` or `Has(collection)` and be done with it.

Background
----------

*Nothing* isn’t one thing in `.NET`. It’s `null`, `default`, white space, `0`, `NaN`, `Empty`, `Length = 0`, uninitialized structs, `Nullable<T>.HasValue == false`, etc. Things can get quite absurd, once you dive into how many ways nothingness can be expressed in .`NET`.

Here we coin the term __nully__. Don't blame us; the concept it already existed, just nobody dared give it a name yet.

Features
--------

Grab these methods instead of wrestling with all these checks. Your code (and your brain) will thank you:

- `Has` / `FilledIn` / `IsNully`

    - One step beyond `null` treating empty `strings` / white space / `0` / empty lists as `nully`.

-----

- `Coalesce`

    - Pick the first non-`nully` value (`??` on steroids).

-----

- `In` / `Contains`

    - "Is this in that?" tests for collections and sets.

-----

- `Is`

    - Loose equality (case/trim-insensitive, etc.) when you don't care about exact matches.


Examples
--------

```cs
list = list.Where(FilledIn);

if (number.IsNully()) return;

if (Has(name)) sb.Append($" {name} ");

Coalesce(" ", null, "Hi!") == "Hi!"

"\r\n GREEN\t  ".Is("Green")

"GREEN".In("Red", "Green","Blue") == true!
```

Future Features
---------------

More is coming to make things super flexible:

- `spaceMatters` everywhere – because sometimes you really care if your `string` is just a single space.
- `zeroMatters` – flip the switch so `0` isn't disregarded.
- `flex` mode – force a full runtime type lookup on values when you're feeling adventurous.
- `char` quirks – treat lone `' '` as nully by default (no more sneaky space bugs).
- `float` drama – `NaN`, `∞`, `+0`/`–0` all count as empty.
- `enum` safety net – invalid enum values get flagged as nully instead of blowing up.
- all-`null` collections – if every item is `null`, the whole collection is officially empty.
- ultra-loose `Is` – `10.Is("10")` regardless of type, because how will we stay sane if `10` isn’t `10`?


🐨 Mr. Koala
------------

Special thanks to *Mr. Koala.* Once you think of koalas when you read 🐨 `Coalesce`, you can never unsee it. *Mr. Koala* eats your nullies. Nully `nums` are his favorites!


💬 Feedback
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)