JJ.Framework.JavaScript
=======================

Several JavaScript helpers that may be used in private projects.

When installing it as a NuGet package, the script files might be put in the "Scripts" folder automatically. Possibly you may *include* them in the project by hand after that.

May depend on jQuery (version 2.0.3, but possibly any version will do).

-----

- JJ.Framework.Url.js:
    - May contain helper functions for working with URL's, which contains bugs... I should fix that eventually. 
- JJ.Framework.Cookie.js:
    - Contains helpers for working with cookies.
- JJ.Framework.Assert.js / JJ.Framework.Check.js:
    - Should allow making JavaScript more type-safe, but possibly using TypeScript instead is a better plan these days. 
- JJ.Framework.RememberScrollPosition.js:
    - may make an effort to make a page remember its scroll position when you get back to it, just by referencing this script.