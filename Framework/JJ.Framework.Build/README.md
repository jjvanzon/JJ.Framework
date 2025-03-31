JJ.Framework.Build
==================

Internal infrastructure.

A supporting tool, designed to trigger initialization at the start of a solution build. Used internally to provide a single reference to `JJ.AutoIncrementVersion`, allowing other projects to reference `JJ.Framework.Build.csproj` instead. This makes the version increment only once, improves build reliability and keeps the version number coherent throughout the build.