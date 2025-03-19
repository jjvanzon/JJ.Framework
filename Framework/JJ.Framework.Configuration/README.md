JJ.Framework
============

JJ.Framework.Configuration
==========================

Paste this into the post-build events of the problem you wish to use an app.config for:

```
echo copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
     copy "$(ProjectDir)app.config" "$(TargetDir)$(TargetFileName).config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)testhost.dll.config"
echo copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
     copy "$(ProjectDir)app.config" "$(TargetDir)nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
```