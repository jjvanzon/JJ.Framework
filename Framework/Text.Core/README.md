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

`PrettyDuration` / `PrettyTimeSpan` examples:

- `2.63 d` | `2.35 h` | `1.50 min` | `1.23 s` | `3.54 ms` | `573.23 μs`


`PrettyTime` example:

- `14:30:45.123`


`PrettyByteCount` examples:

- `100 bytes` | `5119 bytes` | `5 kB` | `5120 kB` | `5 MB` | `5120 MB` | `5 GB` | `10 GB` | `10000 GB`


`WithShortGuids`:

- GUIDs can really clutter your text: `New record {07c75275-0150-4414-bbca-0081b021a0ea}`
- This method takes a text that may contain GUIDs and shortens then e.g., `"New record 07c752"`
- It makes it easier to eyeball them, and usually they are an exact match. For human readability, this is good.
- You can supply the desired shortened length. In the example above length was `6`.


Spacing & Punctuation
---------------------

Trying to avoid excess blank lines or punctuation these were born:

- `StartsWithBlankLine`
- `EndsWithBlankLine`
- `EndsWithPunctuation`
- `RemoveAccents`
- `CountLines`

Basic Overloads
---------------

Overloads that take either `char` or `string` for:

- `Trim` 
- `Replace`

💬 Feedback
------------

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)