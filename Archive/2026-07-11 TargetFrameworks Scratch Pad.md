
Compilation.Core.csproj:

```xml
    <!-- Support a whole sweep of .NET versions, to make a statement that run-time compilation supports all of these. -->
    <!-- And NCrunch also can't distinguish 2 TargetFrameworks tags with conditions on them. -->
    <!-- But NCrunch hates net48 combined with netstandard dependencies. -->
    <!--<TargetFrameworks >net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net462;net461;netstandard2.1;netstandard2.0</TargetFrameworks>-->
```

Configuration.Core.Tests.csproj:

```xml
    <!--<TargetFrameworks>net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net461</TargetFrameworks>-->
    <!--<TargetFrameworks>net10.0</TargetFrameworks>-->
    <!--<TargetFrameworks>net10.0;net461</TargetFrameworks>-->
```

JJ.Framework.Configuration.Core.Package.Tests.csproj:

```xml
    <!--<TargetFrameworks Condition="$(IsNCrunch)">net10.0;net5.0;net461</TargetFrameworks>-->
    <!--<TargetFrameworks Condition="$(IsNCrunch)">net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net48;net462;net461</TargetFrameworks> -->
    <!--<TargetFrameworks Condition="$(IsNCrunch)">net10.0</TargetFrameworks>-->
    <!--<SuppressTfmSupportBuildWarnings>True</SuppressTfmSupportBuildWarnings>-->
```

JJ.Framework.Compilation.Core.Package.Tests.csproj:

```xml
    <!-- Not sure why NCrunch refuses net48 and net462. -->
    <!--<TargetFrameworks Condition="$(IsNCrunch)">net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net48;net462;net461</TargetFrameworks> -->
```


JJ.Framework.Compilation.Core.Package.TrimTests.csproj:

```xml
    <!-- TargetFramework is also used for compilations fired off at run-time and those need a stretch of .NET versions for coverage. -->
    <!--<TargetFrameworks Condition="$(IsNCrunch)">net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net48;net462;net461</TargetFrameworks>-->
    <!-- But Trimming only can apply to .NET 5 and onward (we exclude .NET 5 for reasons here. See TargetFrameworks.xml -->
```

JJ.Framework.Configuration.Core.Package.Tests.Dummy.csproj:

```xml
    <!-- This project is compiled at runtime without the Directory.Build.props that defines the IsNCrunch variable.  -->
    <!--<TargetFrameworks Condition="$(IsNCrunch)">net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net48;net462;net461</TargetFrameworks> -->
    <TargetFrameworks>net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net461</TargetFrameworks>
```