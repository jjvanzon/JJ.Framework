JJ.Framework.Configuration.Core
===============================

The `System.Configuration` component is deprecated in `.NET Core` and `.NET 5`, which is quite inconvenient.

People may say you have to do a painful migration to `JSON` file for configurations.

But the usual alternative is referencing a package called [`System.Configuration.ConfigurationManager`](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/11.0.0-preview.3.26207.106).

However it lacks the original __copying__ behavior, that would just make `app.config` work out of the box when it's in your project folder.

__This__ package `JJ.Framework.Configuration.Core` copies it for you automatically again so you don't have to worry about it anymore.


File Names
----------

It copies your `app.config` to the output `bin` with the following file names:

- `{YourProjectName}.dll.config`:  
  For exe's
- `testhost.dll.config`:  
  For test runs in `Visual Studio`
- `nCrunch.TaskRunner.DotNetCore.20.x64.dll.config`:  
  For `NCrunch` to find your config.



`[ TODO: Document other purpose of JJ.Framework.Configuration.Core ]`

`[ TODO: Reference JJ.Framework.Configuration(.Legacy) ]`