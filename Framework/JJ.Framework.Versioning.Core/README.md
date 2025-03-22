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

The `$(BuildNum)` variable should be automatically available when you've installed this NuGet package.
Unfortunately it will also be **UN**available after you uninstall it. No problem right? Wrong.

A safer approach might be to replace your `Version` / `VerionPrefix` / `VersionSuffix` tags with this instead:

```xml
<Version Condition="'$(BuildNum)'==''">1.0.0</Version>
<Version Condition="'$(BuildNum)'!=''">1.0.$(BuildNum)</Version>
```

The first Version tag specified the default value, when no `$(BuildNum)` has been generated yet.
The 2nd Version tag subsequently uses the incremental number, via the `$(BuildNum)` macro.

This makes sure the build doesn't fail when you uninstall the `JJ.AutoIncrementVersion`.
Otherwise you're left with `1.0.$(BuildNum)`, but `$(BuildNum)` isn't defined anymore,
resulting in a corrupt version number `1.0.` with an extra period at the end,
which can result in either an error `1.0. isn't a valid version number.` if you're lucky.
But probably it would so you something irrelevant like `net9 not supported.`
And you can't just reinstall the packag, because nuget restore fails, and blocks you from uninstalling or reinstalling any package or build your solution for that matter until you've adjusted your `<Version>` tags.

I'm trying to find a more elegant solution as we speak.