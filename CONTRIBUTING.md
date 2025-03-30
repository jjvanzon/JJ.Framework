Contributing to JJ.Framework
============================

__📔 Contents__

- [⚙ Dev Env](#-dev-env)
    - [📦 JJ.Framework](#-jjframework)
    - [🌐 Internet Information Services (IIS)](#-internet-information-services-iis)
    - [💽 SQL Server](#-sql-server)
- [🧓 Checking Out Old Commits](#-checking-out-old-commits)


Here you can find instructions to set up your dev environment so `JJ.Framework.sln` can be built.


⚙ Dev Env
-----------

### 📦 JJ.Framework

- Pre-release versions of `JJ.Framework` components may be used.
- Those are currently hosted in *Azure DevOps*:
- https://pkgs.dev.azure.com/jjvanzon/1de16010-421a-41a5-90f1-86e9513f2c5b/_packaging/JJs-Pre-Release-Package-Feed/nuget/v3/index.json
- Name: JJs-Pre-Release-Package-Feed
- It might require configuring *NuGet* in your dev environment to connect to this additional package source.

### 🌐 Internet Information Services (IIS)

- You can enable `IIS` with "Turn Windows features on or off" (search in the `Start` menu).
- The following options have been known to work on `Windows 11`:  
  <img src="resources/iis-components.png" width="250" />
- Some projects need `Internet Information Services (IIS)`.
- They might not load otherwise.
- Create a web site for each of the relevant projects below.
- Also change the `Windows hosts` file. Each site added to `IIS` might need to be mentioned in the file `C:\Windows\System32\drivers\etc\hosts`.
- Try *reloading* a web project:
- The Output window in `Visual Studio` might show an expected web address.
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

### 💽 SQL Server

SQL Server *is* used by some of the automated tests, but they may fail gracefully with an inconclusive result. Anyway, the database files may or may not even be included in this code base either.


🧓 Checking Out Old Commits
----------------------------

`JJ.Framework` was once part of a larger code base. It was extracted to become a new Git repository with history in tact. Some quirks when checking out older history items, still have to do with that.

Sometimes commit comments may mention *apps* that do not seem to be relevant to the `JJ.Framework`. That is because changes to `JJ.Framework` were in service of making a feature in another app.

The following may only be relevant when getting older commits from history (from before 2018-12-02).

- No solution file in the first commits.
    - `JJ.Framework` projects were first only referenced by the solution of the app it was made for. Those solutions are not be in the history here, so the first commits may have no solution file.
- `JJ.sln` references non-existent projects.
    - Before `JJ.Framework` was open-sourced, there might not have been a `JJ.Framework.sln`.
    - However, what you might find there is a `JJ.sln`, broader in scope.
    - However it would include projects from other apps too.
    - It might still build even though some projects may not load.
- Missing *NHibernate SQL Logger* files.
    - *NHibernate SQL Logger* was made in  employer's time, but programmed into the `JJ.Framework`. It was removed out of the `JJ.Framework` to avoid intellectual property issues.
    - Remove references to non-existent files.
    - Remove the pieces of code that use `if (SqlLogger.Enabled)` and it will work.
- *.NET Framework* mismatches:
    - These errors may have slipped in, by not consistently building all solutions upon committing code.
    - The symptom would be compiler errors. `csproj` references may appear not to work, even when the references are obviously there.
    - Correct the `csproj` with the lower `.NET` version (e.g. `3.5`) to use the higher `.NET` version instead (e.g. `4.5`).
- *MVC Framework*
    - Mismatches `4.0.0.0` vs `4.0.0.1`.
    - Correct it so the projects use the same version (using NuGet).
- *Entity Framework*
    - It seems difficult for a newer *Visual Studio* to find (the older) *Entity Framework 5*. Messing around until you got some working references to Entity Framework might be the only advice at hand here.
