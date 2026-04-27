JJ.Framework.Configuration.Core
===============================

To use the deprecated `System.Configuration` in `.NET 5` and up, you'd need to reference a package called [`System.Configuration.ConfigurationManager`](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/11.0.0-preview.3.26207.106).

But it lacks config file copying behavior that would just make `app.config` work out of the box when it's in your project folder.

This package `JJ.Framework.Configuration.Core` copies it for you automatically again so you don't have to worry about it anymore.


File Names
----------

It copies your `app.config` to the output bin with the following file names:

- {YourProjectName}.dll.config
- testhost.dll.config
- nCrunch.TaskRunner.DotNetCore.20.x64.dll.config

`[ TODO: More details, like example paths and file names. ]`


`[ TODO: Document other purpose of JJ.Framework.Configuration.Core ]`

`[ TODO: Reference JJ.Framework.Configuration(.Legacy) ]`