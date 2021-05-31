JJ.Framework
============

*JJ.Framework* would be extensions to the .NET Framework: like the nuts, bolts and screws of software development: *reusable components*. Some of which might be expected to be there in the .NET Framework, but seem to be missing there.

JJ.Framework might contain reusable code, produced along with real-life applications.


Stability
---------

No software is bug free, but extra effort might have been made, testing the JJ.Framework components that were published to [NuGet](https://www.nuget.org/profiles/jjvanzon) which includes unit tests.

The ones not on NuGet may be available as a sneek peek in [JJs-Pre-Release-Package-Feed](https://dev.azure.com/jjvanzon/JJs-Software/_packaging?_a=feed&feed=JJs-Pre-Release-Package-Feed). But use with caution, because those may not be tested as well. Those may be helped by some more unit testing and may still be a bug or two in it.


History
-------

Any reusable code independent of a particular business domain, may have been moved to this JJ.Framework, for reuse. The reusable code was gathered up between around 2010 and 2020. It may have been a hobby project. But something similar to this framework, may also have been used professionally in a team of 7 under my technical lead at that time.


Modularization
--------------

JJ.Framework may have a separate assembly for each part of .NET that might be extended. Separation may be found between technical aspects. That may allow being specific, on which parts of .NET an application may become dependent.


Platform Compatibility
----------------------

That grip on dependency, might be a good plan for platform compatibility. JJ.Framework may currently be based on .NET 4.6.1 trying to keep it compatible with Mono. Around 2015 JJ.Framework was tested to be reasonably compatible with Mono and by extension Android, iOS and Windows Phone. This was before newer technology like .NET Standard and more recently .NET 5, which might make keeping things platform-compatible easier. For this reason, there may be plans to port JJ.Framework to .NET 5, but this is still for the future.


Setting Up Dev Environment
--------------------------

- Some projects might desire setting up in Internet Information Services (IIS).
- They may not load otherwise.
- Trying to *reload* a web project:
- The Output window in Visual Studio might show an expected web address.
- It is suggested to install IIS.
- Creating a web site for each of the relevant projects.
- Also the Windows hosts file might be changed. Each site added to IIS might need entries in the file `C:\Windows\System32\drivers\etc\hosts`.
- Here follow suggestions for each of the sites to create and their settings.
- (Physical path root folder `C:\Repositories\JJ.Framework` may vary.)

-----

- __JJ.Framework.Soap.Tests.Server__

    - C# project:
        - `JJ.Framework.Soap.Tests.Server.csproj`
    - IIS site name:
        - `TEST_JJ.Framework.Soap.Tests.Server`
    - IIS site physical path:
        - `C:\Repositories\JJ.Framework\Framework\Soap.Tests.Server`
    - IIS site binding host name:
        - `test.jj-framework-soap.jjvanzon.io`
    - hosts file entries:
        - `127.0.0.1  test.jj-framework-soap.jjvanzon.io`
        - `::1        test.jj-framework-soap.jjvanzon.io`

- __JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter__

    - C# project:
        - `JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.csproj`
    - IIS site name:
        - `DEV_JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter`
    - IIS site physical path:
        - `C:\Repositories\JJ.Framework\Demos\ReturnActions.NoViewMapping.Mvc.UrlParameter`
    - IIS site binding host name:
        - `demo-ret-noviewmapping-urlparameter.jjvanzon.io`
    - hosts file entries:
        - `127.0.0.1  demo-ret-noviewmapping-urlparameter.jjvanzon.io`
        - `::1        demo-ret-noviewmapping-urlparameter.jjvanzon.io`

- __JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData__

    - C# project:
        - `JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData.csproj`
    - IIS site name:
        - `DEV_JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData`
    - IIS site physical path:
        - `C:\Repositories\JJ.Framework\Demos\ReturnActions.WithViewMapping.Mvc.PostData`
    - IIS site binding host name:
        - `demo-ret-withviewmapping-postdata.jjvanzon.io`
    - hosts file entries:
        - `127.0.0.1  demo-ret-withviewmapping-postdata.jjvanzon.io`
        - `::1        demo-ret-withviewmapping-postdata.jjvanzon.io`

- __JJ.Demos.ReturnActions.WithViewMapping.Mvc.UrlParameter__

    - C# project:
        - `JJ.Demos.ReturnActions.WithViewMapping.Mvc.UrlParameter.csproj`
    - IIS site name:
        - `DEV_JJ.Demos.ReturnActions.WithViewMapping.Mvc.UrlParameter`
    - IIS site physical path:
        - `C:\Repositories\JJ.Framework\Demos\ReturnActions.WithViewMapping.Mvc.UrlParameter`
    - IIS site binding host name:
        - `demo-ret-withviewmapping-urlparameter.jjvanzon.io`
    - hosts file entries:
        - `127.0.0.1  demo-ret-withviewmapping-urlparameter.jjvanzon.io`
        - `::1        demo-ret-withviewmapping-urlparameter.jjvanzon.io`

Quirks when Checking Out Old Commits
------------------------------------

`JJ.Framework` was once part of a larger code base. It may have been extracted to become a new Git repository with history in tact. Some quirks when checking out older history items, may have to do with that.

Sometimes commit comments may mention apps that do not seem to be relevant to the JJ.Framework change. That may be because changes to *JJ.Framework* may have been in service of making a feature in another app.

The following may only be relevant when getting older commits from history (from before 2018-12-02).

- No solution file in the first commits.
    - *JJ.Framework* projects may first only have been referenced by the solution of the app it was made for. That solution file may not be in the history, so the first commits may have no solution file.
- *JJ.sln* references non-existent projects.
    - Before *JJ.Framework* was open-sourced, there may not have been a *JJ.Framework.sln*.
    - However, there might have been a *JJ.sln*, broader in scope. However it may have included projects from other apps too.
    - It might still build even though the projects may not load.
- Missing *NHibernate SQL Logger* files.
    - *NHibernate SQL Logger* was made in an employers time, but programmed into *JJ.Framework*. It may have been removed from JJ.Framework to avoid intellectual property issues.
    - Perhaps removing the references to non-existent files.
    - Perhaps remove the pieces of code that use `if (SqlLogger.Enabled)`.
- *.NET Framework* mismatches:
    - These errors may have slipped in, by not consistently building all solutions upon committing code.
    - The symptom may be compiler errors. csproj references may appear not to work, even when the references might obviously be there.
    - Perhaps correct the csproj with the lower .NET version (e.g. 3.5) to use the higher .NET version instead (e.g. 4.5).
- *MVC Framework*
    - Mismatches 4.0.0.0 vs 4.0.0.1.
    - Perhaps correct it so the projects use the same version.
- *Entity Framework*
    - It seems difficult for a newer *Visual Studio* to find (the older) *Entity Framework 5*. Messing around until you got some working references to Entity Framework might be the only advice at hand here.
