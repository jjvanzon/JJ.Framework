# JJ.Framework

*Jan Joost van Zon, 2018-12-02*

Everything works to some extent, but the quality of the components varies. The ones with the highest quality made it to [NuGet](https://www.nuget.org/profiles/jjvanzon). Others might need some more unit testing and some bugs resolved.

`JJ.Framework` contains reusable software components written in C# that are extensions or replacements of parts of the *Microsoft .NET Framework*. In this framework I and our team put any reusable code not related to a particular business domain. There is a separate assembly for each part of .NET that is extended or a separate assembly for each technical aspect. That allows us to be specific about which parts of .NET and other API's we make our applications dependent on, which is a good plan for platform compatibility.

I started programming this framework at home in 2013. Some code is even ported from my previous code base that I started in 2010. I have also used a variation of this code at work in a team of 7 that I lead.

## Quirks when Checking Out Old Commits

`JJ.Framework` was once part of a larger code base. It has been extracted to become a new Git repository with the full history in tact. Some of the quirks when checking out old history items have to do with that.

One funny thing you will see in the history is that commit comments mention apps that do not seem to be relevant to the actual change. That is because changes to *JJ.Framework* were often in service of making a feature in another app.

The following is not relevant unless you get old commits from history (from before 2018-12-02).

* No solution file in the first commits.
	* *JJ.Framework* projects were first only referenced by the solution of the app I made it for. That solution is not in the history, so the first commits have no solution file.
* *JJ.sln* references non-existent projects.
	* Before I open-sourced *JJ.Framework*, there was no *JJ.Framework.sln*.
	* However, there was *JJ.sln*, however it included the projects from other apps too.
	* You can still build even if the projects do not load.
* Missing *NHibernate SQL Logger* files.
	* I made *NHibernate SQL Logger* in my employers time, but programmed it into *JJ.Framework*. I removed it to avoid intellectual property problems.
	* Remove the references to non-existent files.
	* Remove the pieces of code that use `if (SqlLogger.Enabled)`.
* *.NET Framework* mismatches:
	* By not consistently building all solutions upon committing code, these errors slipped in.
	* The symptom is that there are compiler errors. csproj references appear not to work, even though the references are obviously there.
	* You would have to correct the csproj with the lower .NET version (e.g. 3.5) to use the higher .NET version instead (e.g. 4.5).
* *MVC framework*
	* Mismatches 4.0.0.0 vs 4.0.0.1.
	* You would need to correct it so the projects use the same version.
* *Entity Framework*
	* Somehow it is difficult for a newer *Visual Studio* to find *Entity Framework 5*. Mess around until you got some working references to Entity Framework. That is how I do it.
