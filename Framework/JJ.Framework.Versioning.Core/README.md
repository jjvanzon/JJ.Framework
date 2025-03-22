What is JJ.AutoIncrementVersion ?!
==================================

I want my `*` back! 

Those don't work anymore for version numbers. But we want auto-incremental numbers!

This package allows you to use `$(BuildNum)` instead.


How to Use?
-----------

You can use `$(BuildNum)` inside your version number, like this:


```
1.0.$(BuildNum)
```

And the effective version becomes something like:

```
1.0.123
```

Every time you build your project, the `$(BuildNum)` is simply incremented by `1`.


Integration
-----------

The `$(BuildNum)` variable should be automatically available when you've installed this NuGet package. But you can customize further.

A safer approach might be to add this instead, but it might be overkill:

```xml
<PropertyGroup>
  <!-- Use these in place of your own Version/VersionPrefix/VersionSuffix tags. -->
  <!-- They allow you to use the $(BuildNum) macro, which is automatically replaced by an incremental number. -->
  <!-- The first Version tag specified the default value, when no BuildNum has been generated yet. -->
  <!-- The 2nd Version tag subsequently uses the incremental number, via the $(BuildNum) macro. -->
  <Version Condition="'$(BuildNum)'==''">1.0.0</Version>
  <Version Condition="'$(BuildNum)'!=''">1.0.$(BuildNum)</Version>
</PropertyGroup>
```

This makes sure the build doesn't fail when the auto-generated 
`JJ.AutoIncrementVersion.props` is deleted. If deleted, it would otherwise cause and error like: `1.0. isn't a valid version number.`
