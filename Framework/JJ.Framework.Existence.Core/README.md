Existence.Core
==============

Ever find yourself trying to decide on `IsNullOrEmpty`, `IsNullOrWhiteSpace`, a `null` check, empty list check or whether you should check at all?

Well, no more. Now you just type `Has(text)` or `Has(collection)` and be done with it.


Background
----------

__Nothing__ isn't one thing in `.NET`. It's `null`, `default`, white space, `0`, `NaN`, `Empty`, `Length = 0`, `!Equals(x, default(T?)) && !Equals(x, default(T))`. It gets quite absurd with the many states of nothingness in .`NET`.

Here we coin the term __nully__. Don't blame us; the concept already existed, just nobody dared give it a name yet.


Features
--------

Grab these methods instead of wrestling with these checks. Your code (and your brain) will thank you:

- `Has` / `FilledIn` / `IsNully`

    - One step beyond `null` treating empty `strings` / white space / `0` / empty lists as `nully`.

-----

- `Coalesce`

    - Pick the first non-`nully` value (`??` on steroids).

-----

- `In` / `Contains`

    - "Is this in that?" tests for collections.

-----

- `Is`

    - Loose equality (case/trim-insensitive, etc.) when you don't care about exact matches.

-----

Flags for special occasions:

- `spaceMatters`

    - At times, you really care if your `string` is just a single space.

-----

- `zeroMatters`
  
    - Flip the switch if you consider `0` meaningful.

-----

- `caseMatters`

    - To keep us sane as long as possible, the default is to not trip over case mismatches: GREEN = green. The caseMatters flag can make things stricter and case-sensitive again.


Examples
--------

```cs
list = list.Where(FilledIn);

if (number.IsNully()) return;

if (Has(name)) sb.Append($" {name} ");

Coalesce(" ", Null, "Hi!") == "Hi!"

"\r\n GREEN\t  ".Is("Green")

"GREEN".In("Red", "Green","Blue") == true!
```


Coming Soon
-----------

- `flex` mode – force a full runtime type lookup on values when you're feeling adventurous.
- `char` quirks – treat lone `' '` as nully by default (no more sneaky space bugs).
- `float` drama – `NaN`, `∞`, `+0`/`–0` all count as empty.
- `enum` safety net – invalid enum values get flagged as nully instead of blowing up.
- all-`null` collections – if every item is `null`, the whole collection is officially empty.
- ultra-loose `Is` – `10.Is("10")` regardless of type, because how will we stay sane if `10` isn't `10`?

Release Notes
--------

#### `2.5` Initial release

#### `2.6` Flags

- `spaceMatters` flags everywhere  
- `caseMatters` replaced `ignoreCase`  
- `StringBulder`/`string` more combos possible  
- `x.In(a, b, c)` extension favored over static `In(x, a, b, c)`  

#### `2.7` Version Lineages + IntelliSense

- Improved separation of `Legacy` version lineages for a more stable package update.

#### `2.8` AOT, Trimming and Self-Contained App Support

- Compatibility with AOT "Ahead-Of-Time" native compilation, code trimming and single-executable, self-contained apps.

#### `2.9` zeroMatters

- Flag when you consider `0` meaningful (not nully).

#### `3.0` .NET 10 Support

#### `3.1` No Priorities

- Simplify overload resolution priorities.
- Removing `OverloadResolutionPriority]` (or `[Prio]`) attributes.
- Sacrifices direct use of keywords e.g. `Coalesce(null, "Hallo")`, which isn't a real use case anyway.


After Upgrading
---------------

Links to legacy dependencies may have changed. If you experience problems, these things might help:

#### Option `1`
- Do nothing. Everything works.
#### Option `2`
- Use the [JJ.Framework.Common.Legacy](https://www.nuget.org/packages/JJ.Framework.Common.Legacy) namespace where you currently use [JJ.Framework.Common](https://www.nuget.org/packages/JJ.Framework.Common/0.250.3184).
#### Option `3`
- Install [JJ.Framework.Common](https://www.nuget.org/packages/JJ.Framework.Common/0.250.3184) explicitly. You may need a downgrade to a `0.*` version.

The same thing applies to 
[JJ.Framework.PlatformCompatibility.Legacy](https://www.nuget.org/packages/JJ.Framework.PlatformCompatibility.Legacy) vs [JJ.Framework.PlatformCompatibility](https://www.nuget.org/packages/JJ.Framework.PlatformCompatibility/0.250.3184)


🐨 Mr. Koala
------------

Special thanks to *Mr. Koala.* Once you think of koalas when you read 🐨 `Coalesce`, you can never unsee it. *Mr. Koala* eats your nullies. Nully `nums` are his favorite!


💬 Feedback
------------

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)