Existence.Core
==============

Ever find yourself trying to decide on `IsNullOrEmpty`, `IsNullOrWhiteSpace`, a `null` check, empty list check or no check at all?

Well, no more. Now you just type: `Has(text)` or `Has(collection)` and be done with it.

Features
--------

- `FilledIn` / `Has` / `IsNully`  
  One step beyond `null`, treating empty `strings`, `0`, or empty lists as `"nully"`.
- `Coalesce`  
  First non-`nully` value picker (think `??` on steroids).
- `Contains` / `In`  
  "Is this in that?" tests for collections and sets.
- `Is`   
  Loose equality (case/trim-insensitive, etc.) when you don't care about exact matches.

Grab these methods instead of wrestling with `if` statements and repeated checks.
Your code (and your brain) will thank you.

Future Features
---------------

- `spaceMatters` everywhere – because sometimes you really care if your `string` is just a single space.
- `zeroMatters` – flip the switch so `0` isn't disregarded.
- `flex` mode – force a full runtime type lookup on values when you're feeling adventurous.
- `char` quirks – treat lone `' '` as nully by default (no more sneaky space bugs).
- `float` drama – `NaN`, `∞`, `+0`/`–0` all count as empty.
- `enum` safety net – invalid enum values get flagged as nully instead of blowing up.
- all-`null` collections – if every item is `null`, the whole collection is officially empty.
- ultra-loose `Is` – `10.Is("10")` regardless of type, because how will we stay sane if `10` isn’t `10`?
