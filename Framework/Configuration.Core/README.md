JJ.Framework.Configuration.Core
===============================

The `System.Configuration` component is deprecated in `.NET Core` and `.NET 5`, which is quite inconvenient.

The first tip you get, is to do a painful migration to `JSON` files.

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


JJ.Framework.Configuration.Legacy
---------------------------------


This `.Core` variant accompanies a [`.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Configuration), that can map config XML to C# objects much simpler than the standard way offered by .NET `System.Configuration`.

CustomConfigurationManagerCore Class
------------------------------------

Offers a `TryGetSection` method that complements `GetSection` but now when the configuration section is not found, `null` is returned, instead of a crash. (Complements the null-intolerant version from [`JJ.Framework.Configuration.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Configuration)).
