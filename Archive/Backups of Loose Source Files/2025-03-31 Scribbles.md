CONTRIBUTING:

Here you can find instructions to set up your dev environment so `JJ.Framework.sln` can be built.

-----

### 📦 JJ.Framework

- Pre-release versions of `JJ.Framework` components may be used.
- Those are currently hosted in *Azure DevOps*:
- https://pkgs.dev.azure.com/jjvanzon/1de16010-421a-41a5-90f1-86e9513f2c5b/_packaging/JJs-Pre-Release-Package-Feed/nuget/v3/index.json
- Name: JJs-Pre-Release-Package-Feed
- It might require configuring *NuGet* in your dev environment to connect to this additional package source.

-----

`JJ.Framework` was once part of a larger code base. It was extracted to become a new Git repository with history in tact. Some quirks when checking out older history items, still have to do with that.

Sometimes commit comments may mention *apps* that do not seem to be relevant to the `JJ.Framework`. That is because changes to `JJ.Framework` were in service of making a feature in another app.

The following may only be relevant when getting older commits from history (from before 2018-12-02).

-----

```cs
        
        [TestMethod]
        public void Test_PlatformHelper_CultureInfo_GetCultureInfo_PlatformSafe()
        {
            foreach (string cultureName in new[] { "nl-NL", "en-US", "de-DE", "zh-CN" })
            {
                var cultureInfo1 = CultureInfo.GetCultureInfo(cultureName);
                var cultureInfo2 = new CultureInfo(cultureName);
                var cultureInfo3 = PlatformHelper.CultureInfo_GetCultureInfo_PlatformSafe(cultureName);
                
                IsNotNull(cultureInfo1);
                IsNotNull(cultureInfo2);
                IsNotNull(cultureInfo3);
                
                AreEqual(cultureInfo1.Name, cultureInfo2.Name);
                AreEqual(cultureInfo2.Name, cultureInfo3.Name);
            }
        }
```

-----

CONTRIBUTING:

`[ Drafts: ]`


- The new main uses single-branch-line strategy, or with the branch lines next to it from the legacy, it would get incredibly out of hand with parallel lines.
- The new `main` follows a single-line strategy. `legacy` had multiple branch lines; mixing both would be unmanageable. Merges from `legacy` are allowed, but new branches should stay minimal.
- The new `main` follows a single-line strategy. `legacy` had multiple branch lines; introducing more would make things unmanageable. New development stays on `main`.
- The new `main` follows a single-line strategy. While temporary branches may be used, they are always fast-forward merged to maintain a linear history. Tags are used to mark significant points.
- The new `main` follows a single-line strategy. Temporary branches may be used, but are always fast-forward merged to preserve linear history. Tags mark key points. In a team context, contributors could use `git pull --rebase` to stay aligned.

-----



(cherry picked fd12697546d270d15386b239a2bd980a6955a74d 👨‍💻 JJ.Framework.PlatformCompatibility: No distinction between PlatformHelper and PlatformExtensions.)

-----

The .Core version has parts in it that the suffix-free legacy `JJ.Framework.PlatformCompatibility` is missing, and may still be relied on by certain projects.

-----

    <!--<AssemblyCopyright>Copyright © 2013 - 2025 Jan Joost van Zon</AssemblyCopyright>
    <Copyrightjj>Copyright © 2013 - 2025 Jan Joost van Zon</Copyrightjj>-->

    <!--<Description></Description>-->
    <!--<Authors>JJ van Zon</Authors>-->
    <!--<Copyright>Copyright © 2014 - 2025 Jan Joost van Zon</Copyright>-->
    <!--<Copyright>$(Copyrightjj)</Copyright>-->

-----

*In short: Core-suffixed stuff is mutable. Everything else: basically immutable.*

*Core-suffixed = allowed to change.*  
*Everything else = don’t touch unless you really have to.*

