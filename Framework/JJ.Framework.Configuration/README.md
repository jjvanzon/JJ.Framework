JJ.Framework.Configuration.Legacy
=================================

Map config `XML` to `C#` objects much simpler than the standard way offered by .NET `System.Configuration`.

See the [2018 version's README](https://www.nuget.org/packages/JJ.Framework.Configuration) for a good explainer.

This is a `2015` code freeze of it + some additions to keep some legacy projects running.


Config Copying
--------------

The `System.Configuration` component is deprecated in `.NET Core` and `.NET 5`, which is quite inconvenient.

The first tip you get, is to do a painful migration to `JSON` files.

But the usual alternative is referencing a package called [`System.Configuration.ConfigurationManager`](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/11.0.0-preview.3.26207.106).

However it lacks the original __copying__ behavior, that would just make `app.config` work out of the box when it's in your project folder.

__This__ package `JJ.Framework.Configuration.Legacy` copies it for you automatically again so you don't have to worry about it anymore.


Config File Names
-----------------

If you reference `JJ.Framework.Configuration.Legacy` in your project,
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

If referencing `JJ.Framework.Configuration.Legacy` is not enough to auto-copy your config where it needs to be, you could add the following scripting to the Post-Build Event of your `csproj`:

```bash
echo copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
     copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
```

This can help if your environment's tooling expects a different file name. Adjust the script's source and destination file names accordingly.

Switching from JJ.Framework.Configuration (non-Legacy)
------------------------------------------------------

When you're switching from a non-Legacy suffixed version (`JJ.Framework.Configuration`) to this `Legacy` suffixed variant (`JJ.Framework.Configuration.Legacy`) you should update your configuration section declarations in your config files. This is the original:

`<section name="..." type="JJ.Framework.Configuration.ConfigurationSectionHandler, JJ.Framework.Configuration"/>`

This should be the new one:

`<section name="..." type="JJ.Framework.Configuration.Legacy.ConfigurationSectionHandler, JJ.Framework.Configuration.Legacy"/>`

This is necessary so that side-by-side usage of the two variants doesn't collide.


💬 Feedback
============

Issues or comments? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)