`[ TODO: Combine texts for .Legacy and .Core projects both dunked in this text file ]`

JJ.Framework.Configuration.Legacy
=================================

Paste this into the post-build events of the project you wish to use an app.config for:

```
echo copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
     copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
```

Switching from JJ.Framework.Configuration (non-Legacy)
------------------------------------------------------

When you're switching from a non-Legacy suffixed version (`JJ.Framework.Configuration`) to this `Legacy` suffixed variant (`JJ.Framework.Configuration.Legacy`) you should update your configuration section declarations in your config files. This is the original:

`<section name="..." type="JJ.Framework.Configuration.ConfigurationSectionHandler, JJ.Framework.Configuration"/>`

This should be the new one:

`<section name="..." type="JJ.Framework.Configuration.Legacy.ConfigurationSectionHandler, JJ.Framework.Configuration.Legacy"/>`

This is necessary so that side-by-side usage of the two variants doesn't collide.

JJ.Framework.Configuration.Core
===============================

The `System.Configuration` component is deprecated in `.NET Core` and `.NET 5`, which is quite inconvenient.

The first tip you get, is to do a painful migration to `JSON` files.

But the usual alternative is referencing a package called [`System.Configuration.ConfigurationManager`](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/11.0.0-preview.3.26207.106).

However it lacks the original __copying__ behavior, that would just make `app.config` work out of the box when it's in your project folder.

__This__ package `JJ.Framework.Configuration.Core` copies it for you automatically again so you don't have to worry about it anymore.


Config File Names
-----------------

If you reference `JJ.Framework.Configuration.Core` in your project,
the following config file names in your project folder are copied to the `bin` when you compile:

- `app.config`
- `web.config`
- `testhost.dll.config`
- `{YourProjectName}.dll.config`

If either of those are in your project, the first one is copied to the `bin` with the following file names:

- `{YourProjectName}.dll.config`:  
    - For exe's
- `testhost.dll.config`:  
    - For test runs in `Visual Studio`
- `nCrunch.TaskRunner.DotNetCore.20.x64.dll.config`:  
    - For `NCrunch` to find your config.

All `3` copies will be put in the `bin`, so all this tooling can find it.

Manual Option
-------------

If referencing `JJ.Framework.Configuration.Core` is not enough to auto-copy your config where it needs to be, you could add the following scripting to the Post-Build Event of your `csproj`:

```bash
echo copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
     copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
```

This can help if your environment's tooling expects a different file name. Adjust the script's source and destination file names accordingly.

JJ.Framework.Configuration.Legacy
---------------------------------

This `.Core` variant accompanies a `JJ.Framework.Configuration`[`.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Configuration) variant, that can map config `XML` to `C#` objects much simpler than the standard way offered by .NET `System.Configuration`.

CustomConfigurationManagerEx Class
------------------------------------

Offers a `TryGetSection` method that complements `GetSection` (from [`JJ.Framework.Configuration.Legacy`](https://github.com/jjvanzon/JJ.Framework/tree/main/Framework/JJ.Framework.Configuration)) but now when the configuration section is not found, `null` is returned, instead an exception being thrown.
