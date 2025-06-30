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