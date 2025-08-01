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

### Existence.Core's former reason to exclude net5.0, then readded to ensure trimming compatibility

```xml
    <!--We do not explicitly conditionally compile for net5.0 features, so strictly we don't need it.-->
    <!--And by excluding it our net5.0 tests we hit the netstandard2.1 compilation.-->
```

### Docs in *.Tests.Helper projects not needed

```cs
/// <inheritdoc cref="_dummyclass" />
/// <inheritdoc cref="_idummy" />
```

### Deprecated Directory.Build.props Content

```xml
  <!--<PropertyGroup Condition="'$(IsTest)'!='True' And '$(IsTrimTest)'!='True'">-->
  <!--<CopyToOutputDirectory>Always</CopyToOutputDirectory>-->
      <!--<CopyToOutputDirectory>Always</CopyToOutputDirectory>-->
      <!--<CopyToOutputDirectory>Always</CopyToOutputDirectory>-->
```


### Trimming / AOT

```cs
            #if NET9_0_OR_GREATER
                Array array = Array.CreateInstanceFromArrayType(typeof(T));
            #endif

          //#if NET7_0_OR_GREATER
            where T : struct, Enum
          //#else
          //where T : struct
          //#endif

          //#if NET7_0_OR_GREATER
            T[] enumValues = Enum.GetValues<T>(); // Trim-safe variant.
          //#else
          //T[] enumValues = (T[])Enum.GetValues(typeof(T));
          //#endif
```

```xml
    <!--<PublishProtocol>FileSystem</PublishProtocol>-->
    <!--<_TargetId>Folder</_TargetId>-->

```
