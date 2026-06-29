JJ.Framework.IO.Core
====================

Small set of helpers for IO related tasks.  
An extension to [`JJ.Framework.IO.Legacy`](https://www.nuget.org/packages/JJ.Framework.IO.Legacy).

Also adds a thread-safe variant of numbering file names (e.g. `MyFileToCopy (2).txt`) for highly concurrent scenarios, solving quite some tricky problems, when you pressure the system enough.