JJ.Framework.Text.Core
======================

Addition to `JJ.Framework.Text.Legacy` for some special case methods that:

- Prettify logs and console output.
- Deal with blank lines, punctuation and accents.
- Overloads of basic methods like `Trim` and `Replace`  

Prettify
--------

Here's the prettification methods. They are opinionated, but made some logs pretty:

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

And a few more for accent-free comparison and counting the number of lines for some reason:

- `CountLines`
- `RemoveAccents`

Basic Overloads
---------------

Overloads that take either `char` or `string`, where I was missing them:

- `Trim` 
- `Replace`

💬 Feedback
------------

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)