JJ.AutoIncrementVersion
=======================


How to Use?
-----------

You can use $(BuildNumber) inside your version number, so instead of this:

```
1.0.0
```

You would use this:

```
1.0.$(BuildNumber)
```

And the effective version becomes e.g.:

```
1.0.123
```

Every time you build your project, the BuildNumber is simply incremented by 1.


Integration
-----------

The $(BuildNumber) variable should be automatically available when you've installed this NuGet package. But you can customize further.

A safer approach might be to add this instead, but it might be overkill:

```
<PropertyGroup>
  <!-- Use these in place of your own Version/VersionPrefix/VersionSuffix tags. -->
  <!-- They allow you to use the $(BuildNumber) macro, which is automatically replaced by an incremental number. -->
  <!-- The first Version tag specified the default value, when no BuildNumber has been generated yet. -->
  <!-- The 2nd Version tag subsequently uses the incremental number, via the $(BuildNumber) macro. -->
  <Version Condition="'$(BuildNumber)'==''">1.0.0</Version>
  <Version Condition="'$(BuildNumber)'!=''">1.0.$(BuildNumber)</Version>
</PropertyGroup>
```

This makes sure the build doesn't fail when the auto-generated 
JJ.AutoIncrementVersion.props is deleted. If deleted, it would otherwise cause and error like: "1.0." isn't a valid version number.
