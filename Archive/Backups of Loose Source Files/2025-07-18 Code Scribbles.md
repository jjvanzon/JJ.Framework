### Attempt to Force Code Coverage in Trimming.TestApps

```xml
  <!-- Force Code Coverage -->
  <PropertyGroup>
    <!--<AnalysisMode>AllEnabledByDefault</AnalysisMode>-->
    <!--<WarningsAsErrors>$(WarningsAsErrors);IDE0035</WarningsAsErrors>--> <!-- Unreachable code -->
    <!--<WarningsAsErrors>$(WarningsAsErrors);IDE0051</WarningsAsErrors>--> <!-- Unused private member -->
    <!--<WarningsAsErrors>$(WarningsAsErrors);IDE0052</WarningsAsErrors>--> <!-- Unread private member -->
    <!--<WarningsAsErrors>$(WarningsAsErrors);IDE0060</WarningsAsErrors>--> <!-- Unused parameter -->
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Roslynator.Analyzers" Version="4.*" PrivateAssets="all" />
  </ItemGroup>
  <PropertyGroup>
    <WarningsAsErrors>$(WarningsAsErrors);RCS1125</WarningsAsErrors> <!-- RCS1125 = Remove unused type -->
  </PropertyGroup>
```

```xml
  <ItemGroup>
    <PackageReference Include="Roslynator.Analyzers" Version="4.*" PrivateAssets="all" />
  </ItemGroup>

  <PropertyGroup>
    <AnalysisMode>Default</AnalysisMode>
    <NoWarn>$(NoWarn);RCS1102</NoWarn>
    <WarningsAsErrors>$(WarningsAsErrors);RCS1125</WarningsAsErrors>
  </PropertyGroup>
```