JJ.Framework.Build
==================

Internal infrastructure.

A supporting tool, designed to trigger initialization at the start of a solution build.

Used internally, to have one reference to JJ.AutoIncrementVersion and other projects reference JJ.Framework.Build.csproj; it makes the version increment only once, making the build more reliable and the version numbers more coherent.