Existence.Core
==============

Ever find yourself trying to decide on `IsNullOrEmpty`, `IsNullOrWhiteSpace`, a `null` check, empty list check or whether you should check at all?

Well, no more. Now you just type `Has(text)` or `Has(collection)` and be done with it.

Background
----------

*Nothing* isn’t one thing in `.NET`. It’s `null`, `default`, white space, `0`, `NaN`, `Empty`, `Length = 0`, `!Equals(x, default(T?)) && !Equals(x, default(T))`. It gets quite absurd with the many states of nothingness in .`NET`.

Here we coin the term __nully__. Don't blame us; the concept already existed, just nobody dared give it a name yet.

Features
--------

Grab these methods instead. Your code (and your brain) will thank you:

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

-----

Flags for special occasions:

- `spaceMatters`


    - `spaceMatters` flags everywhere – because sometimes you really care if your `string` is just a single space.

-----

- `matchCase`

    - To keep us sane as long as possible, the default is to not trip over case mismatches: GREEN = green. The matchCase flag can make things stricter and case-sensitive again.


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

Releases
--------

- __`2.5` Initial release__  
- __`2.6` Flags__  
  `spaceMatters` wider support  
  `ignoreCase` replaced by `matchCase`
  `x.In(a, b, c)` in favor of `In(x, a, b, c)`

Coming Soon
-----------

- `zeroMatters` – flip the switch so `0` isn't disregarded.
- `flex` mode – force a full runtime type lookup on values when you're feeling adventurous.
- `char` quirks – treat lone `' '` as nully by default (no more sneaky space bugs).
- `float` drama – `NaN`, `∞`, `+0`/`–0` all count as empty.
- `enum` safety net – invalid enum values get flagged as nully instead of blowing up.
- all-`null` collections – if every item is `null`, the whole collection is officially empty.
- ultra-loose `Is` – `10.Is("10")` regardless of type, because how will we stay sane if `10` isn’t `10`?


🐨 Mr. Koala
------------

Special thanks to *Mr. Koala.* Once you think of koalas when you read 🐨 `Coalesce`, you can never unsee it. *Mr. Koala* eats your nullies. Nully `nums` are his favorite!


💬 Feedback
------------

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)