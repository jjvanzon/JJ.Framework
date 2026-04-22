
```xml
  <!-- Tame NCrunch -->
  <PropertyGroup>
    <TargetFrameworks>net10.0;netstandard2.1;netstandard2.0</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTest)">net10.0;net5.0;net461</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTrimTest)">net10.0;net5.0</TargetFrameworks>
  </PropertyGroup>

  <!-- Non-NCrunch -->
  <PropertyGroup Condition="'$(IsNCrunch)'!='True'">
    <TargetFrameworks>net10.0;net9.0;net8.0;net7.0;net6.0;netstandard2.1;netstandard2.0</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTest)">net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net461</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTrimTest)">net10.0;net9.0;net8.0;net7.0;net6.0;net5.0</TargetFrameworks>
  </PropertyGroup>

  <!-- Non-SDK -->
  <PropertyGroup Condition="$(IsNet48)">
    <TargetFrameworks></TargetFrameworks>
  </PropertyGroup>
```

```
<Project>
  <!-- Default Targets -->
  <PropertyGroup Condition="!$(IsNCrunch)">
    <TargetFrameworks                          >net10.0;net9.0;net8.0;net7.0;net6.0;netstandard2.1;netstandard2.0</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTest)"    >net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net461</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTrimTest)">net10.0;net9.0;net8.0;net7.0;net6.0;net5.0</TargetFrameworks>
  </PropertyGroup>
  
  <!-- Tame NCrunch -->
  <!-- NOTE: Does not work centrally. Repeated in csprojs. -->
  <PropertyGroup Condition="$(IsNCrunch)">
    <TargetFrameworks>net10.0;netstandard2.1;netstandard2.0</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTest)">net10.0;net5.0;net461</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTrimTest)">net10.0;net5.0</TargetFrameworks>
  </PropertyGroup>

  <!-- .NET 4.8 / Non-SDK -->
  <PropertyGroup Condition="$(IsNet48)">
    <TargetFrameworks></TargetFrameworks>
  </PropertyGroup>
</Project>
```


```xml
  <!-- Tame NCrunch -->
  <!-- NOTE: Does not work centrally. Repeated in csprojs. -->
  <PropertyGroup Condition="$(IsNCrunch)">
    <TargetFrameworks>net10.0;netstandard2.1;netstandard2.0</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTest)">net10.0;net5.0;net461</TargetFrameworks>
    <TargetFrameworks Condition="$(IsTrimTest)">net10.0;net5.0</TargetFrameworks>
  </PropertyGroup>
```