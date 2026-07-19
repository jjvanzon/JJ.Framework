JJ.Framework.Text.Core
======================

Addition to [`JJ.Framework.Text.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Text) for some special case methods that:

- Prettify logs and console output.
- Deal with blank lines, punctuation and accents.
- Overloads of basic methods like `Trim` and `Replace`.

Prettify
--------

These are opinionated, but made some logs pretty:

- `PrettyDuration`
- `PrettyTimeSpan`
- `PrettyTime`
- `PrettyByteCount`
- `WithShortGuids`


Spacing & Punctuation
---------------------

Trying to avoid excessive blank lines or punctuation these were born:

- `StartsWithBlankLine`
- `EndsWithBlankLine`
- `EndsWithPunctuation`
- `CountLines`
- `RemoveAccents`

Basic Overloads
---------------

Overloads that take either `char` or `string`:

- `Trim` 
- `Replace`

💬 Feedback
------------

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)