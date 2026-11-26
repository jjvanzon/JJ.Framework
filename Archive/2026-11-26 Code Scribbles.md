
```xml
  <PropertyGroup>
    <!-- Internal null checks cause to many conflicting code changes. -->
    <!--<Nullable>enable</Nullable>-->
    <!--<WarningsAsErrors>$(WarningsAsErrors);Nullable</WarningsAsErrors>-->
    <!-- But API surface null-checks might not. -->
    <WarningsAsErrors>$(WarningsAsErrors);CA1062</WarningsAsErrors> <!--API surface nulls--> 
  </PropertyGroup>

    
  <PropertyGroup>
    <Nullable>enable</Nullable>
    <WarningsAsErrors>$(WarningsAsErrors);Nullable</WarningsAsErrors>
    <WarningsAsErrors>$(WarningsAsErrors);CA1062</WarningsAsErrors><!--API surface nulls-->
  </PropertyGroup>
```

``cs

/// <inheritdoc cref="_streamhelper" />
public struct _streamhelperlegacy;
```