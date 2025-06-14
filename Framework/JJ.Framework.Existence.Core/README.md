Existence.Core
==============

Ever find yourself trying to decide on `IsNullOrEmpty`, `IsNullOrWhiteSpace`, a `null` check, empty list check or no check at all?

Well, no more. Now you just type: `Has(text)` or `Has(collection)` and be done with it.

Future Features
---------------

- `spaceMatters` everywhere – because sometimes you really care if your `string` is just a single space.
- `zeroMatters` – flip the switch so `0` isn't disregarded.
- `flex` mode – force a full runtime type lookup on values when you're feeling adventurous.
- `char` quirks – treat lone `' '` as nully by default (no more sneaky space bugs).
- `float` drama – `NaN`, `∞`, `+0`/`–0` all count as empty.
- `enum` safety net – invalid enum values get flagged as nully instead of blowing up.
- all-null collections – if every item is null, the whole collection is officially "empty."
- ultra-loose `Is` – because sometimes `10.Is("10")` because how will we stay sane if it's not.