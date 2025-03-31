JJ.Framework.Build
==================

Internal infrastructure. Not intended for direct use.

A supporting tool, designed to trigger initialization at the start of the JJ.Framework solution build. Provides a single reference to [`JJ.AutoIncrementVersion`](https://www.nuget.org/packages/JJ.AutoIncrementVersion), allowing other projects to reference `JJ.Framework.Build.csproj` instead. This increments the version only once per build, keeping the version numbers coherent and improving build reliability.