Existence.Core
==============

Ever find yourself trying to decide on `IsNullOrEmpty`, `IsNullOrWhiteSpace`, a `null` check, empty list check or no check at all?

Well, no more. Now you just type: `Has(text)` or `Has(collection)` and be done with it.

Future Features
---------------

- `spaceMatters` more widely used
- `zeroMatters` to make 0 count as filled
- `flex` flag for runtime type checks
- char ' ' = nully
- Float specials: `NaN`, `∞`, `+0`/`-0` = nully
- Invalid enum val = nully
- List all-items-null = nully
- Looser `Is`: `10.Is("10") == true!`
