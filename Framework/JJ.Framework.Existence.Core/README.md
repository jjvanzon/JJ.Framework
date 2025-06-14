Existence.Core
==============

Ever find yourself trying to decide on `IsNullOrEmpty`, `IsNullOrWhiteSpace`, a `null` check, empty list check or no check at all?

Well, no more. Now you just type: `Has(text)` or `Has(collection)` and be done with it.

Future Features
---------------

- __`spaceMatters` everywhere__ – because sometimes you really care if your `string` is just a single space.
- __`zeroMatters`__ – flip the switch so `0` isn't disregarded.
- __`flex` mode__ – force a full runtime type lookup on values when you're feeling adventurous.
- __`char` quirks__ – treat lone `' '` as nully by default (no more sneaky space bugs).
- __`float` drama__ – `NaN`, `∞`, `+0`/`–0` all count as empty.
- __`enum` safety net__ – invalid enum values get flagged as nully instead of blowing up.
- __all-null collections__ – if every item is null, the whole collection is officially "empty."
- __ultra-loose `Is`__ – because sometimes `10.Is("10")` because how will we stay sane if it's not.